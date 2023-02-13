using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using Wypozyczalnia;

namespace Czasopisma
{
    public partial class UbytkiForm : Form
    {
        private string MagazineID;
        private bool Seryjne;
        private string Title;

        public int AllSygsCount { get { return AllDGV.Rows.Count; } }
        private Dictionary<string, string> _translationsDictionary;
        public UbytkiForm(string MagazineID, string Title, bool Seryjne)
        {
            InitializeComponent();
            setControlsText();

            this.MagazineID = MagazineID;
            this.Seryjne = Seryjne;
            this.Title = Title;

            FetchData(MagazineID);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(label1, "signatures_to_remove_with_registration");
            mapping.Add(label2, "existing_signatures");
            mapping.Add(label3, "signatures_to_remove_without_registration");

            mapping.Add(AllSygNameDGV, "signature");
            mapping.Add(UbytkiSygNameDGV, "signature");
            mapping.Add(SygNameDGV, "signature");

            mapping.Add(OkButton, "confirm");
            mapping.Add(CancButton, "cancel");

            mapping.Add(this, "magazine_signatures_deleting");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void UbytkiForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
                this.Close();
        }

        private void FetchData(string MagazineID)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "Czasop_MagazineSygs @MagazineID; ";
            Command.Parameters.AddWithValue("@MagazineID", MagazineID);

            DataTable Dt;
            
