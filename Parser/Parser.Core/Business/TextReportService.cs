using Parser.Core.DTO;
using Parser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Core.Business
{
    public class TextReportService
    {
        private readonly IWordSorter wordSorter;
        private readonly IReportWriter reportWriter;
        private readonly ILogger logger;

        public TextReportService(IWordSorter WordSorter, IReportWriter ReportWriter, ILogger Logger)
        {
            if (WordSorter == null)
            {
                throw new ArgumentNullException("WordSorter", "WordSorter service cannot be null.");
            }

            if (ReportWriter == null)
            {
                throw new ArgumentNullException("ReportWriter", "ReportWriter service cannot be null.");
            }

            if (Logger == null)
            {
                throw new ArgumentNullException("Logger", "Logger service cannot be null.");
            }

            this.wordSorter = WordSorter;
            this.reportWriter = ReportWriter;
            this.logger = Logger;
        }

        public void ProduceReport(IList<Word> Words, ReportConfig Config)
        {
            if (Words == null || Words.Count == 0)
            {
                logger.LogInfo("Empty list of words provided in input. No report is generated.");
                return;
            }

            logger.LogInfo($"Start creating report for {Words.Count} words.");

            // sort the words
            IList<Word> sortedWords = wordSorter.Sort(Words);

            // create the report
            StringBuilder sbReport = new StringBuilder();
            reportWriter.Write(Config.ReportTitle);
            foreach (Word word in sortedWords)
            {
                sbReport.AppendLine(word.Counter + Config.Separator + word.Name);
            }

            // store
            reportWriter.Write(sbReport.ToString());

            logger.LogInfo("Finished creating report");
        }
    }
}
