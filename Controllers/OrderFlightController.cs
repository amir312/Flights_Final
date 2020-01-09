using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HW3.Models;

namespace HW3.Controllers
{
    public class OrderFlightController : ApiController
    {

        public IEnumerable<OrderdFlight> Get()
        {

            OrderdFlight ordered_flight = new OrderdFlight();
            return ordered_flight.getOrderdflights();

        }



        public void Post([FromBody]OrderdFlight oflt1)
        {
            oflt1.insertOrderdFlight();


        }

     
    }
}