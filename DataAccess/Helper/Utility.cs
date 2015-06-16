using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{
    public class Utility
    {
        #region parse value

        public static string GetColumnValue(DataRow row, string column)
        {
            var result = string.Empty;
            var curVal = row[column];
            if (curVal != null && curVal != DBNull.Value)
            {
                result = curVal.ToString();
            }
            return result;
        }

        public static int GetColumnIntValue(DataRow row, string column)
        {
            var result = 0;

            var tempVal = GetColumnValue(row, column);

            int.TryParse(tempVal, out result);

            return result;
        }

        public static decimal GetColumnDoubleValue(DataRow row, string column)
        {
            decimal result = 0;

            var tempVal = GetColumnValue(row, column);

            decimal.TryParse(tempVal, out result);

            return result;
        }

        public static decimal GetColumnDecimalValue(DataRow row, string column)
        {
            decimal result = 0;

            var tempVal = GetColumnValue(row, column);

            decimal.TryParse(tempVal, out result);

            return result;
        }

        public static DateTime GetColumnDateTimeValue(DataRow row, string column)
        {
            DateTime result = DateTime.MinValue;

            var tempVal = GetColumnValue(row, column);

            if (DateTime.TryParse(tempVal, out result))
            {
                //TODO: result = SPUtility.ConvertUtcToPst(result);
                result = ConvertUtcToPst(result);
            }

            return result;
        }

        [System.Obsolete("This is a temporary, Practical method in the SPUtility.cs file.", false)]
        public static DateTime ConvertUtcToPst(DateTime utc)
        {
            return utc.ToLocalTime();
        }

        #endregion

        #region DB Common Operation
        public static List<T> GetListFromDB<T>(string[] selectedColumns, string sql) where T : new()
        {
            List<T> list = new List<T>();           
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnStr, CommandType.Text, sql);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                var obj = new T();
                PropertyInfo[] fields = obj.GetType().GetProperties();
                foreach (string columnName in selectedColumns)
                {
                    foreach (var field in fields)
                    {
                        //如果是public属性并且是可写的
                        if (field.CanWrite)
                        {
                            //字段名和列名相同
                            if (field.Name.Equals(columnName, StringComparison.CurrentCultureIgnoreCase))
                            {
                                //判断字段类型
                                if (field.PropertyType == typeof(DateTime))
                                {
                                    field.SetValue(obj, Utility.GetColumnDateTimeValue(dr, columnName));
                                }
                                else if (field.PropertyType == typeof(string))
                                {
                                    field.SetValue(obj, Utility.GetColumnValue(dr, columnName));
                                }
                                else if (field.PropertyType == typeof(int))
                                {
                                    field.SetValue(obj, Utility.GetColumnIntValue(dr, columnName));
                                }
                                else if (field.PropertyType == typeof(decimal))
                                {
                                    field.SetValue(obj, Utility.GetColumnDecimalValue(dr, columnName));
                                }
                                else if (field.PropertyType == typeof(double))
                                {
                                    field.SetValue(obj, Utility.GetColumnDoubleValue(dr, columnName));
                                }
                                break;
                            }
                        }
                    }
                }

                list.Add(obj);
            }

            return list;
        }
        #endregion       
    }
}
