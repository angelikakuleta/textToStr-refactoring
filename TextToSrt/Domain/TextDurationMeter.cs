using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SubtitlesConverter.Domain
{
    internal class TextDurationMeter
    {
        private double FullTextLength { get; }
        private TimeSpan FullTextDuration { get; }

        public TextDurationMeter(IEnumerable<string> fullText, TimeSpan clipDuration)
        {
            FullTextLength = fullText.Sum(CountRaedableLetters);
            FullTextDuration = clipDuration;
        }

        public TimeSpan EstimateDuration(string text) =>
            TimeSpan.FromMilliseconds(EstimateMilliseconds(text));

        private double EstimateMilliseconds(string text) =>
            FullTextDuration.TotalMilliseconds * GetRelativeLength(text);

        private double GetRelativeLength(string text) =>
            CountRaedableLetters(text) / FullTextLength;

        private int CountRaedableLetters(string text) =>
            Regex.Matches(text, @"w+").Sum(match => match.Value.Length);
    }
}