using System;
using System.Collections.Generic;
using System.Text;

namespace SubtitlesConverter.Domain.Models
{
    interface ISubtitlesVisitor
    {
        void Visit(SubtitleLine line);
    }
}
