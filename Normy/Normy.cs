using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Coliber;

namespace Normy
{
    public partial class Normy : Form
    {
        public int ID;

        DataTable tNormy;
        string SearchText;
        int iCol = 1;

        public Normy(bool lDel = false)
        {
            InitializeComponent();
            DeleteButton.Visible = lDel;
            SelectButton.Visible = !lDel;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip((Control)this.buttonSzukaj, "Szukaj");
            toolTip.SetToolTip((Control)this.buttonAll, "Pokaż wszyskie");
            LoadData("Select * from Normy order by tytul");
        }

        void LoadData(string cSQL)
        {
            tNormy = App.SQLSelect(cSQL,CommandType.Text);
            dgNormy.AutoGenerateColumns = false;
            dgNormy.DataSource = tNormy;
        }

        private void ClearSearch()
        {
            SearchText = "";
            SearchLabel.Text = SearchText;
        }
        bool GetSel()
        {
            int Idx = -1;
            if (dgNormy.SelectedRows != null && dgNormy.SelectedRows.Count > 0) Idx = dgNormy.SelectedRows[0].Index;
            if (Idx == -1 )
            {
                MessageBox.Show("Nie zaznaczono żadnej pozycji ", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void SelectButton_Click(object sender, System.EventArgs e)
        {
            if (!GetSel()) return;
            ID = App.DBInt(dgNormy["id", dgNormy.CurrentCell.RowIndex].Value);
            this.Close();
            Norma fNorma = new Norma(ID);
            fNorma.MdiParent = Application.OpenForms[0];
            fNorma.Show();
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void dgNormy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                if (SearchText.Length > 0)
                {
                    SearchText = SearchText.Remove(SearchText.Length - 1);
                    SearchLabel.Text = SearchText;
                }
                e.Handled = true;
            }
            else
            {
                SearchText += e.KeyChar.ToString();
                SearchLabel.Text = SearchText;
            }
            for (int i = 0; i < dgNormy.Rows.Count; i++)
            {
                if (dgNormy.Rows[i].Cells[iCol].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dgNormy.ClearSelection();
                    dgNormy.Rows[i].Selected = true;
                    dgNormy.CurrentCell = dgNormy[iCol, i];
                    dgNormy.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void dgNormy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                SelectButton_Click(sender, e);
        }

        private void dgNormy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearSearch();
        }

        private void dgNormy_Sorted(object sender, System.EventArgs e)
        {
            string cColName;
            cColName = dgNormy.SortedColumn.Name;
            iCol = dgNormy.Columns[cColName].Index;
        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            if (!GetSel()) return;
            string cNr = App.NVL(dgNormy["nr_normy", dgNormy.CurrentCell.RowIndex].Value);
            if (MessageBox.Show("Czy chcesz usunąć zaznaczoną pozycję", cNr, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int i,iRec = -1;
                ID = App.DBInt(dgNormy["id", dgNormy.CurrentCell.RowIndex].Value);
                for (i = 0; i < tNormy.Rows.Count; i++)
                {
                    if (App.DBInt(tNormy.Rows[i]["Id_norma"]) == ID)
                    {
                        iRec = i;
                        break;
                    }
                }
                if (iRec == -1)
                {
                    MessageBox.Show("Nie znaleziono klucza w tabeli " + ID.ToString(), "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SqlCommand cmd = new SqlCommand("delete from normy where id_norma = @ID");
                cmd.Parameters.AddWithValue("@ID", ID);
                if (App.SQLExec(cmd)>0) tNormy.Rows[iRec].Delete();
            }
        }

        private void buttonAll_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno pobrać wszystkie pozycje ?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                LoadData("Select * from Normy order by Tytul");
            }
        }

        private void buttonSzukaj_Click(object sender, System.EventArgs e)
        {
            Szukaj fSzukaj = new Szukaj();
            if (fSzukaj.ShowDialog() == DialogResult.Cancel) return;
            string cSQL = "";
            string cWhere = "";
            string cNrNormy = fSzukaj.cNrNormy;
            string cTytul = fSzukaj.cTytul;
            cSQL = "select * from Normy ";
            if (cNrNormy != "") cWhere = cWhere + "nr_normy like @NrNormy";
            if (cTytul != "")
            {
                if (cWhere != "") cWhere = cWhere + " and ";
                cWhere = cWhere + "tytul like @Tytul";
            }
            if (cWhere != "") cWhere = " where " + cWhere;
            cSQL = cSQL + cWhere + " order by Tytul";
            SqlCommand cmd = new SqlCommand(cSQL);
            if (cNrNormy != "") cmd.Parameters.AddWithValue("@NrNormy", cNrNormy + "%");
            if (cTytul != "") cmd.Parameters.AddWithValue("@Tytul", cTytul + "%");
            tNormy = App.SQLSelect(cmd);
            dgNormy.AutoGenerateColumns = false;
            dgNormy.DataSource = tNormy;
        }
    }
}
