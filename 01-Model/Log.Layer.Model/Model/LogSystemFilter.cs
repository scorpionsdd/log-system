using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Layer.Model.Model
{
    /// <summary>
    /// Modelo para aplicar filtros a la consulta de bitacora
    /// </summary>
    public class LogSystemFilter
    {
        /// <summary>
        /// Usuario en especifico a considerar
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Modulo a filtrar
        /// </summary>
        public string Module { get; set; }
        /// <summary>
        /// Accion a filtrar
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Tabla a filtrar
        /// </summary>
        public string Table { get; set; }
        /// <summary>
        /// Fecha Desde para filtrar
        /// </summary>
        public DateTime? DateTimeEventFrom { get; set; }
        /// <summary>
        /// Fecha Hasta para filtrar
        /// </summary>
        public DateTime? DateTimeEventTo { get; set; }
        /// <summary>
        /// Modulos a filtrar
        /// </summary>
        public List<string> Modules { get; set; }
        /// <summary>
        /// Acciones a filtrar
        /// </summary>
        public List<string> Actions { get; set; }
    }
}
