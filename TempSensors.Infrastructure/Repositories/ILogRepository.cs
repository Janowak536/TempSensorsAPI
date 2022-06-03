using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempSensors.Core.Models;

namespace TempSensors.Infrastructure.Repositories
{
    public interface ILogRepository
    {
        Task<List<Log>> GetAllLogs();
        Task<Log> GetLogById(int id);
        Task AddLog(Log log);
        Task RemoveLog(int id);
        Task Save();
    }
}
