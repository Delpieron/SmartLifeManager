using System;

namespace SmartLifeManager.Models
{//wydarzenie, data, 
    internal class ScheduleModel
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Temperature { get; set; }
        public string Pressure { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string Wet { get; set; }
        public string RainfallSum { get; set; }
    }
}
