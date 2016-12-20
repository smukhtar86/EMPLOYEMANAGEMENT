using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMPLOYEE_WorkSummery : System.Web.UI.Page
{
    Common_Class cs = new Common_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        new SessionManagement()._CheckSession();

        if (!IsPostBack)
        { }
    }
    void BInd()
    {
        string s = "";
        DataSet ds = cs._Get_Dataset("USP_ATTENDANCE_MST 'USER_DT','" + Session["ID"].ToString());
        for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
        {
            s += "<tr>" +
                "<td>" + (x + 1).ToString() + "</td>" +
                "<td>" + ds.Tables[0].Rows[x]["LOG_DT"].ToString() + "</td>" +
                "<td>" + ds.Tables[0].Rows[x]["duratin"].ToString() + "</td>" +
                "<td><span class='label label-warning'><a href='WorkSummeryDetails.aspx'>View Details</a></span></td>" +
                "</tr>";
        }
    }
}