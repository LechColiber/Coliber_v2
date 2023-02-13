using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zoom.Net;
using Zoom.Net.YazSharp;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Threading;

namespace Ksiazki
{
    class Z3950Connection
    {
        /*
        Błędy         
         * -1 błąd połaczenia
         * -2 nie nawiązano połączenia
         * -3 błąd składni zapytania
        */
        private string Host;
        private int Port;
        private string Username;
        private string Password;
        private string DatabaseName;
        private bool isConnected;
        private Zoom.Net.YazSharp.Connection YazConnection;

        private Exception exception;

        public bool IsConnected
        {
            get { return isConnected; }
        }

        public Z3950Connection(string Host, int Port, string DatabaseName, string Username, string Password)
        {
            this.exception = null;
            this.Password = Password;
            this.Host = Host;
            this.Port = Port;
            this.Username = Username;
            this.DatabaseName = DatabaseName;
        }

        public int Connect()
        {
            try
            {
                YazConnection = new Connection(Host, Port);
                YazConnection.DatabaseName = DatabaseName;
                YazConnection.Username = Username;
                YazConnection.Password = Password;
                YazConnection.Syntax = Zoom.Net.RecordSyntax.XML;
                isConnected = true;
                return 0;
            }
            catch(Exception excep) 
            {
                this.exception = excep;
                //MessageBox.Show(excep.Message);
                isConnected = false;
                return -1;
            }
        }

        public XmlDocument QueryZ3950XML(string Title, string ISBN, string Author, string Publisher, string Year)
        {
            string ss;
            XmlDocument outXml = new XmlDocument();
            string queryString = "";

            if (!isConnected)
            {
                //MessageBox.Show(exception.Message);
                if (exception != null)
                {
                    ss = "<root><error><id>-1</id><message>" + exception.Message + "</message></error></root>";
                }
                else
                {
                    ss = "<root><error><id>-2</id><message>" + exception.Message + "</message></error></root>";
                }

                outXml.LoadXml(ss);
                return outXml;
            }

            exception = null;
        
            try
            {
                /*
                 *   Autor	            1003
                     Tytuł	            4
                     Przedmiot  	    21
                     ISSN	            8
                     ISBN	            7
                     Uwaga  	        63
                     Zawartość	        1016
                     Seria	            5
                     Wydawca	        1018
                     Data wydania	    31
                     Miejsce wydania	59
                     UKD	            14
                 * 
                 */

                //queryString = "@attr 1=4 1=1003 \"potop\" \"Sienkiewicz, Henryk\"";
                //queryString = "@and @and @attr 1=1003 \"Sienkiewicz, Henryk\" @attr 1=4 Potop @attr 1=7 978-83-89968-92-0";  
                int n = 0;

                if (Title.Length > 0)
                {
                    queryString += " @attr 1=4 \"" + Title + "\"";
                    n++;
                }
                if (ISBN.Length > 0)
                {
                    queryString += " @attr 1=7 \"" + ISBN + "\"";
                    n++;
                }
                if (Author.Length > 0)
                {
                    queryString += " @attr 1=1003 \"" + Author + "\"";
                    n++;
                }
                if (Publisher.Length > 0)
                {
                    queryString += " @attr 1=1018 \"" + Publisher + "\"";
                    n++;
                }
                if (Year.Length > 0)
                {
                    queryString += " @attr 1=31 \"" + Year + "\"";
                    n++;
                }
                
                while (n-- > 1)
                    queryString = queryString.Insert(0, "@and ");

                //MessageBox.Show(queryString);
                //queryString = "@and @attr 1=4 \"Diuna\" @attr 1=1003 \"Herbert\"";
                Zoom.Net.YazSharp.PrefixQuery qq = new PrefixQuery(queryString);
                
                IResultSet Result = YazConnection.Search(qq);
                
                if (Result.Count == 0)
                {
                    ss = "<root><count>0</count></root>";
                    outXml.LoadXml(ss);
                    return outXml;
                }

                ss = "<root><count>" + Result.Count.ToString() + "</count><results>";

                for (int i = 0; i < Result.Count; i++)
                {
                    ss += Encoding.UTF8.GetString(Result[i].Content);
                    
                    //System.Diagnostics.Trace.WriteLine(i.ToString() + " " + Result[i].Content.Length.ToString());// + " " + Encoding.UTF8.GetString(Result[i].Content));

                    if (i == Settings.MaxRecords - 1)
                        break;
                }
                
                ss += "</results></root>";

                outXml.LoadXml(ss);

                return outXml;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.exception = ex;

                ss = "<root><error><id>-4</id><message>" + exception.Message + "</message><qs>" + queryString + "</qs></error></root>";

                outXml.LoadXml(ss);
                return outXml;               
            }
        }
    }
}
