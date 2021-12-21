using System.Collections.Generic;

namespace SubtitlesConverter.Domain
{
    interface ITextProcessor
    {
        IEnumerable<string> Execute(IEnumerable<string> text);
    }
}