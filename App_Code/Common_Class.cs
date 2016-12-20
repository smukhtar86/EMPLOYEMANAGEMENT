using System;
using System.Data;
using System.Configuration;  
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts; 
using System.Data.SqlClient;

/// <summary>
/// Summary description for Common_Class
/// </summary>
public class Common_Class
{
    Connection_Class objconn = new Connection_Class();
    static Connection_Class con = new Connection_Class();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da;
    DataSet ds;
    string date_insert = "";

    SqlConnection OrbitCon = null;
    public static string strConnectionString = "";
    public Common_Class()
    {
       
        strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString();
        OrbitCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString());
    }
    public string fillgrid(string qry, GridView grid_show)
    {
        string msg = "";
        try
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                da = new SqlDataAdapter(qry, con);
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid_show.DataSource = ds;
                    grid_show.DataBind();
                    grid_show.Visible = true;
                    msg = "";
                }
                else
                {
                    grid_show.Visible = false;
                    msg = "No Data Found ...!!";
                }
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message.ToString();

        }
        return msg;
    }

    public void Filldatalist(string Table, string Fields, string Cond, DataList dl)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {

                da = new SqlDataAdapter("select " + Fields + " from " + Table + " " + Cond, con);
                ds = new DataSet();
                da.Fill(ds, Table);
                dl.DataSource = ds;
                dl.DataBind();
            }
        }
        catch (Exception ee)
        {
        }
    }

    public void Filldatalist_Proc(string Proc, DataList dl)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                da = new SqlDataAdapter(Proc, con);
                ds = new DataSet();
                da.Fill(ds, Proc);
                dl.DataSource = ds;
                dl.DataBind();
            }
        }
        catch (Exception ee)
        {
        }
    }

    public static bool Bind_DataList(DataList gv, DataSet ds)
    {
        try
        {
            gv.DataSource = ds;
            gv.DataBind();
            return true;
        }
        catch (Exception ee)
        {
            return false;
        }
    }

    public DataTable filldatatable(string que)
    {
        DataTable dt = new DataTable();

        //Start: Commented by Ramesh, dt:27/05/2014
        //if (objconn.connection.State == ConnectionState.Closed)
        //{
        //    objconn.connection.Open();
        //}
        //try
        //{
        //    SqlDataAdapter da = new SqlDataAdapter(que, objconn.connection);
        //    da.Fill(dt);
        //    return dt;
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        //finally
        //{
        //    objconn.connection.Close();
        //}

        //Start: Commented by Ramesh, dt:27/05/2014

        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(que, con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //return dt;
    }



    public string convertdatetime(string date)
    {
        //DateTime date_insert;
        try
        {
            string[] arr_date = date.Split('/');
            date_insert = arr_date[2].ToString() + "/" + arr_date[1].ToString() + "/" + arr_date[0].ToString();
        }
        catch (Exception ex)
        {
            date_insert = "1900/01/01";
        }
        return date_insert;
    }

    //public string convertdatetime(string ddmmyy)
    //{
    //    String yymmdd = "";
    //    try
    //    {
    //        String dob = ddmmyy;
    //        String[] Segments = dob.Split('/');
    //        String dd = Segments[0];
    //        String mm = Segments[1];
    //        String yy = Segments[2];
    //        yymmdd = yy + "/" + mm + "/" + dd;
    //    }
    //    catch (Exception)
    //    {

    //    }
    //    return yymmdd;
    //}

    public string execute_scalar(string query)
    {
        string value = "";
        //Start: Commented by Ramesh, dt:27/05/2014
        //if (objconn.connection.State == ConnectionState.Closed)
        //{
        //    objconn.connection.Open();
        //}
        //try
        //{
        //    SqlCommand cmd = new SqlCommand(query, objconn.connection);
        //    value = (cmd.ExecuteScalar()).ToString();
        //    return value;
        //}
        //catch (Exception ex)
        //{

        //}
        //return value;
        //End: Commented by Ramesh, dt:27/05/2014
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                value = (cmd.ExecuteScalar()).ToString();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return value;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw ex;
            }
        }
    }

    public DataSet _Get_Dataset(string query)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                return ds; // throw;
            }
        }
    }
    public void BindDropDownList1(DropDownList ddl, DataTable dt, string DataValueField, string DataTextField, string Index0Value)
    {
        ddl.DataTextField = DataTextField;
        ddl.DataValueField = DataValueField;
        ddl.DataSource = dt;
        ddl.DataBind();
        ddl.Items.Insert(0, Index0Value);
    }

    public string NumberToText(int number)
    {
        if (number == 0)
        {
            return "Zero";
        }

        else if (number == -2147483648)
        {
            return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";
        }
        else
        {
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };
            num[0] = number % 1000; // units 
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands 
            num[3] = number / 10000000; // crores 
            num[2] = num[2] - 100 * num[3]; // lakhs 
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0)
                    continue;
                u = num[i] % 10; // ones 
                t = num[i] / 10;
                h = num[i] / 100; // hundreds 
                t = t - 10 * h; // tens 
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {

                    if (h > 0 || i == 0)
                    {

                        if ((h > 0) && (i == 0))
                        {
                            sb.Append("and ");
                        }
                    }
                    if (t == 0)
                    {
                        sb.Append(words0[u]);
                    }
                    else if (t == 1)
                    {
                        sb.Append(words1[u]);
                    }
                    else
                    {
                        sb.Append(words2[t - 2] + words0[u]);
                    }
                }

                if (i != 0) sb.Append(words3[i - 1]);

            }
            return sb.ToString().TrimEnd() + " Rupees Only";
        }
    }



    public static void Desable_Enable_textbox(TextBox[] Text, string txt_val)
    {
        if (txt_val == "Cancel")
        {
            foreach (TextBox tb in Text)
            {
                tb.Enabled = false;
            }
        }
        else
        {
            foreach (TextBox tb in Text)
            {
                tb.Enabled = true;
            }
        }
    }


    public static void Desable_Enable_dropdown(DropDownList[] drp, string txt_val)
    {
        if (txt_val == "Cancel")
        {
            foreach (DropDownList db in drp)
            {
                db.Enabled = false;
            }
        }
        else
        {
            foreach (DropDownList db in drp)
            {
                db.Enabled = true;
            }
        }
    }

    public static void clear_Label_value(Label[] Text)
    {
        foreach (Label tb in Text)
        {
            tb.Text = "";
        }
    }


    public static void cleardropdown(DropDownList[] drp)
    {
        foreach (DropDownList db in drp)
        {
            db.SelectedIndex = 0;
        }
    }

    public static void cleartextbox(TextBox[] txt)
    {
        foreach (TextBox tx in txt)
        {
            tx.Text = "";
        }
    }

    public int ExecuteQuery(string query)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                int x = 0;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                x = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return x;
            }
        }
        catch (Exception ee)
        {
            return 0;
        }
    }

    //..................... Return Command ............................
    public static SqlCommand ReturnCommand_with_separater(string SP_Name, string Parameter, string Fields)
    {
        // Start: Commented by Ramesh, dt:27/05/2014
        //string[] Param = Parameter.Split('/');
        //string[] Field = Fields.Split('/');
        //SqlCommand cmd = new SqlCommand();
        //try
        //{

        //    cmd = new SqlCommand(SP_Name, con.connection);
        //    cmd.Connection = con.connection;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    if (Param.Length == Field.Length)
        //    {
        //        for (int x = 0; x < Param.Length; x++)
        //        {
        //            if (Field[x].ToUpper() == "NULL")
        //            {
        //                cmd.Parameters.AddWithValue(Param[x].ToString(), DBNull.Value);
        //            }
        //            else if (Field[x].ToUpper() == "")
        //            {
        //                cmd.Parameters.AddWithValue(Param[x].ToString(), DBNull.Value);
        //            }
        //            else
        //            {
        //                cmd.Parameters.AddWithValue(Param[x].ToString(), Field[x].ToString());
        //            }
        //        }
        //    }
        //    return cmd;
        //}
        //catch (Exception ee)
        //{
        //    return cmd;
        //}
        //Start: Commented by Ramesh, dt:27/05/2014

        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            SqlCommand cmd = null;
            try
            {
                string[] Param = Parameter.Split('/');
                string[] Field = Fields.Split('/');

                cmd = new SqlCommand(SP_Name, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Param.Length == Field.Length)
                {
                    for (int x = 0; x < Param.Length; x++)
                    {
                        if (Field[x].ToUpper() == "NULL")
                        {
                            cmd.Parameters.AddWithValue(Param[x].ToString(), DBNull.Value);
                        }
                        else if (Field[x].ToUpper() == "")
                        {
                            cmd.Parameters.AddWithValue(Param[x].ToString(), DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Param[x].ToString(), Field[x].ToString());
                        }
                    }
                }
                return cmd;
            }
            catch (Exception ee)
            {
                return cmd;
            }
        }
    }

    public SqlCommand ReturnCommand(string SP_Name, string Parameter, string Fields, char separator)
    {       
        SqlCommand cmd = null;
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            try
            {
                string[] Param = Parameter.Split(separator);
                string[] Field = Fields.Split(separator);

                cmd = new SqlCommand(SP_Name, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Param.Length == Field.Length)
                {
                    for (int x = 0; x < Param.Length; x++)
                    {
                        if (Field[x].ToUpper() == "NULL")
                        {
                            cmd.Parameters.AddWithValue(Param[x].ToString(), DBNull.Value);
                        }
                        else if (Field[x].ToUpper() == "")
                        {
                            cmd.Parameters.AddWithValue(Param[x].ToString(), DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Param[x].ToString(), Field[x].ToString());
                        }
                    }
                }

                return cmd;
            }
            catch (Exception ee)
            {
                return cmd;
            }
        }
    }


    public static SqlCommand ReturnCommand_withDatatableType(string SP_Name, string Parameter, string Fields, string tt_parameter_nm, DataTable dt_parameter_val, char separator)
    {
        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            string[] Param = Parameter.Split(separator);
            string[] Field = Fields.Split(separator);
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand(SP_Name, con);

                cmd.CommandType = CommandType.StoredProcedure;
                if (Param.Length == Field.Length)
                {
                    for (int x = 0; x < Param.Length; x++)
                    {
                        if (Field[x].ToUpper() == "NULL")
                        {
                            cmd.Parameters.AddWithValue(Param[x].ToString(), DBNull.Value);
                        }
                        else if (Field[x].ToUpper() == "")
                        {
                            cmd.Parameters.AddWithValue(Param[x].ToString(), DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(Param[x].ToString(), Field[x].ToString());
                        }
                    }
                }
                cmd.Parameters.AddWithValue(tt_parameter_nm, dt_parameter_val);
                return cmd;
            }
            catch (Exception ee)
            {
                return cmd;
            }
        }

    }

    public bool ExecuteCmd(SqlCommand cmd)
    {
        //Start: Commented by ramesh, dt:27/may/2014
        //SqlConnection conn = new SqlConnection();
        //try
        //{
        //    conn = con.connection;
        //    cmd.Connection = conn;
        //    //conn.Open();
        //    int res = cmd.ExecuteNonQuery();
        //    //conn.Close();
        //    if (res == 1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //catch (Exception ee)
        //{
        //    conn.Close();
        //    return false;
        //}
        //Start: Commented by ramesh, dt:27/may/2014

        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Connection = con;
                int res = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return false;
            }
        }
    }

    public string ExecuteCmd_WithOutput(SqlCommand cmd, string Out)
    {
        //Start: Commented by Ramesh ,dt:27/may/2014
        //SqlConnection conn = new SqlConnection();
        //try
        //{
        //    conn = con.connection;
        //    cmd.Connection = conn;
        //    SqlParameter par1 = new SqlParameter(Out, SqlDbType.VarChar, 200);
        //    par1.Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add(par1);

        //    cmd.ExecuteNonQuery();
        //    string returnValue = Convert.ToString(cmd.Parameters[Out].Value);

        //    conn.Close();

        //    return returnValue;

        //}
        //catch (Exception ee)
        //{
        //    conn.Close();
        //    return "ERROR";
        //}
        //End: Commented by Ramesh ,dt:27/may/2014

        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            try
            {
                cmd.Connection = con;
                SqlParameter par1 = new SqlParameter(Out, SqlDbType.VarChar, 200);
                par1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(par1);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                string returnValue = Convert.ToString(cmd.Parameters[Out].Value);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return returnValue;
            }
            catch (Exception ee)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return "ERROR";
            }
        }

    }

    public string[] ExecuteCmd_WithMultipleOutput(SqlCommand cmd, string MOut)
    {
        //Start: Commented by ramesh Dt: 27/may/2014
        //string[] ArrOutParam = MOut.Split('^');
        //string[] arrreturnValue = new string[ArrOutParam.Length];
        //SqlConnection conn = new SqlConnection();
        //try
        //{
        //    conn = con.connection;
        //    cmd.Connection = conn;
        //    for (int i = 0; ArrOutParam.Length > i; i++)
        //    {
        //        string parNm = "par" + i.ToString();
        //        SqlParameter paramNm = new SqlParameter { ParameterName = parNm };
        //        paramNm = new SqlParameter(ArrOutParam[i], SqlDbType.VarChar, 400) { Direction = ParameterDirection.Output };
        //        cmd.Parameters.Add(paramNm);
        //    }
        //    cmd.ExecuteNonQuery();

        //    for (int j = 0; ArrOutParam.Length > j; j++)
        //    {
        //        arrreturnValue[j] = Convert.ToString(cmd.Parameters[ArrOutParam[j]].Value);
        //    }

        //    conn.Close();

        //    return arrreturnValue;

        //}
        //catch (Exception ee)
        //{
        //    arrreturnValue[0] = "ERROR";
        //    conn.Close();
        //    return arrreturnValue;
        //}
        //return arrreturnValue;
        //End: Commented by ramesh Dt: 27/may/2014

        using (SqlConnection con = new SqlConnection(strConnectionString))
        {
            string[] ArrOutParam = MOut.Split('^');
            string[] arrreturnValue = new string[ArrOutParam.Length];
            try
            {
                cmd.Connection = con;
                for (int i = 0; ArrOutParam.Length > i; i++)
                {
                    string parNm = "par" + i.ToString();
                    SqlParameter paramNm = new SqlParameter { ParameterName = parNm };
                    paramNm = new SqlParameter(ArrOutParam[i], SqlDbType.VarChar, 400) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(paramNm);
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                for (int j = 0; ArrOutParam.Length > j; j++)
                {
                    arrreturnValue[j] = Convert.ToString(cmd.Parameters[ArrOutParam[j]].Value);
                }
                return arrreturnValue;
            }
            catch (Exception ee)
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                arrreturnValue[0] = "ERROR";
                return arrreturnValue;
            }
        }
    }

    public DataSet RetDataset_DataAdapter(SqlCommand cmd)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.SelectCommand.Connection = con;
                    da.Fill(ds);
                }
            }
            return ds;
        }
        catch (Exception ee)
        {
            return ds;
        }
    }

    public bool Bind_DropDownList(DataTable dt, string ValueField, string TextField, DropDownList ddl)
    {
        try
        {
            ddl.DataSource = dt;
            ddl.DataValueField = ValueField;
            ddl.DataTextField = TextField;
            ddl.DataBind();
            return true;
        }
        catch (Exception ee)
        {
            return false;
        }
    }

    public SqlDataAdapter Ret_DataAdapter(SqlCommand cmd, SqlConnection con)
    {
        SqlDataAdapter da = null;
        try
        {
            using (con = new SqlConnection(strConnectionString))
            {
                da = new SqlDataAdapter(cmd);
                da.SelectCommand.Connection = con;
                return da;
            }
        }
        catch (Exception ee)
        {
            return da;
        }
    }


    //..................... Fill Country ............................

    public void fil_DropDown_Country(DropDownList DropDown_Country)
    {
        try
        {
            DropDown_Country.Items.Clear();
            string query_Rtv_Contry = "SELECT CNT_ID,CNT_NAME  FROM  ENM_COUNTRY ORDER BY CNT_NAME";

            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query_Rtv_Contry, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DropDown_Country.DataTextField = "CNT_NAME";
                    DropDown_Country.DataValueField = "CNT_ID";
                    DropDown_Country.DataSource = dt;
                    DropDown_Country.DataBind();
                    DropDown_Country.Items.Insert(0, "Select");
                }
                else
                {
                    DropDown_Country.Items.Insert(0, "Select");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    //..................... Fill State ............................

    public void fil_DropDown_State(DropDownList DropDown_State, int cnt_Id)
    {
        try
        {
            DropDown_State.Items.Clear();
            string query_Rtv_Contry = String.Format("SELECT ST_ID,ST_NAME  FROM  ENM_STATE WHERE ST_CNT_ID='{0}' ORDER BY ST_NAME", cnt_Id);
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query_Rtv_Contry, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DropDown_State.DataTextField = "ST_NAME";
                    DropDown_State.DataValueField = "ST_ID";
                    DropDown_State.DataSource = dt;
                    DropDown_State.DataBind();
                    DropDown_State.Items.Insert(0, "Select");
                }
                else
                {
                    DropDown_State.Items.Insert(0, "Select");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //finally
        //{
        //    objconn.connection.Close();
        //}
    }

    //..................... Fill  City............................

    public void fil_DropDown_City(DropDownList DropDown_City, int st_Id)
    {
        try
        {
            DropDown_City.Items.Clear();
            string query_Rtv_Contry = String.Format("SELECT CT_ID,CT_NAME  FROM  ENM_CITY WHERE CT_ST_ID='{0}' ORDER BY CT_NAME", st_Id);
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query_Rtv_Contry, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DropDown_City.DataTextField = "CT_NAME";
                    DropDown_City.DataValueField = "CT_ID";
                    DropDown_City.DataSource = dt;
                    DropDown_City.DataBind();
                    DropDown_City.Items.Insert(0, "Select");
                }
                else
                {
                    DropDown_City.Items.Insert(0, "Select");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    //..................... Fill  City............................

    public void fil_DropDown_Bank(DropDownList DropDown_Bank)
    {
        try
        {
            DropDown_Bank.Items.Clear();
            string query_Rtv_Contry = "SELECT ENM_SLNO,ENM_BANK_NAME  FROM  ENM_BANK ORDER BY ENM_BANK_NAME";
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query_Rtv_Contry, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DropDown_Bank.DataTextField = "ENM_BANK_NAME";
                    DropDown_Bank.DataValueField = "ENM_SLNO";
                    DropDown_Bank.DataSource = dt;
                    DropDown_Bank.DataBind();
                    DropDown_Bank.Items.Insert(0, "Select");
                }
                else
                {
                    DropDown_Bank.Items.Insert(0, "Select");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    //..................... Fill Distributor ............................

    public void fil_DropDown_Distributor(DropDownList DropDown_Distributor)
    {
        try
        {
            DropDown_Distributor.Items.Clear();
            string query_Rtv_Distributor = "SELECT DIS_ID,DIS_NAME+' ('+CT_NAME+')' AS DIS_NAME FROM VW_DISTRIBUTOR_MST ORDER BY DIS_NAME";
            using (SqlConnection con = new SqlConnection(strConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query_Rtv_Distributor, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DropDown_Distributor.DataTextField = "DIS_NAME";
                    DropDown_Distributor.DataValueField = "DIS_ID";
                    DropDown_Distributor.DataSource = dt;
                    DropDown_Distributor.DataBind();
                    DropDown_Distributor.Items.Insert(0, "Select");
                }
                else
                {
                    DropDown_Distributor.Items.Insert(0, "Select");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objconn.connection.Close();
        }
    }
}