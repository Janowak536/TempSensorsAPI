namespace TempSensors.Core.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Temperature { get; set; }
    }
}
