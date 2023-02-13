
﻿
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using System.Threading;
                                                                                                                                    
namespace WindowsFormsApplication1
{
    public partial class Users : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private DataTable Dt;
        private string Table = "dbo.login";

        private Dictionary<int, string> RodzajeDictionary;

        private string SearchText;

        public Users()
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            RodzajeDictionary = new Dictionary<int, string>();
            SetRodzajeDictionary();
            SearchText = "";
            label1.Text = "";            

            DisableTextBoxes();
            UpdateView();

            if (!Settings.IsAdminLogged)
            {
                if (DeleteButton.Text.ToLower() == "usuń")
                    DeleteButton.Enabled = false;

                AddButton.Enabled = false;
            }

            dataGridView1.Focus();
            dataGridView1.Select();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "co_liber_users");
            mapping.Add(label7, "last_name");
            mapping.Add(label6, "first_name");
            mapping.Add(label13, "searching");
            mapping.Add(RodzajeComboBox, "main_inventory");
            mapping.Add(label5, "starting_books_collection");
            mapping.Add(label4, "rights");
            mapping.Add(label3, "repeat_password");
            mapping.Add(label2, "password");
            mapping.Add(label12, "name");
            mapping.Add(CloseButton, "exit");
            mapping.Add(DeleteButton, "delete");
            mapping.Add(EditButton, "edit");
            mapping.Add(AddButton, "add");
            mapping.Add(Nazwa, "name");
            mapping.Add(Prawa, "rights");
            mapping.Add(firstNameDGVC, "first_name");
            mapping.Add(nameDGVC, "last_name");
            mapping.Add(ksiegozbiorStartowy, "starting_books_collection");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void SetRodzajeDictionary()
        {
            SqlCommand Command = new SqlCommand();

            Command.CommandText = "SELECT id_rodzaj, LTRIM(RTRIM(nazwa)) AS nazwa FROM rodzaje ORDER BY nazwa; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.coliberConnection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                RodzajeDictionary.Add((int)Dt.Rows[i]["id_rodzaj"], Dt.Rows[i]["nazwa"].ToString());
            }

            RodzajeComboBox.DataSource = new BindingSource(RodzajeDictionary, null);
            RodzajeComboBox.ValueMember = "Key";
            RodzajeComboBox.DisplayMember = "Value";
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RightsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void UpdateView()
        {
            try
            {
                SqlCommand Command = new SqlCommand();

                //Command.CommandText = " SELECT id AS [ID], RTRIM(LTRIM(login.nazwa)) AS [Nazwa], RTRIM(LTRIM(prawa)) AS [Prawa], id_rodzaj, '**********' AS haslo, rodzaje.nazwa AS [Księgozbiór startowy] FROM " + this.Table + " AS login INNER JOIN rodzaje ON baza_start = rodzaje.id_rodzaj ";
                Command.CommandText = " SELECT id, RTRIM(LTRIM(login.nazwa)) AS nazwa, RTRIM(LTRIM(prawa)) AS prawa, id_rodzaj, LTRIM(RTRIM(imie)) AS imie, LTRIM(RTRIM(nazwisko)) AS nazwisko, rodzaje.nazwa AS ksiegozbiorStartowy FROM " + this.Table + " AS login INNER JOIN rodzaje ON baza_start = rodzaje.id_rodzaj WHERE deleted = 0 ";

                if (!Settings.IsAdminLogged)
                {
                    Command.CommandText += " AND login.nazwa = @nazwa ";
                    Command.Parameters.AddWithValue("@nazwa", Settings.Login);
                }

                Command.CommandText += " ORDER BY dbo.Expand(login.nazwa, 6, 30); ";
               
                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.coliberConnection);
                dataGridView1.DataSource = Dt;
                

                DisableTextBoxes();
                ClearTextBoxes();
                Fill(0);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                this.Close();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if ((EditButton.Text == _T("save"))) 
                {
                    if (MessageBox.Show(_T("cancel_q") + UserNameTextBox.Text , "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Fill(e.RowIndex);
                        AddButton.Text = _T("add");
                        EditButton.Text = _T("edit");
                        DisableTextBoxes();

                        AddButton.Enabled = true;
                        CloseButton.Enabled = true;
                        //RightsButton.Enabled = false;
                    }
                }
                else if (AddButton.Text == _T("save"))
                {
                    if (MessageBox.Show(_T("cancle_q"), "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Fill(e.RowIndex);
                        AddButton.Text = _T("add");
                        EditButton.Text = _T("edit");
                        DisableTextBoxes();

                        AddButton.Enabled = true;
                        CloseButton.Enabled = true;
                        //RightsButton.Enabled = false;
                    }
                }
                else
                {
                    Fill(e.RowIndex);
                    AddButton.Text = _T("add");
                    EditButton.Text = _T("edit");
                    DisableTextBoxes();
                    
                    AddButton.Enabled = true;
                    CloseButton.Enabled = true;
                    //RightsButton.Enabled = false;
                }
            }
        }

        private void Fill(int Row)
        {
            if (Row >= 0 && dataGridView1.Rows.Count > 0)
            {
                IDTextBox.Text = dataGridView1["ID", Row].Value.ToString();
                UserNameTextBox.Text = dataGridView1["Nazwa", Row].Value.ToString();
                PassTextBox.Text = "";
                Pass2TextBox.Text = "";
                RightsTextBox.Text = dataGridView1["Prawa", Row].Value.ToString();
                RodzajeComboBox.SelectedValue = dataGridView1["id_rodzaj", Row].Value;
                firstNameTextBox.Text = dataGridView1["firstNameDGVC", Row].Value.ToString();
                nameTextBox.Text = dataGridView1["nameDGVC", Row].Value.ToString();
            }
        }

        private void ClearTextBoxes()
        {
            IDTextBox.Text = "";
            UserNameTextBox.Text = "";
            PassTextBox.Text = "";
            Pass2TextBox.Text = "";
            RightsTextBox.Text = "";
            firstNameTextBox.Text = "";
            nameTextBox.Text = "";
        }

        private void EnableTextBoxes()
        {
            IDTextBox.Enabled = true;
            UserNameTextBox.Enabled = true;
            PassTextBox.Enabled = true;
            Pass2TextBox.Enabled = true;
            RightsTextBox.Enabled = true;            
            RodzajeComboBox.Enabled = true;
            firstNameTextBox.Enabled = true;
            nameTextBox.Enabled = true;
        }

        private void DisableTextBoxes()
        {
            IDTextBox.Enabled = false;
            UserNameTextBox.Enabled = false;
            PassTextBox.Enabled = false;
            Pass2TextBox.Enabled = false;
            RightsTextBox.Enabled = false;            
            RodzajeComboBox.Enabled = false;
            firstNameTextBox.Enabled = false;
            nameTextBox.Enabled = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (EditButton.Text == _T("edit"))
            {
                if (UserNameTextBox.Text == "")
                    MessageBox.Show(_T("choose_user_first"));
                else
                {
                    EditButton.Text = _T("save");
                    DeleteButton.Text = _T("cancel");
                    EnableTextBoxes();
                    AddButton.Enabled = false;
                    CloseButton.Enabled = false;
                    DeleteButton.Enabled = true;
                    //RightsButton.Enabled = true;                    

                    DeleteButton.Image = Resources.fileclose1;
                    EditButton.Image = Resources.save;
                    dataGridView1.Enabled = false;
                }
            }
            else if (EditButton.Text == _T("cancel"))
            {
                AddButton.Text = _T("add");
                EditButton.Text = _T("edit");

                DisableTextBoxes();
                CloseButton.Enabled = true;
                DeleteButton.Enabled = true;
                //RightsButton.Enabled = false;
                //WypozyczalniaButton.Enabled = false;
                DeleteButton.Enabled = true;
                dataGridView1.Enabled = true;
                
                if (!Settings.IsAdminLogged)
                {
                    DeleteButton.Enabled = false;
                    //RightsButton.Enabled = false;
                    //WypozyczalniaButton.Enabled = false;
                    DeleteButton.Enabled = false;
                }

                AddButton.Image = Resources.edit_add;
                EditButton.Image = Resources.edycjam;

                if (dataGridView1.Rows.Count > 0)
                    Fill(0);
            }
            else if (EditButton.Text == _T("save"))
            {
                bool Pass;

                if (UserNameTextBox.Text == "" && RightsTextBox.Text == "")
                {
                    MessageBox.Show(_T("fill_all_values"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!IsUserNameAvailable(UserNameTextBox.Text.Trim(), IDTextBox.Text))
                {
                    MessageBox.Show(_T("value_repeated_enter_new"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (PassTextBox.Text != Pass2TextBox.Text)
                    {
                        MessageBox.Show(_T("different_passwords"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Pass = PassTextBox.Text != "";

                        try
                        {
                            SqlCommand Command = new SqlCommand();
                            
                            /*Command.CommandText = "UPDATE " + this.Table + " SET nazwa = @nazwa, prawa = @prawa, baza_start = @baza, imie = @imie, nazwisko = @nazwisko " + Pass +
                                                  " WHERE id = @id; ";*/
                            Command.CommandText = "EXEC PA_Users_Edit @nazwa, @haslo, @prawa, @baza, @imie, @nazwisko, @changePassword, @id; ";

                            Command.Parameters.AddWithValue("@nazwa", UserNameTextBox.Text.Trim().ToUpper());
                            Command.Parameters.AddWithValue("@prawa", RightsTextBox.Text);                            
                            Command.Parameters.AddWithValue("@baza", RodzajeComboBox.SelectedValue);
                            Command.Parameters.AddWithValue("@imie", firstNameTextBox.Text.Trim());
                            Command.Parameters.AddWithValue("@nazwisko", nameTextBox.Text.Trim());
                            Command.Parameters.AddWithValue("@changePassword", Pass);
                            Command.Parameters.Add("@haslo", SqlDbType.VarChar).Value = PassTextBox.Text;

                            Command.Parameters.AddWithValue("@id", IDTextBox.Text);

                            if (CommonFunctions.WriteData(Command, ref Settings.coliberConnection))
                                MessageBox.Show(_T("modified"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                return;

                            string TempName = UserNameTextBox.Text;
                            dataGridView1.Enabled = true;

                            ClearTextBoxes();
                            EditButton.Text = _T("edit");
                            DeleteButton.Text = _T("delete");

                            AddButton.Enabled = true;
                            CloseButton.Enabled = true;                           

                            if (!Settings.IsAdminLogged)
                            {
                                AddButton.Enabled = false;
                                DeleteButton.Enabled = false;
                            }

                            EditButton.Image = Resources.edycjam;
                            DeleteButton.Image = Resources.contact_busy_overlay;

                            DisableTextBoxes();
                            UpdateView();

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1["Nazwa", i].Value.ToString().ToLower() == TempName.ToLower())
                                {
                                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1["Nazwa", i].RowIndex;
                                    dataGridView1["Nazwa", i].Selected = true;
                                    //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;

                                    Fill(dataGridView1["Nazwa", i].RowIndex);

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
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (AddButton.Text == _T("add"))
            {
                EnableTextBoxes();
                ClearTextBoxes();
                AddButton.Text = _T("save");
                EditButton.Text = _T("cancel");
                CloseButton.Enabled = false;
                DeleteButton.Enabled = false;
                //RightsButton.Enabled = true;
                //WypozyczalniaButton.Enabled = true;
                RodzajeComboBox.Enabled = true;
                dataGridView1.Enabled = false;

                AddButton.Image = Resources.save;
                EditButton.Image = Resources.fileclose1;

                UserNameTextBox.Focus();

                RightsTextBox.Text = _T("");
            }
            else if (AddButton.Text == _T("save"))
            {
                if (UserNameTextBox.Text == "" || PassTextBox.Text == "" || RightsTextBox.Text == "")// || StartBaseTextBox.Text == "")
                {
                    MessageBox.Show(_T("fill_all_values"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!IsUserNameAvailable(UserNameTextBox.Text.Trim(), "-1"))
                {
                    MessageBox.Show(_T("value_repeated_enter_new"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (PassTextBox.Text != Pass2TextBox.Text)
                {
                    MessageBox.Show(_T("different_passwords"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    AddUser();
                }
            }
        }

        private void AddUser()
        {
            try
            {
                //int ID = GetIDFromProcedure("login");
                //Command = new OdbcCommand("INSERT INTO " + this.Table + " (id, nazwa, haslo, prawa, baza_start) VALUES (?, ?, CONVERT(VARCHAR(42), HASHBYTES('MD5', ?), 2), ?, ?); ", NewConnection.AppConnection);
                SqlCommand Command = new SqlCommand();
                //Command.CommandText = "INSERT INTO " + this.Table + " (nazwa, haslo, prawa, baza_start, imie, nazwisko) VALUES (@nazwa, CONVERT(VARCHAR(42), HASHBYTES('MD5', @haslo), 2), @prawa, @baza, @imie, @nazwisko); ";
                Command.CommandText = "EXEC PA_Users_Add @nazwa, @haslo, @prawa, @baza, @imie, @nazwisko; ";
                //Command.Parameters.AddWithValue("@ID", ID);
                Command.Parameters.AddWithValue("@nazwa", UserNameTextBox.Text.ToUpper());
                Command.Parameters.Add("@haslo", SqlDbType.VarChar).Value = PassTextBox.Text;
                Command.Parameters.AddWithValue("@prawa", RightsTextBox.Text);
                //Command.Parameters.AddWithValue("@Baza", StartBaseTextBox.Text);
                Command.Parameters.AddWithValue("@baza", RodzajeComboBox.SelectedValue);
                Command.Parameters.AddWithValue("@imie", firstNameTextBox.Text.Trim());
                Command.Parameters.AddWithValue("@nazwisko", nameTextBox.Text.Trim());

                
                if(CommonFunctions.WriteData(Command, ref Settings.coliberConnection))
                    MessageBox.Show(_T("user_added"), _T("user_adding"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else                
                    return;                

                string TempName = UserNameTextBox.Text;

                UpdateView();

                AddButton.Text = _T("add");
                EditButton.Text = _T("edit");
                CloseButton.Enabled = true;
                DeleteButton.Enabled = true;
                //RightsButton.Enabled = false;
                dataGridView1.Enabled = true;

                AddButton.Image = Resources.edit_add;
                EditButton.Image = Resources.edycjam;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1["Nazwa", i].Value.ToString().ToLower() == TempName.ToLower())
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1["Nazwa", i].RowIndex;
                        dataGridView1["Nazwa", i].Selected = true;
                        //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;

                        Fill(dataGridView1["Nazwa", i].RowIndex);

                        break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private bool IsUserNameAvailable(string UserName, string id)
        {
            /*------------------------------------------------------------------------------ 
            Prototyp: IsUserNameAvailable(String UserName)

            Przeznaczenie: Sprawdzenie, czy nazwa użytkownika jest dostępna.

            Argumenty: - String UserName

            Wartosc zwracana: bool

            Autor: Krzysztof Rybka

            Data: 06.01.2013
            ------------------------------------------------------------------------------*/

            try
            {
                SqlCommand Command = new SqlCommand("SELECT 1 FROM dbo.login WHERE LTRIM(RTRIM(nazwa)) = @nazwa AND id != @id; ");
                Command.Parameters.AddWithValue("@nazwa", UserName.Trim());
                Command.Parameters.AddWithValue("@id", id);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.coliberConnection);

                return !(Dt.Rows.Count > 0);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _T("error"));
                return false;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (DeleteButton.Text == _T("cancel"))
            {
                AddButton.Enabled = true;
                CloseButton.Enabled = true;
                //RightsButton.Enabled = false;
                EditButton.Text = _T("edit");
                DeleteButton.Text = _T("delete");
                DisableTextBoxes();
                //ClearTextBoxes();
                dataGridView1.Enabled = true;

                DeleteButton.Image = Resources.contact_busy_overlay;
                EditButton.Image = Resources.edycjam;

                if (!Settings.IsAdminLogged && DeleteButton.Text.ToLower() == _T("delete"))
                    DeleteButton.Enabled = false;

                if (!Settings.IsAdminLogged)
                    AddButton.Enabled = false;
                
            }           
            else if (DeleteButton.Text == _T("delete"))
            {
                if (UserNameTextBox.Text.ToLower().Trim() == "admin")
                {
                    MessageBox.Show(_T("admin_cannot_be_deleted"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (UserNameTextBox.Text == "")
                    MessageBox.Show(_T("choose_user_first"));
                else
                {
                    if (MessageBox.Show(_T("delete_user_q") + " " + UserNameTextBox.Text + "?", _T("user_deleting"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) 
                    {
                        try
                        {
                            SqlCommand Command = new SqlCommand("EXEC PA_Users_Delete @id; ");
                            Command.Parameters.AddWithValue("@id", IDTextBox.Text);

                            if (CommonFunctions.WriteData(Command, ref Settings.coliberConnection))
                            {
                                MessageBox.Show(_T("user") + " " + UserNameTextBox.Text + " " + _T("was_deleted"), _T("user_deleting"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                UpdateView();
                            }
                            else
                               return;
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message);
                        }
                    }
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dataGridView1.HitTest(e.X, e.Y).RowIndex >= 0 && (AddButton.Text != _T("add") || EditButton.Text != _T("edit")) && dataGridView1.HitTest(e.X, e.Y).ColumnIndex >= 0)
                {
                    if (dataGridView1[dataGridView1.HitTest(e.X, e.Y).ColumnIndex, dataGridView1.HitTest(e.X, e.Y).RowIndex].ColumnIndex == dataGridView1.Columns["Nazwa"].Index)
                        UserNameTextBox.Text = dataGridView1[dataGridView1.HitTest(e.X, e.Y).ColumnIndex, dataGridView1.HitTest(e.X, e.Y).RowIndex].Value.ToString();
                    if (dataGridView1[dataGridView1.HitTest(e.X, e.Y).ColumnIndex, dataGridView1.HitTest(e.X, e.Y).RowIndex].ColumnIndex == dataGridView1.Columns["Prawa"].Index)
                        RightsTextBox.Text = dataGridView1[dataGridView1.HitTest(e.X, e.Y).ColumnIndex, dataGridView1.HitTest(e.X, e.Y).RowIndex].Value.ToString();

                    Clipboard.SetText(dataGridView1[dataGridView1.HitTest(e.X, e.Y).ColumnIndex, dataGridView1.HitTest(e.X, e.Y).RowIndex].Value.ToString());
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                Fill(dataGridView1.CurrentRow.Index);

            Search(e.KeyChar.ToString());
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

        private void NameTextBox_Enter(object sender, EventArgs e)
        {
            PassTextBox.SelectAll();
        }

        private void PassTextBox_Enter(object sender, EventArgs e)
        {
            PassTextBox.SelectAll();
        }

        private void Pass2TextBox_Enter(object sender, EventArgs e)
        {
            Pass2TextBox.SelectAll();
        }

        private void Users_KeyDown(object sender, KeyEventArgs e)
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
                if (dataGridView1.Rows[i].Cells["Nazwa"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1["Nazwa", i];
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
