using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW3.Models
{
    public class Discounts
    {
        string airline;
        string flyfrom;
        string flyto;
        string startdate;
        string finishdate;
        float discount;

        public Discounts() { }
        public Discounts(string airline, string flyfrom, string flyto, string startdate, string finishdate, float discount)
        {
            this.airline = airline;
            this.flyfrom = flyfrom;
            this.flyto = flyto;
            this.startdate = startdate;
            this.finishdate = finishdate;
            this.discount = discount;
        }

        public string Airline { get => airline; set => airline = value; }
        public string Flyfrom { get => flyfrom; set => flyfrom = value; }
        public string Flyto { get => flyto; set => flyto = value; }
        public string Startdate { get => startdate; set => startdate = value; }
        public string Finishdate { get => finishdate; set => finishdate = value; }
        public float Discount { get => discount; set => discount = value; }

        public List<Discounts> getusers()
        {
            List<Discounts> u = new List<Discounts>();
            DBservices dbs = new DBservices();
            u = dbs.getdiscounts();
            return u;
        }
    }
}