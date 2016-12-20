using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class USER_Payments : System.Web.UI.Page
{
    _Utility _utl = new _Utility();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //tblData.InnerHtml = new _UserProfile()._Payment_History();
            if (Request.QueryString["Typ"] != null)
            {
                if (Request.QueryString["Cd"] != null)
                {
                    if (Request.QueryString["Typ"].ToString() == "Ven")
                    {
                        Bind("where pay_VEN_CD='" + Request.QueryString["Cd"].ToString() + "'");
                    }
                   
                }
            }
            else
            {
                Bind("");
            }
        }
    }

    void Bind(string cond)
    {
        DataSet ds = _utl.Get_Payment_Report(cond + " order by PAY_CODE desc");
        string ress = ""; double total = 0;
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    ress += "<tr><td>" + (x + 1).ToString() + "</td> <td>" + Convert.ToDateTime(ds.Tables[0].Rows[x]["PAY_DT"].ToString()).ToString("dd-MMM-yyyy") + "</td><td><a href='VendorReport.aspx?Cd=" + ds.Tables[0].Rows[x]["PAY_VEN_CD"].ToString() + "'>" + ds.Tables[0].Rows[x]["ECM_NAME"].ToString() + "</a></td><td>" + ds.Tables[0].Rows[x]["PAY_AMOUNT"].ToString() + "</td></tr>";
                    total += Convert.ToDouble(ds.Tables[0].Rows[x]["PAY_AMOUNT"].ToString());
                }
            }
        }
        sp_COLLECTION_AMT.InnerHtml = "Rs. " + total.ToString();
        tblData.InnerHtml = ress;
    }
}