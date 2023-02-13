using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebColiber.App_GlobalResources;


namespace WebColiber
{
    public partial class Basket : System.Web.UI.Page
    {
        List<string> orders;
        List<string> ordersMag;
        List<string> ordersNor;

        List<string> ordersIdZasob;
        //List<string> ordersMagIdZasob;
        bool lSkipNor = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnDelete.Attributes.Add("onClick", "Delete(); return false;");
            //btnOrder.Attributes.Add("onClick", "self.location = \"Order.aspx\"; return false;");
            btnNormy.Attributes.Add("onClick", "Normy(); return false;");
            btnNormy.Visible = false;

            orders = new List<string>();
            orders = Session["orders"] as List<string>;

            ordersMag = new List<string>();
            ordersMag = Session["ordersMag"] as List<string>;

            ordersNor = new List<string>();
            ordersNor = Session["ordersNor"] as List<string>;

            if (ordersMag == null && orders == null && ordersNor == null)
            {
                lblComment.Text = Language.basketIsEmpty;
                lblComment.Visible = true;
                btnDelete.Visible = false;
                btnOrder.Visible = false;                
            }
            else if ((ordersMag != null && ordersMag.Count == 0 ) || (orders != null && orders.Count == 0) || (ordersNor != null && ordersNor.Count == 0))
            {
                lblComment.Text = Language.basketIsEmpty;
                lblComment.Visible = true;                
                btnDelete.Visible = false;
                btnOrder.Visible = false;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(Settings.ColiberConnectionString))
                {
                    conn.Open();

                    if (orders != null && orders.Count > 0)
                    {
                        SqlConnection conn2 = new SqlConnection(Settings.WypozyczalniaConnectionString);

                        string query = string.Format(" SELECT LTRIM(RTRIM(tytul_gl)) + ISNULL(' : ' + (SELECT LTRIM(RTRIM(t_dodatk)) FROM dbo.t_dodatk WHERE dbo.t_dodatk.kod = dbo.ksiazki_new.kod), '') AS tytul_gl, kod, " +
                                        " ISNULL((SELECT TOP 1 '" + Language.borrowed + "' FROM {0}.dbo.w2_wypozyczenia WHERE data_zwrot IS NULL AND uzytk_id = @uzytk_id AND zasob_id IN (SELECT zasob_id FROM {0}.dbo.w2_zasoby_t WHERE CAST(obcy_id AS int) IN (SELECT id_zasob FROM dbo.zasoby WHERE dbo.zasoby.kod = dbo.ksiazki_new.kod))), " +
                                        " (SELECT TOP 1 '" + Language.ordered + "' FROM {0}.dbo.w2_zamowienia WHERE stan_zamow IN ('0', '3') AND uzytk_id = @uzytk_id AND zasob_id IN (SELECT zasob_id FROM {0}.dbo.w2_zasoby_t WHERE CAST(obcy_id AS int) IN (SELECT id_zasob FROM dbo.zasoby WHERE dbo.zasoby.kod = dbo.ksiazki_new.kod)))) AS stan " +
                                        " FROM dbo.ksiazki_new " +
                                        " WHERE kod IN (", conn2.Database);

                        for (int i = 0; i < orders.Count; i++)
                        {
                            if (i < orders.Count - 1)
                                query += "@kod" + i + ",";
                            else
                                query += "@kod" + i;
                        }

                        query += ") ORDER BY tytul_gl; ";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            for (int i = 0; i < orders.Count; i++)
                            {
                                cmd.Parameters.AddWithValue("@kod" + i, orders[i]);
                            }

                            cmd.Parameters.AddWithValue("@uzytk_id", HttpContext.Current.Session["UserID"]);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                DataTable Dt = new DataTable();
                                Dt.Load(reader);

                                ResultsO.Text = "<b>" + Language.books + "</b><br /><br /><table border=1 frame='void' rules='all' class=\"table table-striped table-bordered table-hover table-condensed\">";

                                ResultsO.Text += "<tr>";
                                //ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width: 20px;'>L.p.</td>";

                                //if (HttpContext.Current.Session["CanOrder"] != null && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string))
                                ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width:120px'>" + Language.toDelete + "</td>";
                                ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width:120px'>" + Language.status + "</td>";

                                ResultsO.Text += "<td align=\"left\" style='padding-left: 10px; padding-right: 10px;'>" + Language.description + "</td>";
                                ResultsO.Text += "</tr>";

                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    ResultsO.Text += "<tr>";
                                    //ResultsO.Text += "<td align='center' valign='top'>" + (i + 1) + "</td>";

                                    //if (HttpContext.Current.Session["CanOrder"] != null && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string))
                                    ResultsO.Text += string.Format("<td align='center'><input id=\"Checkboxb{0}\" type=\"checkbox\" OnClick=\"lookCheckboxes(this);\"/></td>", Dt.Rows[i]["kod"].ToString());

                                    ResultsO.Text += string.Format("<td align='center' valign='top'>{0}</td>", Dt.Rows[i]["stan"].ToString());
                                    ResultsO.Text += string.Format("<td align='left' valign='top'>{0}</td>", Dt.Rows[i]["tytul_gl"].ToString());
                                    ResultsO.Text += "</tr>";
                                }

                                ResultsO.Text += "</table>";
                                lSkipNor = true;
                            }
                        }
                    }

                    if (ordersMag != null && ordersMag.Count > 0)
                    {
                        SqlConnection conn2 = new SqlConnection(Settings.WypozyczalniaConnectionString);
                        conn2.Open();

                        string query = string.Format(" SELECT zasob_id, LTRIM(RTRIM(opis)) as tytul, " +
                                       //" ISNULL((SELECT TOP 1 'Zamówiony' FROM dbo.w2_zamowienia WHERE stan_zamow IN ('0', '3') AND uzytk_id = @uzytk_id AND zasob_id IN (SELECT zasob_id FROM dbo.w2_zasoby_t WHERE CAST(obcy_id AS int) IN (SELECT id_zasob FROM {0}.dbo.cza_zas WHERE id_czasop IN (select id_czasop FROM {0}.dbo.cza_zas WHERE id_zasob IN (SELECT CAST(obcy_id AS int) FROM dbo.w2_zasoby_t WHERE zasob_id = dbo.w2_zasoby_t.zasob_id))))), " +
                                       //" (SELECT TOP 1 'Wypożyczony' FROM dbo.w2_wypozyczenia WHERE data_zwrot IS NULL AND uzytk_id = @uzytk_id AND zasob_id IN (SELECT zasob_id FROM dbo.w2_zasoby_t WHERE CAST(obcy_id AS int) IN (SELECT id_zasob FROM {0}.dbo.cza_zas WHERE id_czasop IN (select id_czasop FROM {0}.dbo.cza_zas WHERE id_zasob IN (SELECT CAST(obcy_id AS int) FROM dbo.w2_zasoby_t WHERE zasob_id = dbo.w2_zasoby_t.zasob_id)))))) " +
                                       " ISNULL((SELECT TOP 1 '" + Language.borrowed + "' FROM dbo.w2_wypozyczenia WHERE data_zwrot IS NULL AND uzytk_id = @uzytk_id AND zasob_id = dbo.w2_zasoby_t.zasob_id), " +
                                       " (SELECT TOP 1 '" + Language.ordered + "' FROM dbo.w2_zamowienia WHERE stan_zamow IN ('0', '3') AND uzytk_id = @uzytk_id AND zasob_id = dbo.w2_zasoby_t.zasob_id)) " +
                                       " AS stan " +
                                       " FROM dbo.w2_zasoby_t WHERE zasob_id IN ( ", conn.Database);

                        for (int i = 0; i < ordersMag.Count; i++)
                        {
                            if (i < ordersMag.Count - 1)
                                query += "@kod" + i + ",";
                            else
                                query += "@kod" + i;
                        }

                        query += ") ORDER BY opis; ";

                        using (SqlCommand cmd = new SqlCommand(query, conn2))
                        {
                            for (int i = 0; i < ordersMag.Count; i++)
                            {
                                cmd.Parameters.AddWithValue("@kod" + i, ordersMag[i]);
                            }

                            cmd.Parameters.AddWithValue("@uzytk_id", HttpContext.Current.Session["UserID"]);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                DataTable Dt = new DataTable();
                                Dt.Load(reader);

                                ResultsO.Text += "<b>" + Language.magazines + "</b><br /><br /><table border=1 frame='void' rules='all' class=\"table table-striped table-bordered table-hover table-condensed\">";

                                ResultsO.Text += "<tr>";
                                //ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width: 20px;'>L.p.</td>";

                                //if (HttpContext.Current.Session["CanOrder"] != null && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string))
                                ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width:120px'>" + Language.toDelete + "</td>";
                                ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width:140px'>Status</td>";

                                ResultsO.Text += "<td align=\"left\" style='padding-left: 10px; padding-right: 10px;'>" + Language.description + "</td>";
                                ResultsO.Text += "</tr>";

                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    ResultsO.Text += "<tr>";
                                    //ResultsO.Text += "<td align='center' valign='top'>" + (i + 1) + "</td>";

                                    //if (HttpContext.Current.Session["CanOrder"] != null && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string))
                                    ResultsO.Text += "<td align='center'><input id=\"Checkboxm" + Dt.Rows[i]["zasob_id"].ToString() + "\" type=\"checkbox\" OnClick=\"lookCheckboxes(this);\"/></td>";

                                    ResultsO.Text += string.Format("<td align='center' valign='top'>{0}</td>", Dt.Rows[i]["stan"].ToString());
                                    ResultsO.Text += "<td align='left' valign='top'>" + Dt.Rows[i]["tytul"].ToString() + "</td>";
                                    ResultsO.Text += "</tr>";
                                }

                                ResultsO.Text += "</table>";
                                lSkipNor = true;
                            }
                        }
                    }

                    if (ordersNor != null && ordersNor.Count > 0 && !lSkipNor)
                    {
                        SqlConnection conn2 = new SqlConnection(Settings.WypozyczalniaConnectionString);
                        conn2.Open();

                        /*
                        string query = string.Format(" SELECT zasob_id, LTRIM(RTRIM(opis)) as tytul, " +
                                       " ISNULL((SELECT TOP 1 '" + Language.borrowed + "' FROM dbo.w2_wypozyczenia WHERE data_zwrot IS NULL AND zasob_id = dbo.w2_zasoby_t.zasob_id), " +
                                       " (SELECT TOP 1 '" + Language.ordered + "' FROM dbo.w2_zamowienia WHERE stan_zamow IN ('0', '3') AND uzytk_id = " + HttpContext.Current.Session["UserID"].ToString() + " AND zasob_id = dbo.w2_zasoby_t.zasob_id)) " +
                                       " AS stan, Sygnatura " +
                                       " FROM dbo.w2_zasoby_t WHERE kod IN ( " , conn.Database);
                        for (int i = 0; i < ordersNor.Count; i++)
                        {
                            if (i < ordersNor.Count - 1)
                                query += ordersNor[i].ToString() + ",";
                            else
                                query += ordersNor[i].ToString();
                        }
                        */

                        string query = string.Format(" SELECT zasob_id, LTRIM(RTRIM(opis)) as tytul, " +
                                       " ISNULL((SELECT TOP 1 '" + Language.borrowed + "' FROM dbo.w2_wypozyczenia WHERE data_zwrot IS NULL AND zasob_id = dbo.w2_zasoby_t.zasob_id), " +
                                       " (SELECT TOP 1 '" + Language.ordered + "' FROM dbo.w2_zamowienia WHERE stan_zamow IN ('0', '3') AND uzytk_id = @uzytk_id AND zasob_id = dbo.w2_zasoby_t.zasob_id)) " +
                                       " AS stan, Sygnatura " +
                                       " FROM dbo.w2_zasoby_t WHERE kod IN ( ", conn.Database);

                        for (int i = 0; i < ordersNor.Count; i++)
                        {
                            if (i < ordersNor.Count - 1)
                                query += "@kod" + i + ",";
                            else
                                query += "@kod" + i;
                        }

                        query += ") and grupa_id = 4 ORDER BY opis; ";

                        using (SqlCommand cmd = new SqlCommand(query, conn2))
                        {
                            for (int i = 0; i < ordersNor.Count; i++)
                            {
                                cmd.Parameters.AddWithValue("@kod" + i, ordersNor[i]);
                            }

                            cmd.Parameters.AddWithValue("@uzytk_id", HttpContext.Current.Session["UserID"]);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                DataTable Dt = new DataTable();
                                Dt.Load(reader);
//                                ResultsO.Text += "<b>" + query + "</b>";
                                ResultsO.Text += "<b>" + "Normy" + "</b><br /><br /><table border=1 frame='void' rules='all' class=\"table table-striped table-bordered table-hover table-condensed\">";

                                ResultsO.Text += "<tr>";
                                //ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width: 20px;'>L.p.</td>";

                                //if (HttpContext.Current.Session["CanOrder"] != null && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string))
                                ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width:120px'>Zaznacz</td>";
                                ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width:140px'>Status</td>";

                                ResultsO.Text += "<td align=\"left\" style='padding-left: 10px; padding-right: 10px;'>" + Language.description + "</td>";
                                ResultsO.Text += "<td align=\"left\" style='padding-left: 10px; padding-right: 10px;'>Sygnatura</td>";
                                ResultsO.Text += "</tr>";

                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {
                                    ResultsO.Text += "<tr>";
                                    //ResultsO.Text += "<td align='center' valign='top'>" + (i + 1) + "</td>";

                                    //if (HttpContext.Current.Session["CanOrder"] != null && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string))
                                    if (Dt.Rows[i]["stan"].ToString()=="") ResultsO.Text += "<td align='center'><input id=\"Checkbox" + Dt.Rows[i]["zasob_id"].ToString() + "\" type=\"checkbox\" OnClick=\"lookCheckboxes(this);\"/></td>";
                                    else ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width:120px'></td>";
                                    ResultsO.Text += string.Format("<td align='center' valign='top'>{0}</td>", Dt.Rows[i]["stan"].ToString());
                                    ResultsO.Text += "<td align='left' valign='top'>" + Dt.Rows[i]["tytul"].ToString() + "</td>";
                                    ResultsO.Text += "<td align='left' valign='top'>" + Dt.Rows[i]["sygnatura"].ToString() + "</td>";
                                    ResultsO.Text += "</tr>";
                                }

                                ResultsO.Text += "</table>";
                                btnDelete.Visible = false;
                                btnOrder.Visible = false;
                                btnNormy.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["Banned"] != null && (HttpContext.Current.Session["Banned"] as string).ToLower() == "true")
            {
                //string script = "alert('"+ Language.cannotOrder + "');";
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);

                //return;
            }

            GetIdZasob();
            Response.Redirect("Order.aspx");

            /*if (Settings.OrderMethod == 0)
            {
                GetIdZasob();
                //OrderViaDb();
            }
            else if (Settings.OrderMethod == 1)
            {
                GetIdZasob();

                if (ordersIdZasob.Count == 0)// && ordersIdZasob[0] != "")
                    Response.Redirect("OrderSent.aspx");
                else
                    Response.Redirect("Order.aspx");
            }
            else if (Settings.OrderMethod == 2)
            {
                GetIdZasob();

                if (ordersIdZasob.Count == 0)// && ordersIdZasob[0] != "")
                    Response.Redirect("OrderSent.aspx");
                else
                {
                    //OrderViaDb();
                    Response.Redirect("Order.aspx");
                }
            }*/
        }

        #region GetIdZasob
        protected void GetIdZasob()
        {
            //ordersIdZasob = orders;

            //using (SqlConnection Connection = new SqlConnection(Settings.ColiberConnectionString))
            using (SqlConnection Connection = new SqlConnection(Settings.WypozyczalniaConnectionString))
            {
                Connection.Open();

                ordersIdZasob = new List<string>();

                SqlConnection DatabaseConnection = new SqlConnection(Settings.ColiberConnectionString);

                if (orders != null)
                {
                    foreach (string Code in orders)
                    {
                        //string Query = "SELECT id_zasob FROM zasoby WHERE kod = " + Code;
                        /*string Query = "SELECT zasob_id FROM w2_zasoby_t " +
                                        "INNER JOIN " + DatabaseConnection.Database + ".dbo.zasoby ON " + DatabaseConnection.Database + ".dbo.zasoby.id_zasob = w2_zasoby_t.obcy_id " +
                                        " WHERE rodzaj_zas = 1 AND kod = " + Code;*/

                        string Query = "DECLARE @id int = null; " +

                                        "SELECT TOP 1 @id = zasob_id FROM dbo.w2_zasoby_t  " +
                                        "INNER JOIN  " + DatabaseConnection.Database + ".dbo.zasoby ON  " + DatabaseConnection.Database + ".dbo.zasoby.id_zasob = dbo.w2_zasoby_t.obcy_id  " +
                                       // "WHERE rodzaj_zas = 1 AND kod =  " + Code + " and wypozyczony = 0 " +
                                        "WHERE rodzaj_zas = 1 AND zasoby.kod = @kod and wypozyczony = 0 ORDER BY syg; " +

                                        "IF @id IS NULL " +
                                        "	SELECT TOP 1 @id = zasob_id FROM dbo.w2_zasoby_t  " +
                                        "	INNER JOIN  " + DatabaseConnection.Database + ".dbo.zasoby ON  " + DatabaseConnection.Database + ".dbo.zasoby.id_zasob = dbo.w2_zasoby_t.obcy_id  " +
                                        //"	WHERE rodzaj_zas = 1 AND kod =  " + Code +
                                        "	WHERE rodzaj_zas = 1 AND zasoby.kod = @kod ORDER BY syg; " +

                                        "SELECT @id as id; ";                        

                        using (SqlCommand Command = new SqlCommand(Query, Connection))
                        {
                            Command.Parameters.AddWithValue("@kod", Code);

                            using (SqlDataReader Reader = Command.ExecuteReader())
                            {
                                while (Reader.Read())
                                    ordersIdZasob.Add(Code + ";" + Reader.GetValue("id").ToString());
                            }
                        }
                    }
                }

                if (ordersMag != null)
                {
                    foreach (string Zas_id in ordersMag)
                    {
                        ordersIdZasob.Add("-1;" + Zas_id);
                    }
                }
            }

            List<string> MagazinesIdZasobList = new List<string>();
            string[] tempM = new string[2];
            List<string> Magazines = new List<string>();

            foreach (string a in ordersIdZasob)
            {
                tempM = a.Split(';');

                if (tempM[0] == "-1")
                    MagazinesIdZasobList.Add(tempM[1]);
            }

            using (SqlConnection Connection = new SqlConnection(Settings.WypozyczalniaConnectionString))
            {
                Connection.Open();

                string[] Temp;

                for (int i = 0; i < ordersIdZasob.Count; i++)
                {
                    Temp = ordersIdZasob[i].Split(';');

                    //string Query = "SELECT COUNT(*) FROM w2_wypozyczenia WHERE zasob_id = " + Temp[1].ToString() + " AND uzytk_id = " + HttpContext.Current.Session["UserID"] + " AND data_zwrot IS NULL";
                    string Query = "SELECT COUNT(*) FROM w2_wypozyczenia WHERE zasob_id = @zasob_id AND uzytk_id = @uzytk_id AND data_zwrot IS NULL; ";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@zasob_id", Temp[1].ToString().Trim());
                        Command.Parameters.AddWithValue("@uzytk_id", HttpContext.Current.Session["UserID"]);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                if (Int32.Parse(Reader.GetValue(0).ToString()) != 0)
                                {
                                    ordersIdZasob.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < ordersIdZasob.Count; i++)
                {
                    Temp = ordersIdZasob[i].Split(';');

                    //string Query = "SELECT COUNT(*) FROM w2_zamowienia WHERE zasob_id = " + Temp[1].ToString().Trim() + " AND uzytk_id = " + HttpContext.Current.Session["UserID"] + " AND data_realiz IS NULL";// " AND data_realiz IS NULL";
                    string Query = "SELECT COUNT(*) FROM w2_zamowienia WHERE zasob_id = @zasob_id AND uzytk_id = @uzytk_id AND data_realiz IS NULL; ";// " AND data_realiz IS NULL";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@zasob_id", Temp[1].ToString().Trim());
                        Command.Parameters.AddWithValue("@uzytk_id", HttpContext.Current.Session["UserID"]);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                if (Int32.Parse(Reader.GetValue(0).ToString()) != 0)
                                {
                                    ordersIdZasob.RemoveAt(i);

                                    i--;
                                }
                            }
                        }
                    }
                }


                List<string> CodesTemp = new List<string>();
                List<string> IdTemp = new List<string>();                

                for (int i = 0; i < ordersIdZasob.Count; i++)
                {
                    Temp = ordersIdZasob[i].Split(';');

                    CodesTemp.Add(Temp[0].Trim());
                    IdTemp.Add(Temp[1].Trim());
                }

                for (int i = 0; i < CodesTemp.Count; i++)
                {
                    for (int j = 0; j < CodesTemp.Count; j++)
                    {
                        if (CodesTemp[j] != "-1" && CodesTemp[i] == CodesTemp[j] && i != j)
                        {
                            CodesTemp.RemoveAt(j);
                            IdTemp.RemoveAt(j);
                            j--;
                        }
                    }
                }

                ordersIdZasob = IdTemp;                

                foreach (string a in MagazinesIdZasobList)
                {
                    foreach (string b in ordersIdZasob)
                        if (a == b)
                            Magazines.Add(a);
                }
            }

            string OrdersString = string.Join(",", ordersIdZasob.ToArray());
            string OrdersStringMag = string.Join(",", Magazines.ToArray());
            Session["ordersIdZasob"] = OrdersString;
            Session["ordersIdZasobMag"] = OrdersStringMag;
            //Session["ordersIdZasobNor"] = idZasobNor();
        }


        string idZasobNor()
        {
            SqlConnection Connection = new SqlConnection(Settings.WypozyczalniaConnectionString);
            string ordersIdZasobNor = "";
            if (ordersNor != null)
            {
                string Query = "select kod,min(zasob_id) as id_zasob from w2_zasoby_t where kod in (@Kod) and grupa_id = 4 and wypozyczony != 1 group by kod";
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@kod", string.Join(",", ordersNor.ToArray()));
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        while (Reader.Read())
                            ordersIdZasobNor = ordersIdZasobNor + ";" + Reader.GetValue("id_zasob").ToString();
                    }
                }
            }
            return ordersIdZasobNor;
        }


        #endregion

        /*protected void OrderViaDb()
        {
            using (SqlConnection conn = new SqlConnection(Settings.WypozyczalniaConnectionString))
            {
                conn.Open();                
                
                using (SqlCommand Command = new SqlCommand("w2_zamowienie", conn))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter ResultParameter = new SqlParameter();
                    ResultParameter.Direction = System.Data.ParameterDirection.Output;
                    ResultParameter.ParameterName = "@rezultat";
                    ResultParameter.Value = 0;
                    
                    try
                    {
                        if (ordersIdZasob != null && ordersIdZasob.Count > 0)
                        {
                            foreach (string Code in ordersIdZasob)
                            {
                                Command.Parameters.AddWithValue("@zasob_id", Int32.Parse(Code));
                                Command.Parameters.AddWithValue("@uzytk_id", HttpContext.Current.Session["UserID"]);
                                Command.Parameters.AddWithValue("@pracown_id", DBNull.Value);
                                Command.Parameters.AddWithValue("@uwagi", "");
                                Command.Parameters.Add(ResultParameter);

                                //System.Diagnostics.Trace.WriteLine(Code);
                                Command.ExecuteNonQuery();

                                Command.Parameters.Clear();
                            }
                        }

                        /* if (ordersMag != null && ordersMag.Count > 0)
                         {
                             foreach (string Code in ordersMag)
                             {

                                 Command.Parameters.AddWithValue("@zasob_id", Code);
                                 Command.Parameters.AddWithValue("@uzytk_id", HttpContext.Current.Session["UserID"]);
                                 Command.Parameters.AddWithValue("@pracown_id", 1);
                                 Command.Parameters.AddWithValue("@limit_czasu", 30);
                                 Command.Parameters.AddWithValue("@stan_zamow", "");
                                 Command.Parameters.AddWithValue("@uwagi", "");
                                 Command.Parameters.Add(ResultParameter);

                                 Command.ExecuteNonQuery();

                                 Command.Parameters.Clear();
                             }
                         }*/
        /* }
         catch (SqlException Ex)
         {

             //SiteMaster.Name1 += Ex.Message.ToString();
         }
     }

     conn.Close();
 }

 if (Settings.OrderMethod == 0)
     Response.Redirect("OrderSent.aspx");
}*/
    }
}