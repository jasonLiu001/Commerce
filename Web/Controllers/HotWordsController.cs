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
    public class HotWordsController : ApiController
    {
        HotWordsBussiness hotWordsBussiness = new HotWordsBussiness();
        // GET: api/GetHotWords
        public string GetHotWords()
        {
            var hotWords = hotWordsBussiness.GetHotWords();
            var hotWordsList = JsonConvert.SerializeObject(hotWords);
            return hotWordsList;
        }

        // GET: api/HotWords/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HotWords
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HotWords/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HotWords/5
        public void Delete(int id)
        {
        }
    }
}
