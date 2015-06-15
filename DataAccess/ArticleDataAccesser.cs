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
            List<Article> list=new List<Article>();
            string cmdText = "select top 10 title,site_name,url,media_type,polarity,publish_date,same_doc_count,address,content from original_news";
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnStr, CommandType.Text, cmdText);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                var article = new Article(){
                    title=Utility.GetColumnValue(dr,"title"),
                    site_name = Utility.GetColumnValue(dr, "site_name"),
                    url = Utility.GetColumnValue(dr, "url"),
                    media_type = Utility.GetColumnValue(dr, "media_type"),
                    polarity = Utility.GetColumnIntValue(dr, "polarity"),
                    publish_date = Utility.GetColumnDateTimeValue(dr, "publish_date"),
                    same_doc_count = Utility.GetColumnIntValue(dr, "same_doc_count"),
                    address = Utility.GetColumnValue(dr, "address"),
                    content = Utility.GetColumnValue(dr, "content")
                };
                list.Add(article);
            }

            return list;
        }
    }
}
