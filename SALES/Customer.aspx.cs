using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class SALES_Customer : System.Web.UI.Page
{
    _Utility _utl = new _Utility();
    Common_Class _cs = new Common_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Cd"] != null && Request.QueryString["Typ"] != null)
            {
                if (Request.QueryString["Typ"].ToString() == "Edit")
                {
                    ddlType.Enabled = false;
                    btnSubmit.Text = "Update";
                    DataSet ds = _utl.Get_Employee_Customer_Data_Individual(Request.QueryString["Cd"].ToString());

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _utl.Code = Request.QueryString["Cd"].ToString();
                            ddlType.SelectedValue = ds.Tables[0].Rows[0]["ECM_ECAT_CD"].ToString();
                            txtName.Text = ds.Tables[0].Rows[0]["ECM_NAME"].ToString();
                            txtEmail.Text = ds.Tables[0].Rows[0]["ECM_EMAIL"].ToString();
                            txtPhone.Text = ds.Tables[0].Rows[0]["ECM_PHNO"].ToString();
                            txtAddress.Text = ds.Tables[0].Rows[0]["ECM_ADD"].ToString();

                        }
                    }

                }
            }
            Bind();
            BindData();
        }
    }
    void Bind()
    {
        _cs.BindDropDownList1(ddlType, _utl.Get_Designation("").Tables[0], "ECAT_CODE", "ECAT_NAME", "");

    }
    void AssignData()
    {
        _utl.User_Type = ddlType.SelectedValue.ToString();
        _utl.Name = txtName.Text;
        _utl.Phone = txtPhone.Text;
        _utl.Address = txtAddress.Text;
        _utl.Email = txtEmail.Text;
        _utl.UpperId = "0";
        _utl.BankDetails = "";// txtBankDetails.Text;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AssignData();
        if (btnSubmit.Text == "Submit")
        {
            if (_utl.Insert_Employee_Customer_Data(_utl, "I") == 1)
            {
                divMsg.Visible = true;
                divMsg.InnerHtml = "<span class='bg-red'>Submitted Successfully</span>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Submitted Successfully..');", true);
              
                reset();
                // BindData();
            }
        }
        else if (btnSubmit.Text == "Update")
        {
            _utl.Code = Request.QueryString["Cd"].ToString();
            _utl.Emp_Cust_Code = Request.QueryString["Cd"].ToString();
            if (_utl.Insert_Employee_Customer_Data(_utl, "U") == 1)
            {
               

                divMsg.Visible = true;
                divMsg.InnerHtml = "<span class='bg-red'>Updated Successfully</span>";
                // reset();
                // BindData();
            }
        }
    }
    void BindData()
    {
        DataSet ds = _utl.Get_Employee_Customer_Data("5");
        string res = "";
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    res += "<tr><td>" + (x + 1).ToString() + "</td>" +
                        "<td>" + ds.Tables[0].Rows[x]["ECM_NAME"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["ECM_PHNO"].ToString() + "</td>" +
                        "<td>" + ds.Tables[0].Rows[x]["SALE_QNTY"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["SALE"].ToString() + "</td>" +
                        "<td>" + ds.Tables[0].Rows[x]["PAID"].ToString() + "</td>" +
                        "<td>" + ds.Tables[0].Rows[x]["BALANCE_AMT"].ToString() + "</td>" +
                        "<td><span class='label label-success'><a href='SaleReport.aspx?Typ=Ven&Cd=" + ds.Tables[0].Rows[x]["ECM_CODE"].ToString() + "' style='color:white'>View Sales</a></span></td>" +
                        "<td><span class='label label-success'><a href='VendorReport.aspx?Cd=" + ds.Tables[0].Rows[x]["ECM_CODE"].ToString() + "' style='color:white'>Ledger</a></span></td>" +
                         "<td><span class='label label-warning'><a href='?Cd=" + ds.Tables[0].Rows[x]["ECM_CODE"].ToString() + "&Typ=Edit' style='color:white'>Edit</a></span></td>" +
                        "</tr>";
                }
            }
        }
        DataSet dss = _utl.Get_Product();
      
        // Tbody1.InnerHtml = res;
    }
    void reset()
    {
        ddlType.SelectedIndex = 0;
        txtName.Text = "";
        txtPhone.Text = "";
        txtAddress.Text = "";
        txtEmail.Text = "";
        //txtBankDetails.Text = "";
        ddlType.Focus();
    }
}