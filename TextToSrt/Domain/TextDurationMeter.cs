﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SubtitlesConverter.Domain
{
    internal class TextDurationMeter
    {
        private TimedText Text { get; }

        public TextDurationMeter(TimedText text)
        {
            Text = text;
        }

        public IEnumerable<SubtitleLine> MeasureLines() =>
            MeasureLines(GetFullTextWeight());

        public IEnumerable<SubtitleLine> MeasureLines(double fullTextWeight) =>
            Text.Content
                .Select(line => (
                    line: line,
                    relativeWeight: CountReadableLetters(line) / fullTextWeight))
                .Select(tuple => (
                    line: tuple.line,
                    miliseconds: Text.Duration.TotalMilliseconds * tuple.relativeWeight))
                .Select(tuple => new SubtitleLine(
                    tuple.line,
                    TimeSpan.FromMilliseconds(tuple.miliseconds)));

        private double GetFullTextWeight() =>
            Text.Content.Sum(CountReadableLetters);

        private int CountReadableLetters(string text) =>
            Regex.Matches(text, @"w+").Sum(match => match.Value.Length);
    }
}