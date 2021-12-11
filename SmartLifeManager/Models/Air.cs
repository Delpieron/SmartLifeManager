using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
