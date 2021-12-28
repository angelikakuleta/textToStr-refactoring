using System.Collections.Generic;
using System.Linq;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation.Splitters
{
    internal class FirstWins : ITwoWaySplitter
    {
        private ITwoWaySplitter Splitter { get; }
        
        public FirstWins(ITwoWaySplitter splitter)
        {
            this.Splitter = splitter;
        }

        public IEnumerable<(string left, string right)> ApplyTo(string line) =>
            this.Splitter.ApplyTo(line).Take(1);
    }
}
