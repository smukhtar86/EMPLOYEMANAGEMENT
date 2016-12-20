using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;
using System.Configuration;

/// <summary>
/// Summary description for Login
/// </summary>
public abstract class Login
{
    public Login()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string UserId
    {
        get;
        set;
    }
    public string UserName
    {
        get;
        set;
    }
    public string UserPWD
    {
        get;
        set;
    }
    public string UserType
    {
        get;
        set;
    }

    public DataSet VerifyLogin(Login objEmployee)
    {
        DataSet ds = new DataSet();
        using (DBManager objDBManager = new DBManager(ConfigurationManager.ConnectionStrings["conn"].ToString()))
        {
            objDBManager.Open();
            objDBManager.CreateParameters(3);
            objDBManager.AddParameters(0, "@USER_ID", objEmployee.UserName);
            objDBManager.AddParameters(1, "@USER_PWD", objEmployee.UserPWD);
            objDBManager.AddParameters(2, "@USER_TYPE", objEmployee.UserType);
            ds = objDBManager.ExecuteDataSet(CommandType.StoredProcedure, "USP_SMSDTL");
        }
        return ds;
    }
    public string VerifyLogin(Admin objAdmin)
    {
        Common_Class _cs = new Common_Class();
        string retSatus = "";
        string ss = objAdmin.UserId;// ConfigurationManager.AppSettings["User"].ToString();
        string dd = objAdmin.UserPWD;// ConfigurationManager.AppSettings["PWD"].ToString();
        DataSet ds = _cs._Get_Dataset("select * from TBL_COMPANY_MST WHERE CMP_EMAIL='" + ss + "' and CMP_PWD='" + dd + "'");
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                //if (objAdmin.UserId == ConfigurationManager.AppSettings["User"].ToString() && objAdmin.UserPWD == ConfigurationManager.AppSettings["PWD"].ToString())
                //{
                retSatus = "SUCCESS";
            }
            else
            {
                retSatus = "FAILED";
            }

        }
        else
        {
            retSatus = "FAILED";
        }
        return retSatus;
    }
    public DataSet GetCorpInfoDDL()
    {
        DataSet ds = new DataSet();
        using (DBManager objDBManager = new DBManager(ConfigurationManager.ConnectionStrings["conn"].ToString()))
        {
            objDBManager.Open();
            ds = objDBManager.ExecuteDataSet(CommandType.StoredProcedure, "SP_GET_DDL_CORPLIST");
        }
        return ds;
    }
}