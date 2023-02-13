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

namespace WindowsFormsApplication1
{
    public partial class SubSeries : _Window
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

        //DataTable RodzajDataTable;

        string Table = "dbo.podserie";

        public SubSeries(Connection NewConnection)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.NewConnection = NewConnection;
            this.StartPosition = FormStartPosition.CenterParent;

            this.Command = new OdbcCommand();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            //mapping.Add(OkButton, "ok");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
            //this.Text = _T("authors_coauthors_institutions");
        }

        private void SubSeries_Load(object sender, EventArgs e)
        {
            //RodzajDataTable = ReturnDataTable();
            //SetIDRodzajListToComboBox(ReturnIDRodzajList(RodzajDataTable));
            //SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
            SelectFromDb();
        }

        //private void SelectFromDb(int id_rodzaj)
        private void SelectFromDb()
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT id_podser AS [ID podserii], kod AS [Kod], LTRIM(RTRIM(tyt_pserii)) AS [Tytuł podserii], LTRIM(RTRIM(pissn)) AS [ISSN], LTRIM(RTRIM(nazwa_pcz)) AS [Nazwa części], LTRIM(RTRIM(numer_pcz)) AS [Numer części] FROM " + this.Table;

                Adapter = new OdbcDataAdapter();
                Adapter.SelectCommand = Command;

                Ds = new DataSet();

                Adapter.Fill(Ds);

                Ds.Tables[0].Columns["ID podserii"].ReadOnly = true;
    
                dataGridView1.DataSource = Ds.Tables[0];

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                DataGridViewTextBoxColumn CodeColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Kod"];
                if (CodeColumn.Visible == true)
                    CodeColumn.Visible = false;

                DataGridViewTextBoxColumn TitleColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Tytuł podserii"];
                TitleColumn.MaxInputLength = 201;

                DataGridViewTextBoxColumn ISSNColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["ISSN"];
                ISSNColumn.MaxInputLength = 16;

                DataGridViewTextBoxColumn NameColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Nazwa części"];
                NameColumn.MaxInputLength = 10;

                DataGridViewTextBoxColumn NumberColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Numer części"];
                NumberColumn.MaxInputLength = 25;

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
                                          "FROM dbo.podserie " +
                                          "WHERE id_podser = ? AND kod != 0";
                    Command.Parameters.AddWithValue("Code", Int32.Parse(dataGridView1["ID podserii", e.RowIndex].Value.ToString()));

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
            if (CountTextBox.Text != "")
            {
                ShowList ShowListForm = new ShowList(GetListWhereSeriesOccured(Int32.Parse(dataGridView1["Kod", dataGridView1.CurrentRow.Index].Value.ToString())), dataGridView1["Tytuł podserii", dataGridView1.CurrentRow.Index].Value.ToString());
                ShowListForm.ShowDialog();
            }
            dataGridView1.Focus();
        }

        private List<string> GetListWhereSeriesOccured(int IDKey)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT tytul_gl " +
                                        "FROM dbo.ksiazki " +
                                        "WHERE kod = ? " +
                                        "ORDER BY tytul_gl";
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
            if (MessageBox.Show(_T("close"), _T("question"), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                this.Dispose();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (AddButton.Text == "Dodaj")
            {
                CountTextBox.Text = "";
                AddButton.Text = "Zapisz";
                MergeButton.Text = "Anuluj";

                DelButton.Enabled = false;
                PrintButton.Enabled = false;
                ShowBooksButton.Enabled = false;
                ExitButton.Enabled = false;

                dataGridView1.AllowUserToAddRows = true;

                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                dataGridView1.ClearSelection();

                dataGridView1.CurrentCell = dataGridView1["Tytuł podserii", dataGridView1.Rows.Count - 1];

                dataGridView1.Focus();

                if (dataGridView1.Rows.Count > 1)
                    dataGridView1.AllowUserToAddRows = false;

                if (dataGridView1.Rows.Count > 0)
                    dataGridView1.CurrentCell = dataGridView1["Tytuł podserii", dataGridView1.Rows.Count - 1];
            }
            else if (AddButton.Text == "Zapisz")
            {
                //int Codes = GetIDFromProcedure("serie");

                //if (Codes != -1)
                //{
                    try
                    {
                        OdbcCommand Command = new OdbcCommand();
                        Command.Connection = NewConnection.AppConnection;

                        Command.CommandText = "INSERT INTO " + this.Table + " (tyt_pserii, pissn, nazwa_pcz, numer_pcz) " +
                                              "VALUES (?, ?, ?, ?)";
                        //Command.Parameters.AddWithValue("@ID", Codes);
                        Command.Parameters.AddWithValue("@Title", dataGridView1["Tytuł podserii", dataGridView1.CurrentRow.Index].Value.ToString());
                        Command.Parameters.AddWithValue("@ISSN", dataGridView1["ISSN", dataGridView1.CurrentRow.Index].Value.ToString());
                        Command.Parameters.AddWithValue("@Inst", dataGridView1["Nazwa części", dataGridView1.CurrentRow.Index].Value.ToString());
                        Command.Parameters.AddWithValue("@Inst", dataGridView1["Numer części", dataGridView1.CurrentRow.Index].Value.ToString());
                        //Command.Parameters.AddWithValue("@IDRodzaj", Int32.Parse(dataGridView1["Księgozbiór", dataGridView1.CurrentRow.Index].Value.ToString()));

                        Command.ExecuteNonQuery();

                        MessageBox.Show("Dodano!");

                        AddButton.Text = "Dodaj";
                        MergeButton.Text = "Połącz";

                        DelButton.Enabled = true;
                        PrintButton.Enabled = true;
                        ShowBooksButton.Enabled = true;
                        ExitButton.Enabled = true;

                        //SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
                        SelectFromDb();
                        dataGridView1.Update();
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                        dataGridView1.CurrentCell = dataGridView1["ID podserii", dataGridView1.Rows.Count - 1];

                        dataGridView1.AllowUserToAddRows = false;

                        dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.CornflowerBlue;
                    }
                    catch (Exception Ex)
                    {
                        dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Red;

                        MessageBox.Show(Ex.Message);
                    }
                //}
                //else
                //{
                //    MessageBox.Show("Błąd uzyskania ID!");
                //}
            }
        }

        /*private DataTable ReturnDataTable()
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.coliberConnection = NewConnection.AppConnection;
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
        }*/
        /*
        private List<string> ReturnIDRodzajList(DataTable Dt)
        {
            try
            {
                List<string> List = new List<string>();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    List.Add(Dt.Rows[i][1].ToString());
                }

                return List;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return null;
        }*/
        /*
        private void SetIDRodzajListToComboBox(List<string> List)
        {
            IDRodzajComboBox.DataSource = List;
        }*/
        /*
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
        }*/
        /*
        private void IDRodzajComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
        }*/

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (AddButton.Text != "Zapisz")
            {
                /*//if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["Księgozbiór"].Index)
                //{
                    try
                    {
                        //klucze_a
                        OdbcCommand ChangeCommand = new OdbcCommand();
                        ChangeCommand.coliberConnection = NewConnection.AppConnection;
                        ChangeCommand.CommandText = "UPDATE " + this.Table + " SET id_rodzaj = ? " +
                                                    "WHERE kody = ?";
                        ChangeCommand.Parameters.AddWithValue("@IDRodzaj", Int32.Parse(dataGridView1["Księgozbiór", dataGridView1.CurrentRow.Index].Value.ToString()));
                        ChangeCommand.Parameters.AddWithValue("@Codes", Int32.Parse(dataGridView1["ID podserii", dataGridView1.CurrentRow.Index].Value.ToString()));

                        ChangeCommand.ExecuteNonQuery();

                        ChangeCommand.Dispose();

                        dataGridView1.CurrentCell.Style.BackColor = Color.LightGreen;
                    }
                    catch (Exception Ex)
                    {
                        dataGridView1.CurrentCell.Style.BackColor = Color.Red;

                        MessageBox.Show(Ex.Message);
                    }*/
                //}
                //else
                //{
                    try
                    {
                        //podserie
                        OdbcCommand ChangeCommand = new OdbcCommand();
                        ChangeCommand.Connection = NewConnection.AppConnection;
                        ChangeCommand.CommandText = "UPDATE " + this.Table + " SET tyt_pserii = ?, pissn = ?, nazwa_pcz = ?, numer_pcz = ? WHERE id_podser = ?";
                        ChangeCommand.Parameters.AddWithValue("@Title", dataGridView1["Tytuł podserii", dataGridView1.CurrentRow.Index].Value.ToString());
                        ChangeCommand.Parameters.AddWithValue("@ISSN", dataGridView1["ISSN", dataGridView1.CurrentRow.Index].Value.ToString());
                        ChangeCommand.Parameters.AddWithValue("@Name", dataGridView1["Nazwa części", dataGridView1.CurrentRow.Index].Value.ToString());
                        ChangeCommand.Parameters.AddWithValue("@Number", dataGridView1["Numer części", dataGridView1.CurrentRow.Index].Value.ToString());
                        ChangeCommand.Parameters.AddWithValue("@ID", Int32.Parse(dataGridView1["ID podserii", dataGridView1.CurrentRow.Index].Value.ToString()));

                        ChangeCommand.ExecuteNonQuery();

                        dataGridView1.CurrentCell.Style.BackColor = Color.LightGreen;
                    }
                    catch (Exception Ex)
                    {
                        dataGridView1.CurrentCell.Style.BackColor = Color.Red;

                        MessageBox.Show(Ex.Message);
                    }
                //}
            }
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            if (MergeButton.Text == "Anuluj")
            {
                AddButton.Text = "Dodaj";
                MergeButton.Text = "Połącz";

                DelButton.Enabled = true;
                PrintButton.Enabled = true;
                ShowBooksButton.Enabled = true;
                ExitButton.Enabled = true;

                //SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
                SelectFromDb();
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Update();

                if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow.Index > 0)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;

                    dataGridView1["Tytuł podserii", dataGridView1.Rows.Count - 1].Selected = true;
                }
            }
            else if (MergeButton.Text == "Połącz" && dataGridView1.Rows.Count > 0)
            {
                try
                {
                    OdbcCommand Command = new OdbcCommand();
                    Command.Connection = NewConnection.AppConnection;
                    Command.CommandText = "SELECT id_podser AS [ID podserii], kod AS [Kod], LTRIM(RTRIM(tyt_pserii)) AS [Tytuł podserii], LTRIM(RTRIM(pissn)) AS [ISSN], LTRIM(RTRIM(nazwa_pcz)) AS [Nazwa części], LTRIM(RTRIM(numer_pcz)) AS [Numer części] FROM " + this.Table + " " +
                                          "WHERE id_podser != ?";
                    Command.Parameters.AddWithValue("@ID", Int32.Parse(dataGridView1["ID podserii", dataGridView1.CurrentRow.Index].Value.ToString()));

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
                            if (Int32.Parse(dataGridView1["ID podserii", i].Value.ToString()) == ID)
                            {
                                Row = i;
                                break;
                            }
                        }

                        if (MessageBox.Show("Połączyć \"" + dataGridView1["Tytuł podserii", dataGridView1.CurrentRow.Index].Value.ToString() + "\" z \"" + dataGridView1["Tytuł podserii", Row].Value.ToString() + "\"?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            OdbcCommand MergeCommand = new OdbcCommand();
                            MergeCommand.Connection = NewConnection.AppConnection;

                            MergeCommand.CommandText = "UPDATE " + this.Table + " " +
                                                       "SET kod = ? " +
                                                       "WHERE id_podser = ?";
                            //MergeCommand.Parameters.AddWithValue("@Title", dataGridView1["Tytuł podserii", dataGridView1.CurrentRow.Index].Value.ToString());
                            //MergeCommand.Parameters.AddWithValue("@ISSN", dataGridView1["ISSN", dataGridView1.CurrentRow.Index].Value.ToString());
                            //MergeCommand.Parameters.AddWithValue("@Name", dataGridView1["nazwa_pcz", dataGridView1.CurrentRow.Index].Value.ToString());
                            MergeCommand.Parameters.AddWithValue("@Number", dataGridView1["Kod", dataGridView1.CurrentRow.Index].Value.ToString());
                            MergeCommand.Parameters.AddWithValue("@ID", Int32.Parse(dataGridView1["ID podserii", Row].Value.ToString()));

                            MergeCommand.ExecuteNonQuery();
                            MessageBox.Show("Wykonano!");
                            //DeleteSeries(Int32.Parse(dataGridView1["ID podserii", Row].Value.ToString()));
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["Księgozbiór"].Index)
            {
                //DataGridViewComboBoxCell IDRodzajColumn = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells["id_rodzaj"];
                //if (MessageBox.Show("Zmienić księgozbiór? ", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                //{
                    Rodzaje RodzajeForm = new Rodzaje(NewConnection);
                    if (RodzajeForm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                        dataGridView1.CurrentCell.Value = RodzajeForm.rodzaj;
                //}
            }*/
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (CountTextBox.TextLength > 0 && Int32.Parse(CountTextBox.Text) > 0)
                {
                    if (MessageBox.Show("Wyświetlić zasoby \"" + dataGridView1["Tytuł podserii", dataGridView1.CurrentRow.Index].Value.ToString() + "\"?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ShowList ShowListForm = new ShowList(GetListWhereSeriesOccured(Int32.Parse(dataGridView1["ID podserii", dataGridView1.CurrentRow.Index].Value.ToString())), dataGridView1["Tytuł podserii", dataGridView1.CurrentRow.Index].Value.ToString());
                        ShowListForm.ShowDialog();
                    }
                }
                if (MessageBox.Show("Usunąć " + dataGridView1["Tytuł podserii", dataGridView1.CurrentRow.Index].Value.ToString() + "?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //if (DeleteSeriesFrom())
                        DeleteSeries(Int32.Parse(dataGridView1["ID podserii", dataGridView1.CurrentRow.Index].Value.ToString()));
                }
            }
        }

        private void DeleteSeries(int Codes)
        {
            try
            {
                int FirstDisplayedRow = dataGridView1.FirstDisplayedScrollingRowIndex;
                int CurrentRow = dataGridView1.CurrentRow.Index;

                OdbcCommand DeleteCommand = new OdbcCommand();
                DeleteCommand.Connection = NewConnection.AppConnection;

                DeleteCommand.CommandText = "DELETE FROM " + this.Table + " WHERE id_podser = ?";
                DeleteCommand.Parameters.AddWithValue("@ID", Codes);

                DeleteCommand.ExecuteNonQuery();

                MessageBox.Show("Wykonano!");

                //SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
                SelectFromDb();
                if (dataGridView1.Rows.Count > 0)
                {
                    if (CurrentRow > dataGridView1.CurrentRow.Index)
                        CurrentRow--;

                    dataGridView1.CurrentCell = dataGridView1["ID podserii", CurrentRow];
                    dataGridView1.FirstDisplayedScrollingRowIndex = FirstDisplayedRow;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        /*private bool DeleteSeriesFrom()
        {
            try
            {
                OdbcCommand DeleteCommand = new OdbcCommand();
                DeleteCommand.coliberConnection = NewConnection.AppConnection;

                DeleteCommand.CommandText = "DELETE FROM dbo.ksi_ser WHERE kody = ?";
                DeleteCommand.Parameters.AddWithValue("@Codes", Int32.Parse(dataGridView1["ID podserii", dataGridView1.CurrentRow.Index].Value.ToString()));

                DeleteCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return false;
            }
        }*/

        private void PrintButton_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcCommand ReportCommand = new OdbcCommand();
                ReportCommand.Connection = NewConnection.AppConnection;

                ReportCommand.CommandText = "SELECT " +
                                               "LTRIM(RTRIM(tyt_pserii)) as tyt, " +
                                               "LTRIM(RTRIM(pissn)) as pissn " +
                                            "FROM [coliber_1do].[dbo].[podserie] ORDER BY tyt_pserii, pissn ";

                ShowReport Report = new ShowReport(ReportCommand, "SubSeriesReport");

                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                Report.ShowDialog();

                Wait.Dispose();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        /*private int GetIDFromProcedure(string Table)
        {
            /*  ------------------------------------------------------------------------------ 
              WYŁĄCZONA Z UŻYTKOWANIA
              Prototyp: GetIdFromProcedure()

              Przeznaczenie: Pobiera kolejne id dla tabeli dbo.login. (Korzysta w procedury w bazie.)

              Argumenty: Brak.

              Wartosc zwracana: double id

              Autor: Krzysztof Rybka

              Data: 06.01.2013
              ------------------------------------------------------------------------------*/

           /* int ID = -1;

            try
            {
                SqlCommand Command = new SqlCommand();
                Command.coliberConnection = new SqlConnection("Server = " + NewConnection.AppConnection.DataSource.ToString() + "; Database = " + NewConnection.AppConnection.Database.ToString() + "; Trusted_Connection = True;");
                Command.coliberConnection.Open();
                Command.CommandText = "NextVal";
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@stabela", Table);
                Command.Parameters.AddWithValue("@nincrement", 1);

                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                    ID = Int32.Parse(Reader.GetValue(0).ToString());

                Reader.Close();
                Command.coliberConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return ID;
        }*/

        /*private int GetIDRodzaj(string RodzajName)
        {
            int ID = 1;

            OdbcCommand Command = new OdbcCommand();
            Command.coliberConnection = NewConnection.AppConnection;
            Command.CommandText = "SELECT id_rodzaj FROM dbo.rodzaje WHERE LTRIM(RTRIM(nazwa)) = ?";
            Command.Parameters.AddWithValue("RodzajName", RodzajName);

            OdbcDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
                ID = Int32.Parse(Reader.GetValue(0).ToString());

            return ID;
        }*/
    }
}
