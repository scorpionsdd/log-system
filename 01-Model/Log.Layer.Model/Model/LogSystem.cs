using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Layer.Model.Model
{
    public class LogSystem
    {
        /// <summary>
        /// BITACORAID
        /// </summary>
        public int LogId { get; set; }
        /// <summary>
        /// USUARIOID
        /// </summary>
        public int UserId{ get; set; }
        /// <summary>
        /// FECHAEVENTO
        /// </summary>
        public DateTime DateTimeEvent { get; set; }
        /// <summary>
        /// MODULO
        /// </summary>
        public string Module { get; set; }
        /// <summary>
        /// ACCION
        /// </summary>
        public string Action{ get; set; }
        /// <summary>
        /// ESBD
        /// </summary>
        public bool IsDB{ get; set; }
        /// <summary>
        /// TABLA
        /// </summary>
        public string Table { get; set; }
        /// <summary>
        /// SENTENCIA
        /// </summary>
        public string Sentence{ get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// METADATO
        /// </summary>
        public string Metadata { get; set; }
        /// <summary>
        /// SESIONID
        /// </summary>
        public string SessionId { get; set; }
        /// <summary>
        /// EXPEDIENTE
        /// </summary>
        public string Expedient { get; set; }
        /// <summary>
        /// CAMPO_1
        /// </summary>
        public string Field_1{ get; set; }
        /// <summary>
        /// CAMPO_2
        /// </summary>
        public string Field_2 { get; set; }
        public string User { get; set; }

        public LogSystem() { }
        public LogSystem(int _UserId, string _Module, string _Action, string _Table, string _Sentence, string _IP, string _SessionId, string _Expedient, string _Metadata="", string _Field_1="", string _Field_2="")
        {
            UserId = _UserId;
            Module = _Module;
            Action = _Action;
            Table = _Table;
            Sentence = _Sentence;
            IsDB = !string.IsNullOrEmpty(Table);
            IP = _IP;
            SessionId = _SessionId;
            Expedient=_Expedient;
            Metadata = _Metadata;
            Field_1 = _Field_1;
            Field_2= _Field_2;
        }
    }
}
