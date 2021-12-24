using System;

namespace SubtitlesConverter.Domain.Models
{
    class SubtitleLine
    {
        public string Content { get; }
        public TimeSpan Duration { get; }

        public SubtitleLine(string content, TimeSpan duration)
        {
            Content = content.Trim();
            Duration = duration;
        }

        public override string ToString() =>
            $"{Duration} --> {Content}";
    }
}
