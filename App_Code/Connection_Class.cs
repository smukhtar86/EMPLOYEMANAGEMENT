using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Connection_Class
/// </summary>
public class Connection_Class
{
	public Connection_Class()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string ORBIT9_connection;
    SqlConnection con;
    public static string constr
    {
        get
        {
            if (ORBIT9_connection == null)
            {
                ORBIT9_connection = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString();
            }
            return ORBIT9_connection;
        }
    }
    public SqlConnection connection
    {
        get
        {
            if (con == null)
            {
                con = new SqlConnection();
                con.ConnectionString = constr;
                con.Open();
                return con;
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

    }
}
