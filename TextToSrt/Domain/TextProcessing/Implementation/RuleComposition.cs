﻿using System.Collections.Generic;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation
{
    internal static class RuleComposition
    {
        public static ITwoWaySplitter WithShortestLeft(this IEnumerable<ITwoWaySplitter> splitters) =>
            new ShortestLeftWins(splitters);
    }
}
