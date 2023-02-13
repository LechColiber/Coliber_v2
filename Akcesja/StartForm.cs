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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

            this.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             //new AkcesjaForm(1, "nowa_karta");//.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //new ShowForm(1, "dopisz").ShowDialog();
            //AkcesjaForm a = new AkcesjaForm(1, "dopisz");
            //a.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //AkcesjaForm a = new AkcesjaForm(1, "usun");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //AkcesjaDetailsForm ADF = new AkcesjaDetailsForm(9, "198", "1", "P-54", "Rynek Zamówień Publicznych", 1, true);
        }
    }
}
