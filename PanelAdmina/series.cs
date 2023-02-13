
﻿using System;
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
    public partial class Series : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        Connection NewConnection;
        OdbcDataAdapter Adapter;
        DataSet Ds;
        OdbcCommand Command;

        DataTable RodzajDataTable;

        string Table = "dbo.serie";

        private string SearchText;

        // OK
        public Series(Connection NewConnection)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.NewConnection = NewConnection;
            this.StartPosition = FormStartPosition.CenterParent;

            this.Command = new OdbcCommand();

            RodzajDataTable = ReturnDataTable();
            SetIDRodzajListToComboBox(ReturnIDRodzajList(RodzajDataTable));
            SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

            SearchText = "";
            label1.Text = "";
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this,"series_for_books");
            mapping.Add(EditButton,"edit");
            mapping.Add(label4,"searching");
            mapping.Add(label3,"books_collection");
            mapping.Add(ShowBooksButton,"show_books");
            mapping.Add(label2,"books_001");
            mapping.Add(label12,"series_occurs");
            mapping.Add(ExitButton,"exit");
            mapping.Add(PrintButton,"print");
            mapping.Add(MergeButton,"merge");
            mapping.Add(AddButton,"add");
            mapping.Add(DelButton,"delete");
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
                    Command.CommandText = "SELECT kody AS [Kody], LTRIM(RTRIM(tyt_serii)) AS [Tytuł serii], " + /*LTRIM(RTRIM(tyt_row_s)) AS [Tytuł równoległy serii], LTRIM(RTRIM(tyt_dod_s)) AS [Tytuł dodatkowy serii],*/ " LTRIM(RTRIM(issn)) AS [ISSN], LTRIM(RTRIM(inst_serii)) AS [Instytucja sprawcza], LTRIM(RTRIM(sied_serii)) AS [Siedziba], LTRIM(RTRIM(rodzaje.nazwa)) AS [Księgozbiór], serie.id_rodzaj FROM " + this.Table + " " +
                                          "LEFT JOIN dbo.rodzaje ON dbo.rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " +
                                          "ORDER BY tyt_serii; ";
                }
                else
                {
                    Command.CommandText = //"SELECT kody AS [Kody], LTRIM(RTRIM(tyt_serii)) AS [Tytuł serii], LTRIM(RTRIM(inst_serii)) AS [Instytucja sprawcza], LTRIM(RTRIM(issn)) AS [ISSN], LTRIM(RTRIM(rodzaje.nazwa)) AS [Księgozbiór] FROM " + this.Table + " " +
                                          "SELECT kody AS [Kody], LTRIM(RTRIM(tyt_serii)) AS [Tytuł serii], " + /*LTRIM(RTRIM(tyt_row_s)) AS [Tytuł równoległy serii], LTRIM(RTRIM(tyt_dod_s)) AS [Tytuł dodatkowy serii],*/ " LTRIM(RTRIM(issn)) AS [ISSN], LTRIM(RTRIM(inst_serii)) AS [Instytucja sprawcza], LTRIM(RTRIM(sied_serii)) AS [Siedziba], LTRIM(RTRIM(rodzaje.nazwa)) AS [Księgozbiór], serie.id_rodzaj FROM " + this.Table + " " +
                                          "LEFT JOIN dbo.rodzaje ON dbo.rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " +
                                          "WHERE " + this.Table + ".id_rodzaj = ? ORDER BY tyt_serii;";
                    Command.Parameters.AddWithValue("id_rodzaj", id_rodzaj);
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

                DataGridViewTextBoxColumn TitleColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Tytuł serii"];
                TitleColumn.MaxInputLength = 201;

                DataGridViewTextBoxColumn InstitutionColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Instytucja sprawcza"];
                InstitutionColumn.MaxInputLength = 120;

                DataGridViewTextBoxColumn ISSNColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["ISSN"];
                ISSNColumn.MaxInputLength = 16;

                dataGridView1.Columns["L.p."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Tytuł serii"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["Instytucja sprawcza"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["ISSN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
                dataGridView1.Columns["Księgozbiór"].Visible = false;
                dataGridView1.Columns["Kody"].Visible = false;
                //dataGridView1.Columns["Tytuł równoległy serii"].Visible = false;
                //dataGridView1.Columns["Tytuł dodatkowy serii"].Visible = false;
                dataGridView1.Columns["Siedziba"].Visible = false;
                dataGridView1.Columns["id_rodzaj"].Visible = false;
                dataGridView1.Columns["L.p."].HeaderText = _T("oridinal_short");

                dataGridView1.Columns["Tytuł serii"].HeaderText = _T("series_title");
                dataGridView1.Columns["ISSN"].HeaderText = _T("issn");
                dataGridView1.Columns["Instytucja sprawcza"].HeaderText = _T("institution");

                dataGridView1.Refresh();

                if (dataGridView1.Rows.Count < 1)
                    CountTextBox.Text = "";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        // OK
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (AddButton.Text != _T("save"))
            {
                try
                {
                    OdbcCommand Command = new OdbcCommand();
                    Command.Connection = NewConnection.AppConnection;
                    Command.CommandText = "SELECT COUNT(*) " +
                                          "FROM dbo.ksi_ser " +
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

        // OK
        private void ShowBooksButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (CountTextBox.Text != "")
            {
                ShowList ShowListForm = new ShowList(GetListWhereSeriesOccured(Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString())), _T("for") + " " + dataGridView1["Tytuł serii", dataGridView1.CurrentRow.Index].Value.ToString());
                ShowListForm.ShowDialog();
            }
            dataGridView1.Focus();
        }

        // OK
        private List<string> GetListWhereSeriesOccured(int IDKey)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT LTRIM(RTRIM(tytul_gl)) AS tytul " +
                                        "FROM dbo.ksiazki_new " +
                                        "JOIN dbo.ksi_ser ON dbo.ksiazki_new.kod = dbo.ksi_ser.kod " +
                                        "WHERE ksi_ser.kody = ? " +
                                        "ORDER BY tytul_gl; ";
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

        // OK
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
                EditSeriesForm ESF = new EditSeriesForm(NewConnection, 1, ReturnIDRodzaj(RodzajDataTable));
                ESF.ShowDialog();
                SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
            }
        }

        // OK
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

        // OK
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

                    dataGridView1["Tytuł serii", dataGridView1.Rows.Count - 1].Selected = true;
                }
            }
            else if (MergeButton.Text == _T("merge") && dataGridView1.Rows.Count > 0)
            {
                try
                {
                    OdbcCommand Command = new OdbcCommand();
                    Command.Connection = NewConnection.AppConnection;
                    Command.CommandText = "SELECT kody AS [id], LTRIM(RTRIM(tyt_serii)) AS [Tytuł serii], LTRIM(RTRIM(inst_serii)) AS [Instytucja sprawcza], LTRIM(RTRIM(issn)) AS [ISSN], LTRIM(RTRIM(rodzaje.nazwa)) AS [Księgozbiór] FROM " + this.Table + " " + "LEFT JOIN dbo.rodzaje ON dbo.rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " + "WHERE kody != ? ORDER BY tyt_serii"; 
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

                        if (MessageBox.Show(_T("merge_q") + "\"" + dataGridView1["Tytuł serii", dataGridView1.CurrentRow.Index].Value.ToString() + "\"" + _T("with") + "\"" + dataGridView1["Tytuł serii", Row].Value.ToString() + "\"?", _T("data_merge"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            OdbcCommand MergeCommand = new OdbcCommand();
                            MergeCommand.Connection = NewConnection.AppConnection;

                            MergeCommand.CommandText = "UPDATE dbo.ksi_ser " +
                                                       "SET kody = ? " +
                                                       "WHERE kody = ?; ";
                            MergeCommand.Parameters.AddWithValue("@ID", Int32.Parse(dataGridView1["Kody", Row].Value.ToString()));
                            MergeCommand.Parameters.AddWithValue("@Codes", Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString()));
                            //MergeCommand.Parameters.AddWithValue("@ISSN", dataGridView1["ISSN", dataGridView1.CurrentRow.Index].Value.ToString());
                            

                            MergeCommand.ExecuteNonQuery();
                            //MessageBox.Show("Wykonano!");
                            //DeleteSeries(Int32.Parse(dataGridView1["Kody", Row].Value.ToString()), false);
                            DeleteSeries(Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString()), true);

                            SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1["Kody", i].Value.ToString() == ID.ToString())
                                {
                                    dataGridView1.ClearSelection();
                                    dataGridView1.Rows[i].Cells["Tytuł serii"].Selected = true;
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

        // OK
        private void DelButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = ""; 
            
            if (dataGridView1.Rows.Count > 0)
            {
                /*if (CountTextBox.TextLength > 0 && Int32.Parse(CountTextBox.Text) > 0)
                {
                    if (MessageBox.Show("Wyświetlić zasoby \"" + dataGridView1["Tytuł serii", dataGridView1.CurrentRow.Index].Value.ToString() + "\"?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ShowList ShowListForm = new ShowList(GetListWhereSeriesOccured(Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString())), dataGridView1["Tytuł serii", dataGridView1.CurrentRow.Index].Value.ToString());
                        ShowListForm.ShowDialog();
                    }
                }*/
                if (MessageBox.Show(_T("to_delete") + " " + dataGridView1["Tytuł serii", dataGridView1.CurrentRow.Index].Value.ToString() + "?", _T("deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteSeries(Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString()), true);
                    /*if (DeleteSeriesFrom())
                        DeleteSeries(Int32.Parse(dataGridView1["Kody", dataGridView1.CurrentRow.Index].Value.ToString()));*/
                    dataGridView1.Focus();

                    SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
                }
            }
        }

        // OK
        private void DeleteSeries(int Codes, bool NoMessages)
        {
            try
            {
                int FirstDisplayedRow = dataGridView1.FirstDisplayedScrollingRowIndex;
                int CurrentRow = dataGridView1.CurrentRow.Index;

                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;

                Command.CommandText = "EXEC ModifySeries ''," + /* '', '',*/  "'', '', '', '', ?, 3; ";

                Command.Parameters.AddWithValue("@p_kody", Codes);

                OdbcDataReader Reader = Command.ExecuteReader();

                string InfoFromDb = "";

                while (Reader.Read())
                {
                    InfoFromDb += Reader.GetValue(0).ToString();
                }

                if (InfoFromDb.Trim() != "")
                    MessageBox.Show(InfoFromDb);
                else
                {
                        MessageBox.Show(_T("completed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Reader.Close();
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

            try
            {
                OdbcCommand ReportCommand = new OdbcCommand();
                ReportCommand.Connection = NewConnection.AppConnection;

                ReportCommand.CommandText = "SELECT " +
                                               "LTRIM(RTRIM(tyt_serii)) as tyt, " +
                                               "LTRIM(RTRIM(issn)) as issn, " +
                                               "LTRIM(RTRIM(inst_serii)) as inst " +
                                             "FROM dbo.serie ORDER BY tyt_serii, issn, inst_serii, sied_serii; ";

                ShowReport Report = new ShowReport(ReportCommand, "SeriesReport");

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
       
        // OK
        private void Series_KeyDown(object sender, KeyEventArgs e)
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
                if (dataGridView1.Rows[i].Cells["Tytuł serii"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1["Tytuł serii", i];
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search(e.KeyChar.ToString());
        }

        // OK
        private void EditButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (dataGridView1.CurrentRow != null)
            {
                string ID_current = dataGridView1.CurrentRow.Cells["Kody"].Value.ToString();

                //EditSeriesForm ESF = new EditSeriesForm(NewConnection, 2, Int32.Parse(dataGridView1.CurrentRow.Cells["id_rodzaj"].Value.ToString()), dataGridView1.CurrentRow.Cells["Kody"].Value.ToString(), dataGridView1.CurrentRow.Cells["Tytuł serii"].Value.ToString(), dataGridView1.CurrentRow.Cells["Tytuł równoległy serii"].Value.ToString(), dataGridView1.CurrentRow.Cells["Tytuł dodatkowy serii"].Value.ToString(), dataGridView1.CurrentRow.Cells["ISSN"].Value.ToString(), dataGridView1.CurrentRow.Cells["Instytucja sprawcza"].Value.ToString(), dataGridView1.CurrentRow.Cells["Siedziba"].Value.ToString());
                EditSeriesForm ESF = new EditSeriesForm(NewConnection, 2, Int32.Parse(dataGridView1.CurrentRow.Cells["id_rodzaj"].Value.ToString()), dataGridView1.CurrentRow.Cells["Kody"].Value.ToString(), dataGridView1.CurrentRow.Cells["Tytuł serii"].Value.ToString(), dataGridView1.CurrentRow.Cells["ISSN"].Value.ToString(), dataGridView1.CurrentRow.Cells["Instytucja sprawcza"].Value.ToString(), dataGridView1.CurrentRow.Cells["Siedziba"].Value.ToString());
                ESF.ShowDialog();

                SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1["Kody", i].Value.ToString() == ID_current)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Cells["Tytuł serii"].Selected = true;
                    }
                }
            }      
        }

        // OK
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {          
            SearchText = "";
            label1.Text = "";            
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
    }
}
