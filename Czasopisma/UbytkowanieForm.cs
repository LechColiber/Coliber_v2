using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using Wypozyczalnia;

namespace Czasopisma
{
    public partial class UbytkowanieForm : Form
    {
        private string MagazineID;
        private bool Seryjne;
        private string id_cza_syg;
        private string Title;

        private Dictionary<string, string> _translationsDictionary;
        public UbytkowanieForm(string MagazineID, string id_cza_syg, string Syg, string Title, bool Seryjne = false)
        {
            InitializeComponent();

            setControlsText();

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

            this.YearLabel.Text = "";
            this.VoluminLabel.Text = "";
            this.NumbersLabel.Text = "";

            this.Title = Title;
            this.SygLabel.Text = Syg;
            this.MagazineID = MagazineID;
            this.Seryjne = Seryjne;
            this.id_cza_syg = id_cza_syg;

            FetchData(MagazineID, id_cza_syg, Seryjne);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(signatureLabel, "signature");
            mapping.Add(yearTextLabel, "year");
            mapping.Add(voluminTextLabel, "volume");
            mapping.Add(numberTextLabel, "numbers");

            mapping.Add(invNoLabel, "inventory_number");
            mapping.Add(absNoLabel, "absolute_number");

            mapping.Add(CheckBoxDGVC, "delete");
            mapping.Add(WoluminDGVC, "numbers");

            mapping.Add(OkButton, "confirm");
            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void FetchData(string MagazineID, string id_cza_syg, bool Seryjne)
        {
            SqlCommand Command = new SqlCommand();

            if (!Seryjne)
                Command.CommandText = "EXEC Czasop_VolumesList @MagazineID, @id_cza_syg; ";
            else
                Command.CommandText = "EXEC Czasop_SeryjneList @MagazineID, @id_cza_syg; ";

            Command.Parameters.AddWithValue("@MagazineID", MagazineID);
            Command.Parameters.AddWithValue("@id_cza_syg", id_cza_syg);                                     

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if(UbytkiDGV.Rows.Count > 0)
                UbytkiDGV.Rows.Clear();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                UbytkiDGV.Rows.Add(Dt.Rows[i]["id"], false, Dt.Rows[i]["volumin"]);
            }
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            bool deleted = false;

            for (int i = 0; i < UbytkiDGV.Rows.Count; i++)
            {
                if (((bool) UbytkiDGV.Rows[i].Cells["CheckBoxDGVC"].Value))
                {
                    DataTable Dt = Settings.IsNumberBorrowed(UbytkiDGV.Rows[i].Cells["id_volumesDGVC"].Value.ToString(), 2);

                    if (Dt.Rows.Count > 0)
                    {
                        string message = string.Format("{0} {1} {2}", _translationsDictionary.ContainsKey("there_are_borrowed_copies_in_quantities") ? _translationsDictionary["there_are_borrowed_copies_in_quantities"] : "Istnieją wypożyczone egzemplarze w ilości:", Dt.Rows.Count, _translationsDictionary.ContainsKey("do_you_want_to_return_it") ? _translationsDictionary["do_you_want_to_return_it"] : "Czy chcesz je zwrócić?");

                        if (MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //if (MessageBox.Show(string.Format("Istnieją wypożyczone egzemplarze w ilości: {0}. Czy chcesz je zwrócić?", Dt.Rows.Count), "Zwracanie numerów", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int j = 1;
                            bool check = true;

                            foreach (DataRow row in Dt.Rows)
                            {
                                ZwrotForm zwrot = new ZwrotForm(row["wypoz_id"].ToString(), Settings.employeeID, this);
                                zwrot.Text += string.Format(" {0} z {1}", j, Dt.Rows.Count);

                                if (zwrot.ShowDialog() == DialogResult.Cancel)
                                    check = false;

                                j++;
                            }

                            if (!check)
                                return;
                        }
                        else
                            return;
                    }

                    SingleUbytkowanieForm SUF = new SingleUbytkowanieForm(UbytkiDGV.Rows[i].Cells["id_volumesDGVC"].Value.ToString(), this.MagazineID, this.SygLabel.Text, Title, Seryjne);
                    SUF.ShowDialog();

                    deleted = true;
                }
            }

            if (!deleted && UbytkiDGV.Rows.Count > 0)
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("choose_volume_to_delete", "Proszę wybrać wolumin do usunięcia."), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie woluminów"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FetchData(MagazineID, id_cza_syg, Seryjne);

            if (UbytkiDGV.Rows.Count == 0)
                DeleteSyg();

            this.Close();
        }

        private void DeleteSyg()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText += "EXEC Czasop_DeleteSygs @deleteSyg; ";
            Command.Parameters.AddWithValue("@deleteSyg", id_cza_syg);

            CommonFunctions.WriteData(Command, ref Settings.Connection);
        }

        private void UbytkiDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (UbytkiDGV.SelectedRows.Count > 0)
                LoadVolumes(UbytkiDGV.SelectedRows[0].Cells["id_volumesDGVC"].Value.ToString());
        }

        private void LoadVolumes(string id_volumes)
        {
            SqlCommand Command = new SqlCommand();

            if (!Seryjne)
                Command.CommandText = "EXEC Czasop_VolumesSelectFill @id_volumes; ";
            else
                Command.CommandText = "EXEC Czasop_SeryjneSelectFill @id_volumes; ";

            Command.Parameters.AddWithValue("@id_volumes", id_volumes);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {
                if (!Seryjne)
                {
                    this.YearLabel.ResetText();

                    if (!string.IsNullOrEmpty(Dt.Rows[0]["rok1"].ToString()))
                        this.YearLabel.Text = Dt.Rows[0]["rok1"].ToString();

                    if (!string.IsNullOrEmpty(Dt.Rows[0]["rok2"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(this.YearLabel.Text))
                            this.YearLabel.Text += " / ";

                        this.YearLabel.Text += Dt.Rows[0]["rok2"].ToString();
                    }

                    this.VoluminLabel.Text = Dt.Rows[0]["volumin"].ToString();
                    this.NumbersLabel.Text = Dt.Rows[0]["czesci"].ToString();
                }
                else
                {
                    this.YearLabel.Text = Dt.Rows[0]["numer_ser"].ToString() + " / " + Dt.Rows[0]["rok_ser"].ToString();
                    this.VoluminLabel.Text = Dt.Rows[0]["tytul_ser"].ToString();
                    this.NumInwLabel.Text = Dt.Rows[0]["numer_inw"].ToString();
                    this.NextNumberLabel.Text = Dt.Rows[0]["nr_kol_ser"].ToString();

                    this.NumbersLabel.Text = Dt.Rows[0]["autor1_ser"].ToString();

                    if(this.NumbersLabel.Text.Length > 0)
                        this.NumbersLabel.Text += Environment.NewLine + Dt.Rows[0]["autor2_ser"].ToString();
                    if (this.NumbersLabel.Text.Length > 0)
                        this.NumbersLabel.Text += Environment.NewLine + Dt.Rows[0]["autor3_ser"].ToString();
                }
            }
        }
    }
}
