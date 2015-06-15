using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    }
}
