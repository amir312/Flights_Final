﻿using System;
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
    // This method inserts a flight to the flights table 
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
        sb.AppendFormat("Values('{0}', '{1}' ,'{2}','{3}','{4}','{5}')", flight.Id, flight.Airlines, flight.FlyFrom, flight.FlyTo, flight.DepartDate, flight.ReturnDate);
        // use a string builder to create the dynamic string
        String prefix = "INSERT INTO FavoriteTBL " + "(FlightID, AirLine, FlyFrom, FlyTO, Departure, Arraivel)";

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

    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    public List<OrderdFlight> getOrderdflightsDB()
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
            String selectSTR = "SELECT COUNT(ID) as FavNum, FlightID, AirLine,FlyFrom, FlyTO, Departure, Arraivel" +
                " FROM [dbo].[FavoriteTBL]" +
                " GROUP BY FlightID, AirLine,FlyFrom, FlyTO, Departure, Arraivel ORDER BY COUNT(ID) DESC, AirLine; ";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr2 = cmd.ExecuteReader();// (CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr2.Read())
            {   // Read till the end of the data into a row
                Flight f = new Flight();
                f.Id = (string)dr2["FlightID"];
                f.FlyFrom = (string)dr2["FlyFrom"];
                f.FlyTo = (string)dr2["FlyTO"];
                f.DepartDate = (string)dr2["Departure"];
                f.ReturnDate = (string)dr2["Arraivel"];
                f.Price = float.Parse(dr2["FavNum"].ToString());
                f.Airlines = (string)dr2["Airline"];

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

    public List<Discounts> getdiscounts()
    {
        List<Discounts> discounts = new List<Discounts>();
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
            String selectSTR = "SELECT * FROM Discounts";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr2 = cmd.ExecuteReader();// (CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr2.Read())
            {   // Read till the end of the data into a row
                Discounts u = new Discounts();

                u.Airline = (string)dr2["airline"];
                u.Flyfrom = (string)dr2["flyfrom"];
                u.Flyto = (string)dr2["flyto"];
                u.Startdate = (string)dr2["startdate"];
                u.Finishdate = (string)dr2["finishdate"];
                u.Discount = (decimal)dr2["discount"];
                u.Id = (int)dr2["ID"];

                discounts.Add(u);
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
        return discounts;
    }

    //  DELETE Discount
    //--------------------------------------------------------------------------------------------------
    public int DeleteDiscount(int Id)
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
        String cStr = "delete from Discounts where ID = " + Id.ToString();      // helper method to build the insert string
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

    public int InsertDiscount (Discounts discount1)
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

        String cStr = BuildInsertCommandDiscount(discount1);      // helper method to build the insert string

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

    private String BuildInsertCommandDiscount(Discounts discount1)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}','{5}')", discount1.Airline, discount1.Flyfrom, discount1.Flyto, discount1.Startdate, discount1.Finishdate, discount1.Discount);

        // use a string builder to create the dynamic string
        String prefix = "INSERT INTO Discounts" + "(airline,flyfrom,flyto,startdate,finishdate,discount) ";
        command = prefix + sb.ToString();

        return command;
    }

    public int PutDiscount(Discounts d)
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
        String cStr = BuildPutCommandDiscount(d);      // helper method to build the insert string
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
    // 17.  Build PUT Sale Command
    //--------------------------------------------------------------------
    private String BuildPutCommandDiscount(Discounts discount)
    {
        String command;
        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        String prefix = "UPDATE Discounts SET [airline] = '" + discount.Airline + "', [flyfrom] = '" + discount.Flyfrom + "', [flyto] = '" + discount.Flyto + "', [startdate] = '" + discount.Startdate + "', [finishdate] =  '" + discount.Finishdate + "', [discount] =  " + discount.Discount + " WHERE [ID] = " + discount.Id + "";
        command = prefix;
        return command;
    }
}


