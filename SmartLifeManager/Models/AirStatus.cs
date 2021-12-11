using System.Collections.Generic;

namespace SmartLifeManager.Models
{
    public class AirStatus
    {
        public string Id;
        public string DateTime;
        public List<string> Status;

        public AirStatus(string id, string stCalcDate, List<string> stIndexLevel)
        {
            Id = id;
            DateTime = stCalcDate;
            Status = stIndexLevel;
        }
    }
}
