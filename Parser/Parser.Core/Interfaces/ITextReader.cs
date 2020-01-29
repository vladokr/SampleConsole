using System.Collections.Generic;

namespace Parser.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITextReader
    {
        IReadOnlyList<string> Read(string FilePath);
    }
}
