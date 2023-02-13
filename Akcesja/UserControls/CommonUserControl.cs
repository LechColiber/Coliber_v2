using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Akcesja
{
    public partial class CommonUserControl : UserControl
    {
        private Dictionary<string, string> _translationsDictionary;
        public CommonUserControl()
        {
            InitializeComponent();

            YearNumericUpDown.Value = DateTime.Today.Year;
            
            setControlsText();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(yearLabel, "year");
            mapping.Add(DateRadioButton, "show_date");
            mapping.Add(NumberRadioButton, "show_number");
            mapping.Add(NextNumberRadioButton, "show_next_number");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        public int GetYear()
        {
            return (int)YearNumericUpDown.Value;
        }

        private void YearNumericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',' || e.KeyChar == '.')
                e.Handled = true;
        }

        public void loadConfig()
        {
            CommonFunctions.LoadConfig(this.Controls, ref Settings.Connection, 5);
        }
    }
}
