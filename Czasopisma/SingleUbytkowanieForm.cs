using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Czasopisma
{
    public partial class SingleUbytkowanieForm : Form
    {
        private string id_volumes;
        private string MagazineID;
        private string Title;
        private string Price;
        private string NumerInw;

        private bool Seryjne;
        private Dictionary<string, string> _translationsDictionary;
        public SingleUbytkowanieForm()
        {
            InitializeComponent();

            setControlsText();

            GenerateWykrComboBoxValues();
        }

        public SingleUbytkowanieForm(string id_volumes, string MagazineID, string Syg, string Title, bool Seryjne = false)
        {
            InitializeComponent();

            setControlsText();

            this.Seryjne = Seryjne;

            if (!Seryjne)
            {
                this.NumInwLabel.Visible = false;
                this.NextNumberLabel.Visible = false;

                this.absNoLabel.Visible = false;
                this.invNoLabel.Visible = false;  
            }
            else
            {
                this.yearTextLabel.Text = _translationsDictionary.getStringFromDictionary("number", "Numer");
                this.voluminTextLabel.Text = _translationsDictionary.getStringFromDictionary("title", "Tytuł");
                this.numberTextLabel.Text = _translationsDictionary.getStringFromDictionary("author", "Autor");
            }

            this.SygLabel.Text = Syg;

            this.id_volumes = id_volumes;
            this.MagazineID = MagazineID;

            this.Title = Title;

            LoadVolumes(id_volumes, Seryjne);

            GenerateWykrComboBoxValues();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(signatureTextLabel, "signature");
            mapping.Add(yearTextLabel, "year");
            mapping.Add(voluminTextLabel, "volume");
            mapping.Add(numberTextLabel, "numbers");

            mapping.Add(invNoLabel, "inventory_number");
            mapping.Add(absNoLabel, "absolute_number");

            mapping.Add(noLossesBookLabel, "losses_book_number");
            mapping.Add(dateLabel, "entry_date");
            mapping.Add(reasonLabel, "deletion_reason");
            mapping.Add(lossDocumentNumberLabel, "losses_document_number");
            mapping.Add(commentsLabel, "comments");

            mapping.Add(OkButton, "confirm");
            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "losses");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
/*
        public SingleUbytkowanieForm(string id_volumes, string MagazineID, string Syg, string Year, string Volumin, string Numbers, string Title, string Price, string NumerInw) : this()
        {            
            this.SygLabel.Text = Syg;
            this.YearLabel.Text = Year;
            this.VoluminLabel.Text = Volumin;
            this.NumbersLabel.Text = Numbers;

            this.id_volumes = id_volumes;
            this.MagazineID = MagazineID;

            this.Title = Title;
            this.Price = Price;
            this.NumerInw = NumerInw;            
        }*/

        private void LoadVolumes(string VolumesID, bool Seryjne)
        {
            SqlCommand Command = new SqlCommand();

            if (!Seryjne)
                Command.CommandText = "EXEC Czasop_VolumesSelectFill @id; ";
            else
                Command.CommandText = "EXEC Czasop_SeryjneSelectFill @id; ";

            Command.Parameters.AddWithValue("@id", VolumesID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {                
                if (Seryjne)
                {
                    /*
                     *  this.label2.Text = "Numer";
                        this.label3.Text = "Tytuł";
                        this.label4.Text = "Autor";*
                     * 
                     * */

                    // ewidencja seryjna
                    this.YearLabel.Text = Dt.Rows[0]["rok_ser"].ToString();
                    this.VoluminLabel.Text = Dt.Rows[0]["tytul_ser"].ToString();
                    this.NumbersLabel.Text = Dt.Rows[0]["autor1_ser"].ToString();

                    this.Price = Dt.Rows[0]["wart_ser"].ToString().Replace(",", ".");
                    this.NumerInw = Dt.Rows[0]["numer_inw"].ToString();

                    this.yearTextLabel.Text = Dt.Rows[0]["numer_ser"].ToString();
                    this.NextNumberLabel.Text = Dt.Rows[0]["nr_kol_ser"].ToString(); 
                }
                else
                {
                    // ewidencja
                    this.YearLabel.Text = Dt.Rows[0]["rok1"].ToString();
                    this.VoluminLabel.Text = Dt.Rows[0]["volumin"].ToString();
                    this.NumbersLabel.Text = Dt.Rows[0]["czesci"].ToString();

                    this.Price = Dt.Rows[0]["rocz_pren"].ToString().Replace(",", ".");
                    this.NumerInw = Dt.Rows[0]["numer_inw"].ToString();
                }
            }
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

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UbytkowanieForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {            
            Delete();
        }

        private void Delete()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ubytki_Add @p_MagazineID, @id_volumes, @p_syg, @p_tytul, @p_volumin, @p_numer_inw, @p_czesci, @p_nr_ksiegi, @p_nr_dow, @p_cena, @p_data_ubyt, @p_uwagi_u, @p_przyczyna, @p_id_rodzaj, @type; ";
            Command.Parameters.AddWithValue("@p_MagazineID", this.MagazineID);
            Command.Parameters.AddWithValue("@id_volumes", id_volumes);
            Command.Parameters.AddWithValue("@p_syg", this.SygLabel.Text);
            Command.Parameters.AddWithValue("@p_tytul", Title);

            if (!Seryjne)
            {
                Command.Parameters.AddWithValue("@p_volumin", this.VoluminLabel.Text);
                Command.Parameters.AddWithValue("@type", 2);
            }
            else
            {
                Command.Parameters.AddWithValue("@p_volumin", "");
                Command.Parameters.AddWithValue("@type", 3);
            }

            Command.Parameters.AddWithValue("@p_numer_inw", NumerInw);
            Command.Parameters.AddWithValue("@p_czesci", this.NumbersLabel.Text);
            Command.Parameters.AddWithValue("@p_nr_ksiegi", this.NrKsTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@p_nr_dow", this.NrDowTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@p_cena", Price);
            Command.Parameters.AddWithValue("@p_data_ubyt", this.DateDTP.Value.ToString("yyyyMMdd"));
            Command.Parameters.AddWithValue("@p_uwagi_u", this.CommentsRTB.Text.Trim());
            Command.Parameters.AddWithValue("@p_przyczyna", this.WykrComboBox.SelectedValue.ToString());
            Command.Parameters.AddWithValue("@p_id_rodzaj", Settings.ID_rodzaj);

            if (CommonFunctions.WriteData(Command, ref Settings.Connection))
            {
                //MessageBox.Show("Wolumin pomyślnie usunięto!", _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("removed", "Wolumin pomyślnie usunięto!"), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
