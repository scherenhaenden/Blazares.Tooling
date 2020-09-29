using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Blazares.Tooling.DataTableExtensions
{
    public static class ConvertToJson
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns>json string or exception</returns>
        public static string ToJson(this DataTable dataTable)
        {
            var JSONString = new StringBuilder();
            if (dataTable.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (j < dataTable.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + dataTable.Columns[j].ColumnName + "\":" + "\"" + dataTable.Rows[i][j] + "\",");
                        }
                        else if (j == dataTable.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + dataTable.Columns[j].ColumnName + "\":" + "\"" + dataTable.Rows[i][j] + "\"");
                        }
                    }
                    if (i == dataTable.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns>json string or exception</returns>
        public static string ToJsonV2(this DataTable dataTable)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in dataTable.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in dataTable.Columns)
                {
                    dict[col.ColumnName] = (Convert.ToString(row[col]));
                }
                list.Add(dict);
            }
            
            string i = JsonConvert.SerializeObject(list, Formatting.Indented
                , new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.All
                    ,ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

            return i;
        }
        
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns>json string or exception</returns>
        public static string ToJsonV3(this DataTable dataTable)
        {
            try
            {
                string result;
                using (StringWriter sw = new StringWriter())
                {
                    dataTable.WriteXml(sw);
                    result = sw.ToString();
                }

                string i = JsonConvert.SerializeObject(result, Formatting.Indented
                /*, new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.All
                        ,ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }*/);
                return i;
            }

            catch (Exception any)
            {
              
            }

            return "";
        }
    }
}