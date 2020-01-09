using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using HW3.Models;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts a car to the cars table 
    //--------------------------------------------------------------------------------------------------
    public int insert(Flight flight)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(flight);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            //for (int i = 0; i < flight.Routes.Count; i++)
            //{
            //    cStr = BuildInsertCommandRoute(flight.Id,flight,;
            //}
            return numEffected;

        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------------------------------------
    // This method inserts a flight to the orderd flights table 
    //--------------------------------------------------------------------------------------------------
    public int DBSinsertOrderdFlight(OrderdFlight orderdflight)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommandOrderd(orderdflight);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
           
            return numEffected;

        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Flight flight)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Values('{0}', '{1}' ,'{2}','{3}','{4}','{5}','{6}')", flight.Id, flight.Price.ToString(), flight.FlyFrom, flight.FlyTo, flight.DepartDate, flight.ReturnDate, flight.Airlines);
        // use a string builder to create the dynamic string
        String prefix = "INSERT INTO MyFlights " + "(Id, Price,Arrival_City,Departure_City,Arrival_Time,Departure_Time,Airlines ) ";
        command = prefix + sb.ToString();

        return command;
    }




    private String BuildInsertCommandOrderd(OrderdFlight flight)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}','{5}')", flight.FlightID, flight.FullName, flight.Email, flight.Airline, flight.Flyfrom, flight.Flyto);

        // use a string builder to create the dynamic string
        String prefix = "INSERT INTO Ordered_Flights " + "(Flight_ID,Full_Name,Passenger_Email,Airline,FlyFrom,FlyTo) ";
        command = prefix + sb.ToString();

        return command;
    }
    //---------------------------------------------------------------------------------
    // Create the SqlCommand
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }




    public int insertDestinations(List<Destination> d)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }



        try
        {
            String cStr = "";
            int numEffected = 0;
            foreach (var item in d)
            {
                cStr = BuildInsertCommandDEST(item);// helper method to build the insert string
                cmd = CreateCommand(cStr, con);             // create the command
                numEffected = cmd.ExecuteNonQuery(); // execute the command

            }
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------
    // Build the Insert command String  FOR Destinaions
    //--------------------------------------------------------------------
    private String BuildInsertCommandDEST(Destination d)
    {
        String command;


        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string\
        d.Name = d.Name.Replace("'", " ");
        sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}', '{4}','{5}' )", d.Staticid, d.Id, d.Code, d.Location_x, d.Location_y, d.Name);
        string prefix = "INSERT INTO ALL_Destinaions " + "(Staticid,Id, Code, Location_x,Location_y, Dest_name) ";
        command = prefix + sb.ToString();

        return command;
    }
    /// <summary>
    /// route sb services
    /// </summary>
    /// <param name="route"></param>
    /// <returns></returns>
    //public int insertroute(List<Route> route)
    //{

    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {
    //        con = connect("DBConnectionString"); // create the connection
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }

    //    string cStr = "";
    //    int numEffected = 0;


    //    try
    //    {
    //        foreach (var r in route)
    //        {
    //            cStr = BuildInsertCommandRoute(r.Id, r.Code, r.City, r.I);      // helper method to build the insert string

    //            cmd = CreateCommand(cStr, con);             // create the command

    //            numEffected = cmd.ExecuteNonQuery(); // execute the command

    //        }
    //        return numEffected;
    //    }
    //    catch (Exception ex)
    //    {
    //        return 0;
    //        // write to log
    //        throw (ex);
    //    }

    //    finally
    //    {
    //        if (con != null)
    //        {
    //            // close the db connection
    //            con.Close();
    //        }
    //    }

    //}

    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommandRoute(string Id, string Code, string City, string I)
    {
        String command;



        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Values('{0}', '{1}' ,'{2}','{3}')", Id, Code, City, I);
        // use a string builder to create the dynamic string
        String prefix = "INSERT INTO Routes " + "(Id, Code,City,I) ";
        command = prefix + sb.ToString();

        return command;
    }

    public List <OrderdFlight> getOrderdflightsDB()
    {
        List<OrderdFlight> OrderdFlightList = new List<OrderdFlight>();
        SqlConnection con = null;


        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            String selectSTR = "SELECT * FROM Ordered_Flights";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr2 = cmd.ExecuteReader();// (CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr2.Read())
            {   // Read till the end of the data into a row
                OrderdFlight order = new OrderdFlight();

                order.FlightID = (string)dr2["Flight_ID"];
                order.FullName = (string)dr2["Full_Name"];
                order.Email = (string)dr2["Passenger_Email"];
                order.Airline = (string)dr2["Airline"];
                order.Flyfrom = (string)dr2["FlyFrom"];
                order.Flyto = (string)dr2["FlyTo"];

                OrderdFlightList.Add(order);
            }
            dr2.Close();
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return OrderdFlightList;
    }


    //////////////////////////////////////////////////////////////////////////////////////////

    public List<Flight> getMYflight()
    {
        List<Flight> FlightList = new List<Flight>();
        SqlConnection con = null;
       

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            String selectSTR = "SELECT * FROM MyFlights";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr2 = cmd.ExecuteReader();// (CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr2.Read())
            {   // Read till the end of the data into a row
                Flight f = new Flight();
                /////
              /// f.Routes = 
                /////
                f.Id = (string)dr2["Id"];
                f.FlyFrom = (string)dr2["Arrival_City"];
                f.FlyTo = (string)dr2["Departure_City"];
                f.DepartDate = (string)dr2["Arrival_Time"];
                f.ReturnDate = (string)dr2["Departure_Time"];
                f.Price = float.Parse(dr2["Price"].ToString());
                f.Airlines = (string)dr2["Airlines"];
                
                

                f.Routes = new List<string>();
             //
                FlightList.Add(f);
            }
            dr2.Close();
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return FlightList;
    }

  




   

    public List<Flight> get_flight_by_connection(string city)
    {
        List<Flight> FlightList = new List<Flight>();
        SqlConnection con = null;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            String selectSTR = $@"select *
                                  from [dbo].[MyFlights]
                                  where Id in (
                                  select  R.Id
                                  from  [dbo].[MyFlights] F inner join [dbo].[Routes] R on F.Id=R.Id
                                  where R.City='{city}')";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr4 = cmd.ExecuteReader();// (CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr4.Read())
            {   // Read till the end of the data into a row
                Flight f = new Flight();

                f.Id = (string)dr4["Id"];
                f.FlyFrom = (string)dr4["Arrival_City"];
                f.FlyTo = (string)dr4["Departure_City"];
                f.DepartDate = (string)dr4["Arrival_Time"];
                f.ReturnDate = (string)dr4["Departure_Time"];
                f.Price = float.Parse(dr4["Price"].ToString());
                f.Routes = new List<string>();
                FlightList.Add(f);

                
            }
            dr4.Close();
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return FlightList;

    }

    public List<Flight> get_flight_routes_by_connection(List<Flight> FullList)
    {
        SqlConnection con = null;
        String selectSTR = "";
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {

            for (int i = 0; i < FullList.Count; i++)
            {


                selectSTR = $@"SELECT * 
                                   FROM Routes1_2020
                                   where FlightId='{FullList[i].Id}'";

                cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr5 = cmd.ExecuteReader();// (CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                while (dr5.Read())
                {   // Read till the end of the data into a row

                    FullList[i].Routes.Add((string)dr5["Tocity"]);

                }
                dr5.Close();
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return FullList;
    }



    public List<signin> getusers()
    {
        List<signin> users = new List<signin>();
        SqlConnection con = null;


        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            String selectSTR = "SELECT * FROM Signintable";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr2 = cmd.ExecuteReader();// (CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr2.Read())
            {   // Read till the end of the data into a row
                signin u = new signin();

                u.Username = (string)dr2["username"];
                u.Password = (string)dr2["password"];

                users.Add(u);




            }
            dr2.Close();
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return users;
    }




}


