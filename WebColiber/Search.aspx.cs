using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Threading;
using System.Resources;
using WebColiber.App_GlobalResources;
using System.Web.Services;
using System.Data;
using System.Web.Script.Services;
using System.Text;
using System.Xml;
using System.IO;
using System.IO.Packaging;
using System.Reflection;

namespace WebColiber
{
    public class Entry
    {
        public enum EntryType { Article, Magazine, Book, MagazineNumber, None };

        public EntryType Type { get; private set; }
        public decimal Id { get; private set; }
        public int Index { get; private set; }
        public string Title { get; private set; }
        public int NumberOfCopies { get; private set; }

        public Entry(int index, decimal id, string title, int NumberOfCopies, EntryType type)
        {
            this.Index = index;
            this.Id = id;
            this.Title = title;
            this.Type = type;
            this.NumberOfCopies = NumberOfCopies;            
        }
    }

    public partial class Search : System.Web.UI.Page
    {
        public static int pageNo;
        protected static int pageMax;
        protected static string query;
        protected const int resultsOnPage = 50;
        protected static List<Entry> entries = new List<Entry>();
        protected SqlCommand CommandQ = new SqlCommand();

        [WebMethod]        
        public static List<string> GetPromptList(string dictType, int type, string text)
        {
            // 1 - ksiazki
            // 2 - czasopisma
            // 3 - artykuly
            
            List<string> ItemsList = new List<string>();

            SqlCommand Command = new SqlCommand();
            
            Command.CommandText = "EXEC WC_PromptList @text, 0, @typ, @dictType; ";

            Command.Parameters.AddWithValue("@typ", type);
            Command.Parameters.AddWithValue("@text", text);
            Command.Parameters.AddWithValue("@dictType", dictType);

            System.Data.DataTable Dt = new System.Data.DataTable();

            Dt = CommonFunctions.ReadData(Command, ref Settings.ColiberConnection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                ItemsList.Add(Dt.Rows[i]["value"].ToString());
            }

            return ItemsList;
        }

        [WebMethod]
        public static List<ListItem> GetLanguagesList()
        {            
            List<ListItem> ItemsList = new List<ListItem>();

            ListItem Item;

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC ListaJezykow; ";

            System.Data.DataTable Dt = new System.Data.DataTable();

            if (Settings.CacheStopWatch.Elapsed.TotalMinutes > 2 || Settings.LanguagesDataTable == null)
            {
                Settings.LanguagesDataTable = CommonFunctions.ReadData(Command, ref Settings.ColiberConnection);
                Settings.RestartCacheStopWatch();
            }

            Dt = Settings.LanguagesDataTable;

            Item = new ListItem();
            Item.Value = "-1";
            Item.Text = "";
            ItemsList.Add(Item);  

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Item = new ListItem();
                Item.Value = Dt.Rows[i]["id"].ToString();
                Item.Text = Dt.Rows[i]["jezyk"].ToString();
                ItemsList.Add(Item);                
            }

            return ItemsList;
        }

        [WebMethod]
        public static List<ListItem> GetCountriesList()
        {
            List<ListItem> ItemsList = new List<ListItem>();

            ListItem Item;

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC CountryList; ";

            System.Data.DataTable Dt = new System.Data.DataTable();

            if (Settings.CacheStopWatch.Elapsed.TotalMinutes > 2 || Settings.CountryDataTable == null)
            {                 
                Settings.CountryDataTable = CommonFunctions.ReadData(Command, ref Settings.ColiberConnection);
                Settings.RestartCacheStopWatch();
            }
            
            Dt = Settings.CountryDataTable;
            
            Item = new ListItem();
            Item.Value = "-1";
            Item.Text = "";
            ItemsList.Add(Item);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Item = new ListItem();
                Item.Value = Dt.Rows[i]["id"].ToString();
                Item.Text = Dt.Rows[i]["p_sk_nazwa"].ToString();
                ItemsList.Add(Item);
            }

