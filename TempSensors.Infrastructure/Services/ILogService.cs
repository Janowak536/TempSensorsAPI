using TempSensors.Core.Models;

namespace TempSensors.Infrastructure.Services
{
    public interface ILogService
    {

        Task<List<Log>> GetAllLogs();
        Task<Log> GetLogById(int id);
        Task<Log> AddLog(Log log);
        Task<Log> RemoveLog(int id);
        Task<Log> PutLog(Log log);
        Task<List<Log>> GetBySensorId(int id);
    }
}
