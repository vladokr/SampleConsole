using Microsoft.Extensions.Configuration;
using Parser.Core.Business;
using Parser.Core.DTO;
using Parser.Core.Interfaces;
using Parser.Infrastructure.Services;
using Parser.Infrastructure.Services.TextReader;
using Parser.Infrastructure.Services.WordSorter;
using System;
using System.Collections.Generic;
using System.IO;

namespace Parser.ConsoleClient
{
    class Program
    {
        static String ReportOutputFilePath;
        static String LogFilePath;
        static String TextToAnalyzePath;
        static IConfiguration config;
        static ReportConfig reportConfig;
        static void Main(string[] args)
        {
            initializeConfiguration();

            try
            {
                // prepare dependencies (TODO: can be done with a DI container)
                ILogger logger = new FileLogger(LogFilePath);
                ITextReader textReader = new FileTextReader();
                IWordSorter wordSorter = new LengthASCIIWordSorter();

                // to output the report to console
                // IReportWriter reportWriter = new ConsoleReportWriter();

                IReportWriter reportWriter = new FileReportWriter(ReportOutputFilePath);

                TextAnalyzerService textAnalyzer = new TextAnalyzerService(textReader, logger);
                IList<Word> words = textAnalyzer.Analyze(TextToAnalyzePath);
              
                TextReportService reportService = new TextReportService(wordSorter, reportWriter, logger);
                reportService.ProduceReport(words, reportConfig);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            Console.WriteLine("Press any key to exit ...");
            Console.Read();
        }

        private static void initializeConfiguration()
        {
            Console.WriteLine($"Reading configuration in {Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")}");

            IConfiguration config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false)
              .Build();


            ReportOutputFilePath = config.GetValue<String>("ReportOutputFilePath");
            LogFilePath = config.GetValue<String>("LogFilePath");
            TextToAnalyzePath = config.GetValue<String>("TextToAnalyzePath");

            // configure the report
            reportConfig = new ReportConfig();
            config.GetSection("ReportConfig").Bind(reportConfig);

            // if not provided in appsetting.json set default values
            if (String.IsNullOrWhiteSpace(ReportOutputFilePath))
            {
                ReportOutputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "report.txt");
            }

            if (String.IsNullOrWhiteSpace(LogFilePath))
            {
                LogFilePath = Path.Combine(Directory.GetCurrentDirectory(), "log.txt");
            }

            if (String.IsNullOrWhiteSpace(TextToAnalyzePath))
            {
                TextToAnalyzePath = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
            }

            Console.WriteLine($"LogFilePath is {LogFilePath}");
            Console.WriteLine($"ReportOutputFilePath is {ReportOutputFilePath}");
            Console.WriteLine($"TextToAnalyzePath is {TextToAnalyzePath}");
        }
    }
}
