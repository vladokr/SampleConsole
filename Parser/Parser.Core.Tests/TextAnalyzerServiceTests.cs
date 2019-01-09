using NSubstitute;
using NUnit.Framework;
using Parser.Core.Business;
using Parser.Core.DTO;
using Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Core.Tests
{
    public class TextAnalyzerServiceTests
    {
        [Test]
        public void Constructor_WhenNullReaderOrLoggerInInput_ArgumentExceptionThrown()
        {
            try
            {
                TextAnalyzerService stu = new TextAnalyzerService(null, null);
            }
            catch(ArgumentNullException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Analyze_WhenNullFilePathProvided_EmptyListOfWords()
        {          
            var textReader = Substitute.For<ITextReader>();
            textReader.Read(null).ReturnsForAnyArgs(x => new List<String>());
            var logger = Substitute.For<ILogger>();
            TextAnalyzerService stu = new TextAnalyzerService(textReader, logger);
            
            IList<Word> words = stu.Analyze(null);

            Assert.AreEqual(0, words.Count);
            logger.Received(1).LogInfo(Arg.Any<String>());
        }

        [Test]
        public void Analyze_ForListOfLinesWithEmptyLines_ListOfWordsReturned()
        {
            String someFilePath = "testPath";
            IList<String> lines = new List<String>();
            lines.Add("The quick brown quick");
            lines.Add("                      ");
            lines.Add("over dog's quick brown dog's");
            var textReader = Substitute.For<ITextReader>();
            textReader.Read(null).ReturnsForAnyArgs(x => lines);
            var logger = Substitute.For<ILogger>();
            TextAnalyzerService stu = new TextAnalyzerService(textReader, logger);

            IList<Word> words = stu.Analyze(someFilePath);

            Assert.AreEqual(5, words.Count);
            Assert.AreEqual("The", words[0].Name);
            Assert.AreEqual(1, words[0].Counter);

            Assert.AreEqual("quick", words[1].Name);
            Assert.AreEqual(3, words[1].Counter);

            Assert.AreEqual("brown", words[2].Name);
            Assert.AreEqual(2, words[2].Counter);

            Assert.AreEqual("over", words[3].Name);
            Assert.AreEqual(1, words[3].Counter);

            Assert.AreEqual("dog's", words[4].Name);
            Assert.AreEqual(2, words[4].Counter);
        }


    }
}
