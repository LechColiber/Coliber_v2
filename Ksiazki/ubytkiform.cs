using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Wypozyczalnia;
using System.Threading;
using System.Collections.Generic;

namespace Ksiazki
{
    public partial class UbytkiForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private string BookID;

        public int AllSygsCount { get { return AllDGV.Rows.Count; } }
        public UbytkiForm(string BookID)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.BookID = BookID;

            FetchData(BookID);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "sig_del_01");
            mapping.Add(label3, "signatures_to_remove_without_registratio");
            mapping.Add(label2, "existing_signatures");
            mapping.Add(label1, "signatures_to_remove_with_registration");
            mapping.Add(CancButton, "cancel");
            mapping.Add(OkButton, "confirm");
            mapping.Add(SygNameDGV, "signature");
            mapping.Add(NumInwDGV, "inventory_number_1");
            mapping.Add(AllSygNameDGV, "signature");
            mapping.Add(AllNumInwDGV, "inventory_number_1");
            mapping.Add(UbytkiSygNameDGV, "signature");
            mapping.Add(UbytkiNumInwDGV, "inventory_number_1");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void UbytkiForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
                this.Dispose();
        }

        private void FetchData(string BookID)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "Ksiazki_BookSygs @BookID; ";
            Command.Parameters.AddWithValue("@BookID", BookID);

            DataTable Dt;
            
            //start - załadowanie sygnatur                              

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                AllDGV.Rows.Add(Dt.Rows[i]["id_sygnat"], Dt.Rows[i]["syg"], Dt.Rows[i]["numer_inw"]);
            }    
        }

        private void AllToDeleteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AllDGV.Rows.Count; i++)
            {
                UbytkiDGV.Rows.Add(AllDGV.Rows[i].Cells["AllSygIDDGV"].Value, AllDGV.Rows[i].Cells["AllSygNameDGV"].Value, AllDGV.Rows[i].Cells["AllNumInwDGV"].Value);                                
            }

            AllDGV.Rows.Clear();
        }

        private void AllToAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UbytkiDGV.Rows.Count; i++)
            {
                AllDGV.Rows.Add(UbytkiDGV.Rows[i].Cells["UbytkiSygIDDGV"].Value, UbytkiDGV.Rows[i].Cells["UbytkiSygNameDGV"].Value, UbytkiDGV.Rows[i].Cells["UbytkiNumInwDGV"].Value);
            }

            UbytkiDGV.Rows.Clear();
        }

        private void ToDelete_Click(object sender, EventArgs e)
        {
            if (AllDGV.SelectedRows.Count > 0)
            {
                UbytkiDGV.Rows.Add(AllDGV.SelectedRows[0].Cells["AllSygIDDGV"].Value, AllDGV.SelectedRows[0].Cells["AllSygNameDGV"].Value, AllDGV.SelectedRows[0].Cells["AllNumInwDGV"].Value);
                AllDGV.Rows.Remove(AllDGV.SelectedRows[0]);
            }
        }

        private void ToAllButton_Click(object sender, EventArgs e)
        {
            if (UbytkiDGV.SelectedRows.Count > 0)
            {
                AllDGV.Rows.Add(UbytkiDGV.SelectedRows[0].Cells["UbytkiSygIDDGV"].Value, UbytkiDGV.SelectedRows[0].Cells["UbytkiSygNameDGV"].Value, UbytkiDGV.SelectedRows[0].Cells["UbytkiNumInwDGV"].Value);
                UbytkiDGV.Rows.Remove(UbytkiDGV.SelectedRows[0]);
            }
        }

        private void AllToDGVButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AllDGV.Rows.Count; i++)
            {
                DGV.Rows.Add(AllDGV.Rows[i].Cells["AllSygIDDGV"].Value, AllDGV.Rows[i].Cells["AllSygNameDGV"].Value, AllDGV.Rows[i].Cells["AllNumInwDGV"].Value);
            }

            AllDGV.Rows.Clear();
        }

        private void AllDGVToAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                AllDGV.Rows.Add(DGV.Rows[i].Cells["SygIDDGV"].Value, DGV.Rows[i].Cells["SygNameDGV"].Value, DGV.Rows[i].Cells["NumInwDGV"].Value);
            }

            DGV.Rows.Clear();
        }

        private void ToDGVButton_Click(object sender, EventArgs e)
        {
            if (AllDGV.SelectedRows.Count > 0)
            {
                DGV.Rows.Add(AllDGV.SelectedRows[0].Cells["AllSygIDDGV"].Value, AllDGV.SelectedRows[0].Cells["AllSygNameDGV"].Value, AllDGV.SelectedRows[0].Cells["AllNumInwDGV"].Value);
                AllDGV.Rows.Remove(AllDGV.SelectedRows[0]);
            }
        }

        private void DGVToAllButton_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                AllDGV.Rows.Add(DGV.SelectedRows[0].Cells["SygIDDGV"].Value, DGV.SelectedRows[0].Cells["SygNameDGV"].Value, DGV.SelectedRows[0].Cells["NumInwDGV"].Value);
                DGV.Rows.Remove(DGV.SelectedRows[0]);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            bool Success = false;

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "";

            SingleUbytkiForm SUF;            

            for (int i = 0; i < UbytkiDGV.Rows.Count; i++)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = "EXEC Ksiazki_SprawdzSygnaturaJestWypozyczona @id; ";
                Cmd.Parameters.AddWithValue("@id", UbytkiDGV.Rows[i].Cells["UbytkiSygIDDGV"].Value.ToString());

                DataTable Dt = CommonFunctions.ReadData(Cmd, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    if (MessageBox.Show(string.Format(_T("book_was_borrowed_return_q"), Dt.Rows[0]["uzytkownik"], UbytkiDGV.Rows[i].Cells["UbytkiSygNameDGV"].Value.ToString()), _T("book_return"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ZwrotForm zwrot = new ZwrotForm(Dt.Rows[0]["wypoz_id"].ToString(), Settings.employeeID, this);

                        if (zwrot.ShowDialog() == DialogResult.Cancel)
                            return;
                    }
                    else
                        return;
                }

                SUF = new SingleUbytkiForm(UbytkiDGV.Rows[i].Cells["UbytkiSygNameDGV"].Value.ToString(), UbytkiDGV.Rows[i].Cells["UbytkiNumInwDGV"].Value.ToString());

                if (SUF.ShowDialog() == DialogResult.OK)
                {
                    Command = new SqlCommand();

                    Command.CommandText += "EXEC Ubytki_Add @BookID, @p_id_sygnat" + i + ", @syg" + i + ", @tytul" + i + ", '', @numer_inw" + i + ", '', @nr_ksiegi" + i + ", @nr_dow" + i + ", @cena" + i + ", @data_ubyt" + i + ", @uwagi" + i + ", @przyczyna" + i + ", @id_rodzaj, 1; ";
                    Command.Parameters.AddWithValue("@BookID", BookID);
                    Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
                    Command.Parameters.AddWithValue("@p_id_sygnat" + i, UbytkiDGV.Rows[i].Cells["UbytkiSygIDDGV"].Value.ToString());
                    Command.Parameters.AddWithValue("@syg" + i, SUF.Dt.Rows[0]["syg"].ToString());
                    Command.Parameters.AddWithValue("@tytul" + i, "");
                    Command.Parameters.AddWithValue("@numer_inw" + i, SUF.Dt.Rows[0]["numer_inw"].ToString());
                    Command.Parameters.AddWithValue("@nr_ksiegi" + i, SUF.Dt.Rows[0]["nr_ksiegi"].ToString() != "" ? SUF.Dt.Rows[0]["nr_ksiegi"].ToString() : "0");
                    Command.Parameters.AddWithValue("@nr_dow" + i, SUF.Dt.Rows[0]["nr_dowodu"].ToString());
                    Command.Parameters.AddWithValue("@cena" + i, 0);
                    Command.Parameters.AddWithValue("@data_ubyt" + i, SUF.Dt.Rows[0]["data"].ToString());
                    Command.Parameters.AddWithValue("@uwagi" + i, SUF.Dt.Rows[0]["uwagi"].ToString());
                    Command.Parameters.AddWithValue("@przyczyna" + i, SUF.Dt.Rows[0]["przyczyna"].ToString());

                    if (CommonFunctions.WriteData(Command, ref Settings.Connection))
                    {
                        MessageBox.Show(_T("book_was_deleted")+".", _T("deleting"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Success = true;
                        UbytkiDGV.Rows.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        Success = false;
                        return;
                    }
                }
            }

            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = "EXEC Ksiazki_SprawdzSygnaturaJestWypozyczona @id; ";
                Cmd.Parameters.AddWithValue("@id", DGV.Rows[i].Cells["SygIDDGV"].Value.ToString());

                DataTable Dt = CommonFunctions.ReadData(Cmd, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    if (MessageBox.Show(string.Format(_T("book_was_borrowed_return_q"), Dt.Rows[0]["uzytkownik"], DGV.Rows[i].Cells[SygNameDGV.Name].Value.ToString()), _T("book_return"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ZwrotForm zwrot = new ZwrotForm(Dt.Rows[0]["wypoz_id"].ToString(), Settings.employeeID, this);

                        if (zwrot.ShowDialog() == DialogResult.Cancel)
                            return;
                    }
                    else
                        return;
                }

                Command = new SqlCommand();

                Command.CommandText += "EXEC Ksiazki_DeleteSignature @id_sygnat" + i + "; ";
                Command.Parameters.AddWithValue("@id_sygnat" + i, DGV.Rows[i].Cells["SygIDDGV"].Value);

                if (CommonFunctions.WriteData(Command, ref Settings.Connection))
                {
                    MessageBox.Show(_T("book_was_deleted") + " " + _T("wo_loses_entry").ToLower()+"." , _T("deleting"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Success = true;
                    DGV.Rows.RemoveAt(i);
                    i--;
                }
                else
                {
                    Success = false;
                    return;
                }
            }

            if(DGV.Rows.Count > 0)
                DGV.Rows.Clear();

            if(AllDGV.Rows.Count > 0)
                AllDGV.Rows.Clear();

            if(UbytkiDGV.Rows.Count > 0)
                UbytkiDGV.Rows.Clear();

            FetchData(BookID);

            if (Success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancButton_Click(object sender, EventArgs e)
        {
            if (DGV.Rows.Count > 0)
                DGV.Rows.Clear();

            if (AllDGV.Rows.Count > 0)
                AllDGV.Rows.Clear();

            if (UbytkiDGV.Rows.Count > 0)
                UbytkiDGV.Rows.Clear();

            FetchData(BookID);

            this.Close();
        }
    }
}
