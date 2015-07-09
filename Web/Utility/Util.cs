using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Utility
{
    public class Util
    {
        public static DateTime ConvertToDateTime(string dateTimeString)
        {
            var dt = DateTime.MinValue;
            if (DateTime.TryParse(dateTimeString, out dt))
            {
                return dt;
            }

            return DateTime.MinValue;
        }
    }
}