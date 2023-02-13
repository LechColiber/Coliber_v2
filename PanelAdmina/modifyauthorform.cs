
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
	public partial class ModifyAuthorForm: Form
	{
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private Connection NewConnection;
        private Dictionary<int, string> IDRodzajDictionary;
        private int Mode;
        private int ID_aut;
           
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewConnection"></param>
        /// <param name="FirstName"></param>
        /// <param name="Name"></param>
        /// <param name="id_rodzaj"></param>
        /// <param name="id_aut"></param>
        /// <param name="Mode">
        ///     Tryb działania:
        ///         1 - dodawanie
        ///         2 - edytowanie
        /// </param>
 
		public ModifyAuthorForm(Connection NewConnection, string FirstName, string Name, int id_rodzaj, int id_aut, int Mode)
		{
			InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.NewConnection = NewConnection;
            this.FirstNameTextBox.Text = FirstName;
            this.NameTextBox.Text = Name;
            this.RodzajComboBox.SelectedValue = id_rodzaj;
            this.Mode = Mode;
            this.ID_aut = id_aut;

            if (Mode == 1)
                this.Text = _T("author_add");
            else if (Mode == 2)
                this.Text = _T("edit_author");

            this.IDRodzajDictionary = new Dictionary<int, string>();
            GenerateRodzajeValues(id_rodzaj);            
		}

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "author_add");
            mapping.Add(CancelButton, "cancel");
            mapping.Add(OkButton, "confirm");
            mapping.Add(label3, "books_collection");
            mapping.Add(label2, "last_name");
            mapping.Add(label1, "first_name");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void ModifyAuthorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Trim() == "" && FirstNameTextBox.Text.Trim() == "")
            {
                MessageBox.Show(_T("author_name_not_filled"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;

                if (Mode == 1)
                {
                    Command.CommandText = "EXEC ModifyAuthor ?, ?, ?, -1, 1; ";

                    Command.Parameters.AddWithValue("@imie", FirstNameTextBox.Text);
                    Command.Parameters.AddWithValue("@nazwisko", NameTextBox.Text);
                    Command.Parameters.AddWithValue("@id_rodzaj", RodzajComboBox.SelectedValue);
                    Command.Parameters.AddWithValue("@id_aut", -1);
                    Command.Parameters.AddWithValue("@mode", 1);
                }
                else if (Mode == 2)
                {
                    Command.CommandText = "EXEC ModifyAuthor ?, ?, ?, ?, 2; ";
                    
                    Command.Parameters.AddWithValue("@imie", FirstNameTextBox.Text);
                    Command.Parameters.AddWithValue("@nazwisko", NameTextBox.Text);
                    Command.Parameters.AddWithValue("@id_rodzaj", RodzajComboBox.SelectedValue);
                    Command.Parameters.AddWithValue("@id_aut", ID_aut);
                    Command.Parameters.AddWithValue("@mode", 2);
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
                        MessageBox.Show(_T("author_added"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Mode == 2)
                        MessageBox.Show(_T("author_modified"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }

                Reader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);                
            }            
        }

        /*private bool AuthorHaveOtherKindInKsiazki(string SurName, string FirstName, int id_rodzaj)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.coliberConnection = NewConnection.AppConnection;
                Command.CommandText = "SELECT tytul_gl FROM ksiazki " +
                                      "WHERE ((autor1 = ? AND imie1 = ?) OR (autor2 = ? AND imie2 = ?) OR (autor3 = ? AND imie3 = ?) OR " +
                                      "(wautor1 = ? AND wimie1 = ?) OR (wautor2 = ? AND wimie2 = ?) OR (wautor3 = ? AND wimie3 = ?) OR (wautor4 = ? AND wimie4 = ?))" +
                                      " ORDER BY tytul_gl";

                Command.Parameters.AddWithValue("SurName", SurName);
                Command.Parameters.AddWithValue("FirstNameName", FirstName);
                Command.Parameters.AddWithValue("SurName", SurName);
                Command.Parameters.AddWithValue("FirstNameName", FirstName);
                Command.Parameters.AddWithValue("SurName", SurName);
                Command.Parameters.AddWithValue("FirstNameName", FirstName);
                Command.Parameters.AddWithValue("SurName", SurName);
                Command.Parameters.AddWithValue("FirstNameName", FirstName);
                Command.Parameters.AddWithValue("SurName", SurName);
                Command.Parameters.AddWithValue("FirstNameName", FirstName);
                Command.Parameters.AddWithValue("SurName", SurName);
                Command.Parameters.AddWithValue("FirstNameName", FirstName);
                Command.Parameters.AddWithValue("SurName", SurName);
                Command.Parameters.AddWithValue("FirstNameName", FirstName);

                Command.Parameters.AddWithValue("@id_rodzaj", RodzajComboBox.SelectedValue);

                OdbcDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    MessageBox.Show("Autor występuje w książkach w innych ");

                while (Reader.Read())
                {

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);                
            }
        }*/

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
	}
}
