using DataAccess;
using Model;
using Model.Business;
using Model.DataTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class BusinessService
    {
        DataService dataService = new DataService();

        public List<JsonDataTemplate<Article>> GetArticleList()
        {
            var list = new List<JsonDataTemplate<Article>>();
            var jsonData = new JsonDataTemplate<Article>();
            var articleList = dataService.GetArticleList();
            jsonData.name = "文章列表";
            jsonData.type = "root";
            jsonData.children = articleList;
            list.Add(jsonData);
            return list;
        }

        public List<JsonDataTemplate<Article>> GetArticleList(int pageIndex, int pageSize)
        {
            var list = new List<JsonDataTemplate<Article>>();
            var jsonData = new JsonDataTemplate<Article>();
            var articleList = dataService.GetArticleList(pageIndex,pageSize);
            jsonData.name = "文章列表";
            jsonData.type = "root";
            jsonData.children = articleList;
            list.Add(jsonData);
            return list;
        }

        public List<JsonDataTemplate<CommonDataEntity>> GetCompanyGroupByHotWords()
        {
            var list = new List<JsonDataTemplate<CommonDataEntity>>();
            var hotWordsList = dataService.GetHotWordsList();

            #region Get Common Data
            var companyList = dataService.GetCompanyList();
            var data = new List<CommonDataEntity>();
            foreach (var company in companyList)
            {
                var commonData = new CommonDataEntity();
                commonData.name = company.company_name;
                commonData.type = "company";
                data.Add(commonData);
            }
            #endregion

            foreach (var hotWord in hotWordsList)
            {
                var jsonData = new JsonDataTemplate<CommonDataEntity>();
                jsonData.name = hotWord.hotword;
                jsonData.type = "root";
                jsonData.children = data;
                list.Add(jsonData);
            }
            return list;
        }

        /// <summary>
        /// 文章来源分布:论坛、微博、微信等
        /// </summary>
        /// <returns></returns>
        public List<JsonDataTemplate<CategoryPercentage>> GetCategoryPercentageList()
        {
            var list = new List<JsonDataTemplate<CategoryPercentage>>();
            var jsonData = new JsonDataTemplate<CategoryPercentage>();
            var categoryPercentageList = dataService.GetCategoryPercentageList();
            jsonData.name = "文章来源分布";
            jsonData.type = "root";
            jsonData.children = categoryPercentageList;
            list.Add(jsonData);
            return list;
        }

        /// <summary>
        /// 情感占比
        /// </summary>
        /// <returns></returns>
        public List<JsonDataTemplate<EmotionPercentage>> GetEmotionPercentageList()
        {
            var list = new List<JsonDataTemplate<EmotionPercentage>>();
            var jsonData = new JsonDataTemplate<EmotionPercentage>();
            var emotionPercentageList = dataService.GetEmotionPercentageList();
            jsonData.name = "情感占比";
            jsonData.type = "root";
            jsonData.children = emotionPercentageList;
            list.Add(jsonData);
            return list;
        }

        /// <summary>
        /// 热词图
        /// </summary>
        /// <returns></returns>
        public List<JsonDataTemplate<HotWordPercentage>> GetHotWordPercentageList()
        {
            var list = new List<JsonDataTemplate<HotWordPercentage>>();
            var jsonData = new JsonDataTemplate<HotWordPercentage>();
            var hotWordPercentageList = dataService.GetHotWordPercentageList();
            jsonData.name = "热词图";
            jsonData.type = "root";
            jsonData.children = hotWordPercentageList;
            list.Add(jsonData);
            return list;
        }

        /// <summary>
        /// 来源网站排行
        /// </summary>
        /// <returns></returns>
        public List<JsonDataTemplate<SiteRank>> GetSiteRankList()
        {
            var list = new List<JsonDataTemplate<SiteRank>>();
            var jsonData = new JsonDataTemplate<SiteRank>();
            var siteRankList = dataService.GetSiteRankList();
            jsonData.name = "来源网站排名";
            jsonData.type = "root";
            jsonData.children = siteRankList;
            list.Add(jsonData);
            return list;
        }
    }
}
