using System;

namespace SubtitlesConverter.Domain.Models
{
    class TimedLine
    {
        public string Content { get; }
        public TimeSpan Duration { get; }

        public TimedLine(string content, TimeSpan duration)
        {
            Content = content.Trim();
            Duration = duration;
        }

        public override string ToString() =>
            $"{Duration} --> {Content}";
    }
}
