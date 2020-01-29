using Parser.Core.DTO;
using System.Collections.Generic;

namespace Parser.Core.Interfaces
{
    public interface IWordSorter
    {
        IReadOnlyList<Word> Sort(IReadOnlyList<Word> words);
    }
}
