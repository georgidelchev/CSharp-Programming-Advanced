using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger
{
    public class LogFile : ILogFile
    {
        private const string FILE_PATH = "../../../log.txt";
        private readonly StringBuilder reports;

        public LogFile()
        {
            this.reports = new StringBuilder();
        }

        public int Size => this.Text
            .Where(char.IsLetter)
            .Sum(c => c);

        public string Text => this.reports.ToString();

        public void Write(string error)
        {
            File.AppendAllText(FILE_PATH, error);

            this.reports.Append(error);
        }
    }
}
