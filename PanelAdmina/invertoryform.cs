using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class InvertoryForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private string SearchText;

        public InvertoryForm()
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            SelectFromDb();

            label1.Text = "";
            SearchText = "";
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "invertories_form");
            mapping.Add(label4, "searching");
            mapping.Add(EditButton, "edit");
            mapping.Add(ExitButton, "exit");
            mapping.Add(PrintButton, "print");
            mapping.Add(MergeButton, "do_change");
            mapping.Add(AddButton, "add");
            mapping.Add(DelButton, "delete");
            mapping.Add(ordinalDGVC, "oridinal_short");
            mapping.Add(invertoryNameDGVC, "invertory_name");
            mapping.Add(descDGVC, "description");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void SelectFromDb()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC InventoryList; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.coliberConnection);

            Dt.Columns.Add("L.p.");
            Dt.Columns["L.p."].SetOrdinal(0);

            for (int i = 0; i < Dt.Rows.Count; i++)
                Dt.Rows[i]["L.p."] = i + 1;

            dataGridView1.DataSource = Dt;

            /*if (dataGridView1.Rows.Count < 1)
                CountTextBox.Text = "";*/
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            ModifyInvertoryForm MDF = new ModifyInvertoryForm();
            MDF.ShowDialog();

            SelectFromDb();
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (dataGridView1.SelectedRows.Count > 0 && MessageBox.Show(_T("to_delete") + " " + dataGridView1.SelectedRows[0].Cells[invertoryNameDGVC.Name].Value.ToString() + " ?", _T("inv_deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {                    
                try
                {
                    SqlCommand ChangeCommand = new SqlCommand();                    

                    ChangeCommand.CommandText = "EXEC PA_InvertoryItemsCount @id; ";
                    ChangeCommand.Parameters.AddWithValue("@id", dataGridView1.SelectedRows[0].Cells[idDGVC.Name].Value.ToString());

                    DataTable Dt = CommonFunctions.ReadData(ChangeCommand, ref Settings.coliberConnection);

                    if (Dt.Rows.Count > 0)
                    {
                        if ((int) Dt.Rows[0]["InvertoryItemsCount"] == 0)
                        {
                            ChangeCommand.CommandText = "EXEC PA_DeleteInvertory @id; ";

                            if (CommonFunctions.WriteData(ChangeCommand, ref Settings.coliberConnection))
                            {
                                MessageBox.Show(_T("inv_was_deleted"), _T("inv_deleting"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SelectFromDb();
                            }
                        }
                        else
                        {
                            MessageBox.Show(_T("inventory_has_resources_deny"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }                   
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }                    
            }         
        }
        
        private void MergeButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";           
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            /*SearchText = "";
            label1.Text = "";

            try
            {
                OdbcCommand ReportCommand = new OdbcCommand();
                ReportCommand.coliberConnection = NewConnection.AppConnection;

                ReportCommand.CommandText = "SELECT LTRIM(RTRIM(departam)) AS departam FROM departam ORDER BY departam; ";

                ShowReport Report = new ShowReport(ReportCommand, "Departamenty");

                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate {  Wait.Show(this); Wait.Update(); });

                Report.ShowDialog();

                Wait.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }*/
        }

        #region Authors_KeyDown(object sender, KeyEventArgs e) - OK
        private void Authors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        #endregion

        private void EditButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string ID_current = dataGridView1.SelectedRows[0].Cells[idDGVC.Name].Value.ToString();

                ModifyInvertoryForm MDF = new ModifyInvertoryForm(dataGridView1.SelectedRows[0].Cells[invertoryNameDGVC.Name].Value.ToString(), dataGridView1.SelectedRows[0].Cells[descDGVC.Name].Value.ToString(), dataGridView1.SelectedRows[0].Cells[idDGVC.Name].Value.ToString());
                MDF.ShowDialog();

                //SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
                SelectFromDb();
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1[idDGVC.Name, i].Value.ToString() == ID_current)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Cells[invertoryNameDGVC.Name].Selected = true;
                    }
                }
            }      
        }

        #region Search(string Letter) - OK
        private void Search(string Letter)
        {
            if (Letter == '\b'.ToString())
            {
                if (SearchText.Length > 0)
                {
                    SearchText = SearchText.Remove(SearchText.Length - 1);
                    label1.Text = SearchText;
                }
            }
            else if (Letter == '\r'.ToString())
            {

            }
            else
            {
                SearchText += Letter;
                label1.Text = SearchText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[invertoryNameDGVC.Name].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1[invertoryNameDGVC.Name, i];
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }
        #endregion

        #region dataGridView1_KeyPress(object sender, KeyPressEventArgs e) - OK
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search(e.KeyChar.ToString());
        }
        #endregion

        #region dataGridView1_KeyDown(object sender, KeyEventArgs e) - OK
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SearchText = "";
                label1.Text = "";
            }
        }
        #endregion

        #region dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) - OK
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            SearchText = "";
            label1.Text = "";
        }
        #endregion

    }
}