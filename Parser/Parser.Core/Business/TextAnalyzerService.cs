using Parser.Core.DTO;
using Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Core.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class TextAnalyzerService
    {
        private readonly ITextReader textReader;
        private readonly ILogger logger;

        public TextAnalyzerService(ITextReader TextReader, ILogger Logger)
        {
            if (TextReader == null)
            {
                throw new ArgumentNullException("TextReader", "TextReader service cannot be null.");
            }

            if (Logger == null)
            {
                throw new ArgumentNullException("Logger", "Logger service cannot be null.");
            }

            this.textReader = TextReader;
            this.logger = Logger;
        }

        public IList<Word> Analyze(string FilePath)
        {
            IList<String> lines = textReader.Read(FilePath);
            IList<Word> wordList = new List<Word>();

            if (lines == null || lines.Count == 0)
            {
                logger.LogInfo("Empty input data is provided to TextAnalyzerService.");
                return wordList;
            }

            IDictionary<String, int> wordDictionary = new Dictionary<String, int>();
            foreach(String line in lines)
            {
                IList<String> words = CreateWords(line);
                foreach(String word in words)
                {
                    if (String.IsNullOrEmpty(word))
                    {
                        continue;
                    }

                    if (wordDictionary.ContainsKey(word))
                    {
                        wordDictionary[word]++;
                    }
                    else
                    {
                        wordDictionary.Add(word, 1);
                    }
                }

            }

            // convert dictionary to list of words          
            foreach (String key in wordDictionary.Keys)
            {
                Word word = new Word(key, wordDictionary[key]);
                wordList.Add(word);
            }

            return wordList;
        }

        private IList<String> CreateWords(String line)
        {
            IList<String> words = new List<String>();
            if (String.IsNullOrEmpty(line))
            {
                return words;
            }

            return line.Split(String.Empty);
        }
    }
}
