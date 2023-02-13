using System;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Net;
using System.Drawing;


namespace Coliber
{
    public static class App
    {
        public static bool lDemo = true;
        public static bool lJestKlucz = false;
        public static bool lLSMode = false;
        public static int BadLData = 0;
        //public static string cUser = "Wersja demonstracyjna";
        //public static string cUser = "Wersja dla użytkowników indywidualnych";
        public static string cUser = "";
        public static string SID = "";
        public static string cError = "";
        public static string cConn = "";
        public static string cUrl = "";
        public static string cCert = "";
        public static string cLKey = "";
        public static string Hash = "";
        public static string cPath = "";
        public static string cBrowser = "";
        public static DataTable tKeyInfo = null;
        public static DataTable tIInfo = null;
        public static string LangID = null;


        public static void Init()
        {

            IniFile coliberConfigs = new IniFile("coliber.ini", "Coliber");
            if (string.IsNullOrEmpty(coliberConfigs.path))
            {
                Environment.Exit(0);
            }
            cPath = System.IO.Directory.GetCurrentDirectory();
            cUrl = coliberConfigs.ReadIni("LicenseWS", "Url");
            cConn = Settings.coliberConnectionString;
            cCert = coliberConfigs.ReadIni("LicenseWS", "Cert");
            cBrowser = coliberConfigs.ReadIni("LicenseWS", "Browser");
            SqlCommand cLang = new SqlCommand("select id from jezyki where jezyk = 'POL'");
            DataTable Dt = SQLSelect(cLang);

            if (Dt.Rows.Count > 0)
            {
                LangID = NVL(Dt.Rows[0]["id"]);
            }


                /*
                if (cUrl == "") cUrl = "http://www.warnet.pl:8082/LicenseWS.asmx/";
                if (cCert == "") cCert = "TEST_CER";
                */

                /*
                GetKeyInfo();
                if (tKeyInfo != null && tKeyInfo.Rows.Count > 0)
                {
                    Hash = NVL(tKeyInfo.Rows[0]["Key2"]);
                    cLKey = NVL(tKeyInfo.Rows[0]["Key3"]);
                    SID = NVL(tKeyInfo.Rows[0]["SID"]);
                    if (cLKey == "") return;
                    if (!VerifyH(Hash)) { lDemo = true; return; }
                    if (VerifyL(Hash, cLKey, true)) lDemo = false;
                }
                */
            }

            public static int UpdateStat(string cId, int iStat, int iPID = 0)
        {
            SqlCommand cKeyInfo = new SqlCommand("update KeyInfo set Stat = @Stat,PID = @PID where Id = @Id");
            cKeyInfo.Parameters.Add("@Id", SqlDbType.VarChar).Value = cId;
            cKeyInfo.Parameters.Add("@Stat", SqlDbType.Int).Value = iStat;
            cKeyInfo.Parameters.Add("@PID", SqlDbType.Int).Value = iPID;
            return SQLExec(cKeyInfo);
        }

        public static void GetKeyInfo()
        {
            SqlCommand cIInfo = new SqlCommand("Exec spKeyInfo");
            SqlCommand cKeyInfo = new SqlCommand("select * from KeyInfo where stat <> 6");
            tIInfo = SQLSelect(cIInfo);
            tKeyInfo = SQLSelect(cKeyInfo);
        }
        public static string GetIP()
        {
            return "127.0.0.1";
            //return GetWS(App.cUrl + "getIP");
        }

        public static string GetWS(string cRequest)
        {
            string xml = "0$";
            using (WebClient client = new WebClient())
            {
                try
                {
                    xml = client.DownloadString(cRequest);
                }
                catch (WebException we)
                {
                    return "0$1" + we.Message;
                }
                catch (Exception ex)
                {
                    return "0$2" + ex.Message;
                }
            }
            string cRet = "0$3" + xml;
            int iStart, iStop;
            iStart = App.IndexOf(xml, ">", 2);
            if (iStart > 0)
            {
                iStop = xml.IndexOf('<', iStart);
                if (iStop > 0) cRet = xml.Substring(iStart + 1, iStop - iStart - 1);

            }
            return cRet;
        }

