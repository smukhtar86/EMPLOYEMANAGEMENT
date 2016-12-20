using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;
using ENC_DEC;
using System.Configuration;
/// <summary>
/// Summary description for _Utility
/// </summary>
public class _Utility : _Property
{
    Common_Class _cs = new Common_Class();
    public _Utility()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region //Employee / customer
    public int Insert_Employee_Customer_Data(_Utility utl, string typ)
    {
        int x = 0;
        if (typ == "I")
        {
            x = _cs.ExecuteQuery("insert into TBL_EMPLOYEE_CUSTOMER_MST(ECM_ECAT_CD,ECM_UPR_ID,ECM_NAME,ECM_PHNO,ECM_ADD,ECM_EMAIL,ECM_PWD,ECM_BANK_DETAILS,ECM_PHOTO) values('" + utl.User_Type + "','" + utl.UpperId + "','" + utl.Name + "','" + utl.Phone + "','" + utl.Address + "','" + utl.Email + "','" + utl.Password + "','" + utl.BankDetails + "','" + utl.Photo + "')");
        }
        else if (typ == "U")
        {
            x = _cs.ExecuteQuery("UPDATE TBL_EMPLOYEE_CUSTOMER_MST SET ECM_ECAT_CD='" + utl.User_Type + "',ECM_UPR_ID='" + utl.UpperId + "',ECM_NAME='" + utl.Name + "',ECM_PHNO='" + utl.Phone + "',ECM_ADD='" + utl.Address + "',ECM_EMAIL='" + utl.Email + "',ECM_PWD='" + utl.Password + "',ECM_BANK_DETAILS='" + utl.BankDetails + "',ECM_PHOTO='" + utl.Photo + "' WHERE ECM_CODE='" + utl.Code + "'");
        }
        return x;
    }
    public string Insert_Vendor_Price_Per_PC(_Utility utl)
    {
        return _cs.ExecuteCmd_WithOutput(_cs.ReturnCommand("USP_TBL_GLUE_SALE_PRICE_INF", "@SAL_VENDOR_CD^@SAL_PRD_CD^@SAL_PRICE_PC", utl.Emp_Cust_Code + "^" + utl.Product_Code + "^" + utl.Product_Price, '^'), "@OUT");
    }
    public DataSet Get_Employee_Customer_Data(string typ)
    {
        return _cs._Get_Dataset("USP_TBL_EMPLOYEE_CUSTOMER_MST '" + typ + "'");
    }
    public DataSet Get_Employee_Customer_Data_Individual(string cd)
    {
        return _cs._Get_Dataset("SELECT * FROM VW_TBL_EMPLOYEE_CUSTOMER_MST where ECM_CODE='" + cd + "'");
    }

    public string Insert_Product(_Utility utl)
    {
        return _cs.ExecuteCmd_WithOutput(_cs.ReturnCommand("USP_TBL_GLUE_SALE_PRICE_INF", "@SAL_VENDOR_CD^@SAL_PRD_CD^@SAL_PRICE_PC", utl.Emp_Cust_Code + "^" + utl.Product_Code + "^" + utl.Product_Price, '^'), "@OUT");
    }

    public DataSet Get_Product_Venodr(string vendor)
    {
        return _cs._Get_Dataset("USP_TBL_GLUE_SALE_PRICE_INF_VENDOR '" + vendor + "'");
    }
    public string Insert_New_Product(_Utility utl)
    {
        return _cs.ExecuteCmd_WithOutput(_cs.ReturnCommand("USP_TBL_GLUE_PRODUCT_MST", "@PRD_CODE^@PRD_NAME^@PRD_SLE_PRC^@PRD_PUR_PRC^@PRD_BOX_SIZE^@PRD_TYPE_CD^@PRD_TAX_CD^@PRD_STS^@TYPE", utl.Product_Code + "^" + utl.Name + "^" + utl.Product_Price + "^" + utl.Product_Purchase_Price + "^" + utl.Product_Box_Size + "^" + utl.PrdType + "^" + utl.VAT + "^" + utl.Status + "^" + utl.Type, '^'), "@OUT");
    }
    public DataSet Get_Product()
    {
        return _cs._Get_Dataset("select * from VW_TBL_GLUE_PRODUCT_MST");
    }
    public DataSet Get_VAT()
    {
        return _cs._Get_Dataset("select * from TBL_VAT_ENM");
    }
    public DataSet Get_MeasureType()
    {
        return _cs._Get_Dataset("select * from TBL_PROUDCT_TYPE_ENM");
    }
    public DataSet Get_Designation(string cond)
    {
        return _cs._Get_Dataset("select * from TBL_ENM_DESIGNATION where " + cond + " ECAT_STS='Y' order by ECAT_NAME");
    }


