using Microsoft.EntityFrameworkCore;
using TempSensors.Core.Models;

namespace TempSensors.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
