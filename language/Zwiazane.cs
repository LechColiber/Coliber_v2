using System;
using System.Data;
using System.Windows.Forms;

namespace Normy
{
    public partial class Zwiazane : Coliber._Dialog
    {
        public Zwiazane(DataRow r,string cTabela)
        {
            InitializeComponent();
            Master = r;
            pagMain = pagInfo;
            if (pagInfo == null) throw new Exception("brak kontenera kontrolek");
            if (cTabela == "Zastapione") Text = "Norma zastąpiona";
            FillControls();
        }

        protected override bool ValidateDialog()
        {
            if (txSygnatura.Text == "" || txTytul.Text == "")
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
