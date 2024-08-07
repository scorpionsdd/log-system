using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Layer.Model.Model
{
    /// <summary>
    /// Clase para crear metadata de CRUD
    /// </summary>
    public class Item
    {
        public string label { get; set; }
        public string value{ get; set; }
        public string text { get; set; }
        public string sentence { get; set; }
        public bool? isOutput { get; set; }
    }
}
