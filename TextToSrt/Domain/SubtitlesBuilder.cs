using SubtitlesConverter.Domain.Models;
using SubtitlesConverter.Domain.TextProcessing;
using SubtitlesConverter.Infrastructure.FileSystem;
using System.Collections.Generic;

namespace SubtitlesConverter.Domain
{
    class SubtitlesBuilder
    {
        private ITextReader Reader { get; set; } = TextReader.Empty;
        ITextProcessor Processing { get; set; } = new DoNothing();

        public SubtitlesBuilder For(TextFileReader source)
        {
            Reader = source;
            return this;
        }

        public SubtitlesBuilder Using(ITextProcessor processor)
        {
            Processing = Processing.Then(processor);
            return this;
        }

        public Subtitles Build()
        {
            TimedText processed = Reader.Read().Apply(Processing);
            TextDurationMeter durationMeter = new TextDurationMeter(processed);
            IEnumerable<TimedLine> subtitles = durationMeter.MeasureLines();
            return new Subtitles(subtitles);
        }
    }
}
