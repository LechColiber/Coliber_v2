using System;
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
    public partial class ShowList : _Window
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        List<string> List;

        public ShowList(List<string> List, string FormText)
        {          
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.StartPosition = FormStartPosition.CenterParent;
            this.List = List;
            this.Text = _T("resources") + " " + FormText + " (" + _T("esc_to_close") + ")"  ;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(ExitButton, "exit");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
            //this.Text = _T("authors_coauthors_institutions");
        }

        private void ShowList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                this.Close();
        }

        private void ShowList_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = List;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
