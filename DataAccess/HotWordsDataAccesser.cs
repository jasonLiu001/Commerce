using DataAccess.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HotWordsDataAccesser
    {
        public List<HotWord> GetHotWordsList()
        {
            var sql = "select hotword from original_hotword";
            var list = Utility.GetListFromDB<HotWord>(new string[] { "hotword" }, sql);
            return list;
        }
    }
}
