using System.Collections.Generic;
using SubtitlesConverter.Domain.TextProcessing;

namespace SubtitlesConverter.Domain
{
    class SubtitlesBuilder
    {
        private TimedText Text { get; set; } = TimedText.Empty;
        ITextProcessor Processing { get; set; } = new DoNothing();

        public SubtitlesBuilder For(TimedText text)
        {
            Text = text;
            return this;
        }

        public SubtitlesBuilder Using(ITextProcessor processor)
        {
            Processing = Processing.Then(processor);
            return this;
        }

        public Subtitles Build()
        {
            TimedText processed = Text.Apply(Processing);
            TextDurationMeter durationMeter = new TextDurationMeter(processed);
            IEnumerable<SubtitleLine> subtitles = durationMeter.MeasureLines();
            return new Subtitles(subtitles);
        }
    }
}
