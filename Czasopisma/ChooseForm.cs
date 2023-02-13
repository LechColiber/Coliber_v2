using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace Czasopisma
{
    public partial class ChooseForm : Form
    {
        private bool Seryjne;
        public enum ModeEnum
        {
            Edit,
            Delete
        }

        private ModeEnum CurrentModeEnum;
        private static Dictionary<string, string> _translationsDictionary = new Dictionary<string, string>();

        public ChooseForm(int id_rodzaj, ModeEnum Mode, string employeeID, bool Seryjne = false)
        {
            InitializeComponent();

            setControlsText();

            this.CurrentModeEnum = Mode;

            if (Mode == ModeEnum.Delete)
                this.Text = _translationsDictionary.getStringFromDictionary("Usuwanie", "Usuwanie danych");

            Settings.SetSettings(id_rodzaj);

            Settings.Search_ID_rodzaj = id_rodzaj;
            this.Seryjne = Seryjne;

            if (Seryjne)
                NewWydSerButton.Visible = true;

            Settings.employeeID = employeeID;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(NewWydSerButton, "new_serial_publication");
            mapping.Add(label1, "choice_existing_serial_publication_by");
            mapping.Add(SygButton, "by_list_of_entered_signatures");
            mapping.Add(TitleButton, "by_list_of_entered_titles");            
            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "data_modification");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private static void getTranslations()
        {
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(new Dictionary<object, string>(), Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        public static void ChangeTitle(int id_rodzaj, Form mdiParent)
        {
            if(!_translationsDictionary.Any())
                getTranslations();

            Settings.SetSettings(id_rodzaj);            

            Settings.Search_ID_rodzaj = id_rodzaj;

            SqlCommand Command = new SqlCommand("EXEC Czasop_MagazinesList @id_rodzaj, @seryjne, @sort; ");
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.Search_ID_rodzaj);
            Command.Parameters.AddWithValue("@seryjne", 0);
            Command.Parameters.AddWithValue("@sort", 1);

            DataGridViewColumn[] Columns = new DataGridViewColumn[4];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "tytul";
            Columns[1].Name = "tytul";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("magazine_title", "Tytuł czasopisma");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "syg";
            Columns[2].Name = "syg";
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("signature", "Sygnatura");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            Columns[3] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[3].DataPropertyName = "id_rodzaj";
            Columns[3].Name = "id_rodzaj";
            Columns[3].Visible = false;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybieranie");

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ChangeTitleForm CTF = new ChangeTitleForm(Formka.Dt.Cells["id"].Value.ToString(), id_rodzaj, false, false);
                CTF.MdiParent = mdiParent;
                CTF.Show();
                //CTF.ShowDialog();
            }
        } 

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
                this.Close();
        }

        private void SygButton_Click(object sender, EventArgs e)
        {
            ShowList(2);
        }

        private void TitleButton_Click(object sender, EventArgs e)
        {
            ShowList(1);
        }

        private void ShowList(int Sort)
        {
            SqlCommand Command = new SqlCommand("EXEC Czasop_MagazinesList @id_rodzaj, @seryjne, @sort; ");
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.Search_ID_rodzaj);

            if(CurrentModeEnum == ModeEnum.Edit)
                Command.Parameters.AddWithValue("@seryjne", !Seryjne ? 0 : 1);
            else            
                Command.Parameters.AddWithValue("@seryjne", 2);
            
            Command.Parameters.AddWithValue("@sort", Sort);

            DataGridViewColumn[] Columns = new DataGridViewColumn[5];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "tytul";
            Columns[1].Name = "tytul";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("magazine_title", "Tytuł czasopisma");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "syg";
            Columns[2].Name = "syg";
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("signature", "Sygnatura");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            Columns[3] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[3].DataPropertyName = "id_rodzaj";
            Columns[3].Name = "id_rodzaj";
            Columns[3].Visible = false;

            Columns[4] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[4].DataPropertyName = "seryjne";
            Columns[4].Name = "seryjne";
            Columns[4].Visible = false;

            ShowForm Formka = new ShowForm(Command, Columns, Sort == 1 ? "tytul" : "syg","M",CurrentModeEnum);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybieranie");

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (CurrentModeEnum == ModeEnum.Edit)
                {
                    MagazineForm MF = new MagazineForm(Int32.Parse(Formka.Dt.Cells["id_rodzaj"].Value.ToString()), Formka.Dt.Cells["id"].Value.ToString(), Settings.employeeID, Seryjne);
                    MF.MdiParent = this.MdiParent;
                    MF.Show();
                    //MF.ShowDialog();
                }
                else if (CurrentModeEnum == ModeEnum.Delete)
                {
                    MagazineForm MF = new MagazineForm(Formka.Dt.Cells["id"].Value.ToString(), Settings.employeeID, (bool)Formka.Dt.Cells["seryjne"].Value);
                    MF.MdiParent = this.MdiParent;
                    MF.Show();
                    //MF.ShowDialog();
                }
            }
        }

        private void NewWydSerButton_Click(object sender, EventArgs e)
        {
            MagazineForm MF = new MagazineForm(Settings.ID_rodzaj, Settings.employeeID, true);
            MF.MdiParent = this.MdiParent;
            MF.Show();
            //MF.ShowDialog();
        }
    }
}
