using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Zrodla
{
    public partial class AttachmentForm : Form
    {
        private string PathToFile; 
        private string ID;

        private enum ModeEnum {ADD = 1, EDIT};
        private enum KindEnum {FILE = 1, URL};

        private int CurrentModeEnum;
        private int CurrentKindEnum;

        private bool FileChanged = false;
        private Dictionary<string, string> _translationsDictionary;

        public AttachmentForm(int Kind, int Mode)
        {
            InitializeComponent();            
            
            _translationsDictionary = new Dictionary<string, string>();

            CurrentModeEnum = Mode;
            CurrentKindEnum = Kind;

            if (CurrentModeEnum == (int) ModeEnum.ADD)
            {
                if (CurrentKindEnum == (int) KindEnum.FILE)
                    this.Text = "Dodawanie pliku";
                else if (CurrentKindEnum == (int) KindEnum.URL)
                    this.Text = "Dodawanie adresu URL";
            }
            else if (CurrentModeEnum == (int) ModeEnum.EDIT)
            {
                if (CurrentKindEnum == (int) KindEnum.FILE)
                    this.Text = "Modyfikacja pliku";
                else if (CurrentKindEnum == (int) KindEnum.URL)
                    this.Text = "Modyfikacja adresu URL";
            }

            if (CurrentKindEnum == (int) KindEnum.URL)
            {
                FileNameLabel.Text = "Nazwa";
                AttachButton.Visible = false;
                FileNameTextBox.ReadOnly = false;
            }
            else if (CurrentKindEnum == (int) KindEnum.FILE)
            {
                URLLabel.Visible = false;
                URLTextBox.Visible = false;

                label2.Location = new Point(12, 46);
                CommentsTextBox.Location = new Point(80, 43);

                CommentsTextBox.Size = new Size(CommentsTextBox.Width, CommentsTextBox.Height + 16);
            }

            Lock();

            setControlsText();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(CancelButton, "cancel");
            mapping.Add(label2, "comments");
            mapping.Add(OKButton, "save");
            mapping.Add(URLLabel, "url_address");

            if (CurrentKindEnum == (int) KindEnum.URL)
                mapping.Add(FileNameLabel, "name"); 
            else if (CurrentKindEnum == (int)KindEnum.FILE)
                mapping.Add(FileNameLabel, "file");

            string windowText = "";

            if (CurrentModeEnum == (int)ModeEnum.ADD)
            {
                if (CurrentKindEnum == (int) KindEnum.FILE)
                    windowText = "file_adding";
                else if (CurrentKindEnum == (int) KindEnum.URL)
                    windowText = "url_adding";
            }
            else if (CurrentModeEnum == (int)ModeEnum.EDIT)
            {
                if (CurrentKindEnum == (int)KindEnum.FILE)                    
                    windowText = "file_modyfing";
                else if (CurrentKindEnum == (int)KindEnum.URL)
                    windowText = "url_modyfing";
            }

            mapping.Add(this, windowText);

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        public AttachmentForm(int Kind, int Mode, string ID, string FileName, string URL, string Comments) : this (Kind, Mode)
        {
            FileNameTextBox.Text = FileName;
            URLTextBox.Text = URL;
            CommentsTextBox.Text = Comments;
            this.ID = ID;
        }

        private void AttachButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = false;

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                PathToFile = OFD.FileName;
                FileNameTextBox.Text = OFD.SafeFileName;
                FileChanged = true;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (FileNameTextBox.Text.Trim() == "")
            {
                if (CurrentKindEnum == (int) KindEnum.FILE)
                    MessageBox.Show(_translationsDictionary.ContainsKey("please_select_file") ? _translationsDictionary["please_select_file"] : "Proszę wybrać plik", _translationsDictionary.ContainsKey("to_correct_data") ? _translationsDictionary["to_correct_data"] : "Popraw dane", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(_translationsDictionary.ContainsKey("file_name_cannot_be_empty") ? _translationsDictionary["file_name_cannot_be_empty"] : "Nazwa nie może być pusta!", _translationsDictionary.ContainsKey("to_correct_data") ? _translationsDictionary["to_correct_data"] : "Popraw dane", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.None;                
                FileNameTextBox.Focus();

                return;
            }

            if (URLTextBox.Text.Trim() == "" && CurrentKindEnum == (int)KindEnum.URL)
            {                
                MessageBox.Show(_translationsDictionary.ContainsKey("url_cannot_be_empty") ? _translationsDictionary["url_cannot_be_empty"] : "Adres nie może być pusty!", _translationsDictionary.ContainsKey("to_correct_data") ? _translationsDictionary["to_correct_data"] : "Popraw dane", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.None;
                URLTextBox.Focus();

                return;
            }
            
            if (CurrentKindEnum == (int) KindEnum.FILE)
                ModifyFile();
            if (CurrentKindEnum == (int) KindEnum.URL)
                ModifyURL();

            this.Close();           
        }

        private void ModifyFile()
        {
            byte[] file = null;

            if (FileChanged)
            {
                file = GetFile(PathToFile);

                if (file == null)
                    return;
            }

            SqlCommand Command = new SqlCommand();

            if (CurrentModeEnum == (int)ModeEnum.ADD)
            {
                Command = new SqlCommand("INSERT INTO documents (kod, nazwa, plik, rodzaj_zasobu, id_rodzaj, uwagi) VALUES (@kod, @nazwa, @plik, @rodzaj_zasobu, @id_rodzaj, @uwagi);");
                Command.Parameters.AddWithValue("@kod", Settings.Code);
                Command.Parameters.AddWithValue("@nazwa", FileNameTextBox.Text);
                Command.Parameters.Add("@plik", SqlDbType.VarBinary).SqlValue = file;
                Command.Parameters.AddWithValue("@rodzaj_zasobu", Settings.KindOfResource);
                Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
                Command.Parameters.AddWithValue("@uwagi", CommentsTextBox.Text);
            }
            else if (CurrentModeEnum == (int)ModeEnum.EDIT)
            {
                string Query = "UPDATE documents SET ";

                if (FileChanged)
                    Query += "nazwa = @nazwa, plik = @plik, ";

                Query += "uwagi = @uwagi WHERE id = @id;";

                Command = new SqlCommand(Query);

                if (FileChanged)
                {
                    Command.Parameters.AddWithValue("@nazwa", FileNameTextBox.Text);
                    Command.Parameters.Add("@plik", SqlDbType.VarBinary).SqlValue = file;
                }

                Command.Parameters.AddWithValue("@uwagi", CommentsTextBox.Text);
                Command.Parameters.AddWithValue("@id", ID);
            }
            
            WaitForm Wait = new WaitForm();
            this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

            if (CommonFunctions.WriteData(Command, ref Settings.Connection))
            {
                string Text = "";
                string Caption = "";

                if (CurrentModeEnum == (int)ModeEnum.ADD)
                {
                    Text = _translationsDictionary.ContainsKey("added") ? _translationsDictionary["added"] : "Dodano!";
                    
                    Caption = _translationsDictionary.ContainsKey("file_adding") ? _translationsDictionary["file_adding"] : "Dodawanie pliku";                    
                                           
                }
                else if (CurrentModeEnum == (int)ModeEnum.EDIT)
                {
                    Text = _translationsDictionary.ContainsKey("modified") ? _translationsDictionary["modified"] : "Zmodyfikowano!";
                    
                    Caption = _translationsDictionary.ContainsKey("file_modyfing") ? _translationsDictionary["file_modyfing"] : "Modyfikacja pliku";
                }

                MessageBox.Show(Text, Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Wait.Close();
        }

        private void ModifyURL()
        {
            SqlCommand Command = new SqlCommand();

            if (CurrentModeEnum == (int)ModeEnum.ADD)
            {
                Command = new SqlCommand("INSERT INTO documents (kod, nazwa, URL, rodzaj_zasobu, id_rodzaj, uwagi) VALUES (@kod, @nazwa, @URL, @rodzaj_zasobu, @id_rodzaj, @uwagi);");
                Command.Parameters.AddWithValue("@kod", Settings.Code);
                Command.Parameters.AddWithValue("@nazwa", FileNameTextBox.Text);
                //Command.Parameters.AddWithValue("@URL", URLTextBox.Text);
                Command.Parameters.AddWithValue("@URL", new UriBuilder(URLTextBox.Text).Uri.ToString()); 
                Command.Parameters.AddWithValue("@rodzaj_zasobu", Settings.KindOfResource);
                Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
                Command.Parameters.AddWithValue("@uwagi", CommentsTextBox.Text);
            }
            else if (CurrentModeEnum == (int)ModeEnum.EDIT)
            {
                Command = new SqlCommand("UPDATE documents SET nazwa = @nazwa, URL = @URL, uwagi = @uwagi WHERE id = @id;");
                
                Command.Parameters.AddWithValue("@nazwa", FileNameTextBox.Text);
                //Command.Parameters.AddWithValue("@URL", URLTextBox.Text);
                Command.Parameters.AddWithValue("@URL", new UriBuilder(URLTextBox.Text).Uri.ToString()); 
                Command.Parameters.AddWithValue("@uwagi", CommentsTextBox.Text);
                Command.Parameters.AddWithValue("@id", ID);
            }

            if (CommonFunctions.WriteData(Command, ref Settings.Connection))
            {
                string Text = "";
                string Caption = "";

                if (CurrentModeEnum == (int)ModeEnum.ADD)
                {
                    Text = _translationsDictionary.ContainsKey("added") ? _translationsDictionary["added"] : "Dodano!";
                    Caption = _translationsDictionary.ContainsKey("url_adding") ? _translationsDictionary["url_adding"] : "Dodawanie adresu URL";
                }
                else if (CurrentModeEnum == (int)ModeEnum.EDIT)
                {
                    Text = _translationsDictionary.ContainsKey("modified") ? _translationsDictionary["modified"] : "Zmodyfikowano!";
                    Caption = _translationsDictionary.ContainsKey("url_modyfing") ? _translationsDictionary["url_modyfing"] : "Modyfikacja adresu URL";
                }

                MessageBox.Show(Text, Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static byte[] GetFile(string filePath)
        {
            try
            {
                FileStream Stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader Reader = new BinaryReader(Stream);

                byte[] File = Reader.ReadBytes((int)Stream.Length);

                Reader.Close();
                Stream.Close();

                return File;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return null;
        }

        private void AttachmentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Lock()
        {
            if (Settings.ReadOnly)
            {
                this.Text = _translationsDictionary.ContainsKey("view_entry") ? _translationsDictionary["view_entry"] : "Podgląd wpisu";
                FileNameTextBox.ReadOnly = true;
                CommentsTextBox.ReadOnly = true;
                URLTextBox.ReadOnly = true;
                OKButton.Visible = false;
                AttachButton.Visible = false;

                CancelButton.Location = new Point(347, 251);
            }
        }
    }
}
