﻿using SubtitlesConverter.Domain.TextProcessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SubtitlesConverter.Domain
{
    class Subtitles : LinesTrimmer
    {
        private IEnumerable<SubtitleLine> Lines { get; }

        public Subtitles(IEnumerable<SubtitleLine> lines)
        {
            Lines = lines.ToList();
        }

        public static Subtitles Parse(string[] text, TimeSpan clipDuration)
        {
            ITextProcessor parsing = 
                new LinesTrimmer()
                    .Then(new SentencesBreaker())
                    .Then(new LinesBreaker(95, 45));
            
            IEnumerable<string> lines = parsing.Execute(text).ToList();

            TextDurationMeter durationMeter = new TextDurationMeter(lines, clipDuration);
            IEnumerable<SubtitleLine> subtitles = lines
                .Select(line => (text: line, duration: durationMeter.EstimateDuration(line)))
                .Select(tuple => new SubtitleLine(tuple.text, tuple.duration));
            return new Subtitles(subtitles);
        }

        public void SaveAsStr(FileInfo destination) =>
            File.WriteAllLines(destination.FullName, GenerateSrtFileContent(), Encoding.UTF8);

        private IEnumerable<string> GenerateSrtFileContent() =>
            GenerateLineBoundaries()
                .SelectMany((tuple, index) =>
                new[]
                {
                    $"{index + 1}",
                    $"{tuple.begin:hh\\:mm\\:ss\\,fff} --> {tuple.end:hh\\:mm\\:ss\\,fff}",
                    $"{tuple.content}",
                    string.Empty
                });

        private IEnumerable<(TimeSpan begin, TimeSpan end, string content)> GenerateLineBoundaries()
        {
            TimeSpan begin = new TimeSpan(0);
            foreach (SubtitleLine line in Lines)
            {
                TimeSpan end = begin + line.Duration;
                yield return (begin, end, line.Content);
                begin = end;
            }
        }
    }
}
