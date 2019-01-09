using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Core.DTO
{
    /// <summary>
    /// Represents a single word with number of occurences
    /// </summary>
    public struct Word
    {
        public String Name;
        public int Counter;
        public Word(String Name, int Counter)
        {
            this.Name = Name;
            this.Counter = Counter;
        }
    }
}
