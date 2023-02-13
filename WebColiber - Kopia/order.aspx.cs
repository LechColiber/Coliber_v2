using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data;
using WebColiber.App_GlobalResources;

namespace WebColiber
{
    public partial class Order : System.Web.UI.Page
    {
        List<string> orders;
        List<string> ordersMag;

        protected void Page_Load(object sender, EventArgs e)
        {
            //orders = new List<string>();
            //orders = Session["orders"] as List<string>;

            //ordersMag = new List<string>();
            //ordersMag = Session["ordersMag"] as List<string>;
            txtOrder.Text = HttpContext.Current.Session["Name"] as string;

            orders = new List<string>();
            ordersMag = new List<string>();

            if ((Session["ordersIdZasob"] as string).Trim() != "")
                orders = new List<string>((Session["ordersIdZasob"] as string).Split(','));

            if ((Session["ordersIdZasobMag"] as string).Trim() != "")
                ordersMag = new List<string>((Session["ordersIdZasobMag"] as string).Split(','));
        }

        protected void btnSendOrder_Click(object sender, EventArgs e)
        {
            if (Settings.OrderMethod == 0)
            {
                OrderViaDb();
            }
            else if (Settings.OrderMethod == 1)
            {
                if (orders.Count == 0)
                    Response.Redirect("OrderSent.aspx");
                else
                    OrderViaMail();
            }
            else if (Settings.OrderMethod == 2)
            {
                if (orders.Count == 0)
                    Response.Redirect("OrderSent.aspx");
                else
                {
                    OrderViaDb();
                    OrderViaMail();
                }
            }

            //OrderViaMail();
        }

        protected void OrderViaMail()
        {
            SmtpClient newMail = new SmtpClient();
            MailMessage mailMsg = new MailMessage();

            mailMsg.From = new MailAddress(Settings.User);
            mailMsg.To.Add(Settings.Recipient);
            mailMsg.Subject = Language.order;
            mailMsg.IsBodyHtml = true;
            mailMsg.Body = txtOrder.Text + " " + Language.ordersFollowingItems + ":<br>";

            using (SqlConnection conn = new SqlConnection(Settings.ColiberConnectionString))
            {
                conn.Open();
                int count = 1;
                

                for (int i = 0; i < orders.Count; i++)
                {
                    for (int j = 0; j < ordersMag.Count; j++)
                    {
                        if (i < orders.Count && j < ordersMag.Count && orders[i] == ordersMag[j])
                        {
                            orders.RemoveAt(i);

                            if (i > 0)
                                i--;
                            j = 0;
                        }
                    }
                }

                //System.Diagnostics.Trace.WriteLine(orders[0]);
                /*string b = "";
                foreach (string a in orders)
                    b += a + " ";

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "myscript", "alert('" + b + "')", true);
                */
                if (orders != null && orders.Count > 0)
                {
                    SqlConnection DatabaseConnection = new SqlConnection(Settings.WypozyczalniaConnectionString);

                    /*string query = " SELECT RTRIM(LTRIM(RTRIM(imie1) + ' ' + LTRIM(autor1))) +" +
                                   " CASE WHEN LTRIM(imie1 + autor1) = '' AND (LTRIM(imie2 + autor2) <> '' OR LTRIM(imie3 + autor3) <> '') THEN ', ' ELSE '' END +" +
                                   " RTRIM(LTRIM(RTRIM(imie2) + ' ' + LTRIM(autor2))) +" +
                                   " CASE WHEN LTRIM(imie2 + autor2) <> '' AND LTRIM(imie3 + autor3) <> '' THEN ', ' ELSE '' END +" +
                                   " RTRIM(LTRIM(RTRIM(imie3) + ' ' + LTRIM(autor3))) AS autorzy," +
                                   " LTRIM(RTRIM(tytul_gl)) AS tytul_gl, LTRIM(RTRIM(zasoby.syg)) AS syg" +                                   
                                   " FROM ksiazki " +
                                   " INNER JOIN zasoby ON ksiazki.kod = zasoby.kod" +
                                   " INNER JOIN " + DatabaseConnection.Database + ".dbo.w2_zasoby ON " + DatabaseConnection.Database + ".dbo.w2_zasoby.obcy_id = zasoby.id_zasob " +
                                   " WHERE " + DatabaseConnection.Database + ".dbo.w2_zasoby.zasob_id = ";*/

                    SqlCommand Command = new SqlCommand();
                    Command.CommandText = " SELECT LTRIM(RTRIM(tytul_gl)) AS tytul_gl, LTRIM(RTRIM(zasoby.syg)) AS syg, " +
                                           " ((SELECT stuff((select ', ' + LTRIM(RTRIM(imie)) + ' ' + LTRIM(RTRIM(nazwisko)) FROM list_aut_k INNER JOIN ksiazki_autor_new ON ksiazki_autor_new.id_autor = list_aut_k.id_aut WHERE ksiazki_autor_new.id_ksiazka = ksiazki_new.kod ORDER BY rating for xml path('')),1,2,''))) as autor " +
                                           " FROM ksiazki_new " +
                                           " INNER JOIN zasoby ON ksiazki_new.kod = zasoby.kod AND rodzaj_zas = 1" +
                                           " INNER JOIN " + DatabaseConnection.Database + ".dbo.w2_zasoby ON " + DatabaseConnection.Database + ".dbo.w2_zasoby.obcy_id = zasoby.id_zasob " +
                                           " WHERE " + DatabaseConnection.Database + ".dbo.w2_zasoby.zasob_id IN ( ";
                    
                    for (int i = 0; i < orders.Count; i++)
                    {
                        Command.CommandText += "@id" + i;

                        if (i < orders.Count - 1)
                            Command.CommandText += ", ";
                        else
                            Command.CommandText += "); ";

                        Command.Parameters.AddWithValue("@id" + i, orders[i]);
                    }

                    DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.ColiberConnection);


                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        mailMsg.Body += "<br>-------------------------------------------------<br>";
                        mailMsg.Body += count++ + ".";
                        mailMsg.Body += "<br>" + Language.authors + "  : " + Dt.Rows[i]["autor"];
                        mailMsg.Body += "<br>" + Language.title + "     : " + Dt.Rows[i]["tytul_gl"];
                        mailMsg.Body += "<br>" + Language.signature + " : " + Dt.Rows[i]["syg"];
                        mailMsg.Body += "<br />";
                    }                     
                }


