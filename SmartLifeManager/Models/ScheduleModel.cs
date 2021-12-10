﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLifeManager.Models
{//wydarzenie, data, 
    class ScheduleModel
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Temperature{ get; set; }
        public string Pressure { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string Wet { get; set; }
        public string RainfallSum { get; set; }
    }
}