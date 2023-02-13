using System;
using System.Data;
using System.Windows.Forms;

namespace Normy
{
    public partial class Klucz : Coliber._Dialog
    {
        public Klucz(DataRow r)
        {
            InitializeComponent();
            Master = r;
            pagMain = pagInfo;
            FillControls();
        }

        protected override bool ValidateDialog()
        {
            if (txNazwa.Text == "")
            {
                MessageBox.Show("Nie wypełniono podstawowych pól !","Informacja",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            return base.ValidateDialog();
        }

        private void cbOK_Click(object sender, EventArgs e)
        {
            OK();
        }

        private void cbCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
