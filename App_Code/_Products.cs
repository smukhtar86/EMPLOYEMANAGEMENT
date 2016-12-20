using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for Class1
/// </summary>
public class _Products
{
    public _Products()
    {
        //
        // TODO: Add constructor logic here
        //

    }
    Common_Class _cs = new Common_Class();
    public string WebName()
    {
        return ConfigurationManager.AppSettings["WebName"].ToString();
    }
    public string _ProductPage(string cat_cd,string thePage)
    {
        string desc = "";
        DataSet ds = null;
        if (ConfigurationManager.AppSettings["UserType"].ToString() == "All")
        {
            if (cat_cd != "")
            {
                //ds = _cs._Get_Dataset("select top 9 ROW_NUMBER() OVER (ORDER BY PRD_CODE DESC) AS Row,* from VW_TBL_PRODUCT_MST  WHERE PRD_CAT_CD='" + cat_cd + "' order by PRD_CODE DESC");
                ds = _cs._Get_Dataset("select * from (select ROW_NUMBER() OVER (ORDER BY PRD_CODE DESC) AS Rowss,* from (select * from VW_TBL_PRODUCT_MST where PRD_CAT_CD='" + cat_cd + "') x) c");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    desc = "<div style='padding-left:15px;'><b>" + ds.Tables[0].Rows[0]["CAT_NAME"].ToString() + "</b> : " + ds.Tables[0].Rows[0]["CAT_DESC"].ToString() + "</div>";
                }
                else
                {
                    DataSet dss = _cs._Get_Dataset("select * from VW_TBL_CATEGORY_MST WHERE CAT_CODE='" + cat_cd + "' AND CAT_STS='Y'");
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        desc = "<div style='padding-left:15px;'><b>" + dss.Tables[0].Rows[0]["CAT_NAME"].ToString() + "</b> : No Product(s) Found..</div>";
                    }
                }
            }
            else
            {
                ds = _cs._Get_Dataset("select * from VW_TBL_PRODUCT_MST order by PRD_NAME");
            }
        }
        else
        {
            if (cat_cd != "")
            {
                //ds = _cs._Get_Dataset("select top 9 ROW_NUMBER() OVER (ORDER BY PRD_CODE DESC) AS Row,* from VW_TBL_PRODUCT_MST where CAT_CMP_ID='" + ConfigurationManager.AppSettings["UserType"].ToString() + "' and  PRD_CAT_CD='" + cat_cd + "' order by PRD_CODE DESC");
                ds = _cs._Get_Dataset("select * from (select ROW_NUMBER() OVER (ORDER BY PRD_CODE DESC) AS Rowss,* from (select * from VW_TBL_PRODUCT_MST where CAT_CMP_ID='" + ConfigurationManager.AppSettings["UserType"].ToString() + "' and PRD_CAT_CD='" + cat_cd + "') x) c");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    desc = "<div style='padding-left:15px;'><b>" + ds.Tables[0].Rows[0]["CAT_NAME"].ToString() + "</b> : " + ds.Tables[0].Rows[0]["CAT_DESC"].ToString() + "</div>";
                }
                else
                {
                    DataSet dss = _cs._Get_Dataset("select * from VW_TBL_CATEGORY_MST WHERE CAT_CODE='" + cat_cd + "' AND  CAT_STS='Y'");
                  if (dss.Tables[0].Rows.Count > 0)
                  {
                      desc = "<div style='padding-left:15px;'><b>" + dss.Tables[0].Rows[0]["CAT_NAME"].ToString() + "</b> : No Product(s) Found..</div>";

                  }
                }
            }
            else
            {
                ds = _cs._Get_Dataset("select ROW_NUMBER() OVER (ORDER BY PRD_CODE DESC) AS Row,* from VW_TBL_PRODUCT_MST where CAT_CMP_ID='" + ConfigurationManager.AppSettings["UserType"].ToString() + "' order by PRD_CODE DESC");
            }
        }
        string xx = "";
        string s = "";
        string ss = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            {
                if (ds.Tables[0].Rows[x]["PRD_PAYMENT_MODE"].ToString() == "ONQUERY")
                {
                    s = "<br>Request a Quote.";
                }
                else
                {
                    //s = ds.Tables[0].Rows[x]["CMP_CURRENCY_SYMBOL"].ToString() + ". " + ds.Tables[0].Rows[0]["PRD_AMT"].ToString();
                }
                if (ds.Tables[0].Rows[x]["PRD_STS"].ToString() == "N")
                {
                    s = "<br>OUT OF STOCK";
                }
                if (HttpContext.Current.Session["TYP"] != null)
                {
                    if (HttpContext.Current.Session["TYP"].ToString() == "ADMIN")
                    {
                        ss = "<a href='" + ConfigurationManager.AppSettings["WebName"].ToString() + "Admin/frm_New_Product.aspx?ID=" + ds.Tables[0].Rows[x]["PRD_CODE"].ToString() + "' target='_balnk'><img src='" + WebName() + "images/edit.png' style='width:25px;height:25px;'></a>" + "<a  onclick=showMessage('"+ ds.Tables[0].Rows[x]["PRD_CODE"].ToString() + "')><img src='" + WebName() + "images/plus.png' style='width:25px;height:25px;'></a>";
                       // s = "";
                    }
                }
                xx += "<div class='grid_4'>" +
                            "<div class='banner'>" +
                            " <a class='fancybox pr dib' data-fancybox-group='addZoomIcon-showZoomImage' href='" + WebName() + "IMAGE/PRODUCT/" + ds.Tables[0].Rows[x]["CAT_IMG_DIR"].ToString() + "/" + ds.Tables[0].Rows[x]["PRD_IMG"].ToString() + "' title='" + ds.Tables[0].Rows[0]["CAT_NAME"].ToString() + " - " + ds.Tables[0].Rows[x]["PRD_NAME"].ToString()+ "'>" +
                                "<img style='width:300px;height:425px' data-src='" + WebName() + "IMAGE/PRODUCT/" + ds.Tables[0].Rows[x]["CAT_IMG_DIR"].ToString() + "/" + ds.Tables[0].Rows[x]["PRD_IMG"].ToString() + "' src='" + WebName() + "images/default.gif' alt=''></a>" +
                                "<div class='label'>" +
                                //  "<img style='width:300px;height:425px' src='" + WebName() + "IMAGE/PRODUCT/" + ds.Tables[0].Rows[x]["CAT_IMG_DIR"].ToString() + "/" + ds.Tables[0].Rows[x]["PRD_IMG"].ToString() + "' alt=''></a>" +
                                //"<div class='label'>" +
                                    "<div class='price'>" + ss + "</div>" +
                                    "<a href='ProductDetails.aspx?PRID=" + ds.Tables[0].Rows[x]["PRD_CODE"].ToString() + "'><b>" + ds.Tables[0].Rows[x]["PRD_NAME"].ToString() +"</b>"+s+"</a>" +
                                "</div>" +
                                 "   <div style='display:none;'>";
                if (ds.Tables[0].Rows[x]["PRD_IMG_CODE"].ToString() != "")
                {
                    DataSet DSS = _cs._Get_Dataset("SELECT * FROM TBL_PRODUCT_IMAGE_INF WHERE PRIMG_PRD_CD='" + ds.Tables[0].Rows[x]["PRD_IMG_CODE"].ToString() + "'");

                    for (int c = 0; c < DSS.Tables[0].Rows.Count; c++)
                    {
                        xx += " <a class='fancybox pr dib' data-fancybox-group='addZoomIcon-showZoomImage' href='" + WebName() + "IMAGE/PRODUCT/" + ds.Tables[0].Rows[x]["CAT_IMG_DIR"].ToString() + "/" + DSS.Tables[0].Rows[c]["PRIIMG_IMG"].ToString() + "' title='" + ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "'></a>";
                    }
                }

                xx += "</div>" +
                            "</div>" +
                        "</div>";
            }
        }
        if(cat_cd!="")
        {
            return desc + "<br>" + xx + "|9";
        }
        else
        {
            return desc + "<br>" + xx;
        }        
    }
    public string _ProductPage_OnScroll(string Value, string cat_cd, string id)
    {
        string desc = "";
        DataSet ds = null;
        int total = Convert.ToInt32(Value) + 9;
        if (cat_cd != "All")
        {
            ds = _cs._Get_Dataset("select * from (select ROW_NUMBER() OVER (ORDER BY PRD_CODE DESC) AS Rowss,* from (select * from VW_TBL_PRODUCT_MST where PRD_CAT_CD='" + cat_cd + "') x) c where Rowss between " + Convert.ToString(Convert.ToInt32(Value) + 1) + " and " + Convert.ToString(total));
            //select * from (select ROW_NUMBER() OVER (ORDER BY PRD_CODE DESC) AS Rowss,* from (select * from VW_TBL_PRODUCT_MST where PRD_CAT_CD='8') x) c  
        }
        string xx = "";
        string s = "";
        string ss = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            {
                if (ds.Tables[0].Rows[x]["PRD_PAYMENT_MODE"].ToString() == "ONQUERY")
                {
                    ss = "<br>Request a Quote.";
                }
                else
                {
                   // s = ds.Tables[0].Rows[x]["CMP_CURRENCY_SYMBOL"].ToString() + ". " + ds.Tables[0].Rows[0]["PRD_AMT"].ToString();
                }
                if (ds.Tables[0].Rows[x]["PRD_STS"].ToString() == "N")
                {
                    ss = "<br>OUT OF STOCK";
                }
                if (id != "")
                {
                    s = "<a href='" + ConfigurationManager.AppSettings["WebName"].ToString() + "Admin/frm_New_Product.aspx?ID=" + ds.Tables[0].Rows[x]["PRD_CODE"].ToString() + "' target='_balnk'><img src='" + WebName() + "images/edit.png' style='width:25px;height:25px;'></a>";
                    ss = "";
                }
                xx += "<div class='grid_4'>" +
                            "<div class='banner'>" +
                            " <a class='fancybox pr dib' data-fancybox-group='addZoomIcon-showZoomImage' href='" + WebName() + "IMAGE/PRODUCT/" + ds.Tables[0].Rows[x]["CAT_IMG_DIR"].ToString() + "/" + ds.Tables[0].Rows[x]["PRD_IMG"].ToString() + "' title='" + ds.Tables[0].Rows[0]["CAT_NAME"].ToString() + " - " + ds.Tables[0].Rows[x]["PRD_NAME"].ToString()+ "'>" +
                                "<img style='width:300px;height:425px' src='" + WebName() + "IMAGE/PRODUCT/" + ds.Tables[0].Rows[x]["CAT_IMG_DIR"].ToString() + "/" + ds.Tables[0].Rows[x]["PRD_IMG"].ToString() + "' alt=''></a>" +
                                "<div class='label'>" +
                                    "<div class='price'>" + s + "</div>" +
                                    "<a href='ProductDetails.aspx?PRID=" + ds.Tables[0].Rows[x]["PRD_CODE"].ToString() + "'><b>" + ds.Tables[0].Rows[x]["PRD_NAME"].ToString() +"</b>"+ss+"</a>" +
                                "</div>" +
                                 "   <div style='display:none;'>";
                if (ds.Tables[0].Rows[x]["PRD_IMG_CODE"].ToString() != "")
                {
                    DataSet DSS = _cs._Get_Dataset("SELECT * FROM TBL_PRODUCT_IMAGE_INF WHERE PRIMG_PRD_CD='" + ds.Tables[0].Rows[x]["PRD_IMG_CODE"].ToString() + "'");

                    for (int c = 0; c < DSS.Tables[0].Rows.Count; c++)
                    {
                        xx += " <a class='fancybox pr dib' data-fancybox-group='addZoomIcon-showZoomImage' href='" + WebName() + "IMAGE/PRODUCT/" + ds.Tables[0].Rows[x]["CAT_IMG_DIR"].ToString() + "/" + DSS.Tables[0].Rows[c]["PRIIMG_IMG"].ToString() + "' title='" + ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "'></a>";
                    }
                }

                xx += "</div>" +
                            "</div>" +
                        "</div>";
            }
        }
        return desc + "<br>" + xx + "|" + total.ToString();
    }
   
  

    public string _CopyRights()
    {
        string sts = "<a href='" + ConfigurationManager.AppSettings["WebName"].ToString() + "Login/Login.aspx' target='_blank' rel='nofollow'>Control Panel</a>";
        if (HttpContext.Current.Session["ID"] != null)
        {
            sts = "<a href='" + ConfigurationManager.AppSettings["WebName"].ToString() + "Admin/Dashboard.aspx' target='_blank' rel='nofollow'>" + HttpContext.Current.Session["NAME"].ToString() + " - Control Panel</a> | <a href='" + ConfigurationManager.AppSettings["WebName"].ToString() + "Admin/Logout.aspx' target='_blank' rel='nofollow'>Logout</a>";
        }
        DataSet ds = _cs._Get_Dataset("USP_FOOTER_MENU");
        string x = ds.Tables[0].Rows[0]["Res"].ToString();
        //for (int xx = 0; xx < ds.Tables[0].Rows.Count; xx++)
        //{
        //    x += "<a href='Products.aspx?CAT=" + ds.Tables[0].Rows[xx]["CAT_CODE"].ToString() + "&NAME=" + ds.Tables[0].Rows[xx]["CAT_NAME"].ToString() + "'>" + ds.Tables[0].Rows[xx]["CAT_NAME"].ToString() + " (" + ds.Tables[0].Rows[xx]["TOTAL_PRD"].ToString() + ")</a> | ";
        //}
        return "&copy;" + DateTime.Now.Year.ToString() + " | <a href='#'>Privacy Policy</a> | Designed by <a href='http://www.ssmaktak.com/' target='_blank' rel='nofollow'>SMAK Solutions</a><br><br><b>Products : </b>" + x + "<br><br>Nature of Business : Manufacturer, Exporter & Supplier<br>Market Covered : Worldwide<br>Contact Us : +91-8266886013<br><br>" + sts + " | <a href='https://asia.login.secureserver.net/index.php?app=wbe&domain=stateofart.biz'>EMAIL Login</a>";
    }

    public string _SocialMediaFooter()
    {
        return "<a href='https://www.facebook.com/stateofartindia' class='fa fa-facebook' target='_blank'></a>" +
                        "<a href='https://twitter.com/stateofartindia' class='fa fa-twitter' target='_blank'></a>" +
                        "<a href='https://plus.google.com/u/1/b/118226887054096985532/118226887054096985532/posts' target='_blank' class='fa fa-google-plus'></a>";
    }
 
    public string _ProductSearch(string cat_cd)
    {
       
        string desc = "";
        DataSet ds = null;
        try
        {
            if (ConfigurationManager.AppSettings["UserType"].ToString() == "All")
            {
                if (cat_cd != "")
                {
                    ds = _cs._Get_Dataset("select * from VW_TBL_PRODUCT_MST  WHERE CAT_NAME like '%" + cat_cd + "%' or PRD_NAME like '%" + cat_cd + "%' order by PRD_NAME");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        desc = "<div style='padding-left:15px;'><b>" + ds.Tables[0].Rows.Count.ToString() + "</b> Product(s) Found..</div>";
                    }
                    else
                    {
                        DataSet dss = _cs._Get_Dataset("select * from VW_TBL_PRODUCT_MST  WHERE CAT_NAME like '%" + cat_cd + "%' or PRD_NAME like '%" + cat_cd + "%'");
                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            desc = "<div style='padding-left:15px;'><b>" + ds.Tables[0].Rows.Count.ToString() + "</b> Product(s) Found..</div>";
                        }
                        else
                        {
                            desc = "<div style='padding-left:15px;'>No Product(s) Found..</div>";
                        }
                    }
                }
                else
                {
                    ds = _cs._Get_Dataset("select * from VW_TBL_PRODUCT_MST order by PRD_NAME");
                }
            }
            else
            {
                if (cat_cd != "")
                {
                    ds = _cs._Get_Dataset("select * from (select * from VW_TBL_PRODUCT_MST where CAT_NAME like '%" + cat_cd + "%' or PRD_NAME like '%" + cat_cd + "%') x where CAT_CMP_ID='" + ConfigurationManager.AppSettings["UserType"].ToString() + "' order by PRD_NAME");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        desc = "<div style='padding-left:15px;'><b>" + ds.Tables[0].Rows.Count.ToString() + "</b> Product(s) Found..</div>";
                    }
                    else
                    {
                        DataSet dss = _cs._Get_Dataset("select * from (select * from VW_TBL_PRODUCT_MST where CAT_NAME like '%" + cat_cd + "%' or PRD_NAME like '%" + cat_cd + "%') x where CAT_CMP_ID='" + ConfigurationManager.AppSettings["UserType"].ToString() + "'");
                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            desc = "<div style='padding-left:15px;'><b>" + ds.Tables[0].Rows.Count.ToString() + "</b> Product(s) Found..</div>";
                        }
                        else
                        {
                            desc = "<div style='padding-left:15px;'>No Product(s) Found..</div>";
                        }
                    }
                }
                else
                {
                    ds = _cs._Get_Dataset("select * from VW_TBL_PRODUCT_MST where CAT_CMP_ID='" + ConfigurationManager.AppSettings["UserType"].ToString() + "' order by PRD_NAME");
                }
            }
            string xx = "";
            string s = "";
            string ss = "";
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {

                    if (ds.Tables[0].Rows[x]["PRD_PAYMENT_MODE"].ToString() == "ONQUERY")
                    {
                        ss = "<br>Request a Quote.";
                    }
                    else
                    {
                        // s = ds.Tables[0].Rows[x]["CMP_CURRENCY_SYMBOL"].ToString() + ". " + ds.Tables[0].Rows[0]["PRD_AMT"].ToString();
                    }
                    if (ds.Tables[0].Rows[x]["PRD_STS"].ToString() == "N")
                    {
                        ss = "<br>OUT OF STOCK";
                    }
                    if (HttpContext.Current.Session["TYP"] != null)
                    {
                        if (HttpContext.Current.Session["TYP"].ToString() == "ADMIN")
                        {
                            s = "<a href='" + ConfigurationManager.AppSettings["WebName"].ToString() + "Admin/frm_New_Product.aspx?ID=" + ds.Tables[0].Rows[x]["PRD_CODE"].ToString() + "' target='_balnk'><img src='" + WebName() + "images/edit.png' style='width:25px;height:25px;'></a>";
                            ss = "";
                        }
                    }
                    xx += "<div class='grid_4'>" +
                                "<div class='banner'>" +
                                " <a class='fancybox pr dib' data-fancybox-group='addZoomIcon-showZoomImage' href='" + WebName() + "IMAGE/PRODUCT/" + ds.Tables[0].Rows[x]["CAT_IMG_DIR"].ToString() + "/" + ds.Tables[0].Rows[x]["PRD_IMG"].ToString() + "' title='" + ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "'>" +
                                    "<img style='width:300px;height:425px' src='" + WebName() + "IMAGE/PRODUCT/" + ds.Tables[0].Rows[x]["CAT_IMG_DIR"].ToString() + "/" + ds.Tables[0].Rows[x]["PRD_IMG"].ToString() + "' alt=''></a>" +
                                    "<div class='label'>" +
                                        "<div class='price'>" + s + "</div>" +
                                        "<a href='ProductDetails.aspx?PRID=" + ds.Tables[0].Rows[x]["PRD_CODE"].ToString() + "'><b>" + ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "</b>" + ss + "</a>" +
                                    "</div>" +
                                     "   <div style='display:none;'>";
                    if (ds.Tables[0].Rows[x]["PRD_IMG_CODE"].ToString() != "")
                    {
                        DataSet DSS = _cs._Get_Dataset("SELECT * FROM TBL_PRODUCT_IMAGE_INF WHERE PRIMG_PRD_CD='" + ds.Tables[0].Rows[x]["PRD_IMG_CODE"].ToString() + "'");

                        for (int c = 0; c < DSS.Tables[0].Rows.Count; c++)
                        {
                            xx += " <a class='fancybox pr dib' data-fancybox-group='addZoomIcon-showZoomImage' href='" + WebName() + "IMAGE/PRODUCT/" + ds.Tables[0].Rows[x]["CAT_IMG_DIR"].ToString() + "/" + DSS.Tables[0].Rows[c]["PRIIMG_IMG"].ToString() + "' title='" + ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "'></a>";
                        }
                    }
                    xx += "</div>" +
                                "</div>" +
                            "</div>";
                }
            }
            return desc + "<br>" + xx;
        }
        catch (Exception ee)
        {
            return "<div style='padding-left:15px;'>No Product(s) Found..</div>";
        }
    }
}