using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Summary description for SessionManagement
/// </summary>
public class SessionManagement
{
    public SessionManagement()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void _CheckSession()
    {
        HttpCookie pwdCookie = new HttpCookie("pwdProtechziCookie");
        pwdCookie = HttpContext.Current.Request.Cookies["pwdProtechziCookie"];
        if (pwdCookie != null)
        {
            HttpContext.Current.Session["CODE"] = pwdCookie.Values["CODE"].ToString();
            HttpContext.Current.Session["ID"] = pwdCookie.Values["ID"].ToString();
            HttpContext.Current.Session["TYP"] = pwdCookie.Values["TYP"].ToString();
            HttpContext.Current.Session["NAME"] = pwdCookie.Values["NAME"].ToString();
            HttpContext.Current.Session["IMG"] = pwdCookie.Values["IMG"].ToString();
        }
        else
        {
            HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["WebName"].ToString() + "/Login/Default.aspx", false);
        }
    }
}