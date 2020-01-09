using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Flight_Final.Models
{
    public class signin
    {
        string username;
        string password;
        public signin() { }
        public signin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public List<signin> getusers()
        {
            List<signin> u = new List<signin>();
            DBservices dbs = new DBservices();
            u = dbs.getusers();


            return u;

        }
    }
 
}