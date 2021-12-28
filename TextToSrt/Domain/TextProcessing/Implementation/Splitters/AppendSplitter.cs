using System.Collections.Generic;
using System.Linq;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation.Splitters
{
    // composite rule
    internal class AppendSplitter : ITwoWaySplitter
    {
        private ITwoWaySplitter Head { get; }
        private ITwoWaySplitter Tail { get; }

        public AppendSplitter(ITwoWaySplitter head, ITwoWaySplitter tail)
        {
            Head = head;
            Tail = tail;
        }

        public IEnumerable<(string left, string right)> ApplyTo(string line) =>
            Head.ApplyTo(line)
            .Concat(Tail.ApplyTo(line));
    }
}
