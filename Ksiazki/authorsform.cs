using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace Ksiazki
{
    public partial class AuthorsForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        public DataTable AuthorsDt;
        public DataTable CoAuthorsDt;
        
        public List<string[]> InstitutionsList;

        private string OdpowID;
        private string AutorID;
        private string InstitutionID;
        private string Institution2ID;

        public List<string> AuthorsToDelete;
        public List<string> CoAuthorsToDelete;

        private Form _parent;

        #region AuthorsForm() - GOOD
        public AuthorsForm(Form parent = null)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            if (parent != null)
            {
                this.MdiParent = parent.MdiParent;
                this._parent = parent;
                _parent.Enabled = false;
            }

            AuthorsToDelete = new List<string>();
            CoAuthorsToDelete = new List<string>();

            AuthorsDt = new DataTable();
            AuthorsDt.Columns.Add("id");
            AuthorsDt.Columns.Add("imie");
            AuthorsDt.Columns.Add("nazwisko");

            CoAuthorsDt = new DataTable();
            CoAuthorsDt.Columns.Add("id");
            CoAuthorsDt.Columns.Add("imie");
            CoAuthorsDt.Columns.Add("nazwisko");
            CoAuthorsDt.Columns.Add("id_odpow");
            CoAuthorsDt.Columns.Add("odpow");

            SetToolTips();

            OdpowID = "-1";
            AutorID = "-1";

            loadConfig();
        }
        #endregion

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(OkButton, "confirm");
            mapping.Add(btCancel, "cancel");
            mapping.Add(groupBox1, "authors");
            mapping.Add(groupBox2, "coauthors_001");
            mapping.Add(groupBox3, "institutions");
            mapping.Add(lbNazwaI, "name_of_institution");
            mapping.Add(lbSiedziba, "seat");
            mapping.Add(NameAuthorsDGV, "last_name");
            mapping.Add(FNameAuthorsDGV, "first_name");
            mapping.Add(CoNameDGVC, "last_name");
            mapping.Add(CoFNameDGVC, "first_name");
            mapping.Add(OdpowiedzialnoscDGVC, "responsibility");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
            this.Text = _T("authors_coauthors_institutions");
        }

        #region AuthorsForm(Object Array) : this(parent) - GOOD
        public AuthorsForm(Object Array) : this()
        {                        
            InstitutionsList = new List<string[]>();

            LoadData(Array);
        }
        #endregion

        #region AuthorsForm(DataTable AuthorsDt, DataTable CoAuthorsDt, List<string[]> InstitutionsList, Form parent) : this(parent) - GOOD
        public AuthorsForm(DataTable AuthorsDt, DataTable CoAuthorsDt, List<string[]> InstitutionsList, Form parent = null): this(parent)
        {            
            this.AuthorsDt = AuthorsDt;
            this.CoAuthorsDt = CoAuthorsDt;
            this.InstitutionsList = InstitutionsList;

            LoadData(AuthorsDt, CoAuthorsDt, InstitutionsList);
        }
        #endregion

        private void loadConfig()
        {
            CommonFunctions.LoadConfig(this.Controls, ref Settings.Connection, 1);
        }

        private void SetToolTips()
        {
            ToolTip AuthorsToolTip = new ToolTip();
            AuthorsToolTip.SetToolTip(ChooseAuthorsButton, _T("list_of_authors"));

            ToolTip AddAuthorsToolTip = new ToolTip();
            AddAuthorsToolTip.SetToolTip(AddAuthorButton, _T("add_author_to_list"));

            ToolTip DeleteAuthorsToolTip = new ToolTip();
            DeleteAuthorsToolTip.SetToolTip(DeleteAuthorButton, _T("delete_author_from_list"));

            ToolTip CoAuthorsToolTip = new ToolTip();
            CoAuthorsToolTip.SetToolTip(ChooseCoAuthorsButton, _T("list_of_coauthors"));

            ToolTip AddCoAuthorsToolTip = new ToolTip();
            AddCoAuthorsToolTip.SetToolTip(AddCoAuthorButton, _T("add_coauthor_to_list"));

            ToolTip DeleteCoAuthorsToolTip = new ToolTip();
            DeleteCoAuthorsToolTip.SetToolTip(DeleteCoAuthorButton, _T("del_coauthor_from_list"));

            ToolTip OdpowToolTip = new ToolTip();
            OdpowToolTip.SetToolTip(Odpow1Button, _T("list_of_responsibilities"));

            ToolTip InstytListToolTip = new ToolTip();
            InstytListToolTip.SetToolTip(InstytButton, _T("lit_of_institution"));
            InstytListToolTip.SetToolTip(Insyt2Button, _T("lit_of_institution"));

            ToolTip ClearListToolTip = new ToolTip();
            ClearListToolTip.SetToolTip(CleanInstytButton, _T("to_clean"));
            ClearListToolTip.SetToolTip(CleanInstyt2Button, _T("to_clean"));
        }

        #region LoadData(Object MyArray) - GOOD
        //Ładowanie informacji o (współ)autorach i instytucjach do *List z Object (XML)
        private void LoadData(Object MyArray)
        {
            if(MyArray == null)
                return;
            
            foreach (List<SubfieldClass> Datafield in (IList)MyArray)
            {
                string[] TempDataField = { "", "", "" };

                foreach (SubfieldClass Subfield in Datafield)
                {
                    if (Subfield.Tag == "100" && Subfield.Code == "a")
                    {
                        if (Subfield.Value[Subfield.Value.Length - 1] == '.')
                            Subfield.Value = Subfield.Value.Remove(Subfield.Value.Length - 1);

                        if (Subfield.Ind1 == "0")
                        {                           
                            AuthorsDt.Rows.Add(Subfield.Value.Split(','));
                        }
                        else
                        {
                            string[] temp = Subfield.Value.Split(',');

                            if (temp.Length == 2)
                            {
                                Array.Reverse(temp);

                                SqlCommand Command = new SqlCommand();
                                Command.CommandText = "EXEC Ksiazki_AuthorExists @imie, @nazwisko, @id_rodzaj; ";

                                string tempid = "-1";

                                IsAuthorInDb(Command, temp[0], temp[1], out tempid);

                                AuthorsDt.Rows.Add(tempid, temp[0], temp[1]);
                            }
                        }
                    }
                    else if (Subfield.Tag == "700" && Subfield.Code == "a")
                    {
                        if (Subfield.Value[Subfield.Value.Length - 1] == '.')
                            Subfield.Value = Subfield.Value.Remove(Subfield.Value.Length - 1);

                        string[] temp;

                        if (Subfield.Ind1 == "0")
                        {
                            temp = Subfield.Value.Split(',');

                            TempDataField[0] = temp[0];

                            if (TempDataField.Length > 1)
                                TempDataField[1] = temp[1];
                        }
                        else
                        {
                            temp = Subfield.Value.Split(',');

                            if (temp.Length > 1)
                                TempDataField[0] = temp[1];

                            if (TempDataField.Length > 1)
                                TempDataField[1] = temp[0];
                        }
                    }
                    else if (Subfield.Tag == "700" && Subfield.Code == "e")
                    {
                        TempDataField[2] = Subfield.Value;
                    }
                }

                if (TempDataField[1] != "")
                {
                    // czy autor istnieje i pobranie ID
                    SqlCommand Command = new SqlCommand();
                    Command.CommandText = "EXEC Ksiazki_AuthorExists @imie, @nazwisko, @id_rodzaj; ";

                    string tempid = "-1";                    

                    IsAuthorInDb(Command, TempDataField[0], TempDataField[1], out tempid);

                    // czy rola istnieje i pobranie ID                    
                    Command.CommandText = "EXEC Ksiazki_OdpowiedzialnoscExists @p_Name; ";

                    string tempidRole = "-1";

                    CheckOdpowExists(Command, RoleTextBox.Text, out tempidRole);

                    CoAuthorsDt.Rows.Add(tempid, TempDataField[0], TempDataField[1], tempidRole, TempDataField[2]);
                }
            }

            LoadIntoTextBox();           
        }
        #endregion

        #region LoadData(List<string[]> AuthorsList, List<string[]> SecondAuthorsList, List<string[]> InstitutionsList) - GOOD
        //Ładowanie informacji o (współ)autorach z *List
        private void LoadData(DataTable AuthorsDt, DataTable CoAuthorsDt, List<string[]> InstitutionsList)
        {

            for (int i = 0; i < AuthorsDt.Rows.Count; i++)
            {
                AuthorsDGV.Rows.Add(AuthorsDt.Rows[i]["id"], AuthorsDt.Rows[i]["nazwisko"], AuthorsDt.Rows[i]["imie"]);
            }

            for (int i = 0; i < CoAuthorsDt.Rows.Count; i++)
            {
                CoAuthorsDGV.Rows.Add(CoAuthorsDt.Rows[i]["id"], CoAuthorsDt.Rows[i]["nazwisko"], CoAuthorsDt.Rows[i]["imie"], CoAuthorsDt.Rows[i]["id_odpow"], CoAuthorsDt.Rows[i]["odpow"]);
            }

            LoadIntoTextBox();
        }
        #endregion        

        #region IsAuthorInDb(SqlCommand Command, string FirstName, string Name, out string OdpowID) - REFACTORED
        //Sprawdzenie, czy autor lub instytucja jest w bazie
        private bool IsAuthorInDb(SqlCommand Command, string FirstName, string Name, out string AuthorID)
        {
            try
            {
                if (FirstName == null)
                    FirstName = "-1";

                if (Name == null)
                    Name = "-1";

                if (string.IsNullOrEmpty(FirstName.Trim()) && string.IsNullOrEmpty(Name.Trim()))
                {
                    AuthorID = "-1"; 
                    return true;
                }

                Command.Parameters.AddWithValue("@imie", FirstName.Trim());
                Command.Parameters.AddWithValue("@nazwisko", Name.Trim());
                Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                Command.Parameters.Clear();

                if (Dt.Rows.Count > 0)
                {
                    AuthorID = Dt.Rows[0][0].ToString();

                    return AuthorID != "-1";
                }
            }
            catch (Exception)
            {
                
            }

            AuthorID = "-1";
            return false;
        }
        #endregion

        #region Finish() - REFACTORED
        public void Finish()
        {
            if(AuthorsDt.Rows.Count > 0) 
                AuthorsDt.Clear();

            for (int i = 0; i < AuthorsDGV.Rows.Count; i++)
            {
                AuthorsDt.Rows.Add(AuthorsDGV.Rows[i].Cells["IDAuthorsDGV"].Value, AuthorsDGV.Rows[i].Cells["FNameAuthorsDGV"].Value, AuthorsDGV.Rows[i].Cells["NameAuthorsDGV"].Value);
            }            

            if (CoAuthorsDt.Rows.Count > 0)
                CoAuthorsDt.Clear();

            for (int i = 0; i < CoAuthorsDGV.Rows.Count; i++)
            {
                CoAuthorsDt.Rows.Add(CoAuthorsDGV.Rows[i].Cells["CoIDDGVC"].Value, CoAuthorsDGV.Rows[i].Cells["CoFNameDGVC"].Value, CoAuthorsDGV.Rows[i].Cells["CoNameDGVC"].Value, CoAuthorsDGV.Rows[i].Cells["CoRoleIDDGVC"].Value, CoAuthorsDGV.Rows[i].Cells["OdpowiedzialnoscDGVC"].Value);
            }

            InstitutionsList = new List<string[]>();

            if (Instyt1TextBox.Text.Trim() != "" || PlaceTextBox.Text.Trim() != "")
                /*if (InstLabel.Visible == true)
                    InstitutionsList.Add(new string[] { Instyt1TextBox.Text.Trim(), PlaceTextBox.Text.Trim(), "false" });
                else*/
                    InstitutionsList.Add(new string[] { Instyt1TextBox.Text.Trim(), PlaceTextBox.Text.Trim(), "true" });

            if (Instyt2TextBox.Text.Trim() != "" || Place2TextBox.Text.Trim() != "")
                /*if (Inst2Label.Visible == true)
                    InstitutionsList.Add(new string[] { Instyt2TextBox.Text.Trim(), Place2TextBox.Text.Trim(), "false" });
            else*/
                    InstitutionsList.Add(new string[] { Instyt2TextBox.Text.Trim(), Place2TextBox.Text.Trim(), "true" });
        }
        #endregion

        #region Click Events - REFACTORED

        #region CleanButtons - GOOD

        private void CleanInstytButton_Click(object sender, EventArgs e)
        {
            Instyt1TextBox.Text = "";
            PlaceTextBox.Text = "";
        }

        private void CleanInstyt2Button_Click(object sender, EventArgs e)
        {
            Instyt2TextBox.Text = "";
            Place2TextBox.Text = "";
        }
        #endregion

        #region InstytButton_Click(object sender, EventArgs e) - REFACTORED
        private void InstytButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_InstitutionsList; ";

            ShowForm Formka = new ShowForm(Command, "Nazwa instytucji sprawczej", "Siedziba", false, "Nazwa instytucji sprawczej");
            Formka.Text = _T("choose_institution_001");
            if (Formka.ShowDialog() == DialogResult.OK)
            {
                Instyt1TextBox.Text = Formka.First;
                PlaceTextBox.Text = Formka.Second;
            }
        }
        #endregion

        #region Insyt2Button_Click(object sender, EventArgs e) - REFACTORED
        private void Insyt2Button_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_InstitutionsList; ";

            ShowForm Formka = new ShowForm(Command, "Nazwa instytucji sprawczej", "Siedziba", false, "Nazwa instytucji sprawczej");
            Formka.Text = _T("choose_institution_001");
            if (Formka.ShowDialog() == DialogResult.OK)
            {
                Instyt2TextBox.Text = Formka.First;
                Place2TextBox.Text = Formka.Second;
            }
        }
        #endregion

        #region CancelButton_Click(object sender, EventArgs e) - GOOD
        private void CancelButton_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
        #endregion

        private void OkButton_Click(object sender, EventArgs e)
        {
            Finish();
            
            this.Close();
        }

        private void Odpow1Button_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_OdpowiedzialnoscList; ";

            ShowForm Formka = new ShowForm(Command, "Odpowiedzialność", "");

            if (Formka.ShowDialog() == DialogResult.OK)
            {
                RoleTextBox.Text = Formka.First;                
                OdpowID = Formka.Dt.Cells["id"].Value.ToString();
            }
        }
        #endregion

        #region LoadIntoTextBox() - REFACTORED
        //Ładowanie informacji o (współ)autorach do TextBoxów  
        private void LoadIntoTextBox()
        {
            try
            {
                for (int i = 0; i < InstitutionsList.Count && i < 3; i++)
                {
                    try
                    {
                        if (i == 0)
                        {
                            if (InstitutionsList[i].ElementAt(0) != null)
                                Instyt1TextBox.Text = InstitutionsList[i].ElementAt(0).Trim();
                            if (InstitutionsList[i].ElementAt(1) != null)
                                PlaceTextBox.Text = InstitutionsList[i].ElementAt(1).Trim();
                           
                            InstitutionsList[i] = new string[] { Instyt1TextBox.Text, PlaceTextBox.Text, "false" };                            
                        }
                        else if (i == 1)
                        {
                            if (InstitutionsList[i].ElementAt(0) != null)
                                Instyt2TextBox.Text = InstitutionsList[i].ElementAt(0).Trim();
                            if (InstitutionsList[i].ElementAt(1) != null)
                                Place2TextBox.Text = InstitutionsList[i].ElementAt(1).Trim();
                            
                            InstitutionsList[i] = new string[] { Instyt2TextBox.Text, Place2TextBox.Text, "false" };                            
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception Ex)
            {

            }
        }
        #endregion

        #region AuthorsForm_KeyDown(object sender, KeyEventArgs e) - GOOD
        private void AuthorsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        #endregion

        #region CheckOdpowExists(SqlCommand Command, string Odpow, out string OdpowID) - GOOD
        private bool CheckOdpowExists(SqlCommand Command, string Odpow, out string OdpowID)
        {
            try
            {
                if (Odpow == null)
                    Odpow = "-1";

                if (string.IsNullOrEmpty(Odpow.Trim()))
                {
                    OdpowID = "-1";
                    return true;
                }

                Command.Parameters.AddWithValue("@p_Name", Odpow.Trim());

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                Command.Parameters.Clear();

                if (Dt.Rows.Count > 0)
                {
                    OdpowID = Dt.Rows[0][0].ToString();

                    return OdpowID != "-1";
                }
            }
            catch (Exception)
            {

            }

            OdpowID = "-1";
            return false;
        }
        #endregion

        private void ChooseAuthorsButton_Click(object sender, EventArgs e)
        {
            WaitForm WF = new WaitForm();
            this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_AuthorsList @id_rodzaj;";
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "nazwisko";
            Columns[1].Name = "Nazwisko";

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "imię";
            Columns[2].Name = "Imię";

            ShowListForm SLF = new ShowListForm(AuthorsDGV, Command, Columns);

            WF.Dispose();

            if (SLF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool NotExists = true;

                for (int i = 0; i < AuthorsDGV.Rows.Count; i++)
                {
                    NotExists = true;

                    for (int j = 0; j < SLF.SelectedDataGridView.Rows.Count; j++)
                    {
                        if (AuthorsDGV.Rows[i].Cells["IDAuthorsDGV"].Value.ToString() == SLF.SelectedDataGridView.Rows[j].Cells["IDAuthorsDGV"].Value.ToString())
                            NotExists = false;
                    }

                    if (NotExists)
                        AuthorsToDelete.Add(AuthorsDGV.Rows[i].Cells["IDAuthorsDGV"].Value.ToString());
                }

                if (AuthorsDGV.Rows.Count > 0)
                    AuthorsDGV.Rows.Clear();

                DataGridViewRow Row;

                for (int i = 0; i < SLF.SelectedDataGridView.Rows.Count; i++)
                {
                    Row = (DataGridViewRow)SLF.SelectedDataGridView.Rows[i].Clone();

                    for (int j = 0; j < SLF.SelectedDataGridView.Rows[i].Cells.Count; j++)
                    {
                        Row.Cells[j].Value = SLF.SelectedDataGridView.Rows[i].Cells[j].Value;
                    }

                    AuthorsDGV.Rows.Add(Row);
                }
            }
        }

        private void CheckNameOrFNameIsNotEmpty(object sender, EventArgs e)
        {
            if (AuthorNameTextBox.Text.Trim().Length > 0 || AuthorFNameTextBox.Text.Trim().Length > 0)
                AddAuthorButton.Enabled = true;
            else
                AddAuthorButton.Enabled = false;            
        }

        private void CheckAuthor(string FName, string Name)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_AuthorExists @imie, @nazwisko, @id_rodzaj; ";

            IsAuthorInDb(Command, FName.Trim(), Name.Trim(), out AutorID);
        }

        private void AddAuthorButton_Click(object sender, EventArgs e)
        {            
            AddAuthorToGrid();
        }

        private void AddAuthorToGrid()
        {
            CheckAuthor(AuthorFNameTextBox.Text, AuthorNameTextBox.Text);

            if (AuthorNameTextBox.Text.Trim().Length > 0 || AuthorFNameTextBox.Text.Trim().Length > 0)
            {
                AuthorsDGV.Rows.Add(new string[] { AutorID, AuthorNameTextBox.Text.Trim(), AuthorFNameTextBox.Text.Trim() });

                AuthorNameTextBox.Text = "";
                AuthorFNameTextBox.Text = "";
            }
        }

        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddAuthorToGrid();
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            int idx = AuthorsDGV.SelectedRows[0].Index;
            DataGridViewRow Row = AuthorsDGV.SelectedRows[0];

            AuthorsDGV.Rows.RemoveAt(idx);
            AuthorsDGV.Rows.Insert(idx - 1, Row);

            AuthorsDGV.Rows[idx - 1].Selected = true;
            AuthorsDGV.CurrentCell = AuthorsDGV.SelectedRows[0].Cells["NameAuthorsDGV"];
        }

        private void AuthorsDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (AuthorsDGV.SelectedRows.Count > 0)
            {
                UpButton.Enabled = AuthorsDGV.SelectedRows[0].Index != 0;
                DownButton.Enabled = AuthorsDGV.SelectedRows[0].Index != AuthorsDGV.Rows.Count - 1;                
            }
            
            DeleteAuthorButton.Enabled = AuthorsDGV.SelectedRows.Count > 0 && !Settings.ReadOnlyMode;
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            int idx = AuthorsDGV.SelectedRows[0].Index;
            DataGridViewRow Row = AuthorsDGV.SelectedRows[0];

            AuthorsDGV.Rows.RemoveAt(idx);
            AuthorsDGV.Rows.Insert(idx + 1, Row);

            AuthorsDGV.Rows[idx + 1].Selected = true;
            AuthorsDGV.CurrentCell = AuthorsDGV.SelectedRows[0].Cells["NameAuthorsDGV"];
        }

        private void CoUpButton_Click(object sender, EventArgs e)
        {
            int idx = CoAuthorsDGV.SelectedRows[0].Index;
            DataGridViewRow Row = CoAuthorsDGV.SelectedRows[0];

            CoAuthorsDGV.Rows.RemoveAt(idx);
            CoAuthorsDGV.Rows.Insert(idx - 1, Row);

            CoAuthorsDGV.Rows[idx - 1].Selected = true;
            CoAuthorsDGV.CurrentCell = CoAuthorsDGV.SelectedRows[0].Cells["CoNameDGVC"];
        }

        private void CoDownButton_Click(object sender, EventArgs e)
        {
            int idx = CoAuthorsDGV.SelectedRows[0].Index;
            DataGridViewRow Row = CoAuthorsDGV.SelectedRows[0];

            CoAuthorsDGV.Rows.RemoveAt(idx);
            CoAuthorsDGV.Rows.Insert(idx + 1, Row);

            CoAuthorsDGV.Rows[idx + 1].Selected = true;
            CoAuthorsDGV.CurrentCell = CoAuthorsDGV.SelectedRows[0].Cells["CoFNameDGVC"];
        }

        private void CoAuthorsDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (CoAuthorsDGV.SelectedRows.Count > 0)
            {
                CoUpButton.Enabled = CoAuthorsDGV.SelectedRows[0].Index != 0;
                CoDownButton.Enabled = CoAuthorsDGV.SelectedRows[0].Index != CoAuthorsDGV.Rows.Count - 1;
            }
            
            DeleteCoAuthorButton.Enabled = CoAuthorsDGV.SelectedRows.Count > 0 && !Settings.ReadOnlyMode;
        }

        private void AddCoAuthorButton_Click(object sender, EventArgs e)
        {            
            AddCoAuthorToGrid();
        }

        private void CoNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddCoAuthorToGrid();
        }

        private void AddCoAuthorToGrid()
        {
            CheckAuthor(CoAuthorFNameTextBox.Text, CoAuthorNameTextBox.Text);

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_OdpowiedzialnoscExists @p_Name; ";
            CheckOdpowExists(Command, RoleTextBox.Text, out OdpowID); 

            if (CoAuthorNameTextBox.Text.Trim().Length > 0 || CoAuthorFNameTextBox.Text.Trim().Length > 0)
            {
                CoAuthorsDGV.Rows.Add(new string[] { AutorID, CoAuthorNameTextBox.Text.Trim(), CoAuthorFNameTextBox.Text.Trim(), OdpowID, RoleTextBox.Text.Trim() });

                CoAuthorNameTextBox.Text = "";
                CoAuthorFNameTextBox.Text = "";
                RoleTextBox.Text = "";
                OdpowID = "-1";
                AutorID = "-1";
            }
        }

        private void ChooseCoAuthorsButton_Click(object sender, EventArgs e)
        {
            WaitForm WF = new WaitForm();
            this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_AuthorsList @id_rodzaj;";
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "nazwisko";
            Columns[1].Name = "Nazwisko";

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "imię";
            Columns[2].Name = "Imię";

            ShowListForm SLF = new ShowListForm(CoAuthorsDGV, Command, Columns, true);

            WF.Dispose();

            if (SLF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool NotExists = true;

                for (int i = 0; i < CoAuthorsDGV.Rows.Count; i++)
                {
                    NotExists = true;

                    for (int j = 0; j < SLF.SelectedDataGridView.Rows.Count; j++)
                    {
                        if (CoAuthorsDGV.Rows[i].Cells["CoIDDGVC"].Value.ToString() == SLF.SelectedDataGridView.Rows[j].Cells["CoIDDGVC"].Value.ToString()
                            && CoAuthorsDGV.Rows[i].Cells["CoRoleIDDGVC"].Value != null && SLF.SelectedDataGridView.Rows[j].Cells["CoRoleIDDGVC"].Value != null
                            &&
                            CoAuthorsDGV.Rows[i].Cells["CoRoleIDDGVC"].Value.ToString() == SLF.SelectedDataGridView.Rows[j].Cells["CoRoleIDDGVC"].Value.ToString())
                            NotExists = false;
                    }

                    if (NotExists)
                        CoAuthorsToDelete.Add(CoAuthorsDGV.Rows[i].Cells["CoIDDGVC"].Value.ToString());
                }

                if (CoAuthorsDGV.Rows.Count > 0)
                    CoAuthorsDGV.Rows.Clear();

                DataGridViewRow Row;

                for (int i = 0; i < SLF.SelectedDataGridView.Rows.Count; i++)
                {
                    Row = (DataGridViewRow)SLF.SelectedDataGridView.Rows[i].Clone();

                    for (int j = 0; j < SLF.SelectedDataGridView.Rows[i].Cells.Count; j++)
                    {
                        Row.Cells[j].Value = SLF.SelectedDataGridView.Rows[i].Cells[j].Value;
                    }

                    CoAuthorsDGV.Rows.Add(Row);
                }
            }
        }

        private void RoleTextBox_TextChanged(object sender, EventArgs e)
        {
            CoCheckNameOrFNameIsNotEmpty();
        }

        private void CoCheckNameOrFNameIsNotEmpty()
        {
            AddCoAuthorButton.Enabled = CoAuthorNameTextBox.Text.Trim().Length > 0 || CoAuthorFNameTextBox.Text.Trim().Length > 0 || RoleTextBox.Text.Trim().Length > 0;
            Odpow1Button.Enabled = CoAuthorNameTextBox.Text.Trim().Length > 0 || CoAuthorFNameTextBox.Text.Trim().Length > 0 || RoleTextBox.Text.Trim().Length > 0;
        }

        private void CoNameTextBox_TextChanged(object sender, EventArgs e)
        {
            CoCheckNameOrFNameIsNotEmpty();
        }

        private void CoFNameTextBox_TextChanged(object sender, EventArgs e)
        {
            CoCheckNameOrFNameIsNotEmpty();
        }

        private void CoAuthorsDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (CoAuthorsDGV.SelectedRows.Count > 0)
            {
                CoUpButton.Enabled = CoAuthorsDGV.SelectedRows[0].Index != 0;
                CoDownButton.Enabled = CoAuthorsDGV.SelectedRows[0].Index != CoAuthorsDGV.Rows.Count - 1;
            }
        }

        private void AuthorsDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (AuthorsDGV.SelectedRows.Count > 0)
            {
                UpButton.Enabled = AuthorsDGV.SelectedRows[0].Index != 0;
                DownButton.Enabled = AuthorsDGV.SelectedRows[0].Index != AuthorsDGV.Rows.Count - 1;
            }
        }

        private void DeleteAuthorButton_Click(object sender, EventArgs e)
        {
            if (AuthorsDGV.SelectedRows.Count > 0)
            {
                AuthorsToDelete.Add(AuthorsDGV.SelectedRows[0].Cells[IDAuthorsDGV.Index].Value.ToString());
                AuthorsDGV.Rows.RemoveAt(AuthorsDGV.SelectedRows[0].Index);
            }
        }

        private void DeleteCoAuthorButton_Click(object sender, EventArgs e)
        {
            if (CoAuthorsDGV.SelectedRows.Count > 0)
            {
                CoAuthorsToDelete.Add(CoAuthorsDGV.SelectedRows[0].Cells[CoIDDGVC.Index].Value.ToString());
                CoAuthorsDGV.Rows.RemoveAt(CoAuthorsDGV.SelectedRows[0].Index);
            }
        }

        private void AuthorsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._parent.Enabled = true;
            this._parent.Focus();
        }
    }
}