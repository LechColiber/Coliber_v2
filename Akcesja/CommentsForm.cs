using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Akcesja
{
    public partial class CommentsForm : Form
    {
        private Form _parent;
        public CommentsForm(string Comments, Form parent, bool readOnly = false)
        {
            InitializeComponent();
            setControlsText();

            Lock(readOnly);

            _parent = parent;
            
            if(_parent != null)
                _parent.Enabled = false;

            this.MdiParent = parent.MdiParent;

            textBox1.Text = Comments;
            textBox1.Select();
            textBox1.SelectionStart = textBox1.TextLength;    
        }

        public CommentsForm( Form parent, string Comments, bool readOnly = false)
        {
            InitializeComponent();
            setControlsText();

            Lock(readOnly);

            _parent = parent;

            if (_parent != null)
                _parent.Enabled = false;

            this.MdiParent = parent.MdiParent;

            textBox1.Text = Comments;
            textBox1.Select();
            textBox1.SelectionStart = textBox1.TextLength;

            this.Text = "Kody kreskowe";
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(OKButton, "confirm");
            mapping.Add(CancelButton, "cancel");
            mapping.Add(this, "accession_comments");

            CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CommentsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Lock(bool readOnly)
        {
            if (Settings.ReadOnlyModeForCatalog || readOnly)
            {
                textBox1.ReadOnly = true;
                OKButton.Visible = false;

                CancelButton.Left = 205;
                //this.Text = "Podgląd uwag akcesji";
            }
        }

        private void CommentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_parent != null)
            {
                _parent.Enabled = true;
                _parent.Focus();
            }
        }
    }
}
