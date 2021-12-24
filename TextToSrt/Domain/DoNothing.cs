using System;
using System.Collections.Generic;

namespace SubtitlesConverter.Domain
{
    class DoNothing : ITextProcessor
    {
        public IEnumerable<string> Execute(IEnumerable<string> text) =>
            text;
    }
}
