using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class SALES_VendorDues : System.Web.UI.Page
{
    _Utility _utl = new _Utility();
    Common_Class _cs = new Common_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
            BindData();
        }
    }
    void Bind()
    {
        // _cs.BindDropDownList1(ddlType, _utl.Get_Designation().Tables[0], "ECAT_CODE", "ECAT_NAME", "");

    }
    void AssignData()
    {
        //_utl.User_Type = ddlType.SelectedValue.ToString();
        //_utl.Name = txtName.Text;
        //_utl.Phone = txtPhone.Text;
        //_utl.Address = txtAddress.Text;
        //_utl.Email = txtEmail.Text;
        //_utl.BankDetails = "";// txtBankDetails.Text;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AssignData();
        if (_utl.Insert_Employee_Customer_Data(_utl, "I") == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Submitted Successfully..');", true);

            reset();
            BindData();
        }
    }
    void BindData()
    {
        DataSet ds = _utl.Get_Employee_Customer_Data("5");
        string res = ""; string s = ""; double ss = 0;
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    s = "";
                    ss = Convert.ToDouble(ds.Tables[0].Rows[x]["BALANCE_AMT"].ToString());
                    if (ss < 2000)
                    {
                        s = "success";
                    }
                    else if (ss < 7000)
                    {
                        s = "warning";
                    }
                    else if (ss > 7000)
                    {
                        s = "danger";
                    }
                    res += "<tr>" +
                        "<td>" + (x + 1).ToString() + "</td>" +
                        "<td><a href='VendorReport.aspx?Cd=" + ds.Tables[0].Rows[x]["ECM_CODE"].ToString() + "'>" + ds.Tables[0].Rows[x]["ECM_NAME"].ToString() + "</a></td>" +
                        "<td>" + ds.Tables[0].Rows[x]["ECM_PHNO"].ToString() + "</td>" +
                    "<td>" + ds.Tables[0].Rows[x]["BALANCE_AMT"].ToString() + "</td>" +
                    "<td><span class='label label-success'><a href='SaleReport.aspx?Typ=Ven&Cd=" + ds.Tables[0].Rows[x]["ECM_CODE"].ToString() + "' style='color:white'>View Sales</a></span>&nbsp;<span class='label label-success'><a href='VendorReport.aspx?Cd=" + ds.Tables[0].Rows[x]["ECM_CODE"].ToString() + "' style='color:white'>Ledger</a></span>&nbsp;<span class='label label-success'><a href='Payments.aspx?Typ=Ven&Cd=" + ds.Tables[0].Rows[x]["ECM_CODE"].ToString() + "' style='color:white'>View Payments</a></span>&nbsp;<span class='label label-" + s + "'><a href='SMS.aspx?VNM=" + ds.Tables[0].Rows[x]["ECM_NAME"].ToString() + "&AMT=" + ds.Tables[0].Rows[x]["BALANCE_AMT"].ToString() + "&PH=" + ds.Tables[0].Rows[x]["ECM_PHNO"].ToString() + "&PG=VendorDues' style='color:white' onclick='return myFunction();'>SMS</a></span></td>" +
                    "</tr>";
                }
            }
        }
        Tbody1.InnerHtml = res;
    }
    void reset()
    {
        //ddlType.SelectedIndex = 0;
        //txtName.Text = "";
        //txtPhone.Text = "";
        //txtAddress.Text = "";
        //txtEmail.Text = "";
        ////txtBankDetails.Text = "";
        //ddlType.Focus();
    }
}