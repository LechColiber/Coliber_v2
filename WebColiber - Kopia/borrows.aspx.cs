using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WebColiber.App_GlobalResources;

namespace WebColiber
{
    public partial class Borrows : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Settings.GetSettinsgFromDb(Page.User.Identity.Name);

            if (IsPostBack)
            {
                Session["ShowReturned"] = chkShowR.Checked;
            }
            else
            {
                object check = Session["ShowReturned"];
                if (check == null)
                    check = false;

                chkShowR.Checked = (bool)check;
            }

            WriteNotReturned();
            ResultsR.Text = "";
            if (chkShowR.Checked)
                WriteReturned();
        }

        void WriteNotReturned()
        {
            /*string query = " SELECT convert(date, w.data_wypoz) as data_wyp, convert(date, w.data_wypoz + w.limit_czasu) as data_oddania, z.opis" +
                           " FROM w2_uzytkownicy u" +
                           " LEFT JOIN w2_wypozyczenia w" +
                           " ON u.uzytk_id = w.uzytk_id" +
                           " LEFT JOIN w2_zasoby z" +
                           " ON w.zasob_id = z.obcy_id" +
                           " WHERE w.data_zwrot IS NULL AND u.uzytk_id = " +  Session["UserID"] as string +
                           " ORDER BY data_wyp";
            */
            /*string query = " SELECT CONVERT(VARCHAR(10), w.data_wypoz, 105) as data_wyp, CONVERT(VARCHAR(10),(w.data_wypoz + w.limit_czasu), 105) as data_oddania, z.opis" +
                              " FROM dbo.w2_uzytkownicy u" +
                              " INNER JOIN dbo.w2_wypozyczenia w ON u.uzytk_id = w.uzytk_id" +
                              " INNER JOIN dbo.w2_zasoby_t z ON w.zasob_id = z.zasob_id" +
                              " WHERE w.data_zwrot IS NULL AND u.uzytk_id = @userID " +
                              " ORDER BY w.data_wypoz; ";*/

            string query = " select CONVERT(VARCHAR(10), w.data_wypoz, 105) as data_wyp, CONVERT(VARCHAR(10), w.data_zwrot, 105) as data_zwrot, CONVERT(VARCHAR(10), (w.data_wypoz + w.limit_czasu), 105) as przewid, w.opis, w.syg" +
                           " FROM dbo.v_wypozyczenia w " +
                           " WHERE w.data_zwrot IS NULL AND w.uzytk_id = @userID " +
                           " ORDER BY w.data_wypoz; ";

            using (SqlConnection conn = new SqlConnection(Settings.WypozyczalniaConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userID", HttpContext.Current.Session["UserID"] as string);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int number = 1;

                            ResultsNR.Text = "<b>" + Language.notReturned  + ":</b><br /><br />";
                            ResultsNR.Text += "<table border=1 frame='void' rules='all' class=\"table table-striped table-bordered table-hover table-condensed\">";
                            ResultsNR.Text += "<tr>" + 
                                                "<th style='padding-left: 10px; padding-right: 10px;width: 30px;'>" + Language.oridinalShort + "</th>" + 
                                                "<th style='padding-left: 10px; padding-right: 10px; width: 50px;'>" + Language.borrowDate + "</th>" + 
                                                "<th style='padding-left: 10px; padding-right: 10px; width: 50px;'>" + Language.providedDate + " </th>" + 
                                                "<th style='padding-left: 10px; padding-right: 10px;'>" + Language.description +  "</th>" +
                                                "<th style='padding-left: 10px; padding-right: 10px;'>" + Language.signature + "</th>" +
                                            "</tr>";

                            while (reader.Read())
                            {
                                ResultsNR.Text += "<tr>";

                                ResultsNR.Text += "<td align='center' valign='top'>" + number + "</td>";
                                ResultsNR.Text += "<td align='center' valign='top'>" + reader.GetValue("data_wyp").ToString().Replace(" 00:00:00", "") + "</td>";
                                ResultsNR.Text += "<td align='center' valign='top'>" + reader.GetValue("przewid").ToString().Replace(" 00:00:00", "") + "</td>";
                                ResultsNR.Text += "<td style='padding-left: 10px; padding-right: 10px;'>" + reader.GetValue("opis").ToString() + "</td>";
                                ResultsNR.Text += "<td style='padding-left: 10px; padding-right: 10px;'>" + reader.GetValue("syg").ToString() + "</td>";

                                ResultsNR.Text += "</tr>";

                                number++;
                            }

                            ResultsNR.Text += "</table>";
                        }
                    }
                }

                conn.Close();
            }
        }

        void WriteReturned()
        {
            
            /*string query = " select convert(date, w.data_wypoz) as data_wyp, w.data_zwrot, convert(date, w.data_wypoz + w.limit_czasu), z.opis" +
                           " FROM w2_uzytkownicy u" +
                           " LEFT JOIN w2_wypozyczenia w" +
                           " ON u.uzytk_id = w.uzytk_id" +
                           " LEFT JOIN w2_zasoby z" +
                           " ON w.zasob_id = z.obcy_id" +
                           " WHERE w.data_zwrot IS NOT NULL AND u.uzytk_id = " + Session["UserID"] as string +
                           " ORDER BY data_wyp";*/
            
            /*string query = " select CONVERT(VARCHAR(10), w.data_wypoz, 105) as data_wyp, CONVERT(VARCHAR(10), w.data_zwrot, 105), CONVERT(VARCHAR(10), (w.data_wypoz + w.limit_czasu), 105), z.opis" +
                           " FROM dbo.w2_uzytkownicy u" +
                           " INNER JOIN dbo.w2_wypozyczenia w ON u.uzytk_id = w.uzytk_id" +
                           " INNER JOIN dbo.w2_zasoby_t z ON w.zasob_id = z.zasob_id " +
                           " WHERE w.data_zwrot IS NOT NULL AND u.uzytk_id = @userID " +
                           " ORDER BY w.data_wypoz; ";*/

            string query = " select CONVERT(VARCHAR(10), w.data_wypoz, 105) as data_wyp, CONVERT(VARCHAR(10), w.data_zwrot, 105) as data_zwrot, CONVERT(VARCHAR(10), (w.data_wypoz + w.limit_czasu), 105), w.opis, w.syg" +
                           " FROM dbo.v_wypozyczenia w " +
                           " WHERE w.data_zwrot IS NOT NULL AND w.uzytk_id = @userID " +
                           " ORDER BY w.data_wypoz; ";

            using (SqlConnection conn = new SqlConnection(Settings.WypozyczalniaConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userID", HttpContext.Current.Session["UserID"] as string);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int number = 1;

                            ResultsR.Text = "<b>"  +  Language.returnedBorrows + ":</b><br><br />";

                            ResultsR.Text += "<table border=1 frame='void' rules='all' class=\"table table-striped table-bordered table-hover table-condensed\">";
                            ResultsR.Text += "<tr>" + 
                                                "<th style='padding-left: 10px; padding-right: 10px; width: 30px;'>" + Language.oridinalShort + "</th>" + 
                                                "<th style='padding-left: 10px; padding-right: 10px; width: 50px;'>" + Language.borrowDate + "</th>" + 
                                                "<th style='padding-left: 10px; padding-right: 10px; width: 120px;'>" + Language.returnDate + "</th>" + 
                                                "<th style='padding-left: 10px; padding-right: 10px; width: 50px;'>" + Language.providedDate + "</th>" +
                                                "<th style='padding-left: 10px; padding-right: 10px;'>" + Language.description + "</th>" +
                                                "<th style='padding-left: 10px; padding-right: 10px;'>" + Language.signature + "</th>" +
                                            "</tr>";

                            while (reader.Read())
                            {
                                ResultsR.Text += "<tr>";

                                ResultsR.Text += "<td align='center' valign='top'>" + number + "</td>";
                                ResultsR.Text += "<td align='center' valign='top'>" + reader.GetValue(0).ToString().Replace(" 00:00:00", "") + "</td>";
                                ResultsR.Text += "<td align='center' valign='top'>" + reader.GetValue(1).ToString().Replace(" 00:00:00", "") + "</td>";
                                ResultsR.Text += "<td align='center' valign='top'>" + reader.GetValue(2).ToString().Replace(" 00:00:00", "") + "</td>";
                                ResultsR.Text += "<td style='padding-left: 10px; padding-right: 10px;'>" + reader.GetValue(3).ToString() + "</td>";
                                ResultsR.Text += "<td style='padding-left: 10px; padding-right: 10px;'>" + reader.GetValue(4).ToString() + "</td>";

                                ResultsR.Text += "</tr>";

                                number++;
                            }

                            ResultsR.Text += "</table>";
                        }
                    }
                }

                conn.Close();
            }
        }
    }
}