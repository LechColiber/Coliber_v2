using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using System.Threading;
using Ksiazki.Properties;

namespace Ksiazki
{
    public partial class ChooseServerForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        List<SubfieldClass> DatafieldList;
        List<List<SubfieldClass>> RecordList;
        Object[,] ResultArray;
        List<List<List<SubfieldClass>>> ResultList;
        XmlDocument OutXML;
        private DataTable ResultDt;
        string Address;
        string SearchText;
        string PathToExe;
        string cServerCfg;
        string cAppCfg;

        public ChooseServerForm(int id_rodzaj, string employeeID)//, string ConnectionString)
        {
            PathToExe = Application.StartupPath + "\\";

            //IniFile Configs = new IniFile("coliber.ini", "coliber");
            //Settings.ConnectionString = Configs.ReadIni("SqlServer", "ConnectionString");
            //Settings.ID_rodzaj = id_rodzaj;

            Settings.SetSettings(id_rodzaj);
            Settings.employeeID = employeeID;
            
            //Settings.ID_rodzaj = 1;
            //Settings.ConnectionString = "Driver=SQL SERVER;SERVER=LAPTOP\\SQLEXPRESS;DATABASE=coliber_1do_test;Trusted_Connection=Yes";

            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();
            ISBNLabel.Text = ISBNLabel.Text.Replace(":", "") + ":";
            TitleLabel.Text = TitleLabel.Text.Replace(":", "") + ":";
            AuthorLabel.Text = AuthorLabel.Text.Replace(":", "") + ":";
            PublisherLabel.Text = PublisherLabel.Text.Replace(":", "") + ":";
            YearLabel.Text = YearLabel.Text.Replace(":", "") + ":";
            ImportTabPage.Text = ImportTabPage.Text.ToUpper();
            SearchButton.Text = SearchButton.Text.ToUpper();
            ImportButton.Text = ImportButton.Text.ToUpper();
            //////////////////////////////////
            //this.Text += " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            /////////////////////////////////////
            ResultDt = new DataTable();
            cServerCfg = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Exell\\ServersConfig.XML";
            cAppCfg = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Exell\\Config.XML";
            string cLocalCfg = PathToExe + "Config.XML";
            if (File.Exists(cLocalCfg) && !File.Exists(cAppCfg))
            {
                try
                {
                    File.Copy(cLocalCfg, cAppCfg); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
            }

            ReadMaxRecordsSetting();
            ClearSearch();

            LoadServersIntoDGV(ReadServersFromXML());
            ReadServerSettings();

            DatafieldList = new List<SubfieldClass>();
            RecordList = new List<List<SubfieldClass>>();
            ResultList = new List<List<List<SubfieldClass>>>();

            if (ResultsDGV.Rows.Count==0)
                NumberOfDescriptonsLabel.Text = _T("0_descriptions");
            else
                NumberOfDescriptonsLabel.Text = ResultsDGV.Rows.Count.ToString() + " " + _T("description");


            this.ShowDialog();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(ImportTabPage, "import");
            mapping.Add(MainGroupBox, "marc_import");
            mapping.Add(SetDefaultButton, "set_default");
            mapping.Add(ServerLabel, "server");
            mapping.Add(ChooseSortLabel, "sort");
            mapping.Add(FoldButton, "collapse");
            mapping.Add(SearchButton, "search");
            mapping.Add(ClearButton, "to_clean");
            mapping.Add(YearLabel, "year_of_publishing");
            mapping.Add(PublisherLabel, "publisher_001");
            mapping.Add(ISBNLabel, "isbn");
            mapping.Add(TitleLabel, "title");
            mapping.Add(AuthorLabel, "author");
            mapping.Add(ResultsGroupBox, "search_results");
            mapping.Add(Ordinal, "oridinal_short");
            mapping.Add(AutorCol, "author");
            mapping.Add(Tytuł, "title");
            mapping.Add(ISBN, "isbn");
            mapping.Add(Wydawca, "publisher_001");
            mapping.Add(Rok, "year_of_publishing");
            mapping.Add(Wydanie, "edition");
            mapping.Add(ImportButton, "import_001");
            mapping.Add(EditMARCButton, "edit_marc");
            mapping.Add(PreviewButton, "view_marc");
            mapping.Add(NumberOfDescriptonsLabel, "0_descriptions");
            mapping.Add(NameLabel, "found");
            mapping.Add(ServersTabPage, "servers");
            mapping.Add(label1, "servers_used");
            mapping.Add(OrdinalS, "oridinal_short");
            mapping.Add(ServerName, "server_name");
            mapping.Add(ServerAddress, "server_address");
            mapping.Add(Comments, "comments");
            mapping.Add(DeleteServerButton, "delete");
            mapping.Add(EditServerButton, "edit1");
            mapping.Add(AddServerButton, "add_new");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void ReadMaxRecordsSetting()
        {
            XmlDocument XMLDocConfig = new XmlDocument();
            XMLDocConfig.Load(cAppCfg);

            XmlNode ServerSetting = XMLDocConfig.SelectSingleNode("/coliber/z39.50/maxrecords");
            
            Settings.MaxRecords = Int32.Parse(ServerSetting.InnerText);
        }

        private void ClearSearch()
        {
            SearchText = "";
            SearchLabel.Text = SearchText;
        }

        /// Dodaje serwery do ComboBoxa i ustawia domyślny z pliku config
        private void ReadServerSettings(bool lAfterEdit = false)
        {
            try
            {
                List<ServerClass> Test = ReadServersFromXML();
                string cCurrent = "-brak-" ;
                int iCurrent = -1;
                int iDefault = 0;
                if (lAfterEdit) cCurrent = ServersComboBox.Text.Trim();


                string[] ServersNames = new string[Test.Count];

                for (int i = 0; i < Test.Count; i++)
                {
                    ServersNames[i] = Test[i].Name;
                }

                Array.Sort(ServersNames);
                for (int i = 0; i < Test.Count; i++)
                {
                    if (ServersNames[i] == cCurrent) iCurrent = i;
                }
                ServersComboBox.DataSource = ServersNames;

                    XmlDocument XMLDocConfig = new XmlDocument();
                    XMLDocConfig.Load(cAppCfg);

                    XmlNode ServerSetting = XMLDocConfig.SelectSingleNode("/coliber/z39.50/serverid");  ///pobranie ID domyślnego serwera z pliku config

                    foreach (ServerClass SC in Test)
                    {
                        if (SC.ID == Int32.Parse(ServerSetting.InnerText))
                        {
                            for (int i = 0; i < ServersNames.Length; i++)
                            {
                                if (SC.Name == ServersNames[i])                                         ///znalezienie języka domyślnego po ID
                                {
                                    ServersNames[i] += " (" + _T("default") + ")";
                                    ServersComboBox.DataSource = null;
                                    ServersComboBox.DataSource = ServersNames;
                                    iDefault = i;
                                    break;
                                }
                            }
                        }
                    }
                    if (iCurrent != -1) ServersComboBox.SelectedIndex = iCurrent;
                    else ServersComboBox.SelectedIndex = iDefault;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _T("error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Obsługa przycisku "Zwiń"/"Rozwiń"
        /// </summary>
        private void FoldButton_Click(object sender, EventArgs e)
        {
            if (FoldButton.Text == _T("collapse"))
            {
                SubLayoutPanel.RowStyles[0].SizeType = SizeType.Absolute;
                SubLayoutPanel.RowStyles[0].Height = FoldButton.Height + 20;
                FoldButton.Text = _T("expand");
                FoldButton.Image = Resources.wdol;
            }
            else
            {
                SubLayoutPanel.RowStyles[0].SizeType = SizeType.Absolute;
                SubLayoutPanel.RowStyles[0].Height = 190;
                FoldButton.Text = _T("collapse");
                FoldButton.Image = Resources.wgore;
            }
        }

        /// <summary>
        /// Wyczyszczenie TextBoxów
        /// </summary>
        /// <param name="sender"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            AuthorTextBox.Text = "";
            TitleTextBox.Text = "";
            ISBNTextBox.Text = "";
            PublisherTextBox.Text = "";
            YearTextBox.Text = "";
        }

        /// <summary>
        /// Czytanie serwerów Z39.50 z pliku serverconfig
        /// </summary>
        private List<ServerClass> ReadServersFromXML()
        {
            List<ServerClass> ServersList = new List<ServerClass>();

            try
            {
                XmlDocument XMLDocConfig = new XmlDocument();
                XMLDocConfig.Load(cServerCfg);

                string Host;
                int Port, ID;
                string Database;
                string Name;
                string User;
                string Password;
                string Comments;

                foreach (XmlNode RootNode in XMLDocConfig)
                {
                    foreach (XmlNode ConnectionNode in RootNode)
                    {
                        Host = Database = Name = User = Password = Comments = "";
                        ID = Port = 0;

                        foreach (XmlNode Node in ConnectionNode)
                        {
                            switch (Node.Name.ToLower())
                            {
                                case "id": Int32.TryParse(Node.InnerText, out ID); break;
                                case "host": Host = Node.InnerText; break;
                                case "port": Int32.TryParse(Node.InnerText, out Port); break;
                                case "database": Database = Node.InnerText; break;
                                case "name": Name = Node.InnerText; break;
                                case "user": User = Node.InnerText; break;
                                case "password": Password = Node.InnerText; break;
                                case "comments": Comments = Node.InnerText.Trim(); break;
                            }
                        }

                        ServersList.Add(new ServerClass(ID, Host, Port, Database, Name, User, Password, Comments));
                    }
                }
            }
            catch (Exception Ex)
            {

            }

            return ServersList;
        }

        /// <summary>
        /// Załadowanie listy serwerów do DGV
        /// </summary>
        /// <param name="ServersList"></param>
        private void LoadServersIntoDGV(List<ServerClass> ServersList)
        {
            foreach(ServerClass Server in ServersList)
            {
                ServersDGV.Rows.Add(ServersDGV.Rows.Count+1, Server.Name, Server.Host, Server.ID, Server.Comments);
            }

            ServersDGV.Sort(ServersDGV.Columns[1], ListSortDirection.Ascending);

            for (int i = 0; i < ServersDGV.Rows.Count; i++)
            {
                ServersDGV.Rows[i].Cells["OrdinalS"].Value = (i + 1);
            }
        }

        /// <summary>
        /// Obsługa przycisku dodającego serwer.
        /// </summary>
        private void AddServerButton_Click(object sender, EventArgs e)
        {
            int TempId ;
            int iCol;
            iCol = ServersDGV.Columns["ServerID"].Index;

/*            int MaxID = ServersDGV.Rows.Cast<DataGridViewRow>()
                                   .AsEnumerable()
                                   .Max(x => int.Parse(x.Cells["ServerID"].Value.ToString())); ///Znalezienie największego ID z serwerów

 */
            int MaxID = 0;
            for (int iRow = 0; iRow < ServersDGV.RowCount; iRow++)
            {
                TempId = Int32.Parse(ServersDGV[iCol, iRow].Value.ToString());
                if (TempId > MaxID) MaxID = TempId;
            }

            //Int32.Parse(ServersDGV[ServersDGV.Columns["ServerID"].Index, ServersDGV.CurrentCell.RowIndex].Value.ToString());


            EditServerForm SF = new EditServerForm(MaxID + 1, true, _T("server_adding"));

            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                ServersDGV.Rows.Clear();
                LoadServersIntoDGV(ReadServersFromXML());
                ReadServerSettings(true);

                for (int i = 0; i < ServersDGV.Rows.Count; i++)
                {
                    if (ServersDGV["ServerID", i].Value.ToString() == (MaxID + 1).ToString())
                    {
                        ServersDGV.Rows[i].Cells[0].Selected = true;
                        ServersDGV.Rows[i].Selected = true;
                        break;
                    }
                }
            }
        }

        private void EditServerButton_Click(object sender, EventArgs e)
        {
            int TempId = Int32.Parse(ServersDGV[ServersDGV.Columns["ServerID"].Index, ServersDGV.CurrentCell.RowIndex].Value.ToString());
            EditServerForm SF = new EditServerForm(Int32.Parse(ServersDGV[ServersDGV.Columns["ServerID"].Index, ServersDGV.CurrentCell.RowIndex].Value.ToString()), false, _T("edit_server"));
            SF.ShowDialog();            

            ServersDGV.Rows.Clear();
            LoadServersIntoDGV(ReadServersFromXML());
            ReadServerSettings(true);

            for (int i = 0; i < ServersDGV.Rows.Count; i++)
            {
                if (ServersDGV["ServerID", i].Value.ToString() == (TempId).ToString())
                {
                    ServersDGV.Rows[i].Cells[0].Selected = true;
                    ServersDGV.Rows[i].Selected = true;                    
                    break;
                }
            }
        }

        private void DeleteServerButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(_T("delete_server") +" \"" + ServersDGV["ServerName", ServersDGV.CurrentCell.RowIndex].Value.ToString() + "\" " + _T("from_list") + "?", _T("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    XmlDocument XMLDocConfig = new XmlDocument();
                    XMLDocConfig.Load(cServerCfg);
                    int nId = Int32.Parse(ServersDGV[ServersDGV.Columns["ServerID"].Index, ServersDGV.CurrentCell.RowIndex].Value.ToString());
                    XmlNode OldConnectionXMLNode = XMLDocConfig.SelectSingleNode("/root/connection[id=" +  nId.ToString() + "]");

                    foreach (XmlNode Node in XMLDocConfig.ChildNodes)
                    {
                        foreach (XmlNode Node2 in Node.ChildNodes)
                        {
                            if (Node2 == OldConnectionXMLNode)
                                Node.RemoveChild(OldConnectionXMLNode);
                        }
                    }

                    XMLDocConfig.Save(cServerCfg);

                    ServersDGV.Rows.Clear();
                    LoadServersIntoDGV(ReadServersFromXML());
                    ReadServerSettings(true);

                    if (ServersDGV.RowCount > 0)
                    {
                        ServersDGV.Rows[0].Cells[0].Selected = true;
                        ServersDGV.Rows[0].Selected = true;
                    }
                }
                catch (Exception Ex)
                {

                }
            }
        }

        private void SetDefaultButton_Click(object sender, EventArgs e)
        {
            XmlDocument XMLDocConfig = new XmlDocument();
            XMLDocConfig.Load(cAppCfg);

            List<ServerClass> ServerList = ReadServersFromXML();

            foreach (ServerClass SC in ServerList)
            {
                if (SC.Name == ServersComboBox.SelectedValue.ToString())
                {
                    XMLDocConfig.SelectSingleNode("/coliber/z39.50/serverid").InnerText = SC.ID.ToString();
                    break;
                }
            }      

            XMLDocConfig.Save(cAppCfg);
            ReadServerSettings();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            WaitForm Wait = new WaitForm();
            this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

            string Address = "";
            int Port = 0; ;
            string Database = "";
            string Username = "";
            string Password = "";

            List<ServerClass> ServerList = ReadServersFromXML();

            foreach (ServerClass SC in ServerList)
            {
                if (SC.Name == ServersComboBox.SelectedValue.ToString().Replace("(" +_T("default") +")", "").Trim())
                {
                    Address = SC.Host;
                    Port = SC.Port;
                    Database = SC.Database;
                    Username = SC.User;
                    Password = SC.Password;
                    this.Address = Address;

                    break;
                }
            }

            NumberOfDescriptonsLabel.Text = "";
            NumberOfDescriptonsLabel.Refresh();

            ResultsDGV.DataSource = null;
            ResultsDGV.Rows.Clear();
            ResultsDGV.Refresh();
            
            GetDataFromServer(Address, Port, Database, Username, Password, TitleTextBox.Text, ISBNTextBox.Text, AuthorTextBox.Text, PublisherTextBox.Text, YearTextBox.Text);

            if (ResultList.Count > 0)
            {
                LoadDataIntoDGV();
            }

            NumberOfDescriptonsLabel.Text = ResultsDGV.Rows.Count.ToString();

            if (ResultsDGV.Rows.Count == 0)
                NumberOfDescriptonsLabel.Text = _T("0_descriptions");
            else if (ResultsDGV.Rows.Count == 1)
                NumberOfDescriptonsLabel.Text += " " + _T("description");
            else if (ResultsDGV.Rows.Count % 10 >= 2 && ResultsDGV.Rows.Count % 10 <= 4 && (ResultsDGV.Rows.Count % 100 < 11 || ResultsDGV.Rows.Count % 100 > 14))
                NumberOfDescriptonsLabel.Text += " " + _T("description");
            else
                NumberOfDescriptonsLabel.Text += " " + _T("description");

            if (ISBNRadioButton.Checked)
                ResultsDGV.Sort(ResultsDGV.Columns["ISBN"], ListSortDirection.Ascending);
            else if (TitleRadioButton.Checked)
                ResultsDGV.Sort(ResultsDGV.Columns["Tytuł"], ListSortDirection.Ascending);
            else if (AuthorRadioButton.Checked)
                ResultsDGV.Sort(ResultsDGV.Columns["Autor"], ListSortDirection.Ascending);
            else if (PublisherRadioButton.Checked)
                ResultsDGV.Sort(ResultsDGV.Columns["Wydawca"], ListSortDirection.Ascending);
            else if (YearRadioButton.Checked)
                ResultsDGV.Sort(ResultsDGV.Columns["Rok"], ListSortDirection.Ascending);

            Thread Th = new Thread(() => {
                for (int i = 0; i < ResultsDGV.Rows.Count; i++)
                {
                    ResultsDGV["Ordinal", i].Value = (i + 1).ToString();
                }
            });

            Th.IsBackground = true;
            Th.Start();
            Th.Join();

            NumberOfDescriptonsLabel.Text = ResultsDGV.Rows.Count.ToString();
            Wait.Dispose();

            ResultsDGV.ClearSelection();
        }

        /// <summary>
        /// Pobieranie danych z serwera Z39.50
        /// </summary>
        private void GetDataFromServer(string Address, int Port, string Database, string Username, string Password, string Title, string ISBN, string Author, string Publisher, string Year)
        {
            try
            {
                Z3950Connection Z3950Connection = new Z3950Connection(Address, Port, Database, Username, Password); ///Połączenie się z serwerem Z39.50
                Z3950Connection.Connect();                                                          

                if (!Z3950Connection.IsConnected)
                {
                    MessageBox.Show(_T("connection_failed"), _T("error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Thread Z39 = new Thread(() => { OutXML = Z3950Connection.QueryZ3950XML(Title, ISBN, Author, Publisher, Year); });
                Z39.IsBackground = true;
                Z39.Start();
                Z39.Join();

                //OutXML = Z3950Connection.QueryZ3950XML(Title, ISBN, Author, Publisher, Year);
                
                //OutXML = Z3950Connection.QueryZ3950XML(Title, ISBN, Author, Publisher, Year);

                ReadXML(OutXML);

                /*//MessageBox.Show(outXml.InnerXml);
                StreamWriter pl = new StreamWriter("XXX.xml");

                pl.WriteLine(OutXML.InnerXml);
                pl.Close();*/
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _T("error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReadXML(XmlDocument Description)
        {
            ResultList = new List<List<List<SubfieldClass>>>();

            string Tag, Ind1, Ind2;

            foreach (XmlNode Node in Description.ChildNodes[0].ChildNodes)
            {
                int ID = 0;

                foreach (XmlNode Record in Node.ChildNodes)
                {
                    if (Record.Name.ToLower() != "record")
                        continue;

                    RecordList = new List<List<SubfieldClass>>();

                    foreach (XmlNode Datafield in Record.ChildNodes)
                    {
                        Tag = Ind1 = Ind2 = "";

                        if (Datafield.Name == "controlfield")
                        {
                            foreach (XmlAttribute Att in Datafield.Attributes)
                            {
                                switch (Att.Name.ToLower())
                                {
                                    case "tag": Tag = Att.Value; break;
                                    case "ind1": Ind1 = Att.Value; break;
                                    case "ind2": Ind2 = Att.Value; break;
                                }
                            }

                            DatafieldList.Add(new SubfieldClass(Tag, Ind1, Ind2, "", Datafield.InnerText));
                        }
                        else if (Datafield.Name == "datafield")
                        {
                            foreach (XmlAttribute Att in Datafield.Attributes)
                            {
                                switch (Att.Name.ToLower())
                                {
                                    case "tag": Tag = Att.Value; break;
                                    case "ind1": Ind1 = Att.Value; break;
                                    case "ind2": Ind2 = Att.Value; break;
                                }
                            }

                            foreach (XmlNode Subfield in Datafield.ChildNodes)
                            {
                                foreach (XmlAttribute Codea in Subfield.Attributes)
                                {
                                    try
                                    {
                                        /*if (Codea.Value == Datafield.ChildNodes[Datafield.ChildNodes.Count - 1].Attributes[0].Value)
                                            DatafieldList.Add(new SubfieldClass(Tag, Ind1, Ind2, Codea.Value, Subfield.InnerText.Remove(Subfield.InnerText.Length - 1)));
                                        else*/
                                            DatafieldList.Add(new SubfieldClass(Tag, Ind1, Ind2, Codea.Value, Subfield.InnerText));
                                    }
                                    catch (Exception Ex)
                                    {
                                        MessageBox.Show(Ex.Message, _T("error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }

                            RecordList.Add(DatafieldList);
                            DatafieldList = new List<SubfieldClass>();
                        }
                    }

                    ID++;
                    ResultList.Add(RecordList);
                }

                ResultArray = new Object[ID, 2];

                for (int i = 0; i < ID; i++)
                {
                    ResultArray[i, 0] = i;
                    ResultArray[i, 1] = ResultList[i];
                }
            }
        }

        private void LoadDataIntoDGV()
        {
            string Title, Author, Publisher, Year, ISBN, Edition;

            for (int i = 0; i < ResultArray.GetLength(0); i++)
            {
                Title = Author = Publisher = Year = ISBN = Edition = "";

                foreach (List<SubfieldClass> Datafield in (IList)ResultArray[i, 1])
                {
                    foreach (SubfieldClass Subfield in Datafield)
                    {
                        if (Subfield.Tag == "100" && Subfield.Code == "a")
                        {
                            Author = Subfield.Value.Replace(",", "");
                        }
                        else if (Subfield.Tag == "245")// && Subfield.Code == "a")
                        {
                            Title += Subfield.Value + " ";
                        }
                        else if (Subfield.Tag == "008")//(Subfield.Tag == "260" && Subfield.Code == "c")
                        {
                            //Year = Subfield.Value.Replace("cop.", "").Replace(".", "").Trim();
                            if (Subfield.Value[6].ToString().ToLower() == "s")
                                Year = Subfield.Value.Substring(7, 4);// +", " + Subfield.Value.Substring(11, 4);
                            else if (Subfield.Value[6].ToString().ToLower() == "m")
                                Year = Subfield.Value.Substring(7, 4) + " - " + Subfield.Value.Substring(11, 4);

                            //MessageBox.Show(Subfield.Value);
                        }
                        else if (Subfield.Tag == "260" && (Subfield.Code == "a" || Subfield.Code == "b"))
                        {
                            Publisher += " " + Subfield.Value.Replace(",", "");
                            Publisher = Publisher.Trim();
                        }
                        else if ((Subfield.Tag == "020" || Subfield.Tag == "920") && Subfield.Code == "a")
                        {
                            ISBN = Subfield.Value;
                        }
                        else if (Subfield.Tag == "250" && Subfield.Code == "a")
                        {
                            Edition = Subfield.Value;
                        }
                    }
                }

                ResultsDGV.Rows.Add(ResultArray[i, 0].ToString(), ResultsDGV.Rows.Count + 1, Author, Title, ISBN, Publisher, Year, Edition);
                //ResultDt.Rows.Add(ResultArray[i, 0].ToString(), ResultsDGV.Rows.Count + 1, Author, Title, ISBN, Publisher, Year, Edition);
            }
        }

        private void ISBNTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchButton_Click(sender, e);
        }

        private void EditMARCButton_Click(object sender, EventArgs e)
        {
            if (ResultsDGV.SelectedRows.Count > 0)
            {
                EditMARCForm Edit = new EditMARCForm(ResultArray[Int32.Parse(ResultsDGV["id", ResultsDGV.CurrentCell.RowIndex].Value.ToString()), 1], true, _T("edit_marc_002"));
                Edit.ShowDialog();
            }
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            if (ResultsDGV.SelectedRows.Count > 0)
            {
                EditMARCForm Edit = new EditMARCForm(ResultArray[Int32.Parse(ResultsDGV["id", ResultsDGV.CurrentCell.RowIndex].Value.ToString()), 1], false, _T("view_marc"));
                Edit.ShowDialog();
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            XmlNode RecordToImport = null;

            if (ResultsDGV.SelectedRows.Count > 0)
            {
                foreach (XmlNode Node in OutXML.ChildNodes[0].ChildNodes)
                {
                    int ID = 0;

                    foreach (XmlNode Record in Node.ChildNodes)
                    {
                        if (Record.Name.ToLower() != "record")
                            continue;

                        foreach (XmlNode Datafield in Record.ChildNodes)
                        {
                            if (Datafield.Name == "controlfield")
                            {
                                Object Temp = ResultArray[Int32.Parse(ResultsDGV["id", ResultsDGV.CurrentCell.RowIndex].Value.ToString()), 1];

                                foreach (List<SubfieldClass> TDatafield in (IList)Temp)
                                {
                                    foreach (SubfieldClass TSubfield in TDatafield)
                                    {
                                        if (TSubfield.Tag == "001" && TSubfield.Value == Datafield.InnerText)
                                            RecordToImport = Record;
                                    }
                                }          
                            }
                        }
                    }
                }

                DetailsForm Details = new DetailsForm(ResultArray[Int32.Parse(ResultsDGV["id", ResultsDGV.CurrentCell.RowIndex].Value.ToString()), 1], RecordToImport, Address);
                Details.Dispose();
                ResultsDGV.Focus();
            }
        }

        private void ServersDGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                if (SearchText.Length > 0)
                {
                    SearchText = SearchText.Remove(SearchText.Length - 1);
                    SearchLabel.Text = SearchText;
                }
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {

            }
            else
            {
                SearchText += e.KeyChar.ToString();
                SearchLabel.Text = SearchText;
            }

            for (int i = 0; i < ServersDGV.Rows.Count; i++)
            {
                if (ServersDGV.Rows[i].Cells[1].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    ServersDGV.ClearSelection();
                    ServersDGV.Rows[i].Selected = true;
                    ServersDGV.CurrentCell = ServersDGV[1, i];
                    ServersDGV.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void ServersDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                ClearSearch();
            }
        }

        private void ImportTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ImportTabControl.SelectedIndex == 1)
                ServersDGV.Focus();
        }

        private void ChooseServerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Dispose();
        }

    }
}