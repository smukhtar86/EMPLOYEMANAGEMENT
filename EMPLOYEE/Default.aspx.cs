using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class USER_Default : System.Web.UI.Page
{
    _Utility _ut = new _Utility();
    protected void Page_Load(object sender, EventArgs e)
    {
        new SessionManagement()._CheckSession();
        if (!IsPostBack)
        {
            Bind();
        }
        //divProfile.InnerHtml = new _UserProfile()._Genealogy_Profile("1000000");
        //ulLatestMember.InnerHtml = new _UserProfile()._Genealogy_Dashboard_Latest_Member("1000000");
    }
    string _In_Transit = "";
    string _Current_Stock = "";
    string _Credit_Amount = "";
    string _Cash_In_Hand = "";
    string _Advance_With_Revenue = "";
    void Bind()
    {
        DataSet dss = _ut._DashBoard();
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                sp_CurrentStock.InnerHtml = "Qnty : " + dss.Tables[0].Rows[0]["CURRENT_STOCK"].ToString() + "/<small>Rs. " + dss.Tables[0].Rows[0]["CURRENT_STOCK_AMOUNT"].ToString() + "</small>";
                sp_PURCHASE_ORDER_QNTY.InnerHtml = "Qnty : " + dss.Tables[0].Rows[0]["PURCHASE_ORDER_QNTY_ALL"].ToString() + "/<small>Rs." + dss.Tables[0].Rows[0]["PURCHASE_ORDER_AMOUNT_REST"].ToString() + "</small>";
                sp_InTransit.InnerHtml = "Qnty : " + dss.Tables[0].Rows[0]["PURCHASE_ORDER_QNTY"].ToString() + "/<small>Rs." + dss.Tables[0].Rows[0]["PURCHASE_ORDER_AMOUNT"].ToString() + "</small>";
                sp_SALE_QNTY.InnerHtml = "Qnty : " + dss.Tables[0].Rows[0]["SALE_QNTY"].ToString() + "/<small>Rs." + dss.Tables[0].Rows[0]["SALE_AMOUNT"].ToString() + "</small>";
                sp_EXPENSES.InnerHtml = "Rs. " + dss.Tables[0].Rows[0]["EXPENSES"].ToString();
                sp_CREDIT.InnerHtml = "Rs. " + dss.Tables[0].Rows[0]["CREDIT_AMOUNT"].ToString();
                _Credit_Amount = dss.Tables[0].Rows[0]["CREDIT_AMOUNT"].ToString();
                sp_CASHINHAND.InnerHtml = "Rs. " + dss.Tables[0].Rows[0]["CASH_IN_HAND_VIR"].ToString();
                _Cash_In_Hand = dss.Tables[0].Rows[0]["CASH_IN_HAND_ACT"].ToString();
                //@COLLECTION_AMOUNT-(@EXPENSES-@CAPITAL_AMOUNT);
                sp_CASHINHANDAct.InnerHtml = "Rs. " + dss.Tables[0].Rows[0]["CASH_IN_HAND_ACT"].ToString() + "<br><small>" + dss.Tables[0].Rows[0]["COLLECTION_AMOUNT"].ToString() + "-(" + dss.Tables[0].Rows[0]["EXPENSES"].ToString() + "-" + dss.Tables[0].Rows[0]["CAPITAL_AMOUNT"].ToString() + ")</small>";
                sp_COLLECTION_AMT.InnerHtml = "Rs. " + dss.Tables[0].Rows[0]["COLLECTION_AMOUNT"].ToString();
                sp_CapitalAmount.InnerHtml = "Rs. " + dss.Tables[0].Rows[0]["CAPITAL_AMOUNT"].ToString();
                sp_asset.InnerHtml = "Rs. " + dss.Tables[0].Rows[0]["TOTAL_ASSET"].ToString() + "<BR><small>Revenue : " + "Rs. " + dss.Tables[0].Rows[0]["TOTAL_REVENUE"].ToString() + "</small>";

                sp_total.InnerHtml = "Rs. " + dss.Tables[0].Rows[0]["STOCK_LEDGER"].ToString();
                _Advance_With_Revenue = Convert.ToString(Convert.ToDecimal(dss.Tables[0].Rows[0]["STOCK_LEDGER"].ToString()) + Convert.ToDecimal(dss.Tables[0].Rows[0]["EXPECTED_REVENUE"].ToString()));
                if (Convert.ToDouble(dss.Tables[0].Rows[0]["STOCK_LEDGER"].ToString()) > 0)
                {
                    sp_total_Title.InnerHtml = "<b>Stock Ledger</b> <small>Advance Amount</small>";
                    sp_total.InnerHtml += "<br><small>Expected Revenue : Rs." + dss.Tables[0].Rows[0]["EXPECTED_REVENUE"].ToString() + "</small>";
                }
                else
                {
                    sp_total_Title.InnerHtml = "Due Amount";
                    sp_total.InnerHtml += "<br><small>Rs." + dss.Tables[0].Rows[0]["EXPECTED_REVENUE"].ToString() + "</small>";
                }
            }
        }
        //DataSet dssl = new _Utility()._DashBoard_Supplier();
        //if (dssl.Tables.Count > 0)
        //{
        //    if (dssl.Tables[3].Rows.Count > 0)
        //    {
        //        sp_total.InnerHtml = "Rs. " + dssl.Tables[3].Rows[0]["REST"].ToString();
        //        if (Convert.ToDouble(dssl.Tables[3].Rows[0]["REST"].ToString()) > 0)
        //        {
        //            sp_total_Title.InnerHtml = "<b>Stock Ledger</b> <small>Advance Amount</small>";
        //        }
        //        else
        //        {
        //            sp_total_Title.InnerHtml = "Due Amount";
        //        }
        //    }
        //}


        DataSet ds = _ut.Get_Product();
        string res = ""; string st = ""; string transit = ""; string po = ""; string pq = ""; string sp_PURCHASE_ORDER_QNTY_str = "";
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    res += "<tr><td>" + (x + 1).ToString() + "</td> <td>" + ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "</td><td>" + ds.Tables[0].Rows[x]["REST_QNTY"].ToString() + "</td><td><span class='label " + ds.Tables[0].Rows[x]["STS"].ToString() + "'>" + ds.Tables[0].Rows[x]["STS_BTN"].ToString() + "</span></td><td><span class='label label-success'><a href='SaleReport.aspx?Typ=Prd&Cd=" + ds.Tables[0].Rows[x]["PRD_CODE"].ToString() + "' style='color:white'>View</a></span></td></tr>";
                    if (x == 0)
                    {
                        st += ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "-" + ds.Tables[0].Rows[x]["REST_QNTY"].ToString() + "/" + ds.Tables[0].Rows[x]["REST_BOXES"].ToString() + "Box<br>";
                        po += ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "-" + ds.Tables[0].Rows[x]["PURCHASE_QNTY"].ToString() + "/" + ds.Tables[0].Rows[x]["PURCHASE_BOXES"].ToString() + "Box<br>";
                        transit += ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "-" + ds.Tables[0].Rows[x]["PURCHASE_ORDER_QNTY"].ToString() + "/" + ds.Tables[0].Rows[x]["PURCHASE_ORDER_BOXES"].ToString() + "Box<br>";
                        pq += ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "-" + ds.Tables[0].Rows[x]["SALE_QNTY"].ToString() + "/" + ds.Tables[0].Rows[x]["SALE_BOXES"].ToString() + "Box<br>";

                        _In_Transit = ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + " - " + ds.Tables[0].Rows[x]["PURCHASE_ORDER_QNTY"].ToString() + " X " + ds.Tables[0].Rows[x]["PRD_SLE_PRC"].ToString() + " : " + Convert.ToString(Convert.ToDecimal(ds.Tables[0].Rows[x]["PURCHASE_ORDER_QNTY"].ToString()) * Convert.ToDecimal(ds.Tables[0].Rows[x]["PRD_SLE_PRC"].ToString())) + "<br>";

                        _Current_Stock = ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + " - " + ds.Tables[0].Rows[x]["REST_QNTY"].ToString() + " X " + ds.Tables[0].Rows[x]["PRD_SLE_PRC"].ToString() + " : " + Convert.ToString(Convert.ToDecimal(ds.Tables[0].Rows[x]["REST_QNTY"].ToString()) * Convert.ToDecimal(ds.Tables[0].Rows[x]["PRD_SLE_PRC"].ToString())) + "<br>";
                    }
                    else
                    {
                        st += ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "-" + ds.Tables[0].Rows[x]["REST_QNTY"].ToString() + "/" + ds.Tables[0].Rows[x]["REST_BOXES"].ToString() + "Box ";
                        po += ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "-" + ds.Tables[0].Rows[x]["PURCHASE_QNTY"].ToString() + "/" + ds.Tables[0].Rows[x]["PURCHASE_BOXES"].ToString() + "Box";
                        transit += ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "-" + ds.Tables[0].Rows[x]["PURCHASE_ORDER_QNTY"].ToString() + "/" + ds.Tables[0].Rows[x]["PURCHASE_ORDER_BOXES"].ToString() + "Box"; ;
                        pq += ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "-" + ds.Tables[0].Rows[x]["SALE_QNTY"].ToString() + "/" + ds.Tables[0].Rows[x]["SALE_BOXES"].ToString() + "Box";

                        _In_Transit += ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + " - " + ds.Tables[0].Rows[x]["PURCHASE_ORDER_QNTY"].ToString() + " X " + ds.Tables[0].Rows[x]["PRD_SLE_PRC"].ToString() + " : " + Convert.ToString(Convert.ToDecimal(ds.Tables[0].Rows[x]["PURCHASE_ORDER_QNTY"].ToString()) * Convert.ToDecimal(ds.Tables[0].Rows[x]["PRD_SLE_PRC"].ToString()));
                        _Current_Stock += ds.Tables[0].Rows[x]["PRD_NAME"].ToString() + "-" + ds.Tables[0].Rows[x]["REST_QNTY"].ToString() + " X " + ds.Tables[0].Rows[x]["PRD_SLE_PRC"].ToString() + " : " + Convert.ToString(Convert.ToDecimal(ds.Tables[0].Rows[x]["REST_QNTY"].ToString()) * Convert.ToDecimal(ds.Tables[0].Rows[x]["PRD_SLE_PRC"].ToString()));
                    }
                }
                sp_CurrentStock1.InnerHtml += "<small>" + st + "</small>";
                sp_PURCHASE_ORDER_QNTY.InnerHtml += "<br><small>" + po + "</small>";
                sp_InTransit.InnerHtml += "<br><small>" + transit + "</small>";
                sp_SALE_QNTY.InnerHtml += "<br><small>" + pq + "</small>";
            }
        }
        tblProductStock.InnerHtml = res;


        DataSet dsss = _ut.Get_Product_Stock("where STS='Approve' ORDER BY PUR_DT DESC");
        DataSet dsss_PS = _ut.Get_Product_Stock("PUR_DT", "where STS='Approve' GROUP BY PUR_DT ORDER BY PUR_DT DESC");
        string ress = ""; string btn = "";
        string purOrd = "";
        if (dsss_PS.Tables.Count > 0)
        {
            if (dsss_PS.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < dsss_PS.Tables[0].Rows.Count; x++)
                {
                    purOrd += "<b style='color:red;'>Date : " + Convert.ToDateTime(dsss_PS.Tables[0].Rows[x]["PUR_DT"].ToString()).ToString("dd-MMM-yyyy") + "</b><br> ";
                    for (int xz = 0; xz < dsss.Tables[0].Rows.Count; xz++)
                    {
                        if (Convert.ToDateTime(dsss_PS.Tables[0].Rows[x]["PUR_DT"].ToString()).ToString("dd-MMM-yyyy") == Convert.ToDateTime(dsss.Tables[0].Rows[xz]["PUR_DT"].ToString()).ToString("dd-MMM-yyyy"))
                        {
                            purOrd += dsss.Tables[0].Rows[xz]["PRD_NAME"].ToString() + " : " + dsss.Tables[0].Rows[xz]["PUR_QNTY"].ToString() + " (" + dsss.Tables[0].Rows[xz]["TOTAL_BOX"].ToString() + " Box) Rs. " + dsss.Tables[0].Rows[xz]["PUR_TOT_AMT"].ToString() + "<br>";
                        }
                    }
                }
            }
        }
        tblPurchaseOrder.InnerHtml = ress;
        sp_Intransit_Details.InnerHtml = purOrd;
        DataSet dscap = _ut.Get_Capital_Amount("ORDER BY CAP_CODE DESC");
        string rescap = "";
        string rescap1 = "";
        if (dscap.Tables.Count > 0)
        {
            if (dscap.Tables[0].Rows.Count > 0)
            {//PUR_CODE, PUR_DT, PUR_PRD_CD, PUR_QNTY, PUR_PRICE_PC, PUR_TOT_AMT, PUR_APRV_DT, PUR_STS
                for (int x = 0; x < dscap.Tables[0].Rows.Count; x++)
                {
                    rescap += "<tr><td>" + (x + 1).ToString() + "</td>" +
                    "<td>" + Convert.ToDateTime(dscap.Tables[0].Rows[x]["CAP_DT"].ToString()).ToString("dd-MMM-yyyy") + "</td>" +
                    "<td>" + dscap.Tables[0].Rows[x]["ECM_NAME"].ToString() + "</td>" +
                    "<td>" + dscap.Tables[0].Rows[x]["CAP_AMOUNT"].ToString() + "</td>" +
                 "</tr>";
                    rescap1 += "<b>" + Convert.ToDateTime(dscap.Tables[0].Rows[x]["CAP_DT"].ToString()).ToString("dd-MMM-yyyy") + "</b><br>" + dscap.Tables[0].Rows[x]["ECM_NAME"].ToString() + " Rs. " + dscap.Tables[0].Rows[x]["CAP_AMOUNT"].ToString() + "<br>";
                }
            }
        }
        tbl_Capital.InnerHtml = rescap;
        sp_CapitalAmount1.InnerHtml = rescap1;

        DataSet dssssPO = _ut.Get_Product_Stock("PUR_APRV_DT", "where STS='Approved' group by PUR_APRV_DT order by PUR_APRV_DT desc");
        DataSet dssss = _ut.Get_Product_Stock("where STS='Approved' order by PUR_APRV_DT desc");
        string resss = "";
        if (dssss.Tables.Count > 0)
        {
            if (dssssPO.Tables[0].Rows.Count > 0)
            {//PUR_CODE, PUR_DT, PUR_PRD_CD, PUR_QNTY, PUR_PRICE_PC, PUR_TOT_AMT, PUR_APRV_DT, PUR_STS
                for (int x = 0; x < dssssPO.Tables[0].Rows.Count; x++)
                {
                    resss += "<b style='color:red;'>Date : " + Convert.ToDateTime(dssssPO.Tables[0].Rows[x]["PUR_APRV_DT"].ToString()).ToString("dd-MMM-yyyy") + "</b><br> ";
                    for (int zx = 0; zx < dssss.Tables[0].Rows.Count; zx++)
                    {
                        if (Convert.ToDateTime(dssssPO.Tables[0].Rows[x]["PUR_APRV_DT"].ToString()).ToString("dd-MMM-yyyy") == Convert.ToDateTime(dssss.Tables[0].Rows[zx]["PUR_APRV_DT"].ToString()).ToString("dd-MMM-yyyy"))
                            resss += dssss.Tables[0].Rows[zx]["PRD_NAME"].ToString() + " : " + dssss.Tables[0].Rows[zx]["PUR_QNTY"].ToString() + " (" + dssss.Tables[0].Rows[zx]["TOTAL_BOX"].ToString() + " Box) Rs. " + dssss.Tables[0].Rows[zx]["PUR_TOT_AMT"].ToString() + "<br>";
                    }
                }
            }
        }
        sp_PURCHASE_ORDER_QNTY1.InnerHtml = "<small>" + resss + "</small>";

        DataSet dscollection_rp = _ut.Get_Payment_Report("top 10 *", "where PAY_DT BETWEEN '" + DateTime.Now.AddDays(-10).ToString("dd-MMM-yyyy") + "' and '" + DateTime.Now.ToString("dd-MMM-yyyy") + "' order by PAY_DT DESC");
        DataSet dscollection = _ut.Get_Payment_Report("top 10 PAY_DT", "where PAY_DT BETWEEN '" + DateTime.Now.AddDays(-10).ToString("dd-MMM-yyyy") + "' and '" + DateTime.Now.ToString("dd-MMM-yyyy") + "' group by PAY_DT order by PAY_DT DESC");
        string rescol = "";
        if (dscollection.Tables.Count > 0)
        {
            if (dscollection.Tables[0].Rows.Count > 0)
            {//PUR_CODE, PUR_DT, PUR_PRD_CD, PUR_QNTY, PUR_PRICE_PC, PUR_TOT_AMT, PUR_APRV_DT, PUR_STS
                for (int x = 0; x < dscollection.Tables[0].Rows.Count; x++)
                {
                    rescol += "<b>Date : " + Convert.ToDateTime(dscollection.Tables[0].Rows[x]["PAY_DT"].ToString()).ToString("dd-MMM-yyyy") + "</b><br> ";
                    for (int xs = 0; xs < dscollection_rp.Tables[0].Rows.Count; xs++)
                    {
                        if (Convert.ToDateTime(dscollection.Tables[0].Rows[x]["PAY_DT"].ToString()).ToString("dd-MMM-yyyy") == Convert.ToDateTime(dscollection_rp.Tables[0].Rows[xs]["PAY_DT"].ToString()).ToString("dd-MMM-yyyy"))
                        {
                            rescol += dscollection_rp.Tables[0].Rows[xs]["ECM_NAME"].ToString() + " : Rs." + dscollection_rp.Tables[0].Rows[xs]["PAY_AMOUNT"].ToString() + "<br>";
                        }
                    }
                }
            }
        }
        sp_COLLECTION_AMT1.InnerHtml = "<small>" + rescol + "</small>";
        string resexp = ""; string resexp1 = ""; double exp = 0;
        DataSet dssexpenses = _ut.Get_Expenses_Mst("");
        if (dssexpenses.Tables.Count > 0)
        {
            if (dssexpenses.Tables[0].Rows.Count > 0)
            {//PUR_CODE, PUR_DT, PUR_PRD_CD, PUR_QNTY, PUR_PRICE_PC, PUR_TOT_AMT, PUR_APRV_DT, PUR_STS
                for (int x = 0; x < dssexpenses.Tables[0].Rows.Count; x++)
                {
                    if (dssexpenses.Tables[0].Rows[x]["EXP_VEN_CODE"].ToString() == "29")
                    {
                        resexp += "<b>" + dssexpenses.Tables[0].Rows[x]["ECM_NAME"].ToString() + " : Rs." + dssexpenses.Tables[0].Rows[x]["TOTAL_AMOUNT"].ToString() + "</b>";
                    }
                    else
                    {
                        exp += Convert.ToDouble(dssexpenses.Tables[0].Rows[x]["TOTAL_AMOUNT"].ToString());
                    }
                }

                resexp += "<br><b>Transport : Rs." + exp + "</b>";
            }
        }
        sp_EXPENSES.InnerHtml += "<br>" + resexp;
        DataSet dsexpenses = _ut.Get_Expenses("top 10 *", "order by EXP_CODE DESC");//.Get_Product_Stock("where STS='Approved'");
        resexp = "";
        if (dsexpenses.Tables.Count > 0)
        {
            if (dsexpenses.Tables[0].Rows.Count > 0)
            {//PUR_CODE, PUR_DT, PUR_PRD_CD, PUR_QNTY, PUR_PRICE_PC, PUR_TOT_AMT, PUR_APRV_DT, PUR_STS
                for (int x = 0; x < dsexpenses.Tables[0].Rows.Count; x++)
                {
                    resexp += "<b>Date : " + Convert.ToDateTime(dsexpenses.Tables[0].Rows[x]["EXP_DT"].ToString()).ToString("dd-MMM-yyyy") + " : Rs." + dsexpenses.Tables[0].Rows[x]["EXP_AMOUNT"].ToString() + "</b><br> " + dsexpenses.Tables[0].Rows[x]["ECM_NAME"].ToString() + "<br>";
                }
            }
        }
        sp_EXPENSES1.InnerHtml = "<small>" + resexp + "</small>";

        DataSet dsecredit = _ut.Get_Employee_Customer_Data("5");//.Get_Product_Stock("where STS='Approved'");
        string rescredit = "";
        if (dsecredit.Tables.Count > 0)
        {
            if (dsecredit.Tables[0].Rows.Count > 0)
            {//PUR_CODE, PUR_DT, PUR_PRD_CD, PUR_QNTY, PUR_PRICE_PC, PUR_TOT_AMT, PUR_APRV_DT, PUR_STS
                for (int x = 0; x < dsecredit.Tables[0].Rows.Count; x++)
                {
                    rescredit += "<b><a href='VendorReport.aspx?Cd=" + dsecredit.Tables[0].Rows[x]["ECM_CODE"].ToString() + "'>" + dsecredit.Tables[0].Rows[x]["ECM_NAME"].ToString() + "</a></b> Rs." + dsecredit.Tables[0].Rows[x]["BALANCE_AMT"].ToString() + "<br>";
                }
            }
        }
        sp_CREDIT1.InnerHtml = "<small>" + rescredit + "</small>";

        DataSet dssales = _ut.Get_Sale_Report("top 5 SAL_DT", "where SAL_DT between '" + DateTime.Now.AddDays(-5).ToString("dd-MMM-yyyy") + "' and '" + DateTime.Now.ToString("dd-MMM-yyyy") + "' GROUP BY SAL_DT order by SAL_DT DESC");
        //.Get_Product_Stock("where STS='Approved'");
        string ressales = "";
        if (dssales.Tables.Count > 0)
        {
            if (dssales.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < dssales.Tables[0].Rows.Count; x++)
                {
                    DataSet dssales1 = _ut.Get_Sale_Report("*", "WHERE SAL_DT='" + Convert.ToDateTime(dssales.Tables[0].Rows[x]["SAL_DT"].ToString()).ToString("dd-MMM-yyyy") + "' order by SAL_DT DESC");
                    ressales += "<b style='color:red;'>Date : " + Convert.ToDateTime(dssales.Tables[0].Rows[x]["SAL_DT"].ToString()).ToString("dd-MMM-yyyy") + "</b><br>-----------------------------------<br>";
                    if (dssales1.Tables[0].Rows.Count > 0)
                    {
                        for (int xX = 0; xX < dssales1.Tables[0].Rows.Count; xX++)
                        {
                            ressales += "<b>" + dssales1.Tables[0].Rows[xX]["SAL_TYPE"].ToString() + " <a href='VendorReport.aspx?Cd=" + dssales1.Tables[0].Rows[xX]["SAL_VENDOR_CD"].ToString() + "'>" + dssales1.Tables[0].Rows[xX]["ECM_NAME"].ToString() + "</a><br></b>" + dssales1.Tables[0].Rows[xX]["PRD_NAME"].ToString() + "-" + dssales1.Tables[0].Rows[xX]["SAL_QNTY"].ToString() + " Pcs(" + dssales1.Tables[0].Rows[xX]["SAL_BOX"].ToString() + " Box) /Rs." + dssales1.Tables[0].Rows[xX]["SAL_TOT_AMT"].ToString() + "<br>";
                        }
                    }
                }
            }
        }
        sp_SALE_QNTY1.InnerHtml = "<small><br>" + ressales + "</small>";


        DataSet dsTodaySales = _ut.Get_Sale_Report("SAL_DT", "where SAL_DT BETWEEN '" + DateTime.Now.AddDays(-10).ToString("dd-MMMM-yyyy") + "' AND '" + DateTime.Now.ToString("dd-MMMM-yyyy") + "' GROUP BY SAL_DT ORDER BY SAL_DT DESC");
        DataSet dsTodaySales1 = _ut.Get_Sale_Report("SAL_DT,PRD_NAME,SUM(SAL_TOT_AMT) AS SALE_AMT,SUM(SAL_QNTY) AS SALE_QNTY,CONVERT(NUMERIC(18,0),SUM(SAL_QNTY)/PRD_BOX_SIZE) AS BOX", "where SAL_DT BETWEEN '" + DateTime.Now.AddDays(-10).ToString("dd-MMMM-yyyy") + "' AND '" + DateTime.Now.ToString("dd-MMMM-yyyy") + "' GROUP BY SAL_DT,PRD_NAME,PRD_BOX_SIZE ORDER BY SAL_DT DESC");
        //.Get_Product_Stock("where STS='Approved'");
        string resTodaysales = ""; string resTodaysales1 = ""; string resTodaysales2 = "";
        if (dsTodaySales.Tables.Count > 0)
        {
            if (dsTodaySales.Tables[0].Rows.Count > 0)
            {
                for (int x = 0; x < dsTodaySales.Tables[0].Rows.Count; x++)
                {
                    if (x == 0)
                    {
                        if (Convert.ToDateTime(dsTodaySales.Tables[0].Rows[x]["SAL_DT"].ToString()).ToString("dd-MMM-yyyy") == DateTime.Now.ToString("dd-MMM-yyyy"))
                        {
                            resTodaysales += "<b style='color:red;'>Date : " + Convert.ToDateTime(dsTodaySales.Tables[0].Rows[x]["SAL_DT"].ToString()).ToString("dd-MMM-yyyy") + "</b><br>";
                            for (int z = 0; z < dsTodaySales1.Tables[0].Rows.Count; z++)
                            {
                                if (dsTodaySales.Tables[0].Rows[x]["SAL_DT"].ToString() == dsTodaySales1.Tables[0].Rows[z]["SAL_DT"].ToString())
                                {
                                    resTodaysales += dsTodaySales1.Tables[0].Rows[z]["PRD_NAME"].ToString() + " " + dsTodaySales1.Tables[0].Rows[z]["SALE_QNTY"].ToString() + " Pcs. (" + dsTodaySales1.Tables[0].Rows[z]["BOX"] + " Box) Rs. " + dsTodaySales1.Tables[0].Rows[z]["SALE_AMT"].ToString() + "<br>";
                                }
                            }
                        }
                        else
                        {
                            resTodaysales2 += "<b style='color:red;'>Date : " + Convert.ToDateTime(dsTodaySales.Tables[0].Rows[x]["SAL_DT"].ToString()).ToString("dd-MMM-yyyy") + "</b><br>";
                            //resTodaysales1 += "<b style='color:red;'>Date : " + Convert.ToDateTime(dsTodaySales.Tables[0].Rows[x]["SAL_DT"].ToString()).ToString("dd-MMM-yyyy") + "</b><br>";

                            for (int z = 0; z < dsTodaySales1.Tables[0].Rows.Count; z++)
                            {
                                if (dsTodaySales.Tables[0].Rows[x]["SAL_DT"].ToString() == dsTodaySales1.Tables[0].Rows[z]["SAL_DT"].ToString())
                                {
                                    resTodaysales2 += dsTodaySales1.Tables[0].Rows[z]["PRD_NAME"].ToString() + " " + dsTodaySales1.Tables[0].Rows[z]["SALE_QNTY"].ToString() + " Pcs. (" + dsTodaySales1.Tables[0].Rows[z]["BOX"] + " Box) Rs. " + dsTodaySales1.Tables[0].Rows[z]["SALE_AMT"].ToString() + "<br>";
                                }
                            }
                        }
                    }
                    else
                    {
                        resTodaysales2 += "<b style='color:red;'>Date : " + Convert.ToDateTime(dsTodaySales.Tables[0].Rows[x]["SAL_DT"].ToString()).ToString("dd-MMM-yyyy") + "</b><br>";
                        for (int z = 0; z < dsTodaySales1.Tables[0].Rows.Count; z++)
                        {
                            if (dsTodaySales.Tables[0].Rows[x]["SAL_DT"].ToString() == dsTodaySales1.Tables[0].Rows[z]["SAL_DT"].ToString())
                            {
                                resTodaysales2 += dsTodaySales1.Tables[0].Rows[z]["PRD_NAME"].ToString() + " " + dsTodaySales1.Tables[0].Rows[z]["SALE_QNTY"].ToString() + "Pcs (" + dsTodaySales1.Tables[0].Rows[z]["BOX"] + " Box) Rs. " + dsTodaySales1.Tables[0].Rows[z]["SALE_AMT"].ToString() + "<br>";
                            }
                        }
                    }
                }
            }
        }
        sp_TODAY_SALE_QNTY.InnerHtml = "<small>" + resTodaysales + "</small>";
        sp_TODAY_SALE_QNTY1.InnerHtml = "<small><br>" + resTodaysales1 + resTodaysales2 + "</small>";

        Span2.InnerHtml = "<small style='text-align:right;'>In Transit<br>" + _In_Transit + "<br>Current Sotck<br>" + _Current_Stock + "<br>Credit Amount : " + _Credit_Amount + "<br>Cash In Hand : " + _Cash_In_Hand + "<br>Advance with Revenue : " + _Advance_With_Revenue + "</small>";
    }
}