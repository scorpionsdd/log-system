using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Log.Layer.Model.Extension
{
    public static class Extension
    {
        public static List<T> DataReaderMapToList<T>(this IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
        public static DataTable ToDataTable(this IDataReader value) {
            DataTable dt = new DataTable();
            dt.Load(value);
            return dt;
        }
        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Obtener todas las propiedades de T
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Crear las columnas del DataTable
            foreach (PropertyInfo property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Crear las filas del DataTable
            foreach (T item in items)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    dataRow[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
        public static DataTable ToDataTable(this IList<object> items,bool isO)
        {
            if (items == null || !items.Any())
                throw new ArgumentException("La lista está vacía o es nula.");

            DataTable dataTable = new DataTable();

            // Obtener las propiedades del primer objeto
            var properties = items.First().GetType().GetProperties();

            // Crear las columnas del DataTable
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Crear las filas del DataTable
            foreach (var item in items)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (var property in properties)
                {
                    dataRow[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
        public static DataTable ToDataTable<T>(this IList<T> items, bool isO)
        {
            if (items == null || !items.Any())
                throw new ArgumentException("La lista está vacía o es nula.");

            DataTable dataTable = new DataTable();

            // Obtener las propiedades del primer objeto
            var properties = items.First().GetType().GetProperties();

            // Crear las columnas del DataTable
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Crear las filas del DataTable
            foreach (var item in items)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (var property in properties)
                {
                    dataRow[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
        public static List<Log.Layer.Model.Model.Item> GetEnumDescription(this Enum enumerator)
        {
            List<Log.Layer.Model.Model.Item> result = new List<Log.Layer.Model.Model.Item>();
            int i = 0;
            foreach (string text in Enum.GetNames(enumerator.GetType()))
            {
                Log.Layer.Model.Model.Item item = new Log.Layer.Model.Model.Item();
                i++;
                item.text = text;
                item.value = i.ToString();
                result.Add(item);
            }
            return result;
        }
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }
        public static string SerializeOracleParameters(this OracleParameter[] parameters)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OracleParameter[]));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, parameters);
                return writer.ToString();
            }
        }
        public static OracleParameter[] DeserializeOracleParameters(this string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OracleParameter[]));
            using (StringReader reader = new StringReader(xml))
            {
                return (OracleParameter[])serializer.Deserialize(reader);
            }
        }
    }
}
