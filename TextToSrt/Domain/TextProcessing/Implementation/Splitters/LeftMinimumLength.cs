using System.Collections.Generic;
using System.Linq;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation.Splitters
{
    internal class LeftMinimumLength : ITwoWaySplitter
    {
        private ITwoWaySplitter Rule { get; }
        private int MinLength { get; }

        public LeftMinimumLength(ITwoWaySplitter rule, int minLength)
        {
            this.Rule = rule;
            this.MinLength = minLength;
        }

        public IEnumerable<(string left, string right)> ApplyTo(string line) =>
            this.Rule.ApplyTo(line)
                .Where(tuple => tuple.left.Length >= this.MinLength);
    }
}
