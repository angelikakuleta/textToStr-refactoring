using SubtitlesConverter.Common;
using System.Collections.Generic;
using System.Linq;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation.Splitters
{
    // Composite rule
    class ShortestLeftWins : ITwoWaySplitter
    {
        private IEnumerable<ITwoWaySplitter> Splitters { get; } // composition

        public ShortestLeftWins(IEnumerable<ITwoWaySplitter> splitters)
        {
            Splitters = splitters;
        }

        public IEnumerable<(string left, string right)> ApplyTo(string line) =>
            Splitters
                .SelectMany(rule => rule.ApplyTo(line))
                .DefaultIfEmpty((left: line, right: string.Empty))
                .WithMinimumOrEmpty(tuple => tuple.left.Length);
    }
}
