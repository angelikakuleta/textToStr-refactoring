using System;

namespace TextToSrt
{
    class CaptionLine
    {
        public string Content { get; }
        public TimeSpan Duration { get; }

        public CaptionLine(string content, TimeSpan duration)
        {
            Content = content.Trim();
            Duration = duration;
        }

        public override string ToString() =>
            $"{this.Duration} --> {this.Content}";
    }
}
