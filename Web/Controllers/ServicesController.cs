using Bussiness;
using Model.Pagination;
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

        // GET: api/Services/GetCompanyGroupByHotWords
        public string GetCompanyGroupByHotWords()
        {
            var list = businessService.GetCompanyGroupByHotWords();
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // GET: api/Services/GetArticlesWithoutPagination
        public string GetArticlesWithoutPagination()
        {
            var list = businessService.GetArticleList();
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // GET: api/Services/GetArticles
        public string GetArticles([FromUri] PaginationParams urlParams)
        {
            var list = businessService.GetArticleList(urlParams.pageIndex,urlParams.pageSize);
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // GET: api/Services/GetEmotionPercentage
        public string GetEmotionPercentage()
        {
            var list = businessService.GetEmotionPercentageList();
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // GET: api/Services/GetCatagoryPercentage
        public string GetCatagoryPercentage()
        {
            var list = businessService.GetCategoryPercentageList();
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // GET: api/Services/GetHotWordPercentage
        public string GetHotWordPercentage()
        {
            var list = businessService.GetHotWordPercentageList();
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // GET: api/Services/GetSiteRank
        public string GetSiteRank()
        {
            var list = businessService.GetSiteRankList();
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // POST: api/Services
        public void Post([FromBody]string value)
        {
        }
    }
}
