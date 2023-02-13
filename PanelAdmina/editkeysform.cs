
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class EditKeysForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private Connection NewConnection;
        private Dictionary<int, string> IDRodzajDictionary;
        private int Mode;
        private int KeyID;
        private char KeyKind;

        /// <summary>
        ///     Okienko dodawania i modyfikacji klucza.
        /// </summary>
        /// <param name="NewConnection">
        ///     Obiekt połączenia.
        /// </param>
        /// <param name="id_rodzaj">
        ///     Id rodzaj klucza.
        /// </param>
        /// <param name="Mode">
        ///     Tryb:
        ///         1. Dodawanie
        ///         2. Modyfikacja
        /// </param>
        /// <param name="KeyName">
        ///     Nazwa klucza.
        /// </param>
        /// <param name="KeyID">
        ///     ID klucza.
        /// </param>
        public EditKeysForm(Connection NewConnection, int id_rodzaj, int Mode, string KeyName, int KeyID, char KeyKind)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.NewConnection = NewConnection;
            this.Mode = Mode;
            this.KeyNameTextBox.Text = KeyName;
            this.KeyID = KeyID;
            this.KeyKind = KeyKind;

            IDRodzajDictionary = new Dictionary<int, string>();

            GenerateRodzajeValues(id_rodzaj);

            if (Mode == 1)
                this.Text = _T("add_key_form");
            else if (Mode == 2)
                this.Text = _T("edit_key_form");
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "add_key_form");
            mapping.Add(label3, "books_collection");
            mapping.Add(CancelButton, "cancel");
            mapping.Add(OkButton, "confirm");
            mapping.Add(label1, "keys");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateRodzajeValues(int id_rodzaj)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT id_rodzaj, nazwa FROM dbo.rodzaje ORDER BY nazwa; ";

                OdbcDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    IDRodzajDictionary.Add(Int32.Parse(Reader.GetValue(0).ToString()), Reader.GetValue(1).ToString());
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            RodzajComboBox.DataSource = new BindingSource(IDRodzajDictionary, null);
            RodzajComboBox.ValueMember = "Key";
            RodzajComboBox.DisplayMember = "Value";

            if (id_rodzaj == -1)
                RodzajComboBox.SelectedIndex = 0;
            else
                RodzajComboBox.SelectedValue = id_rodzaj;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;

                if (Mode == 1)
                {
                    Command.CommandText = "EXEC ModifyKey ?, ?, ?, ?, 1; ";

                    Command.Parameters.AddWithValue("@p_nazwa_klucz", KeyNameTextBox.Text);
                    Command.Parameters.AddWithValue("@p_id_klucz", this.KeyID);
                    Command.Parameters.AddWithValue("@p_id_rodzaj", RodzajComboBox.SelectedValue);
                    Command.Parameters.AddWithValue("@p_rodzaj_klucza", this.KeyKind); 
                }
                else if (Mode == 2)
                {
                    Command.CommandText = "EXEC ModifyKey ?, ?, ?, ?, 2; ";

                    Command.Parameters.AddWithValue("@p_nazwa_klucz", KeyNameTextBox.Text);
                    Command.Parameters.AddWithValue("@p_id_klucz", this.KeyID);
                    Command.Parameters.AddWithValue("@p_id_rodzaj", RodzajComboBox.SelectedValue);
                    Command.Parameters.AddWithValue("@p_rodzaj_klucza", this.KeyKind);
                }

                OdbcDataReader Reader = Command.ExecuteReader();

                string InfoFromDb = "";

                while (Reader.Read())
                {
                    InfoFromDb += Reader.GetValue(0).ToString();
                }

                if (InfoFromDb != "")
                    MessageBox.Show(InfoFromDb);
                else
                {
                    if (Mode == 1)
                        MessageBox.Show(_T("key_was_added"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Mode == 2)
                        MessageBox.Show(_T("key_info_was_modified"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }

                Reader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }            
        }

        private void EditKeysForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }
    }
}
