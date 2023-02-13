using System;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Threading;
using System.Collections.Generic;

namespace Ksiazki
{
    public partial class ShowForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        public string First;
        public string Second;
        public string ID;
        private string Column1;
        private string Column2;
        private string SearchText;
        private string SearchColumnName;
        private DataTable Table;
        private BookListForm.ModeEnum CurrentMode;
        private string cTryb = "";

        private SqlCommand Command;

        public DataGridViewRow Dt;

        public ShowForm()
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            ClearSearch();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "");
            mapping.Add(ExitButton, "exit");
            mapping.Add(label1, "sort_001");
            mapping.Add(SygRadioButton, "signature_genitive");
            mapping.Add(TitleRadioButton, "title_genitive");
            mapping.Add(SelectButton, "select_001");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        public ShowForm(SqlCommand Command, string Column1, string Column2, bool SortOptionVisible = false, string SearchColumnName = null)
            : this()
        {            
            this.Column1 = Column1;
            this.Column2 = Column2;

            this.SearchColumnName = SearchColumnName;

            SQLGetDataFromDb(Command);            
        }

        public ShowForm(SqlCommand Command, DataGridViewColumn[] ColumnsDefinition, bool SortOptionVisible = false, string SearchColumnName = null, BookListForm.ModeEnum iMode = BookListForm.ModeEnum.Edit, string tryb = "") : this()
        {
            cTryb = tryb;
            CurrentMode = iMode;
            TitleRadioButton.Visible = SortOptionVisible;
            SygRadioButton.Visible = SortOptionVisible;
            label1.Visible = SortOptionVisible;

            dataGridView1.AutoGenerateColumns = false;

            for (int i = 0; i < ColumnsDefinition.Length; i++)
            {
                dataGridView1.Columns.Add(ColumnsDefinition[i]);
            }

            this.Command = Command;

            this.SearchColumnName = SearchColumnName;

            SQLGetDataFromDb(Command);
            btEdit.Visible = cTryb == "P" && CurrentMode == BookListForm.ModeEnum.Edit ;
            if (cTryb == "K" && CurrentMode == BookListForm.ModeEnum.Edit) SelectButton.DialogResult = DialogResult.None;
        }

        //WYCZYSZCZENIE LABELA SZUKANIA
        private void ClearSearch()
        {
            SearchText = "";
            SearchLabel.Text = SearchText;
        }

        private void SQLGetDataFromDb(SqlCommand Command)
        {
            try
            {
                Table = CommonFunctions.ReadData(Command, ref Settings.Connection);
                dataGridView1.DataSource = Table;

                if (dataGridView1.Columns.Contains("id"))
                    dataGridView1.Columns["id"].Visible = false;

                if (!string.IsNullOrEmpty(this.Column1))
                    dataGridView1.Columns[Column1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!string.IsNullOrEmpty(this.Column2))
                    dataGridView1.Columns[Column2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Focus();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (cTryb == "K" && CurrentMode == BookListForm.ModeEnum.Edit)
            {
                Dt = dataGridView1.CurrentRow;
                OpenBooks(Dt.Cells["id"].Value.ToString(), Dt.Cells["kod_tomy"].Value.ToString());
                return;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (Column1 != null && dataGridView1.Columns.Contains(Column1))
                    this.First = dataGridView1[Column1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                if (Column1 != null && dataGridView1.Columns.Contains(Column2))
                    this.Second = dataGridView1[Column2, dataGridView1.CurrentCell.RowIndex].Value.ToString();

                if (dataGridView1.Columns.Contains("id") && dataGridView1.SelectedRows.Count > 0)
                    ID = dataGridView1["id", dataGridView1.CurrentCell.RowIndex].Value.ToString();

                Dt = dataGridView1.CurrentRow;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                this.DialogResult = System.Windows.Forms.DialogResult.No;

            this.Close();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            {
                SearchText += e.KeyChar.ToString();
                SearchLabel.Text = SearchText;
            }

            //WYSZUKANIE WG WPISANEGO TEKSTU
            if (string.IsNullOrEmpty(SearchColumnName))
            {
                bool BreakLoop = false;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    /*if ((dataGridView1.Columns.Contains("id") && dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower().StartsWith(SearchText.ToLower())) || 
                        (dataGridView1.Columns.Contains("syg") && dataGridView1.Rows[i].Cells["syg"].Value.ToString().ToLower().StartsWith(SearchText.ToLower())) || 
                        (dataGridView1.Columns.Contains("numer_inw") && dataGridView1.Rows[i].Cells["numer_inw"].Value.ToString().ToLower().StartsWith(SearchText.ToLower())) || 
                        (dataGridView1.Columns.Contains("tytul") && dataGridView1.Rows[i].Cells["tytul"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                        
                        )
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;

                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Columns[j].Visible == true)
                            {
                                dataGridView1.CurrentCell = dataGridView1[j, i];
                                break;
                            }
                        }
                        
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }*/

                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Visible && dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                        {
                            dataGridView1.ClearSelection();
                            dataGridView1.Rows[i].Selected = true;

                            dataGridView1.CurrentCell = dataGridView1[j, i];

                            dataGridView1.FirstDisplayedScrollingRowIndex = i;

                            BreakLoop = true;
                            break;
                        }
                    }

                    if(BreakLoop)
                        break;                    
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[SearchColumnName].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[SearchColumnName, i];
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                ClearSearch();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ClearSearch();
                SelectButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                SelectButton_Click(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearSearch();
        }

        private void TitleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TitleRadioButton.Checked)
            {
                Command.Parameters["@sort"].Value = 1;
                SQLGetDataFromDb(Command);
            }
        }

        private void SygRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SygRadioButton.Checked)
            {
                Command.Parameters["@sort"].Value = 2;
                SQLGetDataFromDb(Command);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                decimal Id = (decimal)dataGridView1.CurrentRow.Cells[0].Value;
                string cNazwa = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string cOld = cNazwa;
                if (Coliber.App.InputBox("Modyfikacja danych wydawcy", "Nazwa wydawcy:", ref cNazwa) != DialogResult.OK) return;
                if (cNazwa == cOld) return;
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC ModifyPublisher @p_nazwa,@p_nazwa_krotka,@p_id_panstwa," +
                    "@p_miasto,@p_kontakt,@p_adres,@p_odsylacz,@p_rodzaj_wydawcy,@p_id_rodzaj,@p_id_wydawcy,@p_typ_wydawcy,@p_mode";
                Command.Parameters.AddWithValue("@p_nazwa", cNazwa);
                Command.Parameters.AddWithValue("@p_nazwa_krotka", "");
                Command.Parameters.AddWithValue("@p_id_panstwa", "");
                Command.Parameters.AddWithValue("@p_miasto", "");
                Command.Parameters.AddWithValue("@p_kontakt", "");
                Command.Parameters.AddWithValue("@p_adres", "");
                Command.Parameters.AddWithValue("@p_odsylacz", 0);
                Command.Parameters.AddWithValue("@p_rodzaj_wydawcy", "");
                Command.Parameters.AddWithValue("@p_id_rodzaj", 0);
                Command.Parameters.AddWithValue("@p_id_wydawcy", Id);
                Command.Parameters.AddWithValue("@p_typ_wydawcy", "");
                Command.Parameters.AddWithValue("@p_mode", 4);
                if (CommonFunctions.WriteData(Command, ref Settings.Connection))
                {
                    dataGridView1.ReadOnly = false;
                    dataGridView1.Columns["Nazwa_w"].ReadOnly = false;
                    dataGridView1.BeginEdit(true);
                    dataGridView1.CurrentRow.Cells[1].Value = cNazwa;
                    dataGridView1.EndEdit();
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.ReadOnly = true;
                }
        }

        private void OpenBooks(string ID, string TomeID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                if (!string.IsNullOrEmpty(TomeID))
                {
                    if (CurrentMode == BookListForm.ModeEnum.Edit)
                    {
                        DetailsForm DF = new DetailsForm(TomeID, ID, Settings.employeeID);
                        //DF.ShowDialog();
                        DF.MdiParent = this.MdiParent;
                        DF.Show();
                    }
                    else
                    {
                        DetailsForm DF = new DetailsForm(TomeID, ID, Settings.employeeID, true);
                        //DF.ShowDialog();
                        DF.MdiParent = this.MdiParent;
                        DF.Show();
                    }
                }
                else
                {
                    if (CurrentMode == BookListForm.ModeEnum.Edit)
                    {
                        DetailsForm DF = new DetailsForm(Settings.ID_rodzaj, ID, Settings.employeeID);
                        //DF.ShowDialog();
                        DF.MdiParent = this.MdiParent;
                        DF.Show();
                    }
                    else
                    {
                        DetailsForm DF = new DetailsForm(Settings.ID_rodzaj, ID, Settings.employeeID, true);
                        //DF.ShowDialog();
                        DF.MdiParent = this.MdiParent;
                        DF.Show();
                    }
                }
            }
        }

    }
}
