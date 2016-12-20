using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class USER_VendorReport : System.Web.UI.Page
{
    _Utility _utl = new _Utility();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Cd"] != null)
            {
                Bind("where SAL_VENDOR_CD='" + Request.QueryString["Cd"].ToString() + "'");
                BindDetails(Request.QueryString["Cd"].ToString());
                Bind_Btl(Request.QueryString["Cd"].ToString());

                Bind1("where PAY_VEN_CD='" + Request.QueryString["Cd"].ToString() + "'");
            }
        }
    }
    void BindDetails(string vid)
    {
        DataSet ds = _utl.Get_Employee_Customer_Data_Individual(vid);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                divName.InnerHtml = ds.Tables[0].Rows[0]["ECM_NAME"].ToString();
                sp_totalSale.InnerHtml = "Rs. " + ds.Tables[0].Rows[0]["SALE"].ToString() + "<small>  Qnty : " + ds.Tables[0].Rows[0]["SALE_QNTY"].ToString() + "</small>";
                sp_totalPay.InnerHtml = "Rs. " + ds.Tables[0].Rows[0]["PAID"].ToString();
                sp_total.InnerHtml = "Rs. " + ds.Tables[0].Rows[0]["BALANCE_AMT"].ToString();
            }
        }
    }
    void Bind(string cond)
    {
        DataSet ds = _utl.Get_Sale_Report(cond + " order by SAL_CODE desc");
        string res = "";
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    res += "<tr><td>" + (x + 1).ToString() + "</td> <td>" + Convert.ToDateTime(ds.Tables[0].Rows[x]["SAL_DT"].ToString()).ToString("dd-MMM-yyyy") + "</td><td>" + ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["SAL_QNTY"].ToString() + "pcs (" + ds.Tables[0].Rows[x]["SAL_BOX"].ToString() + " Box)</td><td>" + ds.Tables[0].Rows[x]["SAL_PRICE_PC"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["SAL_TOT_AMT"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["SAL_REMARKS"].ToString() + "</td></tr>";
                }
            }
        }
        tblSaleReport.InnerHtml = res;
    }
    void Bind_Btl(string cond)
    {
        DataSet ds = _utl.Get_Sale_Report1(cond);
        string res = "";
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    res += ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "-" + ds.Tables[0].Rows[x]["QNTY"].ToString() + " Pcs. (" + ds.Tables[0].Rows[x]["BOX"].ToString() + " Box)<br>";
                }
            }
        }
        sp_totalSale.InnerHtml += "<br><small>" + res + "</small";
    }
    string lastPayment = "";
    void Bind1(string cond)
    {
        DataSet ds = _utl.Get_Payment_Report(cond + " order by PAY_CODE desc");
        string ress = "";
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    ress += "<tr><td>" + (x + 1).ToString() + "</td> <td>" + Convert.ToDateTime(ds.Tables[0].Rows[x]["PAY_DT"].ToString()).ToString("dd-MMM-yyyy") + "</td><td>" + ds.Tables[0].Rows[x]["PAY_AMOUNT"].ToString() + "</td></tr>";
                }
                lastPayment = "Last Paid :" + Convert.ToDateTime(ds.Tables[0].Rows[0]["PAY_DT"].ToString()).ToString("dd-MMM-yyyy") + " Rs." + ds.Tables[0].Rows[0]["PAY_AMOUNT"].ToString();
            }
        }

        tblPaymentReport.InnerHtml = ress;

        sp_totalPay.InnerHtml += "<br><small>" + lastPayment + "</small>";
    }
}