            //start - załadowanie sygnatur                              

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                AllDGV.Rows.Add(Dt.Rows[i]["id"], Dt.Rows[i]["syg"]);
            }    
        }

        private void AllToDeleteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AllDGV.Rows.Count; i++)
            {
                //UbytkiDGV.Rows.Add(AllDGV.Rows[i].Cells["AllSygIDDGV"].Value, AllDGV.Rows[i].Cells["AllSygNameDGV"].Value, AllDGV.Rows[i].Cells["AllNumInwDGV"].Value);
                UbytkiDGV.Rows.Add(AllDGV.Rows[i].Cells["AllSygIDDGV"].Value, AllDGV.Rows[i].Cells["AllSygNameDGV"].Value);
            }

            AllDGV.Rows.Clear();
        }

        private void AllToAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UbytkiDGV.Rows.Count; i++)
            {
                //AllDGV.Rows.Add(UbytkiDGV.Rows[i].Cells["UbytkiSygIDDGV"].Value, UbytkiDGV.Rows[i].Cells["UbytkiSygNameDGV"].Value, UbytkiDGV.Rows[i].Cells["UbytkiNumInwDGV"].Value);
                AllDGV.Rows.Add(UbytkiDGV.Rows[i].Cells["UbytkiSygIDDGV"].Value, UbytkiDGV.Rows[i].Cells["UbytkiSygNameDGV"].Value);
            }

            UbytkiDGV.Rows.Clear();
        }

        private void ToDelete_Click(object sender, EventArgs e)
        {
            if (AllDGV.SelectedRows.Count > 0)
            {
                //UbytkiDGV.Rows.Add(AllDGV.SelectedRows[0].Cells["AllSygIDDGV"].Value, AllDGV.SelectedRows[0].Cells["AllSygNameDGV"].Value, AllDGV.SelectedRows[0].Cells["AllNumInwDGV"].Value);
                UbytkiDGV.Rows.Add(AllDGV.SelectedRows[0].Cells["AllSygIDDGV"].Value, AllDGV.SelectedRows[0].Cells["AllSygNameDGV"].Value);
                AllDGV.Rows.Remove(AllDGV.SelectedRows[0]);
            }
        }

        private void ToAllButton_Click(object sender, EventArgs e)
        {
            if (UbytkiDGV.SelectedRows.Count > 0)
            {
                //AllDGV.Rows.Add(UbytkiDGV.SelectedRows[0].Cells["UbytkiSygIDDGV"].Value, UbytkiDGV.SelectedRows[0].Cells["UbytkiSygNameDGV"].Value, UbytkiDGV.SelectedRows[0].Cells["UbytkiNumInwDGV"].Value);
                AllDGV.Rows.Add(UbytkiDGV.SelectedRows[0].Cells["UbytkiSygIDDGV"].Value, UbytkiDGV.SelectedRows[0].Cells["UbytkiSygNameDGV"].Value);
                UbytkiDGV.Rows.Remove(UbytkiDGV.SelectedRows[0]);
            }
        }

        private void AllToDGVButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AllDGV.Rows.Count; i++)
            {
                //DGV.Rows.Add(AllDGV.Rows[i].Cells["AllSygIDDGV"].Value, AllDGV.Rows[i].Cells["AllSygNameDGV"].Value, AllDGV.Rows[i].Cells["AllNumInwDGV"].Value);
                DGV.Rows.Add(AllDGV.Rows[i].Cells["AllSygIDDGV"].Value, AllDGV.Rows[i].Cells["AllSygNameDGV"].Value);
            }

            AllDGV.Rows.Clear();
        }

        private void AllDGVToAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                //AllDGV.Rows.Add(DGV.Rows[i].Cells["SygIDDGV"].Value, DGV.Rows[i].Cells["SygNameDGV"].Value, DGV.Rows[i].Cells["NumInwDGV"].Value);
                AllDGV.Rows.Add(DGV.Rows[i].Cells["SygIDDGV"].Value, DGV.Rows[i].Cells["SygNameDGV"].Value);
            }

            DGV.Rows.Clear();
        }

        private void ToDGVButton_Click(object sender, EventArgs e)
        {
            if (AllDGV.SelectedRows.Count > 0)
            {
                //DGV.Rows.Add(AllDGV.SelectedRows[0].Cells["AllSygIDDGV"].Value, AllDGV.SelectedRows[0].Cells["AllSygNameDGV"].Value, AllDGV.SelectedRows[0].Cells["AllNumInwDGV"].Value);
                DGV.Rows.Add(AllDGV.SelectedRows[0].Cells["AllSygIDDGV"].Value, AllDGV.SelectedRows[0].Cells["AllSygNameDGV"].Value);
                AllDGV.Rows.Remove(AllDGV.SelectedRows[0]);
            }
        }

        private void DGVToAllButton_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                //AllDGV.Rows.Add(DGV.SelectedRows[0].Cells["SygIDDGV"].Value, DGV.SelectedRows[0].Cells["SygNameDGV"].Value, DGV.SelectedRows[0].Cells["NumInwDGV"].Value);
                AllDGV.Rows.Add(DGV.SelectedRows[0].Cells["SygIDDGV"].Value, DGV.SelectedRows[0].Cells["SygNameDGV"].Value);
                DGV.Rows.Remove(DGV.SelectedRows[0]);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            bool Success = false;

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "";

            UbytkowanieForm UF;

            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                //                
                if (MessageBox.Show(string.Format("{0} {1}?", _translationsDictionary.getStringFromDictionary("do_you_want_to_delete_signature", "Czy chcesz usunąć sygnaturę "), DGV.Rows[i].Cells[SygNameDGV.Name].Value), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataTable Dt = Settings.IsNumberBorrowed(DGV.Rows[i].Cells[SygIDDGV.Name].Value.ToString(), 5);

                    if (Dt.Rows.Count > 0)
                    {
                        string message = string.Format("{0} {1} {2}", _translationsDictionary.ContainsKey("there_are_borrowed_copies_in_quantities") ? _translationsDictionary["there_are_borrowed_copies_in_quantities"] : "Istnieją wypożyczone egzemplarze w ilości:", Dt.Rows.Count, _translationsDictionary.ContainsKey("do_you_want_to_return_it") ? _translationsDictionary["do_you_want_to_return_it"] : "Czy chcesz je zwrócić?");

                        if (MessageBox.Show(string.Format(message, Dt.Rows.Count), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                    Command = new SqlCommand();

                    Command.CommandText += "EXEC Czasop_DeleteSygs @id" + i + "; ";
                    Command.Parameters.AddWithValue("@id" + i, DGV.Rows[i].Cells[SygIDDGV.Name].Value);

                    if (CommonFunctions.WriteData(Command, ref Settings.Connection))
                    {                        
                        //MessageBox.Show("Sygnatura została usunięta bez wpisu do księgi ubytków.", _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(_translationsDictionary.getStringFromDictionary("signature_was_removed_without_registration", "Sygnatura została usunięta bez wpisu do księgi ubytków."), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Success = true;
                    }
                    else
                        return;
                }
            }

            for (int i = 0; i < UbytkiDGV.Rows.Count; i++)
            {
                UF = new UbytkowanieForm(MagazineID, UbytkiDGV.Rows[i].Cells[UbytkiSygIDDGV.Name].Value.ToString(), UbytkiDGV.Rows[i].Cells[UbytkiSygNameDGV.Name].Value.ToString(), Title, Seryjne);

                UF.ShowDialog();
            }            

            if (DGV.Rows.Count > 0)
                DGV.Rows.Clear();

            if (AllDGV.Rows.Count > 0)
                AllDGV.Rows.Clear();

            if (UbytkiDGV.Rows.Count > 0)
                UbytkiDGV.Rows.Clear();

            FetchData(MagazineID);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancButton_Click(object sender, EventArgs e)
        {
            if (DGV.Rows.Count > 0)
                DGV.Rows.Clear();

            if (AllDGV.Rows.Count > 0)
                AllDGV.Rows.Clear();

            if (UbytkiDGV.Rows.Count > 0)
                UbytkiDGV.Rows.Clear();

            FetchData(MagazineID);

            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
