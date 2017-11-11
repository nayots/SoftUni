using System;

namespace CarDealerSystem.Data.Models
{
    public class LogEntry
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public LogType LogType { get; set; }

        public string Table { get; set; }

        public DateTime Time { get; set; }
    }

    public enum LogType
    {
        Add = 1,
        Edit = 2,
        Delete = 3
    }
}