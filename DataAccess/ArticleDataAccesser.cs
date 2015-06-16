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
    public class ArticleDataAccesser
    {
        public List<Article> GetArticleList()
        {
            var sql = "select top 10 * from original_news";
            var list = Utility.GetListFromDB<Article>(new string[] { "title", "site_name", "url", "media_type", "polarity", "publish_date", "same_doc_count", "address", "content" }, sql);
            return list;
        }
    }
}
