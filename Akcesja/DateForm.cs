using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Akcesja
{
    public partial class DateForm : Form
    {
        public DateForm()
        {
            InitializeComponent();

            this.ShowDialog();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //MessageBox.Show(monthCalendar1.SelectionRange.Start.ToString("dd-MM-yyyy"));
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void monthCalendar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }
    }
}
