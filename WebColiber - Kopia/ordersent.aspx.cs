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
    public partial class OrderSent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["orders"] = null;
            Session["ordersMag"] = null;

            List<string> OrdersIdZasob = null;

            if (Session["ordersIdZasob"] != null && Session["ordersIdZasob"] as string != "")
                OrdersIdZasob = new List<string>((Session["ordersIdZasob"] as string).Split(','));

            Session["ordersIdZasob"] = null;

            if (OrdersIdZasob != null && OrdersIdZasob.Count > 0)
            {
                string Query = " SELECT LTRIM(RTRIM(opis)) as tytul " +
                               " FROM dbo.w2_zasoby_t " +
                               " WHERE zasob_id IN ( ";

                for (int i = 0; i < OrdersIdZasob.Count; i++)
                {
                    if (i < OrdersIdZasob.Count - 1)
                        Query += "@kod" + i + ",";
                    else
                        Query += "@kod" + i;
                }

                Query += ") ORDER BY opis; ";
                
                using (SqlConnection Connection = new SqlConnection(Settings.WypozyczalniaConnectionString))
                {
                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {                        
                        for (int i = 0; i < OrdersIdZasob.Count; i++)
                        {
                            Command.Parameters.AddWithValue("@kod" + i, OrdersIdZasob[i]);
                        }

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            int count = 1;

                            Results.Text = "<b>" + Language.ordersInfo003 + ":</b><br /><br />";
                            Results.Text += "<table border=1 frame='void' rules='all' class=\"table table-striped table-bordered table-hover table-condensed\">";
                            Results.Text += "<tr><td align='center'>" + Language.oridinalShort + "</td><td>" + Language.description + "</td></tr>";

                            while (Reader.Read())
                            {
                                Results.Text += "<tr>";

                                Results.Text += "<td align='center' style='padding-left: 10px; padding-right: 10px;'>" + count++ + "</td>";
                                Results.Text += "<td align='left'>" + Reader.GetValue("tytul").ToString() + "</td>";

                                Results.Text += "</tr>";
                            }

                            Results.Text += "</table>";
                            Results.Text += "<br /><b>" + Language.ordersInfo001 + ".</b>";
                        }
                    }

                    Connection.Close();
                }

                /*if (Session["ordersIdZasob"] == null)
                    OrdersIdZasob = null;

                Session["orders"] = null;*/
            }
            else
                Results.Text = "<b>" + Language.ordersInfo002 + ".</b>";

            if (Session["ordersIdZasob"] == null)
                OrdersIdZasob = null;

            Session["orders"] = null;
        }
    }
}