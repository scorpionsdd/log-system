using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Layer.Model.Model
{
    public class LogSystemFilter
    {
        public int UserId { get; set; }        
        public string Module { get; set; }
        public string Action { get; set; }        
        public string Table { get; set; }
        public DateTime? DateTimeEventFrom { get; set; }
        public DateTime? DateTimeEventTo { get; set; }
    }
}
