using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Flight_Final.Models;

namespace HW3.Controllers
{
    public class OrderFlightController : ApiController
    {
       
        public void Post([FromBody]OrderdFlight oflt1)
        {
            oflt1.insertOrderdFlight();


        }

     
    }
}