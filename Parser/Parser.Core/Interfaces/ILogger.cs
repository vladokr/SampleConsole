using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Core.Interfaces
{
    public interface ILogger
    {
        void LogError(String ErrorMessage);
        void LogInfo(String InfoMessage);
    }
}
