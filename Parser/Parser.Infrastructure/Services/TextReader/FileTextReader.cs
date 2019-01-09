using Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Parser.Infrastructure.Services.TextReader
{
    public class FileTextReader : ITextReader
    {
        public IList<string> Read(string FilePath)
        {
            return File.ReadAllLines(FilePath);
        }
    }
}
