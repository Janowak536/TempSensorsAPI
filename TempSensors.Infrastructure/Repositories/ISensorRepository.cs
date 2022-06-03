using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempSensors.Core.Models;

namespace TempSensors.Infrastructure.Repositories
{
    public interface ISensorRepository
    {
        Task<List<Sensor>> GetAllSensors();
        Task<Sensor> GetSensorById(int id);
        Task AddSensor(Sensor sensor);
        Task RemoveSensor(int id);
        Task Save();
    }
}
