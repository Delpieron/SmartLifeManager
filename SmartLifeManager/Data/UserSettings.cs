using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLifeManager.Data
{
    public class UserSettings
    {
        public static string City { get; set; } = "Krakow";
        public static string TemperatureUnit { get; set; } = " °C";
        public static string Pressure { get; set; } = " hPa";
        public static string Speed { get; set; } = " m/s";
        public static string Content { get; set; } = " μg/m³";
        public static string CoContent { get; set; } = " mg/m³";
    }
}
