using Problem1_Logger.Models.Appenders.Contracts;
using Problem1_Logger.Models.Appenders.Enums;
using Problem1_Logger.Models.Layouts.Contracts;
using System;

namespace Problem1_Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
        }

        public int MessageCount { get; private set; }

        public ReportLevel ReportLevel { get; set; } = ReportLevel.Info;

        public ILayout Layout { get; set; }

        public void AppendLine(string time, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.Layout.Format, time, reportLevel.ToString().ToUpper(), message));
                this.MessageCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessageCount}";
        }
    }
}