using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace Ksiazki
{
    public partial class TomsForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private string BookID;
        private Form _parent;
        private bool readOnly;

        public TomsForm(Form parent)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.TitleLV.Name = "TitleLV";
            this.kodLV.Name = "kodLV";

            this.TomsListView.Width = this.TomsListView.Width + 1;
            this.TomsListView.Width = this.TomsListView.Width - 1;

            this.MdiParent = parent.MdiParent;
            this._parent = parent;
            parent.Enabled = false;            
            parent.BringToFront();
        }
        public TomsForm(string BookID, Form parent, bool ReadOnly = false) : this(parent)
        {            
            this.BookID = BookID;
            
            FetchData();

            readOnly = ReadOnly;

            if(ReadOnly)
                Lock();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "vlumes_1");
            mapping.Add(NewButton, "new");
            mapping.Add(EditButton, "edit");
            mapping.Add(DeleteButton, "delete");
            mapping.Add(EscapeButton, "cancel");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void Lock()
        {
            NewButton.Enabled = false;
            EditButton.Enabled = false;
        }

        private void FetchData()
        {
            TomsListView.Items.Clear();

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_BookTomeList @kod; ";
            Command.Parameters.AddWithValue("@kod", BookID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            ListViewItem item1;

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                item1 = new ListViewItem(Dt.Rows[i]["tytul"].ToString());
                item1.SubItems.Add(Dt.Rows[i]["kod_tomy"].ToString());

                TomsListView.Items.Add(item1);
            }

            if (TomsListView.Items.Count > 0)
                TomsListView.Items[0].Selected = true;

            EditButton.Enabled = TomsListView.SelectedItems.Count > 0 && !readOnly;
            DeleteButton.Enabled = TomsListView.SelectedItems.Count > 0;
        }

        private void TomsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
                this.Close();
        }

        private void EscapeButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void NewButton_Click(object sender, System.EventArgs e)
        {
            DetailsForm Det = new DetailsForm("", BookID, Settings.employeeID);
            Det.ShowDialog();            

            FetchData();
        }

        private void TomsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditButton.Enabled = TomsListView.SelectedItems.Count > 0 && !readOnly;
            DeleteButton.Enabled = TomsListView.SelectedItems.Count > 0;
        }

        private void TomsListView_Resize(object sender, EventArgs e)
        {
            if (this.TitleLV.Width < this.TomsListView.Width)
                this.TitleLV.Width = this.TomsListView.Width-25;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            DetailsForm Det = new DetailsForm(TomsListView.SelectedItems[0].SubItems[1].Text, BookID, Settings.employeeID);
            Det.ShowDialog();

            FetchData();            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DetailsForm Det = new DetailsForm(TomsListView.SelectedItems[0].SubItems[1].Text, BookID, Settings.employeeID, true);
            Det.ShowDialog();

            FetchData(); 
        }

        private void TomsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._parent.Enabled = true;
        }
    }
}
