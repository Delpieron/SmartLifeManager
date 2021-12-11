using System.Collections.Generic;

namespace SmartLifeManager.Models
{
    public class Air
    {
        public string Key;
        public List<Dictionary<string, string>> Values;

        public Air(string key, List<Dictionary<string, string>> values)
        {
            Key = key;
            Values = values;
        }
    }
}
