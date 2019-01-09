using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITextReader
    {
        IList<string> Read(string FilePath);
    }
}
