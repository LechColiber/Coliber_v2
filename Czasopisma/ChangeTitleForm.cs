using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Czasopisma
{
    public partial class ChangeTitleForm : Form
    {
        private string PreviousID;
        private string NextID;
        private string CurrentID;
        private bool ReadOnly;
        private bool Seryjne;
        private Dictionary<string, string> _translationsDictionary;

        public ChangeTitleForm(string MagazineID, int id_rodzaj, bool Seryjne, bool ReadOnly = true)
        {
            InitializeComponent();

            setControlsText();

            Settings.SetSettings(id_rodzaj);

            this.CurrentID = MagazineID;
            Settings.ID_rodzaj = id_rodzaj;
            this.ReadOnly = ReadOnly;
            this.Seryjne = Seryjne;

            AddNextButton.Visible = !ReadOnly;
            AddPreviousButton.Visible = !ReadOnly;
            DeleteNextButton.Visible = !ReadOnly;
            DeletePreviousButton.Visible = !ReadOnly;

            LoadCurrent(MagazineID, true);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(label1, "title_of_modyfing_magazine");
            mapping.Add(label3, "previous_magazine_title");
            mapping.Add(label4, "next_magazine_title");

            mapping.Add(PreviousButton, "previous");
            mapping.Add(NextButton, "next");
            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "change_title_of_magazine");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void ChangeTitleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCurrent(string ID, bool IsFirst = false)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_ChangeTitleSelect @Magazine; ";
            Command.Parameters.AddWithValue("@Magazine", ID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if(Dt.Rows.Count > 0)
            {
//
//                NamedFormat.Format("Od {number} numeru {year} r. wychodzi pt.: {title}", new {a = "123"});
//                NamedFormat.Format("Wychodzi pt.: [tytul] {title}", new {a = "123"});

                if (IsFirst)
                    TitleRTB.Text = Dt.Rows[0]["tytul"].ToString();

                // "środkowy" tytuł
                CurrentID = ID;

                CurrentRTB.Text = Dt.Rows[0]["tytul"].ToString();

                // górny tytuł
                PreviousID = Dt.Rows[0]["poprzedni_kod"].ToString();
                PreviousRTB.Text = "";

                /*if (!string.IsNullOrEmpty(Dt.Rows[0]["poprzedni_numer"].ToString()) || !string.IsNullOrEmpty(Dt.Rows[0]["poprzedni_rok"].ToString()))
                    PreviousRTB.Text = "Do ";

                if (!string.IsNullOrEmpty(Dt.Rows[0]["poprzedni_numer"].ToString()))
                    PreviousRTB.Text += Dt.Rows[0]["poprzedni_numer"].ToString() + " numeru ";

                if (!string.IsNullOrEmpty(Dt.Rows[0]["poprzedni_rok"].ToString()))
                    PreviousRTB.Text += Dt.Rows[0]["poprzedni_rok"].ToString() + " r. ";

                if (PreviousRTB.TextLength > 0)
                    PreviousRTB.Text += "wychodził ";
                else
                    PreviousRTB.Text = "Wychodził ";

                if (!string.IsNullOrEmpty(Dt.Rows[0]["poprzedni_tytul"].ToString()))
                    PreviousRTB.Text += "pt.: " + Dt.Rows[0]["poprzedni_tytul"].ToString();
                else
                    PreviousRTB.Text = "";*/

                var previousValues = new { number = Dt.Rows[0]["poprzedni_numer"], year = Dt.Rows[0]["poprzedni_rok"], title = Dt.Rows[0]["poprzedni_tytul"] };

                if (!string.IsNullOrWhiteSpace(Dt.Rows[0]["poprzedni_numer"].ToString()) && !string.IsNullOrWhiteSpace(Dt.Rows[0]["poprzedni_rok"].ToString()))
                    PreviousRTB.Text = NamedFormat.Format(_translationsDictionary.getStringFromDictionary("until_number_issue_year_was_published_as", "Do {number} numeru {year} r. wychodził pt.: {title}"), previousValues);
                else if (!string.IsNullOrWhiteSpace(Dt.Rows[0]["poprzedni_numer"].ToString()))
                    PreviousRTB.Text = NamedFormat.Format(_translationsDictionary.getStringFromDictionary("until_number_issue_was_published_as", "Do {number} numeru wychodził pt.: {title}"), previousValues);
                else if (!string.IsNullOrWhiteSpace(Dt.Rows[0]["poprzedni_rok"].ToString()))
                    PreviousRTB.Text = NamedFormat.Format(_translationsDictionary.getStringFromDictionary("until_year_was_published_as", "Do {year} r. wychodził pt.: {title}"), previousValues);
                else if (!string.IsNullOrEmpty(Dt.Rows[0]["poprzedni_tytul"].ToString()))
                    PreviousRTB.Text = NamedFormat.Format(_translationsDictionary.getStringFromDictionary("was_published_as", "Wychodził pt.: {title}"), previousValues);
                else
                    PreviousRTB.Text = "";

                // dolny tytuł
                /*NextID = Dt.Rows[0]["nastepny_kod"].ToString();
                NextRTB.Text = "";

                if (!string.IsNullOrEmpty(Dt.Rows[0]["nastepny_numer"].ToString()) || !string.IsNullOrEmpty(Dt.Rows[0]["nastepny_rok"].ToString()))
                    NextRTB.Text = "Do ";

                if (!string.IsNullOrEmpty(Dt.Rows[0]["nastepny_numer"].ToString()))
                    NextRTB.Text += Dt.Rows[0]["nastepny_numer"].ToString() + " numeru ";

                if (!string.IsNullOrEmpty(Dt.Rows[0]["nastepny_rok"].ToString()))
                    NextRTB.Text += Dt.Rows[0]["nastepny_rok"].ToString() + " r. ";

                if (NextRTB.TextLength > 0)
                    NextRTB.Text += "wychodzi ";
                else
                    NextRTB.Text = "Wychodzi ";

                if (!string.IsNullOrEmpty(Dt.Rows[0]["nastepny_tytul"].ToString()))
                    NextRTB.Text += "pt.: " + Dt.Rows[0]["nastepny_tytul"].ToString();
                else
                    NextRTB.Text = ""; */

                var nextValues = new { number = Dt.Rows[0]["nastepny_numer"], year = Dt.Rows[0]["nastepny_rok"], title = Dt.Rows[0]["nastepny_tytul"] };

                if (!string.IsNullOrWhiteSpace(Dt.Rows[0]["nastepny_numer"].ToString()) && !string.IsNullOrWhiteSpace(Dt.Rows[0]["nastepny_rok"].ToString()))
                    NextRTB.Text = NamedFormat.Format(_translationsDictionary.getStringFromDictionary("since_number_issue_year_has_been_published_as", "Od {number} numeru {year} r. wychodzi pt.: {title}"), nextValues);
                else if (!string.IsNullOrWhiteSpace(Dt.Rows[0]["nastepny_numer"].ToString()))
                    NextRTB.Text = NamedFormat.Format(_translationsDictionary.getStringFromDictionary("since_number_issue_has_been_published_as", "Od {number} numeru wychodzi pt.: {title}"), nextValues);
                else if (!string.IsNullOrWhiteSpace(Dt.Rows[0]["nastepny_rok"].ToString()))
                    NextRTB.Text = NamedFormat.Format(_translationsDictionary.getStringFromDictionary("since_year_has_been_published_as", "Od {year} r. wychodzi pt.: {title}"), nextValues);
                else if (!string.IsNullOrEmpty(Dt.Rows[0]["nastepny_tytul"].ToString()))
                    NextRTB.Text = NamedFormat.Format(_translationsDictionary.getStringFromDictionary("has_been_published_as", "Wychodzi pt.: {title}"), nextValues);
                else
                    NextRTB.Text = "";
            }

            ChangeButtonStates(PreviousID, NextID);
        }       

        private void ChangeButtonStates(string PreviousID, string NextID)
        {
            PreviousButton.Enabled = !string.IsNullOrEmpty(PreviousID);
            AddPreviousButton.Enabled = string.IsNullOrEmpty(PreviousID);
            DeletePreviousButton.Enabled = !string.IsNullOrEmpty(PreviousID);
            PreviousInfoButton.Enabled = !string.IsNullOrEmpty(PreviousID);

            NextButton.Enabled = !string.IsNullOrEmpty(NextID);
            AddNextButton.Enabled = string.IsNullOrEmpty(NextID);
            DeleteNextButton.Enabled = !string.IsNullOrEmpty(NextID);
            NextInfoButton.Enabled = !string.IsNullOrEmpty(NextID);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            LoadCurrent(NextID);
        }

        private void PrevoiusButton_Click(object sender, EventArgs e)
        {
            LoadCurrent(PreviousID);
        }

        private void DeleteTitle(string ID, string ID2, bool IsNext)
        {            
            //if(MessageBox.Show("Czy usunąć " + (IsNext ? "następny" : "poprzedni" ) + " tytuł?", "Usuwanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            if(MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_this_title", "Czy usunąć " + (IsNext ? "następny" : "poprzedni" ) + " tytuł?"), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Czasop_DeleteChangeTitle @MagazineID, @MagazineID2; ";
                Command.Parameters.AddWithValue("@MagazineID", ID);
                Command.Parameters.AddWithValue("@MagazineID2", ID2);

                CommonFunctions.WriteData(Command, ref Settings.Connection);

                LoadCurrent(CurrentID);
            }
        }

        private void DeleteNextButton_Click(object sender, EventArgs e)
        {
            DeleteTitle(CurrentID, NextID, true);
        }

        private void DeletePreviousButton_Click(object sender, EventArgs e)
        {
            DeleteTitle(CurrentID, PreviousID, false);
        }

        private void AddTitle(string CurrentID, string ID, bool IsNext)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_AddChangeTitle @MagazineID, @ID, @IsNext; ";
            Command.Parameters.AddWithValue("@MagazineID", CurrentID);
            Command.Parameters.AddWithValue("@ID", ID);
            Command.Parameters.AddWithValue("@IsNext", IsNext ? 1 : 0);

            CommonFunctions.WriteData(Command, ref Settings.Connection);

            LoadCurrent(CurrentID);
        }

        private void MagazinesList(bool IsNext)
        {
            SqlCommand Command = new SqlCommand("EXEC Czasop_MagazinesList @id_rodzaj, @seryjne; ");
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
            Command.Parameters.AddWithValue("@seryjne", this.Seryjne);

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "tytul";
            Columns[2].Name = "tytul";
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("magazine_title", "Tytuł czasopisma");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "syg";
            Columns[1].Name = "syg";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("signature", "Sygnatura");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybieranie");

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Formka.Dt.Cells["id"].Value.ToString() == CurrentID)
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("this_magazine_cannot_join", "Tego czasopisma nie można dołączyć!"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    AddTitle(CurrentID, Formka.Dt.Cells["id"].Value.ToString(), IsNext);
            }
        }

        private void AddNextButton_Click(object sender, EventArgs e)
        {
            MagazinesList(true);
        }

        private void AddPreviousButton_Click(object sender, EventArgs e)
        {
            MagazinesList(false);
        }

        private void NextInfoButton_Click(object sender, EventArgs e)
        {
            DetailsChangeTitleForm DFTF = new DetailsChangeTitleForm(CurrentID, NextID, true, this.ReadOnly);
            DFTF.ShowDialog();

            LoadCurrent(CurrentID);
        }

        private void PreviousInfoButton_Click(object sender, EventArgs e)
        {
            DetailsChangeTitleForm DFTF = new DetailsChangeTitleForm(PreviousID, CurrentID, false, this.ReadOnly);
            DFTF.ShowDialog();

            LoadCurrent(CurrentID);
        }
    }
}
