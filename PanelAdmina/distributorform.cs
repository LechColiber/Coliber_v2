
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class DistributorForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private string SearchText;

        public DistributorForm()
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            Search("");

            LoadData();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "magazine_distributors");
            mapping.Add(label4, "searching");
            mapping.Add(label2, "articles_001");
            mapping.Add(label12, "distributor_occurs_in");
            mapping.Add(NazwaDGVC, "name");
            mapping.Add(MiastoDGVC, "city");
            mapping.Add(ShortDGVC, "short_name");
            mapping.Add(CountryDGVC, "country");
            mapping.Add(CodeDGVC, "code");
            mapping.Add(AddressDGVC, "url_address");
            mapping.Add(PhoneDGVC, "phone");
            mapping.Add(Phone2DGVC, "phone_2");
            mapping.Add(FaxDGVC, "fax");
            mapping.Add(EditButton, "edit");
            mapping.Add(ShowBooksButton, "show_articles");
            mapping.Add(ExitButton, "exit");
            mapping.Add(MergeButton, "merge");
            mapping.Add(AddButton, "add");
            mapping.Add(DelButton, "delete");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void LoadData()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "DistributorsList; ";

            dataGridView1.DataSource = CommonFunctions.ReadData(Command, ref Settings.coliberConnection);
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(_T("confirm_distributor_delete"), _T("deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    DeleteDistributor(dataGridView1.SelectedRows[0].Cells["idDGV"].Value.ToString());
            }
        }

        private void DeleteDistributor(string ID)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "PA_DeleteDistributor @id; ";
            Command.Parameters.AddWithValue("@id", ID);

            if (CommonFunctions.WriteData(Command, ref Settings.coliberConnection))
            {
                MessageBox.Show(_T("removed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SearchText = "";
                label1.Text = "";
            }
        }

        private void DistributorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SearchText = "";
            label1.Text = "";
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search(e.KeyChar.ToString());
        }

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

            //bool BreakLoop = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["NazwaDGVC"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1["NazwaDGVC", i];
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
            /*for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Visible && dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;

                        dataGridView1.CurrentCell = dataGridView1[j, i];

                        dataGridView1.FirstDisplayedScrollingRowIndex = i;

                        BreakLoop = true;
                        break;
                    }
                }

                if (BreakLoop)
                    break;
            }*/
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ModifyDistributorForm MOF = new ModifyDistributorForm();

            if (MOF.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                SearchAndSelect(MOF.Ciag);
            }
        }

        private void SearchAndSelect(string Ciag)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["NazwaDGVC"].Value.ToString().ToLower().Trim() == Ciag.ToLower().Trim())
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells["NazwaDGVC"];
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ModifyDistributorForm MOF = new ModifyDistributorForm(dataGridView1.SelectedRows[0].Cells["NazwaDGVC"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["ShortDGVC"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["AddressDGVC"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["MiastoDGVC"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["CodeDGVC"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["CountryDGVC"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["PhoneDGVC"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["Phone2DGVC"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["FaxDGVC"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["idDGV"].Value.ToString());

                if (MOF.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    SearchAndSelect(MOF.Ciag);
                }
            }
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "DistributorsList; ";

                DataSet ChooseDs = new DataSet();

                ChooseDs.Tables.Add(CommonFunctions.ReadData(Command, ref Settings.coliberConnection));

                for (int i = 0; i < ChooseDs.Tables[0].Rows.Count; i++)
                {
                    if (ChooseDs.Tables[0].Rows[i]["id"].ToString() == dataGridView1.SelectedRows[0].Cells["idDGV"].Value.ToString())
                    {
                        ChooseDs.Tables[0].Rows.RemoveAt(i);
                        break;
                    }
                }

                ChooseSecond ChSForm = new ChooseSecond(ChooseDs);

                if (ChSForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int ID = ChSForm.ReturnID();
                    int Row = 0;
                    string ID_current = dataGridView1.SelectedRows[0].Cells["idDGV"].Value.ToString();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Int32.Parse(dataGridView1["idDGV", i].Value.ToString()) == ID)
                        {
                            Row = i;
                            break;
                        }
                    }

                    if (MessageBox.Show(_T("merge") + dataGridView1.SelectedRows[0].Cells["NazwaDGVC"].Value.ToString() + _T("with") + dataGridView1["NazwaDGVC", Row].Value.ToString() + "?", _T("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Merge(dataGridView1.SelectedRows[0].Cells["idDGV"].Value.ToString(), dataGridView1["idDGV", Row].Value.ToString()))
                        {
                            MessageBox.Show(_T("merged"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadData();

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1["idDGV", i].Value.ToString() == ID.ToString())
                                {
                                    dataGridView1.ClearSelection();
                                    dataGridView1.Rows[i].Cells["NazwaDGVC"].Selected = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool Merge(string OldID, string NewID)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "PA_DistributorsMerge @oldID, @newID; ";
            Command.Parameters.AddWithValue("@oldID", OldID);
            Command.Parameters.AddWithValue("@newID", NewID);

            if (CommonFunctions.WriteData(Command, ref Settings.coliberConnection))
                return true;
            
            return false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                SqlCommand Command = new SqlCommand();

                Command.CommandText = "PA_DistributorsSingleOccurrencesNumber @idDGV; ";

                Command.Parameters.AddWithValue("@idDGV", dataGridView1.SelectedRows[0].Cells["idDGV"].Value.ToString());

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.coliberConnection);

                if (Dt.Rows.Count > 0)
                    CountTextBox.Text = Dt.Rows[0]["count"].ToString();
            }
        }

        private void ShowBooksButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SearchText = "";
                label1.Text = "";

                if (CountTextBox.Text != "")
                {
                    ShowList ShowListForm = new ShowList(GetListWithMagazinesWhereDistributorOccured(dataGridView1.SelectedRows[0].Cells["idDGV"].Value.ToString()), dataGridView1.SelectedRows[0].Cells["NazwaDGVC"].Value.ToString());
                    ShowListForm.ShowDialog();
                }

                dataGridView1.Focus();
            }
        }

        private List<string> GetListWithMagazinesWhereDistributorOccured(string ID)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "PA_DistributorsSingleMagazine @id";
            Command.Parameters.AddWithValue("@id", ID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.coliberConnection);

            List<string> Lista = new List<string>();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Lista.Add(Dt.Rows[i]["tytul"].ToString());
            }

            return Lista;
        }
    }
}
