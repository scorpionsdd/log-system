using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Layer.Model.Model
{
    public class LogSystem
    {
        public int LogId { get; set; }
        public int UserId{ get; set; }
        public DateTime DateTimeEvent { get; set; }
        public string Module { get; set; }
        public string Action{ get; set; }
        public bool IsDB{ get; set; }
        public string Table { get; set; }
        public string Sentence{ get; set; }
        public string IP { get; set; }
        public string Metadata { get; set; }
        public string User { get; set; }

        public LogSystem() { }
        public LogSystem(int _UserId, string _Module, string _Action, string _Table, string _Sentence, string _IP, string _Metadata="")
        {
            UserId = _UserId;
            Module = _Module;
            Action = _Action;
            Table = _Table;
            Sentence = _Sentence;
            IsDB = !string.IsNullOrEmpty(Table);
            IP = _IP;
            Metadata = _Metadata;
        }
    }
}
