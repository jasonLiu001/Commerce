using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.DataAccess;

namespace Web.Controllers
{
    public class IndexController : ApiController
    {
        private BusinessContext db = new BusinessContext();

        // GET: api/Index
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Index/5
        public string Get(int id)
        {
            var data = db.Students.ToList();

            //add student
            db.Students.Add(new Models.Student
            {
                id = 1,
                name = "test"
            });
            int r = db.SaveChanges();


            return "data count=" + data.Count;
        }

        // POST: api/Index
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Index/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Index/5
        public void Delete(int id)
        {
        }
    }
}
