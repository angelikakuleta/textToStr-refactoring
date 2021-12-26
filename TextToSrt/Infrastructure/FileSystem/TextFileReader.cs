using SubtitlesConverter.Domain;
using SubtitlesConverter.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SubtitlesConverter.Infrastructure.FileSystem
{
    class TextFileReader : ITextReader
    {
        private FileInfo Source { get; }

        public TextFileReader(FileInfo source)
        {
            Source = source;
        }

        // property getter indicates a cheap operation, for expensive operation use method instead
        public TimedText Read() => ParseSource();

        private TimedText ParseSource()
        {
            if (Source is null) return TimedText.Empty;

            TimeSpan? initial = null;
            TimeSpan? final = null;
            List<string> content = new List<string>();
            bool beginInTimeStamp = true;
            bool endInTimeSpan = false;

            foreach (string line in File.ReadAllLines(Source.FullName, Encoding.UTF8))
            {
                if (Parse(line) is TimeSpan time)
                {
                    initial ??= time;
                    final = time;
                    endInTimeSpan = true;
                }
                else
                {
                    content.Add(line);
                    beginInTimeStamp = beginInTimeStamp && initial.HasValue;
                    endInTimeSpan = false;
                }
            }

            if (!beginInTimeStamp || !endInTimeSpan)
                throw new InvalidOperationException("Source file is not structured correctly.");

            TimeSpan duration = final.Value.Subtract(initial.Value);
            return new TimedText(content, duration);
        }

        private object Parse(string line)
        {
            Regex timePattern = new Regex(@"^\s*(?<minutes>\d+):(?<seconds>\d+)\s*$");
            Match match = timePattern.Match(line);

            if (!match.Success) return line;

            int minutes = int.Parse(match.Groups["minutes"].Value);
            int seconds = int.Parse(match.Groups["seconds"].Value);

            return new TimeSpan(0, minutes, seconds);
        }
    }
}
