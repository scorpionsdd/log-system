using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Layer.Model.Model
{
    /// <summary>
    /// Clase para crear metadata de Update
    /// </summary>
    public class ItemUpdate
    {
        public List<ItemComplex> data { get; set; }
    }
    /// <summary>
    /// Clase para crear metadata de Update con antes y despues
    /// </summary>
    public class ItemComplex {
        public Item before { get; set; }
        public Item after { get; set; }
    }
}
