using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class USER_Invoice : System.Web.UI.Page
{
    _Utility _utl = new _Utility();
    Common_Class _cs = new Common_Class();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Cache["Product"] != null)
            {
                DataTable dt = (DataTable)Cache["Product"];
                dt.Rows.Clear();
                Cache["Product"] = dt;
            }
            txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            Bind();
        }
    }
    void Bind()
    {
        try
        {
            _cs.BindDropDownList1(ddlVendorName, _utl.Get_Employee_Customer_Data("5").Tables[0], "ECM_CODE", "ECM_NAME", "Select");
            //_cs.BindDropDownList1(ddlPrdName, _utl.Get_Product().Tables[0], "PRD_CODE", "PRD_NAME", "Select");
            _cs.BindDropDownList1(ddlPrdName, _utl.Get_Product_Venodr("").Tables[0], "PRD_CODE", "PRD_NAME", "Select");
        }
        catch (Exception ee) { }
    }

    void Caches()
    {
        TimeSpan ts = new TimeSpan(10, 0, 10);
        if (Cache["Product"] == null)
        {
            DataTable dtProduct = new DataTable("Product");
            dtProduct.Columns.Add("PrdID", typeof(string));
            dtProduct.Columns.Add("PrdNm", typeof(string));
            dtProduct.Columns.Add("Qnty", typeof(string));
            dtProduct.Columns.Add("Price", typeof(string));
            dtProduct.Columns.Add("discount", typeof(string));
            dtProduct.Columns.Add("Vat", typeof(string));
            dtProduct.Columns.Add("Amt", typeof(string));
            dtProduct.Columns.Add("Total", typeof(string));
            DataRow rs = dtProduct.NewRow();
            rs[0] = ddlPrdName.SelectedValue.ToString();
            rs[1] = ddlPrdName.SelectedItem.Text;
            rs[2] = txtQnty.Text;
            rs[3] = txtPrice.Text;
            rs[4] = txtDiscount.Text;
            rs[5] = "0";
            rs[6] = txtTotal.Text;
            rs[7] = txtTotalAmount.Text;
            dtProduct.Rows.Add(rs);
            Cache["Product"] = dtProduct;
            bindTable(dtProduct);
        }
        else
        {
            DataTable dtProduct = (DataTable)Cache["Product"];
            DataRow rs = dtProduct.NewRow();
            rs[0] = ddlPrdName.SelectedValue.ToString();
            rs[1] = ddlPrdName.SelectedItem.Text;
            rs[2] = txtQnty.Text;
            rs[3] = txtPrice.Text;
            rs[4] = txtDiscount.Text;
            rs[5] = "0";
            rs[6] = txtTotal.Text;
            rs[7] = txtTotalAmount.Text;
            dtProduct.Rows.Add(rs);
            Cache["Product"] = dtProduct;
            // Cache.Insert("Product1", dtProduct, null, DateTime.Now.AddHours(1), ts);
            bindTable(dtProduct);
        }
    }
    void bindTable(DataTable dt)
    {
        string tb = "";
        double total = 0; double vat = 0; double discount = 0; double totalAmount = 0;
        if (dt.Rows.Count > 0)
        {
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                tb += "<tr>" +
                    "<td>" + (x + 1).ToString() + "</td>" +
                    "<td>" + dt.Rows[x]["PrdID"].ToString() + "</td>" +
                    "<td>" + dt.Rows[x]["PrdNm"].ToString() + "</td>" +
                     "<td>" + dt.Rows[x]["Qnty"].ToString() + "</td>" +
                     "<td>" + dt.Rows[x]["Price"].ToString() + "</td>" +
                     "<td>" + dt.Rows[x]["discount"].ToString() + "</td>" +
                     "<td>" + dt.Rows[x]["vat"].ToString() + "</td>" +
                     "<td>" + dt.Rows[x]["Amt"].ToString() + "</td>" +
                     "<td>" + dt.Rows[x]["Total"].ToString() + "</td>" +
                     "</tr>";
                total += Convert.ToDouble(dt.Rows[x]["Amt"].ToString());
                vat += Convert.ToDouble(dt.Rows[x]["vat"].ToString());
                discount += Convert.ToDouble(dt.Rows[x]["discount"].ToString());
                totalAmount += Convert.ToDouble(dt.Rows[x]["Total"].ToString());
            }
        }
        tblDetails.InnerHtml = tb;
        txtAmountFooter.Text = total.ToString();
        txtDiscountFooter.Text = discount.ToString();
        txtVatFooter.Text = vat.ToString();
        txtTotalAmountFooter.Text = totalAmount.ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Caches();

    }
    void Reset()
    {
        txtDate.Text = "";
        ddlPrdName.SelectedIndex = 0;
        ddlVendorName.SelectedIndex = 0;
        txtTotal.Text = "";
        txtBox.Text = "";
        txtPrice.Text = "";
        txtQnty.Text = "";
        txtRemark.Text = "";
        txtDate.Focus();
    }
    protected void ddlVendorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        _cs.BindDropDownList1(ddlPrdName, _utl.Get_Product_Venodr(ddlVendorName.SelectedValue.ToString()).Tables[0], "PRD_CODE", "PRD_NAME", "Select");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Cache["Product"] != null)
        {
            DataTable dtProduct = (DataTable)Cache["Product"];
            dtProduct.Rows.Clear();
            Cache["Product"] = dtProduct;
        }
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        //if (_cs.ExecuteQuery("insert into TBL_GLEU_SALE_MST(SAL_DT,PUR_VENDOR_CD,PUR_PRD_CD,SAL_QNTY,SAL_PRICE_PC,SAL_TOT_AMT) values('" + utl.Date + "','" + utl.Emp_Cust_Code + "','" + utl.Product_Code + "','" + utl.Product_Price + "','" + utl.Amount + "')") == 1)
        //btnSave.Attributes.Add("onclick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
        if (Cache["Product"] != null)
        {
            DataTable dtProduct = (DataTable)Cache["Product"];
            for (int x = 0; x < dtProduct.Rows.Count; x++)
            {
                _utl.Date = txtDate.Text;
                _utl.Emp_Cust_Code = ddlVendorName.SelectedValue.ToString();
                _utl.Product_Code = dtProduct.Rows[x]["PrdID"].ToString();
                _utl.Product_Price = dtProduct.Rows[x]["Price"].ToString();
                _utl.Product_Qnty = dtProduct.Rows[x]["Discount"].ToString();
                _utl.VAT = dtProduct.Rows[x]["vat"].ToString();
                _utl.Product_Price = dtProduct.Rows[x]["Amt"].ToString();
                _utl.Amount = dtProduct.Rows[x]["Total"].ToString();
                _utl.Remarks = txtRemark.Text;
                _utl.Type = "SALE";
                //_utl.Amount = Convert.ToString(Convert.ToDouble(_utl.Product_Price) * Convert.ToDouble(txtQnty.Text));// txtTotal.Text
                //if (_utl._Inser_Sale(_utl) == "Success")
                //{
                //    liMsg.Visible = true;
                //    liMsg.InnerHtml = " <span class='bg-red'>Product Sold Successfully</span>";
                //    string[] s = ddlPrdName.SelectedItem.Text.Split('-');
                //    DataSet ds = new _Utility().Get_Employee_Customer_Data_Individual(_utl.Emp_Cust_Code);
                //    Sms._Vendor_Sale(ddlVendorName.SelectedItem.Text.ToString(), ds.Tables[0].Rows[0]["ECM_PHNO"].ToString(), txtTotal.Text, Convert.ToString(Convert.ToDouble(txtQnty.Text) / Convert.ToDouble(s[2])) + " : " + s[0].ToString());
                //    Reset();
                //}
                //else
                //{
                //    liMsg.Visible = true;
                //    liMsg.InnerHtml = " <span class='bg-red'>Error Found..</span>";
                //}
            }
        }

        btnSave.Enabled = true;
    }
}