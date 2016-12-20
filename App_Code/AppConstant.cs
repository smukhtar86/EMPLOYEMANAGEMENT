using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AppConstant
/// </summary>
public class AppConstant
{
    public static string WebName = System.Configuration.ConfigurationManager.AppSettings["WebName"].ToString();
    public AppConstant()
    {
        
        //
        // TODO: Add constructor logic here
        //
    }

    public class URLConstant
    {
        public class VENDOR
        {
            public static string VENDOR_REPORT = WebName + "VENDOR/Vendor_rpt.aspx";
        }

        public class LOGIN
        {
            public static string VENDOR_LOGIN = WebName + "LOGIN/Vendor.aspx";
            public static string ADMIN_LOGIN = WebName + "LOGIN/Admin.aspx";
            public static string DISTRIBUTOR_LOGIN = WebName + "LOGIN/Distributor.aspx";

        }

    }


}
