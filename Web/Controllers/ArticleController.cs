using Bussiness;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    public class ArticleController : ApiController
    {
        ArticleBussiness articleBussiness = new ArticleBussiness();
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        public string GetArticleList()
        {
            var articleList = articleBussiness.GetArticleList();
            var strArticleList = JsonConvert.SerializeObject(articleList);
            return strArticleList;
        }

        // GET: api/Article/5
        public string Get(int id)
        {
            return "value";
        }



        // POST: api/Article
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Article/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Article/5
        public void Delete(int id)
        {
        }
    }
}
