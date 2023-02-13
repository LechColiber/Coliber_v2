using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Threading;
using System.Resources;
using WebColiber.App_GlobalResources;

namespace WebColiber
{
    public partial class ShowMagazines : System.Web.UI.Page
    {
        public static int pageNo;
        protected static int pageMax;
        protected static string query;
        protected const int resultsOnPage = 50;
        protected static List<Entry> entries = new List<Entry>();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*Language.Culture = new System.Globalization.CultureInfo(Settings.Localization);
            string s = Language.searching;
            System.Resources.ResourceManager temp = new System.Resources.ResourceManager("WebColiber.App_GlobalResources.Language", typeof(Language).Assembly);
            string s2 = temp.GetString("searching", Language.Culture);*/
            
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "myscript", "alert('" + Settings.UserID + "')", true);
            SqlConnection DatabaseConnection = new SqlConnection(Settings.ColiberConnectionString);
            
            Session["KodCzasopisma"] = Request.QueryString["kod"];
            //Session["WoluminCzasopisma"] = Request.QueryString["volumin"];
            Session["id_volumes"] = Request.QueryString["volumin"];
            //Session["RokCzasopisma"] = Request.QueryString["rok"];

            query = ";WITH tab AS ( \n" +
                            "SELECT zasob_id, opis, num FROM w2_zasoby \n" +
                            "INNER JOIN " + DatabaseConnection.Database + ".dbo.cza_zas ON CAST(w2_zasoby.obcy_id AS int) = " + DatabaseConnection.Database + ".dbo.cza_zas.id_zasob \n" +
                            "INNER JOIN " + DatabaseConnection.Database + ".dbo.czasop_n ON " + DatabaseConnection.Database + ".dbo.czasop_n.id_czasop_n = " + DatabaseConnection.Database + ".dbo.cza_zas.id_czasop \n" +                
                            "INNER JOIN " + DatabaseConnection.Database + ".dbo.akcesja ON " + DatabaseConnection.Database + ".dbo.akcesja.kod = " + DatabaseConnection.Database + ".dbo.cza_zas.kod " +               
                            //"WHERE " + DatabaseConnection.Database + ".dbo.akcesja.nr_czasop = @kod AND grupa_id = 2 AND " + DatabaseConnection.Database + ".dbo.czasop_n.volumin = @volumin AND " + DatabaseConnection.Database + ".dbo.czasop_n.rok1 = @rok \n" +
                            "WHERE " + DatabaseConnection.Database + ".dbo.akcesja.nr_czasop = @kod AND grupa_id = 2 AND " + DatabaseConnection.Database + ".dbo.czasop_n.id_volumes = @id_volumes \n" +
                            ") \n" +
                            "SELECT zasob_id, opis FROM tab \n" +
                            "ORDER BY num; \n" +
                            "";                   

