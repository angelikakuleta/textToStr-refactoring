using SubtitlesConverter.Domain.Models;

namespace SubtitlesConverter.Domain
{
    interface ITextReader
    {
        TimedText Read();
    }
}