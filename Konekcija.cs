using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication49
{
    public class Konekcija
    {
        public static string Conn = @"Data Source=.\SQLEXPRESS;Initial Catalog=TuristickaAgencija;Integrated Security=true";

        public static SqlCommand GetCommand() 
        {
            SqlConnection con = new SqlConnection(Conn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return cmd;
        }
    }
}