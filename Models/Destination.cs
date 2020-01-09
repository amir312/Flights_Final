using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flight_Final.Models
{
    public class Destination
    {
        string staticid;
        string id;
        string code;
        string  location_x  ;
        string  location_y  ;
        string name;

    

        public Destination()
        { }

        public Destination(string staticid, string id, string code, string location_x, string location_y, string name)
        {
            this.staticid = staticid;
            this.id = id;
            this.code = code;
            this.location_x = location_x;
            this.location_y = location_y;
            this.name = name;
        }

        public string Staticid { get => staticid; set => staticid = value; }
        public string Id { get => id; set => id = value; }       
        public string Code { get => code; set => code = value; }
        public string Location_x { get => location_x; set => location_x = value; }
        public string Location_y { get => location_y; set => location_y = value; }
        public string Name { get => name; set => name = value; }

        public int InsertDestinations(List<Destination> d)
        {
            DBservices dbs = new DBservices();
            int numEffected = dbs.insertDestinations(d);
            return numEffected;
        }
    }

   


}

