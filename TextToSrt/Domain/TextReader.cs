using SubtitlesConverter.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SubtitlesConverter.Domain
{
    internal class TextReader : ITextReader
    {
        public static ITextReader Empty { get; } = new TextReader();

        private TextReader() { }
        public IEnumerable<TimedText> Read() => Enumerable.Empty<TimedText>();
    }
}
