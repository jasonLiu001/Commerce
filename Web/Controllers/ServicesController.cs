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
using System.Web.Http.Cors;
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

        // GET: api/Services/GetArticles
        public string GetArticles([FromUri] UrlParams urlParams)
        {
            var list = businessService.GetArticleList(urlParams.pageIndex, urlParams.pageSize);
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

        // GET: api/Services/GetLatestAtricles
        public string GetLatestAtricles()
        {
            var list = businessService.GetLatestAtricles();
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // POST: api/Services/GetAtricleRank
        [HttpPost]
        public string GetAtricleRank([FromBody]SourceDataType sourceDateType)
        {
            var queryDate = Util.ConvertToDateTime(sourceDateType.queryDate);
            var verifyResult = ParamsVerify(sourceDateType, queryDate);
            if (verifyResult != null)
            {
                return JsonConvert.SerializeObject(verifyResult);
            }

            var list = businessService.GetArticleRankList(sourceDateType.dataType, queryDate, sourceDateType.topCount);
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // POST: api/Services/GetSiteRank
        [HttpPost]
        public string GetSiteRank([FromBody]SourceDataType sourceDateType)
        {
            var queryDate = Util.ConvertToDateTime(sourceDateType.queryDate);
            var verifyResult = ParamsVerify(sourceDateType, queryDate);
            if (verifyResult != null)
            {
                return JsonConvert.SerializeObject(verifyResult);
            }

            var list = businessService.GetSiteRankList(sourceDateType.dataType, queryDate, sourceDateType.topCount);
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        // POST: api/Services/GetCompassData
        [HttpPost]
        public string GetCompassData([FromBody]SourceDataType sourceDateType)
        {
            var queryDate = Util.ConvertToDateTime(sourceDateType.queryDate);
            var verifyResult = ParamsVerify(sourceDateType, queryDate);
            if (verifyResult != null)
            {
                return JsonConvert.SerializeObject(verifyResult);
            }

            var compassData = businessService.GetCompassDataList(sourceDateType.dataType, queryDate, sourceDateType.topCount);
            var compassJsonData = JsonConvert.SerializeObject(compassData);
            return compassJsonData;
        }

        // POST: api/Services/GetChangeTrend
        [HttpPost]
        public string GetChangeTrend([FromBody]SourceDataType sourceDateType)
        {
            var queryDate = Util.ConvertToDateTime(sourceDateType.queryDate);
            var verifyResult = ParamsVerify(sourceDateType, queryDate);
            if (verifyResult != null)
            {
                return JsonConvert.SerializeObject(verifyResult);
            }

            var list = businessService.GetHotWordChangeTrend(sourceDateType.dataType, queryDate, sourceDateType.topCount);
            var jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        private List<JsonDataTemplate<CommonDataEntity>> ParamsVerify(SourceDataType sourceDateType, DateTime queryDate)
        {
            List<JsonDataTemplate<CommonDataEntity>> errorList = null;
            var errorJsonData = new JsonDataTemplate<CommonDataEntity>();
            errorJsonData.name = "参数错误";

            if (string.IsNullOrEmpty(sourceDateType.dataType))
            {
                sourceDateType.dataType = "hotword";
            }
            else if (string.IsNullOrEmpty(sourceDateType.queryDate))
            {
                sourceDateType.dataType = "2015-05-27";
            }
            else if (string.IsNullOrEmpty(sourceDateType.topCount))
            {
                sourceDateType.topCount = "10";
            }
            else if (queryDate == DateTime.MinValue)
            {
                errorList = new List<JsonDataTemplate<CommonDataEntity>>();
                errorJsonData.errorMsg = "参数queryDate日期格式错误！";
                errorList.Add(errorJsonData);
            }
            return errorList;
        }
    }
}