            return ItemsList;
        }

        [WebMethod]
        public static List<ListItem> GetFreqList()
        {
            List<ListItem> ItemsList = new List<ListItem>();

            ItemsList.Add(new ListItem("", "-1"));
            ItemsList.Add(new ListItem(Language.daily, "1"));
            ItemsList.Add(new ListItem(Language.weekly, "2"));
            ItemsList.Add(new ListItem(Language.biweekly, "3"));
            ItemsList.Add(new ListItem(Language.monthly, "4"));
            ItemsList.Add(new ListItem(Language.bimonthly, "5"));
            ItemsList.Add(new ListItem(Language.quarterly, "6"));
            ItemsList.Add(new ListItem(Language.halfYearly, "7"));
            ItemsList.Add(new ListItem(Language.yearly, "8"));
            ItemsList.Add(new ListItem(Language.irregular, "9"));


            return ItemsList;
        }

        [WebMethod]
        public static List<ListItem> GetItemsList(string type)
        {            
            List<ListItem> ItemsList = new List<ListItem>();

            ListItem Item;

            type = type.Trim().ToLower();

            if (type == "books")
            {
                Item = new ListItem();
                Item.Text = Language.title;
                Item.Value = "title";
                ItemsList.Add(Item);

                Item = new ListItem();
                Item.Text = Language.author;
                Item.Value = "authorsLastName";
                ItemsList.Add(Item);

                if (Settings.SearchByKeyInBooksVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.key;
                    Item.Value = "key";
                    ItemsList.Add(Item);
                }

                Item = new ListItem();
                Item.Text = Language.signature;
                Item.Value = "syg";
                ItemsList.Add(Item);

                if (Settings.SearchBySerieInBooksVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.serie;
                    Item.Value = "serie";
                    ItemsList.Add(Item);
                }

                if (Settings.SearchByPublisherInBooksVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.publisher;
                    Item.Value = "publisher";
                    ItemsList.Add(Item);
                }

                if (Settings.SearchByInstitutionInBooksVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.institution;
                    Item.Value = "instyt";
                    ItemsList.Add(Item);
                }

                if (Settings.SearchByUKDInBooksVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.ukd;
                    Item.Value = "ukd";
                    ItemsList.Add(Item);
                }

                if (Settings.SearchByEntryInBooksDateVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.dateEntererd;
                    Item.Value = "entry_date";
                    ItemsList.Add(Item);
                }

                if (Settings.SearchByPublishYearInBooksVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.yearOfPublishing;
                    Item.Value = "publish_year";
                    ItemsList.Add(Item);
                }
            }

            if (type == "magazines")
            {
                Item = new ListItem();
                Item.Text = Language.title;
                Item.Value = "title";
                ItemsList.Add(Item);

                Item = new ListItem();
                Item.Text = Language.signature;
                Item.Value = "syg";
                ItemsList.Add(Item);

                if (Settings.SearchByKeyInMagazinesVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.key;
                    Item.Value = "key";
                    ItemsList.Add(Item);
                }

                if (Settings.SearchByPublisherInMagazinesVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.publisher;
                    Item.Value = "publisher";
                    ItemsList.Add(Item);
                }

                if (Settings.SearchByDistributorInMagazinesVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.supplier;
                    Item.Value = "distributor";
                    ItemsList.Add(Item);
                }

                if (Settings.SearchByExtrasTitleInMagazinesVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.additionTitle;
                    Item.Value = "extras_title";
                    ItemsList.Add(Item);
                }

                if (Settings.SearchByExtrasAuthorInMagazinesVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.additionAuthor;
                    Item.Value = "extras_author";
                    ItemsList.Add(Item);
                }
            }

            if (type == "articles")
            {
                Item = new ListItem();
                Item.Text = Language.title;
                Item.Value = "title";
                ItemsList.Add(Item);

                Item = new ListItem();
                Item.Text = Language.author;
                Item.Value = "authorsLastName";
                ItemsList.Add(Item);

                if (Settings.SearchByKeyInArticlesVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.key;
                    Item.Value = "key";
                    ItemsList.Add(Item);
                }

                Item = new ListItem();
                Item.Text = Language.titleOfPublicationSource;
                Item.Value = "magazine_title";
                ItemsList.Add(Item);

                if (Settings.SearchByEntryInArticlesDateVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.dateEntererd;
                    Item.Value = "entry_date";
                    ItemsList.Add(Item);
                }

                if (Settings.SearchByDescFragmentInArticlesVisible)
                {
                    Item = new ListItem();
                    Item.Text = Language.excerpt;
                    Item.Value = "desc_fragment";
                    ItemsList.Add(Item);
                }
            }
            if (type == "normy")
            {
                Item = new ListItem();
                Item.Text = "Numer normy";
                Item.Value = "nrn";
                ItemsList.Add(Item);

                Item = new ListItem();
                Item.Text = Language.title;
                Item.Value = "title";
                ItemsList.Add(Item);

                Item = new ListItem();
                Item.Text = "Data publikacji";
                Item.Value = "data_pub";
                ItemsList.Add(Item);

                Item = new ListItem();
                Item.Text = "Status";
                Item.Value = "StatusN";
                ItemsList.Add(Item);

                Item = new ListItem();
                Item.Text = "Słowo kluczowe";
                Item.Value = "key";
                ItemsList.Add(Item);
            }
            return ItemsList;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {            
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "myscript", "alert('" + Settings.UserID + "')", true);
        }
        
        /*[WebMethod]
        public static void GenerateDOC()
        {
            string Cookie = HttpContext.Current.Request.Cookies["order"].Value;
            List<string> Ids = new List<string>();

            if (Cookie != null)
                Ids = Cookie.Split(',').ToList();

            string type = HttpContext.Current.Request.Cookies["typeToPrint"].Value;

            string Content = "";

            foreach (string id in Ids)
            {
                Content += Details.GenerateContent(type, id, true);
                Content += "<hr /><br /><br />";
            }

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = Encoding.UTF8.WebName;
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;

            HttpContext.Current.Response.ContentType = "application/msword";

            string strFileName = "Opisy bibliograficzne" + ".doc";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + strFileName);

            StringBuilder strHTMLContent = new StringBuilder();
            strHTMLContent.Append(Content);

            //strHTMLContent.Append("<br><br>".ToString()); strHTMLContent.Append("<p align='Center'> Note : This is adynamically generated word document  <  / p > ".ToString());
            HttpContext.Current.Response.Write('\uFEFF');
            HttpContext.Current.Response.Write(strHTMLContent);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }*/

        [WebMethod]
        public static void GenerateDOC()
        {
            string splitLine = "<hr />";
            string Cookie = HttpContext.Current.Request.Cookies["order"].Value;
            List<string> Ids = new List<string>();

            if (Cookie != null)
                Ids = Cookie.Split(',').ToList();

            string type = HttpContext.Current.Request.Cookies["typeToPrint"].Value.ToLower().Trim();

            string Content = "";
            Content += "<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word'xmlns='http://www.w3.org/TR/REC-html40'>" +
                "<xml><w:WordDocument><w:View>Print</w:View><w:DoNotOptimizeForBrowser/></w:WordDocument></xml>";

            if (type == "magazine" || type == "magazines")
            {
                foreach (string id in Ids)
                {
                    Content += Details.GenerateContent(type, id, true);
                    Content += splitLine;
                }
            }
            else if(type == "book" || type == "books")
            {
                /*
                foreach (string id in Ids)
                {
                    Content += Details.GenerateContent(type, id, true);
                    Content += splitLine;
                }
                */

                foreach (string id in Ids)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "EXEC Ksiazki_RaportKartyKatalogTomy @kod, '', 0;";
                    command.Parameters.AddWithValue("@kod", id);

                    DataTable Dt = CommonFunctions.ReadData(command, ref Settings.ColiberConnection);

                    string table;

                    if (Dt.Rows.Count > 0)
                    {
                        table = "<table class=\"table table-striped table-bordered table-hover table-condensed\">";
                        table += "<tr><td>" + Dt.Rows[0]["haslo"].ToString() + "</td><td colspan=\"2\" align=\"right\">" + (Dt.Columns.Contains("syg") ? Dt.Rows[0]["syg"].ToString() : "") + (Dt.Columns.Contains("sygnatura") ? Dt.Rows[0]["sygnatura"].ToString() : "") + "</td></tr>";

                        table += "<tr><td colspan=\"4\">&emsp;" + Dt.Rows[0]["opis"].ToString() + "</td></tr>";
                        table += "<tr><td colspan=\"4\"><br />" + Dt.Rows[0]["klucze"].ToString() + "</td></tr>";
                        table += "<tr><td colspan=\"3\">" + Dt.Rows[0]["numer_inw"].ToString() + "</td><td>" + Dt.Rows[0]["ukd"].ToString() + "</td></tr>";

                        table += "</table>";


                        table = Regex.Replace(table, "[\n\r]", "<br />&emsp;");

                        Content += table;
                        Content += splitLine;
                    }
                }

            }
            else if (type == "article" || type == "articles")
            {
                foreach (string id in Ids)
                {                    
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "DECLARE @rodzaj_zas char = (SELECT rodzaj_zas FROM artykuly where kod = @kod); " + Environment.NewLine +
                                        "IF @rodzaj_zas = 'C'" + Environment.NewLine +
                                        "	EXEC Artykuly_RaportyDoOpisuKartyKatalog @kod;" + Environment.NewLine +
                                        "ELSE" + Environment.NewLine +
                                        "   EXEC Artykuly_RaportyDoOpisuKartyKatalogKsiazki @kod;";
                    command.Parameters.AddWithValue("@kod", id);

                    DataTable Dt = CommonFunctions.ReadData(command, ref Settings.ColiberConnection);

                    string table;

                    if (Dt.Rows.Count > 0)
                    {
                        table = "<table class=\"table table-striped table-bordered table-hover table-condensed\">";
                        table += "<tr><td align=\"right\">" + (Dt.Columns.Contains("syg") ? Dt.Rows[0]["syg"].ToString() : "") + (Dt.Columns.Contains("sygnatura") ? Dt.Rows[0]["sygnatura"].ToString() : "") + "</td></tr>";
                        table += "<tr><td><br />" + Dt.Rows[0]["autor"].ToString() + "</td></tr>";
                        table += "<tr><td>" + Dt.Rows[0]["opis"].ToString() + "</td></tr>";
                        table += "<tr><td><br />" + Dt.Rows[0]["klucze"].ToString() + "</td></tr>";

                        table += "</table>";

                        Content += table;
                        Content += splitLine;
                    }
                }
            }
            Content += "</html>";

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = Encoding.UTF8.WebName;
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;

            HttpContext.Current.Response.ContentType = "application/msword";

            string strFileName = Language.glossaryDescriptions + ".doc";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + strFileName);

            StringBuilder strHTMLContent = new StringBuilder();
            strHTMLContent.Append(Content);

            //strHTMLContent.Append("<br><br>".ToString()); strHTMLContent.Append("<p align='Center'> Note : This is adynamically generated word document  <  / p > ".ToString());
            HttpContext.Current.Response.Write('\uFEFF');
            HttpContext.Current.Response.Write(strHTMLContent);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }


        protected void TopExportBtn_Click(object sender, EventArgs e)
        {
            GenerateDOC();
        }
    }
}