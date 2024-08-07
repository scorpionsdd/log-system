using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Layer.Model.Model.Enumerator
{
    /// <summary>
    /// Enumerador de acciones a generar bitacora (Se modifica acorde a sistema donde se implementa)
    /// </summary>
    public enum enuAction
    {        
        [Description("Acceso a Sistema")]Access=1,
        [Description("Acceso a Sistema Fallido")] AccessDenied = 2,
        [Description("Navegacion Pantalla")]Navegation= 3,
        [Description("Crear Registro")]Create=4,
        [Description("Consultar Registro")]Retrieve=5,
        [Description("Actualizar Registro")]Update=6,
        [Description("Eliminar Registro")] Delete =7,
        [Description("Inactivar Registro")] Inactive = 8,
        [Description("Subir Archivo")] Upload= 9,
        [Description("Descargar Archivo")] Download= 10,
        [Description("No Existe Usuario")] UserNotExist = 11,
    }
    /// <summary>
    /// Enumerador para acciones de CRUD (Es fijo)
    /// </summary>
    public enum enuActionTrack {
        [Description("Crear Registro")] Create = 1,
        [Description("Consultar Registro")] Retrieve = 2,
        [Description("Actualizar Registro")] Update = 3,
        [Description("Eliminar Registro")] Delete = 4,
    }
}
