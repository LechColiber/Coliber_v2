
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
    public partial class Departments : Form
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

        string Table = "departam";

        string TempFirstName;
        string TempSurName;
        int TempID_rodzaj;

        int id_rodzaj;
        private string SearchText;

        public Departments(Connection NewConnection)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.NewConnection = NewConnection;

            this.Command = new OdbcCommand();

            RodzajDataTable = ReturnDataTable();
            SetIDRodzajListToComboBox(ReturnIDRodzajList(RodzajDataTable));

            SelectFromDb();

            label1.Text = "";
            SearchText = "";
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this,"departments");
            mapping.Add(label4,"searching");
            mapping.Add(EditButton,"edit");
            mapping.Add(label3,"books_collection");
            mapping.Add(ShowBooksButton,"show_articles");
            mapping.Add(label2,"articles_001");
            mapping.Add(label12,"department_shows_in");
            mapping.Add(ExitButton,"exit");
            mapping.Add(PrintButton,"print");
            mapping.Add(MergeButton,"do_change");
            mapping.Add(AddButton,"add");
            mapping.Add(DelButton,"delete");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        
        private void SelectFromDb()
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;

                /*if (IDRodzajComboBox.SelectedValue.ToString().ToLower().Trim() == "wszystkie")
                {*/
                    Command.CommandText = "SELECT kod_depart as [id], LTRIM(RTRIM(departam)) AS [Departament] FROM " + this.Table + " " +
                                          "ORDER BY departam;";
                /*}
                else
                {
                    Command.CommandText = "SELECT id_aut, LTRIM(RTRIM(nazwisko)) AS [Nazwisko], LTRIM(RTRIM(imie)) AS [Imię], LTRIM(RTRIM(rodzaje.nazwa)) AS [Księgozbiór2], list_aut_k.id_rodzaj AS [id_rodzaj] FROM " + this.Table + " " +
                                          "LEFT JOIN dbo.rodzaje ON dbo.rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " +
                                          "WHERE " + this.Table + ".id_rodzaj = ? ORDER BY nazwisko, imie;";
                    Command.Parameters.AddWithValue("id_rodzaj", id_rodzaj);
                }*/

                Adapter = new OdbcDataAdapter();
                Adapter.SelectCommand = Command;

                Ds = new DataSet();

                Adapter.Fill(Ds);                

                Ds.Tables[0].Columns.Add("L.p.");
                Ds.Tables[0].Columns["L.p."].SetOrdinal(0);

                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                    Ds.Tables[0].Rows[i]["L.p."] = i + 1;
                
                dataGridView1.DataSource = Ds.Tables[0];

                dataGridView1.Columns["id"].Visible = false;

                dataGridView1.Columns["L.p."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Departament"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                
                //dataGridView1.Columns["id_aut"].Width = 90;
                //dataGridView1.Columns["Księgozbiór"].Width = 62;

                dataGridView1.Columns["L.p."].HeaderText = _T("oridinal_short");
                dataGridView1.Columns["Departament"].HeaderText = _T("department");
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            ModifyDepartmentsForm MDF = new ModifyDepartmentsForm(NewConnection, "", -1, 1);
            MDF.ShowDialog();

            //SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
            SelectFromDb();
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            /*if (MessageBox.Show("Wyświetlić zasoby " +  dataGridView1["Nazwisko", dataGridView1.CurrentRow.Index].Value.ToString() + " " + dataGridView1["Imię", dataGridView1.CurrentRow.Index].Value.ToString() + "?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                ShowList ShowListForm = new ShowList(GetListWithBooksWhereAuthorsOccured(dataGridView1["Imię", dataGridView1.CurrentRow.Index].Value.ToString(), dataGridView1["Nazwisko", dataGridView1.CurrentRow.Index].Value.ToString()), dataGridView1["Imię", dataGridView1.CurrentRow.Index].Value.ToString() + " " + dataGridView1["Nazwisko", dataGridView1.CurrentRow.Index].Value.ToString()); 
                ShowListForm.ShowDialog();
            }*/

            if (dataGridView1.Rows.Count > 0 && MessageBox.Show(_T("to_delete") + " " + dataGridView1["Departament", dataGridView1.CurrentRow.Index].Value.ToString() + " ?", _T("db_deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {                    
                try
                {
                    OdbcCommand ChangeCommand = new OdbcCommand();
                    ChangeCommand.Connection = NewConnection.AppConnection;

                    ChangeCommand.CommandText = "EXEC ModifyDepartment '', ?, 3; ";
                    ChangeCommand.Parameters.AddWithValue("@ID", dataGridView1["id", dataGridView1.CurrentRow.Index].Value.ToString());

                    OdbcDataReader Reader = ChangeCommand.ExecuteReader();

                    string InfoFromDb = "";

                    while (Reader.Read())
                    {
                        InfoFromDb += Reader.GetValue(0).ToString();
                    }

                    if (InfoFromDb != "")
                        MessageBox.Show(InfoFromDb);
                    else
                        MessageBox.Show(_T("department_has_been_deleted"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Reader.Close();

                    SelectFromDb();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }                    
            }            
        }
        
        private void MergeButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";           
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //OdbcCommand Command = new OdbcCommand();
                //Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT COUNT(DISTINCT tytul) " +
                                        "FROM dla_kogo " +
                                        "INNER JOIN czasop ON dla_kogo.kod = czasop.kod " + 
                                        "WHERE kod_depart = ?; ";
                Command.Parameters.AddWithValue("@kod", dataGridView1["id", e.RowIndex].Value.ToString());

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

        private void ShowBooksButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (CountTextBox.Text != "")
            {
                ShowList ShowListForm = new ShowList(GetListWithBooksWhereDepartmentOccured(dataGridView1["id", dataGridView1.CurrentRow.Index].Value.ToString()), _T("for_magazine"));
                ShowListForm.ShowDialog();
            }

            dataGridView1.Focus();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            try
            {
                OdbcCommand ReportCommand = new OdbcCommand();
                ReportCommand.Connection = NewConnection.AppConnection;

                ReportCommand.CommandText = "SELECT LTRIM(RTRIM(departam)) AS departam FROM departam ORDER BY departam; ";

                ShowReport Report = new ShowReport(ReportCommand, "Departamenty");

                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate {  Wait.Show(this); Wait.Update(); });

                Report.ShowDialog();

                Wait.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void IDRodzajComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
            SelectFromDb();

            dataGridView1.Focus();
        }

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

        private List<string> GetListWithBooksWhereDepartmentOccured(string id)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;

                Command.CommandText = "SELECT DISTINCT LTRIM(RTRIM(tytul)) AS tytul " +
                                      "FROM czasop " +
                                      "INNER JOIN dla_kogo ON dla_kogo.kod = czasop.kod " +
                                      "WHERE kod_depart = ? " +
                                      "ORDER BY tytul; ";
                Command.Parameters.AddWithValue("@id", id);


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

        private void Authors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (dataGridView1.CurrentRow != null)
            {
                string ID_current = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                /*ModifyAuthorForm MAF = new ModifyAuthorForm(this.NewConnection, dataGridView1.CurrentRow.Cells["Imię"].Value.ToString(), dataGridView1.CurrentRow.Cells["Nazwisko"].Value.ToString(), Int32.Parse(dataGridView1.CurrentRow.Cells["id_rodzaj"].Value.ToString()), Int32.Parse(dataGridView1.CurrentRow.Cells["id_aut"].Value.ToString()), 2);
                MAF.ShowDialog();*/

                ModifyDepartmentsForm MDF = new ModifyDepartmentsForm(NewConnection, dataGridView1.CurrentRow.Cells["Departament"].Value.ToString(), Int32.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()), 2);
                MDF.ShowDialog();

                //SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
                SelectFromDb();
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1["id", i].Value.ToString() == ID_current)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Cells["Departament"].Selected = true;
                    }
                }
            }            
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
                if (dataGridView1.Rows[i].Cells["Departament"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1["Departament", i];
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search(e.KeyChar.ToString());
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SearchText = "";
                label1.Text = "";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            SearchText = "";
            label1.Text = "";            
        }
    }
}
