using System;
using System.Data;
using System.Windows.Forms;

namespace Normy
{
    public partial class Sygnatura : Coliber._Dialog
    {
        public Sygnatura(DataRow r)
        {
            InitializeComponent();
            Master = r;
            pagMain = pagInfo;
            if (pagInfo == null) throw new Exception("brak kontenera kontrolek");
            FillControls();
        }

        protected override bool ValidateDialog()
        {
            if (txSygnatura.Text == "" || dpData.Text == "")
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
