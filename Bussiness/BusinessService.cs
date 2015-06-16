using DataAccess;
using Model;
using Model.Common;
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

        public List<JsonDataTemplate<HotWord>> GetHotWords()
        {
            var list = new List<JsonDataTemplate<HotWord>>();
            var jsonData = new JsonDataTemplate<HotWord>();
            var hotWordsList = dataService.GetHotWordsList();
            jsonData.name = "大数据";
            jsonData.type = "root";
            jsonData.children = hotWordsList;
            list.Add(jsonData);
            return list;
        }
    }
}
