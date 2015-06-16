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
            var sql = "select id,hotword from original_hotword";
            var list = Utility.GetListFromDB<HotWord>(new string[] { "id","hotword" }, sql);
            return list;
        }

        public List<Company> GetCompanyList()
        {
            var sql = "select id,company_name,company_name_short,company_boss from original_company";
            var list = Utility.GetListFromDB<Company>(new string[] { "id","company_name", "company_name_short", "company_boss" }, sql);
            return list;
        }
    }
}
