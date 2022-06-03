using Microsoft.EntityFrameworkCore;
using TempSensors.Core.Models;
using TempSensors.Infrastructure.Data;

namespace TempSensors.Infrastructure.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly DataContext _context;

        public SensorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddSensor(Sensor sensor)
        {
            _context.Sensors.Add(sensor);

            await Task.CompletedTask;
        }

        public async Task<List<Sensor>> GetAllSensors()
        {
            return await _context.Sensors.ToListAsync();
        }

        public async Task<Sensor> GetSensorById(int id)
        {
            return await _context.Sensors.FindAsync(id);
        }

        public async Task RemoveSensor(int id)
        {
            var dbSensor = await GetSensorById(id);

            _context.Sensors.Remove(dbSensor);

            await Task.CompletedTask;
        }

        async Task ISensorRepository.Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
