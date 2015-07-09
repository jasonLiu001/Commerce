using DataAccess;
using Model;
using Model.Business;
using Model.Constant;
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

        private string GetCommonDataType(string keyWord)
        {
            switch (keyWord)
            {
                case SourceDataType.HotWord:
                    return "hotword";
                case SourceDataType.Area:
                    return "area";
                case SourceDataType.Company:
                    return "company";
                case SourceDataType.People:
                    return "people";
                default:
                    return "hotword";
            }
        }

        public List<JsonDataTemplate<Article>> GetArticleList(int pageIndex, int pageSize)
        {
            var list = new List<JsonDataTemplate<Article>>();
            var jsonData = new JsonDataTemplate<Article>();
            var articleList = dataService.GetArticleList(pageIndex, pageSize);
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
        /// 获取最新文章
        /// </summary>
        /// <returns></returns>
        public List<Article> GetLatestAtricles()
        {           
            var latestArticleList = dataService.GetLatestAtricles();
            return latestArticleList;
        }

        /// <summary>
        /// 热词图
        /// </summary>
        /// <returns></returns>
        public List<int> GetHotWordPercentageList(string keyWord, DateTime queryDate, string topCount)
        {
            var list = new List<JsonDataTemplate<HotWordPercentage>>();
            var jsonData = new JsonDataTemplate<HotWordPercentage>();
            var hotWordPercentageList = dataService.GetHotWordPercentageList(keyWord, topCount, queryDate.ToString("yyyy-MM-dd"));

            List<int> changeTrend = new List<int>();
            foreach (var hotWord in hotWordPercentageList)
            {
                changeTrend.Add(hotWord.hotword_counts);
            }

            return changeTrend;
        }

        public List<Article> GetArticleRankList(string keyWord, DateTime queryDate, string topCount)
        {                   
            var articleList = dataService.GetArticleCountRankList(keyWord, topCount, queryDate.ToString("yyyy-MM-dd"));
            return articleList;
        }

        /// <summary>
        /// 来源网站排行
        /// </summary>
        /// <returns></returns>
        public SiteRankJsonData GetSiteRankList(string keyWord, DateTime queryDate, string topCount)
        {
            var jsonData = new SiteRankJsonData();
            jsonData.cities = new List<string>();
            jsonData.data = new List<int>();
            var siteRankList = dataService.GetSiteRankList(keyWord, topCount, queryDate.ToString("yyyy-MM-dd"));

            foreach (var siteRank in siteRankList)
            {
                jsonData.cities.Add(siteRank.site_name);
                jsonData.data.Add(siteRank.news_counts);
            }
            return jsonData;
        }

        /// <summary>
        /// 获取根据罗盘指示的类型获取数据
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public List<JsonDataTemplate<CommonDataEntity<CommonDataEntity>>> GetCompassDataList(string keyWord, DateTime queryDate, string topCount)
        {
            var list = new List<JsonDataTemplate<CommonDataEntity<CommonDataEntity>>>();
            var publishDate = queryDate.ToString("yyyy-MM-dd");
            //关键词
            var hotWordData = new List<CommonDataEntity<CommonDataEntity>>();
            //公司
            var companyData = new List<CommonDataEntity<CommonDataEntity>>();
            //人物
            var peopleData = new List<CommonDataEntity<CommonDataEntity>>();
            //地区
            var areaData = new List<CommonDataEntity<CommonDataEntity>>();

            //构建"children": [{ "name": "", "type": "child" }] }
            var commonDataEntity = new CommonDataEntity();
            commonDataEntity.name = "";
            commonDataEntity.type = "child";
            var childrenList = new List<CommonDataEntity>();
            childrenList.Add(commonDataEntity);

            var hotWordsList = dataService.GetHotwordRankList(topCount, publishDate);
            var companyList = dataService.GetCompanyRankList(topCount, publishDate);
            var areaList = dataService.GetAreaRankList(topCount, publishDate);
            var personList = dataService.GetPeopleRankList(topCount, publishDate);

            #region Fill company data.
            foreach (var company in companyList)
            {
                var commonData = new CommonDataEntity<CommonDataEntity>();
                commonData.name = company.company_name;
                commonData.type = "company";
                commonData.children = childrenList;
                hotWordData.Add(commonData);
                //companyData.Add(commonData);
                peopleData.Add(commonData);
                areaData.Add(commonData);
            }
            #endregion

            #region Fill area data.
            foreach (var area in areaList)
            {
                var commonData = new CommonDataEntity<CommonDataEntity>();
                commonData.name = area.city;
                commonData.type = "area";
                commonData.children = childrenList;
                hotWordData.Add(commonData);
                companyData.Add(commonData);
                peopleData.Add(commonData);
                //areaData.Add(commonData);
            }
            #endregion

            #region Fill person data.
            foreach (var person in personList)
            {
                var commonData = new CommonDataEntity<CommonDataEntity>();
                commonData.name = person.people;
                commonData.type = "people";
                commonData.children = childrenList;
                hotWordData.Add(commonData);
                companyData.Add(commonData);
                //peopleData.Add(commonData);
                areaData.Add(commonData);
            }
            #endregion

            #region Fill hotword data
            foreach (var hotword in hotWordsList)
            {
                var commonData = new CommonDataEntity<CommonDataEntity>();
                commonData.name = hotword.hotword;
                //改变type类型
                commonData.type = GetCommonDataType(keyWord);
                commonData.children = childrenList;
                //hotWordData.Add(commonData);
                companyData.Add(commonData);
                areaData.Add(commonData);
                peopleData.Add(commonData);
            }
            #endregion

            switch (keyWord)
            {
                case SourceDataType.HotWord:
                    {
                        #region Final Data by hotWords
                        foreach (var hotWord in hotWordsList)
                        {
                            var jsonData = new JsonDataTemplate<CommonDataEntity<CommonDataEntity>>();
                            jsonData.name = hotWord.hotword;
                            jsonData.children = hotWordData;
                            list.Add(jsonData);
                        }
                        #endregion
                    }
                    break;
                case SourceDataType.People:
                    {
                        foreach (var person in personList)
                        {
                            var jsonData = new JsonDataTemplate<CommonDataEntity<CommonDataEntity>>();
                            jsonData.name = person.people;
                            jsonData.children = peopleData;
                            list.Add(jsonData);
                        }
                    }
                    break;
                case SourceDataType.Area:
                    {
                        foreach (var area in areaList)
                        {
                            var jsonData = new JsonDataTemplate<CommonDataEntity<CommonDataEntity>>();
                            jsonData.name = area.city;
                            jsonData.children = areaData;
                            list.Add(jsonData);
                        }
                    }
                    break;
                case SourceDataType.Company:
                    {
                        foreach (var company in companyList)
                        {
                            var jsonData = new JsonDataTemplate<CommonDataEntity<CommonDataEntity>>();
                            jsonData.name = company.company_name;
                            jsonData.children = companyData;
                            list.Add(jsonData);
                        }
                    }
                    break;
                default:
                    foreach (var hotWord in hotWordsList)
                    {
                        var jsonData = new JsonDataTemplate<CommonDataEntity<CommonDataEntity>>();
                        jsonData.name = hotWord.hotword;
                        jsonData.children = hotWordData;
                        list.Add(jsonData);
                    }
                    break;
            }

            return list;
        }

    }
}
