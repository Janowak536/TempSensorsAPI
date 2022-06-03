using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempSensors.Core.Models;
using TempSensors.Infrastructure.Data;

namespace TempSensors.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly DataContext _context;

        public ReportRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Sensor>> AverageTemperature()
        {
            return await _context.Sensors.ToListAsync();
        }

        public async Task<List<Log>> AverageTempForSensor()
        {
            return await _context.Logs.ToListAsync();
        }
    }
}
