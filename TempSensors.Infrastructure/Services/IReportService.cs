using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempSensors.Core.Models;
using TempSensors.Infrastructure.Dtos;

namespace TempSensors.Infrastructure.Services
{
    public interface IReportService
    {
        Task<AverageTemp> AllAverageTemp();
        Task<SensorDto> AverageTempForOneSensor(int id);
    }
}
