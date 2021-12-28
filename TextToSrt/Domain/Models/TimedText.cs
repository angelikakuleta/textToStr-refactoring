using SubtitlesConverter.Domain.TextProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubtitlesConverter.Domain.Models
{
    class TimedText
    {
        public IEnumerable<string> Content { get; }
        public TimeSpan Offset { get; } // when it begins
        public TimeSpan Duration { get; }
        public static TimedText Empty { get; } =
            new TimedText(Enumerable.Empty<string>(), TimeSpan.Zero, TimeSpan.Zero);

        public TimedText(IEnumerable<string> content, TimeSpan offset, TimeSpan duration)
        {
            Content = content.ToList();
            Offset = offset;
            Duration = duration;
        }

        public TimedText Apply(ITextProcessor processor) =>
            new TimedText(processor.Execute(Content), Offset, Duration);
    }
}