    #endregion

    #region // Journal Entry
    public int Insert_Journal_Data(_Utility utl)
    {
        return _cs.ExecuteQuery("insert into TBL_JOURNAL_HDR(JRN_DT,JRN_ECM_CD,JRN_CR_DR,JRN_FRM_TO,JRN_DESC,JRN_AMT) values('" + Convert.ToDateTime(utl.Date).ToString("dd-MMM-yyyy") + "','" + utl.Emp_Cust_Code + "','" + utl.CR_DR + "','" + utl.Emp_Cust_Code_To + "','" + utl.Description + "','" + utl.Amount + "')");
    }
    #endregion

    public string Insert_User_Data(_Utility utl)
    {
        string re = "";
        DataSet ds = _cs._Get_Dataset("select * from TBL_EMPLOYEE_CUSTOMER_MST where ECM_ECAT_CD='6' AND ECM_EMAIL='" + utl.Email + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            re = "InvEmail";
        }
        else
        {
            if (_cs.ExecuteQuery("insert into TBL_EMPLOYEE_CUSTOMER_MST(ECM_ECAT_CD,ECM_NAME,ECM_PHNO,ECM_EMAIL,ECM_PWD) values('6','" + utl.Name + "','" + utl.Phone + "','" + utl.Email + "','" + utl.Password + "')") == 1)
            {
                re = "Success";
            }
            else
            {
                re = "Error";
            }
        }
        return re;
    }

    public string _Inser_Sale(_Utility utl)
    {
        string re = "";

        if (_cs.ExecuteQuery("insert into TBL_GLUE_SALE_MST(SAL_DT,SAL_VENDOR_CD,SAL_PRD_CD,SAL_QNTY,SAL_PRICE_PC,SAL_TOT_AMT,SAL_TYPE,SAL_REMARKS) values('" + utl.Date + "','" + utl.Emp_Cust_Code + "','" + utl.Product_Code + "','" + utl.Product_Qnty + "','" + utl.Product_Price + "','" + utl.Amount + "','" + utl.Type + "','" + utl.Remarks + "')") == 1)
        {
            re = "Success";
        }
        else
        {
            re = "Error";
        }
        return re;
    }

    public DataSet Get_Sale_Report(string cond)
    {
        return _cs._Get_Dataset("select * from VW_TBL_GLUE_SALE_MST " + cond);
    }
    public DataSet Get_Sale_Report(string field, string cond)
    {
        return _cs._Get_Dataset("select " + field + " from VW_TBL_GLUE_SALE_MST " + cond);
    }
    public DataSet Get_Sale_Report1(string vendor)
    {
        return _cs._Get_Dataset("select SAL_VENDOR_CD,SAL_PRD_CD,PRD_NAME,SUM(SAL_QNTY) AS QNTY,CONVERT(NUMERIC(18,0),SUM(SAL_QNTY)/PRD_BOX_SIZE) AS BOX from VW_TBL_GLUE_SALE_MST WHERE SAL_VENDOR_CD='" + vendor + "' group by SAL_VENDOR_CD,SAL_PRD_CD,PRD_NAME,PRD_BOX_SIZE");
    }

    public string _Insert_Payment(_Utility utl)
    {
        string re = "";

        if (_cs.ExecuteQuery("insert into TBL_GLUE_VENDOR_PAYMENT_INF(PAY_DT,PAY_VEN_CD,PAY_AMOUNT) values('" + utl.Date + "','" + utl.Emp_Cust_Code + "','" + utl.Amount + "')") == 1)
        {
            re = "Success";
        }
        else
        {
            re = "Error";
        }
        return re;
    }


