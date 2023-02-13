

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;
using WindowsFormsApplication1.Properties;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class MagazinesKeys : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        Connection NewConnection;
        string SelectedTable;
        string Table = "dbo.klucze_c";

        OdbcDataAdapter Adapter;
        DataSet Ds;
        DataTable RodzajDataTable;

        private string SearchText;

        public MagazinesKeys(Connection NewConnection, string Caption, string SelectedTable)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();
            this.StartPosition = FormStartPosition.CenterParent;

            this.NewConnection = NewConnection;

            this.SelectedTable = SelectedTable;

            RodzajDataTable = ReturnDataTable();
            SetIDRodzajListToComboBox(ReturnIDRodzajList(RodzajDataTable));
            SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

            SearchText = "";
            label1.Text = "";
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this,"magazines_keys");
            mapping.Add(label4,"searching");
            mapping.Add(EditButton,"edit");
            mapping.Add(label3,"books_collection");
            mapping.Add(ShowBooksButton,"show_articles");
            mapping.Add(label2,"articles_001");
            mapping.Add(label12,"key_appears_in");
            mapping.Add(ExitButton,"exit");
            mapping.Add(PrintButton,"print");
            mapping.Add(MergeButton,"merge");
            mapping.Add(AddButton,"add");
            mapping.Add(DelButton,"delete");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void SelectFromDb(int id_rodzaj)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;

                if (IDRodzajComboBox.SelectedValue.ToString().ToLower().Trim() == _T("all").ToLower().Trim())
                {
                    Command.CommandText = "SELECT kody AS [Kody], LTRIM(RTRIM(klucze)) AS [Klucze], LTRIM(RTRIM(rodzaje.nazwa)) AS [Księgozbiór], " + this.Table + ".id_rodzaj FROM " + this.Table + " " +
                                          "JOIN rodzaje ON rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " +
                                          "ORDER BY klucze;";
                }
                else
                {
                    Command.CommandText = "SELECT kody AS [Kody], LTRIM(RTRIM(klucze)) AS [Klucze], LTRIM(RTRIM(rodzaje.nazwa)) AS [Księgozbiór], " + this.Table + ".id_rodzaj FROM " + this.Table + " " +
                                          "JOIN rodzaje ON rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " +
                                          "WHERE " + this.Table + ".id_rodzaj = ? ORDER BY klucze;";
                    Command.Parameters.AddWithValue("ID", id_rodzaj);
                }

                Adapter = new OdbcDataAdapter();
                Adapter.SelectCommand = Command;

                Ds = new DataSet();

                Adapter.Fill(Ds);

                Ds.Tables[0].Columns["Kody"].ReadOnly = true;
                
                Ds.Tables[0].Columns.Add("L.p.");
                Ds.Tables[0].Columns["L.p."].SetOrdinal(0);

                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                    Ds.Tables[0].Rows[i]["L.p."] = i + 1;

                dataGridView1.DataSource = Ds.Tables[0];

                DataGridViewTextBoxColumn NameColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Klucze"];
                NameColumn.MaxInputLength = 120;

                dataGridView1.Columns["L.p."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.Columns["Księgozbiór"].Visible = false;
                dataGridView1.Columns["Kody"].Visible = false;
                dataGridView1.Columns["id_rodzaj"].Visible = false;

                dataGridView1.Columns["L.p."].HeaderText = _T("oridinal_short");
                dataGridView1.Columns["Klucze"].HeaderText = _T("keys");

                dataGridView1.Refresh();

                if (dataGridView1.Rows.Count < 1)
                    CountTextBox.Text = "";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (AddButton.Text != "Zapisz")
            {
                try
                {
                    OdbcCommand Command = new OdbcCommand();
                    Command.Connection = NewConnection.AppConnection;
                    Command.CommandText = "SELECT COUNT(*) " +
                                          "FROM  " + this.SelectedTable + " " +
                                          "WHERE kody = ?; ";
                    Command.Parameters.AddWithValue("Codes", Int32.Parse(dataGridView1["Kody", e.RowIndex].Value.ToString()));

                    OdbcDataReader Reader;
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

        private void ShowBooksButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (CountTextBox.Text != "")
            {
                ShowList ShowListForm = new ShowList(GetListWhereKeyOccured(Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString())), dataGridView1["Klucze", dataGridView1.CurrentRow.Index].Value.ToString());
                ShowListForm.ShowDialog();
            }
            dataGridView1.Focus();
        }

        private List<string> GetListWhereKeyOccured(int IDKey)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT LTRIM(RTRIM(tytul)) As tytul " + "FROM dbo.czasop " + "LEFT JOIN dbo.cza_klu ON czasop.kod = cza_klu.kod " + "LEFT JOIN dbo.klucze_c ON klucze_c.kody = cza_klu.kody " + "WHERE klucze_c.kody = ? " + "ORDER BY tytul; "; 
                Command.Parameters.AddWithValue("Codes", IDKey);

                OdbcDataReader Reader;
                Reader = Command.ExecuteReader();

                List<string> List = new List<string>();

                while (Reader.Read())
                {
                    List.Add(Reader.GetValue(0).ToString());
                }

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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                EditKeysForm EKF = new EditKeysForm(NewConnection, ReturnIDRodzaj(RodzajDataTable), 1, "", -1, 'c');
                EKF.ShowDialog();
                SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
            }
        }

        private DataTable ReturnDataTable()
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT id_rodzaj, LTRIM(RTRIM(nazwa)) AS [nazwa] FROM dbo.rodzaje; ";

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

        private void SetIDRodzajListToComboBox(List<string> List)
        {
            IDRodzajComboBox.DataSource = List;
        }

        private int ReturnIDRodzaj(DataTable Dt)
        {
            int id_rodzaj = 0;

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

        private void IDRodzajComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

            dataGridView1.Focus();
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

                    dataGridView1["Klucze", dataGridView1.Rows.Count - 1].Selected = true;
                }
            }
            else if (MergeButton.Text == _T("merge") && dataGridView1.Rows.Count > 0)
            {
                try
                {
                    OdbcCommand Command = new OdbcCommand();
                    Command.Connection = NewConnection.AppConnection;
                    Command.CommandText = "SELECT kody AS [id], LTRIM(RTRIM(klucze)) AS [Klucze], LTRIM(RTRIM(nazwa)) AS [Księgozbiór] FROM " + this.Table + " " +
                                          "LEFT JOIN dbo.rodzaje ON dbo.rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " +
                                          "WHERE kody != ? ORDER BY klucze;";
                    Command.Parameters.AddWithValue("@Codes", Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString()));

                    OdbcDataAdapter Adapter = new OdbcDataAdapter();
                    Adapter.SelectCommand = Command;

                    DataSet ChooseDs = new DataSet();
                    Adapter.Fill(ChooseDs);

                    ChooseSecond ChSForm = new ChooseSecond(ChooseDs);

                    if (ChSForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        int ID = ChSForm.ReturnID();
                        int Row = 0;

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Int32.Parse(dataGridView1["Kody", i].Value.ToString()) == ID)
                            {
                                Row = i;
                                break;
                            }
                        }

                        if (MessageBox.Show(_T("merge_q") + "\"" + dataGridView1["Klucze", dataGridView1.CurrentRow.Index].Value.ToString() + "\"" + _T("with") + "\"" + dataGridView1["Klucze", Row].Value.ToString() + "\"?", _T("information"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            OdbcCommand MergeCommand = new OdbcCommand();
                            MergeCommand.Connection = NewConnection.AppConnection;

                            MergeCommand.CommandText = "UPDATE " + this.SelectedTable + " " +
                                                       "SET kody = ?, klucze = ? " +
                                                       "WHERE kody = ?";
                            /*MergeCommand.Parameters.AddWithValue("@Codes", Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString()));
                            MergeCommand.Parameters.AddWithValue("@Keys", dataGridView1["Klucze", dataGridView1.CurrentRow.Index].Value.ToString());
                            MergeCommand.Parameters.AddWithValue("@OldCodes", Int32.Parse(dataGridView1["Kody", Row].Value.ToString()));*/
                            MergeCommand.Parameters.AddWithValue("@Codes", Int32.Parse(dataGridView1["Kody", Row].Value.ToString()));
                            MergeCommand.Parameters.AddWithValue("@Keys", dataGridView1["Klucze", Row].Value.ToString());
                            MergeCommand.Parameters.AddWithValue("@OldCodes", Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString()));

                            MergeCommand.ExecuteNonQuery();

                            //DeleteKey(Int32.Parse(dataGridView1["Kody", Row].Value.ToString()));
                            DeleteKey(Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString()));

                            SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1["Kody", i].Value.ToString() == ID.ToString())
                                {
                                    dataGridView1.ClearSelection();
                                    dataGridView1.Rows[i].Cells["Klucze"].Selected = true;
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

        private void DelButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (dataGridView1.Rows.Count > 0)
            {
                if (CountTextBox.TextLength > 0 && Int32.Parse(CountTextBox.Text) > 0)
                {
                    if (MessageBox.Show(_T("show_res_q") + " " + dataGridView1["Klucze", dataGridView1.CurrentRow.Index].Value.ToString() + "?", _T("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ShowList ShowListForm = new ShowList(GetListWhereKeyOccured(Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString())), dataGridView1["Klucze", dataGridView1.CurrentRow.Index].Value.ToString());
                        ShowListForm.ShowDialog();
                    }
                }
                if (MessageBox.Show(_T("to_delete") + " " + dataGridView1["Klucze", dataGridView1.CurrentRow.Index].Value.ToString() + " ?", _T("deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DeleteKeyFromArticles())
                        DeleteKey(Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString()));
                }
            }
        }

        private void DeleteKey(int Codes)
        {
            try
            {
                int FirstDisplayedRow = dataGridView1.FirstDisplayedScrollingRowIndex;
                int CurrentRow = dataGridView1.CurrentRow.Index;

                OdbcCommand DeleteCommand = new OdbcCommand();
                DeleteCommand.Connection = NewConnection.AppConnection;

                DeleteCommand.CommandText = "DELETE FROM " + this.Table + " WHERE kody = ?; ";
                DeleteCommand.Parameters.AddWithValue("@Codes", Codes);

                DeleteCommand.ExecuteNonQuery();

                MessageBox.Show(_T("completed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

                if (dataGridView1.Rows.Count > 0)
                {
                    if (CurrentRow > dataGridView1.CurrentRow.Index)
                        CurrentRow--;

                    dataGridView1.CurrentCell = dataGridView1["Klucze", CurrentRow];
                    dataGridView1.FirstDisplayedScrollingRowIndex = FirstDisplayedRow;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private bool DeleteKeyFromArticles()
        {
            try
            {
                OdbcCommand DeleteCommand = new OdbcCommand();
                DeleteCommand.Connection = NewConnection.AppConnection;

                DeleteCommand.CommandText = "DELETE FROM " + this.SelectedTable + " WHERE kody = ?; ";
                DeleteCommand.Parameters.AddWithValue("@Codes", Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString()));

                DeleteCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return false;
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            try
            {
                OdbcCommand ReportCommand = new OdbcCommand();
                ReportCommand.Connection = NewConnection.AppConnection;

                ReportCommand.CommandText = "SELECT LTRIM(RTRIM(klucze)) AS [klucze] FROM " + this.Table + " ORDER BY klucze; ";

                ShowReport Report = new ShowReport(ReportCommand, "MagazinesKeysReport");

                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                Report.ShowDialog();

                Wait.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }       

        private void MagazinesKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

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
                if (dataGridView1.Rows[i].Cells["Klucze"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1["Klucze", i];
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search(e.KeyChar.ToString());
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (dataGridView1.CurrentRow != null)
            {
                string ID_current = dataGridView1.CurrentRow.Cells["Kody"].Value.ToString();

                EditKeysForm EKF = new EditKeysForm(NewConnection, Int32.Parse(dataGridView1.CurrentRow.Cells["id_rodzaj"].Value.ToString()), 2, dataGridView1.CurrentRow.Cells["Klucze"].Value.ToString(), Int32.Parse(dataGridView1.CurrentRow.Cells["Kody"].Value.ToString()), 'c');
                EKF.ShowDialog();

                SelectFromDb(ReturnIDRodzaj(RodzajDataTable));               

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1["Kody", i].Value.ToString() == ID_current)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Cells["Klucze"].Selected = true;
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            SearchText = "";
            label1.Text = "";            
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SearchText = "";
                label1.Text = "";
            }
        }
    }
}
