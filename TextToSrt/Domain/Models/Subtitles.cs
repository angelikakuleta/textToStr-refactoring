using SubtitlesConverter.Domain.TextProcessing.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubtitlesConverter.Domain.Models
{
    class Subtitles : LinesTrimmer
    {
        private IEnumerable<TimedLine> Lines { get; }

        public Subtitles(IEnumerable<TimedLine> lines)
        {
            Lines = lines.ToList();
        }

        public void Accept(ISubtitlesVisitor visitor)
        {
            TimeSpan begin = new TimeSpan(0);
            foreach (TimedLine line in Lines)
            {
                TimeSpan end = begin + line.Duration;
                visitor.Visit(new SubtitleLine(begin, end, line.Content));
                begin = end;
            }
        }
    }
}