        public static string Napis(string cId = "", string cName = "", string cSID = "")
        {
            string cIP = App.GetIP();
            if (cIP.Substring(0, 2) == "0$") { App.Info(cIP); return ""; }
            if (cId == "") cId = App.NVL(App.tKeyInfo.Rows[0]["Id"]).ToUpper();
            if (cName == "") cName = App.NVL(App.tKeyInfo.Rows[0]["Name"]);
            if (cSID == "") cSID = App.NVL(App.tKeyInfo.Rows[0]["SID"]);
            string cNapis = "";
            cNapis = cId + "$" + cName + "$" + (string)App.tIInfo.Rows[0][0];
            cNapis = cNapis + "$" + (string)App.tIInfo.Rows[0][1];
            cNapis = cNapis + "$" + (string)App.tIInfo.Rows[0][2];
            cNapis = cNapis + "$" + (string)App.tIInfo.Rows[0][3];
            cNapis = cNapis + "$" + cIP;
            cNapis = cNapis + "$" + cSID;
            return cNapis;
        }

        public static bool VerifyH(string cCompare)
        {
            bool lOK;
            cUser = "Błąd weryfikacji licencji (1) !";
            string cNapis;
            cNapis = App.Napis();
            // tworzymy klucze
            SHA1Managed Sha = new SHA1Managed();
            byte[] napis = Encoding.UTF8.GetBytes(cNapis);
            byte[] hashed = Sha.ComputeHash(napis);
            string cHash = Convert.ToBase64String(hashed);
            lOK =  cHash == cCompare;
            if (!lOK) App.BadLData = 1;
            return lOK;
        }

