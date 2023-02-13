using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebColiber.App_GlobalResources;

namespace WebColiber
{
    public partial class _Novelties : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public static void GenerateDOC()
        {
            string splitLine = "<hr />";
            string Content = "";
            if (HttpContext.Current.Request.Cookies["order"] == null)
            {
            }
            else
            {
                string Cookie = HttpContext.Current.Request.Cookies["order"].Value;
                List<string> Ids = new List<string>();
                if (Cookie == null) Cookie = "-1";
                if (Cookie == "") Cookie = "-2";
                Cookie = Cookie.Replace("$", "");
                Cookie = Cookie.Remove(Cookie.Length - 1);

                WriteLog(Cookie, true);

                if (Cookie != null)
                    Ids = Cookie.Split(',').ToList();

                string type = "books";

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
                else if (type == "book" || type == "books")
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
            }

            HttpContext.Current.Response.Clear();
            if (Content == "")
            {
                HttpContext.Current.Response.Write('\uFEFF');
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            else
            {
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
        }


        protected void TopExportBtn_Click(object sender, EventArgs e)
        {
            GenerateDOC();
        }

        public static void WriteLog(String sInfo, bool lNew = false)
        {
            String cPath = "C:\\Log.TXT";
            //StreamWriter w;
            try
            {
                FileInfo logFile = new FileInfo(cPath);
                if (logFile.Exists & (lNew | logFile.Length > 100000))
                    File.Delete(cPath);


                File.AppendAllText(cPath, "\n --- " + DateTime.Now.ToString() + " --- \n" + sInfo);

                /*w = File.AppendAllText(cPath);
                w.WriteLine("-------------------------------");
                w.WriteLine(sInfo);
                w.WriteLine(DateTime.Now);
                // Update the underlying file.
                w.Close();*/
            }
            catch (Exception)
            {
                ;
            }

        }
        

    }
}
