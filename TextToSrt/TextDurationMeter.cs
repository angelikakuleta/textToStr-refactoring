using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextToSrt
{
    internal class TextDurationMeter
    {
        private double FullTextLength { get; }
        private TimeSpan FullTextDuration { get; }

        public TextDurationMeter(IEnumerable<string> fullText, TimeSpan clipDuration)
        {
            this.FullTextLength = fullText.Sum(this.CountRaedableLetters);
            this.FullTextDuration = clipDuration;
        }

        public TimeSpan EstimateDuration(string text) =>
            TimeSpan.FromMilliseconds(this.EstimateMilliseconds(text));

        private double EstimateMilliseconds(string text) =>
            this.FullTextDuration.TotalMilliseconds * this.GetRelativeLength(text);

        private double GetRelativeLength(string text) =>
            this.CountRaedableLetters(text) / this.FullTextLength;

        private int CountRaedableLetters(string text) =>
            Regex.Matches(text, @"w+").Sum(match => match.Value.Length);
    }
}