                //List<string> ordersMag = new List<string>((Session["ordersIdZasobMag"] as string).Split(',')); //Session["ordersIdZasobMag"] as List<string>;//Session["ordersMag"] as List<string>;
                if (ordersMag != null && ordersMag.Count > 0)
                {
                    SqlConnection DatabaseConnection = new SqlConnection(Settings.ColiberConnectionString);

                    /**string query = " SELECT opis, syg, CASE WHEN rok2 > 1900 THEN RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) + '/' + CAST(rok2 As varchar) ELSE RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) END As volumin " +
                                   " FROM w2_zasoby " +
                                   " INNER JOIN " + DatabaseConnection.Database + ".dbo.zasoby ON w2_zasoby.obcy_id = " + DatabaseConnection.Database + ".dbo.zasoby.id_zasob" +
                                   " WHERE w2_zasoby.zasob_id = ";
                    query += string.Join(" OR w2_zasoby.zasob_id = ", ordersMag);*/
                    
                    SqlCommand Command = new SqlCommand();
                    Command.CommandText = " SELECT opis, syg, CASE WHEN rok2 > 1900 THEN RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) + '/' + CAST(rok2 As varchar) ELSE RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) END As volumin " +
                                          " FROM w2_zasoby " +
                                          " INNER JOIN " + DatabaseConnection.Database + ".dbo.zasoby ON w2_zasoby.obcy_id = " + DatabaseConnection.Database + ".dbo.zasoby.id_zasob" +
                                          " WHERE w2_zasoby.zasob_id IN (";
                    
                    for (int i = 0; i < ordersMag.Count; i++)
                    {
                        Command.CommandText += "@id" + i;

                        if (i < ordersMag.Count - 1)
                            Command.CommandText += ", ";
                        else 
                            Command.CommandText += "); ";

                        Command.Parameters.AddWithValue("@id" + i, ordersMag[i]);
                    }

                    DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.WypozyczalniaConnection);


                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        mailMsg.Body += "<br>-------------------------------------------------<br>";
                        mailMsg.Body += count++ + ".";
                        mailMsg.Body += "<br>" + Language.title + "     : " + Dt.Rows[i]["opis"];
                        mailMsg.Body += "<br>" + Language.signature + " : " + Dt.Rows[i]["syg"];
                        mailMsg.Body += "<br>" + Language.volumin + "   : " + Dt.Rows[i]["volumin"];
                    }                                            
                }
            }

            mailMsg.Body += "<br><br>";
            mailMsg.Body += Language.additionalOrderInfo ;
            mailMsg.Body += txtDescription.Text.Trim();

            newMail.Host = Settings.SmtpServer;
            newMail.EnableSsl = false;

            newMail.DeliveryMethod = SmtpDeliveryMethod.Network;
            newMail.Credentials = new System.Net.NetworkCredential(Settings.User, Settings.Password);

            //throw new Exception("Do you really want to send that message?");
            newMail.Send(mailMsg);

            Response.Redirect("OrderSent.aspx");
        }

        protected void OrderViaDb()
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
                        if (orders != null && orders.Count > 0)
                        {
                            foreach (string Code in orders)
                            {
                                Command.Parameters.AddWithValue("@zasob_id", Int32.Parse(Code));
                                Command.Parameters.AddWithValue("@uzytk_id", HttpContext.Current.Session["UserID"]);
                                Command.Parameters.AddWithValue("@pracown_id", DBNull.Value);
                                Command.Parameters.AddWithValue("@uwagi", txtDescription.Text.Trim());
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
                    }
                    catch (SqlException Ex)
                    {

                        //SiteMaster.Name1 += Ex.Message.ToString();
                    }
                }

                conn.Close();
            }

            if (Settings.OrderMethod == 0)
                Response.Redirect("OrderSent.aspx");
        }
    }
}