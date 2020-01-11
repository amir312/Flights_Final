using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HW3.Models;

namespace HW3.Controllers
{
    public class OrderdFlightController : ApiController
    {
        // GET api/<controller>

        //public List<OrderdFlight> Get()
        //{
        //    OrderdFlight ordered_flight = new OrderdFlight();
        //    return ordered_flight.getOrderdflights();

        //}

      

        [HttpGet]

        public List<OrderdFlight> GetFlights()
        {
               OrderdFlight ordered_flight = new OrderdFlight();
               return ordered_flight.getOrderdflights();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST api/<controller>
        public void Post([FromBody] Models.OrderdFlight oflt1)
        {
            oflt1.insertOrderdFlight();

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