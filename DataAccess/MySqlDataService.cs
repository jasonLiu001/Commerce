using DataAccess.Helper;
using Model.Business;
using Model.Business.Compass;
using Model.Original;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MySql
{
    public class MySqlDataService
    {
        public List<Article> GetArticleList(int pageIndex, int pageSize)
        {
            var sql = "select title,site_name,url,media_type,polarity,publish_date,same_doc_count,address,left(content,50) from original_news limit 10";
            var list = Utility.GetListFromMySql<Article>(new string[] { "title", "site_name", "url", "media_type", "polarity", "publish_date", "same_doc_count", "address", "content" }, sql);
            return list;
        }

        public List<HotWord> GetHotWordsList()
        {
            var sql = "select id,hotword from original_hotword limit 10";
            var list = Utility.GetListFromMySql<HotWord>(new string[] { "id", "hotword" }, sql);
            return list;
        }

        public List<HotWord> GetHotWordsList(DateTime date)
        {
            var sql = "select id,hotword from original_hotword limit 10";
            var list = Utility.GetListFromMySql<HotWord>(new string[] { "id", "hotword" }, sql);
            return list;
        }

        public List<Company> GetCompanyList()
        {
            var sql = "select id,company_name,company_name_short,company_boss from original_company limit 10";
            var list = Utility.GetListFromMySql<Company>(new string[] { "id", "company_name", "company_name_short", "company_boss" }, sql);
            return list;
        }

        public List<CategoryPercentage> GetCategoryPercentageList()
        {
            var sql = "select id,news,blog,forum,media,weibo,weixin,total_counts from b_category_percentage";
            var list = Utility.GetListFromMySql<CategoryPercentage>(new string[] { "id", "news", "blog", "forum", "media", "weibo", "weixin", "total_counts" }, sql);
            return list;
        }

        public List<EmotionPercentage> GetEmotionPercentageList()
        {
            var sql = "select id,positive,negative,normal,total_counts from b_emotion_percentage";
            var list = Utility.GetListFromMySql<EmotionPercentage>(new string[] { "id", "positive", "negative", "total_counts" }, sql);
            return list;
        }

        public List<HotWordPercentage> GetHotWordPercentageList(string keyWord = "hotword", string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select hotword,hotword_counts from b_hotword_percentage order by hotword_counts asc limit " + topCount;
            var list = Utility.GetListFromMySql<HotWordPercentage>(new string[] { "hotword", "hotword_counts" }, sql);
            return list;
        }

        public List<Article> GetLatestAtricles()
        {
            var sql = "select title,site_name,url,media_type,polarity,publish_date,same_doc_count,address,left(content,50) from original_news order by publish_date desc limit 10";
            var list = Utility.GetListFromMySql<Article>(new string[] { "title", "site_name", "url", "media_type", "polarity", "publish_date", "same_doc_count", "address", "content" }, sql);
            return list;
        }

        public List<Article> GetArticleCountRankList(string keyWord = "hotword", string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select title,site_name,url,media_type,polarity,publish_date,same_doc_count,address,left(content,50) from original_news where publish_date='" + publishDate + " 00:00:00' order by same_doc_count desc limit " + topCount;
            var list = Utility.GetListFromMySql<Article>(new string[] { "title", "site_name", "url", "media_type", "polarity", "publish_date", "same_doc_count", "address", "content" }, sql);
            return list;
        }

        public List<SiteRank> GetSiteRankList(string keyWord = "hotword", string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select site_name,news_counts from b_site_name_rank where publish_date='" + publishDate + " 00:00:00' order by news_counts desc limit " + topCount;
            var list = Utility.GetListFromMySql<SiteRank>(new string[] { "site_name", "news_counts" }, sql);
            return list;
        }

        public List<RegionDetail> GetAreasList()
        {
            var sql = " select area from original_region_detail where region_rank=2 limit 10";
            var list = Utility.GetListFromMySql<RegionDetail>(new string[] { "area" }, sql);
            return list;
        }

        #region CompassData

        public List<AreaRank> GetAreaRankList(string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select distinct city,frequency from b_area_rank where publish_date='" + publishDate + " 00:00:00' order by frequency desc limit " + topCount;
            var list = Utility.GetListFromMySql<AreaRank>(new string[] { "city", "frequency" }, sql);
            return list;
        }

        public List<PeopleRank> GetPeopleRankList(string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select distinct people,frequency from b_people_rank where publish_date='" + publishDate + " 00:00:00' order by frequency desc limit " + topCount;
            var list = Utility.GetListFromMySql<PeopleRank>(new string[] { "people", "frequency" }, sql);
            return list;
        }

        public List<CompanyRank> GetCompanyRankList(string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select distinct company_name,frequency from b_company_rank where publish_date='" + publishDate + " 00:00:00' order by frequency desc limit " + topCount;
            var list = Utility.GetListFromMySql<CompanyRank>(new string[] { "company_name", "frequency" }, sql);
            return list;
        }

        public List<HotwordRank> GetHotwordRankList(string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select distinct hotword,frequency from b_hotword_rank where publish_date='" + publishDate + " 00:00:00' order by frequency desc limit " + topCount;
            var list = Utility.GetListFromMySql<HotwordRank>(new string[] { "hotword", "frequency" }, sql);
            return list;
        }
        #endregion
    }
}
