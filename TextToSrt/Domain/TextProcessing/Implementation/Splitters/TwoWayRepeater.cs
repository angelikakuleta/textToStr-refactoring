using System.Collections.Generic;
using System.Linq;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation.Splitters
{
    class TwoWayRepeater : IMultiwaySplitter
    {
        private ITwoWaySplitter Splitter { get; }

        public TwoWayRepeater(ITwoWaySplitter splitter)
        {
            Splitter = splitter;
        }

        public IEnumerable<string> ApplyTo(string line)
        {
            string remaining = line.Trim();
            while (remaining.Length > 0)
            {
                (string extracted, string rest) = Splitter.ApplyTo(remaining).First();

                yield return extracted;
                remaining = rest;
            }

        }
    }
}
