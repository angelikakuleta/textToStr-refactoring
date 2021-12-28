﻿using System.Collections.Generic;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation.Rules
{
    internal static class RuleComposition
    {
        public static ITwoWaySplitter WithShortestLeft(this IEnumerable<ITwoWaySplitter> splitters) =>
            new ShortestLeftWins(splitters);

        public static IMultiwaySplitter Repeat(this ITwoWaySplitter splitter) =>
            new TwoWayRepeater(splitter);
    }
}
