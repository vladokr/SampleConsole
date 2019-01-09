using NUnit.Framework;
using Parser.Core.DTO;
using Parser.Infrastructure.Services.WordSorter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Infrastructure.Tests
{
    public class LengthASCIIWordSorterTests
    {

        [Test]
        public void Sort_ListWithNullItems_SortsByLenght()
        {
            LengthASCIIWordSorter stu = new LengthASCIIWordSorter();
            IList<Word> words = new List<Word>();
            words.Add(new Word(null, 1));
            words.Add(new Word("the", 1));
            words.Add(new Word("vlado", 1));
            words.Add(new Word("   ", 1));
            words.Add(new Word("  ", 2));
            words.Add(new Word(null, 2));

            IList<Word> sortedWords = stu.Sort(words);

            Assert.AreEqual(null, sortedWords[0].Name);
            Assert.AreEqual(null, sortedWords[1].Name);
            Assert.AreEqual("  ", sortedWords[2].Name);
            Assert.AreEqual("   ", sortedWords[3].Name);
            Assert.AreEqual("the", sortedWords[4].Name);
            Assert.AreEqual("vlado", sortedWords[5].Name);

        }

        [Test]
        public void Sort_ListWithDifferentNameLength_SortedByLength()
        {
            LengthASCIIWordSorter stu = new LengthASCIIWordSorter();
            IList<Word> words = new List<Word>();
            words.Add(new Word("quickedtest", 1));
            words.Add(new Word("the", 1));
            words.Add(new Word("vlado", 1));

            IList<Word> sortedWords = stu.Sort(words);

            Assert.AreEqual("the", sortedWords[0].Name);
            Assert.AreEqual("vlado", sortedWords[1].Name);
            Assert.AreEqual("quickedtest", sortedWords[2].Name);
        }

        [Test]
        public void Sort_ListWithSameAndDifferentNameLength_SortedByLenghtAndASCII()
        {
            LengthASCIIWordSorter stu = new LengthASCIIWordSorter();
            IList<Word> words = new List<Word>();
            words.Add(new Word("quick", 1));
            words.Add(new Word("back", 1));
            words.Add(new Word("the", 1));
            words.Add(new Word("brown", 1));
            words.Add(new Word("dog's", 1));
            words.Add(new Word("lazy", 1));
            words.Add(new Word("jumped", 1));
            words.Add(new Word("The", 1));
            words.Add(new Word("over", 1));
            words.Add(new Word("fox", 1));
            

            IList<Word> sortedWords = stu.Sort(words);

            Assert.AreEqual("The", sortedWords[0].Name);
            Assert.AreEqual("fox", sortedWords[1].Name);
            Assert.AreEqual("the", sortedWords[2].Name);
            Assert.AreEqual("back", sortedWords[3].Name);
            Assert.AreEqual("lazy", sortedWords[4].Name);
            Assert.AreEqual("over", sortedWords[5].Name);
            Assert.AreEqual("brown", sortedWords[6].Name);
            Assert.AreEqual("dog's", sortedWords[7].Name);
            Assert.AreEqual("quick", sortedWords[8].Name);
            Assert.AreEqual("jumped", sortedWords[9].Name);
        }
    }
}
