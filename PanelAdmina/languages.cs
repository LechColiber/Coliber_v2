
﻿
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using WindowsFormsApplication1.Properties;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Languages : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private Connection NewConnection;
        private DataTable Dt;
        private OdbcDataReader Reader;
        private OdbcCommand Command;
        private string Table = "dbo.jezyki";
        private string SearchText;

        public Languages(Connection NewConnection)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.StartPosition = FormStartPosition.CenterParent;

            this.NewConnection = NewConnection;
            
            UpdateView(0);
            dataGridView1.Select();
            label1.Text = "";
            SearchText = "";
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this,"languages");
            mapping.Add(label2,"searching");
            mapping.Add(CloseButton,"exit");
            mapping.Add(DeleteButton,"delete");
            mapping.Add(EditButton,"edit");
            mapping.Add(AddButton,"add");
            mapping.Add(PolishNameLabel,"polish_name");
            mapping.Add(EnglishNameLabel,"english_name");
            mapping.Add(DigitalCodeLabel,"digit_code");
            mapping.Add(LanguagesLabel,"language");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void DigitalCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == (char)(Keys.Back))
                e.Handled = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Languages_Load(object sender, EventArgs e)
        {
            //UpdateView(0);
            dataGridView1.Focus();
        }

        private void UpdateView(int Row)
        {
            try
            {
                Command = new OdbcCommand();

                Command.CommandText = "SELECT LTRIM(RTRIM(jezyk)) AS [Język], LTRIM(RTRIM(j_kod_cyfr)) AS [Kod cyfrowy], RTRIM(LTRIM(j_an_nazwa)) AS [Nazwa angielska], RTRIM(LTRIM(j_pl_nazwa)) AS [Nazwa polska] FROM " + this.Table + " ORDER BY j_pl_nazwa; ";
                Command.Connection = NewConnection.AppConnection;

                Reader = Command.ExecuteReader();

                Dt = new DataTable();
                Dt.Columns.Add("Język");
                Dt.Columns.Add("Kod cyfrowy");
                Dt.Columns.Add("Nazwa angielska");
                Dt.Columns.Add("Nazwa polska");

                Dt.Load(Reader);

                Reader.Close();
                
                dataGridView1.DataSource = Dt;

                dataGridView1.Columns["Język"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Kod cyfrowy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridView1.Columns["Język"].HeaderText = _T("language");
                dataGridView1.Columns["Kod cyfrowy"].HeaderText = _T("digit_code");
                dataGridView1.Columns["Nazwa angielska"].HeaderText = _T("english_name");
                dataGridView1.Columns["Nazwa polska"].HeaderText = _T("polish_name");
                //dataGridView1.Update();
                dataGridView1.Refresh();

                ClearTextBoxes();
                DisableTextBoxes();

                Fill(Row);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                this.Close();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (DeleteButton.Text == _T("cancel"))
            {
                AddButton.Enabled = true;
                EditButton.Text = _T("edit");
                CloseButton.Enabled = true;
                DeleteButton.Text = _T("delete_magazine");
                ClearTextBoxes();
                DisableTextBoxes();

                EditButton.Image = Resources.edycjam;
                DeleteButton.Image = Resources.contact_busy_overlay;

                if (dataGridView1.SelectedRows.Count > 0)
                    Fill(dataGridView1.SelectedRows[0].Index);
            }
            else if (LanguageTextBox.Text == "")
                MessageBox.Show(_T("choose_language_first"));
            else
            {
                if (MessageBox.Show(_T("delete_q") + " " + PolishNameTextBox.Text.Trim() + "?", _T("language_deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Command = new OdbcCommand("DELETE FROM " + this.Table + " WHERE jezyk = ?", NewConnection.AppConnection);
                        Command.Parameters.AddWithValue("@Language", LanguageTextBox.Text.ToUpper());

                        Command.ExecuteNonQuery();

                        MessageBox.Show(_T("language") + " " + PolishNameTextBox.Text.Trim() + " " + _T("was_deleted"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        UpdateView(0);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }

        private void Fill(int Row)
        {
            if (Row >= 0)
            {
                LanguageTextBox.Text = dataGridView1["Język", Row].Value.ToString();
                DigitalCodeTextBox.Text = dataGridView1["Kod cyfrowy", Row].Value.ToString();
                EnglishNameTextBox.Text = dataGridView1["Nazwa angielska", Row].Value.ToString();
                PolishNameTextBox.Text = dataGridView1["Nazwa polska", Row].Value.ToString();
            }
        }

        private void ClearTextBoxes()
        {
            LanguageTextBox.Text = "";
            DigitalCodeTextBox.Text = "";
            EnglishNameTextBox.Text = "";
            PolishNameTextBox.Text = "";
        }

        private void EnableTextBoxes()
        {
            LanguageTextBox.Enabled = true;
            DigitalCodeTextBox.Enabled = true;
            EnglishNameTextBox.Enabled = true;
            PolishNameTextBox.Enabled = true;
        }

        private void DisableTextBoxes()
        {
            LanguageTextBox.Enabled = false;
            DigitalCodeTextBox.Enabled = false;
            EnglishNameTextBox.Enabled = false;
            PolishNameTextBox.Enabled = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Fill(e.RowIndex);
                AddButton.Text = _T("add");
                EditButton.Text = _T("edit");
                DeleteButton.Text = _T("delete");
                AddButton.Enabled = true;
                CloseButton.Enabled = true;

                DisableTextBoxes();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (AddButton.Text == _T("add"))
            {
                AddButton.Text = _T("save");
                EditButton.Text = _T("cancel");
                DeleteButton.Enabled = false;
                CloseButton.Enabled = false;
                EnableTextBoxes();
                ClearTextBoxes();

                AddButton.Image = Resources.save;
                EditButton.Image = Resources.fileclose1;

                LanguageTextBox.Focus();
            }
            else if (AddButton.Text == _T("save"))
            {
                if (LanguageTextBox.Text == "" || DigitalCodeTextBox.Text == "" || EnglishNameTextBox.Text == "" || PolishNameTextBox.Text == "")
                {
                    MessageBox.Show(_T("fill_all_values"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!IsLanguageNameAvalaible(LanguageTextBox.Text, "jezyk"))
                {
                    MessageBox.Show(_T("language_name_exists"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!IsLanguageNameAvalaible(DigitalCodeTextBox.Text, "j_kod_cyfr"))
                {
                    MessageBox.Show(_T("language_dc_exists"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!IsLanguageNameAvalaible(EnglishNameTextBox.Text, "j_an_nazwa"))
                {
                    MessageBox.Show(_T("language_english_name_exists"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!IsLanguageNameAvalaible(PolishNameTextBox.Text, "j_pl_nazwa"))
                {
                    MessageBox.Show(_T("language_polish_name_exists"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        Command = new OdbcCommand("INSERT INTO " + this.Table + " (jezyk, j_kod_cyfr, j_an_nazwa, j_pl_nazwa) VALUES (?, ?, ?, ?); ", NewConnection.AppConnection);

                        Command.Parameters.AddWithValue("@Language", LanguageTextBox.Text.ToUpper());
                        Command.Parameters.AddWithValue("@DigitalCode", DigitalCodeTextBox.Text);
                        Command.Parameters.AddWithValue("@EnglishName", EnglishNameTextBox.Text);
                        Command.Parameters.AddWithValue("@PolishName", PolishNameTextBox.Text);

                        Command.ExecuteNonQuery();

                        MessageBox.Show(_T("language_added") + " !", _T("data_save"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string TempName = PolishNameTextBox.Text;

                        UpdateView(0);

                        DisableTextBoxes();
                        AddButton.Text = _T("add");
                        EditButton.Text = _T("edit");
                        DeleteButton.Enabled = true;
                        CloseButton.Enabled = true;

                        AddButton.Image = Resources.edit_add;
                        EditButton.Image = Resources.edycjam;

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1["Nazwa polska", i].Value.ToString().ToLower() == TempName.ToLower())
                            {
                                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1["Nazwa polska", i].RowIndex;
                                dataGridView1["Język", i].Selected = true;
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;

                                Fill(dataGridView1["Nazwa polska", i].RowIndex);

                                break;
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }

                   /* DisableTextBoxes();
                    AddButton.Text = _T("add");
                    EditButton.Text = _T("edit");
                    DeleteButton.Enabled = true;
                    CloseButton.Enabled = true;*/
                }             
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (EditButton.Text == _T("cancel"))
            {
                AddButton.Text = _T("add");
                EditButton.Text = _T("edit");
                CloseButton.Enabled = true;
                DeleteButton.Enabled = true;
                ClearTextBoxes();
                DisableTextBoxes();

                AddButton.Image = Resources.edit_add;
                EditButton.Image = Resources.edycjam;

                if (dataGridView1.Rows.Count > 0)
                    Fill(0);
            }
            else if (EditButton.Text == _T("edit"))
            {
                if (LanguageTextBox.Text == "")
                    MessageBox.Show(_T("choose_language_first"));
                else
                {
                    AddButton.Enabled = false;
                    EditButton.Text = _T("save");
                    CloseButton.Enabled = false;
                    DeleteButton.Text = _T("cancel");

                    EditButton.Image = Resources.save;
                    DeleteButton.Image = Resources.fileclose1;

                    EnableTextBoxes();
                }
            }
            else if (EditButton.Text == _T("save"))
            {
                if (LanguageTextBox.Text == "" || DigitalCodeTextBox.Text == "" || EnglishNameTextBox.Text == "" || PolishNameTextBox.Text == "")
                {
                    MessageBox.Show(_T("fill_all_values"));
                }
                else
                {
                    try
                    {
                        Command = new OdbcCommand();
                        Command.Connection = NewConnection.AppConnection;
                        Command.CommandText = "UPDATE " + this.Table + " SET jezyk = ?, j_kod_cyfr = ?, j_an_nazwa = ?, j_pl_nazwa = ? " +
                                              " WHERE jezyk = ?; ";

                        Command.Parameters.AddWithValue("@Language", LanguageTextBox.Text.ToUpper());                   
                        Command.Parameters.AddWithValue("@DigitalCode", DigitalCodeTextBox.Text);
                        Command.Parameters.AddWithValue("@EnglishName", EnglishNameTextBox.Text);
                        Command.Parameters.AddWithValue("@PolishName", PolishNameTextBox.Text);
                        Command.Parameters.AddWithValue("@LanguageOld", dataGridView1["Język", dataGridView1.CurrentRow.Index].Value.ToString());

                        Command.ExecuteNonQuery();

                        MessageBox.Show(_T("modified"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string TempName = PolishNameTextBox.Text;

                        EditButton.Image = Resources.edycjam;
                        DeleteButton.Image = Resources.contact_busy_overlay;

                        UpdateView(0);

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1["Nazwa polska", i].Value.ToString().ToLower() == TempName.ToLower())
                            {
                                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1["Nazwa polska", i].RowIndex;
                                dataGridView1["Język", i].Selected = true;
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;

                                Fill(dataGridView1["Nazwa polska", i].RowIndex);

                                break;
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }

                    DisableTextBoxes();
                    EditButton.Text = _T("edit");
                    DeleteButton.Text = _T("delete");
                    AddButton.Enabled = true;
                    CloseButton.Enabled = true;
                }
            }
        }

        private bool IsLanguageNameAvalaible(string Language, string Column)
        {
            /*------------------------------------------------------------------------------ 
            Prototyp: IsUserNameAvalaible(String UserName)

            Przeznaczenie: Sprawdzenie, czy nazwa użytkownika jest dostępna.

            Argumenty: - String UserName

            Wartosc zwracana: bool

            Autor: Krzysztof Rybka

            Data: 06.01.2013
            ------------------------------------------------------------------------------*/

            try
            {
                string UserNameFromDb = "";

                Command = new OdbcCommand("SELECT " + Column + " FROM " + this.Table + " WHERE " + Column + " = ?; ", NewConnection.AppConnection);
                Command.Parameters.AddWithValue("@Param", Language);

                Reader = Command.ExecuteReader();

                while (Reader.Read())
                    UserNameFromDb = Reader.GetValue(0).ToString();

                Reader.Close();

                if (Language.ToUpper().Trim() == UserNameFromDb.ToUpper().Trim())
                    return false;
                else
                    return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(_T("error") + "\n" + Ex.Message);
                return false;
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                Fill(dataGridView1.CurrentRow.Index);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {           
            if (dataGridView1.CurrentRow != null)
                Fill(dataGridView1.CurrentRow.Index);

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SearchText = "";
                label1.Text = "";
            }
        }

        private void Languages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
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

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {                
                if (dataGridView1.Rows[i].Cells["Nazwa polska"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1["Nazwa polska", i];
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }                
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search(e.KeyChar.ToString());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SearchText = "";
            label1.Text = "";
        }
    }
}
