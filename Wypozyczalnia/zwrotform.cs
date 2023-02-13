using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Wypozyczalnia
{
    public partial class ZwrotForm : Form
    {
        private string borrowID;
        private Form _parent;
        private DateTime borrowDate;
        private Dictionary<string, string> _translationsDictionary;
        private bool lWin10 = false;

        public ZwrotForm(Form parent, bool onlyReturning)
        {
            InitializeComponent();

            setControlsText();

            if (parent != null)
            {
                parent.Enabled = false;
                _parent = parent;
                this.MdiParent = parent.MdiParent;
            }
            IsWin10();
            borrowDate = DateTime.Now;

            prolongationButton.Enabled = !onlyReturning;            
        }
        public ZwrotForm(string borrowID, Form parent, bool onlyReturning = false)
            : this(parent, onlyReturning)
        {
            this.borrowID = borrowID;

            LoadResourceData(borrowID);
            dateFromCalendarLabel.Text = dateCal.SelectionStart.ToLongDateString();

            dateCal.MinDate = borrowDate;            
        }

        public ZwrotForm(string borrowID, string employeeID, Form parent, bool onlyReturning = true)
            : this(parent, onlyReturning)
        {
            Settings.SetSettings();

            Settings.employeeID = Int32.Parse(employeeID);

            this.borrowID = borrowID;

            LoadResourceData(borrowID);
            dateFromCalendarLabel.Text = dateCal.SelectionStart.ToLongDateString();
        }

 
        public void IsWin10()
        {
            var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            string productName = (string)reg.GetValue("ProductName");

            lWin10 = productName.Contains("Windows 10");
            if (lWin10) dateCal.Left = dateCal.Left - 100;
        }
        
        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(userTextLabel, "user");
            mapping.Add(resourceLabel, "resource");
            mapping.Add(label2, "barcode");
            mapping.Add(label4, "group");
            mapping.Add(label3, "employee");
            mapping.Add(label6, "borrow_date");
            mapping.Add(label5, "require_date");
            mapping.Add(label8, "return_date_new_require_date");

            mapping.Add(prolongationButton, "prolongs");
            mapping.Add(returnResourceButton, "confirm_return");
            mapping.Add(ExitButton, "exit");

            mapping.Add(this, "return_resource");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void LoadResourceData(string borrowID)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zwrot_szczegoly @zasob_id; ";
            Command.Parameters.AddWithValue("@zasob_id", borrowID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if(Dt.Rows.Count > 0)
            {
                userLabel.Text = Dt.Rows[0]["uzytkownik"].ToString();
                descRTB.Text = Dt.Rows[0]["opis"].ToString();
                barcodeLabel.Text = Dt.Rows[0]["kod_kresk"].ToString();
                groupLabel.Text = Dt.Rows[0]["grupa"].ToString();
                lenderLabel.Text = Dt.Rows[0]["wypozyczajacy"].ToString();
                borrowDateLabel.Text = Dt.Rows[0]["data_wypoz"].ToString();
                DateTime.TryParseExact(Dt.Rows[0]["data_wypoz"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,  out borrowDate);
                reqiureDateLabel.Text = Dt.Rows[0]["data_przewidywana"].ToString();
            }
        }

        private void ZwrotForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dateCal_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateFromCalendarLabel.Text = dateCal.SelectionStart.ToLongDateString();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void returnResourceButton_Click(object sender, EventArgs e)
        {
            returnResource(borrowID, Settings.employeeID);
        }

        private void returnResource(string borrowID, int employeeID)
        {
            if (!IsDateValid(dateCal.SelectionStart))
                return;

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zwrot @wypoz_id, @pracown_id, @data_zwrotu, @rezultat OUTPUT; ";
            Command.Parameters.AddWithValue("@wypoz_id", borrowID);
            Command.Parameters.AddWithValue("@pracown_id", employeeID);
            Command.Parameters.AddWithValue("@data_zwrotu", dateCal.SelectionStart.ToString("yyyyMMdd"));

            SqlParameter rezultat = new SqlParameter();
            rezultat.ParameterName = "@rezultat";
            rezultat.SqlDbType = SqlDbType.TinyInt;
            rezultat.Direction = ParameterDirection.Output;

            Command.Parameters.Add(rezultat);
            
            if (CommonFunctions.WriteData(ref Command, ref Settings.Connection))
            {
                if (Command.Parameters["@rezultat"].SqlValue.ToString() == "1")
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("resource_returned", "Zasób został zwrócony."), _translationsDictionary.getStringFromDictionary("", "Operacja zakończona"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            } 
        }

        private void prolongationButton_Click(object sender, EventArgs e)
        {
            if(!IsDateValid(dateCal.SelectionStart))
                return;

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_przedluzenie @wypoz_id, @data_wymagana, @rezultat OUTPUT; ";
            Command.Parameters.AddWithValue("@wypoz_id", borrowID);            
            Command.Parameters.AddWithValue("@data_wymagana", dateCal.SelectionStart.ToString("yyyyMMdd"));

            SqlParameter rezultat = new SqlParameter();
            rezultat.ParameterName = "@rezultat";
            rezultat.SqlDbType = SqlDbType.TinyInt;
            rezultat.Direction = ParameterDirection.Output;

            Command.Parameters.Add(rezultat);

            if (CommonFunctions.WriteData(ref Command, ref Settings.Connection))
            {
                if (Command.Parameters["@rezultat"].SqlValue.ToString() == "1")
                {
                    MessageBox.Show("Termin zwrotu został przedłużony do " + dateCal.SelectionStart.ToString("dd-MM-yyyy") + ".", _translationsDictionary.getStringFromDictionary("", "Operacja zakończona"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }            
        }

        private bool IsDateValid(DateTime date1)
        {
            if (borrowDate <= date1)
                return true;
            else
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("date_cannot_be_earlier_than_borrow_date", "Data nie może być wcześniejsza niż data wypożyczenia!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Błędna data"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void ZwrotForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_parent != null)
            {
                _parent.Enabled = true;
                _parent.Focus();
            }
        }
    }
}
