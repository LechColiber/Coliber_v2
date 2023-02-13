using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Coliber
{
    public partial class License : Form
    {


        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public License()
        {
            InitializeComponent();
            LInfo(true);
            //gdKeyInfo.DataSource = App.tKeyInfo;
        }

        private void cbBuy_Click(object sender, EventArgs e)
        {
            if (cbBuy.Text.Trim() == "Wprowadź dane licencji")
            {
                tLInfo.ReadOnly = false;
                tLInfo.BackColor = SystemColors.Window;
                tLInfo.ForeColor = Color.Black;
                if (App.lLSMode)
                {
                    cbBuy.Text = "Zakup licencji";
                }
                else
                {
                    tLKey.ReadOnly = false;
                    tLKey.BackColor = SystemColors.Window;
                    tLKey.ForeColor = Color.Black;
                    tLKey.Mask = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA";
                    cbBuy.Text = "Pobierz licencję";
                }
                tLInfo.Focus();
            }
            else if (cbBuy.Text.Trim() == "Zweryfikuj dane licencji")
            {
                sendLInfo();
            }
            else
            {
                prepareKey();
            }
        }

        private void cbOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        void LInfo(bool lInit = false)
        {
            string cDate = App.NVL(App.tKeyInfo.Rows[0]["D2"]);
            tLInfo.Text = App.cUser;
            tLKey.Text = App.lLSMode ? App.Hash : App.SID;
            this.tLDate.Text = cDate;
            if (App.lDemo)
            {
                if (App.BadLData > 0) cbBuy.Text = "Zweryfikuj dane licencji";
                else cbBuy.Text = "Wprowadź dane licencji";
            }
            else
            {
                cbBuy.Visible = false;
            }
            if (lInit) return;

            tLInfo.ReadOnly = true;
            tLInfo.BackColor = SystemColors.Info;
            tLInfo.ForeColor = Color.DarkSlateBlue;
            tLKey.ReadOnly = true;
            tLKey.BackColor = SystemColors.Info;
            tLKey.ForeColor = Color.DarkSlateBlue;


/*            if (App.lDemo && !App.lJestKlucz)
            {
                cbBuy.Visible = true;
                if (App.lLSMode)
                {
                    tLInfo.ReadOnly = false;
                    tLInfo.BackColor = SystemColors.Window;
                    tLInfo.ForeColor = Color.Black;
                }
                else
                {
                    cbBuy.Text = "Wprowadź klucz licencji";
                }
            }
            else
            {
                tLDate.Text = cDate;
                cbBuy.Visible = false;
                if (App.lLSMode)
                {
                    tLInfo.ReadOnly = true;
                    tLInfo.BackColor = SystemColors.Info;
                    tLInfo.ForeColor = Color.DarkSlateBlue;
                    tLKey.Text = App.cHash;
                }
                else tLKey.Text = App.SID;
            }
 */
        }

        string OrderInit(string cId)
        {
            return App.GetWS(App.cUrl + "OrderInit?cId=" + cId);
        }

        string OrderCreate(string cId)
        {
            return App.GetWS(App.cUrl + "OrderCreate?cId=" + cId);
        }

        string OrderGetInfo(string cId)
        {
            return App.GetWS(App.cUrl + "OrderGetInfo?cId=" + cId);
        }

        string OrderStatus(string cId)
        {
            return App.GetWS(App.cUrl + "OrderStatus?cId=" + cId);
        }

        string chkSID(string cCId, string cSId)
        {
            return App.GetWS(App.cUrl + "chkSID?CId=" + cCId + "&SId=" + cSId);
        }

        string GetLicense(string cId, string cHash, string cB64)
        {
            return App.GetWS(App.cUrl + "GetLicense?cId=" + cId + "&cHash=" + cHash + "&cB64=" + cB64);
        }

        void sendLInfo()
        {
            string cNew,cB64,cHash,cKey,cNapis;
            cNapis = App.Napis();
            byte[] napis = Encoding.UTF8.GetBytes(cNapis);
            cNew = Convert.ToBase64String(napis);
            cB64 = App.NVL(App.tKeyInfo.Rows[0]["Key1"]);
            cHash = App.NVL(App.tKeyInfo.Rows[0]["Key2"]);
            cKey = App.NVL(App.tKeyInfo.Rows[0]["Key3"]);
            string cStat = App.GetWS(App.cUrl + "LInfo?SID=" + App.SID + "&New=" + cNew);
            string cFunc = cStat.Substring(2);
            cStat = cStat.Substring(0, 2);
            if (cStat == "0$")
            {
                App.Info("Błąd podczas wysyłania informacji o licencji " + "\n" + cFunc);
            }
            if (cStat == "1$")
            {
                App.Info("Informacje o licencji zostały wysłane do weryfikacji " + "\n" + cFunc);
                cbBuy.Visible = false;
            }
        }


        void Navigate(string cUrl)
        {
            if (App.cBrowser == "InternetExplorer.Application")
            {
                Type comObjectType = Type.GetTypeFromProgID(App.cBrowser);
                dynamic theComObject = Activator.CreateInstance(comObjectType, false);
                theComObject.Navigate(cUrl);
                int hWnd = theComObject.HWND;
                ShowWindow((IntPtr)hWnd, 3);
            }
            else if (App.cBrowser == "default")
            {
                System.Diagnostics.Process.Start(cUrl);
            }
            else if (App.cBrowser == "browser")
            {
                Browser fBrowser = new Browser(cUrl);
                DialogResult iRet = fBrowser.ShowDialog();
            }
            else
            {
                if (App.cBrowser == "opera.exe") cUrl = "--disable-update \"" + cUrl + "\"";
                Process myProcess = new Process();
                //myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = App.cBrowser;
                myProcess.StartInfo.Arguments = cUrl;
                myProcess.Start();
            }
        }

        void prepareKey()
        {
            string cSID = "";
            string cDemo = "Wersja demonstracyjna";
            cDemo = "Wersja dla użytkowników indywidualnych";
            string cNazwa = tLInfo.Text.Trim();
            if (cNazwa == "" || cNazwa.StartsWith(cDemo) || cNazwa.StartsWith("Błąd weryfikacji licencji"))
            {
                App.Info("Wypełnij nazwę licencjobiorcy !");
                return;
            }
            if (App.lLSMode == false)
            {
                cSID = tLKey.Text.Trim();
                if (cSID == "")
                {
                    App.Info("Wypełnij klucz licencji !");
                    return;
                }
            }
            int iRet = 0;
            // domena, serwer i MAC
            string cNapis, cName, cKey1, cId;
            int iStat;
            cId = App.NVL(App.tKeyInfo.Rows[0]["Id"]).ToUpper();
            iStat = App.DBInt(App.tKeyInfo.Rows[0]["Stat"]);
            cName = App.NVL(App.tKeyInfo.Rows[0]["Name"]);
            cKey1 = App.NVL(App.tKeyInfo.Rows[0]["Key1"]);
            cNapis = App.Napis(cId, cNazwa, cSID);
            // tworzymy klucze
            SHA1Managed Sha = new SHA1Managed();
            byte[] napis = Encoding.UTF8.GetBytes(cNapis);
            byte[] hashed = Sha.ComputeHash(napis);
            string cHash = Convert.ToBase64String(hashed);
            string cB64 = Convert.ToBase64String(napis);
            // ew aktualizacja tabeli KeyInfo
            string cStat;
            string cFunc;
            if (iStat == 0 && (cName != cNazwa || cB64 != cKey1 || App.SID != cSID))
            {
                SqlCommand cKeyInfo = new SqlCommand("update KeyInfo set Name = @Name,SID = @SID,Key1 = @Key1, Key2 = @Key2 where Id = @Id");
                cKeyInfo.Parameters.Add("@Id", SqlDbType.VarChar).Value = cId;
                cKeyInfo.Parameters.Add("@Name", SqlDbType.VarChar).Value = cNazwa;
                cKeyInfo.Parameters.Add("@SID", SqlDbType.VarChar).Value = cSID;
                cKeyInfo.Parameters.Add("@Key1", SqlDbType.VarChar).Value = cB64;
                cKeyInfo.Parameters.Add("@Key2", SqlDbType.VarChar).Value = cHash;
                iRet = App.SQLExec(cKeyInfo);
                if (iRet < 0)
                {
                    App.Info("Błąd podczas zapisu danych dotyczących Licencji " + "\n" + App.cError);
                    return;
                }
                App.tKeyInfo.Rows[0]["Name"] = cNazwa;
                App.tKeyInfo.Rows[0]["Key1"] = cB64;
                App.tKeyInfo.Rows[0]["Key2"] = cHash;
                App.tKeyInfo.Rows[0]["SID"] = cSID;
                App.SID = cSID;
            }
            // tworzymy rekord zamówienia lub sprawdzamy SID
            if (iStat == 0)
            {
                if (App.lLSMode) cStat = OrderInit(cId);
                else cStat = chkSID(cId,App.SID);
                if (cStat == "1$")
                {
                    iStat = App.lLSMode ? 1 : 4;
                    App.tKeyInfo.Rows[0]["Stat"] = iStat;
                    iRet = App.UpdateStat(cId, iStat);
                    if (iRet < 0)
                    {
                        App.Info("Błąd podczas aktualizacji danych dotyczących Licencji " + "\n" + App.cError);
                        return;
                    }
                }
                else
                {
                    string cText = App.lLSMode ? "prologu zamówienia !" : "pobierania licencji !";
                    App.Info("Błąd podczas " + cText + "\n" + cStat);
                    return;
                }
            }
            // tworzymy zamówienie
            if (iStat == 1)
            {
                cStat = OrderCreate(cId);
                if (cStat.Substring(0, 2) == "1$")
                {
                    iStat = 2;
                    App.tKeyInfo.Rows[0]["Stat"] = iStat;
                    iRet = App.UpdateStat(cId, iStat);
                    if (iRet < 0)
                    {
                        App.Info("Błąd podczas zapisu zamówienia " + "\n" + App.cError);
                        return;
                    }
                }
                else
                {
                    App.Info("Błąd podczas tworzenia zamówienia " + "\n" + cStat);
                    return;
                }
            }
            // pobieramy dane zamówienia i ew potwierdzamy zamówienie
            if (iStat == 2)
            {
                cStat = OrderGetInfo(cId);
                cFunc = cStat.Substring(0, 2);
                if (cFunc == "1$")
                {
                    string cUrl = cStat.Substring(2);
                    cUrl = cUrl.Replace("&amp;", "&");
                    Navigate(cUrl);
                    MessageBox.Show("Zakup licencji programu Co-Liber", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    iStat = 3;
                    App.tKeyInfo.Rows[0]["Stat"] = iStat;
                    iRet = App.UpdateStat(cId, iStat);
                    if (iRet < 0)
                    {
                        App.Info("Błąd podczas aktualizacji stanu zamówienia " + "\n" + App.cError);
                        return;
                    }
                }
                else
                {
                    App.Info("Błąd podczas pobierania danych zamówienia !" + "\n" + cStat);
                    return;
                }
            }
            // sprawdzamy status zamówienia
            if (iStat == 3)
            {
                cStat = OrderStatus(cId);
                cFunc = cStat.Substring(2);
                cStat = cStat.Substring(0, 2);
                if (cStat == "0$")
                {
                    App.Info("Błąd podczas pobierania statusu zamówienia " + "\n" + cFunc);
                    return;
                }
                if (cStat == "1$")
                {
                    App.Info("Zamówienie niepotwierdzone !");
                    Navigate(cFunc);
                    return;
                }
                if (cStat == "2$")
                {
                    App.Info("Zamówienie niegotowe " + "\n" + cFunc);
                    return;
                }
                if (cStat == "3$")
                {
                    App.Info("Zamówienie anulowane " + "\n" + cFunc);
                    iStat = 6;
                }
                if (cStat == "4$")
                {
                    int iPID = 0;
                    if (cFunc != "") iPID = Int32.Parse(cFunc);
                    iStat = 4;
                    App.tKeyInfo.Rows[0]["Stat"] = iStat;
                    iRet = App.UpdateStat(cId, iStat, iPID);
                    if (iRet < 0)
                    {
                        App.Info("Błąd podczas zatwierdzania płatności " + "\n" + App.cError);
                        return;
                    }
                }
            }
            // pobieramy licencję
            if (iStat == 4)
            {
                cStat = GetLicense(cId, cHash, cB64);
                cFunc = cStat.Substring(2);
                cStat = cStat.Substring(0, 2);
                if (cStat == "0$")
                {
                    App.Info("Błąd podczas pobierania licencji " + "\n" + cFunc);
                    return;
                }
                if (cStat == "1$")
                {
                    if (!App.VerifyL(cHash, cFunc)) return;
                    iStat = 5;
                    DateTime d2 = DateTime.Now;
                    App.tKeyInfo.Rows[0]["Name"] = cName;
                    App.tKeyInfo.Rows[0]["D2"] = d2;
                    App.tKeyInfo.Rows[0]["Key3"] = cFunc;
                    SqlCommand cKeyInfo = new SqlCommand("update KeyInfo set D2 = @D2,Key3 = @Key3, Stat = 5 where Id = @Id");
                    cKeyInfo.Parameters.Add("@Id", SqlDbType.VarChar).Value = cId;
                    cKeyInfo.Parameters.Add("@D2", SqlDbType.DateTime).Value = d2;
                    cKeyInfo.Parameters.Add("@Key3", SqlDbType.VarChar).Value = cFunc;
                    iRet = App.SQLExec(cKeyInfo);
                    if (iRet < 0)
                    {
                        App.Info("Błąd podczas zapisu Licencji " + "\n" + App.cError);
                        return;
                    }
                    App.lDemo = false;
                }
            }
            if (iStat == 5)
            {
                LInfo();
            }
            if (iStat == 6)
            {
                App.tKeyInfo.Rows[0]["Stat"] = iStat;
                iRet = App.UpdateStat(cId, iStat);
                if (iRet < 0)
                {
                    App.Info("Błąd podczas anulowania zamówienia " + "\n" + App.cError);
                    return;
                }
            }
        }

       
        /*
        void Old()
        {

                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["thing1"] = "hello";
                    values["thing2"] = "world";

                    var response = client.UploadValues("http://www.example.com/recepticle.aspx", values);

                    var responseString = Encoding.Default.GetString(response);
                }


            using (var client = new WebClient())
            {
                var responseString = client.DownloadString("http://whatismyip.akamai.com");
                DataTable Dt = new DataTable();
                string cNapis;
                cNapis = (string)Dt.Rows[0][0];
                cNapis = cNapis + "$" + (string)Dt.Rows[0][1];
                cNapis = cNapis + "$" + (string)Dt.Rows[0][2];
                cNapis = cNapis + "$" + responseString;

        cNapis = @"EXELL04$EB-46-0E-7C-74-54$MSSQL1\FSE21$194.181.21.138";



                SHA1Managed Sha = new SHA1Managed();
                byte[] hashed = Sha.ComputeHash(Encoding.UTF8.GetBytes(cNapis));
                byte[] signature;
                byte[] encrypted = null;
                byte[] decrypted = null;
                string cHash = Convert.ToBase64String(hashed);
                string cSignature = "";
                string cOK = "-empty-";
                string cCert = "TEST_CER";


                
                CspParameters cspParam = new CspParameters();
                cspParam.Flags = CspProviderFlags.UseMachineKeyStore;
                cspParam.KeyContainerName = "MyKeyContainerName";
                RSACryptoServiceProvider csp = new RSACryptoServiceProvider(cspParam);
                

                X509Certificate2 x509 = GetCert(cCert);
                RSACryptoServiceProvider csp = (RSACryptoServiceProvider)x509.PrivateKey;


                //string privateKey = csp.ToXmlString(true);
                string publicKey = csp.ToXmlString(false);

                //csp.FromXmlString(privateKey);

 //               File.WriteAllText(@"C:\Program\Xades\Key.XML", publicKey);

                signature = csp.SignHash(hashed, CryptoConfig.MapNameToOID("SHA1"));
                cSignature = Convert.ToBase64String(signature);

                X509Certificate2 x509pub = GetCert2(cCert);

                RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)x509pub.PublicKey.Key;
                //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParam);
                //rsa.FromXmlString(publicKey);

                    try
                    {
                        encrypted = rsa.Encrypt(Encoding.UTF8.GetBytes(cNapis),false);
                        bool success = rsa.VerifyHash(hashed, CryptoConfig.MapNameToOID("SHA1"), signature);
                        if (success) cOK = "OK"; else cOK = "Bad";
                    }
                    catch (CryptographicException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        rsa.PersistKeyInCsp = false;
                    }

                    decrypted = csp.Decrypt(encrypted, false);
                    string cDecrypted = Encoding.UTF8.GetString(decrypted);
                    string cEncrypted = Convert.ToBase64String(encrypted);
                
                //    string cDecrypted = TestEncDec("HelloTherre");

                    cNapis = Convert.ToBase64String(Encoding.UTF8.GetBytes(cNapis));
                    cNapis = cNapis + "\r\n" + cHash + "\r\n" + cSignature + "\r\n" + cOK + "\r\n" + cDecrypted + "\r\n" + cEncrypted;
                    if (MessageBox.Show("Zapisać do schowka ?", "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Clipboard.SetText(cNapis);
                    }
                    MessageBox.Show(cNapis);



                                byte[] hashed1 = Sha.ComputeHash(Encoding.ASCII.GetBytes(cNapis));
                string cHash1 = Convert.ToBase64String(hashed1);
                byte[] hashed2 = Sha.ComputeHash(Encoding.Unicode.GetBytes(cNapis));
                string cHash2 = Convert.ToBase64String(hashed2);
                byte[] hashed3 = Sha.ComputeHash(GetBytes1(cNapis));
                string cHash3 = Convert.ToBase64String(hashed3);

                MessageBox.Show(cNapis + "\n" + cHash + "\n" + cHash1 + "\n" + cHash2 + "\n" + cHash3 + "\n" + hashed1.Length.ToString() + "\n" + hashed2.Length.ToString());
 
            }  

        }
        */

        /*
        public string TestEncDec(string str)
        {
            CspParameters cspParam = new CspParameters();
            cspParam.Flags = CspProviderFlags.UseMachineKeyStore;
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(cspParam);
            string publicKey = RSA.ToXmlString(false);
            string privateKey = RSA.ToXmlString(true);
//            File.WriteAllText(@"C:\Program\Xades\Key1.TXT", privateKey);
            RSACryptoServiceProvider RSA2 = new RSACryptoServiceProvider();
            RSA2.FromXmlString(publicKey);
            byte[] EncryptedStrAsByt = RSA2.Encrypt(System.Text.Encoding.UTF8.GetBytes(str), false);
            object EncryptedStrAsString = System.Text.Encoding.UTF8.GetString(EncryptedStrAsByt);
            RSACryptoServiceProvider RSA3 = new RSACryptoServiceProvider(cspParam);
            RSA3.FromXmlString(privateKey);
            byte[] DecryptedStrAsByt = RSA3.Decrypt(EncryptedStrAsByt, false);
            string DecryptedStrAsString = System.Text.Encoding.UTF8.GetString(DecryptedStrAsByt);
            return DecryptedStrAsString;
        }
        */
    }
}
