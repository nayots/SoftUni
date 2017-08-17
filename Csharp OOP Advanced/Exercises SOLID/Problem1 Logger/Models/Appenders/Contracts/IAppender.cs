using Problem1_Logger.Models.Appenders.Enums;
using Problem1_Logger.Models.Layouts.Contracts;

namespace Problem1_Logger.Models.Appenders.Contracts
{
    public interface IAppender
    {
        int MessageCount { get; }

        ReportLevel ReportLevel { get; set; }

        void AppendLine(string time, ReportLevel reportLevel, string message);

        ILayout Layout { get; set; }
    }
}