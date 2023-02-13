using System;
using System.Data;
using System.Windows.Forms;

namespace Normy
{
    public partial class Szukaj : Form
    {
        public string cNrNormy = null;
        public string cTytul = null;

        public Szukaj()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (txNrNormy.Text == "" && txTytul.Text == "")
            {
                MessageBox.Show("Nie wprowadzono żadnej wartości !", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
            cNrNormy = txNrNormy.Text;
            cTytul = txTytul.Text;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
