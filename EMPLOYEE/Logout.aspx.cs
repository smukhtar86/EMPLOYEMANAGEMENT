using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMPLOYEE_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        new SessionManagement()._CheckSession();
    }
    _Utility _ut = new _Utility();
    login_bal lg = new login_bal();
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lg.EMPID = Session["ID"].ToString();
        lg.Desc = txtDate.Text;
        if (_ut._Logout(lg) == "Success")
        {
            Session.Abandon();
            HttpCookie pwdCookie = new HttpCookie("pwdProtechziCookie");
            pwdCookie = Request.Cookies["pwdProtechziCookie"];
            pwdCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(pwdCookie);
            Response.Redirect("../Login/Login.aspx");
        }
        //Session.Abandon();
        //HttpCookie pwdCookie = new HttpCookie("pwdProtechziCookie");
        //pwdCookie = Request.Cookies["pwdProtechziCookie"];
        //pwdCookie.Expires = DateTime.Now.AddDays(-1);
        //Response.Cookies.Add(pwdCookie);
        //Response.Redirect("../Login/Login.aspx");
    }
}