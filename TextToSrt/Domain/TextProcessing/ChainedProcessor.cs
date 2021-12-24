using System;
using System.Collections.Generic;

namespace SubtitlesConverter.Domain.TextProcessing
{
    class ChainedProcessor : ITextProcessor
    {
        private ITextProcessor Inner { get; }
        private ITextProcessor Next { get; }

        public ChainedProcessor(ITextProcessor inner, ITextProcessor next)
        {
            Inner = inner;
            Next = next;
        }

        public IEnumerable<string> Execute(IEnumerable<string> text) =>
            Next.Execute(Inner.Execute(text));
    }

    static class ChainConstruction
    {
        public static ITextProcessor Then(this ITextProcessor first, ITextProcessor next) =>
            first is DoNothing ? next
            : next is DoNothing ? first
            : new ChainedProcessor(first, next);
    }
}
