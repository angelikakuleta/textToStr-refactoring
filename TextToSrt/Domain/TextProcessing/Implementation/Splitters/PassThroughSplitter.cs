using System.Collections.Generic;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation.Splitters
{
    internal class PassThroughSplitter : ITwoWaySplitter
    {
        public IEnumerable<(string left, string right)> ApplyTo(string line) =>
            new[] {(line, string.Empty)};
    }
}
