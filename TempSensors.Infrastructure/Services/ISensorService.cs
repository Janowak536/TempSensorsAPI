using TempSensors.Core.Models;

namespace TempSensors.Infrastructure.Services
{
    public interface ISensorService
    {
        Task<List<Sensor>> GetAllSensors();
        Task<Sensor> GetSensorById(int id);
        Task<Sensor> AddSensor(Sensor sensor);
        Task<Sensor> RemoveSensor(int id);
        Task<Sensor> PutSensor(Sensor sensor);
    }
}
