using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//this is the API controller
//check the basic ASP.net site, and you'll see these things
//on the API link (or "/help") 

//if you add, say, "/api/values" to the end of the site's URL
//you will see the xml schemas for what's below

namespace WebAPIDemoDec2018.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        // gets all the values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        // the overloaded GET method
        // gets a specific value
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        // creates a new value -- starts empty
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        // updates a value -- starts empty
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        // deletes a value -- starts empty
        public void Delete(int id)
        {
        }
    }
}
