using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempSensors.Core.Models;

namespace TempSensors.Infrastructure.Repositories
{
    public interface IReportRepository
    {
        Task<List<Sensor>> AverageTemperature();
        Task<List<Log>> AverageTempForSensor();
    }
}
