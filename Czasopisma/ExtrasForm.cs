using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Czasopisma
{
    public partial class ExtrasForm : Form
    {
        private int IDTemp;
        public DataTable Dt;

        private enum ModeEnum
        {
            Add,
            Edit,
            None
        }

        private ModeEnum CurrentModeEnum; 

        public ExtrasForm(bool ReadOnly)
        {
            InitializeComponent();

            setControlsText();

            IDTemp = 1;

            Dt = new DataTable();
            Dt.Columns.Add("idTemp");
            Dt.Columns.Add("id");
            Dt.Columns.Add("tytul_dod");
            Dt.Columns.Add("autor1");
            Dt.Columns.Add("autor2");
            Dt.Columns.Add("autor3");
            Dt.Columns.Add("k_kreskowy");

            ChangeState(ModeEnum.None);

            if (ReadOnly)
            {
                NewButton.Visible = false;
                EditButton.Visible = false;
                SaveButton.Visible = false;
                CancButton.Visible = false;
                DeleteButton.Visible = false;
            } 
        }
        public ExtrasForm(string MagazineID, string Syg, string Volumin, string Year, bool ReadOnly) : this(ReadOnly)
        {                                   
            GetData(MagazineID, Syg, Volumin, Year);                        
        }

        public ExtrasForm(DataTable Dt, bool ReadOnly) : this(ReadOnly)
        {
            if (Dt.Rows.Count > 0)
            {
                this.Dt = Dt;
                LoadData(Dt);
            }
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(extrasLabel, "supplements_list");

            mapping.Add(TitleDGVC, "title");

            mapping.Add(NewButton, "new");
            mapping.Add(EditButton, "edit");
            mapping.Add(DeleteButton, "delete");
            mapping.Add(SaveButton, "save");
            mapping.Add(CancButton, "cancel");

            mapping.Add(titleLabel, "title");
            mapping.Add(authorsLabel, "authors");

            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "supplements");

            CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name);
        }

        private void GetData(string MagazineID, string Syg, string Volumin, string Year)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_ExtrasList @MagazineID, @syg, @Volumin, @Year; ";
            Command.Parameters.AddWithValue("@MagazineID", MagazineID);
            Command.Parameters.AddWithValue("@syg", Syg);
            Command.Parameters.AddWithValue("@Volumin", Volumin);
            Command.Parameters.AddWithValue("@Year", Year);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);
            LoadData(Dt);
        }

        private void LoadData(DataTable Dt)
        {
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                ExtrasDGV.Rows.Add(IDTemp, Dt.Rows[i]["id"].ToString(), Dt.Rows[i]["tytul_dod"].ToString(), Dt.Rows[i]["autor1"].ToString(), Dt.Rows[i]["autor2"].ToString(), Dt.Rows[i]["autor3"].ToString(), Coliber.App.DBInt(Dt.Rows[i]["k_kreskowy"]).ToString());

                IDTemp++;
            }

            DeleteButton.Enabled = Dt.Rows.Count > 0;
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

            TitleTextBox.ReadOnly = !EnableCtrl;
            AuthorTextBox.ReadOnly = !EnableCtrl;
            Author2TextBox.ReadOnly = !EnableCtrl;
            Author3TextBox.ReadOnly = !EnableCtrl;
            tKodK.ReadOnly = !EnableCtrl;
        }

        private void Clear()
        {
            TitleTextBox.ResetText();
            AuthorTextBox.ResetText();
            Author2TextBox.ResetText();
            Author3TextBox.ResetText();
            tKodK.ResetText();
        }

        private bool Save()
        {
            if(CurrentModeEnum == ModeEnum.Add)
            {
                Dt.Rows.Add(IDTemp, "-1", TitleTextBox.Text.Trim(), AuthorTextBox.Text.Trim(), Author2TextBox.Text.Trim(), Author3TextBox.Text.Trim(),tKodK.Text.Trim());
                ExtrasDGV.Rows.Add(IDTemp, "-1", TitleTextBox.Text.Trim(), AuthorTextBox.Text.Trim(), Author2TextBox.Text.Trim(), Author3TextBox.Text.Trim(), tKodK.Text.Trim());
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

                ExtrasDGV.SelectedRows[0].Cells["TitleDGVC"].Value = TitleTextBox.Text.Trim();
                ExtrasDGV.SelectedRows[0].Cells["autor1"].Value = AuthorTextBox.Text.Trim();
                ExtrasDGV.SelectedRows[0].Cells["autor2"].Value = Author2TextBox.Text.Trim();
                ExtrasDGV.SelectedRows[0].Cells["autor3"].Value = Author3TextBox.Text.Trim();
                ExtrasDGV.SelectedRows[0].Cells["k_kreskowy"].Value = tKodK.Text.Trim();

                Dt.Rows.Add(IDTempTemp, ExtrasDGV.SelectedRows[0].Cells["id"].Value, TitleTextBox.Text.Trim(), AuthorTextBox.Text.Trim(), Author2TextBox.Text.Trim(), Author3TextBox.Text.Trim(), tKodK.Text.Trim());

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
            TitleTextBox.Text = ExtrasDGV.SelectedRows[0].Cells["TitleDGVC"].Value.ToString();
            AuthorTextBox.Text = ExtrasDGV.SelectedRows[0].Cells["autor1"].Value.ToString();
            Author2TextBox.Text = ExtrasDGV.SelectedRows[0].Cells["autor2"].Value.ToString();
            Author3TextBox.Text = ExtrasDGV.SelectedRows[0].Cells["autor3"].Value.ToString();
            tKodK.Text = ExtrasDGV.SelectedRows[0].Cells["k_kreskowy"].Value.ToString();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ChangeState(ModeEnum.Edit);
        }
    }
}
