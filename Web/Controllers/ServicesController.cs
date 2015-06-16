using Bussiness;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    public class ServicesController : ApiController
    {
        BusinessService businessService = new BusinessService();

        // GET: api/Services
        public string GetHotWords()
        {
            var hotWords = businessService.GetHotWords();
            var hotWordsList = JsonConvert.SerializeObject(hotWords);
            return hotWordsList;
        }

        public string GetArticles()
        {
            var articleList = businessService.GetArticleList();
            var strArticleList = JsonConvert.SerializeObject(articleList);
            return strArticleList;
        }

        // POST: api/Services
        public void Post([FromBody]string value)
        {
        }
    }
}
