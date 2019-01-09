using Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Parser.Infrastructure.Services
{
    public class FileReportWriter : IReportWriter
    {
        private readonly String filePath;

        public FileReportWriter(String FilePath)
        {
            if (String.IsNullOrEmpty(FilePath))
            {
                throw new ArgumentNullException("FilePath", "FilePath cannot be null.");
            }

            this.filePath = FilePath;
        }

        public void Write(string Content)
        {
            File.AppendAllText(this.filePath, Content + System.Environment.NewLine);
        }
    }
}
