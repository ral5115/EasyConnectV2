using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace EasyTools.Framework.Data
{
    public class ResultList
    {
        private List<List<object>> values;

        private Dictionary<string, int> columns;

        private Dictionary<int, string> columnTypes;

        public ResultList()
        {
            values = new List<List<object>>();
            columns = new Dictionary<string, int>();
            columnTypes = new Dictionary<int, string>();
        }

        public ResultList(DbDataReader reader)
        {
            values = new List<List<object>>();
            columns = new Dictionary<string, int>();
            columnTypes = new Dictionary<int, string>();
            AddValues(reader, 0);
        }

        public ResultList(DbDataReader reader, int recordNumber)
        {
            values = new List<List<object>>();
            columns = new Dictionary<string, int>();
            columnTypes = new Dictionary<int, string>();
            AddValues(reader, recordNumber);
        }



        public void Clear()
        {
            if (values == null)
                values = new List<List<object>>();
            else
                values.Clear();
        }

        public void AddValues(DbDataReader reader, int recordNumber)
        {
            Clear();
            if (reader != null && !reader.IsClosed)
            {
                int j = 0;
                while (reader.Read())
                {
                    int totalColumns = reader.FieldCount;
                    List<object> value = new List<object>();
                    for (int i = 0; i < totalColumns; i++)
                    {
                        if (totalColumns != columns.Count)
                        {
                            columns.Add(reader.GetName(i), i);
                            columnTypes.Add(i, reader.GetFieldType(i).ToString());
                        }
                        if (!reader.IsDBNull(i))
                            value.Add(reader.GetValue(i));
                        else
                            value.Add(null);

                    }
                    values.Add(value);
                    j++;
                    if (recordNumber > 0 && j == recordNumber)
                        break;
                }
            }
            else
                throw new ApplicationException("Parametros Invalidos", new Exception("El datareader esta cerrado o es nulo"));
        }

        public List<String> GetColumns()
        {
            return columns.Keys.ToList<string>();
        }

        public List<List<object>> GetRows()
        {
            return values;
        }

        public int Count()
        {
            return values.Count;
        }

        public List<object> GetRow(int irow)
        {
            return values[irow];
        }

        public object GetValue(int iRow, int iCol)
        {
            return values[iRow][iCol];
        }

        public object GetValue(int iRow, string sCol)
        {
            return values[iRow][columns[sCol]];
        }

        public string GetStringValue(int iRow, int iCol)
        {
            return (values[iRow][iCol] == null ? "" : values[iRow][iCol].ToString());
        }

        public string GetStringValue(int iRow, string sCol)
        {
            return (values[iRow][columns[sCol]]) == null ? "" : values[iRow][columns[sCol]].ToString();
        }

        public int GetIntValue(int iRow, int iCol)
        {
            return (values[iRow][iCol] == null ? 0 : int.Parse(values[iRow][iCol].ToString()));
        }

        public int GetIntValue(int iRow, string sCol)
        {
            return (values[iRow][columns[sCol]]) == null ? 0 : int.Parse(values[iRow][columns[sCol]].ToString());
        }

        public Decimal GetDecimalValue(int iRow, int iCol)
        {
            return (values[iRow][iCol] == null ? 0 : Decimal.Parse(values[iRow][iCol].ToString()));
        }

        public Decimal? GetDecimalValue(int iRow, string sCol)
        {
            var data = values[iRow][columns[sCol]];
            if(data!=null)
                return Decimal.Parse(data.ToString());
            else
                return null;

            //return (values[iRow][columns[sCol]]) == null ? Decimal.Parse(values[iRow][columns[sCol]].ToString()) : null;
        }

        public DateTime GetDateTimeValue(int iRow, int iCol)
        {
            var data = (values[iRow][iCol]) ;
             if(data!=null)
                 return DateTime.Parse(data.ToString());
            else
                return DateTime.MinValue;
            //return (values[iRow][iCol] == null ? 0 : DateTime.Parse(values[iRow][iCol].ToString()));
        }

        public DateTime GetDateTimeValue(int iRow, string sCol)
        {
            return (values[iRow][columns[sCol]]) == null ? DateTime.MinValue : DateTime.Parse(values[iRow][columns[sCol]].ToString());
        }

        public bool GetBooleanValue(int iRow, int iCol)
        {
            return (values[iRow][iCol] == null || values[iRow][iCol].ToString() == "0" ? false : true);
        }

        public bool GetBooleanValue(int iRow, string sCol)
        {
            return (values[iRow][columns[sCol]]) == null ? false : true;
        }

        public string GetColumnType(int icol)
        {
            if (columnTypes.ContainsKey(icol))
                return columnTypes[icol];
            return null;
        }

        public string GetColumnName(int icol)
        {
            string sKey = "";
            foreach (var col in columns)
            {
                if (col.Value == icol)
                {
                    sKey = col.Key;
                    break;
                }
            }
            return sKey;
        }
    }
}