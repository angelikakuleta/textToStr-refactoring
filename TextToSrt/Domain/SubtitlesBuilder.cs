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
            Subtitles subtitles = new Subtitles();

            foreach(TimedText block in Reader.Read())
            {
                TimedText processed = block.Apply(Processing);
                TextDurationMeter durationMeter = new TextDurationMeter(processed);
                IEnumerable<TimedLine> lines = durationMeter.MeasureLines();
                subtitles.Append(lines, block.Offset);

            }

            return subtitles;
        }
    }
}
