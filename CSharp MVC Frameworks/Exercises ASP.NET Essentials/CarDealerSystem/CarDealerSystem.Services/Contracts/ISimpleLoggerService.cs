using CarDealerSystem.Data.Models;
using CarDealerSystem.Services.Models.Logs;
using System.Collections.Generic;

namespace CarDealerSystem.Services.Contracts
{
    public interface ISimpleLoggerService
    {
        void LogToDb(string username, LogType operation, string table);

        IEnumerable<LogDetailsModel> GetLogs(string username);

        void ClearLogs(string username);
    }
}