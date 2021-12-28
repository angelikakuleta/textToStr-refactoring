using System.Collections.Generic;
using System.Linq;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation.Splitters
{
    internal class LeftMaximumLength : ITwoWaySplitter
    {
        private ITwoWaySplitter Rule { get; }
        private int MaxLength { get; }

        public LeftMaximumLength(ITwoWaySplitter rule, int maxLength)
        {
            this.Rule = rule;
            this.MaxLength = maxLength;
        }

        public IEnumerable<(string left, string right)> ApplyTo(string line) =>
            this.Rule.ApplyTo(line)
                .Where(tuple => tuple.left.Length <= this.MaxLength);
    }
}
