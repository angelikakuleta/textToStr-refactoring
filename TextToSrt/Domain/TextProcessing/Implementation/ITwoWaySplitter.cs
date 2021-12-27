using System.Collections.Generic;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation
{
    public interface ITwoWaySplitter
    {
        IEnumerable<(string left, string right)> ApplyTo(string line);
    }
}