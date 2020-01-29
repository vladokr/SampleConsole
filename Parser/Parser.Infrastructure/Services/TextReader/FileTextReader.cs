using Parser.Core.Interfaces;
using System.Collections.Generic;
using System.IO;
namespace Parser.Infrastructure.Services.TextReader
{
    public class FileTextReader : ITextReader
    {
        public IReadOnlyList<string> Read(string FilePath)
        {
            return File.ReadAllLines(FilePath);
        }
    }
}
