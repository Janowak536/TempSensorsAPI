using Microsoft.EntityFrameworkCore;
using TempSensors.Core.Models;
using TempSensors.Infrastructure.Data;

namespace TempSensors.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly DataContext _context;

        public LogRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddLog(Log log)
        {
            _context.Logs.Add(log);
            await Task.CompletedTask;
        }

        public async Task<List<Log>> GetAllLogs()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<Log> GetLogById(int id)
        {
            return await _context.Logs.FindAsync(id);
        }

        public async Task RemoveLog(int id)
        {
            var dbLog = await GetLogById(id);

            _context.Logs.Remove(dbLog);

            await Task.CompletedTask;
        }

        async Task ILogRepository.Save()
        {
           await _context.SaveChangesAsync();
        }

    }
}
