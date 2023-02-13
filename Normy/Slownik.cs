using System;
using System.Data;
using System.Windows.Forms;
using Coliber;

namespace Normy
{
    public partial class Slownik : Form
    {

        DataTable tSlownik;
        public DataRow Rekord = null;

        public Slownik(string cTyp)
        {
            InitializeComponent();
            tSlownik = App.SQLSelect("Select j_pl_nazwa as Nazwa,id from jezyki order by j_pl_nazwa", CommandType.Text);
            dgSlownik.AutoGenerateColumns = false;
            dgSlownik.DataSource = tSlownik;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            int iRow, nId;
            iRow = dgSlownik.SelectedRows[0].Index;
            if (iRow < 0)
            {
                MessageBox.Show("Nie zaznaczono żadnej pozycji ", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            nId = (int)dgSlownik.Rows[iRow].Cells["Id"].Value;
            for (int i = 0; i < tSlownik.Rows.Count; i++)
            {
                if (App.DBInt(tSlownik.Rows[i]["Id"]) == nId)
                {
                    Rekord = tSlownik.Rows[i];
                    break;
                }
            }
            if (Rekord == null)
            {
                MessageBox.Show("Nie znaleziono klucza w tabeli " + nId.ToString(), "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
