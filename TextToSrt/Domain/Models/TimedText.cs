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
        public TimeSpan Duration { get; }
        public static TimedText Empty { get; } =
            new TimedText(Enumerable.Empty<string>(), TimeSpan.Zero);

        public TimedText(IEnumerable<string> content, TimeSpan duration)
        {
            Content = content.ToList();
            Duration = duration;
        }

        public TimedText Apply(ITextProcessor processor) =>
            new TimedText(processor.Execute(Content), Duration);
    }
}
