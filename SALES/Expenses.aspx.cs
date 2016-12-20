using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class USER_Expenses : System.Web.UI.Page
{
    Common_Class _cs = new Common_Class();
    _Utility _utl = new _Utility();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _cs.BindDropDownList1(ddlEmpCustomer, _utl.Get_Employee_Customer_Data("ALL").Tables[0], "ECM_CODE", "ECM_NAME_1", "");
            Bind();
        }
    }
    void Bind()
    {
        DataSet ds = _utl.Get_Expenses_Mst("");
        string res = "";
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                   // res += "<tr><td>" + (x + 1).ToString() + "</td> <td>" + Convert.ToDateTime(ds.Tables[0].Rows[x]["EXP_DT"].ToString()).ToString("dd-MMM-yyyy") + "</td><td>" + ds.Tables[0].Rows[x]["ECM_NAME"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["EXP_PURPOSE"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["EXP_AMOUNT"].ToString() + "</td></tr>";
                    res += "<tr><td>" + (x + 1).ToString() + "</td><td>" + ds.Tables[0].Rows[x]["ECM_NAME"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["TOTAL_AMOUNT"].ToString() + "</td><td><a href=ExpensesReport.aspx?ID=" + ds.Tables[0].Rows[x]["EXP_VEN_CODE"].ToString() + ">View</a></td></tr>";
                }
            }
        }
        Tbody1.InnerHtml = res;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        _utl.Date = txtDate.Text; 
        _utl.Emp_Cust_Code = ddlEmpCustomer.SelectedValue.ToString(); 
        _utl.Purpose = txtPurpose.Text; 
        _utl.Amount = txtAmount.Text;
        if(_utl._Insert_Expenses(_utl)=="Success")
        {
            Bind();
            liMsg.Visible = true;
            liMsg.InnerHtml = "<span class='bg-red'>Submitted Successfully</span>";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Submitted Successfully..');", true);
            Reset();
        }
    }
    void Reset()
    {
        txtAmount.Text = "";
        txtDate.Text = "";
        txtPurpose.Text = "";
        ddlEmpCustomer.SelectedIndex = 0;

    }
}