using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Flight_Final.Models;


namespace Flight_Final.Controllers
{
    public class signinController : ApiController
    {
        // GET api/<controller>
        public List<signin> Get()
        {
            signin s = new signin();
            
            return s.getusers();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        
    }
}