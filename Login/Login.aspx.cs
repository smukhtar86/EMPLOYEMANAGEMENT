using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
public partial class Login_Login : System.Web.UI.Page
{
    login_bal objReg = new login_bal();
    DataSet ds = new DataSet();
    Admin objAdmin = new Admin();
    Common_Class _cs = new Common_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CODE"] == null)
            {
                //Response.Redirect("~/ADMIN/Dashboard.aspx", false);
                HttpCookie pwdCookie = new HttpCookie("pwdProtechziCookie");
                pwdCookie = Request.Cookies["pwdProtechziCookie"];
                if (pwdCookie != null)
                {
                    Session["CODE"] = pwdCookie.Values["CODE"].ToString();
                    Session["ID"] = pwdCookie.Values["ID"].ToString();
                    Session["TYP"] = pwdCookie.Values["TYP"].ToString();
                    Session["NAME"] = pwdCookie.Values["NAME"].ToString();
                    Session["IMG"] = pwdCookie.Values["IMG"].ToString();
                    if (pwdCookie.Values["TYP"].ToString() == "1")
                    {
                        Response.Redirect("~/ADMIN/Dashboard.aspx", false);
                    }
                    else if (pwdCookie.Values["TYP"].ToString() == "9")
                    {
                        Response.Redirect("~/EMPLOYEE/Default.aspx", false);
                    }
                }
            }
            else
            {
                //Response.Redirect("~/ADMIN/Dashboard.aspx", false);
                HttpCookie pwdCookie = new HttpCookie("pwdProtechziCookie");
                pwdCookie = Request.Cookies["pwdProtechziCookie"];
                if (pwdCookie != null)
                {
                    Session["CODE"] = pwdCookie.Values["CODE"].ToString();
                    Session["ID"] = pwdCookie.Values["ID"].ToString();
                    Session["TYP"] = pwdCookie.Values["TYP"].ToString();
                    Session["NAME"] = pwdCookie.Values["NAME"].ToString();
                    Session["IMG"] = pwdCookie.Values["IMG"].ToString();
                    if (pwdCookie.Values["TYP"].ToString() == "1")
                    {
                        Response.Redirect("~/ADMIN/Dashboard.aspx", false);
                    }
                    else if (pwdCookie.Values["TYP"].ToString() == "9")
                    {
                        Response.Redirect("~/SALES/Default.aspx", false);
                    }
                }
            }
            BindCategory();
        }
    }
    void BindCategory()
    {
        DataSet ds = _cs._Get_Dataset("select * from TBL_ENM_DESIGNATION WHERE ECAT_STS='Y'");
        _cs.BindDropDownList1(ddlType, ds.Tables[0], "ECAT_CODE", "ECAT_NAME", "Login As..");
        ddlType.SelectedValue = "9";
    }
    protected void Btn_submit_Click(object sender, EventArgs e)
    {

        try
        {
            objReg.UserName = Txt_id.Text;
            objReg.PASSWORD = ENC_DEC.Encode_Decode.EncodeTo64(Txt_pwd.Text).ToString();
            objReg.TYPE = ddlType.SelectedValue.ToString();
            DataSet ds = objReg.VerifyLogin(objReg);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ddlType.SelectedValue == "1")
                {
                    Session["CODE"] = ds.Tables[0].Rows[0]["ECM_CODE"].ToString();
                    Session["ID"] = ds.Tables[0].Rows[0]["ECM_CODE"].ToString();
                    Session["TYP"] = ddlType.SelectedValue.ToString();//ds.Tables[0].Rows[0]["CMP_TYP"].ToString();
                    Session["NAME"] = ds.Tables[0].Rows[0]["ECM_NAME"].ToString();
                    Session["IMG"] = ds.Tables[0].Rows[0]["ECM_PHOTO"].ToString();
                }
                else
                {
                    Session["CODE"] = ds.Tables[0].Rows[0]["ECM_CODE"].ToString();
                    Session["ID"] = ds.Tables[0].Rows[0]["ECM_CODE"].ToString();
                    Session["TYP"] = ddlType.SelectedValue.ToString();//ds.Tables[0].Rows[0]["CMP_TYP"].ToString();
                    Session["NAME"] = ds.Tables[0].Rows[0]["ECM_NAME"].ToString();
                    Session["IMG"] = ds.Tables[0].Rows[0]["ECM_PHOTO"].ToString();
                }
                if (1 == 1)
                {
                    HttpCookie pwdCookie = new HttpCookie("pwdProtechziCookie");

                    pwdCookie.Values.Add("CODE", Session["CODE"].ToString());
                    pwdCookie.Values.Add("ID", Session["ID"].ToString());
                    pwdCookie.Values.Add("TYP", Session["TYP"].ToString());
                    pwdCookie.Values.Add("NAME", Session["NAME"].ToString());
                    pwdCookie.Values.Add("IMG", Session["IMG"].ToString());


                    pwdCookie.Expires = DateTime.Now.AddYears(50);
                    Response.Cookies.Add(pwdCookie);
                }
                if (ddlType.SelectedValue == "1")
                {
                    Response.Redirect("~/ADMIN/Dashboard.aspx", false);
                }
                else if (ddlType.SelectedValue == "2")
                {
                    Response.Redirect("~/EMPLOYEE/Default.aspx", false);
                }
                else
                {
                    // Response.Redirect("~/Accounts/Dashboard.aspx", false);
                }
            }
        }
        catch (Exception ex)
        {
            Session["CODE"] = null;
            Session["ID"] = null;
            Session["TYP"] = null;
            Session["NAME"] = null;
            Session["IMG"] = null;
        }
    }
}