using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using System.Threading;


namespace WindowsFormsApplication1
{
    public partial class Countries : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }

        private Connection NewConnection;
        private OdbcCommand Command;
        private DataTable Dt;
        private OdbcDataReader Reader;

        private string TempCountryName;
        private string SearchText;

        public Countries(Connection NewConnection)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.StartPosition = FormStartPosition.CenterParent;

            this.NewConnection = NewConnection;

            dataGridView1.Select();
            label1.Text = "";
            SearchText = "";
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this,"countries");
            mapping.Add(label7,"searching");
            mapping.Add(EditButton,"edit");
            mapping.Add(CloseButton,"exit");
            mapping.Add(DeleteButton,"delete");
            mapping.Add(AddButton,"add");
            mapping.Add(label6,"country_digit_code");
            mapping.Add(label5,"code");
            mapping.Add(label4,"polish_name");
            mapping.Add(label3,"english_name");
            mapping.Add(label2,"short_name");
            mapping.Add(label9,"country");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Countries_Load(object sender, EventArgs e)
        {
            DisableTextBoxes();

            UpdateView();
            Fill(0);
        }

        private void DisableTextBoxes()
        {
            CountryTextBox.Enabled = false;
            Code2TextBox.Enabled = false;
            DigitalCodeTextBox.Enabled = false;
            ShortNameTextBox.Enabled = false;
            EnglishNameTextBox.Enabled = false;
            PolishNameTextBox.Enabled = false;
        }

        private void EnableTextBoxes()
        {
            CountryTextBox.Enabled = true;
            Code2TextBox.Enabled = true;
            DigitalCodeTextBox.Enabled = true;
            ShortNameTextBox.Enabled = true;
            EnglishNameTextBox.Enabled = true;
            PolishNameTextBox.Enabled = true;
        }

        private void Fill(int Row)
        {
            try
            {
                if (Row >= 0)
                {
                    CountryTextBox.Text = dataGridView1["ID", Row].Value.ToString();
                    Code2TextBox.Text = dataGridView1["Kod2", Row].Value.ToString();
                    DigitalCodeTextBox.Text = dataGridView1["Kod cyfrowy", Row].Value.ToString();
                    ShortNameTextBox.Text = dataGridView1["Nazwa krótka", Row].Value.ToString();
                    EnglishNameTextBox.Text = dataGridView1["Nazwa angielska", Row].Value.ToString();
                    PolishNameTextBox.Text = dataGridView1["Nazwa polska", Row].Value.ToString();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(Ex.Message);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (AddButton.Text == _T("add"))
            {
                CountryTextBox.Text = "";
                Code2TextBox.Text = "";
                DigitalCodeTextBox.Text = "";
                ShortNameTextBox.Text = "";
                EnglishNameTextBox.Text = "";
                PolishNameTextBox.Text = "";

                AddButton.Text = _T("save");
                EditButton.Text = _T("cancel");
                CloseButton.Enabled = false;
                DeleteButton.Enabled = false;

                dataGridView1.Enabled = false;
                EnableTextBoxes();

                CountryTextBox.Focus();

                AddButton.Image = Resources.save;
                EditButton.Image = Resources.fileclose1;
            }
            else if (AddButton.Text == _T("save"))
            {
                AddUser();
            }
        }

        private void UpdateView()
        {
            try
            {
                Command = new OdbcCommand();

                Command.CommandText = "SELECT LTRIM(RTRIM(panstwo)) AS [ID], LTRIM(RTRIM(kod2)) AS [Kod2], LTRIM(RTRIM(p_kod_cyfr)) AS [Kod cyfrowy], LTRIM(RTRIM(p_sk_nazwa)) AS [Nazwa krótka], LTRIM(RTRIM(p_an_nazwa)) AS [Nazwa angielska], LTRIM(RTRIM(p_pl_nazwa)) AS [Nazwa polska] FROM dbo.panstwa ORDER BY p_sk_nazwa;";
                Command.Connection = NewConnection.AppConnection;

                Reader = Command.ExecuteReader();

                Dt = new DataTable();

                Dt.Columns.Add("ID");
                Dt.Columns.Add("Kod2");
                Dt.Columns.Add("Kod cyfrowy");
                Dt.Columns.Add("Nazwa krótka");
                Dt.Columns.Add("Nazwa angielska");
                Dt.Columns.Add("Nazwa polska");

                Dt.Load(Reader);

                dataGridView1.DataSource = Dt;

                dataGridView1.Columns["ID"].Width = 38;
                dataGridView1.Columns["Kod2"].Width = 38;
                dataGridView1.Columns["Kod cyfrowy"].Width = 46;
                dataGridView1.Columns["Nazwa krótka"].Width = 200;
                dataGridView1.Columns["Nazwa angielska"].Width = 202;
                dataGridView1.Columns["Nazwa polska"].Width = 250;

                dataGridView1.Columns["ID"].HeaderText = "ID";
                dataGridView1.Columns["Kod2"].HeaderText = "Kod2";
                dataGridView1.Columns["Kod cyfrowy"].HeaderText = _T("digit_code");
                dataGridView1.Columns["Nazwa krótka"].HeaderText = _T("short_name");
                dataGridView1.Columns["Nazwa angielska"].HeaderText = _T("english_name");
                dataGridView1.Columns["Nazwa polska"].HeaderText = _T("polish_name");

                Reader.Close();

                dataGridView1.Update();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                this.Close();
            }
        }

        private void AddUser()
        {
            if (CountryTextBox.Text == "" || Code2TextBox.Text == "" || DigitalCodeTextBox.Text == "" || ShortNameTextBox.Text == "" || EnglishNameTextBox.Text == "" || PolishNameTextBox.Text == "")
            {
                MessageBox.Show(_T("fill_all_values"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!IsCountryAvalaible(ShortNameTextBox.Text, "p_sk_nazwa"))
            {
                MessageBox.Show(_T("country_name_exists"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!IsCountryAvalaible(DigitalCodeTextBox.Text, "p_kod_cyfr"))
            {
                MessageBox.Show(_T("country_code_exists"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Command = new OdbcCommand();
                    Command.CommandText = "INSERT INTO dbo.panstwa (panstwo, kod2, p_kod_cyfr, p_sk_nazwa, p_an_nazwa, p_pl_nazwa) VALUES (?, ?, ?, ?, ?, ?); ";
                    Command.Connection = NewConnection.AppConnection;

                    Command.Parameters.AddWithValue("@Country", CountryTextBox.Text);
                    Command.Parameters.AddWithValue("@Code2", Code2TextBox.Text);
                    Command.Parameters.AddWithValue("@DigitalCode", Int32.Parse(DigitalCodeTextBox.Text));
                    Command.Parameters.AddWithValue("@ShortName", ShortNameTextBox.Text);
                    Command.Parameters.AddWithValue("@EnglishName", EnglishNameTextBox.Text);
                    Command.Parameters.AddWithValue("@PolishName", PolishNameTextBox.Text);

                    Command.ExecuteNonQuery();

                    MessageBox.Show(_T("added"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataGridView1.Enabled = true;
                    AddButton.Text = _T("add");
                    EditButton.Text = _T("edit");

                    CloseButton.Enabled = true;
                    DeleteButton.Enabled = true;

                    DisableTextBoxes();

                    AddButton.Image = Resources.edit_add;
                    EditButton.Image = Resources.edycjam;
                   
                    UpdateView();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1["Nazwa krótka", i].Value.ToString().ToLower() == ShortNameTextBox.Text.ToLower())
                        {
                            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1["Nazwa krótka", i].RowIndex;
                            dataGridView1["Nazwa krótka", i].Selected = true;
                            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.CornflowerBlue;

                            Fill(dataGridView1["Nazwa krótka", i].RowIndex);

                            break;
                        } 
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditUser()
        {
            if (CountryTextBox.Text == "" || Code2TextBox.Text == "" || DigitalCodeTextBox.Text == "" || ShortNameTextBox.Text == "" || EnglishNameTextBox.Text == "" || PolishNameTextBox.Text == "")
            {
                MessageBox.Show(_T("fill_all_values"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /*else if (!IsCountryAvalaible(ShortNameTextBox.Text, "p_sk_nazwa"))
            {
                MessageBox.Show(_T("country_name_exists"));
            }
            else if (!IsCountryAvalaible(DigitalCodeTextBox.Text, "p_kod_cyfr"))
            {
                MessageBox.Show(_T("country_code_exists"));
            }*/
            else
            {
                try
                {
                    Command = new OdbcCommand();
                    //Command.CommandText = "INSERT INTO dbo.panstwa (panstwo, kod2, p_kod_cyfr, p_sk_nazwa, p_an_nazwa, p_pl_nazwa) VALUES (@Country, @Code2, @DigitalCode, @ShortName, @EnglishName, @PolishName)";
                    Command.CommandText = "UPDATE dbo.panstwa SET panstwo = ?, kod2 = ?, p_kod_cyfr = ?, p_sk_nazwa = ?, p_an_nazwa = ?, p_pl_nazwa = ? WHERE LTRIM(RTRIM(p_sk_nazwa)) = ?; ";
                    Command.Connection = NewConnection.AppConnection;

                    Command.Parameters.AddWithValue("@Country", CountryTextBox.Text);
                    Command.Parameters.AddWithValue("@Code2", Code2TextBox.Text);
                    Command.Parameters.AddWithValue("@DigitalCode", Int32.Parse(DigitalCodeTextBox.Text));
                    Command.Parameters.AddWithValue("@ShortName", ShortNameTextBox.Text);
                    Command.Parameters.AddWithValue("@EnglishName", EnglishNameTextBox.Text);
                    Command.Parameters.AddWithValue("@PolishName", PolishNameTextBox.Text);
                    Command.Parameters.Add("@OldCountry", OdbcType.VarChar).Value = TempCountryName.Trim();

                    Command.ExecuteNonQuery();

                    MessageBox.Show(_T("modified"), "Edycja państwa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AddButton.Enabled = true;
                    CloseButton.Enabled = true;
                    EditButton.Text = _T("edit");
                    DeleteButton.Text = _T("delete");

                    EditButton.Image = Resources.edycjam;
                    DeleteButton.Image = Resources.contact_busy_overlay;

                    dataGridView1.Enabled = true;
                    DisableTextBoxes();

                    UpdateView();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1["Nazwa krótka", i].Value.ToString().ToLower() == ShortNameTextBox.Text.ToLower())
                        {
                            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1["Nazwa krótka", i].RowIndex;
                            dataGridView1["Nazwa krótka", i].Selected = true;
                            //dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.CornflowerBlue;

                            Fill(dataGridView1["Nazwa krótka", i].RowIndex);

                            break;
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            } 
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (DeleteButton.Text == _T("cancel"))
            {
                EditButton.Text = _T("edit");
                DeleteButton.Text = _T("delete");
                AddButton.Enabled = true;
                CloseButton.Enabled = true;
                dataGridView1.Enabled = true;
                DisableTextBoxes();
                EditButton.Image = Resources.edycjam;
                DeleteButton.Image = Resources.contact_busy_overlay;
            }
            else if (DeleteButton.Text == _T("delete"))
            {
                if (CountryTextBox.Text == "")
                    MessageBox.Show(_T("choose_language_first"));
                else
                {
                    if (MessageBox.Show(_T("to_delete") + " " + _T("country").ToLower() + " " + ShortNameTextBox.Text + " ?", _T("country_deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            Command = new OdbcCommand("DELETE FROM dbo.panstwa WHERE panstwo = ? AND kod2 = ? AND p_kod_cyfr = ? AND p_sk_nazwa = ? AND " +
                                                    "p_an_nazwa = ? AND p_pl_nazwa = ?; ");
                            Command.Connection = NewConnection.AppConnection;

                            Command.Parameters.AddWithValue("@Country", CountryTextBox.Text);
                            Command.Parameters.AddWithValue("@Code2", Code2TextBox.Text);
                            Command.Parameters.AddWithValue("@DigitalCode", Int32.Parse(DigitalCodeTextBox.Text));
                            Command.Parameters.AddWithValue("@ShortName", ShortNameTextBox.Text);
                            Command.Parameters.AddWithValue("@EnglishName", EnglishNameTextBox.Text);
                            Command.Parameters.AddWithValue("@PolishName", PolishNameTextBox.Text);

                            Command.ExecuteNonQuery();

                            MessageBox.Show(_T("removed"), _T("country_deleting"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                            UpdateView();
                            Fill(0);
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message);
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Fill(dataGridView1.CurrentRow.Index);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (EditButton.Text == _T("cancel"))
            {
/*                AddButton.Text = _T("add");
                EditButton.Text = _T("edit");
                
                EditButton.Image = Resources.edycjam;
                DeleteButton.Image = Resources.contact_busy_overlay;
                AddButton.Image = Resources.edit_add;

                DeleteButton.Enabled = true;
                CloseButton.Enabled = true;
                dataGridView1.Enabled = true;
                DisableTextBoxes();
 */

                EditButton.Text = _T("edit");
                AddButton.Text = _T("add");

                DeleteButton.Enabled = true;
                CloseButton.Enabled = true;
                
                dataGridView1.Enabled = true;
                DisableTextBoxes();
                EditButton.Image = Resources.edycjam;
                AddButton.Image = Resources.edit_add;



                if (dataGridView1.Rows.Count > 0)
                    Fill(0);
            }
            else if (EditButton.Text == _T("edit"))
            {
                if (CountryTextBox.Text == "")
                    MessageBox.Show(_T("choose_country_first"));
                else
                {
                    TempCountryName = ShortNameTextBox.Text;

                    EditButton.Text = _T("save");
                    DeleteButton.Text = _T("cancel");

                    AddButton.Enabled = false;
                    CloseButton.Enabled = false;
                    dataGridView1.Enabled = false;
                    EnableTextBoxes();

                    EditButton.Image = Resources.save;
                    DeleteButton.Image = Resources.fileclose1;
                }
            }
            else if (EditButton.Text == _T("save"))
            {
                EditUser();
            }
        }

        private bool IsCountryAvalaible(string Country, string Column)
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

                Command = new OdbcCommand("SELECT " + Column + " FROM dbo.panstwa WHERE " + Column + " = ?; ", NewConnection.AppConnection);
                Command.Parameters.AddWithValue("@Param", Country);

                Reader = Command.ExecuteReader();

                while (Reader.Read())
                    UserNameFromDb = Reader.GetValue(0).ToString();

                Reader.Close();

                if (Country.ToUpper().Trim() == UserNameFromDb.ToUpper().Trim())
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

        private void Countries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
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

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Nazwa krótka"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1["Nazwa polska", i];
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SearchText = "";
            label1.Text = "";
        }
    }
}
