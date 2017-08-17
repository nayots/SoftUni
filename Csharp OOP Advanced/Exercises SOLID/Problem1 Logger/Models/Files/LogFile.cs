using Problem1_Logger.Models.Files.Contracts;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem1_Logger.Models.Files
{
    public class LogFile : ILogFile
    {
        private StringBuilder sb;
        private const string TextFilePath = "log.txt";

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size
        {
            get
            {
                return this.sb.ToString().Where(c => char.IsLetter(c)).Sum(x => (int)x);
            }
        }

        public void Write(string message)
        {
            this.sb.AppendLine(message);
            File.AppendAllText(TextFilePath, message + Environment.NewLine);
        }
    }
}