using Parser.Core.DTO;
using Parser.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Parser.Infrastructure.Services.WordSorter
{
    /// <summary>
    /// Produces a sorted word list with a primary sort of word lenght and a secondary ASCII sort.
    /// </summary>
    public class LengthASCIIWordSorter : IWordSorter
    {
        public IReadOnlyList<Word> Sort(IReadOnlyList<Word> Words)
        {
            List<Word> unSortedList = new List<Word>(Words);
            unSortedList.Sort(new LenghtAsciiComparer());
            return unSortedList;
        }

        class LenghtAsciiComparer : IComparer<Word>
        {
            public int Compare(Word x, Word y)
            {
                // 1. both null or empty then consider them as equal
                if (x.Name == null && y.Name == null)
                {
                    return 0;
                }

                // 2. check when one is null or empty
                if (x.Name == null && y.Name != null)
                {
                    return -1;
                }

                if (x.Name != null && y.Name == null)
                {
                    return 1;
                }


                // 3. check length
                if (x.Name.Length > y.Name.Length)
                {
                    return 1;
                }

                if (x.Name.Length < y.Name.Length)
                {
                    return -1;
                }

                // 4. when equal length apply a secondary ASCII comparison
                return String.CompareOrdinal(x.Name, y.Name);
            }
        }

    }
}
