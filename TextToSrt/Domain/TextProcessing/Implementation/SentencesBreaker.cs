using SubtitlesConverter.Domain.TextProcessing.Implementation.Splitters;

namespace SubtitlesConverter.Domain.TextProcessing.Implementation
{
    // this class is now declarative
    public class SentencesBreaker : RuleBasedProcessor
    {
        protected override IMultiwaySplitter Splitter { get; } = new[]
        {
            RegexSplitter.LeftAndRightExtractor(@"^(?<left>[^\?*]+\?)\s*(?<right>.*)$"),
            RegexSplitter.LeftAndRightExtractor(@"^(?<left>[^\!*]+\!)\s*(?<right>.*)$"),
            RegexSplitter.LeftAndRightExtractor(@"^(?<left>(?:(?:\.\.\.)|[^\.])+)\.\s*(?<right>.*)$"),
            RegexSplitter.LeftAndRightExtractor(@"(?<left>^.*\.\.\.)(?=(?:\s+\p{Lu})|(?:\s+\p{Lt})|\s*$)\s*(?<right>.*)$"),
            RegexSplitter.LeftAndRightExtractor(@"^(?<left>.*(?<!\.))\.(?=$)(?<right>)$"),
            RegexSplitter.LeftAndRightExtractor(@"^(?<left>.*)(?:[\:\;\,]|\s+-\s*)(?<right>)$"),
        }
        .WithShortestLeft()
        .Repeat();
    }
}