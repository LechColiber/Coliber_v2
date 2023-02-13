using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Artykuly
{    
    public partial class ArtykulyForm : Form
    {
        public enum KindEnum { Book, Magazine };
        public enum ModeEnum { Add, Edit, Delete, ReadOnlyCatalog };

        private enum FormActivate
        {
            faMainForm, faAuthorsForm, faKeysForm
        };

        private FormActivate ActiveReason;
        KindEnum CurrentKind;
        ModeEnum CurrentMode;

        UserControl KindUC;

        private string ID;
        private List<string> AuthorsToDelete;
        private List<string> KeysToDelete;
        public bool ShowList;

        private ShowListForm SLF;

        private Dictionary<string, string> _translationsDictionary;
        public ArtykulyForm(KindEnum Kind, ModeEnum Mode)
        {
            InitializeComponent();

            setControlsText();

            this.ActiveReason = FormActivate.faMainForm;

            CurrentKind = Kind;
            CurrentMode = Mode;

            loadConfig();

            AuthorsToDelete = new List<string>();
            KeysToDelete = new List<string>();

            ShowList = false;

            if(CurrentKind == KindEnum.Magazine)
            {
                KindUC = new MagazineUC();
                //KindUC.Location = new Point(12, 438);                
                //this.Controls.Add(KindUC);
                KindUC.Location = new Point(0, 0);
                panel1.Controls.Add(KindUC);

            }
            else if (CurrentKind == KindEnum.Book)
            {
                KindUC = new BookUC();
                //KindUC.Location = new Point(12, 438);
                //this.Controls.Add(KindUC);
                KindUC.Location = new Point(0, 0);
                panel1.Controls.Add(KindUC);
            }

            if (CurrentMode == ModeEnum.Edit || CurrentMode == ModeEnum.Delete)
            {
                SearchButton.Visible = true;
                PrintButton.Visible = true;
            }

            if(CurrentMode == ModeEnum.Delete)
            {
                DeleteButton.Visible = true;
                Settings.ReadOnlyMode = true;
                LockAll();                
            }

            if(CurrentMode == ModeEnum.ReadOnlyCatalog)
            {
                Settings.ReadOnlyMode = true;
                ReadOnlyForCatalog();
            }

            ToolTip SelectToolTip = new ToolTip();
            SelectToolTip.SetToolTip(SourcesButton, _translationsDictionary.getStringFromDictionary("add_attachments", "Dodaj załączniki"));            

            keySuggest("");
        }

        public ArtykulyForm(KindEnum Kind, ModeEnum Mode, string ID) : this(Kind, Mode)
        {
            this.ID = ID;

            if (Kind == KindEnum.Book)
                SetBook();
            else if (Kind == KindEnum.Magazine)
                SetMagazine();

            SetAuthorsAndKeys();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(articleTitleLabel, "article_title");

            mapping.Add(NameAuthorsDGV, "last_name");
            mapping.Add(FNameAuthorsDGV, "first_name");

            mapping.Add(authorsLabel, "authors");
            mapping.Add(classificationLabel, "factual_classification");

            mapping.Add(CommentsTabPage, "comments");
            mapping.Add(StreszczenieTabPage, "summary");
            mapping.Add(FullTabPage, "full_article");

            mapping.Add(PrintButton, "printing");
            mapping.Add(SourcesButton, "sources");
            mapping.Add(SaveButton, "save");
            mapping.Add(SearchButton, "search");
            mapping.Add(DeleteButton, "delete");
            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "articles");            

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void loadConfig()
        {
            CommonFunctions.LoadConfig(this.Controls, ref Settings.Connection, 3);
        }

        private void LockAll()
        {
            if (CurrentKind == KindEnum.Magazine)
                ((MagazineUC)KindUC).LockAll();
            else if (CurrentKind == KindEnum.Book)
                ((BookUC)KindUC).LockAll();

            foreach (Control Ctrl in this.Controls)
                if (Ctrl is TextBox)
                    ((TextBox)Ctrl).ReadOnly = true;                
                else if (Ctrl is RichTextBox)
                    ((RichTextBox)Ctrl).ReadOnly = true;
                else if (Ctrl is CheckBox)
                    ((CheckBox)Ctrl).Enabled = false;
                else if (Ctrl is Button)
                    ((Button)Ctrl).Enabled = false;
                else if (Ctrl is DateTimePicker)
                    ((DateTimePicker)Ctrl).Enabled = false;

            ((RichTextBox)tabControl1.TabPages["CommentsTabPage"].Controls["CommentsRichTextBox"]).ReadOnly = true;
            ((RichTextBox)tabControl1.TabPages["StreszczenieTabPage"].Controls["StreszczenieRichTextBox"]).ReadOnly = true;
            ((RichTextBox)tabControl1.TabPages["FullTabPage"].Controls["FullArtRichTextBox"]).ReadOnly = true;

            SearchButton.Enabled = true;
            EscapeButton.Enabled = true;
            SourcesButton.Enabled = true;
            PrintButton.Enabled = true;
            DeleteButton.Enabled = true;
            SaveButton.Visible = false;
        }

        private void ReadOnlyForCatalog()
        {
            LockAll();
            DeleteButton.Visible = false;
            SearchButton.Visible = false;
            SaveButton.Visible = false;
        }

        private void ChooseAuthorsButton_Click(object sender, EventArgs e)
        {
            WaitForm WF = new WaitForm();
            this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC ZwrocAutorowArykuly @id_rodzaj;";
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "nazwisko";
            Columns[1].Name = "Nazwisko";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("last_name", "Nazwisko");

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "imie";
            Columns[2].Name = "Imię";
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("first_name", "Imię");

            SLF = new ShowListForm(AuthorsDGV, Command, Columns, this);            
            
            SLF.Show();

            WF.Close();

            ActiveReason = FormActivate.faAuthorsForm;            

            /*if (SLF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool NotExists = true;

                for (int i = 0; i < AuthorsDGV.Rows.Count; i++)
                {
                    NotExists = true;

                    for (int j = 0; j < SLF.SelectedDataGridView.Rows.Count; j++)
                    {
                        if (AuthorsDGV.Rows[i].Cells["IDAuthorsDGV"].Value.ToString() == SLF.SelectedDataGridView.Rows[j].Cells["id"].Value.ToString())
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
            }*/
        }

        private void ChooseKeyButton_Click(object sender, EventArgs e)
        {
            WaitForm WF = new WaitForm();
            this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC ZwrocKluczeArtykuly @id_rodzaj;";
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

            DataGridViewColumn[] Columns = new DataGridViewColumn[2];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "klucze";
            Columns[1].Name = "Klucze";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("keys", "Klucze");

            SLF = new ShowListForm(KeysDGV, Command, Columns, this);            

            ActiveReason = FormActivate.faKeysForm;
            SLF.Show();

            WF.Close();

            /*if (SLF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool NotExists = true;

                for (int i = 0; i < KeysDGV.Rows.Count; i++)
                {
                    NotExists = true;

                    for (int j = 0; j < SLF.SelectedDataGridView.Rows.Count; j++)
                    {
                        if (KeysDGV.Rows[i].Cells["IDKeysDGV"].Value.ToString() == SLF.SelectedDataGridView.Rows[j].Cells["id"].Value.ToString())
                            NotExists = false;
                    }

                    if (NotExists)
                        KeysToDelete.Add(KeysDGV.Rows[i].Cells["IDKeysDGV"].Value.ToString());
                }

                if (KeysDGV.Rows.Count > 0)
                    KeysDGV.Rows.Clear();

                DataGridViewRow Row;

                for (int i = 0; i < SLF.SelectedDataGridView.Rows.Count; i++)
                {
                    Row = (DataGridViewRow)SLF.SelectedDataGridView.Rows[i].Clone();

                    for (int j = 0; j < SLF.SelectedDataGridView.Rows[i].Cells.Count; j++)
                    {
                        Row.Cells[j].Value = SLF.SelectedDataGridView.Rows[i].Cells[j].Value;
                    }

                    KeysDGV.Rows.Add(Row);
                }
            }*/
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void AddAuthorButton_Click(object sender, EventArgs e)
        {
            AddAuthorToGrid();
        }

        private void AddAuthorToGrid()
        {
            if (AuthorNameTextBox.Text.Trim().Length > 0 || AuthorFNameTextBox.Text.Trim().Length > 0)
            {
                AuthorsDGV.Rows.Add(new string[] {"-1", AuthorNameTextBox.Text.Trim(), AuthorFNameTextBox.Text.Trim()});

                AuthorNameTextBox.Text = "";
                AuthorFNameTextBox.Text = "";
            }
        }

        private void AddKeyButton_Click(object sender, EventArgs e)
        {
            AddKeyToGrid();
        }

        private void AddKeyToGrid()
        {
            if (KeyTextBox.Text.Trim().Length > 0)
            {
                bool exists = false;

                for (int i = 0; i < KeysDGV.Rows.Count; i++)
                {
                    if (KeysDGV.Rows[i].Cells[KeyNameKeysDGV.Name].Value.ToString().ToUpper() == KeyTextBox.Text.Trim().ToUpper())
                    {
                        exists = true;
                        break;
                    }
                }

                if(!exists)
                    KeysDGV.Rows.Add(new string[] { "-1", KeyTextBox.Text.Trim() });

                KeyTextBox.Text = "";
            }
        }

        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {
            AddKeyButton.Enabled = KeyTextBox.Text.Trim().Length > 0;
        }

        private void keySuggest(string text)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "EXEC SlowaKluczowePodpowiedz @text, @id_rodzaj, 3; ";
            command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj); 
            command.Parameters.AddWithValue("@text", text);

            DataTable dt = CommonFunctions.ReadData(command, ref Settings.Connection);
            var source = new AutoCompleteStringCollection();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                source.Add(dt.Rows[i]["klucz"].ToString());
            }

            KeyTextBox.AutoCompleteCustomSource = source;
        }

        private void CheckNameOrFNameIsNotEmpty(object sender, EventArgs e)
        {
            if (AuthorNameTextBox.Text.Trim().Length > 0 || AuthorFNameTextBox.Text.Trim().Length > 0)
                AddAuthorButton.Enabled = true;
            else
                AddAuthorButton.Enabled = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {           
            Save(false);
        }
        private bool Save(bool NoMessage)
        {
           /* if (string.IsNullOrEmpty(((MagazineUC)KindUC).IDValue))
            {
                MessageBox.Show("Proszę wybrać czasopismo/książkę.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }*/

            if (string.IsNullOrEmpty(TitleRichTextBox.Text.Trim()))
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("enter_article_title", "Proszę podać tytuł artykułu"), _translationsDictionary.getStringFromDictionary("enter_the_data", "Uzupełnienie danych"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            SqlCommand Command = new SqlCommand();
            
            SqlParameter KodParam = new SqlParameter();
            KodParam.SqlDbType = SqlDbType.Int;
            KodParam.ParameterName = "@kod";
            KodParam.Direction = ParameterDirection.Output;

            if (CurrentMode == ModeEnum.Add || CurrentMode == ModeEnum.Edit)
            {                
                Command.CommandText = "EXEC ModifyArtykul @p_syg, @p_tytul, @p_rok1, @p_rok2, @p_volumin, @p_numer1, @p_numer2, @p_tytul_a, @p_jezyk, @p_strony, @p_nr_odcinka, @p_tabele, @p_mapy, @p_wykresy, " +
                                      "@p_s_pol, @p_s_ang, @p_s_niem, @p_s_fran, @p_s_ros, @p_uwagi, @p_opis, @p_caly, @p_data_uk, @p_id_rodzaj, @p_kod_zas, @p_rodzaj_zas, @p_autor_red, @p_data_wyd, @p_miejsce_wyd, @p_kod, @p_wydawnictwo, @p_mode, @id_czasop_n, @kod OUTPUT;";

                Command.Parameters.AddWithValue("@p_tytul_a", TitleRichTextBox.Text.Trim());
                
                Command.Parameters.AddWithValue("@p_uwagi", tabControl1.TabPages["CommentsTabPage"].Controls["CommentsRichTextBox"].Text);
                Command.Parameters.AddWithValue("@p_opis", tabControl1.TabPages["StreszczenieTabPage"].Controls["StreszczenieRichTextBox"].Text);
                Command.Parameters.AddWithValue("@p_caly", tabControl1.TabPages["FullTabPage"].Controls["FullArtRichTextBox"].Text);
               
                Command.Parameters.AddWithValue("@p_id_rodzaj", Settings.ID_rodzaj);                

                if (CurrentKind == KindEnum.Magazine)
                {
                    Command.Parameters.AddWithValue("@p_jezyk", ((MagazineUC)KindUC).LanguageTextBoxValue);
                    Command.Parameters.AddWithValue("@p_strony", ((MagazineUC)KindUC).PagesTextBoxValue);
                    Command.Parameters.AddWithValue("@p_s_pol", ((MagazineUC)KindUC).PolCheckBoxValue);
                    Command.Parameters.AddWithValue("@p_s_ang", ((MagazineUC)KindUC).EngCheckBoxValue);
                    Command.Parameters.AddWithValue("@p_s_niem", ((MagazineUC)KindUC).GerCheckBoxValue);
                    Command.Parameters.AddWithValue("@p_s_fran", ((MagazineUC)KindUC).FraCheckBoxValue);
                    Command.Parameters.AddWithValue("@p_s_ros", ((MagazineUC)KindUC).RusCheckBoxValue);

                    Command.Parameters.AddWithValue("@p_syg", ((MagazineUC)KindUC).SygnaturaTextBoxValue.Trim());
                    Command.Parameters.AddWithValue("@p_tytul", ((MagazineUC)KindUC).SourceTitleRichTextBoxValue);
                    Command.Parameters.AddWithValue("@p_rok1", ((MagazineUC)KindUC).YearTextBoxValue.Length > 0 ? ((MagazineUC)KindUC).YearTextBoxValue : "0");
                    Command.Parameters.AddWithValue("@p_rok2", ((MagazineUC)KindUC).Year2TextBoxValue.Length > 0 ? ((MagazineUC)KindUC).Year2TextBoxValue : "0");//C
                    Command.Parameters.AddWithValue("@p_volumin", ((MagazineUC)KindUC).WoluminTextBoxValue.Trim());//C
                    Command.Parameters.AddWithValue("@p_numer1", ((MagazineUC)KindUC).NumberTextBoxValue.Length > 0 ? ((MagazineUC)KindUC).NumberTextBoxValue : "0");//C
                    Command.Parameters.AddWithValue("@p_numer2", ((MagazineUC)KindUC).Number2TextBoxValue.Length > 0 ? ((MagazineUC)KindUC).Number2TextBoxValue : "0");//C                    
                    Command.Parameters.AddWithValue("@p_nr_odcinka", ((MagazineUC)KindUC).NrodcTextBoxValue.Length > 0 ? ((MagazineUC)KindUC).NrodcTextBoxValue : "0");//C
                    Command.Parameters.AddWithValue("@p_tabele", ((MagazineUC)KindUC).TablesCheckBoxValue);//C
                    Command.Parameters.AddWithValue("@p_mapy", ((MagazineUC)KindUC).MapsCheckBoxValue);//C
                    Command.Parameters.AddWithValue("@p_wykresy", ((MagazineUC)KindUC).ChartCheckBoxValue);//C

                    Command.Parameters.AddWithValue("@p_data_uk", ((MagazineUC)KindUC).DateDTPValue.ToString("yyyyMMdd"));                    

                    Command.Parameters.AddWithValue("@p_autor_red", DBNull.Value);//K
                    Command.Parameters.AddWithValue("@p_data_wyd", DBNull.Value);//K
                    Command.Parameters.AddWithValue("@p_miejsce_wyd", DBNull.Value);//K

                    Command.Parameters.AddWithValue("@p_rodzaj_zas", 'C');

                    if (!string.IsNullOrEmpty(((MagazineUC) KindUC).IDValue))                    
                        Command.Parameters.AddWithValue("@p_kod_zas", ((MagazineUC) KindUC).IDValue);
                    else                    
                        Command.Parameters.AddWithValue("@p_kod_zas", DBNull.Value);
                    
                    Command.Parameters.AddWithValue("@p_wydawnictwo", DBNull.Value);

                    if (!string.IsNullOrEmpty(((MagazineUC)KindUC).id_czasop_nValue))
                        Command.Parameters.AddWithValue("@id_czasop_n", ((MagazineUC)KindUC).id_czasop_nValue);
                    else
                        Command.Parameters.AddWithValue("@id_czasop_n", DBNull.Value);
                }
                else if (CurrentKind == KindEnum.Book)
                {
                    Command.Parameters.AddWithValue("@p_jezyk", ((BookUC)KindUC).LanguageTextBoxValue);
                    Command.Parameters.AddWithValue("@p_strony", ((BookUC)KindUC).PagesTextBoxValue);
                    Command.Parameters.AddWithValue("@p_s_pol", ((BookUC)KindUC).PolCheckBoxValue);
                    Command.Parameters.AddWithValue("@p_s_ang", ((BookUC)KindUC).EngCheckBoxValue);
                    Command.Parameters.AddWithValue("@p_s_niem", ((BookUC)KindUC).GerCheckBoxValue);
                    Command.Parameters.AddWithValue("@p_s_fran", ((BookUC)KindUC).FraCheckBoxValue);
                    Command.Parameters.AddWithValue("@p_s_ros", ((BookUC)KindUC).RusCheckBoxValue);

                    Command.Parameters.AddWithValue("@p_syg", ((BookUC)KindUC).SygnaturaTextBoxValue.Trim());
                    Command.Parameters.AddWithValue("@p_tytul", ((BookUC)KindUC).SourceTitleRichTextBoxValue);
                    Command.Parameters.AddWithValue("@p_rok1", ((BookUC)KindUC).YearTextBoxValue.Length > 0 ? ((BookUC)KindUC).YearTextBoxValue : "0");
                    Command.Parameters.AddWithValue("@p_rok2", 0);//C
                    Command.Parameters.AddWithValue("@p_volumin", "");//C
                    Command.Parameters.AddWithValue("@p_numer1", 0);//C
                    Command.Parameters.AddWithValue("@p_numer2", 0);//C
                    Command.Parameters.AddWithValue("@p_nr_odcinka", 0);//C
                    Command.Parameters.AddWithValue("@p_tabele", false);//C
                    Command.Parameters.AddWithValue("@p_mapy", false);//C
                    Command.Parameters.AddWithValue("@p_wykresy", false);//C
                    
                    Command.Parameters.AddWithValue("@p_data_uk", ((BookUC)KindUC).DateDTPValue.ToString("yyyyMMdd"));

                    if (!string.IsNullOrEmpty(((BookUC)KindUC).AuthorTextBoxValue))
                        Command.Parameters.AddWithValue("@p_autor_red", ((BookUC)KindUC).AuthorTextBoxValue);//K
                    else
                        Command.Parameters.AddWithValue("@p_autor_red", DBNull.Value);//K

                    if (!string.IsNullOrEmpty(((BookUC)KindUC).YearTextBoxValue))
                        Command.Parameters.AddWithValue("@p_data_wyd", ((BookUC)KindUC).YearTextBoxValue);//K
                    else
                        Command.Parameters.AddWithValue("@p_data_wyd", DBNull.Value);//K

                    //if (!string.IsNullOrEmpty(((BookUC)KindUC).PlaceTextBoxValue))
                    if (!string.IsNullOrEmpty(((BookUC)KindUC).IDValue))
                        Command.Parameters.AddWithValue("@p_miejsce_wyd", ((BookUC)KindUC).PlaceTextBoxValue);//K
                    else
                        Command.Parameters.AddWithValue("@p_miejsce_wyd", DBNull.Value);//K

                    Command.Parameters.AddWithValue("@p_rodzaj_zas", 'K');

                    if (!string.IsNullOrEmpty(((BookUC)KindUC).IDValue))
                        Command.Parameters.AddWithValue("@p_kod_zas", ((BookUC)KindUC).IDValue);
                    else
                        Command.Parameters.AddWithValue("@p_kod_zas", DBNull.Value);

                    if (string.IsNullOrEmpty(((BookUC)KindUC).IDValue))
                        Command.Parameters.AddWithValue("@p_wydawnictwo", ((BookUC)KindUC).PublisherTextBoxValue);
                    else
                        Command.Parameters.AddWithValue("@p_wydawnictwo", DBNull.Value);

                    Command.Parameters.AddWithValue("@id_czasop_n", DBNull.Value);
                }

                if (CurrentMode == ModeEnum.Add)
                {
                    Command.Parameters.AddWithValue("@p_kod", DBNull.Value);
                    Command.Parameters.AddWithValue("@p_mode", 1);
                }
                else if (CurrentMode == ModeEnum.Edit)
                {
                    Command.Parameters.AddWithValue("@p_kod", ID);
                    Command.Parameters.AddWithValue("@p_mode", 2);
                }

                Command.Parameters.Add(KodParam);
            }

            if (CommonFunctions.WriteData(ref Command, ref Settings.Connection))
            {
                if(CurrentMode == ModeEnum.Add)
                    ID = KodParam.Value.ToString();

                CurrentMode = ModeEnum.Edit;

                if (AddAuthors(ID) && AddKeys(ID))
                {
                    if (!NoMessage)
                    {
                        MessageBox.Show(_translationsDictionary.getStringFromDictionary("saved", "Dane zostały zapisane."), _translationsDictionary.getStringFromDictionary("data_save", "Zapis danych"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PrintButton.Visible = true;
                    }
                }
                
                return true;
            }

            return false;
        }

        private bool AddAuthors(string ID)
        {
            SqlCommand Command = new SqlCommand();

            if (AuthorsToDelete.Count > 0)
            {
                for (int i = 0; i < AuthorsToDelete.Count; i++)
                {
                    Command.CommandText += "EXEC ModifyAuthorArtykuly @id_aut_d" + i + ", @kod_art_d, @mode_d;";
                    Command.Parameters.AddWithValue("@id_aut_d" + i, AuthorsToDelete[i]);
                }

                Command.Parameters.AddWithValue("@mode_d", 2);
                Command.Parameters.AddWithValue("@kod_art_d", ID);
            }

            if (AuthorsDGV.Rows.Count > 0)
            {
                for (int i = 0; i < AuthorsDGV.Rows.Count; i++)
                {
                    if (AuthorsDGV.Rows[i].Cells["IDAuthorsDGV"].Value.ToString() == "-1")
                    {
                        Command.CommandText += "EXEC ModifyAuthorArtykuly @id_aut" + i + ", @kod_art, @mode, @imie" + i + ", @nazwisko" + i + ", @id_rodzaj;";
                        Command.Parameters.AddWithValue("@id_aut" + i, AuthorsDGV.Rows[i].Cells["IDAuthorsDGV"].Value.ToString());
                        Command.Parameters.AddWithValue("@imie" + i, AuthorsDGV.Rows[i].Cells["FNameAuthorsDGV"].Value.ToString());
                        Command.Parameters.AddWithValue("@nazwisko" + i, AuthorsDGV.Rows[i].Cells["NameAuthorsDGV"].Value.ToString());
                    }
                    else if (AuthorsDGV.Rows[i].Cells["IDAuthorsDGV"].Value.ToString() != "-1")
                    {
                        Command.CommandText += "EXEC ModifyAuthorArtykuly @id_aut" + i + ", @kod_art, @mode;";
                        Command.Parameters.AddWithValue("@id_aut" + i, AuthorsDGV.Rows[i].Cells["IDAuthorsDGV"].Value.ToString());
                    }
                }

                Command.Parameters.AddWithValue("@mode", 1);
                Command.Parameters.AddWithValue("@kod_art", ID);
                Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);                
            }

            if (AuthorsToDelete.Count > 0 || AuthorsDGV.Rows.Count > 0)
                return CommonFunctions.WriteData(Command, ref Settings.Connection);

            return true;
        }
        private bool AddKeys(string ID)
        {
            SqlCommand Command = new SqlCommand();

            if (KeysToDelete.Count > 0)
            {
                for (int i = 0; i < KeysToDelete.Count; i++)
                {
                    Command.CommandText += "EXEC ModifyKeyArtykuly @p_id_klucza_d" + i + ", @kod_art_d, @mode_d;";
                    Command.Parameters.AddWithValue("@p_id_klucza_d" + i, KeysToDelete[i]);
                }

                Command.Parameters.AddWithValue("@mode_d", 2);
                Command.Parameters.AddWithValue("@kod_art_d", ID);
            }

            if (KeysDGV.Rows.Count > 0)
            {
                for (int i = 0; i < KeysDGV.Rows.Count; i++)
                {
                    if (KeysDGV.Rows[i].Cells["IDKeysDGV"].Value.ToString() == "-1")
                    {
                        Command.CommandText += "EXEC ModifyKeyArtykuly @p_id_klucza" + i + ", @kod_art, @mode, @klucz" + i + ", @id_rodzaj;";
                        Command.Parameters.AddWithValue("@p_id_klucza" + i, KeysDGV.Rows[i].Cells["IDKeysDGV"].Value.ToString());
                        Command.Parameters.AddWithValue("@klucz" + i, KeysDGV.Rows[i].Cells["KeyNameKeysDGV"].Value.ToString());
                    }
                    else if (KeysDGV.Rows[i].Cells["IDKeysDGV"].Value.ToString() != "-1")
                    {
                        Command.CommandText += "EXEC ModifyKeyArtykuly @p_id_klucza" + i + ", @kod_art, @mode, @klucz" + i + ";";
                        Command.Parameters.AddWithValue("@p_id_klucza" + i, KeysDGV.Rows[i].Cells["IDKeysDGV"].Value.ToString());
                        Command.Parameters.AddWithValue("@klucz" + i, KeysDGV.Rows[i].Cells["KeyNameKeysDGV"].Value.ToString());
                    }
                }

                Command.Parameters.AddWithValue("@mode", 1);
                Command.Parameters.AddWithValue("@kod_art", ID);
                Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
            }

            if (KeysToDelete.Count > 0 || KeysDGV.Rows.Count > 0)
                return CommonFunctions.WriteData(Command, ref Settings.Connection);

            return true;
        }  
        public void SetBook()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC ZwrocInformacjeOArtykule @kod;";
            Command.Parameters.AddWithValue("@kod", ID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {
                TitleRichTextBox.Text = Dt.Rows[0]["tytul_artykulu"].ToString();

                tabControl1.TabPages["CommentsTabPage"].Controls["CommentsRichTextBox"].Text = Dt.Rows[0]["uwagi"].ToString();
                tabControl1.TabPages["StreszczenieTabPage"].Controls["StreszczenieRichTextBox"].Text = Dt.Rows[0]["opis"].ToString();
                tabControl1.TabPages["FullTabPage"].Controls["FullArtRichTextBox"].Text = Dt.Rows[0]["caly"].ToString();

                ((BookUC)KindUC).IDValue = Dt.Rows[0]["kod_zas"].ToString();
                ((BookUC)KindUC).SourceTitleRichTextBoxValue = Dt.Rows[0]["tytul_ksiazki"].ToString();
                ((BookUC)KindUC).SygnaturaTextBoxValue = Dt.Rows[0]["sygnatura"].ToString();
                ((BookUC)KindUC).YearTextBoxValue = Dt.Rows[0]["data_wyd"].ToString();
                ((BookUC)KindUC).PlaceTextBoxValue = Dt.Rows[0]["miejsce_wyd"].ToString();
                ((BookUC)KindUC).PublisherTextBoxValue = Dt.Rows[0]["wydawca"].ToString();
                ((BookUC)KindUC).AuthorTextBoxValue = Dt.Rows[0]["autor_red"].ToString();
                ((BookUC)KindUC).PagesTextBoxValue = Dt.Rows[0]["strony"].ToString();               
                ((BookUC)KindUC).LanguageTextBoxValue = Dt.Rows[0]["jezyk"].ToString();
                ((BookUC)KindUC).PolCheckBoxValue = (bool)Dt.Rows[0]["s_pol"];//.ToString() == "false" ? false : true;
                ((BookUC)KindUC).EngCheckBoxValue = (bool)Dt.Rows[0]["s_ang"];//.ToString() == "false" ? false : true;
                ((BookUC)KindUC).GerCheckBoxValue = (bool)Dt.Rows[0]["s_niem"];//.ToString() == "false" ? false : true;
                ((BookUC)KindUC).RusCheckBoxValue = (bool)Dt.Rows[0]["s_ros"];//.ToString() == "false" ? false : true;
                ((BookUC)KindUC).FraCheckBoxValue = (bool)Dt.Rows[0]["s_fran"];//.ToString() == "false" ? false : true;            
                ((BookUC)KindUC).DateDTPValue = DateTime.Parse(Dt.Rows[0]["data_uk"].ToString());

                if (!string.IsNullOrEmpty(Dt.Rows[0]["autorzy"].ToString()))
                    ((BookUC)KindUC).BookAuhorsRichTextBoxValue += Dt.Rows[0]["autorzy"].ToString();

                if(!Settings.ReadOnlyMode)
                    ((BookUC)KindUC).BookAuhorsRichTextBoxReadOnly = !string.IsNullOrEmpty(((BookUC)KindUC).IDValue);

                ((BookUC)KindUC).Lock(!string.IsNullOrEmpty(((BookUC)KindUC).IDValue));
            }     
        }

        public void SetMagazine()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC ZwrocInformacjeOArtykule @kod;";
            Command.Parameters.AddWithValue("@kod", ID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {
                TitleRichTextBox.Text = Dt.Rows[0]["tytul_artykulu"].ToString();

                tabControl1.TabPages["CommentsTabPage"].Controls["CommentsRichTextBox"].Text = Dt.Rows[0]["uwagi"].ToString();
                tabControl1.TabPages["StreszczenieTabPage"].Controls["StreszczenieRichTextBox"].Text = Dt.Rows[0]["opis"].ToString();
                tabControl1.TabPages["FullTabPage"].Controls["FullArtRichTextBox"].Text = Dt.Rows[0]["caly"].ToString();

                ((MagazineUC)KindUC).IDValue = Dt.Rows[0]["kod_zas"].ToString();
                ((MagazineUC)KindUC).SourceTitleRichTextBoxValue = Dt.Rows[0]["tytul_czasopisma"].ToString();
                ((MagazineUC)KindUC).SygnaturaTextBoxValue = Dt.Rows[0]["sygnatura"].ToString();
                ((MagazineUC)KindUC).YearTextBoxValue = Dt.Rows[0]["rok1"].ToString();
                ((MagazineUC)KindUC).Year2TextBoxValue = Dt.Rows[0]["rok2"].ToString();
                ((MagazineUC)KindUC).WoluminTextBoxValue = Dt.Rows[0]["volumin"].ToString();
                ((MagazineUC)KindUC).MapsCheckBoxValue = (bool)Dt.Rows[0]["mapy"];
                ((MagazineUC)KindUC).TablesCheckBoxValue = (bool)Dt.Rows[0]["tabele"];
                ((MagazineUC)KindUC).NumberTextBoxValue = Dt.Rows[0]["numer1"].ToString();
                ((MagazineUC)KindUC).Number2TextBoxValue = Dt.Rows[0]["numer2"].ToString();
                ((MagazineUC)KindUC).PagesTextBoxValue = Dt.Rows[0]["strony"].ToString();
                ((MagazineUC)KindUC).ChartCheckBoxValue = (bool)Dt.Rows[0]["wykresy"];
                ((MagazineUC)KindUC).NrodcTextBoxValue = Dt.Rows[0]["nr_odcinka"].ToString();
                ((MagazineUC)KindUC).LanguageTextBoxValue = Dt.Rows[0]["jezyk"].ToString();
                ((MagazineUC)KindUC).PolCheckBoxValue = (bool)Dt.Rows[0]["s_pol"];
                ((MagazineUC)KindUC).EngCheckBoxValue = (bool)Dt.Rows[0]["s_ang"];
                ((MagazineUC)KindUC).GerCheckBoxValue = (bool)Dt.Rows[0]["s_niem"];
                ((MagazineUC)KindUC).RusCheckBoxValue = (bool)Dt.Rows[0]["s_ros"];
                ((MagazineUC)KindUC).FraCheckBoxValue = (bool)Dt.Rows[0]["s_fran"];
                ((MagazineUC)KindUC).DateDTPValue = DateTime.Parse(Dt.Rows[0]["data_uk"].ToString());
                ((MagazineUC)KindUC).id_czasop_nValue = Dt.Rows[0]["id_czasop_n"].ToString();

                ((MagazineUC)KindUC).Lock(!string.IsNullOrEmpty(((MagazineUC)KindUC).IDValue), !string.IsNullOrEmpty(((MagazineUC)KindUC).id_czasop_nValue));
            }
        }

        public void SetAuthorsAndKeys()
        {
            SqlCommand Command = new SqlCommand();            
            Command.CommandText = "EXEC ZwrocAutorowArtykulu @kod;";
            Command.Parameters.AddWithValue("@kod", ID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                AuthorsDGV.Rows.Add(new string[] { Dt.Rows[i]["id_aut"].ToString(), Dt.Rows[i]["nazwisko"].ToString(), Dt.Rows[i]["imie"].ToString() });
            }

            Command.CommandText = "EXEC ZwrocKluczeArtykulow @kod;";

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                KeysDGV.Rows.Add(new string[] { Dt.Rows[i]["kody"].ToString(), Dt.Rows[i]["klucze"].ToString() });
            }
        }

        private void ArtykulyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Connection.State == ConnectionState.Open)
                Settings.Connection.Close();

            if (!Settings.ReadOnlyMode && MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_exit_without_save", "Czy opuścić okno bez zapisywania zmian?"), _translationsDictionary.getStringFromDictionary("exit", "Wyjście"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Form mdiParent = this.MdiParent;
            this.Close();

            ChooseType.ShowAllArticles(CurrentMode, mdiParent);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string article_deleting = _translationsDictionary.getStringFromDictionary("article_deleting", "Usuwanie artykułu");

            if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_article", "Czy chcesz usunąć artykuł?"), article_deleting, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC DeleteArtykul @kod;";
                Command.Parameters.AddWithValue("@kod", ID);

                if (CommonFunctions.WriteData(Command, ref Settings.Connection))
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("removed", "Artykuł został usunięty."), article_deleting, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
        }

        private void SourcesButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ID))
            {
                if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("if_you_want_to_add_sources_save_article", "Aby dodać źródła, należy zapisać artykuł. Chcesz zapisać?"), _translationsDictionary.getStringFromDictionary("data_save", "Zapisywanie"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!Save(true))
                        return;
                }
                else
                    return;
            }

            if (Settings.ReadOnlyMode)
            {
                Zrodla.SourceForm SF = new Zrodla.SourceForm(Int32.Parse(ID), 3, Settings.ID_rodzaj, true);
                SF.ShowDialog();
            }
            else
            {
                Zrodla.SourceForm SF = new Zrodla.SourceForm(Int32.Parse(ID), 3, Settings.ID_rodzaj);
                SF.ShowDialog();
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            ChooseReportForm CRF = new ChooseReportForm(CurrentKind, ID, this);
            CRF.Show();
        }

        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddAuthorToGrid();
        }

        private void FNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddAuthorToGrid();
        }

        private void KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddKeyToGrid();
        }

        private void ArtykulyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ArtykulyForm_Activated(object sender, EventArgs e)
        {
            if (ActiveReason == FormActivate.faAuthorsForm)
            {
                if (SLF.DialogResult == DialogResult.OK)
                {
                    bool NotExists = true;

                    for (int i = 0; i < AuthorsDGV.Rows.Count; i++)
                    {
                        NotExists = true;

                        for (int j = 0; j < SLF.SelectedDataGridView.Rows.Count; j++)
                        {
                            if (AuthorsDGV.Rows[i].Cells["IDAuthorsDGV"].Value.ToString() == SLF.SelectedDataGridView.Rows[j].Cells["id"].Value.ToString())
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
                        Row = (DataGridViewRow) SLF.SelectedDataGridView.Rows[i].Clone();

                        for (int j = 0; j < SLF.SelectedDataGridView.Rows[i].Cells.Count; j++)
                        {
                            Row.Cells[j].Value = SLF.SelectedDataGridView.Rows[i].Cells[j].Value;
                        }

                        AuthorsDGV.Rows.Add(Row);
                    }
                }
            }
            else if (ActiveReason == FormActivate.faKeysForm)
            {
                if (SLF.DialogResult == DialogResult.OK)
                {
                    bool NotExists = true;

                    for (int i = 0; i < KeysDGV.Rows.Count; i++)
                    {
                        NotExists = true;

                        for (int j = 0; j < SLF.SelectedDataGridView.Rows.Count; j++)
                        {
                            if (KeysDGV.Rows[i].Cells["IDKeysDGV"].Value.ToString() == SLF.SelectedDataGridView.Rows[j].Cells["id"].Value.ToString())
                                NotExists = false;
                        }

                        if (NotExists)
                            KeysToDelete.Add(KeysDGV.Rows[i].Cells["IDKeysDGV"].Value.ToString());
                    }

                    if (KeysDGV.Rows.Count > 0)
                        KeysDGV.Rows.Clear();

                    DataGridViewRow Row;

                    for (int i = 0; i < SLF.SelectedDataGridView.Rows.Count; i++)
                    {
                        Row = (DataGridViewRow)SLF.SelectedDataGridView.Rows[i].Clone();

                        for (int j = 0; j < SLF.SelectedDataGridView.Rows[i].Cells.Count; j++)
                        {
                            Row.Cells[j].Value = SLF.SelectedDataGridView.Rows[i].Cells[j].Value;
                        }

                        KeysDGV.Rows.Add(Row);
                    }
                }
            }
            
            ActiveReason = FormActivate.faMainForm;            
        }

        private void DeleteAuthorButton_Click(object sender, EventArgs e)
        {
            if (AuthorsDGV.SelectedRows.Count > 0)
            {
                AuthorsToDelete.Add(AuthorsDGV.SelectedRows[0].Cells[IDAuthorsDGV.Index].Value.ToString());
                AuthorsDGV.Rows.RemoveAt(AuthorsDGV.SelectedRows[0].Index);
            }
        }

        private void DeleteKeyButton_Click(object sender, EventArgs e)
        {
            if (KeysDGV.SelectedRows.Count > 0)
            {
                KeysToDelete.Add(KeysDGV.SelectedRows[0].Cells[IDKeysDGV.Index].Value.ToString());
                KeysDGV.Rows.RemoveAt(KeysDGV.SelectedRows[0].Index);
            }
        }

        private void AuthorsDGV_SelectionChanged(object sender, EventArgs e)
        {
            DeleteAuthorButton.Enabled = AuthorsDGV.SelectedRows.Count > 0 && !Settings.ReadOnlyMode;
        }

        private void KeysDGV_SelectionChanged(object sender, EventArgs e)
        {
            DeleteKeyButton.Enabled = KeysDGV.SelectedRows.Count > 0 && !Settings.ReadOnlyMode;
        }
    }
}
