using System;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using WebColiber.App_GlobalResources;

namespace WebColiber
{
	public partial class Orders : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Settings.GetSettinsgFromDb(Page.User.Identity.Name);
			
			/*if (IsPostBack)
			{
				Session["ShowReturned"] = chkShowR.Checked;
			}
			else
			{
				object check = Session["ShowReturned"];
				if (check == null)
					check = false;

				chkShowR.Checked = (bool)check;
			}*/

			WriteOrdered();
			/*ResultsR.Text = "";
			if (chkShowR.Checked) 
				WriteReturned();*/
		}

		void WriteOrdered()
		{
			/*string query = " select convert(date, w.data_wypoz) as data_wyp, w.data_zwrot, convert(date, w.data_wypoz + w.limit_czasu), z.opis" +
						   " FROM w_user_guid u" +
						   " LEFT JOIN w2_wypozyczenia w" +
						   " ON u.uzytk_id = w.uzytk_id" +
						   " LEFT JOIN w2_zasoby z" +
						   " ON w.zasob_id = z.obcy_id" +
						   " WHERE w.data_zwrot IS NOT NULL AND u.domena_nazwa = '" + User.Identity.Name + "'" +
						   " ORDER BY data_wyp";
			*/
			string query = //" select convert(date, w.data_zamow) as data_zam, z.opis" +
						   " SELECT CONVERT(VARCHAR(16), w.data_zamow, 21) as data_zam, z.opis, " +
						   "CASE " + 
							"   WHEN stan_zamow = '0' THEN '" + Language.stat_Oczekuje + "'" +
                            "   WHEN stan_zamow = '1' THEN '" + Language.stat_Zrealizowane + "'" +
                            "   WHEN stan_zamow = '2' THEN '" + Language.stat_Rezygnacja + "'" +
                            "   WHEN stan_zamow = '3' THEN '" + Language.stat_Przygotowane + "'" +
							"END AS stan" +
						   " FROM dbo.w2_uzytkownicy u" +
						   " INNER JOIN w2_zamowienia w ON u.uzytk_id = w.uzytk_id" +
						   " INNER JOIN w2_zasoby z ON w.zasob_id = z.zasob_id" +
						   " WHERE w.data_realiz IS NULL AND u.uzytk_id = @userID " +
						   " ORDER BY data_zam; ";

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

							ResultsO.Text = "<b>" + Language.orders + ":</b><br><br />";

							ResultsO.Text += "<table border=1 frame='void' rules='all' class=\"table table-striped table-bordered table-hover table-condensed\">";
							ResultsO.Text += "<tr>" +
												"<th style='padding-left: 10px; padding-right: 10px; width:auto;'>" + Language.oridinalShort + "</th>" +                                                 
												"<th style='padding-left: 10px; padding-right: 10px; width:160px'>" + Language.ordersDate + "</th>" +
												"<th style='padding-left: 10px; padding-right: 10px; width:160px'>" + Language.orderState + "</th>" + 
												"<th style='padding-left: 10px; padding-right: 10px;'>" + Language.description + "</th>" + 
											"</tr>";

							while (reader.Read())
							{
								ResultsO.Text += "<tr>";
								ResultsO.Text += "<td align='center' valign='top'>" + number + "</td>";
								ResultsO.Text += "<td align='center' valign='top'>" + reader.GetValue("data_zam").ToString() + "</td>";
								ResultsO.Text += "<td align='center' valign='top'>" + reader.GetValue("stan").ToString() + "</td>";
								ResultsO.Text += "<td style='padding-left: 10px; padding-right: 10px;'>" + reader.GetValue("opis").ToString() + "</td>";                                

								ResultsO.Text += "</tr>";

								number++;
							}

							ResultsO.Text += "</table>";
						}
						else
						{
							ResultsO.Text = Language.noOrders ;
						}
					}
				}

				conn.Close();
			}
		}
	}
}