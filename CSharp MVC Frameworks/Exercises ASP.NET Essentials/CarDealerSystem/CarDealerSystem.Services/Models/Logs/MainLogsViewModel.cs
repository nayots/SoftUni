using System.Collections.Generic;

namespace CarDealerSystem.Services.Models.Logs
{
    public class MainLogsViewModel
    {
        public IEnumerable<LogDetailsModel> Logs { get; set; } = new List<LogDetailsModel>();
    }
}