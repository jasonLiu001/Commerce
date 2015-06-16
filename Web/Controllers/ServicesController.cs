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
        public string GetCompanyGroupByHotWords()
        {
            var list = businessService.GetCompanyGroupByHotWords();
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        public string GetArticles()
        {
            var list = businessService.GetArticleList();
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // POST: api/Services
        public void Post([FromBody]string value)
        {
        }
    }
}
