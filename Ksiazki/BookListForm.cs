using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace Ksiazki
{
    public partial class BookListForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        public enum ModeEnum { Edit, Delete };
        private ModeEnum CurrentMode;

        private int id_rodzaj;
        public BookListForm(int id_rodzaj, ModeEnum Mode, string employeeID)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            Settings.SetSettings(id_rodzaj);

            Settings.employeeID = employeeID;

            this.id_rodzaj = id_rodzaj;

            this.CurrentMode = Mode;

            if (Mode == ModeEnum.Edit)
                this.Text = _T("books_modification");
            else
                this.Text = _T("books_deleting");

            if (label2.Text.Substring(label2.Text.Length - 1, 1) != ":") label2.Text = label2.Text + ":";
            if (label3.Text.Substring(label3.Text.Length - 1, 1) != ":") label3.Text = label3.Text + ":";
            if (label4.Text.Substring(label4.Text.Length - 1, 1) != ":") label4.Text = label4.Text + ":";
            if (label5.Text.Substring(label5.Text.Length - 1, 1) != ":") label5.Text = label5.Text + ":";

        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "books_modification");
            mapping.Add(ExitButton, "exit");
            mapping.Add(TitleButton, "list_of_titles");
            mapping.Add(SygButton, "list_of_signatures");
            mapping.Add(NumInwButton, "list_of_inventory_numbers");
            mapping.Add(label5, "title");
            mapping.Add(label4, "signature_001");
            mapping.Add(label3, "inventory_number");
            mapping.Add(label2, "barcode");
            mapping.Add(label1, "find_desc_using");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BookListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void NumInwButton_Click(object sender, EventArgs e)
        {
            Search(NumInwTextBox.Text.Trim(), 3);
        }

        private void SygButton_Click(object sender, EventArgs e)
        {
            Search(SygTextBox.Text.Trim(), 2);
        }

        private void TitleButton_Click(object sender, EventArgs e)
        {
            Search(TitleTextBox.Text.Trim(), 1);
        }

        private void NumInwTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                Search(NumInwTextBox.Text.Trim(), 3);
        }

        private void SygTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(SygTextBox.Text.Trim(), 2);
        }

        private void TitleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(TitleTextBox.Text.Trim(), 1);
        }

        private void Search(string SearchText, int SearchField)
        {
            SqlCommand Command = new SqlCommand("EXEC Ksiazki_BookList @sort, @id_rodzaj, @searchField, @searchText;");
            Command.Parameters.AddWithValue("@sort", SearchField);
            Command.Parameters.AddWithValue("@id_rodzaj", id_rodzaj);//Settings.ID_rodzaj);

            if (!string.IsNullOrEmpty(SearchText))
                Command.Parameters.AddWithValue("@searchField", SearchField);
            else
                Command.Parameters.AddWithValue("@searchField", DBNull.Value);

            Command.Parameters.AddWithValue("@searchText", SearchText + "%");

            DataGridViewColumn[] Columns = new DataGridViewColumn[7];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "kod";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "syg";
            Columns[1].Name = "syg";
            Columns[1].HeaderText = _T("signature");
            Columns[1].Width = 120;
            Columns[1].Visible = SearchField == 1 || SearchField == 2;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "numer_inw";
            Columns[2].Name = "numer_inw";
            Columns[2].HeaderText = _T("inventory_number");
            Columns[2].Width = 120;
            //Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Columns[2].Visible = SearchField == 3;

            Columns[3] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[3].DataPropertyName = "tytul";
            Columns[3].Name = "tytul";
            Columns[3].HeaderText = _T("book_title");
            Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[4] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[4].DataPropertyName = "k_kreskowy";
            Columns[4].Name = "k_kreskowy";
            Columns[4].HeaderText = _T("barcode");
            Columns[4].Width = 100;
            //Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            Columns[5] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[5].DataPropertyName = "kod_tomy";
            Columns[5].Name = "kod_tomy";
            Columns[5].Visible = false;

            Columns[6] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[6].DataPropertyName = "id_rodzaj";
            Columns[6].Name = "id_rodzaj";
            Columns[6].Visible = false;

            string SearchColumnName;

            if (SearchField == 1)
                SearchColumnName = "tytul";
            else if (SearchField == 2)
                SearchColumnName = "syg";
            else
                SearchColumnName = "numer_inw";

            ShowForm Formka = new ShowForm(Command, Columns, false, SearchColumnName, CurrentMode, "K");

                //Command, Columns, false, SearchColumnName, CurrentMode);
            Formka.Text = _T("select_001");

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Int32.TryParse(Formka.Dt.Cells["id_rodzaj"].Value.ToString(), out Settings.ID_rodzaj);

                OpenBooks(Formka.Dt.Cells["id"].Value.ToString(), Formka.Dt.Cells["kod_tomy"].Value.ToString());

                BarCodeTextBox.ResetText();
                NumInwTextBox.ResetText();
                SygTextBox.ResetText();
                TitleTextBox.ResetText();
            }
        }

        private void OpenBooks(string ID, string TomeID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                if (!string.IsNullOrEmpty(TomeID))
                {
                    if (CurrentMode == ModeEnum.Edit)
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
                    if (CurrentMode == ModeEnum.Edit)
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

        private void BarCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(BarCodeTextBox.Text.Trim().Length > 0 && BarCodeTextBox.Text.Trim() != "0")
                    SearchByBarCode(BarCodeTextBox.Text.Trim());

                BarCodeTextBox.Text = "";
            }
        }

        private void BarCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < BarCodeTextBox.TextLength; i++)
            {
                if (!char.IsDigit(BarCodeTextBox.Text[i]))
                {
                    BarCodeTextBox.Text = BarCodeTextBox.Text.Remove(i, 1);
                    BarCodeTextBox.SelectionStart = BarCodeTextBox.TextLength;
                }
            }
        }

        private void SearchByBarCode(string SearchText)
        {
            SqlCommand Command = new SqlCommand("EXEC FindBookByBarCode @searchText, @id_rodzaj;");
            Command.Parameters.AddWithValue("@searchText", SearchText);
            Command.Parameters.AddWithValue("@id_rodzaj", id_rodzaj/*Settings.ID_rodzaj*/);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {
                Int32.TryParse(Dt.Rows[0]["id_rodzaj"].ToString(), out Settings.ID_rodzaj);

                OpenBooks(Dt.Rows[0]["kod"].ToString(), Dt.Rows[0]["kod_tomy"].ToString());
            }
            else
                MessageBox.Show(_T("not_found"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
