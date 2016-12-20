using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SALES_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        HttpCookie pwdCookie = new HttpCookie("pwdProtechziCookie");
        pwdCookie = Request.Cookies["pwdProtechziCookie"];
        pwdCookie.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(pwdCookie);
        Response.Redirect("../Login/Login.aspx");
    }
}