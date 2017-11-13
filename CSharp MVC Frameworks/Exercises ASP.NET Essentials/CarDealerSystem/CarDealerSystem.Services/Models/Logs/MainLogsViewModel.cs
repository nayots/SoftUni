using System.Collections.Generic;

namespace CarDealerSystem.Services.Models.Logs
{
    public class MainLogsViewModel
    {
        public string Search { get; set; }

        public int Page { get; set; }

        public IEnumerable<LogDetailsModel> Logs { get; set; } = new List<LogDetailsModel>();
    }
}