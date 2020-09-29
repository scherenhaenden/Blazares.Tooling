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
        /// This Method will concert the Datatable data into a JSON String.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns>Json String. Exceptions will not be caught in this method</returns>
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
    }
}