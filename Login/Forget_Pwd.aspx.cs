using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Forget_Pwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
      //string rtn=  new SendMail().mailresetpwd(Txt_id.Text,Txt_Email.Text);
      //Response.Write("<script>alert('"+ rtn +"');location.href='login.aspx';</script>");
    }
}