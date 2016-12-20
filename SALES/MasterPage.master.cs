using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ADMIN_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CODE"] == null)
        {
            HttpCookie pwdCookie = new HttpCookie("pwdCookie");
            pwdCookie = Request.Cookies["pwdCookie"];
            if (pwdCookie != null)
            {
                Session["CODE"] = pwdCookie.Values["CODE"].ToString();
                Session["ID"] = pwdCookie.Values["ID"].ToString();
                Session["TYP"] = pwdCookie.Values["TYP"].ToString();
                Session["NAME"] = pwdCookie.Values["NAME"].ToString();
                Session["IMG"] = pwdCookie.Values["IMG"].ToString();

                Bind();
            }
            else
            {
                Response.Redirect("../Login/Login.aspx", false);
            }
        }
        else
        {            
            Bind();
        }
    }

    void Bind()
    {
        DataSet ds = new _Utility().Get_Employee_Customer_Data("5");
        if(ds.Tables.Count>0)
        {
            if(ds.Tables[0].Rows.Count>0)
            {
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    ul_Ledger.InnerHtml += "<li><a href='VendorReport.aspx?Cd=" + ds.Tables[0].Rows[x]["ECM_CODE"].ToString() + "'><i class='fa fa-user'></i>" + ds.Tables[0].Rows[x]["ECM_NAME"].ToString() + "</a></li>";
                }
                lbl_notification.Text = ds.Tables[0].Rows.Count.ToString();
                lbl_notification1.Text = ds.Tables[0].Rows.Count.ToString();
                ul_UserDetails.InnerHtml = ul_Ledger.InnerHtml;
            }
        }
        
        lbl_user_name.Text = Session["NAME"].ToString();
        lbl_user_name1.Text = Session["NAME"].ToString();
        lbl_UserName2.Text = Session["NAME"].ToString();
    }
}
