using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HW3.Models;

namespace HW3.Controllers
{
    public class DiscountsController : ApiController
    {
        // GET api/<controller>

        //public List<OrderdFlight> Get()
        //{
        //    OrderdFlight ordered_flight = new OrderdFlight();
        //    return ordered_flight.getOrderdflights();

        //}

        [HttpGet]

        public List<Discounts> Getdiscounts()
        {
            Discounts discount = new Discounts();
            return discount.getdiscounts();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }


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
        public List<Discounts> Delete(int id)
        {
            Discounts discount = new Discounts();
            discount.DeleteDiscount(id);
            return discount.getdiscounts();
        }
    }
}