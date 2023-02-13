using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace Ksiazki
{
    public partial class SingleUbytkiForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        public DataTable Dt;
        public SingleUbytkiForm(string Signature, string NumerInw, string id_sygnat = "")
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            SygTextBox.Text = Signature.Trim();
            NumInwTextBox.Text = NumerInw.Trim();
            
            this.Dt = new DataTable();
            Dt.Columns.Add("syg");
            Dt.Columns.Add("numer_inw");
            Dt.Columns.Add("nr_ksiegi");
            Dt.Columns.Add("data");
            Dt.Columns.Add("przyczyna");
            Dt.Columns.Add("nr_dowodu");
            Dt.Columns.Add("uwagi");
            Dt.Columns.Add("id_sygnat");

            GenerateWykrComboBoxValues();

            NrKsUbytkowTextBox.Select();
        }

        private void GenerateWykrComboBoxValues()
        {
            Dictionary<int, string> WykrComboBoxValues = new Dictionary<int, string>();

            WykrComboBoxValues.Add(1, _T("unreturned"));
            WykrComboBoxValues.Add(2, _T("destroyed"));
            WykrComboBoxValues.Add(3, _T("withdrawn"));
            WykrComboBoxValues.Add(4, _T("lost"));
            WykrComboBoxValues.Add(5, _T("other_unreasonable"));

            WykrComboBox.DataSource = new BindingSource(WykrComboBoxValues, null);
            WykrComboBox.DisplayMember = "Value";
            WykrComboBox.ValueMember = "Key";
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "single_loses_entry");
            mapping.Add(CancButton, "cancel");
            mapping.Add(OkButton, "confirm");
            mapping.Add(label6, "deletion_reason");
            mapping.Add(WykrComboBox, "unreturned");
            mapping.Add(label3, "losses_book_number");
            mapping.Add(label38, "date_of_add");
            mapping.Add(label5, "comments");
            mapping.Add(label4, "loses_receipt");
            mapping.Add(label2, "inventory_number");
            mapping.Add(label1, "signature");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void CancButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Dt.Rows.Add(SygTextBox.Text.Trim(), NumInwTextBox.Text.Trim(), NrKsUbytkowTextBox.Text.Trim(), DateDTP.Value.ToString("yyyMMdd"), WykrComboBox.SelectedValue, NrDowoduUbytkuTextBox.Text.Trim(), CommentsRichTextBox.Text.Trim());
            this.Close();
        }

        private void SingleUbytkiForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
