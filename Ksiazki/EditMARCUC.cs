using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ksiazki
{
    public partial class EditMARCUC : UserControl
    {
        public EditMARCUC(List<string> DataSource, string NumberComboBox, string Ind1, string Ind2, string Value, bool IsEdit)
        {
            InitializeComponent();

            this.TagComboBox.DataSource = DataSource;
            this.TagComboBox.SelectedItem = (object)NumberComboBox;
            this.Ind1TextBox.Text = Ind1;
            this.Ind2TextBox.Text = Ind2;
            this.ValueTextBox.Text = Value;

            Ind1TextBox.ReadOnly = Ind2TextBox.ReadOnly = ValueTextBox.ReadOnly = !IsEdit;
            TagComboBox.Enabled = IsEdit;
        }

        public string GetTagComboBoxText()
        {
            return TagComboBox.SelectedValue.ToString();
        }

        public void SetValueTextBoxText(string Value1, string Value2)
        {
            this.ValueTextBox.Text = Value1 + " " + Value2;        
        }

        public string GetValueTextBoxText()
        {
            return ValueTextBox.Text;
        }

        public string ToString()
        {
            //return TagComboBox.SelectedItem + '\t'.ToString() + Ind1TextBox.Text + '\t'.ToString() + Ind2TextBox.Text + '\t'.ToString() + ValueTextBox.Text;
            //return TagComboBox.SelectedItem + "\t" + Ind1TextBox.Text + "\t" + Ind2TextBox.Text + "\t" + ValueTextBox.Text;
            return TagComboBox.SelectedItem + "     " + (Ind1TextBox.Text.Trim() != "" ? Ind1TextBox.Text.Trim() : "  ") + "     " + (Ind2TextBox.Text.Trim() != "" ? Ind2TextBox.Text.Trim() : "  ") + "     " + ValueTextBox.Text;
        }
    }
}
