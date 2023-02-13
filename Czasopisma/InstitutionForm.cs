using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Czasopisma
{
    public partial class InstitutionForm : Form
    {
        private int IDTemp;
        public DataTable Dt;

        public int Count { get { return ExtrasDGV.Rows.Count; } }        

        private enum ModeEnum
        {
            Add,
            Edit,
            None
        }

        private ModeEnum CurrentModeEnum;

        public InstitutionForm(bool ReadOnly)
        {
            InitializeComponent();
            setControlsText();

            IDTemp = 1;

            Dt = new DataTable();
            Dt.Columns.Add("idTemp");
            Dt.Columns.Add("id");
            Dt.Columns.Add("nazwa");
            Dt.Columns.Add("siedziba");            

            if (ReadOnly)
            {
                NewButton.Visible = false;
                EditButton.Visible = false;
                SaveButton.Visible = false;
                CancButton.Visible = false;
                DeleteButton.Visible = false;
            } 
        }
        public InstitutionForm(string MagazineID, bool ReadOnly) : this(ReadOnly)
        {                                   
            GetData(MagazineID);
        }

        public InstitutionForm(DataTable Dt, bool ReadOnly) : this(ReadOnly)
        {
            if (Dt.Rows.Count > 0)
            {
                //this.Dt = Dt;
                LoadData(Dt);
            }
            else
                ChangeState(ModeEnum.None);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(listLabel, "list_of_institution");

            mapping.Add(NameDGVC, "name_of_institution");

            mapping.Add(NewButton, "new");
            mapping.Add(EditButton, "edit");
            mapping.Add(DeleteButton, "delete");
            mapping.Add(SaveButton, "save");
            mapping.Add(CancButton, "cancel");

            mapping.Add(instNameLabel, "name_of_institution");
            mapping.Add(seatLabel, "seat");

            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "institutions");

            CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name);
        }

        private void GetData(string MagazineID)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_MagazineInstitutionsList @MagazineID; ";
            Command.Parameters.AddWithValue("@MagazineID", MagazineID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);
            LoadData(Dt);
        }

        private void LoadData(DataTable Dt)
        {
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Dt.Columns.Contains("idTemp") && Dt.Rows[i]["idTemp"].ToString() == "-1")
                {
                    this.Dt.Rows.Add(Dt.Rows[i]["idTemp"].ToString(), Dt.Rows[i]["id"].ToString(), Dt.Rows[i]["nazwa"].ToString(), Dt.Rows[i]["siedziba"].ToString());
                    continue;
                }

                ExtrasDGV.Rows.Add(IDTemp, Dt.Rows[i]["id"].ToString(), Dt.Rows[i]["nazwa"].ToString(), Dt.Rows[i]["siedziba"].ToString());
                this.Dt.Rows.Add(IDTemp, Dt.Rows[i]["id"].ToString(), Dt.Rows[i]["nazwa"].ToString(), Dt.Rows[i]["siedziba"].ToString());

                IDTemp++;
            }

            ChangeState(ModeEnum.None);
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExtrasForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
                this.Close();
        }

        private void ChangeState(ModeEnum Mode)
        {
            CurrentModeEnum = Mode;
            bool EnableCtrl;

            if (Mode == ModeEnum.Add)
            {
                Clear();
                EnableCtrl = true;
            }
            else if (Mode == ModeEnum.Edit)
            {
                EnableCtrl = true;
            }
            else
            {
                EnableCtrl = false;

                if (ExtrasDGV.SelectedRows.Count > 0)
                {
                    Fill();                   
                }
                else
                {
                    Clear();
                }
            }

            NewButton.Enabled = !EnableCtrl;
            EditButton.Enabled = !EnableCtrl && ExtrasDGV.SelectedRows.Count > 0;
            DeleteButton.Enabled = !EnableCtrl && ExtrasDGV.SelectedRows.Count > 0;

            SaveButton.Enabled = EnableCtrl;
            CancButton.Enabled = EnableCtrl;

            NameTextBox.ReadOnly = !EnableCtrl;
            PlaceTextBox.ReadOnly = !EnableCtrl;

            ExtrasDGV.Enabled = !EnableCtrl;

            SelectInstitutionButton.Enabled = EnableCtrl;
        }

        private void Clear()
        {
            NameTextBox.ResetText();
            PlaceTextBox.ResetText();
        }

        private bool Save()
        {
            if (NameTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Proszę wprowadzić nazwę instytucji.", "Uzupełnij dane", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if(CurrentModeEnum == ModeEnum.Add)
            {
                int idx = 0;

                Dt.Rows.Add(IDTemp, "-1", NameTextBox.Text.Trim(), PlaceTextBox.Text.Trim());
                idx = ExtrasDGV.Rows.Add(IDTemp, "-1", NameTextBox.Text.Trim(), PlaceTextBox.Text.Trim());
                
                ExtrasDGV.Rows[idx].Selected = true;
                ExtrasDGV.CurrentCell = ExtrasDGV.Rows[idx].Cells["NameDGVC"];
                ExtrasDGV.FirstDisplayedScrollingRowIndex = idx;
            }
            else
            {
                string IDTempTemp = ExtrasDGV.SelectedRows[0].Cells["tempid"].Value.ToString();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    if (Dt.Rows[i]["idTemp"].ToString() == IDTempTemp)
                    {
                        Dt.Rows.RemoveAt(i);
                        break;
                    }
                }

                ExtrasDGV.SelectedRows[0].Cells["NameDGVC"].Value = NameTextBox.Text.Trim();
                ExtrasDGV.SelectedRows[0].Cells["PlaceDGVC"].Value = PlaceTextBox.Text.Trim();

                Dt.Rows.Add(IDTempTemp, ExtrasDGV.SelectedRows[0].Cells["id"].Value, NameTextBox.Text.Trim(), PlaceTextBox.Text.Trim());
            }

            IDTemp++;            

            return true;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            ChangeState(ModeEnum.Add);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(Save())
                ChangeState(ModeEnum.None);
        }

        private void CancButton_Click(object sender, EventArgs e)
        {
            ChangeState(ModeEnum.None);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string IDTempTemp = ExtrasDGV.SelectedRows[0].Cells["tempid"].Value.ToString();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Dt.Rows[i]["idTemp"].ToString() == IDTempTemp)
                {
                    Dt.Rows.RemoveAt(i);
                    break;
                }
            }

            Dt.Rows.Add("-1", ExtrasDGV.SelectedRows[0].Cells["id"].Value);
            ExtrasDGV.Rows.RemoveAt(ExtrasDGV.SelectedRows[0].Index);
        }

        private void ExtrasDGV_SelectionChanged(object sender, EventArgs e)
        {            
            ChangeState(ModeEnum.None);            
        }

        private void Fill()
        {
            NameTextBox.Text = ExtrasDGV.SelectedRows[0].Cells["NameDGVC"].Value.ToString();
            PlaceTextBox.Text = ExtrasDGV.SelectedRows[0].Cells["PlaceDGVC"].Value.ToString();           
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ChangeState(ModeEnum.Edit);
        }

        private void SelectInstitutionButton_Click(object sender, EventArgs e)
        {
            // inicjalizacja 
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_InstitutionsList; ";

            DataGridViewColumn[] Columns = new DataGridViewColumn[2];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "nazwa_inst";
            Columns[0].Name = "nazwa_inst";
            Columns[0].HeaderText = "Nazwa wydawcy";
            Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "siedziba";
            Columns[1].Name = "siedziba";
            Columns[1].HeaderText = "Miasto";
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);

            if (Formka.ShowDialog() == DialogResult.OK)
            {
                // przypisanie siedziby i nazwy instytucji
                NameTextBox.Text = Formka.Dt.Cells["nazwa_inst"].Value.ToString();
                PlaceTextBox.Text = Formka.Dt.Cells["siedziba"].Value.ToString();
            }
        }
    }
}
