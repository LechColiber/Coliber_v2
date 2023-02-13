using System;
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
    public partial class SelectPublishers : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        Connection NewConnection;

        public SelectPublishers(Connection NewConnection)
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
            mapping.Add(MagazinesRadioButton, "magazines");
            mapping.Add(BooksRadioButton, "books");
            mapping.Add(groupBox1, "selected_publishers");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
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

                BooksPublishers PublishersForm = new BooksPublishers(NewConnection, "dla bazy książek", "dbo.ksiazki");

                Wait.Close();

                PublishersForm.ShowDialog();               
            }
            else if (MagazinesRadioButton.Checked == true)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                MagazinesPublishers PublishersForm = new MagazinesPublishers(NewConnection, "dla bazy czasopism", "dbo.czasop");

                Wait.Close();

                PublishersForm.ShowDialog();                
            }

            this.Close();
        }

        private void SelectPublishers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
