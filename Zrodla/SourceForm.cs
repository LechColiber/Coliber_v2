using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Zrodla
{
    public partial class SourceForm : Form
    {
        private int Code;
        private int KindOfResource;

        private enum EnumMode { NORMAL, READONLY};
        private int CurrentMode;

        private Dictionary<string, string> _translationsDictionary;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code">Pole "kod" z tabeli documents.</param>
        /// <param name="KindOfResource">
        ///     Pole "rodzaj_zasobu" z tabeli documents.
        ///         1 - książka
        ///         2 - czasopismo
        ///         3 - artykuł.
        /// </param>
        /// <param name="id_rodzaj"> Pole"id_rodzaj" z tabeli documents.</param>
        public SourceForm(int Code, int KindOfResource, int id_rodzaj) 
        {
            InitializeComponent();

            this.Code = Code;
            this.KindOfResource = KindOfResource;

            IniFile Configs = new IniFile("coliber.ini", "coliber");

            Settings.SetSettings(Configs.ReadIni("SqlServer", "ConnectionString"), id_rodzaj, Code, KindOfResource);
            
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();            

            GetFilesData();
            GetURLsData();
        }

        public SourceForm(int Code, int KindOfResource, int id_rodzaj, bool ReadOnly) : this (Code, KindOfResource, id_rodzaj)
        {
            if (ReadOnly)
            {
                Settings.ReadOnly = true;
                CurrentMode = (int) EnumMode.READONLY;
                
                AddFilesButton.Click -= AddFilesButton_Click;
                AddFilesButton.Click += EditFilesButton_Click;

                AddButton.Click -= AddButton_Click;
                AddButton.Click += EditButton_Click;
            }

            Lock();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(groupBox1, "files_to_download");
            mapping.Add(OrdinalFilesDGV, "oridinal_short");
            mapping.Add(FileName, "file_name");
            mapping.Add(Date, "date_of_add");
            mapping.Add(Comments, "comments");
            mapping.Add(AddFilesButton, "attach");
            mapping.Add(EditFilesButton, "edit");
            mapping.Add(DeleteFilesButton, "delete");
            mapping.Add(DownloadFileButton, "download");

            mapping.Add(groupBox2, "download");
            mapping.Add(OrdinalURLsDGV, "oridinal_short");
            mapping.Add(NameURLsDGV, "file_name");
            mapping.Add(URLURLsDGV, "url_address");
            mapping.Add(DateURLsDGV, "date_of_add");
            mapping.Add(CommentsURLsDGV, "comments");
            mapping.Add(AddButton, "attach");
            mapping.Add(EditButton, "edit");
            mapping.Add(DeleteButton, "delete");
            mapping.Add(ExitButton, "exit");

            mapping.Add(this, "sources_list");
            
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetFilesData()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "SELECT id, nazwa, data_dodania, uwagi FROM documents WHERE plik IS NOT NULL AND kod = @kod AND rodzaj_zasobu = @rodzaj_zasobu ORDER BY nazwa;";
            Command.Parameters.AddWithValue("@kod", Code);
            Command.Parameters.AddWithValue("@rodzaj_zasobu", KindOfResource);

            ShowData(CommonFunctions.ReadData(Command, ref Settings.Connection), ref FilesDGV);
        }

        private void GetURLsData()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "SELECT id, nazwa, URL, data_dodania, uwagi FROM documents WHERE URL IS NOT NULL AND kod = @kod AND rodzaj_zasobu = @rodzaj_zasobu ORDER BY nazwa;";
            Command.Parameters.AddWithValue("@kod", Code);
            Command.Parameters.AddWithValue("@rodzaj_zasobu", KindOfResource);            

            ShowData(CommonFunctions.ReadData(Command, ref Settings.Connection), ref URLsDGV);
        }

        private void ShowData(DataTable Dt, ref DataGridView DGV)
        {
            try
            {
                Dt.Columns.Add("L.p.");
                Dt.Columns["L.p."].SetOrdinal(0);

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    Dt.Rows[i]["L.p."] = i + 1;
                }

                /*if (DGV.Name == "URLsDGV")
                {
                    if (Dt.Columns.Contains("nazwa"))
                        Dt.Columns["nazwa"].ColumnName = "NameURLsDGV";
                    if (Dt.Columns.Contains("data_dodania"))
                        Dt.Columns["data_dodania"].ColumnName = "DateURLsDGV";
                    if (Dt.Columns.Contains("uwagi"))
                        Dt.Columns["uwagi"].ColumnName = "CommentsURLsDGV";
                    if (Dt.Columns.Contains("URL"))
                        Dt.Columns["URL"].ColumnName = "URLURLsDGV";
                }
                else if (DGV.Name == "FilesDGV")
                {
                    if (Dt.Columns.Contains("nazwa"))
                        Dt.Columns["nazwa"].ColumnName = "FileName";
                    if (Dt.Columns.Contains("data_dodania"))
                        Dt.Columns["data_dodania"].ColumnName = "Date";
                    if (Dt.Columns.Contains("uwagi"))
                        Dt.Columns["uwagi"].ColumnName = "Comments";
                }*/

                DGV.DataSource = Dt;

                if (DGV.Columns.Contains("id"))
                    DGV.Columns["id"].Visible = false;
            }
            catch (Exception)
            {
                
            }            
        }

        private void URLsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == URLsDGV.Columns["URLURLsDGV"].Index)
                    Process.Start(new UriBuilder(URLsDGV[e.ColumnIndex, e.RowIndex].Value.ToString()).Uri.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (URLsDGV.CurrentRow == null)
                return;

            string message = string.Format("{0} \"" + URLsDGV.CurrentRow.Cells["NameURLsDGV"].Value.ToString() + "\"?", _translationsDictionary.ContainsKey("to_delete") ? _translationsDictionary["to_delete"] : "Usunąć");
            string caption = _translationsDictionary.ContainsKey("url_deleting") ? _translationsDictionary["url_deleting"] : "Usuwanie adresu";

            //if (MessageBox.Show("Usunąć \"" + URLsDGV.CurrentRow.Cells["NameURLsDGV"].Value.ToString() + "\" z bazy?", "Usuwanie adresu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteResource(URLsDGV.CurrentRow.Cells["id"].Value.ToString());

                GetURLsData();
            }
        }

        private void URLsDGV_DataSourceChanged(object sender, EventArgs e)
        {
            CheckControlsState();
        }

        private void CheckControlsState()
        {
            if (FilesDGV.Rows.Count > 0)
            {
                EditFilesButton.Enabled = true;
                DeleteFilesButton.Enabled = true;
                DownloadFileButton.Enabled = true;
            }
            else
            {
                EditFilesButton.Enabled = false;
                DeleteFilesButton.Enabled = false;
                DownloadFileButton.Enabled = false;
            }

            if (URLsDGV.Rows.Count > 0)
            {
                EditButton.Enabled = true;
                DeleteButton.Enabled = true;
            }
            else
            {
                EditButton.Enabled = false;
                DeleteButton.Enabled = false;
            }
        }

        private void FilesDGV_DataSourceChanged(object sender, EventArgs e)
        {
            CheckControlsState();
        }

        private void DeleteFilesButton_Click(object sender, EventArgs e)
        {
            if (FilesDGV.CurrentRow == null)
                return;

            string message = string.Format("{0} \"" + FilesDGV.CurrentRow.Cells[FileName.Name].Value.ToString() + "\"?", _translationsDictionary.ContainsKey("to_delete") ? _translationsDictionary["to_delete"] : "Usunąć");
            string caption = _translationsDictionary.ContainsKey("file_deleting") ? _translationsDictionary["file_deleting"] : "Usuwanie adresu";

            //if (MessageBox.Show("Usunąć \"" + FilesDGV.CurrentRow.Cells["FileName"].Value.ToString() + "\" z bazy?", "Usuwanie pliku", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteResource(FilesDGV.CurrentRow.Cells["id"].Value.ToString());

                GetFilesData();
            }
        }

        private void DeleteResource(string ID)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "DELETE FROM documents WHERE id = @id";
            Command.Parameters.AddWithValue("@id", ID);

            if (CommonFunctions.WriteData(Command, ref Settings.Connection))
            {
                string message = _translationsDictionary.ContainsKey("removed") ? _translationsDictionary["to_delete"] : "Usunięto!";
                string caption = _translationsDictionary.ContainsKey("resource_deleting") ? _translationsDictionary["resource_deleting"] : "Usuwanie zasobu";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show("Usunięto!", "Usuwanie zasobu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddFilesButton_Click(object sender, EventArgs e)
        {
            AttachmentForm Af = new AttachmentForm(1, 1);

            if (Af.ShowDialog() == DialogResult.OK)
                GetFilesData();            
        }

        private void EditFilesButton_Click(object sender, EventArgs e)
        {
            if (FilesDGV.SelectedRows.Count > 0)
            {
                //AttachmentForm Af = new AttachmentForm(1, 2, FilesDGV.CurrentRow.Cells["id"].Value.ToString(), FilesDGV.CurrentRow.Cells["FileName"].Value.ToString(), "", FilesDGV.CurrentRow.Cells["Comments"].Value.ToString());
                AttachmentForm Af = new AttachmentForm(1, 2, FilesDGV.SelectedRows[0].Cells["id"].Value.ToString(), FilesDGV.SelectedRows[0].Cells["FileName"].Value.ToString(), "", FilesDGV.SelectedRows[0].Cells["Comments"].Value.ToString());
                
                if (Af.ShowDialog() == DialogResult.OK)
                    GetFilesData();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AttachmentForm Af = new AttachmentForm(2, 1);

            if (Af.ShowDialog() == DialogResult.OK)
                GetURLsData();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (URLsDGV.SelectedRows.Count > 0)
            {
                //AttachmentForm Af = new AttachmentForm(2, 2, URLsDGV.CurrentRow.Cells["id"].Value.ToString(), URLsDGV.CurrentRow.Cells["NameURLsDGV"].Value.ToString(), URLsDGV.CurrentRow.Cells["URLURLsDGV"].Value.ToString(), URLsDGV.CurrentRow.Cells["CommentsURLsDGV"].Value.ToString());
                AttachmentForm Af = new AttachmentForm(2, 2, URLsDGV.SelectedRows[0].Cells["id"].Value.ToString(), URLsDGV.SelectedRows[0].Cells["NameURLsDGV"].Value.ToString(), URLsDGV.SelectedRows[0].Cells["URLURLsDGV"].Value.ToString(), URLsDGV.SelectedRows[0].Cells["CommentsURLsDGV"].Value.ToString());

                if (Af.ShowDialog() == DialogResult.OK)
                    GetURLsData();
            }
        }

        private void FilesDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DownloadAndSaveFile(FilesDGV["FileName", e.RowIndex].Value.ToString(), FilesDGV["id", e.RowIndex].Value.ToString());                
            }
        }

        private void DownloadAndSaveFile(string FileName, string ID)
        {
            WaitForm Wait = new WaitForm();

            try
            {
                SaveFileDialog SF = new SaveFileDialog();
                SF.Filter = string.Format("{0} (*.*)|*.*", _translationsDictionary.ContainsKey("all_files") ? _translationsDictionary["all_files"] : "Wszystkie pliki");
                SF.FileName = FileName;
                //SF.CheckFileExists = true;
                SF.AddExtension = true;

                if (SF.ShowDialog() == DialogResult.OK)
                {                    
                    this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                    SqlCommand Command = new SqlCommand();
                    Command.CommandText = "SELECT plik FROM documents WHERE id = @id;";
                    Command.Parameters.AddWithValue("@id", ID);

                    DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                    byte[] File = null;

                    if (Dt.Rows[0].ItemArray[0] != null)
                        File = (byte[])Dt.Rows[0].ItemArray[0];

                    if (Dt.Rows.Count > 0)
                    {
                        FileStream fs = (FileStream) SF.OpenFile();
                        fs.Write(File, 0, File.Length);
                        fs.Close();
                    }

                    string message = _translationsDictionary.ContainsKey("saved") ? _translationsDictionary["saved"] : "Zapisano!";
                    string caption = _translationsDictionary.ContainsKey("data_save") ? _translationsDictionary["data_save"] : "Zapis danych";

                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("Zapisano!", "Zapis danych", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    message = _translationsDictionary.ContainsKey("to_open") ? _translationsDictionary["to_open"] : "Zapisano!";
                    caption = _translationsDictionary.ContainsKey("file_opening") ? _translationsDictionary["file_opening"] : "Zapis danych";
                    if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //if (MessageBox.Show("Otworzyć?", "Otwieranie pliku", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(SF.FileName);
                    }

                    this.DialogResult = DialogResult.None;
                }                                
            }
            catch (Exception Ex)
            {
                string caption = _translationsDictionary.ContainsKey("error") ? _translationsDictionary["error"] : "błąd";
                MessageBox.Show(Ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Wait.Close();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (FilesDGV.CurrentRow != null)
                DownloadAndSaveFile(FilesDGV["FileName", FilesDGV.CurrentRow.Index].Value.ToString(), FilesDGV["id", FilesDGV.CurrentRow.Index].Value.ToString());
        }

        private void FilesDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (FilesDGV.CurrentRow != null && e.KeyData == Keys.Enter)
                DownloadAndSaveFile(FilesDGV["FileName", FilesDGV.CurrentRow.Index].Value.ToString(), FilesDGV["id", FilesDGV.CurrentRow.Index].Value.ToString());        
        }

        private void Lock()
        {
            if (Settings.ReadOnly)
            {
                EditButton.Visible = false;
                DeleteButton.Visible = false;

                EditFilesButton.Visible = false;
                DeleteFilesButton.Visible = false;

                AddButton.Text = _translationsDictionary.ContainsKey("view_entry") ? _translationsDictionary["view_entry"] : "Podgląd wpisu";
                AddFilesButton.Text = _translationsDictionary.ContainsKey("view_entry") ? _translationsDictionary["view_entry"] : "Podgląd wpisu";                
            }
        }

        private void SourceForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
