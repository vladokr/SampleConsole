using Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Parser.Infrastructure.Services
{
    public class FileLogger : ILogger
    {
        private readonly String filePath;
        public FileLogger(String FilePath)
        {
            if (String.IsNullOrEmpty(FilePath))
            {
                throw new ArgumentNullException("FilePath", "FilePath cannot be null.");
            }

            this.filePath = FilePath;
        }

        public void LogError(string Error)
        {
            String logError = $"{DateTime.Now.ToString()} ERROR " + Error + System.Environment.NewLine;
            Write(logError);
        }

        public void LogInfo(string Message)
        {
            String logMessage = $"{DateTime.Now.ToString()} INFO " + Message + System.Environment.NewLine;
            Write(logMessage);
        }

        private void Write(String value)
        {
            File.AppendAllText(this.filePath, value);
        }
    }
}
