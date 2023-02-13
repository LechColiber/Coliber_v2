using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class Authors : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        Connection NewConnection;
        OdbcDataAdapter Adapter;
        DataSet Ds;
        OdbcDataReader Reader;
        OdbcCommand Command;
        List<int> CodesList;

        DataTable RodzajDataTable;

        string Table = "list_aut_k";

        string TempFirstName;
        string TempSurName;
        int TempID_rodzaj;

        int id_rodzaj;
        private string SearchText;

        // OK
        public Authors(Connection NewConnection)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.NewConnection = NewConnection;
            //this.StartPosition = FormStartPosition.CenterParent;

            this.Command = new OdbcCommand();

            RodzajDataTable = ReturnDataTable();
            SetIDRodzajListToComboBox(ReturnIDRodzajList(RodzajDataTable));
            //SetGridProperties();
            SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

            label1.Text = "";
            SearchText = "";
            Text = _T("authors") + " " + _T("for_books");
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "authors");
            mapping.Add(label4, "searching");
            mapping.Add(EditButton, "edit");
            mapping.Add(label3, "books_collection");
            mapping.Add(ShowBooksButton, "show_books");
            mapping.Add(label2, "books_001");
            mapping.Add(label12, "author_appears_in");
            mapping.Add(ExitButton, "exit");
            mapping.Add(PrintButton, "print");
            mapping.Add(MergeButton, "merge");
            mapping.Add(AddButton, "add");
            mapping.Add(DelButton, "delete");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        // OK
        private void SelectFromDb(int id_rodzaj)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;

                if (IDRodzajComboBox.SelectedValue.ToString().ToLower().Trim() == _T("all").ToLower().Trim())
                {
                    Command.CommandText = "SELECT id_aut, LTRIM(RTRIM(nazwisko)) AS [Nazwisko], LTRIM(RTRIM(imie)) AS [Imię], LTRIM(RTRIM(rodzaje.nazwa)) AS [Księgozbiór2], list_aut_k.id_rodzaj AS [id_rodzaj] FROM " + this.Table + " " +
                                          "LEFT JOIN dbo.rodzaje ON dbo.rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " +
                                          "ORDER BY nazwisko, imie;";
                }
                else
                {
                    Command.CommandText = "SELECT id_aut, LTRIM(RTRIM(nazwisko)) AS [Nazwisko], LTRIM(RTRIM(imie)) AS [Imię], LTRIM(RTRIM(rodzaje.nazwa)) AS [Księgozbiór2], list_aut_k.id_rodzaj AS [id_rodzaj] FROM " + this.Table + " " +
                                          "LEFT JOIN dbo.rodzaje ON dbo.rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " +
                                          "WHERE " + this.Table + ".id_rodzaj = ? ORDER BY nazwisko, imie;";
                    Command.Parameters.AddWithValue("id_rodzaj", id_rodzaj);
                }

                Adapter = new OdbcDataAdapter();
                Adapter.SelectCommand = Command;

                Ds = new DataSet();

                Adapter.Fill(Ds);

                Ds.Tables[0].Columns["id_aut"].ReadOnly = true;
                Ds.Tables[0].Columns.Add("L.p.");
                Ds.Tables[0].Columns["L.p."].SetOrdinal(0);

                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                    Ds.Tables[0].Rows[i]["L.p."] = i + 1;
                
                dataGridView1.DataSource = Ds.Tables[0];

                DataGridViewTextBoxColumn NameColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Imię"];
                NameColumn.MaxInputLength = 35;

                DataGridViewTextBoxColumn SurNameColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Nazwisko"];
                SurNameColumn.MaxInputLength = 40;

                dataGridView1.Columns["L.p."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["L.p."].HeaderText = _T("oridinal_short");
                //dataGridView1.Columns["Imię"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dataGridView1.Columns["Nazwisko"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridView1.Columns["Księgozbiór2"].Visible = false;
                dataGridView1.Columns["Księgozbiór2"].HeaderText = _T("books_collection");
                dataGridView1.Columns["Nazwisko"].HeaderText = _T("last_name");
                dataGridView1.Columns["Imię"].HeaderText = _T("first_name");
                dataGridView1.Columns["id_aut"].Visible = false;
                dataGridView1.Columns["id_rodzaj"].Visible = false;
                
                //dataGridView1.Columns["id_aut"].Width = 90;
                //dataGridView1.Columns["Księgozbiór"].Width = 62;

                dataGridView1.Refresh();

                if (dataGridView1.Rows.Count < 1)
                    CountTextBox.Text = "";

                //SetDefaultComboboxValue();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                MessageBox.Show(Ex.ToString());
            }
        }

        // OK
        private void AddButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";
            int idRodzaj;
            idRodzaj = ReturnIDRodzaj(RodzajDataTable);
            if (IDRodzajComboBox.SelectedValue.ToString().ToLower().Trim() == _T("all").ToLower())
            {
                MessageBox.Show(_T("choose_invertory_to_add_new"), _T("information"), MessageBoxButtons.OK);
            }
            else
            {
                ModifyAuthorForm MAF = new ModifyAuthorForm(this.NewConnection, "", "", idRodzaj, -1, 1);
                MAF.ShowDialog();
                SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
            }
        }

        // OK
        private void DelButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (CountTextBox.TextLength > 0 && Int32.Parse(CountTextBox.Text) > 0)
            {
                if (MessageBox.Show(_T("to_delete") + " " + dataGridView1["Nazwisko", dataGridView1.CurrentRow.Index].Value.ToString() + " " + dataGridView1["Imię", dataGridView1.CurrentRow.Index].Value.ToString() + "?", _T("db_deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        DeleteAuthor(Int32.Parse(dataGridView1["id_aut", dataGridView1.CurrentRow.Index].Value.ToString()));
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }                  
                }
            }
            else
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (MessageBox.Show(_T("author_not_bound_q") + dataGridView1["Nazwisko", dataGridView1.CurrentRow.Index].Value.ToString() + " " + dataGridView1["Imię", dataGridView1.CurrentRow.Index].Value.ToString() + "?", _T("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        DeleteAuthor(Int32.Parse(dataGridView1["id_aut", dataGridView1.CurrentRow.Index].Value.ToString()));
                    }
                }
            }
        }

        // OK
        //private List<int> GetCodes(string SurName, string FirstName)
        private List<int> GetCodes(string id_aut)
        {
            List<int> List = new List<int>();

            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;

                Command.CommandText = "SELECT DISTINCT kod " +
                                      "FROM dbo.ksiazki_new " +
                                      "LEFT JOIN ksiazki_autor_new ON  ksiazki_autor_new.id_ksiazka = kod " +
                                      "LEFT JOIN ksiazki_wautor_new ON  ksiazki_wautor_new.id_ksiazka = kod " +
                                      "WHERE id_autor = ? or id_wautor = ?; ";

                Command.Parameters.AddWithValue("@id_aut", id_aut);
                Command.Parameters.AddWithValue("@id_waut", id_aut);


                OdbcDataReader Reader;
                Reader = Command.ExecuteReader();     

                while (Reader.Read())
                {
                    List.Add(Int32.Parse(Reader.GetValue(0).ToString()));
                }

                Reader.Close();
                Command.Parameters.Clear();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return List;
        }

        // OK
        private void DeleteAuthor(int ID)
        {
            try
            {
                int FirstDisplayedRow = dataGridView1.FirstDisplayedScrollingRowIndex;
                int CurrentRow = dataGridView1.CurrentRow.Index;
                //kod od usuwania
                Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;                

                Command.CommandText = "EXEC ModifyAuthor '', '', 1, ?, 3; ";

                Command.Parameters.AddWithValue("ID", ID);

                Command.ExecuteNonQuery();

                Command.Parameters.Clear();

                SelectFromDb(ReturnIDRodzaj(RodzajDataTable));               

                MessageBox.Show(_T("completed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (MergeButton.Text == _T("cancel"))
            {
                AddButton.Text = _T("add");
                MergeButton.Text = _T("merge");

                DelButton.Enabled = true;
                PrintButton.Enabled = true;
                ShowBooksButton.Enabled = true;
                ExitButton.Enabled = true;

                MergeButton.Image = Resources.zastap;

                SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Update();

                if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow.Index > 0)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;

                    dataGridView1["Nazwisko", dataGridView1.Rows.Count - 1].Selected = true;
                }
            }
            else if (MergeButton.Text == _T("merge") && dataGridView1.Rows.Count > 0)
            {
                try
                {
                    OdbcCommand Command = new OdbcCommand();
                    Command.Connection = NewConnection.AppConnection;
                    Command.CommandText = "SELECT id_aut as id, LTRIM(RTRIM(nazwisko)) AS Nazwisko, LTRIM(RTRIM(imie)) AS Imię, LTRIM(RTRIM(Nazwa)) AS [Księgozbiór] FROM " + this.Table + " " +
                                          "JOIN dbo.rodzaje ON dbo.rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " +
                                          "WHERE id_aut != ? ORDER BY nazwisko, imie;";

                    Command.Parameters.AddWithValue("@IDAuthor", Int32.Parse(dataGridView1["id_aut", dataGridView1.CurrentRow.Index].Value.ToString()));

                    OdbcDataAdapter Adapter = new OdbcDataAdapter();
                    Adapter.SelectCommand = Command;

                    DataSet ChooseDs = new DataSet();
                    Adapter.Fill(ChooseDs);

                    ChooseSecond ChSForm = new ChooseSecond(ChooseDs);

                    if (ChSForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        int ID = ChSForm.ReturnID();
                        int Row = 0;
                        string ID_current = dataGridView1.CurrentRow.Cells["id_aut"].Value.ToString();

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Int32.Parse(dataGridView1["id_aut", i].Value.ToString()) == ID)
                            {
                                Row = i;
                                break;
                            }
                        }

                        if (MessageBox.Show(_T("merge_q") + dataGridView1["Nazwisko", dataGridView1.CurrentRow.Index].Value.ToString() + " " + dataGridView1["Imię", dataGridView1.CurrentRow.Index].Value.ToString() + " z " + dataGridView1["Nazwisko", Row].Value.ToString() + " " + dataGridView1["Imię", Row].Value.ToString() + "?", _T("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)                        
                        {                                                        
                            //List<int> List = GetCodes(dataGridView1["id_aut", dataGridView1.CurrentRow.Index].Value.ToString());

                            UpdateAuthorInBooks(ID_current, ID.ToString());                            

                            DeleteAuthor(Int32.Parse(ID_current));

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {                                
                                if (dataGridView1["id_aut", i].Value.ToString() == ID.ToString())
                                {
                                    dataGridView1.ClearSelection();
                                    dataGridView1.Rows[i].Cells["Nazwisko"].Selected = true;
                                }
                            }
                        }                        
                    }                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // OK
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (AddButton.Text != _T("save"))
            {
                try
                {
                    //CodesList = GetCodes(dataGridView1["id_aut", e.RowIndex].Value.ToString());
                }
                catch (Exception)
                {
                }

                try
                {
                    Command.Connection = NewConnection.AppConnection;
                    
                    Command.CommandText = "SELECT COUNT(*) FROM  (" + Environment.NewLine + 
                                          "SELECT id_ksiazka FROM ksiazki_autor_new WHERE id_autor = ?" + Environment.NewLine +
                                          "UNION" + Environment.NewLine +  
                                          "SELECT id_ksiazka FROM ksiazki_wautor_new WHERE id_wautor = ?) AS ids";

                    Command.Parameters.AddWithValue("@id_aut", dataGridView1["id_aut", e.RowIndex].Value.ToString());
                    Command.Parameters.AddWithValue("@id_waut", dataGridView1["id_aut", e.RowIndex].Value.ToString());

                    //OdbcDataReader Reader;
                    Reader = Command.ExecuteReader();

                    while (Reader.Read())
                    {
                        CountTextBox.Text = Reader.GetValue(0).ToString();
                    }

                    Reader.Close();
                    Command.Parameters.Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // OK
        private void ShowBooksButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (CountTextBox.Text != "")
            {                
                ShowList ShowListForm = new ShowList(GetListWithBooksWhereAuthorsOccured(dataGridView1["id_aut", dataGridView1.CurrentRow.Index].Value.ToString()), dataGridView1["Imię", dataGridView1.CurrentRow.Index].Value.ToString() + " " + dataGridView1["Nazwisko", dataGridView1.CurrentRow.Index].Value.ToString());
                ShowListForm.ShowDialog();
            }

            dataGridView1.Focus();
        }        

        // OK        
        private void UpdateAuthorInBooks(string id_aut_old, string id_aut_new)
        {
            try
            {
                OdbcCommand ChangeCommand = new OdbcCommand();
                ChangeCommand.Connection = NewConnection.AppConnection;

                ChangeCommand.CommandText = "UPDATE ksiazki_autor_new SET id_autor = ? WHERE id_autor = ?; " +
                                            "UPDATE ksiazki_wautor_new SET id_wautor = ? WHERE id_wautor = ?; ";

                ChangeCommand.Parameters.AddWithValue("@ID", id_aut_new);
                ChangeCommand.Parameters.AddWithValue("@ID", id_aut_old);
                ChangeCommand.Parameters.AddWithValue("@ID", id_aut_new);
                ChangeCommand.Parameters.AddWithValue("@ID", id_aut_old);

                ChangeCommand.ExecuteNonQuery();
                //ChangeCommand.Dispose();
                //MessageBox.Show(TempFirstName + " " + TempSurName + " " + TempID_rodzaj.ToString());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            PrintForm PF = new PrintForm(NewConnection);
            PF.ShowDialog();
        }
        // OK
        private void IDRodzajComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
            dataGridView1.Focus();
        }

        // OK
        private DataTable ReturnDataTable()
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT id_rodzaj, LTRIM(RTRIM(nazwa)) AS [nazwa] FROM dbo.rodzaje";

                OdbcDataReader Reader = Command.ExecuteReader();
                DataTable Dt = new DataTable();
                Dt.Load(Reader);
                Reader.Close();

                return Dt;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return null;
        }

        // OK
        private List<string> ReturnIDRodzajList(DataTable Dt)
        {
            try
            {
                List<string> List = new List<string>();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    List.Add(Dt.Rows[i][1].ToString());
                }

                List.Add(_T("all"));
                List.Sort();
                return List;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return null;
        }

        // OK
        private void SetIDRodzajListToComboBox(List<string> List)
        {
            IDRodzajComboBox.DataSource = List;
        }

        // OK
        private int ReturnIDRodzaj(DataTable Dt)
        {
            try
            {               
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    if (Dt.Rows[i][1].ToString() == IDRodzajComboBox.SelectedValue.ToString())
                        id_rodzaj = Int32.Parse(Dt.Rows[i][0].ToString());
                }

                return id_rodzaj;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return 0;
        }

        // OK
        //private List<string> GetListWithBooksWhereAuthorsOccured(string FirstName, string SurName)
        private List<string> GetListWithBooksWhereAuthorsOccured(string id_aut)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;

                Command.CommandText = "SELECT DISTINCT tytul_gl, kod " +
                                      "FROM dbo.ksiazki_new " +
                                      "LEFT JOIN ksiazki_autor_new ON  ksiazki_autor_new.id_ksiazka = kod " +
                                      "LEFT JOIN ksiazki_wautor_new ON  ksiazki_wautor_new.id_ksiazka = kod " +
                                      "WHERE id_autor = ? or id_wautor = ? " +
                                      "ORDER BY tytul_gl; ";

                Command.Parameters.AddWithValue("@id_aut", id_aut);
                Command.Parameters.AddWithValue("@id_waut", id_aut);

                OdbcDataReader Reader;
                Reader = Command.ExecuteReader();

                List<string> List = new List<string>();
               
                while (Reader.Read())
                {
                    List.Add(Reader.GetValue(0).ToString());
                }

                List.Sort();
                
                Reader.Close();
                Command.Parameters.Clear();

                return List;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return null;
        }

        // OK
        private void Authors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        // OK
        private void EditButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (dataGridView1.CurrentRow != null)
            {
                string ID_current = dataGridView1.CurrentRow.Cells["id_aut"].Value.ToString();
                ModifyAuthorForm MAF = new ModifyAuthorForm(this.NewConnection, dataGridView1.CurrentRow.Cells["Imię"].Value.ToString(), dataGridView1.CurrentRow.Cells["Nazwisko"].Value.ToString(), Int32.Parse(dataGridView1.CurrentRow.Cells["id_rodzaj"].Value.ToString()), Int32.Parse(dataGridView1.CurrentRow.Cells["id_aut"].Value.ToString()), 2);
                MAF.ShowDialog();

                SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1["id_aut", i].Value.ToString() == ID_current)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Cells["Nazwisko"].Selected = true;
                    }
                }
            }            
        }

        // OK
        private void Search(string Letter)
        {
            if (Letter == '\b'.ToString())
            {
                if (SearchText.Length > 0)
                {
                    SearchText = SearchText.Remove(SearchText.Length - 1);
                    label1.Text = SearchText;
                }
            }
            else if (Letter == '\r'.ToString())
            {

            }
            else
            {
                SearchText += Letter;
                label1.Text = SearchText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Nazwisko"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1["Nazwisko", i];
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        // OK
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search(e.KeyChar.ToString());
        }

        // OK
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SearchText = "";
                label1.Text = "";
            }
        }

        // OK
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            SearchText = "";
            label1.Text = "";            
        }
    }
}