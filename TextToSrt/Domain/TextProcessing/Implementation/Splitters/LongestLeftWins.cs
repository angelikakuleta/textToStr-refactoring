using System.Collections.Generic;
using SubtitlesConverter.Common;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation.Splitters
{
    internal class LongestLeftWins : ITwoWaySplitter
    {
        private ITwoWaySplitter Splitter { get; }
        
        public LongestLeftWins(ITwoWaySplitter splitter)
        {
            this.Splitter = splitter;
        }

        public IEnumerable<(string left, string right)> ApplyTo(string line) =>
            this.Splitter.ApplyTo(line)
                .WithMaximumOrEmpty(tuple => tuple.left.Length);
    }
}
