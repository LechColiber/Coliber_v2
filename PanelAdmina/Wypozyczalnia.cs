using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace WindowsFormsApplication1
{
    public partial class Wypozyczalnia : Form
    {
        Connection NewConnection;
        string Table = "dbo.w2_pracownicy";

        public Wypozyczalnia(string Login, string Password)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;

            this.LoginTextBox.Text = Login;
            this.PassTextBox.Text = Password;
            this.Pass2TextBox.Text = Password;
        }

        private void Wypozyczalnia_Load(object sender, EventArgs e)
        {
            try
            {
                NewConnection = new Connection("WYPOZYCZ.ini");
                NewConnection.AppConnection.Open();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                this.Dispose();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anulować?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                this.Dispose();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!IsUserNameAvalaible(LoginTextBox.Text))
            {
                MessageBox.Show("Użytkownik o takim loginie już istnieje!");
            }
            else if (LoginTextBox.Text == "" || PassTextBox.Text == "" || NameTextBox.Text == "" || SurnameTextBox.Text == "" || TimeExpiredTextBox.Text == "" || EmergencyTextBox.Text == "")
            {
                MessageBox.Show("Uzupełnij pola!");
            }
            else if (PassTextBox.Text != Pass2TextBox.Text)
            {
                MessageBox.Show("Hasła nie są jednakowe!");
            }
            else
            {
                try
                {
                    OdbcCommand Command = new OdbcCommand();
                    Command.Connection = NewConnection.AppConnection;
                    Command.CommandText = "INSERT INTO " + this.Table + " (login, haslo, imie, nazwisko, waznosc_hasla, data_zm_hasla, logow_awar, uwagi, ustawienia) " +
                                           " VALUES (?, CONVERT(VARCHAR(42), HASHBYTES('MD5', ?), 2), ?, ?, ?, ?, ?, ?, ?)";
                    Command.Parameters.Add("@Login", OdbcType.VarChar).Value = LoginTextBox.Text.ToUpper();
                    Command.Parameters.Add("@Haslo", OdbcType.VarChar).Value = PassTextBox.Text;
                    Command.Parameters.Add("@Imie", OdbcType.VarChar).Value = NameTextBox.Text;
                    Command.Parameters.Add("@Nazwisko", OdbcType.VarChar).Value = SurnameTextBox.Text;
                    Command.Parameters.Add("@Waznosc", OdbcType.SmallInt).Value = TimeExpiredTextBox.Text;
                    Command.Parameters.Add("@Data_zmiany", OdbcType.SmallDateTime).Value = DateTime.Now.ToString();
                    Command.Parameters.Add("@Max_log_aw", OdbcType.TinyInt).Value = EmergencyTextBox.Text;
                    Command.Parameters.Add("@Uwagi", OdbcType.Text).Value = CommentsTextBox.Text;
                    Command.Parameters.Add("@Ustawienia", OdbcType.Text).Value = SettingsTextBox.Text;

                    Command.ExecuteNonQuery();
                    MessageBox.Show("Dodano użytkownika!");
                    this.Dispose();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void TimeExpiredTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
                e.Handled = false;
            if (e.KeyChar == '.')
                e.Handled = true;
        }

        private void TimeExpiredTextBox_Leave(object sender, EventArgs e)
        {
            if (TimeExpiredTextBox.Text != "" && Int32.Parse(TimeExpiredTextBox.Text) > 32767)
            {
                MessageBox.Show("Wartość nie może być większa niż 32 767!");
                TimeExpiredTextBox.Focus();
            }
            /*else if (TimeExpiredTextBox.Text == "")
            {
                MessageBox.Show("Pole nie może być puste!");
                TimeExpiredTextBox.Focus();
            }*/
        }

        private void EmergencyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
                e.Handled = false;
            if (e.KeyChar == '.')
                e.Handled = true;
        }

        private void EmergencyTextBox_Leave(object sender, EventArgs e)
        {
            if (EmergencyTextBox.Text != "" && Int32.Parse(EmergencyTextBox.Text) > 255)
            {
                MessageBox.Show("Wartość nie może być większa niż 255!");
                EmergencyTextBox.Focus();
            }
            /*else if (EmergencyTextBox.Text == "")
            {
                MessageBox.Show("Pole nie może być puste!");
                EmergencyTextBox.Focus();
            }*/
        }

        private bool IsUserNameAvalaible(string UserName)
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

                OdbcCommand Command = new OdbcCommand("SELECT RTRIM(LTRIM(login)) FROM " + this.Table + " WHERE login = ?", NewConnection.AppConnection);
                Command.Parameters.AddWithValue("@Login", UserName);

                OdbcDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                    UserNameFromDb = Reader.GetValue(0).ToString();

                Reader.Close();

                if (UserName.ToUpper().Trim() == UserNameFromDb.ToUpper().Trim())
                    return false;
                else
                    return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Błąd!\n" + Ex.Message);
                return false;
            }
        }

        private void TimeExpiredTextBox_Enter(object sender, EventArgs e)
        {
            TimeExpiredTextBox.SelectAll();
        }

        private void LoginTextBox_Enter(object sender, EventArgs e)
        {
            LoginTextBox.SelectAll();
        }

        private void PassTextBox_Enter(object sender, EventArgs e)
        {
            PassTextBox.SelectAll();
        }

        private void Pass2TextBox_Enter(object sender, EventArgs e)
        {
            Pass2TextBox.SelectAll();
        }

        private void NameTextBox_Enter(object sender, EventArgs e)
        {
            NameTextBox.SelectAll();
        }

        private void SurnameTextBox_Enter(object sender, EventArgs e)
        {
            SurnameTextBox.SelectAll();
        }

        private void EmergencyTextBox_Enter(object sender, EventArgs e)
        {
            EmergencyTextBox.SelectAll();
        }

        private void CommentsTextBox_Enter(object sender, EventArgs e)
        {
            CommentsTextBox.SelectAll();
        }

        private void SettingsTextBox_Enter(object sender, EventArgs e)
        {
            SettingsTextBox.SelectAll();
        }

        private void Wypozyczalnia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }
    }
}
