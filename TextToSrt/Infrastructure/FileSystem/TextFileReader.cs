using SubtitlesConverter.Domain;
using SubtitlesConverter.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public IEnumerable<TimedText> Read() => ParseSource();

        private IEnumerable<TimedText> ParseSource()
        {
            if (Source is null) yield break;

            IList<string> pendingLines = new List<string>();
            TimeSpan lastKnownTime = TimeSpan.Zero;

            foreach (string line in File.ReadAllLines(Source.FullName, Encoding.UTF8))
            {
                if (Parse(line) is TimeSpan time)
                {
                    if (pendingLines.Any())
                    {
                        TimeSpan duration = time - lastKnownTime;
                        yield return new TimedText(pendingLines, lastKnownTime, duration);
                        pendingLines.Clear();                  
                    }
                    lastKnownTime = time;
                }
                else
                {
                    string trimmed = line.Trim();
                    if (trimmed.Length > 0)
                        pendingLines.Add(line);
                }
            }

            if (pendingLines.Any())
                throw new InvalidOperationException("Input text must end in a timestamp.");
        }

        private object Parse(string line)
        {
            Regex timePattern = new Regex(@"^\s*(?<minutes>\d+):(?<seconds>\d+)(?:\.(?<fractional>\d{1,3}))?\s*$");
            Match match = timePattern.Match(line);

            if (!match.Success) return line;

            int minutes = int.Parse(match.Groups["minutes"].Value);
            int seconds = int.Parse(match.Groups["seconds"].Value);
            int milliseconds = match.Groups["fractional"].Success
                ? int.Parse(match.Groups["fractional"].Value.PadRight(3, '0'))
                : 0;

            return new TimeSpan(0, minutes, seconds, milliseconds);
        }
    }
}
