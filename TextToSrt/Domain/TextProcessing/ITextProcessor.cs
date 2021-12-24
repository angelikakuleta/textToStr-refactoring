using System.Collections.Generic;

namespace SubtitlesConverter.Domain.TextProcessing
{
    interface ITextProcessor
    {
        IEnumerable<string> Execute(IEnumerable<string> text);
    }
}