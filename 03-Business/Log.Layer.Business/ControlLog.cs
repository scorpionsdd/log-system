using Log.Layer.Model.Model;
using Log.Layer.Model.Model.Enumerator;
using Log.Layer.Model.Extension;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Log.Layer.Business
{
    public sealed class ControlLog
    {
        #region Singleton
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private ControlLog() { }

        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static ControlLog _instance;

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static ControlLog GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ControlLog();
            }
            return _instance;
        }
        #endregion
        /// <summary>
        /// Registra log para tener bitacora de afectacion a BD
        /// </summary>
        /// <param name="record">Modelo con la informacion a registrar en log</param>
        /// <returns>True en caso de haber realizado la operacion</returns>
        public TransactionDTO<bool> Create(LogSystem record) {
            Func<string, CommandType, string, int> ExecuteNonQuery = Log.Layer.Data.OracleHelper.ExecuteNonQuery;
            return this.Create(ExecuteNonQuery, record);
        }
        /// <summary>
        /// Registra log para tener bitacora de afectacion a BD
        /// </summary>
        /// <param name="ExecuteNonQuery">Funcion que se encargara de ejecutar operacion a BD</param>
        /// <param name="record">Modelo con la informacion a registrar en log</param>
        /// <returns>True en caso de haber realizado la operacion</returns>
        public TransactionDTO<bool> Create(Func<string, CommandType, string, int> ExecuteNonQuery, LogSystem record)
        {
            TransactionDTO<bool> result = new TransactionDTO<bool>();
            try
            {
                string sql = string.Empty;
                int count;
                sql = "DECLARE  v_text CLOB := '{8}'; BEGIN INSERT INTO CGESTION.BITACORA\r\n(USUARIOID, FECHAEVENTO, MODULO, ACCION, ESBD, TABLA, SENTENCIA, IP, METADATO, SESIONID, EXPEDIENTE)\r\n" +
                    "VALUES('{0}', TO_DATE('{1}', 'YYYY-MM-DD HH24:MI:SS'), '{2}', '{3}', '{4}', '{5}', '{6}','{7}',v_text,'{9}','{10}'); END;";
                record.DateTimeEvent = DateTime.Now;
                sql = string.Format(sql, record.UserId, record.DateTimeEvent.ToString("yyyy-MM-dd hh:mm:ss"), record.Module, record.Action, record.IsDB ? "1" : "0", record.Table, record.Sentence.Replace("'", "\""), record.IP, record.Metadata,record.SessionId,record.Expedient);
                count = ExecuteNonQuery(ConfigurationManager.AppSettings["ConnectionString"], CommandType.Text, sql);
                result.result = count > 0;
            }
            catch (Exception ex)
            {
                result.message = GetException(ex);
            }
            result.isOk = string.IsNullOrEmpty(result.message);
            return result;
        }
        /// <summary>
        /// Consulta log de bitacora
        /// </summary>
        /// <param name="filter">Modelo con la informacion de criterios de busqueda para aplicar en consulta de log</param>
        /// <returns>Informacion de log</returns>
        public TransactionDTO<DataTable> Get(LogSystemFilter filter) {
            Func<string, CommandType, string, System.Data.OracleClient.OracleParameter[], System.Data.OracleClient.OracleDataReader> ExecuteReader= Log.Layer.Data.OracleHelper.ExecuteReader;
            return this.Get(ExecuteReader,filter);
        }
        /// <summary>
        /// Consulta log de bitacora
        /// </summary>
        /// <param name="ExecuteReader">Funcion que se encargara de ejecutar operacion a BD</param>
        /// <param name="filter">Modelo con la informacion de criterios de busqueda para aplicar en consulta de log</param>
        /// <returns>Informacion de log</returns>
        public TransactionDTO<DataTable> Get(Func<string, CommandType, string, System.Data.OracleClient.OracleParameter[], System.Data.OracleClient.OracleDataReader> ExecuteReader, LogSystemFilter filter)
        {
            TransactionDTO<DataTable> result = new TransactionDTO<DataTable>();
            try
            {
                string sql = string.Empty;
                string where = string.Empty;
                List<string> criteria = new List<string>();
                List<string> criteriaDate = new List<string>();
                OracleDataReader reader;
                sql = "SELECT CAST(BITACORAID AS INTEGER) AS LOGID, CAST(0 AS INTEGER) as USERID ,T2.NOMBRE AS \"USER\", FECHAEVENTO AS DATETIMEEVENT,MODULO AS MODULE,ACCION AS \"ACTION\", CASE WHEN CAST(ESBD AS INTEGER)= 1 THEN 1 ELSE 0 END AS  ISDB, TABLA AS \"TABLE\",SENTENCIA AS SENTENCE,IP,METADATO AS METADATA,SESIONID, EXPEDIENTE " +
                    "FROM CGESTION.BITACORA T1 " +
                    "LEFT JOIN CGESTION.SOF_EMPLEADOS T2 ON CAST(TRUNC(T1.USUARIOID) AS INTEGER)=CAST(TRUNC(T2.ID_EMPLEADO) AS INTEGER) " +
                    "{0} ORDER BY BITACORAID DESC";

                if (filter.UserId > 0) criteria.Add(string.Format(" CAST(TRUNC(T1.USUARIOID) AS INTEGER)={0} ", filter.UserId));
                if (!string.IsNullOrEmpty(filter.Module)) criteria.Add(string.Format(" UPPER(MODULO) LIKE '%{0}%' ", filter.Module.ToUpper()));
                if (!string.IsNullOrEmpty(filter.Action)) criteria.Add(string.Format(" UPPER(ACCION)='{0}' ", filter.Action.ToUpper()));
                if (!string.IsNullOrEmpty(filter.Table)) criteria.Add(string.Format(" UPPER(TABLA) LIKE '%{0}%' ", filter.Table.ToUpper()));
                if (filter.DateTimeEventFrom.HasValue || filter.DateTimeEventTo.HasValue)
                {
                    if (filter.DateTimeEventFrom.HasValue) criteriaDate.Add(string.Format(" FECHAEVENTO >=TO_DATE('{0}', 'YYYY-MM-DD HH24:MI:SS') ", filter.DateTimeEventFrom.Value.ToString("yyyy-MM-dd hh:mm:ss")));
                    if (filter.DateTimeEventTo.HasValue) criteriaDate.Add(string.Format(" FECHAEVENTO <=TO_DATE('{0}', 'YYYY-MM-DD HH24:MI:SS') ", filter.DateTimeEventTo.Value.ToString("yyyy-MM-dd hh:mm:ss")));
                    criteria.Add(string.Format(" ({0}) ", string.Join("OR", criteriaDate)));
                }

                if (criteria.Any()) where = string.Format(" WHERE {0} ", string.Join("AND", criteria));

                sql = string.Format(sql, where);

                reader = ExecuteReader(ConfigurationManager.AppSettings["ConnectionString"], CommandType.Text, sql, null);

                if (reader != null)
                {
                    result.result = reader.ToDataTable();
                    result.message = sql;
                }
            }
            catch (Exception ex)
            {
                result.message = GetException(ex);
            }
            result.isOk = string.IsNullOrEmpty(result.message);
            return result;
        }
        /// <summary>
        /// Crea detalle de la transaccion a realizar, para mostrar al usuario formulario con afectaciones realizadas a BD
        /// </summary>
        /// <param name="field">Listado de campos a leer de consulta para crear formulario</param>
        /// <param name="sql">Procedimiento que proporcionara el registro a afectar, para traer valores a mostrar en formulario</param>
        /// <param name="enuAction">Accion a aplicar, determina el tipo de formulario a presentar (C=lista de campos con valores a insertar|R=Campo Descriptivo del registro consultado|U=lista de campos con valores actuales vs nuevos a actualizar|D=Campo Descriptivo del registro a eliminar)</param>
        /// <returns></returns>
        public TransactionDTO<string> GetMetadata(System.Data.OracleClient.OracleParameter[] parameter, System.Data.OracleClient.OracleParameter[] parameterLog, List<Item> field, string sql, enuActionTrack enuAction, DataSet ds = null) {
            Func<string, CommandType, string, System.Data.OracleClient.OracleParameter[], System.Data.OracleClient.OracleDataReader> ExecuteReader = Log.Layer.Data.OracleHelper.ExecuteReader;
            return this.GetMetadata(ExecuteReader,parameter, parameterLog, field, sql, enuAction, ds);
        }
        /// <summary>
        /// Crea detalle de la transaccion a realizar, para mostrar al usuario formulario con afectaciones realizadas a BD
        /// </summary>
        /// <param name="ExecuteReader">Funcion que se encargara de ejecutar operacion a BD</param>
        /// <param name="field">Listado de campos a leer de consulta para crear formulario</param>
        /// <param name="sql">Procedimiento que proporcionara el registro a afectar, para traer valores a mostrar en formulario</param>
        /// <param name="enuAction">Accion a aplicar, determina el tipo de formulario a presentar (C=lista de campos con valores a insertar|R=Campo Descriptivo del registro consultado|U=lista de campos con valores actuales vs nuevos a actualizar|D=Campo Descriptivo del registro a eliminar)</param>
        /// <returns></returns>
        public TransactionDTO<string> GetMetadata(Func<string, CommandType, string, System.Data.OracleClient.OracleParameter[], System.Data.OracleClient.OracleDataReader> ExecuteReader, System.Data.OracleClient.OracleParameter[] parameter, System.Data.OracleClient.OracleParameter[] parameterLog, List<Item> field, string sql, enuActionTrack enuAction, DataSet ds = null)
        {
            TransactionDTO<string> result = new TransactionDTO<string>();
            try
            {
                OracleDataReader reader;
                DataTable dt = new DataTable();
                ItemCreate itemCreate = new ItemCreate();
                ItemRetrieve itemRetrieve = new ItemRetrieve();
                ItemUpdate itemUpdate = new ItemUpdate();
                ItemDelete itemDelete = new ItemDelete();
                Func<string, string,string> fnGetText = (string sentence,string filter) => {
                    string text = string.Empty;
                    try
                    {
                        var rd = ExecuteReader(ConfigurationManager.AppSettings["ConnectionString"], CommandType.Text, string.Format(sentence, filter), null);
                        dt = rd.ToDataTable();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            text = dt.Rows[0][0].ToString();
                        }
                        if (string.IsNullOrEmpty(text)) text = filter;
                    }
                    catch (Exception)
                    {
                    }
                    return text;
                };
                if (enuAction != enuActionTrack.Create && enuAction != enuActionTrack.Delete)
                {
                    if (enuAction == enuActionTrack.Retrieve)
                    {
                        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        else
                        {
                            dt = new DataTable();
                        }
                    }
                    else
                    {
                        reader = ExecuteReader(ConfigurationManager.AppSettings["ConnectionString"], CommandType.StoredProcedure, sql, parameterLog);
                        if (reader != null)
                        {
                            dt = reader.ToDataTable();
                            if (dt != null && dt.Rows.Count > 0)
                            {
                            }
                            else
                            {
                                dt = new DataTable();
                            }
                        }
                    }
                }

                switch (enuAction)
                {
                    case enuActionTrack.Create:
                        itemCreate.data = new List<Item>();
                        parameter.ToList().ForEach(x => {
                            var item = field.FirstOrDefault(p => p.value == x.ParameterName);
                            var valueNew = x.Value;
                            if (!string.IsNullOrEmpty(item.sentence))
                            {                             
                                valueNew = fnGetText(item.sentence, valueNew.ToString());
                            }
                            itemCreate.data.Add(new Item { label = item.label, value = item.text, text = string.Format("{0}", valueNew) });
                        });
                        if (itemCreate.data.Any()) result.result = JsonConvert.SerializeObject(itemCreate);
                        break;
                    case enuActionTrack.Retrieve:
                        itemRetrieve.data = new List<Item>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            foreach (var item in field)
                            {
                                itemRetrieve.data.Add(new Item { value = item.text, text = string.Format("{0}", dr[item.value]) });
                            }
                        }
                        if (itemRetrieve.data.Any()) result.result = JsonConvert.SerializeObject(itemRetrieve);
                        break;
                    case enuActionTrack.Update:
                        itemUpdate.data = new List<ItemComplex>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            foreach (var item in field)
                            {
                                var x = parameter.FirstOrDefault(y => y.ParameterName == item.value);
                                var valueOld = dr[item.text];
                                var valueNew = x.Value;
                                if (valueOld!= valueNew)
                                {
                                    if (!string.IsNullOrEmpty(item.sentence))
                                    {
                                        valueOld = fnGetText(item.sentence, valueOld.ToString());
                                        valueNew = fnGetText(item.sentence, valueNew.ToString());
                                    }
                                    itemUpdate.data.Add(new ItemComplex
                                    {
                                        before = new Item { label = item.label, value = item.text, text = string.Format("{0}", valueOld) },
                                        after = new Item { value = x.ParameterName, text = string.Format("{0}", valueNew) }
                                    }); 
                                }
                            }
                        }
                        if (itemUpdate.data.Any()) result.result = JsonConvert.SerializeObject(itemUpdate);
                        break;
                    case enuActionTrack.Delete:
                        itemDelete.data = new List<Item>();
                        parameter.ToList().ForEach(x => {
                            var item = field.FirstOrDefault(p => p.value == x.ParameterName);
                            itemDelete.data.Add(new Item { value = item.text, text = string.Format("{0}", x.Value) });
                        });
                        if (itemDelete.data.Any()) result.result = JsonConvert.SerializeObject(itemDelete);
                        break;
                }

            }
            catch (Exception ex)
            {
                result.message = GetException(ex);
            }
            result.isOk = string.IsNullOrEmpty(result.message);
            return result;
        }
        /// <summary>
        /// Genera la salida html para representar el metadato del registro afectado
        /// </summary>
        /// <param name="item">Instancia de LogSystem, donde se requiere solo: Action, DateTimeEvent y Metadata</param>
        /// <returns>Contenido html para representar en interface</returns>
        public TransactionDTO<string> BuildMetadata(LogSystem item) {
            TransactionDTO<string> result=new TransactionDTO<string>();
            try
            {
                ItemCreate itemCreate = new ItemCreate();
                ItemRetrieve itemRetrieve = new ItemRetrieve();
                ItemUpdate itemUpdate = new ItemUpdate();
                ItemDelete itemDelete = new ItemDelete();
                string htmlRow = "<tr><td>{0}</td><td>{1}</td></tr>";
                string htmlRowUpdate = "<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>";
                string htmlBody = string.Empty;
                string htmlTable = "<table>{0}</table>";
                
                switch (item.Action)
                {
                    case "Crear Registro":
                        itemCreate = JsonConvert.DeserializeObject<ItemCreate>(item.Metadata);
                        itemCreate.data.ForEach(x => {
                            htmlBody += string.Format(htmlRow, x.label, string.Format("<span class='item-value-new'>{0}</span>", x.text));
                        });
                        break;
                    case "Consultar Registro":
                        itemRetrieve = JsonConvert.DeserializeObject<ItemRetrieve>(item.Metadata);
                        itemRetrieve.data.ForEach(x => {
                            htmlBody += string.Format(htmlRow, x.value, x.text);
                        });
                        break;
                    case "Actualizar Registro":
                        itemUpdate = JsonConvert.DeserializeObject<ItemUpdate>(item.Metadata);
                        itemUpdate.data.ForEach(x => {
                            htmlBody += string.Format(
                                htmlRowUpdate, 
                                x.before.label, 
                                string.Format("<span class='item-value-old'>{0}</span>", x.before.text),
                                string.Format("<span class='item-value-new'>{0}</span>", x.after.text));
                        });
                        break;
                    case "Eliminar Registro":
                        itemDelete = JsonConvert.DeserializeObject<ItemDelete>(item.Metadata);
                        itemDelete.data.ForEach(x => {
                            htmlBody += string.Format(htmlRow, x.value, x.text);
                        });
                        break;
                }

                result.result= string.Format(htmlTable, htmlBody);
            }
            catch (Exception ex)
            {
                result.message = GetException(ex);
            }
            result.isOk = string.IsNullOrEmpty(result.message);
            return result;
        }
        /// <summary>
        /// Obtiene excepcion completa
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string GetException(Exception ex)
        {
            string result = ex.Message;
            if (ex.InnerException != null)
            {
                result = string.Format("{0} {1} {2}", result, Environment.NewLine, GetException(ex.InnerException));
            }
            return result;
        }

    }
}
