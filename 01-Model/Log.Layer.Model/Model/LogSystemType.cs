using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Layer.Model.Model
{
    public class LogSystemType
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public List<string> Module { get; set; }
        public List<string> Action { get; set; }
    }
}
