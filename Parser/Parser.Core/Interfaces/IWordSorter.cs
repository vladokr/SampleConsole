using Parser.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Core.Interfaces
{
    public interface IWordSorter
    {
        IList<Word> Sort(IList<Word> Words);
    }
}
