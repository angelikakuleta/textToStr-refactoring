using System.Collections.Generic;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation.Splitters
{
    internal static class RuleComposition
    {
        public static ITwoWaySplitter WithShortestLeft(this IEnumerable<ITwoWaySplitter> splitters) =>
            new ShortestLeftWins(splitters);

        public static ITwoWaySplitter WithLongestLeft(this ITwoWaySplitter splitter) =>
    new LongestLeftWins(splitter);

        public static ITwoWaySplitter Append(this ITwoWaySplitter head, ITwoWaySplitter tail) =>
            new AppendSplitter(head, tail);

        public static IMultiwaySplitter Repeat(this ITwoWaySplitter splitter) =>
            new TwoWayRepeater(splitter);

        public static ITwoWaySplitter WithLeftNotShorterThan(this ITwoWaySplitter rule, int minLength) =>
            new LeftMinimumLength(rule, minLength);

        public static ITwoWaySplitter WithLeftNotLongerThan(this ITwoWaySplitter rule, int maxLength) =>
            new LeftMaximumLength(rule, maxLength);

        public static ITwoWaySplitter FirstWins(this ITwoWaySplitter rule) =>
            new FirstWins(rule);
    }
}
