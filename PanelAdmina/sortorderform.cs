using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class SortOrderForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }

        public SortOrderForm()
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            LoadData();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "sort_order");
            mapping.Add(DeleteButton, "delete");
            mapping.Add(EditButton, "edit");
            mapping.Add(AddButton, "add");
            mapping.Add(EscapeButton, "exit");
            mapping.Add(OkButton, "confirm");
            mapping.Add(ciagDGVC, "string");
            mapping.Add(OldOrderDGVC, "old_order");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void LoadData()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "PA_SortOrderList; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.coliberConnection);

            if(ContentDGV.Rows.Count > 0)
                ContentDGV.Rows.Clear();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                ContentDGV.Rows.Add(Dt.Rows[i]["id"].ToString(), Dt.Rows[i]["ciag"].ToString(), Dt.Rows[i]["kolejnosc"].ToString());
            }

            if (ContentDGV.Rows.Count > 0)
            {
                EditButton.Enabled = true;
                DeleteButton.Enabled = true;
            }
            else
            {
                EditButton.Enabled = false;
                DeleteButton.Enabled = false;                
            }
        }

        private void UpButton_Click(object sender, System.EventArgs e)
        {
            int idx = ContentDGV.SelectedRows[0].Index;
            DataGridViewRow Row = ContentDGV.SelectedRows[0];

            ContentDGV.Rows.RemoveAt(idx);
            ContentDGV.Rows.Insert(idx - 1, Row);

            ContentDGV.Rows[idx - 1].Selected = true;                        
            ContentDGV.CurrentCell = ContentDGV.SelectedRows[0].Cells["ciagDGVC"];
        }

        private void ContentDGV_SelectionChanged(object sender, System.EventArgs e)
        {
            if (ContentDGV.SelectedRows.Count > 0)
            {                
                UpButton.Enabled = ContentDGV.SelectedRows[0].Index != 0;
                
                DownButton.Enabled = ContentDGV.SelectedRows[0].Index != ContentDGV.Rows.Count - 1;

                EditButton.Enabled = true;
                DeleteButton.Enabled = true;
            }
            else
            {
                EditButton.Enabled = false;
                DeleteButton.Enabled = false;
            }
        }

        private void DownButton_Click(object sender, System.EventArgs e)
        {
            int idx = ContentDGV.SelectedRows[0].Index;
            DataGridViewRow Row = ContentDGV.SelectedRows[0];

            ContentDGV.Rows.RemoveAt(idx);
            ContentDGV.Rows.Insert(idx + 1, Row);

            ContentDGV.Rows[idx + 1].Selected = true;
            ContentDGV.CurrentCell = ContentDGV.SelectedRows[0].Cells["ciagDGVC"];
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            ModifySortOrderForm MFOF = new ModifySortOrderForm(ModifySortOrderForm.ModeEnum.Add);

            if (MFOF.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                SearchAndSelect(MFOF.Ciag);
            }
        }

        private void SearchAndSelect(string Ciag)
        {
            for (int i = 0; i < ContentDGV.Rows.Count; i++)
            {
                if (ContentDGV.Rows[i].Cells["ciagDGVC"].Value.ToString().ToLower().Trim() == Ciag.ToLower().Trim())
                {
                    ContentDGV.ClearSelection();
                    ContentDGV.Rows[i].Selected = true;
                    ContentDGV.CurrentCell = ContentDGV.Rows[i].Cells["ciagDGVC"];
                }
            }
        }

        private void SortOrderForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void EscapeButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void EditButton_Click(object sender, System.EventArgs e)
        {
            ModifySortOrderForm MFOF = new ModifySortOrderForm(ModifySortOrderForm.ModeEnum.Edit, ContentDGV.SelectedRows[0].Cells["idDGVC"].Value.ToString(), ContentDGV.SelectedRows[0].Cells["ciagDGVC"].Value.ToString());
            
            if (MFOF.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                SearchAndSelect(MFOF.Ciag);
            }
        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(_T("confirm_delete") + " ?", _T("deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "PA_DeleteInvertoryOrderItem @ID; ";

                Command.Parameters.AddWithValue("@ID", ContentDGV.SelectedRows[0].Cells["idDGVC"].Value.ToString());
            
                if (CommonFunctions.WriteData(Command, ref Settings.coliberConnection))
                {
                    MessageBox.Show(_T("removed"), _T("deleting"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            Save();
        }

        private bool Save()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "";

            for (int i = 0; i < ContentDGV.Rows.Count; i++)
            {                
                Command.CommandText += "EXEC PA_EditInvertoryOrderItem @ID" + i + ", NULL, @order" + i + "; ";
                Command.Parameters.AddWithValue("@ID" + i, ContentDGV.Rows[i].Cells["idDGVC"].Value.ToString());
                Command.Parameters.AddWithValue("@order" + i, i + 1);                                    
            }
            
            Command.CommandText += "EXEC PA_UpdateInvertoryOrder; ";

            if (CommonFunctions.WriteData(Command, ref Settings.coliberConnection))
            {
                MessageBox.Show(_T("saved"), _T("data_save"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }
    }
}
