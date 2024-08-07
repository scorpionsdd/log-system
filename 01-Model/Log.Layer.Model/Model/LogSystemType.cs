using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Layer.Model.Model
{
    /// <summary>
    /// Modelo para la generacion de la bitacora
    /// </summary>
    public class LogSystemType
    {
        /// <summary>
        /// Tipo de bitacora
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Nombre de bitacora
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Modulos a considerar para generar la bitacora
        /// </summary>
        public List<string> Module { get; set; }
        /// <summary>
        /// Acciones a considerar para generar la bitacora
        /// </summary>
        public List<string> Action { get; set; }
        /// <summary>
        /// Nombre de Columnas en Español a elimninar si lo requiere la bitacora
        /// </summary>
        public List<string> ColumnRemove { get; set; }
        /// <summary>
        /// Nombre de Columnas (Campo 1 y/o Campo 2) en Español a mostrar si lo requiere la bitacora
        /// </summary>
        public List<string> ColumnAddtitional { get; set; }
        /// <summary>
        /// Nombre Nuevo de Columnas (Campo 1 y/o Campo 2) en Español a mostrar si lo requiere la bitacora
        /// </summary>
        public List<string> ColumnAddtitionalTitle { get; set; }
    }
}
