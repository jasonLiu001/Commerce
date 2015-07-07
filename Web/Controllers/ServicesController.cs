using Bussiness;
using Model.DataTemplate;
using Model.UrlParams;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Utility;

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

        // GET: api/Services/GetAtricleRank
        public string GetAtricleRank()
        {
            var list = businessService.GetArticleList();
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // GET: api/Services/GetArticles
        public string GetArticles([FromUri] UrlParams urlParams)
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

        // POST: api/Services/GetCompassData
        [HttpPost]
        public string GetCompassData([FromBody]SourceDataType sourceDateType)
        {
            var queryDate=Util.ConvertToDateTime(sourceDateType.queryDate);
            if(queryDate==null){
                var list = new List<JsonDataTemplate<CommonDataEntity>>();
                var jsonData = new JsonDataTemplate<CommonDataEntity>();
                jsonData.name="Date format error!";
                jsonData.errorMsg = "日期格式错误！";
                list.Add(jsonData);
                return JsonConvert.SerializeObject(list);
            }

            var compassData = businessService.GetCompassDataList(sourceDateType.dataType, queryDate);
            var compassJsonData = JsonConvert.SerializeObject(compassData);
            return compassJsonData;
        }

        // GET: api/Services/GetChangeTrend
        public string GetChangeTrend() {
            var list = businessService.GetHotWordPercentageList();
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }
    }
}
