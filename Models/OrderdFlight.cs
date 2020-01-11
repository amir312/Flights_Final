using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW3.Models
{
    public class OrderdFlight
    {
        public static List<OrderdFlight> OrderdflightList = new List<OrderdFlight>();
        public static List<OrderdFlight> OrderdfiteredList = new List<OrderdFlight>();


        string flightID;
        string fullName;
        string email;
        string airline;
        string flyfrom;
        string flyto;

        public OrderdFlight() { }

        public OrderdFlight(string flightID, string fullName, string email, string airline, string flyfrom, string flyto)
        {
            this.flightID = flightID;
            this.fullName = fullName;
            this.email = email;
            this.airline = airline;
            this.flyfrom = flyfrom;
            this.flyto = flyto;
        }


        public string FlightID { get => flightID; set => flightID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Email { get => email; set => email = value; }
        public string Airline { get => airline; set => airline = value; }
        public string Flyfrom { get => flyfrom; set => flyfrom = value; }
        public string Flyto { get => flyto; set => flyto = value; }

        public int insertOrderdFlight()
        {
            DBservices dbs1 = new DBservices();
            int numAffected = dbs1.DBSinsertOrderdFlight(this);
            return numAffected;
        }



        public List<OrderdFlight> getOrderdflights()
        {
            List<OrderdFlight> orderd_List = new List<OrderdFlight>();

            DBservices dbs = new DBservices();
            orderd_List = dbs.getOrderdflightsDB();

            return orderd_List;
        }
    }
}