using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempSensors.Core.Models;
using TempSensors.Infrastructure.Data;
using TempSensors.Infrastructure.Dtos;
using TempSensors.Infrastructure.Repositories;
using TempSensors.Infrastructure.Services;

namespace TempSensors.Api.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<AverageTemp>> AverageList()
        {
            var result =await _reportService.AllAverageTemp();
            return Ok(result);
        }

        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<SensorDto>> AverageHistory(int id)
        {
            var result = await _reportService.AverageTempForOneSensor(id);
            return Ok(result);
        }
    }
}
