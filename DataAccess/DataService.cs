using DataAccess.Helper;
using Model;
using Model.Business;
using Model.Business.Compass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataService
    {
        public List<Article> GetArticleList(int pageIndex, int pageSize)
        {
            var sql = "select title,site_name,url,media_type,polarity,publish_date,same_doc_count,address,left([content],50) from (select ROW_NUMBER() over(order by publish_date desc) as rowId,*from original_news) temp where temp.rowId>" + (pageIndex * pageSize).ToString() + " and temp.rowId<" + ((pageIndex + 1) * pageSize).ToString();
            var list = Utility.GetListFromDB<Article>(new string[] { "title", "site_name", "url", "media_type", "polarity", "publish_date", "same_doc_count", "address", "[content]" }, sql);
            return list;
        }

        public List<HotWord> GetHotWordsList()
        {
            var sql = "select top 10 id,hotword from original_hotword";
            var list = Utility.GetListFromDB<HotWord>(new string[] { "id", "hotword" }, sql);
            return list;
        }

        public List<HotWord> GetHotWordsList(DateTime date)
        {
            var sql = "select top 10 id,hotword from original_hotword";
            var list = Utility.GetListFromDB<HotWord>(new string[] { "id", "hotword" }, sql);
            return list;
        }

        public List<Company> GetCompanyList()
        {
            var sql = "select top 10 id,company_name,company_name_short,company_boss from original_company";
            var list = Utility.GetListFromDB<Company>(new string[] { "id", "company_name", "company_name_short", "company_boss" }, sql);
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

        public List<HotWordPercentage> GetHotWordPercentageList(string keyWord = "hotword", string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select top " + topCount + " hotword,hotword_counts from b_hotword_percentage order by hotword_counts asc";
            var list = Utility.GetListFromDB<HotWordPercentage>(new string[] { "hotword", "hotword_counts" }, sql);
            return list;
        }

        public List<Article> GetArticleList(string keyWord = "hotword", string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select top " + topCount + " title,site_name,url,media_type,polarity,publish_date,same_doc_count,address,left([content],50) from original_news where datediff(dd,publish_date,'" + publishDate + "')=0 order by same_doc_count desc";
            var list = Utility.GetListFromDB<Article>(new string[] { "title", "site_name", "url", "media_type", "polarity", "publish_date", "same_doc_count", "address", "[content]" }, sql);
            return list;
        }

        public List<SiteRank> GetSiteRankList(string keyWord = "hotword", string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select top " + topCount + " site_name,news_counts from b_site_name_rank order by news_counts desc";
            var list = Utility.GetListFromDB<SiteRank>(new string[] { "site_name", "news_counts" }, sql);
            return list;
        }

        public List<RegionDetail> GetAreasList()
        {
            var sql = " select top 10 area from original_region_detail where region_rank=2";
            var list = Utility.GetListFromDB<RegionDetail>(new string[] { "area" }, sql);
            return list;
        }

        #region CompassData

        public List<AreaRank> GetAreaRankList(string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select distinct TOP " + topCount + " city,frequency from b_area_rank where datediff(dd,publish_date,'" + publishDate + "')=0 order by frequency desc";
            var list = Utility.GetListFromDB<AreaRank>(new string[] { "city", "frequency" }, sql);
            return list;
        }

        public List<PeopleRank> GetPeopleRankList(string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select distinct TOP " + topCount + " people,frequency from b_people_rank where datediff(dd,publish_date,'" + publishDate + "')=0 order by frequency desc";
            var list = Utility.GetListFromDB<PeopleRank>(new string[] { "people", "frequency" }, sql);
            return list;
        }

        public List<CompanyRank> GetCompanyRankList(string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select distinct TOP " + topCount + " company_name,frequency from b_company_rank where datediff(dd,publish_date,'" + publishDate + "')=0 order by frequency desc";
            var list = Utility.GetListFromDB<CompanyRank>(new string[] { "company_name", "frequency" }, sql);
            return list;
        }

        public List<HotwordRank> GetHotwordRankList(string topCount = "5", string publishDate = "2015-05-27")
        {
            var sql = "select distinct TOP " + topCount + " hotword,frequency from b_hotword_rank where datediff(dd,publish_date,'" + publishDate + "')=0 order by frequency desc";
            var list = Utility.GetListFromDB<HotwordRank>(new string[] { "hotword", "frequency" }, sql);
            return list;
        }
        #endregion
    }
}
