using System;
using System.Data;
using System.Windows.Forms;
using Wypozyczalnia;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        Connection NewConnection;
        
        public Main()
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            //this.Text += " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            //mapping.Add(this, "admin_main_form");
            mapping.Add(groupBox1, "borrow_office");
            mapping.Add(wypozyczalniaConfigButton, "configuration");
            mapping.Add(label2, "con_status");
            mapping.Add(coliberGroupBox, "app_name");
            mapping.Add(ConfigButton, "configuration");
            mapping.Add(label1, "con_status");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
            this.użytkownicyToolStripMenuItem.Text = _T("admin");
            this.autorzyToolStripMenuItem.Text = _T("authors");
            this.departamentyToolStripMenuItem.Text = _T("departments");
            this.dostawcyToolStripMenuItem.Text = _T("magazine_distributors");
            this.językiToolStripMenuItem.Text = _T("languages");
            this.kolejnośćSortowaniaToolStripMenuItem.Text = _T("sort_order");
            this.księgiInwentarzoweToolStripMenuItem.Text = _T("invertories_form");
            this.odpowiedzialnościToolStripMenuItem.Text = _T("responsibilities");
            this.państwaToolStripMenuItem.Text = _T("countries");
            this.serieToolStripMenuItem.Text = _T("series");
            this.słowaKluczoweToolStripMenuItem.Text = _T("keywords");
            this.wydawcyToolStripMenuItem.Text = _T("editors");
            this.informacjaOWłaścicieluToolStripMenuItem.Text = _T("library_info");
            this.zakończToolStripMenuItem.Text = _T("close");
            this.bazaDanychToolStripMenuItem.Text = _T("database");
            this.archiwizowanieToolStripMenuItem.Text = _T("archiving");
            this.wypożyczalniaToolStripMenuItem.Text = _T("borrow_office");
            this.konfiguracjaToolStripMenuItem.Text = _T("configuration");
            this.pomocToolStripMenuItem.Text = _T("help");
            this.podręcznikUżytkownikaToolStripMenuItem.Text = _T("user_guide");
            this.oProgramieToolStripMenuItem.Text = _T("about_application");
            this.użytkownicyToolStripMenuItem1.Text = _T("users");
        }
        private void informacjaOWlascicieluToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutOwner AboutOwnerForm = new AboutOwner();
            AboutOwnerForm.ShowDialog();
        }

        private void panstwaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                Countries CountriesForm = new Countries(NewConnection);
                CountriesForm.ShowDialog();
            }
            else
                MessageBox.Show(_T("connection_failed"));
        }

        private void zakonczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            if (ConnectionButton.Text == _T("connect") && NewConnection.AppConnection.State == ConnectionState.Closed)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    NewConnection.SetConnection("coliber.ini");
                    NewConnection.AppConnection.Open();

                    ConnectionButton.Text = _T("disconnect");
                    StatusPictureBox.Image = WindowsFormsApplication1.Properties.Resources.yes;
                    if (NewConnection.AppConnection.DataSource == "")
                        StatusLabel.Text = _T("connected") + ". (local)";
                    else
                        StatusLabel.Text = _T("connected") + ". (" + NewConnection.AppConnection.DataSource + ")";

                    ConfigButton.Enabled = false;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

                this.Cursor = Cursors.Default;
                Wait.Close();
                this.TopMost = true;
                this.TopMost = false;
            }
            else if (ConnectionButton.Text == _T("disconnect") && NewConnection.AppConnection.State == ConnectionState.Open)
            {
                try
                {
                    NewConnection.AppConnection.Close();

                    ConnectionButton.Text = _T("connect");
                    StatusPictureBox.Image = WindowsFormsApplication1.Properties.Resources.no;
                    StatusLabel.Text = _T("disconnected");

                    ConfigButton.Enabled = true;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            NewConnection = new Connection("coliber.ini");
            if (System.IO.File.Exists("Debug.SQL")) MessageBox.Show(NewConnection.ConnectionString,"Load");

            try
            {
                NewConnection.AppConnection.ConnectionTimeout = 2;
                NewConnection.AppConnection.Open();
            }
            catch (Exception)
            {
            }

            try
            {
                Settings.wypozyczalniaSetSettings();// = new Connection("wypozyczalnia.ini");
                Settings.wypozyczalniaConnection.Close();
                Settings.wypozyczalniaConnection.Open();
            }
            catch (Exception ex)
            {
                    
            }
                        
            coliberStatus();
            
            wypozyczalniaStatus();
        }

        private void coliberStatus()
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                ConnectionButton.Text = _T("disconnect");
                StatusPictureBox.Image = WindowsFormsApplication1.Properties.Resources.yes;
                StatusLabel.Text = _T("connected") + ". ";
                ConfigButton.Enabled = false;
            }
            else if (NewConnection.AppConnection.State == ConnectionState.Closed)
            {
                ConnectionButton.Text = _T("connect");
                StatusPictureBox.Image = WindowsFormsApplication1.Properties.Resources.no;
                StatusLabel.Text = "Rozłączony. ";
                ConfigButton.Enabled = true;
            }
        }

        private void wypozyczalniaStatus()
        {
            if (Settings.wypozyczalniaConnection == null || Settings.wypozyczalniaConnection.State == ConnectionState.Closed)
            {
                wypozyczalniaConnectionButton.Text = _T("connect");
                wypozyczalniaStatusPictureBox.Image = WindowsFormsApplication1.Properties.Resources.no;
                wypozyczalniaStatusLabel.Text = _T("disconnected");
                wypozyczalniaConfigButton.Enabled = true;
            }
            else if (Settings.wypozyczalniaConnection.State == ConnectionState.Open)
            {
                wypozyczalniaConnectionButton.Text = _T("disconnect");
                wypozyczalniaStatusPictureBox.Image = WindowsFormsApplication1.Properties.Resources.yes;
                wypozyczalniaStatusLabel.Text = _T("connected") + ". ";
                wypozyczalniaConfigButton.Enabled = false;
            }
        }

        private void uzytkownicyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                Users UsersForm = new Users();
                UsersForm.ShowDialog();
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void jezykiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                Languages LanguagesForm = new Languages(NewConnection);
                LanguagesForm.ShowDialog();
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void autorzyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                Authors AuthorsForm = new Authors(NewConnection);

                Wait.Close();

                AuthorsForm.ShowDialog();
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void wydawcyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                SelectPublishers SelectPublishersForm = new SelectPublishers(NewConnection);
                SelectPublishersForm.ShowDialog();
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void słowaKluczoweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                SelectTableForKeys SelectTableForKeysForm = new SelectTableForKeys(NewConnection);
                SelectTableForKeysForm.ShowDialog();
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void serieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                Series SeriesForm = new Series(NewConnection);

                Wait.Close();

                SeriesForm.ShowDialog();                
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void podserieToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                SubSeries SubSeriesForm = new SubSeries(NewConnection);

                SubSeriesForm.ShowDialog();

                Wait.Close();
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ConfigButton_Click(object sender, EventArgs e)
        {
            Configurator ConfiguratorForm = new Configurator("coliber", "coliber.ini");
            ConfiguratorForm.ShowDialog();

            if (ConfiguratorForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    NewConnection = new Connection("coliber.ini");
                    NewConnection.AppConnection.Close();
                    NewConnection.AppConnection.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }               
            }

            coliberStatus();
            wypozyczalniaStatus();
        }

        private void departamentyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                Departments DepartmentsForm = new Departments(NewConnection);

                Wait.Close();

                DepartmentsForm.ShowDialog();
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /*
        private void reindeksacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                if (MessageBox.Show("Reindeksować bazy?", "Reindeksacja baz", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        WaitForm Wait = new WaitForm();
                        this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                        string Query = "DECLARE @TableName VARCHAR(255) \n" +
                                        "DECLARE @sql NVARCHAR(500) \n" +
                                        "DECLARE @fillfactor INT \n" +
                                        "SET @fillfactor = 80 \n" +
                                        "DECLARE TableCursor CURSOR FOR \n" +
                                        "   SELECT OBJECT_SCHEMA_NAME([object_id])+'.'+name AS TableName FROM sys.tables \n" +
                                        "OPEN TableCursor \n" +
                                        "FETCH NEXT FROM TableCursor INTO @TableName \n" +
                                        "WHILE @@FETCH_STATUS = 0 \n" +
                                        "   BEGIN \n" +
                                        "       SET @sql = 'ALTER INDEX ALL ON ' + @TableName + ' REBUILD WITH (FILLFACTOR = ' + CONVERT(VARCHAR(3),@fillfactor) + ')' \n" +
                                        "       EXEC (@sql) \n" +
                                        "       FETCH NEXT FROM TableCursor INTO @TableName \n" +
                                        "   END \n" +
                                        "CLOSE TableCursor \n" +
                                        "DEALLOCATE TableCursor \n";

                        OdbcCommand Command = new OdbcCommand(Query, NewConnection.AppConnection);
                        Command.ExecuteReader();

                        Wait.Close();

                        MessageBox.Show("Reindeksacja została wykonana!", "Reindeksacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }*/

        private void odpowiedzialnościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                OdpowiedzialnosciForm OF = new OdpowiedzialnosciForm();

                Wait.Close();

                OF.ShowDialog();
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        private void kolejnośćSortowaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {                        
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                SortOrderForm SOF = new SortOrderForm();

                Wait.Close();

                SOF.ShowDialog();
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void dostawcyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                DistributorForm DF = new DistributorForm();

                Wait.Close();

                DF.ShowDialog();
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);                         
        }

        private void księgiInwentarzoweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewConnection.AppConnection.State == ConnectionState.Open)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                InvertoryForm DF = new InvertoryForm();

                Wait.Close();

                DF.ShowDialog();                
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void wypozyczalniaConfigButton_Click(object sender, EventArgs e)
        {
            Configurator ConfiguratorForm = new Configurator("wypozyczalnia", "wypozycz.ini");
            ConfiguratorForm.ShowDialog();

            if (ConfiguratorForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Settings.wypozyczalniaSetSettings();// = new Connection("wypozyczalnia.ini");
                    Settings.wypozyczalniaConnection.Close();
                    Settings.wypozyczalniaConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            wypozyczalniaStatus();
        }

        private void wypozyczalniaConnectionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Settings.wypozyczalniaConnectionStringSql))
            {
                MessageBox.Show("Brak pliku wypozycz.ini!");
                return;                
            }

            if (wypozyczalniaConnectionButton.Text == _T("connect") && Settings.wypozyczalniaConnection.State == ConnectionState.Closed)
            {
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    Settings.wypozyczalniaSetSettings();
                    Settings.wypozyczalniaConnection.Open();

                    wypozyczalniaConnectionButton.Text = _T("disconnect");
                    wypozyczalniaStatusPictureBox.Image = WindowsFormsApplication1.Properties.Resources.yes;

                    if (Settings.wypozyczalniaConnection.DataSource == "")
                        wypozyczalniaStatusLabel.Text = _T("connected") + ". (local)";
                    else
                        wypozyczalniaStatusLabel.Text = _T("connected") + ". (" + Settings.wypozyczalniaConnection.DataSource + ")";

                    wypozyczalniaConfigButton.Enabled = false;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

                this.Cursor = Cursors.Default;
                Wait.Close();
                this.TopMost = true;
                this.TopMost = false;
            }
            else if (wypozyczalniaConnectionButton.Text == _T("disconnect") && Settings.wypozyczalniaConnection.State == ConnectionState.Open)
            {
                try
                {
                    Settings.wypozyczalniaConnection.Close();

                    wypozyczalniaConnectionButton.Text = _T("connect");
                    wypozyczalniaStatusPictureBox.Image = WindowsFormsApplication1.Properties.Resources.no;
                    wypozyczalniaStatusLabel.Text = _T("disconnected");

                    wypozyczalniaConfigButton.Enabled = true;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void konfiguracjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.wypozyczalniaConnection.State == ConnectionState.Open)
            {
                ConfigurationForm cf = new ConfigurationForm(0);
                cf.ShowDialog();
            }
            else
                MessageBox.Show(_T("connection_failed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void podręcznikUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Dokumentacja", "Panel Administratora - Podręcznik użytkownika.pdf"));
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
