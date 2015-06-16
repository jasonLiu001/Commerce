using DataAccess.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataService
    {
        public List<Article> GetArticleList()
        {
            var sql = "select top 10 * from original_news";
            var list = Utility.GetListFromDB<Article>(new string[] { "title", "site_name", "url", "media_type", "polarity", "publish_date", "same_doc_count", "address", "content" }, sql);
            return list;
        }

        public List<HotWord> GetHotWordsList()
        {
            var sql = "select hotword from original_hotword";
            var list = Utility.GetListFromDB<HotWord>(new string[] { "hotword" }, sql);
            return list;
        }
    }
}