        public static bool VerifyL(string cHash, string cSignature, bool lNoInfo = false)
        {
            cUser = "Błąd weryfikacji licencji (2) !";
            lJestKlucz = true;
            X509Certificate2 x509pub = GetCert(cCert);
            if (x509pub == null)
            {
                Info("GetCert " + cCert);
                return false;
            }
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)x509pub.PublicKey.Key;
            byte[] signature;
            byte[] hashed;
            hashed = Convert.FromBase64String(cHash);
            signature = Convert.FromBase64String(cSignature);
            bool success = false;
            try
            {
                success = rsa.VerifyHash(hashed, CryptoConfig.MapNameToOID("SHA1"), signature);
            }
            catch (CryptographicException e)
            {
                Info("vx_si" + e.Message);
                return false;
            }
            if (!success)
            {
                BadLData = 2;
                if (!lNoInfo) MessageBox.Show("Nieprawidłowy klucz licencji !", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            if (tKeyInfo == null || tKeyInfo.Rows.Count == 0 || tIInfo == null || tIInfo.Rows.Count == 0) return success;
            string cB64, cText;
            cB64 = NVL(tKeyInfo.Rows[0]["Key1"]);
            byte[] bytes = Convert.FromBase64String(cB64);
            cText = Encoding.UTF8.GetString(bytes);
            string[] aInfo = null;
            aInfo = cText.Split('$');
            cText = "Klucz :" + "\t" + NVL(tKeyInfo.Rows[0]["Id"] + "\t" + aInfo[0]) + "\r\n";
            cText = cText + "Nazwa :" + "\t" + NVL(tKeyInfo.Rows[0]["Name"]) + "\t" + aInfo[1] + "\r\n";
            cText = cText + "Domena :" + "\t" + NVL(tIInfo.Rows[0][0]) + "\t" + aInfo[2] + "\r\n";
            cText = cText + "MAC :" + "\t" + NVL(tIInfo.Rows[0][1]) + "\t" + "\t" + aInfo[3] + "\r\n";
            cText = cText + "SQL :" + "\t" + NVL(tIInfo.Rows[0][2]) + "\t" + aInfo[4] + "\r\n";
            cText = cText + "? :" + "\t" + NVL(tIInfo.Rows[0][3]) + "\t" + aInfo[5] + "\r\n";
            //
            if (success)
            {
                cUser = NVL(tKeyInfo.Rows[0]["Name"]);
                cHash = NVL(tKeyInfo.Rows[0]["Key2"]);
            }
            //Info(cText);
            return success;
        }


        public static string NVL(Object oVal)
        {
            if (oVal == DBNull.Value)
                return "";
            else
                return oVal.ToString().Trim();
        }

        public static int DBInt(Object oVal)
        {
            if (oVal == DBNull.Value)
                return 0;
            else
                return (int)oVal;
        }

        public static DateTime DBDateT(Object oVal)
        {
            if (oVal == DBNull.Value)
                return new DateTime(1901, 1, 1);
            else
                return (DateTime)oVal;
        }

        public static int IndexOf(string str, string c, int nth = 1, int startPosition = 0)
        {
            int index = str.IndexOf(c, startPosition);
            if (index >= 0 && nth > 1)
            {
                return IndexOf(str, c, nth - 1, index + 1);
            }
            return index;
        }

        public static SqlConnection SQLConnect()
        {
            if (cConn == "") { MessageBox.Show("Nieprawidłowy ciąg połączenia","Błąd SQL1",MessageBoxButtons.OK,MessageBoxIcon.Error); return null; }
            return new SqlConnection(cConn);
        }

        public static DataTable SQLSelect(SqlCommand cmd, SqlConnection con = null)
        {
            DataTable tabela = new DataTable();
            bool lClose = false;
            if (con == null)
            {
                lClose = true;
                con = SQLConnect();
                if (con == null) { MessageBox.Show("Błąd połączenia", "Błąd SQL2", MessageBoxButtons.OK, MessageBoxIcon.Error); return tabela; }
            }
            try
            {
                if (con.State != ConnectionState.Open) con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd.Connection = con;
                    SqlDataReader reader = cmd.ExecuteReader();
                    tabela.Load(reader);
                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (SqlException SqlEx)
            {
                con.Dispose();
                cError = SqlEx.Message;
                MessageBox.Show(cError, "Błąd SQL3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex)
            {
                con.Dispose();
                cError = Ex.Message;
                MessageBox.Show(cError, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (lClose == true) con.Dispose();
            return tabela;
        }

        public static DataTable SQLSelect(string cSQL, CommandType TypSQL = CommandType.TableDirect, SqlConnection con = null)
        {
            if (TypSQL == CommandType.TableDirect)
            {
                cSQL = "select * from " + cSQL;
                TypSQL = CommandType.Text;
            }
            DataTable tabela = new DataTable();
            bool lClose = false;
            if (con == null)
            {
                lClose = true;
                con = SQLConnect();
                if (con == null)
                {
                    MessageBox.Show("Błąd połączenia", "Błąd SQL4", MessageBoxButtons.OK, MessageBoxIcon.Error); return tabela;
                }
            }
            try
            {
                if (con.State != ConnectionState.Open) con.Open();
                if (con.State == ConnectionState.Open)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = TypSQL;
                    cmd.CommandText = cSQL;
                    SqlDataReader reader = cmd.ExecuteReader();
                    tabela.Load(reader);
                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (SqlException SqlEx)
            {
                con.Dispose();
                cError = SqlEx.Message;
                MessageBox.Show(cError, "Błąd SQL5", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex)
            {
                con.Dispose();
                cError = Ex.Message;
                MessageBox.Show(cError, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (lClose == true) con.Dispose();
            return tabela;
        }

        public static int GetId(string cKey)
        {
            SqlConnection ca = SQLConnect();
            SqlCommand cmd = new SqlCommand("GetId", ca);
            SqlParameter p1, p2;
            int iNumer = 0;
            p1 = new SqlParameter("@cKey", cKey);
            p1.Direction = ParameterDirection.Input;
            p2 = new SqlParameter("@iNumer", iNumer);
            p2.Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            try
            {
                ca.Open();
                cmd.ExecuteNonQuery();
                iNumer = (int)cmd.Parameters["@iNumer"].Value;
            }
            catch (SqlException SqlEx)
            {
                cError = SqlEx.Message;
                MessageBox.Show(cError, "Błąd SQL6", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iNumer = -1;
            }
            catch (Exception Ex)
            {
                cError = Ex.Message;
                MessageBox.Show(cError, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                iNumer = -2;
            }
            return iNumer;
        }


        public static int SQLExec(SqlCommand cmd, SqlConnection con = null)
        {
            bool lClose = false;
            int ret = 1;
            try
            {
                if (con == null)
                {
                    lClose = true;
                    con = SQLConnect();
                    if (con == null)
                    {
                        MessageBox.Show(cError, "Błąd SQL7", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -3;
                    }
                }
                if (con.State != ConnectionState.Open) con.Open();
                if (con.State == ConnectionState.Open)
                {
                    //Clipboard.SetText(cSQL);
                    //Utils.Info(cSQL,"I");
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    ret = -4;
                }
            }
            catch (SqlException SqlEx)
            {
                cError = SqlEx.Message;
                ret = -1;
                MessageBox.Show(cError, "Błąd SQL8", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex)
            {
                cError = Ex.Message;
                ret = -2;
                MessageBox.Show(cError, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (lClose && con != null) con.Dispose();
            return ret;
        }

        public static void Info(string cNapis, string cTyp = "I")
        {
            MessageBox.Show(cNapis);
        }

        public static X509Certificate2 GetCert(string cCert)
        {
            X509Certificate2 Cert = null;
            try
            {
                string cPlik = cPath + @"\" + cCert;
                string cExt = Path.GetExtension(cPlik).ToLower();
                string Extensions = ".cer.crt.der.key.pem.p7b.p7c.pfx.p12";
                if (Extensions.IndexOf(cExt) != -1 && File.Exists(cPlik))
                {
                    /*
                    FileStream fs = new FileStream(cPlik, FileMode.Open);
                    byte[] certBytes = new byte[fs.Length];
                    fs.Read(certBytes, 0, (Int32)fs.Length);
                    fs.Close();
                    Cert = new X509Certificate2(certBytes);
                    */
                    Cert = new X509Certificate2(cPlik);
                }
                else
                {
                    var store = new X509Store(StoreLocation.CurrentUser);
                    //var store = new X509Store(StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadOnly);
                    var certificates = store.Certificates;
                    foreach (var certificate in certificates)
                    {
                        //MessageBox.Show(certificate.FriendlyName);
                        if (certificate.FriendlyName.Contains(cCert))
                        {
                            Cert = certificate;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                cError = "GetCert: " + e.Message;
                return null;
            }
            if (Cert == null) { cError = "GetCert: null"; return null; }
            if (Cert.PrivateKey == null) cError = "GetCert: pk";
            if (Cert.NotAfter < DateTime.Now) cError = "GetCert: expired";

            return Cert;
        }

        public static int LogIn(string userName, string Password, ref SqlConnection connection)
        {
            SqlCommand Command = new SqlCommand();

            // App.WriteLog(UserName + "\r\n" + Password + "\r\n" + connection.ConnectionString.ToString() );

            Command.CommandText = "SELECT dbo.LogInToDb(@nazwa, @Haslo); ";
            Command.Parameters.AddWithValue("@nazwa", userName);
            Command.Parameters.AddWithValue("@Haslo", Password);
            Command.CommandTimeout = 5;
            DataTable Dt = null;
            try
            {
                Dt = CommonFunctions.ReadData(Command, ref connection);
            }
            catch( Exception e)
            {
                cError = "Login: " + e.Message;
                return -1;
            }
            if (Dt == null || Dt.Rows.Count == 0)
                return -1;

            Settings.UserName = userName;
            return (int)Dt.Rows[0][0];

            // -1 - błąd
            // -2 - błąd logowania
            //  >= 0 - zalogowano
        }



        public static void WriteLog(String sInfo, Boolean lNew = false)
        {
            string cLog = cPath + "App.LOG";
            //if (lNew & File.Exists(cLog)) File.Delete(cLog);
            //File.AppendAllText(cLog, "\r\n --- " + DateTime.Now.ToString() + " --- \r\n" + sInfo);

        }


public static DialogResult InputBox(string title, string promptText, ref string value)
    {
        Form form = new Form();
        Label label = new Label();
        TextBox textBox = new TextBox();
        Button buttonOk = new Button();
        Button buttonCancel = new Button();

        form.Text = title;
        label.Text = promptText;
        textBox.Text = value;

        buttonOk.Text = "OK";
        buttonCancel.Text = "Cancel";
        buttonOk.DialogResult = DialogResult.OK;
        buttonCancel.DialogResult = DialogResult.Cancel;

        label.SetBounds(9, 20, 372, 13);
        textBox.SetBounds(12, 36, 372, 20);
        buttonOk.SetBounds(228, 72, 75, 23);
        buttonCancel.SetBounds(309, 72, 75, 23);

        label.AutoSize = true;
        textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        form.ClientSize = new Size(396, 107);
        form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
        form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
        form.FormBorderStyle = FormBorderStyle.FixedDialog;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.MinimizeBox = false;
        form.MaximizeBox = false;
        form.AcceptButton = buttonOk;
        form.CancelButton = buttonCancel;

        DialogResult dialogResult = form.ShowDialog();
        value = textBox.Text;
        return dialogResult;
    }
}
}
