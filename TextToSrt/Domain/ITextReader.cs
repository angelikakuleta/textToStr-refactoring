using SubtitlesConverter.Domain.Models;
using System.Collections.Generic;

namespace SubtitlesConverter.Domain
{
    interface ITextReader
    {
        IEnumerable<TimedText> Read();
    }
}