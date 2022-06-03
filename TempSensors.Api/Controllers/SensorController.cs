using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempSensors.Core.Models;
using TempSensors.Infrastructure.Data;
using TempSensors.Infrastructure.Services;

namespace TempSensors.Api.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _sensorService;
        private readonly ILogService _logService;

        public SensorController(ISensorService sensorService, ILogService logService)
        {
            _sensorService = sensorService;
            _logService = logService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sensor>>> SensorsList()
        {
           var result = await _sensorService.GetAllSensors();
           return Ok(result);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Sensor>> SensorId(int id)
        {
            var result = await _sensorService.GetSensorById(id);
            return Ok(result);
        }

        [HttpPost, Authorize(Roles = "Sensor")]
        public async Task<ActionResult<Sensor>> Sensor(Sensor sensor)
        {
            var result = await _sensorService.AddSensor(sensor);
            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Sensor>>> SensorPut(Sensor sensor)
        {
           await _sensorService.PutSensor(sensor);
           return Ok(sensor);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Sensor>>> Sensor(int id)
        {
            var result = await _sensorService.RemoveSensor(id);
            return Ok($"Sensor with id:{id} was deleted");
        }
    }
}
