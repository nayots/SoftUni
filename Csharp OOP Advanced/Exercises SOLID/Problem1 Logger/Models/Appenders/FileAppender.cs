using Problem1_Logger.Models.Appenders.Contracts;
using Problem1_Logger.Models.Appenders.Enums;
using Problem1_Logger.Models.Files;
using Problem1_Logger.Models.Files.Contracts;
using Problem1_Logger.Models.Layouts.Contracts;

namespace Problem1_Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
            this.File = new LogFile();
        }

        public FileAppender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.File = new LogFile();
        }

        public ILogFile File { get; set; }

        public int MessageCount { get; private set; }

        public ReportLevel ReportLevel { get; set; } = ReportLevel.Info;

        public ILayout Layout { get; set; }

        public void AppendLine(string time, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                this.File.Write(string.Format(this.Layout.Format, time, reportLevel.ToString().ToUpper(), message));
                this.MessageCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessageCount}, File size {this.File.Size}";
        }
    }
}