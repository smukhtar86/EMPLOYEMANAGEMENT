using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
/// <summary>
/// Summary description for Maintenance
/// </summary>
public class Maintenance
{
   
    public static void IsMaintenance(Page pg)
    {
        string[] x = ConfigurationManager.AppSettings["Maintenance"].ToString().Split('^');
        if (x[0].ToUpper() == "Y")
        {
            pg.Response.Redirect(ConfigurationManager.AppSettings["WebName"].ToString() + x[1].ToString());
        }
    }
}
