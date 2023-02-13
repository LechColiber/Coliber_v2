using System.Threading;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Ubytki
{
    public partial class UbytkiForm : Form
    {
        public enum KindEnum
        {
            Book, Magazine
        }

        private enum ModeEnum
        {
            Edit, None
        }

        private KindEnum CurrentKind;
        private ModeEnum CurrentMode;
        private int CurrentSort;
        private int CurrentFoundIndex;
        private Dictionary<string, string> _translationsDictionary;

        public UbytkiForm(int id_rodzaj, KindEnum Kind)
        {
            Settings.SetSettings(id_rodzaj);

            InitializeComponent();

            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            CurrentKind = Kind;
            CurrentMode = ModeEnum.None;

            SetControls(false);
            GenerateWykrComboBoxValues();

            CurrentSort = 1;
            CurrentFoundIndex = 0;

            FetchUbytki(CurrentSort);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(TitleDGV, "title");
            mapping.Add(SygDGV, "signature");
            mapping.Add(NumInwDGV, "inventory_number");

            mapping.Add(EditButton, "edit");
            mapping.Add(DeleteButton, "delete");
            mapping.Add(PrintButton, "print");
            mapping.Add(SaveButton, "save");
            mapping.Add(CancButton, "cancel");

            mapping.Add(signatureLabel, "signature");
            mapping.Add(titleLabel, "title");
            mapping.Add(WoluminLabel, "volume_year");
            mapping.Add(invertoryNumberLabel, "inventory_number");
            mapping.Add(NumbersLabel, "numbers");
            mapping.Add(lossesBookNumberLabel, "losses_book_number");
            mapping.Add(lossDocumentNumberLabel, "losses_document_number");
            mapping.Add(priceLabel, "price");
            mapping.Add(entryDateLabel, "entry_date");
            mapping.Add(commentsLabel, "comments");
            mapping.Add(reasonLabel, "deletion_reason");

            mapping.Add(titleSearchLabel, "title");
            mapping.Add(signatureSearchLabel, "signature");
            mapping.Add(invertoryNumberSearchLabel, "inventory_number");
            mapping.Add(SearchCheckBox, "entry_date");
            mapping.Add(sinceDateLabel, "since_date");
            mapping.Add(toDateLabel, "to_date");

            mapping.Add(SearchButton, "search");
            mapping.Add(NextSearchButton, "next");
            mapping.Add(PreviousSearchButton, "previous");
            mapping.Add(CleanSearchButton, "to_clean");

            mapping.Add(ExitButton, "exit");
            mapping.Add(this, "losses_book");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void GenerateWykrComboBoxValues()
        {
            Dictionary<int, string> WykrComboBoxValues = new Dictionary<int, string>();

            WykrComboBoxValues.Add(1, _translationsDictionary.ContainsKey("unreturned") ? _translationsDictionary["unreturned"] : "Niezwrócone ");
            WykrComboBoxValues.Add(2, _translationsDictionary.ContainsKey("destroyed") ? _translationsDictionary["destroyed"] : "Zniszczone");
            WykrComboBoxValues.Add(3, _translationsDictionary.ContainsKey("withdrawn") ? _translationsDictionary["withdrawn"] : "Wycofane");
            WykrComboBoxValues.Add(4, _translationsDictionary.ContainsKey("lost") ? _translationsDictionary["lost"] : "Zagubione");
            WykrComboBoxValues.Add(5, _translationsDictionary.ContainsKey("other_unreasonable") ? _translationsDictionary["other_unreasonable"] : "Inne nieuzasadnione");

            WykrComboBox.DataSource = new BindingSource(WykrComboBoxValues, null);
            WykrComboBox.DisplayMember = "Value";
            WykrComboBox.ValueMember = "Key";
        }

        private void SetControls(bool Enabled)
        {
            if (CurrentKind == KindEnum.Book)
            {
                NumbersLabel.Visible = false;
                NumbersTextBox.Visible = false;

                WoluminLabel.Visible = false;
                WoluminTextBox.Visible = false;

                YearLabel.Visible = false;
                YearTextBox.Visible = false;
            }

            SygnaturaTextBox.ReadOnly = !Enabled;
            TitleRichTextBox.ReadOnly = !Enabled;
            WoluminTextBox.ReadOnly = !Enabled;
            YearTextBox.ReadOnly = !Enabled;
            NumerInwTextBox.ReadOnly = !Enabled;
            NumbersTextBox.ReadOnly = !Enabled;
            NrKsiegiTextBox.ReadOnly = !Enabled;
            NumerDowoduTextBox.ReadOnly = !Enabled;
            PriceTextBox.ReadOnly = !Enabled;
            DateDTP.Enabled = Enabled;
            CommentsRichTextBox.ReadOnly = !Enabled;
            WykrComboBox.Enabled = Enabled;            

            if (Enabled)
            {
                TitleRichTextBox.BackColor = Color.FromKnownColor(KnownColor.White);
                CommentsRichTextBox.BackColor = Color.FromKnownColor(KnownColor.White);
            }
            else
            {
                TitleRichTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
                CommentsRichTextBox.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void UbytkiDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (UbytkiDGV.SelectedRows.Count == 0 ||  (UbytkiDGV.SelectedRows.Count > 0 && UbytkiDGV.SelectedRows[0].Index < 0))
            {
                EditButton.Enabled = false;
                DeleteButton.Enabled = false;
            }
            else
            {
                EditButton.Enabled = true;
                DeleteButton.Enabled = true;

                FillControls(FetchFillUbytki());
            }
        }

        private void FetchUbytki(int Sort)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ubytki_Select @type, @sort, @id_rodzaj, @tytul, @syg, @numer_inw, @search_by_date, @start_date, @end_date;";

            if (CurrentKind == KindEnum.Book)
                Command.Parameters.AddWithValue("@type", 1);
            else
                Command.Parameters.AddWithValue("@type", 2);

            Command.Parameters.AddWithValue("@sort", Sort);
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
            Command.Parameters.AddWithValue("@tytul", TitleSearchTextBox.Text.Trim());

            Command.Parameters.AddWithValue("@syg", SygSearchTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@numer_inw", NumerInwSearchTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@search_by_date", SearchCheckBox.Checked);

            Command.Parameters.AddWithValue("@start_date", startDateSearchDTP.Value.ToString("yyyyMMdd"));
            Command.Parameters.AddWithValue("@end_date", endDateSearchDTP.Value.ToString("yyyyMMdd"));

            UbytkiDGV.DataSource = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (UbytkiDGV.Rows.Count == 0)
            {
                EditButton.Enabled = false;
                DeleteButton.Enabled = false;
            }
        }

        private DataRow FetchFillUbytki()
        {
            DataTable Dt = new DataTable();

            try
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Ubytki_SelectFill @id, @type;";
                Command.Parameters.AddWithValue("@id", UbytkiDGV.SelectedRows[0].Cells["id"].Value.ToString());

                if (CurrentKind == KindEnum.Book)
                    Command.Parameters.AddWithValue("@type", 1);
                else
                    Command.Parameters.AddWithValue("@type", 2);

                Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return Dt.Rows.Count > 0 ? Dt.Rows[0] : null;
        }

        private void FillControls(DataRow Dr)
        {
            if (Dr != null)
            {
                SygnaturaTextBox.Text = (Dr["syg"] != null) ? Dr["syg"].ToString() : "";
                TitleRichTextBox.Text = (Dr["tytul"] != null) ? Dr["tytul"].ToString() : "";
                NumerInwTextBox.Text = (Dr["numer_inw"] != null) ? Dr["numer_inw"].ToString() : "";
                NrKsiegiTextBox.Text = (Dr["nr_ksiegi"] != null) ? Dr["nr_ksiegi"].ToString() : "";
                NumerDowoduTextBox.Text = (Dr["nr_dowodu"] != null) ? Dr["nr_dowodu"].ToString() : "";
                PriceTextBox.Text = (Dr["cena"] != null) ? Dr["cena"].ToString() : "";                                

                if (Dr["data_ubyt"].ToString() != "")
                {
                    DateTime Date;
                    DateTime.TryParse(Dr["data_ubyt"].ToString(), out Date);
                    DateDTP.Value = Date;
                }

                CommentsRichTextBox.Text = (Dr["uwagi"] != null) ? Dr["uwagi"].ToString() : "";
                WykrComboBox.SelectedValue = (Dr["przyczyna"] != null) ? Int32.Parse(Dr["przyczyna"].ToString()) : 0;

                if (CurrentKind == KindEnum.Magazine)
                {
                    WoluminTextBox.Text = (Dr["wolumin"] != null) ? Dr["wolumin"].ToString() : "";                    
                    NumbersTextBox.Text = (Dr["numery"] != null) ? Dr["numery"].ToString() : "";
                    YearTextBox.Text = (Dr["rok1"] != null) ? Dr["rok1"].ToString() : "";
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ChangeState(ModeEnum.Edit);
        }

        private void CancButton_Click(object sender, EventArgs e)
        {
            ChangeState(ModeEnum.None);
        }
       
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                ChangeState(ModeEnum.None);

                string ID = UbytkiDGV.SelectedRows[0].Cells["id"].Value.ToString();

                FetchUbytki(CurrentSort);

                for (int i = 0; i < UbytkiDGV.Rows.Count; i++)
                {
                    if (UbytkiDGV.Rows[i].Cells["id"].Value.ToString() == ID)
                    {
                        UbytkiDGV.Rows[i].Selected = true;
                        UbytkiDGV.Rows[i].Cells["TitleDGV"].Selected = true;

                        break;
                    }
                }
            }
        }

        private void ChangeState(ModeEnum State)
        {
            this.CurrentMode = State;

            if (State == ModeEnum.Edit)
            {
                SetControls(true);

                DeleteButton.Enabled = false;
                PrintButton.Enabled = false;
                EditButton.Enabled = false;

                SaveButton.Visible = true;
                CancButton.Visible = true;

                UbytkiDGV.Enabled = false;

                SearchButton.Enabled = false;
                NextSearchButton.Enabled = false;
                PreviousSearchButton.Enabled = false;
                CleanSearchButton.Enabled = false;

                TitleSearchTextBox.Enabled = false;
                SygSearchTextBox.Enabled = false;
                NumerInwSearchTextBox.Enabled = false;
                SearchCheckBox.Enabled = false;
            }
            else if (State == ModeEnum.None)
            { 
                DeleteButton.Enabled = true;
                PrintButton.Enabled = true;
                EditButton.Enabled = true;

                SaveButton.Visible = false;
                CancButton.Visible = false;

                UbytkiDGV.Enabled = true;

                SearchButton.Enabled = true;
                NextSearchButton.Enabled = true;
                PreviousSearchButton.Enabled = true;
                CleanSearchButton.Enabled = true;

                TitleSearchTextBox.Enabled = true;
                SygSearchTextBox.Enabled = true;
                NumerInwSearchTextBox.Enabled = true;
                SearchCheckBox.Enabled = true;

                SetControls(false);
                FillControls(FetchFillUbytki());
            }
        }

        private bool Save()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ubytki_Modify @id, @syg, @tytul, @volumin, @rok1, @numer_inw, @numery, @nr_ksiegi, @nr_dow, @cena, @data_ubyt, @uwagi_u, @przyczyna, @type;";

            Command.Parameters.AddWithValue("@id", UbytkiDGV.SelectedRows[0].Cells["id"].Value.ToString());
            Command.Parameters.AddWithValue("@syg", SygnaturaTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@tytul", TitleRichTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@volumin", WoluminTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@numer_inw", NumerInwTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@numery", NumbersTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@nr_ksiegi", NrKsiegiTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@nr_dow", NumerDowoduTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@cena", PriceTextBox.Text.Trim().Replace(",", "."));
            Command.Parameters.AddWithValue("@data_ubyt", DateDTP.Value.ToString("yyyyMMdd"));
            Command.Parameters.AddWithValue("@uwagi_u", CommentsRichTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@przyczyna", WykrComboBox.SelectedValue);

            if (CurrentKind == KindEnum.Book)
            { 
                Command.Parameters.AddWithValue("@type", 1);
                Command.Parameters.AddWithValue("@rok1", 0);
            }
            if (CurrentKind == KindEnum.Magazine)
            { 
                Command.Parameters.AddWithValue("@type", 2);
                Command.Parameters.AddWithValue("@rok1", YearTextBox.Text.Trim());
            }

            if (CommonFunctions.WriteData(Command, ref Settings.Connection))
            {
                string message = _translationsDictionary.ContainsKey("saved") ? _translationsDictionary["saved"] : "Zapisano";
                string caption = _translationsDictionary.ContainsKey("data_save") ? _translationsDictionary["data_save"] : "Zapis danych";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else 
                return false;
        }

        private void UbytkiDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.ColumnIndex == UbytkiDGV.Columns["NumInwDGV"].Index && CurrentSort != 1)
                {
                    FetchUbytki(1);
                    CurrentSort = 1;
                }
                else if (e.ColumnIndex == UbytkiDGV.Columns["SygDGV"].Index && CurrentSort != 2)
                {
                    FetchUbytki(2);
                    CurrentSort = 2;
                }
                else if (e.ColumnIndex == UbytkiDGV.Columns["TitleDGV"].Index && CurrentSort != 3)
                {
                    FetchUbytki(3);
                    CurrentSort = 3;
                }

                CurrentFoundIndex = 0;
            }            
        }

        private void PriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CurrencyDecimalSeparator = System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator;

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar.ToString() != CurrencyDecimalSeparator;// && e.KeyChar != ',';

            if (PriceTextBox.Text.Contains(CurrencyDecimalSeparator) && e.KeyChar.ToString() == CurrencyDecimalSeparator)
                e.Handled = true;

            if (!PriceTextBox.Text.Contains(CurrencyDecimalSeparator) && PriceTextBox.Text.Length >= 11 && char.IsDigit(e.KeyChar))
                e.Handled = true;

            if (PriceTextBox.Text.Contains(CurrencyDecimalSeparator))// && PriceTextBox.Text.Length >= 11 && char.IsDigit(e.KeyChar))
            {
                if (PriceTextBox.Text.Substring(PriceTextBox.Text.IndexOf(CurrencyDecimalSeparator)).Length >= 3 && char.IsDigit(e.KeyChar) && PriceTextBox.SelectionLength != PriceTextBox.TextLength)
                    e.Handled = true;
            }               
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UbytkiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentMode == ModeEnum.Edit)
            {
                string message = _translationsDictionary.ContainsKey("do_you_want_to_exit_without_save") ? _translationsDictionary["do_you_want_to_exit_without_save"] : "Czy opuścić okno bez zapisywania zmian?";
                string caption = _translationsDictionary.ContainsKey("losses") ? _translationsDictionary["losses"] : "Ubytki";

                if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void UbytkiForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string message = _translationsDictionary.ContainsKey("do_you_want_to_remove") ? _translationsDictionary["do_you_want_to_remove"] : "Czy na pewno usunąć wpis z księgi ubytków?";
            string caption = _translationsDictionary.ContainsKey("entry_deleting") ? _translationsDictionary["entry_deleting"] : "Usuwanie wpisu";

            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Ubytki_Delete @id, @type;";

                Command.Parameters.AddWithValue("@id", UbytkiDGV.SelectedRows[0].Cells["id"].Value.ToString());

                if (CurrentKind == KindEnum.Book)
                    Command.Parameters.AddWithValue("@type", 1);
                if (CurrentKind == KindEnum.Magazine)
                    Command.Parameters.AddWithValue("@type", 2);

                if (CommonFunctions.WriteData(Command, ref Settings.Connection))
                {
                    message = _translationsDictionary.ContainsKey("removed") ? _translationsDictionary["removed"] : "Usunięto wpis";
                    caption = _translationsDictionary.ContainsKey("entry_deleting") ? _translationsDictionary["entry_deleting"] : "Usuwanie wpisu";

                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FetchUbytki(CurrentSort);
                }
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (UbytkiDGV.Rows.Count == 0)
            {
                string message = _translationsDictionary.ContainsKey("no_results") ? _translationsDictionary["no_results"] : "Brak danych do raportu.";
                string caption = _translationsDictionary.ContainsKey("losses_report") ? _translationsDictionary["losses_report"] : "Raport ubytków";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            WaitForm WF = new WaitForm();

            this.Invoke((MethodInvoker)delegate
            {
                WF.Show(this);
                WF.Update();
            });

            if (CurrentKind == KindEnum.Book)
            {
                ReportParameter[] Parameters = new ReportParameter[7];
                Parameters[0] = new ReportParameter("id_rodzaj", Settings.ID_rodzaj.ToString());
                Parameters[1] = new ReportParameter("tytul", TitleSearchTextBox.Text.Trim());
                Parameters[2] = new ReportParameter("syg", SygSearchTextBox.Text.Trim());
                Parameters[3] = new ReportParameter("numer_inw", NumerInwSearchTextBox.Text.Trim());
                Parameters[4] = new ReportParameter("search_by_date", SearchCheckBox.Checked.ToString());
                Parameters[5] = new ReportParameter("start_date", startDateSearchDTP.Value.ToString("yyyyMMdd"));
                Parameters[6] = new ReportParameter("end_date", endDateSearchDTP.Value.ToString("yyyyMMdd"));

                RdlViewer.MainForm Report = new RdlViewer.MainForm("UbytkiKsiazki.rdl", Parameters, "coliber", Settings.ConnectionString);
                Report.ShowDialog();
            }
            else if (CurrentKind == KindEnum.Magazine)
            {
                ReportParameter[] Parameters = new ReportParameter[7];
                Parameters[0] = new ReportParameter("id_rodzaj", Settings.ID_rodzaj.ToString());
                Parameters[1] = new ReportParameter("tytul", TitleSearchTextBox.Text.Trim());
                Parameters[2] = new ReportParameter("syg", SygSearchTextBox.Text.Trim());
                Parameters[3] = new ReportParameter("numer_inw", NumerInwSearchTextBox.Text.Trim());
                Parameters[4] = new ReportParameter("search_by_date", SearchCheckBox.Checked.ToString());
                Parameters[5] = new ReportParameter("start_date", startDateSearchDTP.Value.ToString("yyyyMMdd"));
                Parameters[6] = new ReportParameter("end_date", endDateSearchDTP.Value.ToString("yyyyMMdd"));

                RdlViewer.MainForm Report = new RdlViewer.MainForm("UbytkiCzasopisma.rdl", Parameters, "coliber", Settings.ConnectionString);
                Report.ShowDialog();
            }

            WF.Close();
        }

        private void CleanSearchButton_Click(object sender, EventArgs e)
        {
            CurrentFoundIndex = 0;

            SygSearchTextBox.Text = "";
            NumerInwSearchTextBox.Text = "";
            TitleSearchTextBox.Text = "";
            SearchCheckBox.Checked = false;
            startDateSearchDTP.Value = DateTime.Now;

            FetchUbytki(CurrentSort);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            CurrentFoundIndex = 0;
            FetchUbytki(CurrentSort);
            
        }

        private void NextSearchButton_Click(object sender, EventArgs e)
        {
            if (CurrentFoundIndex == UbytkiDGV.Rows.Count-1)
                CurrentFoundIndex = -1;

            Search(CurrentFoundIndex+1);
        }

        private void Search(int i, bool Found = false, bool FirstSearch = true)
        {
            if(i < UbytkiDGV.Rows.Count)
            {
                UbytkiDGV.Rows[i].Selected = true;
                CurrentFoundIndex = i;
                UbytkiDGV.Rows[i].Cells[TitleDGV.Name].Selected = true;
                Found = true;                
            }
        }

        private bool IsDateBetween(DateTime start, DateTime end, DateTime date)
        {
            return start <= date && date <= end;
        }

        private void SearchPrevious(int i, bool Found = false, bool FirstSearch = true)
        {
            if (i >= 0)
            {
                UbytkiDGV.Rows[i].Selected = true;
                CurrentFoundIndex = i;
                UbytkiDGV.Rows[i].Cells[TitleDGV.Name].Selected = true;
                Found = true;
            }
        }

        private void PreviousSearchButton_Click(object sender, EventArgs e)
        {
            if (CurrentFoundIndex == 0)
                CurrentFoundIndex = UbytkiDGV.Rows.Count;

            SearchPrevious(CurrentFoundIndex - 1);
        }

        private void SearchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            startDateSearchDTP.Enabled = SearchCheckBox.Checked;
            endDateSearchDTP.Enabled = SearchCheckBox.Checked;
        }

        private void TitleSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)                
                FetchUbytki(CurrentSort);
        }

        private void SygSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)                
                FetchUbytki(CurrentSort);
        }

        private void NumerInwSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)                
                FetchUbytki(CurrentSort);
        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < YearTextBox.TextLength; i++)
            {
                if (!char.IsDigit(YearTextBox.Text[i]))
                { 
                    YearTextBox.Text = YearTextBox.Text.Remove(i, 1);
                    YearTextBox.SelectionStart = YearTextBox.TextLength;
                }
            }
        }
    }
}
