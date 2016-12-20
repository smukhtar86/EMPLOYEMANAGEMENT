using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class USER_ExpensesReport : System.Web.UI.Page
{
    Common_Class _cs = new Common_Class();
    _Utility _utl = new _Utility();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //tblData.InnerHtml = new _UserProfile()._Payment_History();
            if(Request.QueryString["ID"]!=null)
            {
                Bind("where EXP_VEN_CODE='" + Request.QueryString["ID"].ToString() + "'");
            }
            else
            {
                Bind("");
            }
        }
    }

    void Bind(string cond)
    {
        DataSet ds = _utl.Get_Expenses(cond);
        string res = "";
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                     res += "<tr><td>" + (x + 1).ToString() + "</td> <td>" + Convert.ToDateTime(ds.Tables[0].Rows[x]["EXP_DT"].ToString()).ToString("dd-MMM-yyyy") + "</td><td>" + ds.Tables[0].Rows[x]["ECM_NAME"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["EXP_PURPOSE"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["EXP_AMOUNT"].ToString() + "</td></tr>";
                    //res += "<tr><td>" + (x + 1).ToString() + "</td><td>" + ds.Tables[0].Rows[x]["ECM_NAME"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["TOTAL_AMOUNT"].ToString() + "</td><td><a href=ExpensesDetails.aspx?ID=" + ds.Tables[0].Rows[x]["EXP_VEN_CODE"].ToString() + ">View</a></td></tr>";
                }
            }
        }
        Tbody1.InnerHtml = res;

        DataSet dss = _utl.Get_Expenses_Mst(cond);
        if (dss.Tables.Count > 0)
        {
            double re = 0;
            if (dss.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < dss.Tables[0].Rows.Count; x++)
                {
                    re += Convert.ToDouble(dss.Tables[0].Rows[x]["TOTAL_AMOUNT"].ToString());
                }
                sp_totalSale.InnerHtml = "Rs. " + re.ToString();
            }
        }
        
    }
}