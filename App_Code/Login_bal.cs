using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for Class1
/// </summary>
public class login_bal
{
	public login_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string UserName
    {
        get;
        set;
    }
    public string PASSWORD
    {
        get;
        set;
    }
    public string EMAIL
    {
        get;
        set;
    }
    public string EMPID
    {
        get;
        set;
    }

    public string Desc
    {
        get;
        set;
    }
    public string TYPE
    {
        get;
        set;
    }

    public DataSet VerifyLogin(login_bal objReg)
    {
        DataSet ds = new DataSet();
        using (DBManager objDBManager = new DBManager(ConfigurationManager.ConnectionStrings["conn"].ToString()))
        {
            objDBManager.Open();
            objDBManager.CreateParameters(3);
            objDBManager.AddParameters(0, "@EMAIL", objReg.UserName);
            objDBManager.AddParameters(1, "@PWD", objReg.PASSWORD);
            objDBManager.AddParameters(2, "@TYPE", objReg.TYPE);
            ds = objDBManager.ExecuteDataSet(CommandType.StoredProcedure, "USP_USER_LOGIN");           
        }
        return ds;
    }
    public string ForgotPwd(login_bal objReg)
    {
        int intAffectedRows = 0;
        string strout = "";
        using (DBManager objDBManager = new DBManager(ConfigurationManager.ConnectionStrings["conn"].ToString()))
        {
            objDBManager.Open();
            objDBManager.CreateParameters(3);
            objDBManager.AddParameters(0, "@EmpEmail", objReg.EMAIL);
            objDBManager.AddParameters(1, "@EmpPassword", objReg.PASSWORD);
            objDBManager.AddParameters(2, "@msg", "", ParameterDirection.Output);
            intAffectedRows = objDBManager.ExecuteNonQuery(CommandType.StoredProcedure, "EMPFORGOTPASSWORD");
            strout = objDBManager.Parameters[2].Value.ToString();
        }
        return strout;
    }
    public DataSet ConfirmPassword(login_bal objReg)
    {
        DataSet ds = new DataSet();
        using (DBManager objDBManager = new DBManager(ConfigurationManager.ConnectionStrings["conn"].ToString()))
        {
            objDBManager.Open();
            objDBManager.CreateParameters(3);
            objDBManager.AddParameters(0, "@TYPE", objReg.TYPE);
            objDBManager.AddParameters(1, "@PASSWORD", objReg.PASSWORD);
            objDBManager.AddParameters(2, "@ID", objReg.EMPID);
            ds = objDBManager.ExecuteDataSet(CommandType.StoredProcedure, "SP_CHG_PASS");
        }
        return ds;
    }
}
