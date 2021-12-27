using System.Collections.Generic;
using System.Linq;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation
{
    class SentencesBreaker : ITextProcessor
    {
        private ITwoWaySplitter Rules { get; } = new[]
        {
            RegexSplitter.LeftAndRightExtractor(@"^(?<left>[^\?*]+\?)\s*(?<right>.*)$"),
            RegexSplitter.LeftAndRightExtractor(@"^(?<left>[^\!*]+\!)\s*(?<right>.*)$"),
            RegexSplitter.LeftAndRightExtractor(@"^(?<left>(?:(?:\.\.\.)|[^\.])+)\.\s*(?<right>.*)$"),
            RegexSplitter.LeftAndRightExtractor(@"(?<left>^.*\.\.\.)(?=(?:\s+\p{Lu})|(?:\s+\p{Lt})|\s*$)\s*(?<right>.*)$"),
            RegexSplitter.LeftAndRightExtractor(@"^(?<left>.*(?<!\.))\.(?=$)(?<right>)$"),
            RegexSplitter.LeftAndRightExtractor(@"^(?<left>.*)(?:[\:\;\,]|\s+-\s*)(?<right>)$"),
        }
        .WithShortestLeft();

        public IEnumerable<string> Execute(IEnumerable<string> text) =>
            text.SelectMany(Break);

        private IEnumerable<string> Break(string text)
        {
            string remaining = text.Trim();
            while (remaining.Length > 0)
            {
                (string extracted, string rest) = Rules.ApplyTo(remaining).First();

                yield return extracted;
                remaining = rest;
            }
        }
    }
}