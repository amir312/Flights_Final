using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW3.Models
{
    public class OrderdFlight
    {
        string flightID;
        string fullName;
        string email;

        public OrderdFlight(string flightID, string fullName, string email)
        {
            this.flightID = flightID;
            this.fullName = fullName;
            this.email = email;
        }

        public OrderdFlight() { }
        public string FlightID { get => flightID; set => flightID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Email { get => email; set => email = value; }


        public int insertOrderdFlight()
        {
            DBservices dbs1 = new DBservices();
            int numAffected = dbs1.DBSinsertOrderdFlight(this);
            return numAffected;
        }

    }
}