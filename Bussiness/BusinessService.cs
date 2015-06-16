using DataAccess;
using Model;
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
            jsonData.name = "大数据";
            jsonData.type = "root";
            jsonData.children = articleList;
            list.Add(jsonData);
            return list;
        }

        public List<JsonDataTemplate<CommonDataEntity>> GetCompanyGroupByHotWords()
        {
            var list = new List<JsonDataTemplate<CommonDataEntity>>();
            var hotWordsList = dataService.GetHotWordsList();

            #region Get Common
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
    }
}
