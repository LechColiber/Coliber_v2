using System;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace Normy
{
    public partial class Dokument : Coliber._Dialog
    {
        string PathToFile;
        byte[] File;
        public Dokument(DataRow r)
        {
            PathToFile = null;
            File = null;
            InitializeComponent();
            Master = r;
            pagMain = pagInfo;
            if (pagInfo == null) throw new Exception("brak kontenera kontrolek");
            FillControls();
        }

        protected override bool ValidateDialog()
        {
            if (txNazwa.Text == "" || txOpis.Text == "")
            {
                MessageBox.Show("Nie wypełniono podstawowych pól !","Informacja",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            return base.ValidateDialog();
        }

        private void cbOK_Click(object sender, EventArgs e)
        {
            OK();
            if (File != null)
            {
                Master["Plik"] = File;
                Master["Sciezka"] = PathToFile;
            }
        }

        private void cbCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = false;

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                string cNazwa;
                PathToFile = OFD.FileName;
                File = GetFile(PathToFile);
                cNazwa = Path.GetFileName(PathToFile);
                txNazwa.Text = cNazwa;
                PathToFile = PathToFile.Replace(cNazwa, "");
            }
        }

        public static byte[] GetFile(string filePath)
        {
            try
            {
                FileStream Stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader Reader = new BinaryReader(Stream);

                byte[] f = Reader.ReadBytes((int)Stream.Length);

                Reader.Close();
                Stream.Close();

                return f;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            return null;
        }

    }
}
