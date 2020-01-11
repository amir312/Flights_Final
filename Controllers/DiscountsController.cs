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
        public List<Discounts> Post(Discounts discount1)
        {
            Discounts discount = new Discounts();
            discount1.InsertDiscount();
            return discount.getdiscounts();
        }

        // PUT api/<controller>/5
        public List<Discounts> Put(Discounts discount2)
        {
            Discounts discount = new Discounts();
            discount2.PutDiscount();
            return discount.getdiscounts();
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