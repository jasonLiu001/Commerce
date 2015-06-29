using DataAccess.Helper;
using Model;
using Model.Business;
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
            var sql = "select top 10 title,site_name,url,media_type,polarity,publish_date,same_doc_count,address,left([content],50) from original_news";
            var list = Utility.GetListFromDB<Article>(new string[] { "title", "site_name", "url", "media_type", "polarity", "publish_date", "same_doc_count", "address", "[content]" }, sql);
            return list;
        }

        public List<Article> GetArticleList(int pageIndex, int pageSize)
        {
            var sql = "select title,site_name,url,media_type,polarity,publish_date,same_doc_count,address,left([content],50) from (select ROW_NUMBER() over(order by publish_date desc) as rowId,*from original_news) temp where temp.rowId>"+(pageIndex*pageSize).ToString()+" and temp.rowId<"+((pageIndex+1)*pageSize).ToString();
            var list = Utility.GetListFromDB<Article>(new string[] { "title", "site_name", "url", "media_type", "polarity", "publish_date", "same_doc_count", "address", "[content]" }, sql);
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

        public List<CategoryPercentage> GetCategoryPercentageList()
        {
            var sql = "select id,news,blog,forum,media,weibo,weixin,total_counts from b_category_percentage";
            var list = Utility.GetListFromDB<CategoryPercentage>(new string[] { "id", "news", "blog", "forum", "media", "weibo", "weixin", "total_counts" }, sql);
            return list;
        }

        public List<EmotionPercentage> GetEmotionPercentageList()
        {
            var sql = "select id,positive,negative,normal,total_counts from b_emotion_percentage";
            var list = Utility.GetListFromDB<EmotionPercentage>(new string[] { "id", "positive", "negative", "total_counts" }, sql);
            return list;
        }

        public List<HotWordPercentage> GetHotWordPercentageList()
        {
            var sql = "select hotword,hotword_counts from b_hotword_percentage";
            var list = Utility.GetListFromDB<HotWordPercentage>(new string[] { "hotword", "hotword_counts"}, sql);
            return list;
        }

        public List<SiteRank> GetSiteRankList()
        {
            var sql = "select site_name,news_counts from b_site_name_rank";
            var list = Utility.GetListFromDB<SiteRank>(new string[] { "site_name", "news_counts" }, sql);
            return list;
        }
    }
}
