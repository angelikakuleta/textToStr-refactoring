using System;

namespace SubtitlesConverter.Domain.Models
{
    public class SubtitleLine
    {
        public TimeSpan BeginOffset { get; }
        public TimeSpan EndOffset { get; }
        public string Content { get; }

        public SubtitleLine(TimeSpan beginOffset, TimeSpan endOffset, string content)
        {
            BeginOffset = beginOffset;
            EndOffset = endOffset;
            Content = content ?? string.Empty;
        }
    }
}
