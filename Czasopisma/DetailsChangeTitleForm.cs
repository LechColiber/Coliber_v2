using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Czasopisma
{
    public partial class DetailsChangeTitleForm : Form
    {
        private string ID;
        private string ID2;
        private bool IsNext;

        private bool FirstExists;
        private bool SecondExists;        

        public DetailsChangeTitleForm(string ID, string ID2, bool IsNext, bool ReadOnly = false)
        {
            InitializeComponent();

            setControlsText();

            this.ID = ID;
            this.ID2 = ID2;
            this.IsNext = IsNext;

            this.FirstExists = false;
            this.SecondExists = false;

            YearTextBox.ReadOnly = ReadOnly;
            NumberTextBox.ReadOnly = ReadOnly;

            Year2TextBox.ReadOnly = ReadOnly;
            Number2TextBox.ReadOnly = ReadOnly;

            OkButton.Visible = !ReadOnly;

            LoadData(ID, ID2, IsNext);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(toYearNumberLabel, "to_year_number");
            mapping.Add(label3, "entitled");
            mapping.Add(sinceYearNumberLabel, "since_year_number");
            mapping.Add(label4, "entitled");
            
            mapping.Add(OkButton, "next");
            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "details_of_change_title_of_magazine");

            CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name);
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData(string ID, string ID2, bool IsNext)
        {
            // górny tytuł
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_TitleChangesDetails @ID; ";

            Command.Parameters.AddWithValue("@ID", ID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if(Dt.Rows.Count > 0)
            {
                NumberTextBox.Text = Dt.Rows[0]["numer_zm2"].ToString();
                YearTextBox.Text = Dt.Rows[0]["rok2_zm"].ToString();
                richTextBox1.Text = Dt.Rows[0]["tytul"].ToString();

                if (Dt.Rows[0]["RowExists"].ToString() == "1")
                    FirstExists = true;
            }

            // dolny tytuł
            Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_TitleChangesDetails @ID; ";

            Command.Parameters.AddWithValue("@ID", ID2);

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);
            
            if(Dt.Rows.Count > 0)
            {
                Number2TextBox.Text = Dt.Rows[0]["numer_zm1"].ToString();
                Year2TextBox.Text = Dt.Rows[0]["rok1_zm"].ToString();
                richTextBox2.Text = Dt.Rows[0]["tytul"].ToString();

                if (Dt.Rows[0]["RowExists"].ToString() == "1")
                    SecondExists = true;
            }
        }

        private void DetailsChangeTitleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand();

            // górny tytuł
            if (string.IsNullOrEmpty(NumberTextBox.Text.Trim()) && string.IsNullOrEmpty(YearTextBox.Text.Trim()))
            {
                //Command.CommandText = "DELETE FROM zmiany WHERE kod = @kod1; ";
                Command.CommandText = "EXEC Czasop_ModifyTitleChanges @kod1, 3, 0; ";
                Command.Parameters.AddWithValue("@kod1", this.ID);
                MessageBox.Show("3");
            } 
            else if (FirstExists)
            {
                //Command.CommandText = "UPDATE zmiany SET rok2_zm = @rok1, numer_zm2 = @numer1 WHERE kod = @kod1; ";
                Command.CommandText = "EXEC Czasop_ModifyTitleChanges @kod1, 2, 0, @numer1, @rok1;";

                if(!string.IsNullOrEmpty(YearTextBox.Text.Trim()))
                    Command.Parameters.AddWithValue("@rok1", YearTextBox.Text.Trim());
                else
                    Command.Parameters.AddWithValue("@rok1", DBNull.Value);

                if (!string.IsNullOrEmpty(NumberTextBox.Text.Trim()))
                    Command.Parameters.AddWithValue("@numer1", NumberTextBox.Text.Trim());
                else
                    Command.Parameters.AddWithValue("@numer1", DBNull.Value);

                Command.Parameters.AddWithValue("@kod1", this.ID);
                MessageBox.Show("2");
            }
            else
            {
                //Command.CommandText = "INSERT INTO zmiany (rok2_zm, numer_zm2, kod) VALUES (@rok1, @numer1, @kod1); ";
                Command.CommandText = "EXEC Czasop_ModifyTitleChanges @kod1, 1, 0, @numer1, @rok1; ";

                if (!string.IsNullOrEmpty(YearTextBox.Text.Trim()))
                    Command.Parameters.AddWithValue("@rok1", YearTextBox.Text.Trim());
                else
                    Command.Parameters.AddWithValue("@rok1", DBNull.Value);

                if (!string.IsNullOrEmpty(NumberTextBox.Text.Trim()))
                    Command.Parameters.AddWithValue("@numer1", NumberTextBox.Text.Trim());
                else
                    Command.Parameters.AddWithValue("@numer1", DBNull.Value);

                Command.Parameters.AddWithValue("@kod1", this.ID);
                MessageBox.Show("1");
            }

            // dolny tytuł
            if (string.IsNullOrEmpty(Number2TextBox.Text.Trim()) && string.IsNullOrEmpty(Year2TextBox.Text.Trim()))
            {                
                Command.CommandText += "EXEC Czasop_ModifyTitleChanges @kod2, 3, 1; ";
                Command.Parameters.AddWithValue("@kod2", this.ID2);
            }
            else if (SecondExists)
            {                
                Command.CommandText += "EXEC Czasop_ModifyTitleChanges @kod2, 2, 1, @numer2, @rok2;";

                if (!string.IsNullOrEmpty(Year2TextBox.Text.Trim()))
                    Command.Parameters.AddWithValue("@rok2", Year2TextBox.Text.Trim());
                else
                    Command.Parameters.AddWithValue("@rok2", DBNull.Value);

                if (!string.IsNullOrEmpty(Number2TextBox.Text.Trim()))
                    Command.Parameters.AddWithValue("@numer2", Number2TextBox.Text.Trim());
                else
                    Command.Parameters.AddWithValue("@numer2", DBNull.Value);

                Command.Parameters.AddWithValue("@kod2", this.ID2);
            }
            else
            {                
                Command.CommandText += "EXEC Czasop_ModifyTitleChanges @kod2, 1, 1, @numer2, @rok2; ";

                if (!string.IsNullOrEmpty(Year2TextBox.Text.Trim()))
                    Command.Parameters.AddWithValue("@rok2", Year2TextBox.Text.Trim());
                else
                    Command.Parameters.AddWithValue("@rok2", DBNull.Value);

                if (!string.IsNullOrEmpty(Number2TextBox.Text.Trim()))
                    Command.Parameters.AddWithValue("@numer2", Number2TextBox.Text.Trim());
                else
                    Command.Parameters.AddWithValue("@numer2", DBNull.Value);

                Command.Parameters.AddWithValue("@kod2", this.ID2);
            }

            if (CommonFunctions.WriteData(Command, ref Settings.Connection))
                this.Close();
        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            YearTextBox.Text = string.Join("", YearTextBox.Text.Where(x => Char.IsDigit(x)).ToArray());
        }

        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            NumberTextBox.Text = string.Join("", NumberTextBox.Text.Where(x => Char.IsDigit(x)).ToArray());
        }

        private void Year2TextBox_TextChanged(object sender, EventArgs e)
        {
            Year2TextBox.Text = string.Join("", Year2TextBox.Text.Where(x => Char.IsDigit(x)).ToArray());
        }

        private void Number2TextBox_TextChanged(object sender, EventArgs e)
        {
            Number2TextBox.Text = string.Join("", Number2TextBox.Text.Where(x => Char.IsDigit(x)).ToArray());
        }
    }
}
