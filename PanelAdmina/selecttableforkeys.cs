
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace WindowsFormsApplication1
{
    public partial class SelectTableForKeys : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        Connection NewConnection;

        public SelectTableForKeys(Connection NewConnection)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.StartPosition = FormStartPosition.CenterParent;

            this.NewConnection = NewConnection;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "select_publishers");
            mapping.Add(ExitButton, "cancel");
            mapping.Add(OkButton, "select");
            mapping.Add(groupBox1, "keys_for");
            mapping.Add(ArticlesRadioButton, "articles");
            mapping.Add(BooksRadioButton, "books");
            mapping.Add(MagazinesRadioButton, "magazines");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void SelectTableForKeys_Load(object sender, EventArgs e)
        {
            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (BooksRadioButton.Checked == true)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                BooksKeys BooksKeysForm = new BooksKeys(NewConnection, _T("keys"), "dbo.ksi_klu");

                Wait.Close();

                BooksKeysForm.ShowDialog();                
            }
            else if (MagazinesRadioButton.Checked == true)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                MagazinesKeys MagazinesKeysForm = new MagazinesKeys(NewConnection, _T("keys"), "dbo.cza_klu");

                Wait.Close();

                MagazinesKeysForm.ShowDialog();                
            }
            else if (ArticlesRadioButton.Checked == true)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                ArticlesKeys ArticlesKeysForm = new ArticlesKeys(NewConnection, _T("keys"), "dbo.art_klu");

                Wait.Close();

                ArticlesKeysForm.ShowDialog();                
            }

            this.Close();
        }

        private void SelectTableForKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
