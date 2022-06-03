using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempSensors.Core.Models;
using TempSensors.Infrastructure.Repositories;

namespace TempSensors.Infrastructure.Services
{
    public class SensorService : ISensorService
    {
        private readonly ILogRepository _logRepository;
        private readonly ISensorRepository _sensorRepository;
        public SensorService(ISensorRepository sensorRepository,ILogRepository logRepository)
        {
            _sensorRepository = sensorRepository;
            _logRepository = logRepository;
        }
        public async Task<Sensor> AddSensor(Sensor sensor)
        {
            Log log = new Log
            {
                SensorId = sensor.Id,
                Temperature = sensor.Temperature,
                Data = DateTime.Now,
                Information = $"[INFO] {DateTime.Now} Method: [POST] -> [Completed]"
            };
            await _sensorRepository.AddSensor(sensor);
            await _sensorRepository.Save();
            await _logRepository.AddLog(log);
            await _logRepository.Save();
            return sensor;
        }

        public async Task<List<Sensor>> GetAllSensors()
        {
            Log log = new Log
            {
                SensorId = 000,
                Temperature = 000,
                Data = DateTime.Now,
                Information = $"[INFO] {DateTime.Now} Method: [GET] -> [Completed]"
            };
            await _logRepository.AddLog(log);
            await _logRepository.Save();
            return await _sensorRepository.GetAllSensors();
        }

        public Task<Sensor> GetSensorById(int id)
        {
            var sensor = _sensorRepository.GetSensorById(id);

            if (sensor == null)
            {
                Log log = new Log
                {
                    SensorId = 000,
                    Temperature = 000,
                    Data = DateTime.Now,
                    Information = $"[ERROR] {DateTime.Now} Method: [GET] -> [Sensor with id: {id} not found]"
                };
                _logRepository.AddLog(log);
                _logRepository.Save();
                throw new Exception($"sensor is null {id}");
            }
            else
            {
                Log log = new Log
                {
                    SensorId = id,
                    Temperature = sensor.Result.Temperature,
                    Data = DateTime.Now,
                    Information = $"[INFO] {DateTime.Now} Method: [PUT] -> [Completed]"

                };
                _logRepository.AddLog(log);
                _logRepository.Save();
            }

            return sensor;
        }

        public async Task<Sensor> PutSensor(Sensor sensor)
        {
            var dbSensor = await _sensorRepository.GetSensorById(sensor.Id);

            if (dbSensor == null)
            {
                Log log = new Log
                {
                    SensorId = 000,
                    Temperature = 000,
                    Data = DateTime.Now,
                    Information = $"[ERROR] {DateTime.Now} Method: [PUT] -> [Sensor with id: {sensor.Id} not found]"
                };
                await _logRepository.AddLog(log);
                await _logRepository.Save();
                throw new Exception($"sensor with id:{sensor.Id} not found");
            }
            else
            {
                dbSensor.Id = sensor.Id;
                dbSensor.Name = sensor.Name;
                dbSensor.Temperature = sensor.Temperature;

                Log log = new Log
                {
                    SensorId = sensor.Id,
                    Temperature = sensor.Temperature,
                    Data = DateTime.Now,
                    Information = $"[INFO] {DateTime.Now} Method: [PUT] -> [Completed]"
                };
                await _logRepository.AddLog(log);
                await _logRepository.Save();
                await _sensorRepository.Save();
            }
                
            return dbSensor;
        }

        public async Task<Sensor> RemoveSensor(int id)
        {
            var sensor = await _sensorRepository.GetSensorById(id);
            if (sensor == null)
            {
                Log log = new Log
                {
                    SensorId = 000,
                    Temperature = 000,
                    Data = DateTime.Now,
                    Information = $"[ERROR] {DateTime.Now} Method: [DELETE] -> [Sensor with id: {id} not found]"
                };
                await _logRepository.AddLog(log);
                await _logRepository.Save();
                throw new Exception($"Sensor with id:{id} not found");
            }
            else
            {
                Log log =new Log
                {
                    SensorId = id,
                    Temperature = 000,
                    Data = DateTime.Now,
                    Information = $"[INFO] {DateTime.Now} Method: [DELETE] -> [Completed]"
                };
                await _logRepository.AddLog(log);
                await _logRepository.Save();
                await _sensorRepository.RemoveSensor(id);
                await _sensorRepository.Save();
            }
            
            return sensor;
        }

    }
}
