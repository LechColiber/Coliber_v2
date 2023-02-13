using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Artykuly
{
    public partial class ChooseType : Form
    {
        private ArtykulyForm.ModeEnum CurrentMode;
        private bool ShowList;

        private static Dictionary<string, string> _translationsDictionary = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_rodzaj"></param>
        /// <param name="Mode">
        ///     1 - nowy
        ///     2 - edycja
        ///     3 - usuwanie
        ///     4 - read only do katalogu
        ///     </param>
        public ChooseType(int id_rodzaj, int Mode, Form mdiParent)
        {
            InitializeComponent();
            
            setControlsText();

            Settings.SetSettings(id_rodzaj);

            Settings.Search_ID_rodzaj = id_rodzaj;
            this.ShowList = false;

            if (Mode == 2)
            {
                CurrentMode = ArtykulyForm.ModeEnum.Edit;

                do
                {
                    this.ShowList = ShowAllArticles(CurrentMode, mdiParent);
                } while (ShowList);
            } 
            else if (Mode == 3)
            {
                CurrentMode = ArtykulyForm.ModeEnum.Delete;

                do
                {
                    this.ShowList = ShowAllArticles(CurrentMode, mdiParent);
                } while (ShowList);
            }
            else if (Mode == 1)
            {
                CurrentMode = ArtykulyForm.ModeEnum.Add;

                //this.ShowDialog();
                this.MdiParent = mdiParent;
                this.Show();
            }
        }

        public ChooseType(int id_rodzaj, int Mode, string ID, Form mdiParent) : this(id_rodzaj, Mode, mdiParent)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "SELECT LTRIM(RTRIM(rodzaj_zas)) AS rodzaj_zas FROM artykuly WHERE kod = @kod;";
            Command.Parameters.AddWithValue("@kod", ID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {
                ArtykulyForm AF;

                if (Dt.Rows[0]["rodzaj_zas"].ToString().ToLower() == "c")
                    AF = new ArtykulyForm(ArtykulyForm.KindEnum.Magazine, ArtykulyForm.ModeEnum.ReadOnlyCatalog, ID);
                else                
                    AF = new ArtykulyForm(ArtykulyForm.KindEnum.Book, ArtykulyForm.ModeEnum.ReadOnlyCatalog, ID);
                
                AF.ShowDialog();
            }
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(MagazineButton, "from_magazine");
            mapping.Add(BookButton, "from_book");
            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "article_adding");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MagazineButton_Click(object sender, EventArgs e)
        {            
            ArtykulyForm AF = new ArtykulyForm(ArtykulyForm.KindEnum.Magazine, CurrentMode);
            
            //AF.ShowDialog();
            AF.MdiParent = this.MdiParent;
            AF.Show();
        }

        private void BookButton_Click(object sender, EventArgs e)
        {
            ArtykulyForm AF = new ArtykulyForm(ArtykulyForm.KindEnum.Book, CurrentMode);
            
            //AF.ShowDialog();
            AF.MdiParent = this.MdiParent;
            AF.Show();
        }

        public static bool ShowAllArticles(ArtykulyForm.ModeEnum CurrentMode, Form mdiParent)
        {            
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC ZwrocListeArtykulow @id_rodzaj;";
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.Search_ID_rodzaj);

            DataGridViewColumn[] Columns = new DataGridViewColumn[7];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "tytul_artykulu";
            Columns[0].Name = "tytul_artykulu";
            Columns[0].HeaderText = _translationsDictionary.getStringFromDictionary("article_title", "Tytuł artykułu");
            Columns[0].MinimumWidth = 500;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "tytul_ksiazki";
            Columns[1].Name = "Tytuł książki";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("book_title", "Tytuł książki");
            Columns[1].Width = 242;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "tytul_czasopisma";
            Columns[2].Name  = "Tytuł czasopisma";
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("magazine_title", "Tytuł czasopisma");

            Columns[3] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[3].DataPropertyName = "rodzaj_zas";
            Columns[3].Name = "rodzaj_zas";
            Columns[3].Visible = false;

            Columns[4] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[4].DataPropertyName = "kod";
            Columns[4].Name = "kod";
            Columns[4].Visible = false;

            Columns[5] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[5].DataPropertyName = "kod_zas";
            Columns[5].Name = "kod_zas";
            Columns[5].Visible = false;

            Columns[6] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[6].DataPropertyName = "id_rodzaj";
            Columns[6].Name = "id_rodzaj";
            Columns[6].Visible = false;

            ShowForm SF = new ShowForm(Command, Columns);

            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (SF.Dt != null)
                {
                    Int32.TryParse(SF.Dt.Cells["id_rodzaj"].Value.ToString().Trim(), out Settings.ID_rodzaj);

                    if (SF.Dt.Cells["rodzaj_zas"].Value.ToString().ToLower().Trim() == "k")
                    {
                        ArtykulyForm AF = new ArtykulyForm(ArtykulyForm.KindEnum.Book, CurrentMode, SF.Dt.Cells["kod"].Value.ToString().Trim());
                        //AF.ShowDialog();

                        AF.MdiParent = mdiParent;
                        AF.Show();

                        return AF.ShowList;
                    }
                    else if (SF.Dt.Cells["rodzaj_zas"].Value.ToString().ToLower().Trim() == "c")
                    {
                        ArtykulyForm AF = new ArtykulyForm(ArtykulyForm.KindEnum.Magazine, CurrentMode, SF.Dt.Cells["kod"].Value.ToString().Trim());
                        //AF.ShowDialog();
                        AF.MdiParent = mdiParent;
                        AF.Show();

                        return AF.ShowList;
                    }
                }
            }

            return false;
        }

        private void ChooseType_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
                this.Close();
        }
    }
}
