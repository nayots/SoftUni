using CarDealerSystem.Data.Models;
using CarDealerSystem.Services.Models.Logs;

namespace CarDealerSystem.Services.Contracts
{
    public interface ISimpleLoggerService
    {
        void LogToDb(string username, LogType operation, string table);

        MainLogsViewModel GetLogs(string username);

        void ClearLogs(string username);
    }
}