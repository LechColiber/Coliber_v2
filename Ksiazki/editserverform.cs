using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;

namespace Ksiazki
{
    public partial class EditServerForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private int ID;
        private bool IsAdd;
        private string cServerCfg;

        XmlNode IDXMLNode;
        XmlNode NameXMLNode;
        XmlNode HostXMLNode;
        XmlNode PortXMLNode;
        XmlNode DatabaseXMLNode;
        XmlNode UserXMLNode;
        XmlNode PassXMLNode;
        XmlNode CommentsXMLNode;

        public EditServerForm(int ID, bool IsAdd, string Caption)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();
            this.ID = ID;
            this.IsAdd = IsAdd;
            this.Text = Caption;

            foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(System.Windows.Forms.Label) & C.Name != "label1")
                {
                    C.Text = C.Text.Replace(":", "") + ":";
                }
            }
            cServerCfg = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Exell\\ServersConfig.XML";
            if (!IsAdd)
                LoadData();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "edit_server");
            mapping.Add(label1, "remarks");
            mapping.Add(CancelButton, "cancel");
            mapping.Add(SaveButton, "confirm");
            mapping.Add(PasswordLabel, "password");
            mapping.Add(UserLabel, "user");
            mapping.Add(DatabaseLabel, "database");
            mapping.Add(NameLabel, "server_name");
            mapping.Add(AddressLabel, "server_address");
            mapping.Add(PortLabel, "port");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void LoadData()
        {
            try
            {
                XmlDocument XMLDocConfig = new XmlDocument();
                XMLDocConfig.Load(cServerCfg);

                /*IDXMLNode = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("id");
                NameXMLNode = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("name");
                HostXMLNode = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("host");
                PortXMLNode = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("port");
                DatabaseXMLNode = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("database");
                UserXMLNode = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("user");
                PassXMLNode = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("password");*/

                NameTextBox.Text = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("name").InnerText;
                AddressTextBox.Text = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("host").InnerText;
                PortTextBox.Text = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("port").InnerText;
                DatabaseTextBox.Text = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("database").InnerText;
                UserTextBox.Text = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("user").InnerText;
                PasswordTextBox.Text = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("password").InnerText;
                CommentsTextBox.Text = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]").SelectSingleNode("comments").InnerText;
            }
            catch (Exception Ex)
            {

            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Trim() == "")
            {
                MessageBox.Show(_T("name_cannot_be_blank"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                NameTextBox.Focus();
            }
            else if (AddressTextBox.Text.Trim() == "")
            {
                MessageBox.Show(_T("address_cannot_be_blank"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                AddressTextBox.Focus();
            }
            else if (PortTextBox.Text.Trim() == "")
            {
                MessageBox.Show(_T("port_cannot_be_blank"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                PortTextBox.Focus();
            }
            else if (DatabaseTextBox.Text.Trim() == "")
            {
                MessageBox.Show(_T("database_cannot_be_blank"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                DatabaseTextBox.Focus();
            }
            else
            {
                AddNewServer();

                this.Dispose();
            }
        }

        private void AddNewServer()
        {
            try
            {
                XmlDocument XMLDocConfig = new XmlDocument();
                XMLDocConfig.Load(cServerCfg);

                XmlNode ConnectionXMLNode = XMLDocConfig.CreateNode(XmlNodeType.Element, "connection", "");

                IDXMLNode = XMLDocConfig.CreateNode(XmlNodeType.Element, "id", "");
                IDXMLNode.InnerText = ID.ToString();
                NameXMLNode = XMLDocConfig.CreateNode(XmlNodeType.Element, "name", "");
                NameXMLNode.InnerText = NameTextBox.Text.Trim();
                HostXMLNode = XMLDocConfig.CreateNode(XmlNodeType.Element, "host", "");
                HostXMLNode.InnerText = AddressTextBox.Text.Trim();
                PortXMLNode = XMLDocConfig.CreateNode(XmlNodeType.Element, "port", "");
                PortXMLNode.InnerText = PortTextBox.Text.Trim();
                DatabaseXMLNode = XMLDocConfig.CreateNode(XmlNodeType.Element, "database", "");
                DatabaseXMLNode.InnerText = DatabaseTextBox.Text.Trim();
                UserXMLNode = XMLDocConfig.CreateNode(XmlNodeType.Element, "user", "");
                UserXMLNode.InnerText = UserTextBox.Text.Trim();
                PassXMLNode = XMLDocConfig.CreateNode(XmlNodeType.Element, "password", "");
                PassXMLNode.InnerText = PasswordTextBox.Text.Trim();
                CommentsXMLNode = XMLDocConfig.CreateNode(XmlNodeType.Element, "comments", "");
                CommentsXMLNode.InnerText = CommentsTextBox.Text.Trim();

                ConnectionXMLNode.AppendChild(IDXMLNode);
                ConnectionXMLNode.AppendChild(NameXMLNode);
                ConnectionXMLNode.AppendChild(HostXMLNode);
                ConnectionXMLNode.AppendChild(PortXMLNode);
                ConnectionXMLNode.AppendChild(DatabaseXMLNode);
                ConnectionXMLNode.AppendChild(UserXMLNode);
                ConnectionXMLNode.AppendChild(PassXMLNode);
                ConnectionXMLNode.AppendChild(CommentsXMLNode);

                if (IsAdd)
                {
                    XMLDocConfig.DocumentElement.AppendChild(ConnectionXMLNode);
                    XMLDocConfig.Save(cServerCfg);
                }
                else
                {
                    XmlNode OldConnectionXMLNode = XMLDocConfig.SelectSingleNode("/root/connection[id=" + ID + "]");

                    foreach (XmlNode Node in XMLDocConfig.ChildNodes)
                    {
                        foreach (XmlNode Node2 in Node.ChildNodes)
                        {
                            if (Node2 == OldConnectionXMLNode)
                                Node.ReplaceChild(ConnectionXMLNode, OldConnectionXMLNode);
                        }
                    }

                    XMLDocConfig.Save(cServerCfg);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _T("error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PortTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void EditServerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void EditServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }
    }
}
