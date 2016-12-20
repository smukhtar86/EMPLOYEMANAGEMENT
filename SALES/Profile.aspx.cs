using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class USER_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }
    void Bind(string uid)
    {
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       // string x = inputName.Text;
    }
    protected void btnProfilePhoto_Click(object sender, EventArgs e)
    {
        if(fuProfile.HasFile)
        {
            fuProfile.SaveAs(Server.MapPath("DOCS/PHOTO/") + "1000000.png");
        }
    }
}