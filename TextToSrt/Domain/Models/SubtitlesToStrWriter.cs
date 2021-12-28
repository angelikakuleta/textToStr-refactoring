namespace SubtitlesConverter.Domain.Models
{
    public class SubtitlesToStrWriter : ISubtitlesVisitor
    {
        private ITextWriter Destination { get; }
        private int LastOrdinal { get; set; }

        public SubtitlesToStrWriter(ITextWriter destination)
        {
            Destination = destination;
            LastOrdinal = 0;
        }

        public void Visit(SubtitleLine line)
        {
            LastOrdinal += 1;
            Destination.AppendLines(
                $"{LastOrdinal}",
                $"{line.BeginOffset:hh\\:mm\\:ss\\,fff} --> {line.EndOffset:hh\\:mm\\:ss\\,fff}",
                $"{line.Content}",
                string.Empty);
        }
    }
}
