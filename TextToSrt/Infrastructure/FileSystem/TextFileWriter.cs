﻿using SubtitlesConverter.Domain;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SubtitlesConverter.Infrastructure.FileSystem
{
    class TextFileWriter : ITextWriter
    {
        private FileInfo Destination { get; }

        public TextFileWriter(FileInfo destination)
        {
            Destination = destination;
            Truncate(destination);
        }

        private static void Truncate(FileInfo file)
        {
            using (File.Open(file.FullName, FileMode.Create)) { }
        }

        public void Write(IEnumerable<string> lines) =>
            File.WriteAllLines(Destination.FullName, lines, Encoding.UTF8);

        public void AppendLines(params string[] lines) =>
            File.AppendAllLines(Destination.FullName, lines);
    }
}
