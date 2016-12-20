using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class USER_VendorPayment : System.Web.UI.Page
{
    _Utility _utl = new _Utility();
    Common_Class _cs = new Common_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    void Bind()
    {
        _cs.BindDropDownList1(ddlVendorName, _utl.Get_Employee_Customer_Data("5").Tables[0], "ECM_CODE", "ECM_NAME", "Select");
       // _cs.BindDropDownList1(ddlPrdName, _utl.Get_Product().Tables[0], "PRD_CODE", "PRD_NAME", "Select");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {  
        //if (_cs.ExecuteQuery("insert into TBL_GLEU_SALE_MST(SAL_DT,PUR_VENDOR_CD,PUR_PRD_CD,SAL_QNTY,SAL_PRICE_PC,SAL_TOT_AMT) values('" + utl.Date + "','" + utl.Emp_Cust_Code + "','" + utl.Product_Code + "','" + utl.Product_Price + "','" + utl.Amount + "')") == 1)
        _utl.Date = txtDate.Text;
        _utl.Emp_Cust_Code = ddlVendorName.SelectedValue.ToString();
        _utl.Amount = txtTotal.Text;
        if (_utl._Insert_Payment(_utl) == "Success")
        {
            DataSet ds = new _Utility().Get_Employee_Customer_Data_Individual(_utl.Emp_Cust_Code);
            Sms._Vendor_Payment(ddlVendorName.SelectedItem.Text.ToString(), ds.Tables[0].Rows[0]["ECM_PHNO"].ToString(), txtTotal.Text, ds.Tables[0].Rows[0]["BALANCE_AMT"].ToString());
            liMsg.Visible = true;
            liMsg.InnerHtml=" <span class='bg-red'>Payment Received Successfully</span>";
            Reset();
        }
    }
    void Reset()
    {
        txtDate.Text = "";
        ddlVendorName.SelectedIndex = 0;
        txtTotal.Text = "";
        txtDate.Focus();
    }
}