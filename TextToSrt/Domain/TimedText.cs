using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubtitlesConverter.Domain
{
    class TimedText
    {
        public IEnumerable<string> Content { get; }
        public TimeSpan Duration { get; }

        public TimedText(IEnumerable<string> content, TimeSpan duration)
        {
            Content = content.ToList();
            Duration = duration;
        }

        public TimedText Apply(ITextProcessor processor) =>
            new TimedText(processor.Execute(this.Content), this.Duration);
    }
}