            /*query = tmp;
            if (query != string.Empty)
                getResults();

            panelSearchResults.Visible = true;

            if (!IsPostBack)
            {
                pageNo = 1;
                setResults();
            }
           
            setPages();*/
            //setResults();
            getResults();
        }

        protected void getResults()
        {
            using (SqlConnection conn = new SqlConnection(Settings.WypozyczalniaConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kod", Session["KodCzasopisma"] as string);
                    cmd.Parameters.AddWithValue("@id_volumes", Session["id_volumes"] as string);
                    //cmd.Parameters.AddWithValue("@rok", Session["RokCzasopisma"] as string);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable Dt = new DataTable();
                        Dt.Load(reader);

                        ResultsO.Text = "<table border=1 frame='void' rules='all' class=\"table table-striped table-bordered table-hover table-condensed\">";

                        ResultsO.Text += "<tr>";
                        ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width: 20px;'>" + Language.oridinalShort + "</td>";

                        if (HttpContext.Current.Session["CanOrder"] != null && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string))
                            ResultsO.Text += "<td align=\"center\" style='padding-left: 10px; padding-right: 10px; width:120px'>" + Language.check + " <br /> " + Language.toOrder + "</td>";

                        ResultsO.Text += "<td align=\"left\" style='padding-left: 10px; padding-right: 10px;'>" + Language.description + "</td>";
                        ResultsO.Text += "</tr>";

                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            ResultsO.Text += "<tr>";
                            ResultsO.Text += "<td align='center' valign='top'>" + (i + 1) + "</td>";

                            if (HttpContext.Current.Session["CanOrder"] != null && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string))
                                ResultsO.Text += "<td align='center'><input id=\"Checkbox" + Dt.Rows[i]["zasob_id"].ToString() + "\" type=\"checkbox\" OnClick=\"lookCheckboxes(this);\"/></td>";

                            ResultsO.Text += "<td align='left' valign='top'>" + Dt.Rows[i]["opis"].ToString() + "</td>";                            
                            ResultsO.Text += "</tr>";
                        }

                        ResultsO.Text += "</table>";
                    }
                }
            }

            /*using (SqlConnection conn = new SqlConnection(Settings.WypozyczalniaConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kod", Session["KodCzasopisma"] as string);
                    cmd.Parameters.AddWithValue("@volumin", Session["WoluminCzasopisma"] as string);
                    cmd.Parameters.AddWithValue("@rok", Session["RokCzasopisma"] as string);
                     
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        panelResults.Controls.Clear();
                        entries.Clear();                        
                        
                        if (reader.HasRows)
                        {
                            int i = 1;
                            while (reader.Read())
                            {
                                entries.Add(new Entry(i++, Decimal.Parse(reader.GetInt32(0).ToString()), reader.GetString(1), 0, Entry.EntryType.MagazineNumber));
                            }
                        }

                        pageMax = (entries.Count - (entries.Count % resultsOnPage)) / resultsOnPage + (entries.Count % resultsOnPage == 0 ? 0 : 1);
                    }
                }
            }*/
        }

        /*void setPages()
        {
            setPages(panelNavTop);
            setPages(panelNavBottom);
        }*/

        /*void setPages(Panel panel)
        {
            if (pageMax <= 1) panel.Visible = false;
            else
            {
                panel.Visible = true;
                panel.Controls.Clear();

                if (pageNo != 1)
                {
                    {
                        LinkButton lb = new LinkButton();
                        lb.Text = "<< ";
                        lb.ID = panel.ID + lb.Text;
                        lb.Click += new EventHandler(btn_Click);
                        panel.Controls.Add(lb);
                    }
                    {
                        LinkButton lb = new LinkButton();
                        lb.Text = "< ";
                        lb.ID = panel.ID + lb.Text;
                        lb.Click += new EventHandler(btn_Click);
                        panel.Controls.Add(lb);
                    }
                }

                int i = (pageNo < 11 ? 1 : (pageNo > pageMax - 10 ? pageMax - 20 : pageNo - 10));
                int maxi = i + 20 > pageMax ? pageMax : i + 20;

                for (; i <= maxi; i++) 
                {
                    if (i != pageNo)
                    {
                        LinkButton lb = new LinkButton();
                        lb.Text = i + " ";
                        lb.ID = panel.ID + i;
                        lb.Click += new EventHandler(btn_Click);
                        panel.Controls.Add(lb);
                    }
                    else
                    {
                        Label lb = new Label();
                        lb.Text = i + " ";
                        panel.Controls.Add(lb);
                    }
                }

                if (pageNo != pageMax)
                {
                    {
                        LinkButton lb = new LinkButton();
                        lb.Text = "> ";
                        lb.ID = panel.ID + lb.Text;
                        lb.Click += new EventHandler(btn_Click);
                        panel.Controls.Add(lb);
                    }
                    {
                        LinkButton lb = new LinkButton();
                        lb.Text = ">> ";
                        lb.ID = panel.ID + lb.Text;
                        lb.Click += new EventHandler(btn_Click);
                        panel.Controls.Add(lb);
                    }
                }               
            }
        }*/

        /*public void setResults()
        {
            panelSearchResults.Visible = true;

            if (HttpContext.Current.Session["CanOrder"] != null)
            {
                btnOrder.Visible = Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string);
                btnOrder.Attributes.Add("onClick", "Order(); return false;");

                btnOrderTop.Visible = Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string);
                btnOrderTop.Attributes.Add("onClick", "Order(); return false;");
            }

            setPages();

            for (int i = (pageNo - 1) * resultsOnPage; i < pageNo * resultsOnPage && i < entries.Count() && i >= 0; i++ )
            {                
                Result result = LoadControl("UserControls/Result.ascx") as Result;
                //entries[i].NumberOfCopies = Entry.GetAvailableNumberOfCopies((int)entries[i].Id, entries[i].Type);
                result.Entry = entries[i];
                result.ID = "Result" + entries[i].Id;
                
                panelResults.Controls.Add(result);
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;

            switch (btn.Text.Trim())
            {
                case "<<": pageNo = 1; break;
                case "<": pageNo--; break;
                case ">": pageNo++; break;
                case ">>": pageNo = pageMax; break;
                default: pageNo = Int32.Parse(btn.Text.Trim()); break;
            }
            setResults();
        }*/
    }
}