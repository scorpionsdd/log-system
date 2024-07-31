using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Layer.Model.Model
{
    public class ItemUpdate
    {
        public List<ItemComplex> data { get; set; }
    }
    public class ItemComplex {
        public Item before { get; set; }
        public Item after { get; set; }
    }
}
