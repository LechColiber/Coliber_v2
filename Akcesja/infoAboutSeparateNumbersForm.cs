using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Akcesja
{
    public partial class infoAboutSeparateNumbersForm : Form
    {
        public infoAboutSeparateNumbersForm(Form parent)
        {
            InitializeComponent();
            this.MdiParent = parent.MdiParent;
            setControlsText();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(label1, "info_about_separate");
            mapping.Add(this, "information");

            CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void infoAboutSeparateNumbersForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
