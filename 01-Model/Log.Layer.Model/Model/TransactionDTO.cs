using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Layer.Model.Model
{
    public class TransactionDTO<T>
    {
        public bool isOk { get; set; }
        public string message { get; set; }
        public T result { get; set; }
    }
}
