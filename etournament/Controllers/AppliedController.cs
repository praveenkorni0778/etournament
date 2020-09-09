using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using etournament.Api.DataAccess;
using etournament.Models;

namespace etournament.Controllers
{
    public class AppliedController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/applied/post")]
        public string Post([FromUri] AppliedModel obj)
        {
            AppliedAccess ap = new AppliedAccess();
            string result = ap.Post(obj);
            return result;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}