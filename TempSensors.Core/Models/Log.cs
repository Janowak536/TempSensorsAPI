namespace TempSensors.Core.Models
{
    public class Log
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        public int Temperature { get; set; }
        public string Information { get; set; } = string.Empty;
        public DateTime Data { get; set; }
    }
}
