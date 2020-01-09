using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flight_Final.Models
{
    public class Flight
    {
       public static List<Flight> flightList = new List<Flight>();
       public static List<Flight> fiteredList = new List<Flight>();

        string id;
        float price;
        string flyFrom;
        string flyTo;
        string departDate;
        string returnDate;
        List<string> subflights = new List<string>();
        string airlines;
        List<string> routes;
        public string Id { get => id; set => id = value; }
        public float Price { get => price; set => price = value; }
        public string FlyFrom { get => flyFrom; set => flyFrom = value; }
   
        public string FlyTo { get => flyTo; set => flyTo = value; }
        public string DepartDate { get => departDate; set => departDate = value; }
        public string ReturnDate { get => returnDate; set => returnDate = value; }
        public List<string> Subflights { get => subflights; set => subflights = value; }
        public string Airlines { get => airlines; set => airlines = value; }
        public List<string> Routes { get => routes; set => routes = value; }

        public Flight() { }
        public Flight(string id, float price, string flyfrom, string flyto, string departdate, string returedate, List<string> subflight, string airlines, List<string> routes)
        {
            Id = id;
            Price = price;
            FlyFrom = flyFrom;
            FlyTo = flyto;
            DepartDate = departdate;
            ReturnDate = returedate;
            Subflights = subflight;
            Airlines  = airlines;
            Routes = routes;
        }

        public List<Flight> getFlight()
        {
            return flightList;
            
        }
        public List<Flight> getFilteredConnection(string City)
        {
            fiteredList = flightList.Where(x => x.routes.Contains(City)).ToList();
            return flightList;
        }


        public int insert()
        {
            DBservices dbs = new DBservices();
            int numEffected = dbs.insert(this);
            return numEffected;
        }

        public List<Flight> getMYflights()
        {
            List<Flight> FullList = new List<Flight>();
           
            DBservices dbs = new DBservices();
            FullList = dbs.getMYflight();
          
           
            return FullList;



        }




        public List<Flight> getflightsByCity(string city)
        {
            List<Flight> FullList = new List<Flight>();
            DBservices dbs = new DBservices();
            FullList = dbs.get_flight_by_connection(city);
            return dbs.get_flight_routes_by_connection(FullList);
        }





    }






}