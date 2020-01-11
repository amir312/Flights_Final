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
        decimal discount;
        int id;

        public Discounts() { }
        public Discounts(string airline, string flyfrom, string flyto, string startdate, string finishdate, decimal discount, int id)
        {
            this.airline = airline;
            this.flyfrom = flyfrom;
            this.flyto = flyto;
            this.startdate = startdate;
            this.finishdate = finishdate;
            this.discount = discount;
            this.id = id;
        }

        public string Airline { get => airline; set => airline = value; }
        public string Flyfrom { get => flyfrom; set => flyfrom = value; }
        public string Flyto { get => flyto; set => flyto = value; }
        public string Startdate { get => startdate; set => startdate = value; }
        public string Finishdate { get => finishdate; set => finishdate = value; }
        public decimal Discount { get => discount; set => discount = value; }
        public int Id { get => id; set => id = value; }

        public List<Discounts> getdiscounts()
        {
            List<Discounts> u = new List<Discounts>();
            DBservices dbs = new DBservices();
            u = dbs.getdiscounts();
            return u;
        }

        public void DeleteDiscount (int id)
        {
            DBservices dbs = new DBservices();
            dbs.DeleteDiscount(id);
        }
    }
}