    public DataSet Get_Product_Stock(string cond)
    {
        return _cs._Get_Dataset("select * from VW_TBL_GLUE_PURCHASE_ORDER_MST " + cond);
    }
    public DataSet Get_Product_Stock(string field, string cond)
    {
        return _cs._Get_Dataset("select " + field + " from VW_TBL_GLUE_PURCHASE_ORDER_MST " + cond);
    }
    public string _Insert_Stock(_Utility utl)
    {
        string re = "";
        //[dbo].[TBL_GLUE_PURCHASE_ORDER_MST] PUR_CODE, PUR_DT, PUR_PRD_CD, PUR_QNTY, PUR_PRICE_PC, PUR_TOT_AMT, PUR_APRV_DT, PUR_STS
        if (_cs.ExecuteQuery("insert into TBL_GLUE_PURCHASE_ORDER_MST(PUR_DT,PUR_PRD_CD,PUR_QNTY,PUR_PRICE_PC,PUR_TOT_AMT) values('" + utl.Date + "','" + utl.Product_Code + "','" + utl.Product_Qnty + "','" + utl.Product_Price + "','" + utl.Amount + "')") == 1)
        {
            re = "Success";
        }
        else
        {
            re = "Error";
        }
        return re;
    }
    public string _Update_Stock_Approve(_Utility utl)
    {
        string re = "";
        //[dbo].[TBL_GLUE_PURCHASE_ORDER_MST] PUR_CODE, PUR_DT, PUR_PRD_CD, PUR_QNTY, PUR_PRICE_PC, PUR_TOT_AMT, PUR_APRV_DT, PUR_STS
        if (_cs.ExecuteQuery("update TBL_GLUE_PURCHASE_ORDER_MST set PUR_APRV_DT='" + utl.Date + "',PUR_STS='" + utl.Status + "' where PUR_CODE='" + utl.Product_Code + "'") == 1)
        {
            re = "Success";
        }
        else
        {
            re = "Error";
        }
        return re;
    }

    public DataSet _DashBoard()
    {
        return _cs._Get_Dataset("USP_DASHBOARD");
    }
    public DataSet _DashBoard_Supplier()
    {
        return _cs._Get_Dataset("USP_SUPPLIER_INF");
    }
    public string _Insert_Expenses(_Utility utl)
    {
        string re = "";
        if (_cs.ExecuteQuery("insert into TBL_GLUE_EXPENSES_MST(EXP_DT,EXP_VEN_CODE,EXP_PURPOSE,EXP_AMOUNT) values('" + utl.Date + "','" + utl.Emp_Cust_Code + "','" + utl.Purpose + "','" + utl.Amount + "')") == 1)
        {
            re = "Success";
        }
        else
        {
            re = "Error";
        }
        return re;
    }
    public DataSet Get_Expenses(string cond)
    {
        return _cs._Get_Dataset("select * from VW_TBL_GLUE_EXPENSES_MST " + cond + " order by EXP_CODE desc");
    }
    public DataSet Get_Expenses(string field, string cond)
    {
        return _cs._Get_Dataset("select " + field + " from VW_TBL_GLUE_EXPENSES_MST " + cond);
    }
    public DataSet Get_Expenses_Mst(string cond)
    {
        return _cs._Get_Dataset("select EXP_VEN_CODE,ECM_NAME,SUM(EXP_AMOUNT) TOTAL_AMOUNT from VW_TBL_GLUE_EXPENSES_MST " + cond + " group by exp_ven_code,ECM_NAME");
    }


    public DataSet Get_Payment_Report(string cond)
    {
        return _cs._Get_Dataset("select * from VW_TBL_GLUE_VENDOR_PAYMENT_INF " + cond);
    }

    public DataSet Get_Payment_Report(string field, string cond)
    {
        return _cs._Get_Dataset("select " + field + " from VW_TBL_GLUE_VENDOR_PAYMENT_INF " + cond);
    }


    public string _Insert_CapitalAmount(_Utility utl)
    {
        string re = "";
        if (_cs.ExecuteQuery("insert into TBL_CAPITAL_INVESTMENT_MST(CAP_DT,CAP_VEN_CD,CAP_DESC,CAP_AMOUNT) values('" + utl.Date + "','" + utl.Emp_Cust_Code + "','" + utl.Purpose + "','" + utl.Amount + "')") == 1)
        {
            re = "Success";
        }
        else
        {
            re = "Error";
        }
        return re;
    }
    public DataSet Get_Capital_Amount(string cond)
    {
        return _cs._Get_Dataset("select * from VW_TBL_CAPITAL_INVESTMENT_MST " + cond);
    }

    public DataSet Get_Manager_Data(string mgrId)
    {
        return _cs._Get_Dataset("USP_MANAGER_DASHBOARD '" + mgrId + "'");
    }



    public string _Logout(login_bal utl)
    {
        string re = "";
        re = _cs.ExecuteCmd_WithOutput(_cs.ReturnCommand("USP_USER_LOGOUT", "@ID^@DESC", utl.EMPID + "^" + utl.Desc, '^'), "@OUT");
        if (re == "1")
        {
            re = "Success";
        }
        else
        {
            re = "Error";
        }
        return re;
    }
}
