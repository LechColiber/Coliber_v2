using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
//using Microsoft.Data.SqlXml;
using Coliber;

namespace Normy
{
    public partial class Norma : Form
    {

        SqlConnection conn;
        DataTable tNormy;
        DataTable tZwiazane;
        DataTable tZastapione;
        DataTable tKlucze;
        DataTable tSygnatury;
        DataTable tDokumenty;
        DataTable tJezyki;
        int ID;
        bool lSkipQ = false;

        int iTabela = -1;
        SqlDataAdapter[] Adaptery = new SqlDataAdapter[7];
        SqlCommandBuilder[] Buildery = new SqlCommandBuilder[7];

        public Norma(int Id)
        {
            InitializeComponent();
            Wait fWait = new Wait("Wyszukiwanie danych...");
            fWait.Show();
            Application.DoEvents();
            conn = new SqlConnection(App.cConn);
            conn.Open();
            ID = Id;
            tNormy = GetData("Normy", "id_norma", ID);
            if (ID == -1)
            {
                ID = App.GetId("Normy");
                tNormy.Rows.Add();
                tNormy.Rows[0]["id_norma"] = ID;
            }
            //Zwiazane
            tZwiazane = GetData("Normy_zwiazane", "nor_nor_id", ID);
            dgZwiazane.AutoGenerateColumns = false;
            dgZwiazane.DataSource = tZwiazane;
            //Zastapione
            tZastapione = GetData("Normy_Zastapione", "nor_nor_id", ID);
            dgZastapione.AutoGenerateColumns = false;
            dgZastapione.DataSource = tZastapione;
            //Klucze
            tKlucze = GetData("Normy_klucz", "nor_nor_id", ID);
            dgKlucze.AutoGenerateColumns = false;
            dgKlucze.DataSource = tKlucze;
            //Sygnatury
            tSygnatury = GetData("Normy_egzemplarz", "nor_nor_id", ID);
            dgSygnatury.AutoGenerateColumns = false;
            dgSygnatury.DataSource = tSygnatury;
            //Dokumenty
            tDokumenty = GetData("Normy_dokument", "nor_nor_id", ID);
            dgDokumenty.AutoGenerateColumns = false;
            dgDokumenty.DataSource = tDokumenty;
            //Jezyki
            tJezyki = GetData("Normy_jezyk", "nor_nor_id", ID);
            dgJezyki.AutoGenerateColumns = false;
            dgJezyki.DataSource = tJezyki;

            foreach (TabPage P in tabNormy.TabPages)
            {
                foreach (Control C in P.Controls)
                {
                    int iLen;
                    string cName, cAction;
                    cName = C.Name.Substring(2);
                    iLen = cName.Length;
                    if (cName.Length > 3) cAction = cName.Substring(iLen - 3); else cAction = "---";
                    if (C.GetType() == typeof(Button) && ("AddModDel").Contains(cAction))
                    {
                        ((Button)C).Click += DetailsEvent;
                    }
                }
            }
            /*
            SqlCommand CmdNormy = new SqlCommand("select * from Normy where id_norma = @Id");
            CmdNormy.Parameters.Add(new SqlParameter("@Id", Id));
            Normy = App.SQLSelect(CmdNormy);
            */

            FillControls();
            fWait.Close();
        }
        private void DetailsEvent(object sender, EventArgs e)
        {
            string cName, cAction;
            int iLen;
            // tabela i akcja
            Control C = sender as Control;
            cName = C.Name.Substring(2);
            iLen = cName.Length;
            cAction = cName.Substring(iLen - 3);
            cName = cName.Substring(0, iLen - 3);
            DetailsAction(cName, cAction);

        }
        private int DetailsAction(string cName,string cAction)
        {
            // znajdź grid
            DataGridView dgv = null;
            foreach (TabPage panel in tabNormy.TabPages)
            {
                foreach (Control c in panel.Controls)
                {
                    if (c.GetType().Name == "DataGridView" && c.Name == "dg" + cName)
                    {
                        dgv = (DataGridView)c;
                    }
                }
            }
            if (dgv == null)
            {
                MessageBox.Show("Nie znaleziono obiektu " + cName, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            // znajdź id w DataGridView
            int Id,Idx=-1;
            if (dgv.SelectedRows != null && dgv.SelectedRows.Count > 0) Idx = dgv.SelectedRows[0].Index;
            if (Idx == -1 && dgv.Rows.Count != 0)
            {
                dgv.Rows[0].Selected = true;
                Idx = 0;
            }
            if (Idx == -1 && cAction != "Add")
            {
                MessageBox.Show("Nie zaznaczono żadnej pozycji ", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            string cCol = null;
            cCol = dgv.Name + "Id";
            if (Idx == -1) Id = -1; else Id = (int)dgv.Rows[Idx].Cells[cCol].Value;
            // znajdź kolumnę id w tabeli
            int iCol = -1;
            foreach (DataGridViewColumn dc in dgv.Columns)
            {
                if (dc.Name == cCol)
                {
                    cCol = dc.DataPropertyName;
                    break;
                }
            }
            if (cCol == null)
            {
                MessageBox.Show("Nie znaleziono kolumny w tabeli " + cName, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            DataTable dt = (DataTable)dgv.DataSource;
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName == cCol)
                {
                    iCol = dc.Ordinal;
                    break;
                }
            }
            // znajdź DataRow w tabeli
            int i = -1;
            DataRow Rekord = null;
            if (cAction == "Add")
            {
                string cPar = (string)dt.ExtendedProperties["ParentKey"];
                Rekord = dt.NewRow();
                Rekord[cPar] = ID;
            }
            else
            {
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (App.DBInt(dt.Rows[i][cCol]) == Id)
                    {
                        Rekord = dt.Rows[i];
                        break;
                    }
                }
                if (Rekord == null)
                {
                    MessageBox.Show("Nie znaleziono klucza w tabeli " + Id.ToString(), "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }
            }
            // wykonaj odpowiednią akcję
            if (cAction == "Loc")
            {
                return i;
            }
            if (cAction == "Del" && MessageBox.Show("Czy chcesz usunąć zaznaczoną pozycję","Pytanie",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dt.Rows[i].Delete();
                dt.ExtendedProperties["Edited"] = true;
                return -1;
            }
            _Dialog frm = CreateForm(cName,Rekord);
            if (frm == null)
            {
                MessageBox.Show("Nie utworzono formularza dla tabeli " + cName, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            DataRow kopia = null;
            if (cAction == "Mod")
            {
                kopia = CopyRow(Rekord);
            }
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                bool lExists;
                lExists = RowExisits(dt, Rekord, cCol);
                if (lExists)
                {
                    if (cAction == "Mod")
                    {
                        for (i = 0; i < dt.Columns.Count; i++)
                        {
                            Rekord[i] = kopia[i];
                        }
                    }
                    MessageBox.Show("Unikalność pozycji została naruszona !", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }
                if (cAction == "Add")
                {
                    Rekord[cCol] = App.GetId(dt.TableName);
                    dt.Rows.Add(Rekord);
                    dt.ExtendedProperties["Edited"] = true;
                    return 1;
                }
                if (cAction == "Mod" && Rekord.RowState != DataRowState.Unchanged)
                {
                    dt.ExtendedProperties["Edited"] = true;
                    return 1;
                }
            }
            return -1;
        }

        private DataRow CopyRow(DataRow dr)
        {
            DataRow drCopy = dr.Table.NewRow();
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                drCopy[i] = dr[i];
            }
            return drCopy;
        }

        bool RowExisits(DataTable dt, DataRow Rekord,string cId)
        {
            string cVal1, cVal2;
            int iCol;
            iCol = dt.Columns[cId].Ordinal;
            foreach (DataRow r in dt.Rows)
            {
                cVal1 = r.ItemArray[iCol].ToString();
                cVal2 = Rekord.ItemArray[iCol].ToString();
                if (r.ItemArray[iCol].ToString() != Rekord.ItemArray[iCol].ToString())
                {
                    for (int i = 0; i < r.ItemArray.Length; i++)
                    {
                        cVal1 = r.ItemArray[i].ToString();
                        cVal2 = Rekord.ItemArray[i].ToString();
                        if (i != iCol)
                        {
                            if (r.ItemArray[i].ToString() != Rekord.ItemArray[i].ToString()) return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        _Dialog CreateForm(string cTabela, DataRow r)
        {
            _Dialog f = null;
            if (cTabela == "Zwiazane" || cTabela == "Zastapione")
                f = new Zwiazane(r,cTabela);
            if (cTabela == "Klucze")
                f = new Klucz(r);
            if (cTabela == "Sygnatury")
                f = new Sygnatura(r);
            if (cTabela == "Dokumenty")
                f = new Dokument(r);
            f.StartPosition = FormStartPosition.CenterScreen;
            return f;
        }

        DataTable GetData(string cTabela,string cPole,int nKlucz)
        {
            string cSQL;
            DataTable dt = new DataTable();
            cSQL = "select * from " + cTabela + " where " + cPole + "=" + nKlucz.ToString() ;
            iTabela++;
            Adaptery[iTabela] = new SqlDataAdapter(cSQL, conn);
            Buildery[iTabela] = new SqlCommandBuilder(Adaptery[iTabela]);
            Adaptery[iTabela].Fill(dt);
            dt.TableName = cTabela;
            dt.ExtendedProperties.Add("ParentKey", cPole);
            dt.ExtendedProperties.Add("Edited", false);
            return dt;
        }

        void FillControls()
        {
            this.Text = ID.ToString() + " - " + tNormy.Rows[0]["Tytul"];
            //txNr_normy.Text = App.NVL(tNormy.Rows[0]["nr_normy"]);

            foreach (TabPage panel in tabNormy.TabPages)
            {
                foreach (Control C in panel.Controls)
                {
                    string cName, cVal;
                    DateTime tData, tEmpty;
                    tEmpty = new DateTime(1901, 1, 1);
                    cName = C.Name.Substring(2);
                    if (C.GetType() == typeof(TextBox) || C.GetType() == typeof(MaskedTextBox) || C.GetType() == typeof(ComboBox))
                    {
                        cVal = App.NVL(tNormy.Rows[0][cName]);
                        C.Text = cVal;
                    }
                    if (C.GetType() == typeof(NullableDTP))
                    {
                        NullableDTP dpC = (NullableDTP)C;
                        tData = App.DBDateT(tNormy.Rows[0][cName]);
                        if (tData == tEmpty)
                        {
                            tData = DateTime.MinValue;
                        }
                        dpC.Value = tData;
                    }
                }
            }
        }

        void SaveControls()
        {
            this.Text = ID.ToString() + " - " + tNormy.Rows[0]["Tytul"];
            txNr_normy.Text = txNr_normy.Text.Trim();
            txTytul.Text = txTytul.Text.Trim();

            foreach (TabPage panel in tabNormy.TabPages)
            {
                foreach (Control C in panel.Controls)
                {
                    string cName, cVal;
                    int iVal;
                    cName = C.Name.Substring(2);
                    if (C.GetType() == typeof(TextBox) || C.GetType() == typeof(MaskedTextBox) || C.GetType() == typeof(ComboBox))
                    {
                        //MessageBox.Show(cName + "\n" + tNormy.Columns[cName].DataType.ToString());
                        if (tNormy.Columns[cName].DataType.ToString() == "System.String")
                        {
                            cVal = App.NVL(tNormy.Rows[0][cName]);
                            if (cVal != C.Text) tNormy.Rows[0][cName] = C.Text;
                        }
                        if (tNormy.Columns[cName].DataType.ToString() == "System.Int32")
                        {
                            int iNew = 0;
                            if (C.Text != "") iNew = Int32.Parse(C.Text);
                            iVal = App.DBInt(tNormy.Rows[0][cName]);
                            if (iVal != iNew) tNormy.Rows[0][cName] = iNew;
                        }
                    }
                    else if (C.GetType() == typeof(NullableDTP))
                    {
                        //MessageBox.Show(cName + "\n" + tNormy.Columns[cName].DataType.ToString());
                        NullableDTP dpC = (NullableDTP)C;
                        if (dpC.Value == null)
                        {
                            if (tNormy.Rows[0][cName] != DBNull.Value)
                                tNormy.Rows[0][cName] = DBNull.Value;
                        }
                        else if (dpC.Value.ToString() != tNormy.Rows[0][cName].ToString())
                        {
                            tNormy.Rows[0][cName] = dpC.Value;
                        }
                    }
                }
            }
        }

        bool ValidateForm()
        {
            if (txNr_normy.Text == "" || txTytul.Text == "")
            {
                MessageBox.Show("Nie wypełniono podstawowych pól !", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dpData_pub.Text.Trim() == "")
            {
                MessageBox.Show("Nie wprowadzono daty publikacji !", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbStatusN.Text == "Unieważniona" && dpData_uniew.Text.Trim() == "")
            {
                MessageBox.Show("Nie wprowadzono daty unieważnienia !", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbStatusN.Text == "Wycofana" && dpWycofana.Text.Trim() == "")
            {
                MessageBox.Show("Nie wprowadzono daty wycofania !", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbStatusN.Text != "Unieważniona" && dpData_uniew.Text.Trim() != "")
            {
                MessageBox.Show("Nieprawidłowy status normy - wypełniona data unieważnienia !", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbStatusN.Text != "Wycofana" && dpWycofana.Text.Trim() != "")
            {
                MessageBox.Show("Nieprawidłowy status normy - wypełniona data wycofania !", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool SaveForm(bool lForce = false)
        {
            if (!ValidateForm()) return false; 
            if (lForce || UpdatesWaiting())
            {
                if (SaveData(ref tNormy, 0) && 
                    SaveData(ref tZwiazane, 1) &&
                    SaveData(ref tZastapione, 2) &&
                    SaveData(ref tKlucze, 3) &&
                    SaveData(ref tSygnatury, 4) &&
                    SaveData(ref tDokumenty, 5) &&
                    SaveData(ref tJezyki, 6)) return true;
                else return false;
            }
            return true;
        }

        private bool SaveData(ref DataTable dt,int i)
        {
            int iRows = -1;
            bool lEdited = false;
            if (i == 0) lEdited = dt.Rows[0].RowState != DataRowState.Unchanged;
            else lEdited = (bool)dt.ExtendedProperties["Edited"] == true;
            try
            {
                if (lEdited) iRows = Adaptery[i].Update(dt);
                else iRows = 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Błąd SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (DBConcurrencyException ex)
            {
                MessageBox.Show("Zmiany w " + dt.TableName + " nie mogły zostać zapisane" + "\n" + "ponieważ zostały zmienione przez innego użytkownika" + "\n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //MessageBox.Show(dt.TableName + "\n" + dt.ExtendedProperties["Edited"].ToString() + "\n" + iRows.ToString());
            dt.AcceptChanges();
            dt.ExtendedProperties["Edited"] = false;
            return iRows > 0;
        }

        private bool UpdatesWaiting()
        {
            SaveControls();
            return tNormy.Rows[0].RowState != DataRowState.Unchanged ||
                (bool)tZwiazane.ExtendedProperties["Edited"] == true ||
                (bool)tZastapione.ExtendedProperties["Edited"] == true ||
                (bool)tKlucze.ExtendedProperties["Edited"] == true ||
                (bool)tSygnatury.ExtendedProperties["Edited"] == true ||
                (bool)tDokumenty.ExtendedProperties["Edited"] == true ||
                (bool)tJezyki.ExtendedProperties["Edited"] == true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (SaveForm()) { lSkipQ = true; Close(); }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            bool lUpdates;
            lUpdates = UpdatesWaiting();
            if (lUpdates)
            {
                dr = MessageBox.Show(this, "Czy na pewno chcesz anulować wprowadzone zmiany ?", "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;
                else if (dr == DialogResult.Yes) { lSkipQ = true; Close(); }
            }
            else { lSkipQ = true; Close(); }

        }

        private void Norma_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lSkipQ) return;
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dr;
                bool lUpdates;
                lUpdates = UpdatesWaiting();
                if (lUpdates)
                {
                    dr = MessageBox.Show(this, "Czy chcesz zapisać wprowadzone zmiany ?", "Pytanie", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Cancel) e.Cancel = true;
                    else if (dr == DialogResult.Yes)
                        if (!SaveForm()) e.Cancel = true;
                }
            }
        }

        private void btJezykiSlo_Click(object sender, EventArgs e)
        {
            Slownik slo = new Slownik("Jezyki");
            DialogResult dr = slo.ShowDialog();
            if (dr == DialogResult.Cancel) return;
            if (slo.Rekord == null) return;
            int nId = App.GetId("Normy_jezyk");
            tJezyki.Rows.Add(nId, slo.Rekord["Id"], slo.Rekord["Nazwa"], ID);
            tJezyki.ExtendedProperties["Edited"] = true;
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            if (dgDokumenty.CurrentRow == null) {App.Info("Nie zaznaczono żadnej pozycji !"); return; }
            int iRow = DetailsAction("Dokumenty", "Loc");
            if (iRow == -1) return;
            string cPlik = tDokumenty.Rows[iRow]["sciezka"].ToString() + tDokumenty.Rows[iRow]["nazwa"].ToString();
            OpenFile(cPlik, (int)dgDokumenty["dgDokumentyId", dgDokumenty.CurrentRow.Index].Value);
        }

        private void OpenFile(string FileName, int id_nor_dok)
        {
            try
            {
                SaveFileDialog SF = new SaveFileDialog();
                SF.Filter = string.Format("{0} (*.*)|*.*", "Wszystkie pliki");
                SF.FileName = FileName;
                //SF.CheckFileExists = true;
                SF.AddExtension = true;

                if (SF.ShowDialog() == DialogResult.OK)
                {
                    SqlCommand Command = new SqlCommand();
                    Command.CommandText = "SELECT plik FROM normy_dokument WHERE id_nor_dok = @id;";
                    Command.Parameters.AddWithValue("@id", id_nor_dok);

                    DataTable Dt = App.SQLSelect(Command);

                    byte[] File = null;

                    if (Dt.Rows.Count > 0 && Dt.Rows[0].ItemArray[0] != null)
                    {
                        File = (byte[])Dt.Rows[0].ItemArray[0];
                        FileStream fs = (FileStream)SF.OpenFile();
                        fs.Write(File, 0, File.Length);
                        fs.Close();
                    }
                    else { App.Info("Nie udało się pobrać pliku !"); return; }


                    if (MessageBox.Show("Otworzyć wskazany dokument ?", "Otwieranie pliku", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(SF.FileName);
                    }

                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        private void XMLUpdate()
        {
            string cConn = @"Provider=SQLOLEDB;Server=DEV1\SQLEXPRESS;Database=coliber_wzorzec_dentons;Integrated Security=SSPI;";
            cConn = @"Provider=SQLOLEDB;Server=DEV1\SQLEXPRESS;Database=coliber_wzorzec_dentons;uid=Coliber;pwd=koliberek";

            FileStream xml = new FileStream("UGram.XML", FileMode.Open);
            SqlXmlCommand cmd = new SqlXmlCommand(cConn);
            cmd.CommandStream = xml;
            cmd.CommandType = SqlXmlCommandType.UpdateGram;
            cmd.ExecuteNonQuery();
            xml.Close();
        }
        */
    }
}
