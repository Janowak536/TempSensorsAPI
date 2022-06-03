using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempSensors.Core.Models;
using TempSensors.Infrastructure.Repositories;

namespace TempSensors.Infrastructure.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;

        }

        public Task<Log> GetLogById(int id)
        {
            var log = _logRepository.GetLogById(id);

            if (log == null)
            {
                throw new Exception($"log is null {id}");
            }

            return log;
        }

        public async Task<List<Log>> GetAllLogs()
        {
            return await _logRepository.GetAllLogs();
        }

        public async Task<Log> PutLog(Log log)
        {
            var dbLog = await _logRepository.GetLogById(log.Id);

            if (dbLog == null)
                throw new Exception($"Log with id:{log.Id} not found");

            dbLog.Id = log.Id;
            dbLog.SensorId = log.SensorId;
            dbLog.Temperature = log.Temperature;
            dbLog.Data = log.Data;
            dbLog.Information = log.Information;
            await _logRepository.Save();
            return dbLog;
        }


        public async Task<Log> RemoveLog(int id)
        {
            var log = await _logRepository.GetLogById(id);
            if (log == null)
            {
                throw new Exception($"Log with id:{id} not found");
            }
            await _logRepository.RemoveLog(id);
            await _logRepository.Save();
            return log;
        }

        public async Task<Log> AddLog(Log log)
        {
            await _logRepository.AddLog(log);
            await _logRepository.Save();
            return log;
        }


        public async Task<List<Log>> GetBySensorId(int id)
        {
            List<Log> logs = new List<Log>();

            foreach (var item in await _logRepository.GetAllLogs())
            {
                if (item.SensorId == id)
                {
                    logs.Add(item);
                }
            }
            if (logs.Count == 0)
            {
                throw new Exception($"Log with id:{id} not found");
            }
            return logs;
        }
    }
}
