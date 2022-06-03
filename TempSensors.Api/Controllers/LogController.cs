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
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Log>>> LogsList()
        {
            return Ok(await _logService.GetAllLogs());
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Log>> Log(int id)
        {
            var log = await _logService.GetLogById(id);

            return Ok(log);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Log>> LogBySensor(int id)
        {
            return Ok(await _logService.GetBySensorId(id));
        }


        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Log>>> Log(Log log)
        {
            await _logService.PutLog(log);

            return Ok(log);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Log>>> LogRemove(int id)
        {
            await _logService.RemoveLog(id);

            return Ok($"Log with id:{id} was deleted");
        }
    }
}
