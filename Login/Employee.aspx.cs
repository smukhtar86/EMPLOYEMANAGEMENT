using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Login_Employee : System.Web.UI.Page
{
    login_bal objReg = new login_bal();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CODE"] != null)
            {
                Response.Redirect("~/ADMIN/Dashboard.aspx", false);
            }
            else
            {
                HttpCookie pwdCookie = new HttpCookie("pwdCookie");
                pwdCookie = Request.Cookies["pwdCookie"];
                if (pwdCookie != null)
                {
                    Session["CODE"] = pwdCookie.Values["CODE"].ToString();//  ds.Tables[0].Rows[0]["CODE"].ToString();
                    Session["ID"] = pwdCookie.Values["ID"].ToString();
                    Session["TYP"] = pwdCookie.Values["TYP"].ToString();
                    Session["NAME"] = pwdCookie.Values["NAME"].ToString();
                    Session["IMG"] = pwdCookie.Values["IMG"].ToString();
                    Response.Redirect("~/ADMIN/Dashboard.aspx", false);
                }
            }
        }
    }
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
                objReg.UserName = Txt_id.Text;
                objReg.PASSWORD = ENC_DEC.Encode_Decode.EncodeTo64(Txt_pwd.Text).ToString();
                DataSet ds = objReg.VerifyLogin(objReg);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    Session["CODE"] = ds.Tables[0].Rows[0]["CODE"].ToString();
                    Session["ID"] = ds.Tables[0].Rows[0]["ID"].ToString();
                    Session["TYP"] = ds.Tables[0].Rows[0]["TYP"].ToString();
                    Session["NAME"] = ds.Tables[0].Rows[0]["NAME"].ToString();
                    Session["IMG"] = ds.Tables[0].Rows[0]["IMG"].ToString();

                    //if (chkRemPwd.Checked == true)
                    if(1==1)
                    {
                        HttpCookie pwdCookie = new HttpCookie("pwdCookie");

                        pwdCookie.Values.Add("CODE", Session["CODE"].ToString());
                        pwdCookie.Values.Add("ID", Session["ID"].ToString());
                        pwdCookie.Values.Add("TYP", Session["TYP"].ToString());
                        pwdCookie.Values.Add("NAME", Session["NAME"].ToString());
                        pwdCookie.Values.Add("IMG", Session["IMG"].ToString());


                        pwdCookie.Expires = DateTime.Now.AddYears(50);
                        Response.Cookies.Add(pwdCookie);
                    }

                    Response.Redirect("~/ADMIN/Dashboard.aspx", false);
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