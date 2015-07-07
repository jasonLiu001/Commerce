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

        /// <summary>
        /// 获取根据罗盘指示的类型获取数据
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public List<CompassDataTemplate<CommonDataEntity, CommonDataEntity, CommonDataEntity>> GetCompassDataList(string keyWord, DateTime? queryDate)
        {
            var list = new List<CompassDataTemplate<CommonDataEntity, CommonDataEntity, CommonDataEntity>>();
            var hotWordsList = dataService.GetHotWordsList();
            var companyList = dataService.GetCompanyList();
            var areaList = dataService.GetAreasList();
            var personList = dataService.GetCompanyList();

            #region Fill company data.
            var companyData = new List<CommonDataEntity>();
            foreach (var company in companyList)
            {
                var commonData = new CommonDataEntity();
                commonData.name = company.company_name;
                commonData.type = "company";
                companyData.Add(commonData);
            }
            #endregion

            #region Fill area data.
            var areaData = new List<CommonDataEntity>();
            foreach (var area in areaList)
            {
                var commonData = new CommonDataEntity();
                commonData.name = area.area;
                commonData.type = "area";
                areaData.Add(commonData);
            }
            #endregion

            #region Fill person data.
            var personData = new List<CommonDataEntity>();
            foreach (var person in personList)
            {
                var commonData = new CommonDataEntity();
                commonData.name = person.company_boss;
                commonData.type = "person";
                personData.Add(commonData);
            }
            #endregion

            #region Fill hotword data
            var hotWordData = new List<CommonDataEntity>();
            foreach (var hotword in hotWordsList)
            {
                var commonData = new CommonDataEntity();
                commonData.name = hotword.hotword;
                commonData.type = "hotword";
                hotWordData.Add(commonData);
            }
            #endregion

            switch (keyWord)
            {
                case SourceDataType.HotWord:
                    {
                        #region Final Data by hotWords
                        foreach (var hotWord in hotWordsList)
                        {
                            var jsonData = new CompassDataTemplate<CommonDataEntity, CommonDataEntity, CommonDataEntity>();
                            jsonData.name = hotWord.hotword;
                            jsonData.children1 = companyData;
                            jsonData.children2 = areaData;
                            jsonData.children3 = personData;
                            list.Add(jsonData);
                        }
                        #endregion
                    }
                    break;
                case SourceDataType.Person:
                    {
                        foreach (var person in personList)
                        {
                            var jsonData = new CompassDataTemplate<CommonDataEntity, CommonDataEntity, CommonDataEntity>();
                            jsonData.name = person.company_boss;
                            jsonData.children1 = hotWordData;
                            jsonData.children2 = areaData;
                            jsonData.children3 = personData;
                            list.Add(jsonData);
                        }
                    }
                    break;
                case SourceDataType.Area:
                    {
                        foreach (var area in areaList)
                        {
                            var jsonData = new CompassDataTemplate<CommonDataEntity, CommonDataEntity, CommonDataEntity>();
                            jsonData.name = area.area;
                            jsonData.children1 = companyData;
                            jsonData.children2 = areaData;
                            jsonData.children3 = personData;
                            list.Add(jsonData);
                        }
                    }
                    break;
                case SourceDataType.Company:
                    {
                        foreach (var company in companyList)
                        {
                            var jsonData = new CompassDataTemplate<CommonDataEntity, CommonDataEntity, CommonDataEntity>();
                            jsonData.name = company.company_name;
                            jsonData.children1 = companyData;
                            jsonData.children2 = areaData;
                            jsonData.children3 = personData;
                            list.Add(jsonData);
                        }
                    }
                    break;
            }

            return list;
        }
      
    }
}
