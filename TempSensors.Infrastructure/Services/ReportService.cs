using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempSensors.Core.Models;
using TempSensors.Infrastructure.Dtos;
using TempSensors.Infrastructure.Repositories;

namespace TempSensors.Infrastructure.Services
{
    public class ReportService : IReportService
    {

        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<AverageTemp> AllAverageTemp()
        {
            var list = _reportRepository.AverageTemperature();
            int sumOfTemp = 0;
            int numberOfSensors = list.Result.Count();
            foreach (var item in list.Result)
            {
                sumOfTemp += item.Temperature;
            }
            int averageTemp = sumOfTemp / numberOfSensors;
            AverageTemp collector = new AverageTemp { AverageTemperature = averageTemp, NumberOfSensors = numberOfSensors };
            return collector;
        }

        public async Task<SensorDto> AverageTempForOneSensor(int id)
        {
            int sum = 0;
            var list = await _reportRepository.AverageTempForSensor();
            List<Log> logs = new List<Log>();

            foreach (var item in list)
            {
                if (item.SensorId == id)
                {
                    logs.Add(item);
                }
            }
            int numberOfLogs = logs.Count();

            foreach (var item in logs)
            {
                sum += item.Temperature;
            }
            SensorDto sensor = new SensorDto { Id = id, Temperature = (sum / numberOfLogs) };
            return sensor;
        }
    }
}
