using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HW3.Models;

namespace HW3.Controllers
{
    public class FlightsController : ApiController
    {    
        
        Flight flightToFlilter = new Flight();

        // GET api/<controller>
        public IEnumerable<Flight> Get()
        {
            //return new string[] { "value1", "value2" };
            //   Flight flt1 = new Flight();
            // return flt1.getFlight();
           
                Flight flight = new Flight();
                    return flight.getMYflights();
          
        }


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/flights/stop/{city}")]
        public IEnumerable<Flight> Get(string city)
        {
            //return flightToFlilter.getFilteredConnection(city);
            Flight flight = new Flight();
            return flight.getflightsByCity(city);

        }
        // POST api/<controller>
        public void Post([FromBody]Flight flt1)
        {
            //Flight.flightList.Add(flt1);
            //Flight f = new Flight();

            flt1.insert();

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