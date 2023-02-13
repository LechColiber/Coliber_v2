using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Czasopisma;
using Ksiazki;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Coliber
{
    public partial class MainForm : Form
    {
        private Wypozyczalnia.Manager _manager;
        private System.Windows.Forms.Timer _timer;
        private Dictionary<string, string> _translationsDictionary;
        public MainForm()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            InitializeComponent();

            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            SetWindowTitle();
            _manager = new Wypozyczalnia.Manager(Int32.Parse(Settings.employeeID), Settings.wypozyczalniaConnectionString);
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000*60;
            _timer.Start();
            _timer.Tick += _timer_Tick;

            UpdateOrdersButtonsText();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(artykułToolStripMenuItem, "article");
            mapping.Add(ribbonTab8, "articles");
            mapping.Add(ribbonTab7, "magazine");
            mapping.Add(czasopismoToolStripMenuItem, "magazine");
            mapping.Add(dodajToolStripMenuItem, "add");
            mapping.Add(książkaToolStripMenuItem, "book");
            mapping.Add(ribbonTab6, "books");
            mapping.Add(EditArticleRButton, "modify");
            mapping.Add(EditBookRButton, "modify");
            mapping.Add(EditMagazineRButton, "modify");
            mapping.Add(aboutOrbMenuItem, "about_application");
            mapping.Add(guideOrbMenuItem, "user_guide");
            mapping.Add(ribbonTab9, "reports");
            mapping.Add(DeleteArticleRButton, "delete");
            mapping.Add(DeleteBookRButton, "delete");
            mapping.Add(DeleteMagazineRButton, "delete");
            mapping.Add(userRB, "users");
            mapping.Add(ExitMenuItem, "exit");
            //mapping.Add(aaaToolStripMenuItem.Text, "change_inventory");
            mapping.Add(wyjścieToolStripMenuItem, "exit");
            mapping.Add(exitOrbMenuItem, "exit");
            mapping.Add(resourcesRB, "resources");
            mapping.Add(aaaToolStripMenuItem, "change_invertory");
            mapping.Add(ribbonButton1, "borrowed_resources");
            mapping.Add(StatsRibbonButton, "invertory_stats");
            mapping.Add(quickRB, "quick_borrow");
            mapping.Add(borrowRB, "borrow");
            mapping.Add(ordersButton, "orders");
            mapping.Add(TitleChangeRButton, "change_title");
            mapping.Add(DopiszAkcesjeRButton, "add_accession");
            mapping.Add(NewBookRButton, "new_book");
            mapping.Add(NewMagazineRButton, "new_magazine");
            mapping.Add(NewArticleRButton, "new_article");
            mapping.Add(DeleteAkcesjeRButton, "delete_accession");
            mapping.Add(UbytkiMagazineRButton, "losses_book");
            mapping.Add(UbytkiBookRButton, "losses_book");
            mapping.Add(NewAkcesjaRButton, "new_accession");
            mapping.Add(wypStatsRB, "borrows_stats");
            mapping.Add(SeryjneRButton, "serial_publications");
            mapping.Add(ribbonTab10, "borrow_office");            

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            UpdateOrdersButtonsText();
        }

        public void UpdateOrdersButtonsText()
        {
            int nIle;
            nIle = _manager.GetCurrentOrdersCount();
            try
            {
                ordersButton.Text = string.Format("{0} ({1})", _translationsDictionary.ContainsKey("orders") ? _translationsDictionary["orders"] : "Zamówienia", nIle);
            }
            catch 
            {

            }
        }

        private void StatsRibbonButton_Click(object sender, EventArgs e)
        {
            Reports.WydrukKIForm Wyd = new Reports.WydrukKIForm(Settings.ID_rodzaj);
            //Wyd.ShowDialog();
            Wyd.MdiParent = this;
            Wyd.Show();
        }

        // dodanie książki
        private void NewBookRButton_Click(object sender, EventArgs e)
        {
            if (Settings.ID_rodzaj == 0)
            {
                ChooseInvertoryForm CIF = new ChooseInvertoryForm();

                if (CIF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DetailsForm DF = new DetailsForm(CIF.IDRodzaj, Settings.employeeID);
                    DF.MdiParent = this;
                    DF.Show();//Dialog();
                    //DF.ShowDialog();
                }
            }
            else
            {
                DetailsForm DF = new DetailsForm(Settings.ID_rodzaj, Settings.employeeID);
                //DF.ShowDialog();
                DF.MdiParent = this;
                DF.Show();//Dialog();
            }
        }

        // edycja książki
        private void EditBookRButton_Click(object sender, EventArgs e)
        {
            BookListForm BLF = new BookListForm(Settings.ID_rodzaj, BookListForm.ModeEnum.Edit, Settings.employeeID);
            BLF.MdiParent = this;
            BLF.Show();//Dialog();
           // BLF.ShowDialog();
        }

        // usuwanie książki
        private void DeleteBookRButton_Click(object sender, EventArgs e)
        {
            BookListForm BLF = new BookListForm(Settings.ID_rodzaj, BookListForm.ModeEnum.Delete, Settings.employeeID);
            BLF.MdiParent = this;
            BLF.Show();//Dialog();
            // BLF.ShowDialog();
        }

        // dodanie artykułu
        private void NewArticleRButton_Click(object sender, EventArgs e)
        {
            if (Settings.ID_rodzaj == 0)
            {
                ChooseInvertoryForm CIF = new ChooseInvertoryForm();

                if (CIF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Artykuly.ChooseType CT = new Artykuly.ChooseType(CIF.IDRodzaj, 1, this);
                }
            }
            else
            {
                Artykuly.ChooseType CT = new Artykuly.ChooseType(Settings.ID_rodzaj, 1, this);
            } 
        }

        // edycja artykułu
        private void EditArticleRButton_Click(object sender, EventArgs e)
        {
            Artykuly.ChooseType CT = new Artykuly.ChooseType(Settings.ID_rodzaj, 2, this);
        }

        // usuwanie artykułu
        private void DeleteArticleRButton_Click(object sender, EventArgs e)
        {
            Artykuly.ChooseType CT = new Artykuly.ChooseType(Settings.ID_rodzaj, 3, this);
        }

        // edycja/usuwanie ubytków książek
        private void UbytkiBookRButton_Click(object sender, EventArgs e)
        {
            Ubytki.UbytkiForm UF = new Ubytki.UbytkiForm(Settings.ID_rodzaj, Ubytki.UbytkiForm.KindEnum.Book);
            //UF.ShowDialog();
            UF.MdiParent = this;
            UF.Show();
        }

        // dodanie czasopisma
        private void NewMagazineRButton_Click(object sender, EventArgs e)
        {
            if (Settings.ID_rodzaj == 0)
            {
                ChooseInvertoryForm CIF = new ChooseInvertoryForm();

                if (CIF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {                    
                    MagazineForm MF = new MagazineForm(CIF.IDRodzaj, Settings.employeeID);
                    MF.MdiParent = this;
                    MF.Show();
                    //MF.ShowDialog();
                }
            }
            else
            {
                MagazineForm MF = new MagazineForm(Settings.ID_rodzaj, Settings.employeeID);
                MF.MdiParent = this;
                MF.Show();
                //MF.ShowDialog();
            }             
        }

        // edycja czasopisma
        private void EditMagazineRButton_Click(object sender, EventArgs e)
        {
            ChooseForm CF = new ChooseForm(Settings.ID_rodzaj, ChooseForm.ModeEnum.Edit, Settings.employeeID);
            CF.MdiParent = this;
            CF.Show();
            //CF.ShowDialog();
        }

        private void DeleteMagazineRButton_Click(object sender, EventArgs e)
        {
            ChooseForm CF = new ChooseForm(Settings.ID_rodzaj, ChooseForm.ModeEnum.Delete, Settings.employeeID);
            CF.MdiParent = this;
            CF.Show();
            //CF.ShowDialog();
        }

        private void TitleChangeRButton_Click(object sender, EventArgs e)
        {
            ChooseForm.ChangeTitle(Settings.ID_rodzaj, this);
        }

        // dodanie / nowa akcesja
        private void NewAkcesjaRButton_Click(object sender, EventArgs e)
        {
            if (Settings.ID_rodzaj == 0)
            {
                ChooseInvertoryForm CIF = new ChooseInvertoryForm();

                if (CIF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Akcesja.AkcesjaForm AF = new Akcesja.AkcesjaForm(CIF.IDRodzaj, "nowa_karta", Settings.employeeID, this);
                }
            }
            else
            {
                Akcesja.AkcesjaForm AF = new Akcesja.AkcesjaForm(Settings.ID_rodzaj, "nowa_karta", Settings.employeeID, this);
            }   
        }

        // dopisanie akcesji
        private void DopiszAkcesjeRButton_Click(object sender, EventArgs e)
        {
            Akcesja.AkcesjaForm AF = new Akcesja.AkcesjaForm(Settings.ID_rodzaj, "dopisz", Settings.employeeID, this);
        }

        // usunięcie akcesji
        private void DeleteAkcesjeRButton_Click(object sender, EventArgs e)
        {
            Akcesja.AkcesjaForm AF = new Akcesja.AkcesjaForm(Settings.ID_rodzaj, "usun", Settings.employeeID, this);
        }

        
        private void SeryjneRButton_Click(object sender, EventArgs e)
        {
            if (Settings.ID_rodzaj == 0)
            {
                ChooseInvertoryForm CIF = new ChooseInvertoryForm();

                if (CIF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Czasopisma.ChooseForm CF = new ChooseForm(CIF.IDRodzaj, ChooseForm.ModeEnum.Edit, Settings.employeeID, true);
                    CF.MdiParent = this;
                    CF.Show();
                    //CF.ShowDialog();
                }
            }
            else
            {
                Czasopisma.ChooseForm CF = new ChooseForm(Settings.ID_rodzaj, ChooseForm.ModeEnum.Edit, Settings.employeeID, true);
                CF.MdiParent = this;
                CF.Show();
                //CF.ShowDialog();
            }             
        }

        // edycja/usuwanie ubytków czasopism 
        private void UbytkiMagazineRButton_Click(object sender, EventArgs e)
        {
            Ubytki.UbytkiForm UF = new Ubytki.UbytkiForm(Settings.ID_rodzaj, Ubytki.UbytkiForm.KindEnum.Magazine);
            //UF.ShowDialog();
            UF.MdiParent = this;
            UF.Show();
        }

        private void ExitMenuItem_CanvasChanged(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBaseForm CBF = new ChangeBaseForm();

            if (CBF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SetWindowTitle();
            }
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void SetWindowTitle()
        {
            string cNapis = String.Format("{0} {1}", _translationsDictionary.ContainsKey("app_name") ? _translationsDictionary["app_name"] : "", Assembly.GetExecutingAssembly().GetName().Version.ToString()) + " [" + Settings.InvertoryName + "]";
            if (App.lDemo) cNapis = cNapis + " " + App.cUser;
            else cNapis = cNapis + " Licencja dla: " + App.cUser;
            this.Text = cNapis;
        }

        private void artykułToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.ID_rodzaj == 0)
            {
                ChooseInvertoryForm CIF = new ChooseInvertoryForm();

                if (CIF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Artykuly.ChooseType CT = new Artykuly.ChooseType(CIF.IDRodzaj, 1, this);
                }
            }
            else
            {
                Artykuly.ChooseType CT = new Artykuly.ChooseType(Settings.ID_rodzaj, 1, this);
            } 
        }

        // dodanie czasopisma
        private void czasopismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.ID_rodzaj == 0)
            {
                ChooseInvertoryForm CIF = new ChooseInvertoryForm();

                if (CIF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MagazineForm MF = new MagazineForm(CIF.IDRodzaj,Settings.employeeID);
                    MF.ShowDialog();
                }
            }
            else
            {
                MagazineForm MF = new MagazineForm(Settings.ID_rodzaj,Settings.employeeID);
                MF.ShowDialog();
            } 
        }

        private void książkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.ID_rodzaj == 0)
            {
                ChooseInvertoryForm CIF = new ChooseInvertoryForm();

                if (CIF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DetailsForm DF = new DetailsForm(CIF.IDRodzaj, Settings.employeeID);
                    DF.ShowDialog();
                }
            }
            else
            {
                DetailsForm DF = new DetailsForm(Settings.ID_rodzaj, Settings.employeeID);
                DF.ShowDialog();
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(_translationsDictionary.ContainsKey("do_you_want_to_exit") ? _translationsDictionary["do_you_want_to_exit"] : "Czy chcesz zakończyć pracę z programem?", _translationsDictionary.ContainsKey("app_name") ? _translationsDictionary["app_name"] : "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Form a = new Form();
                a.MdiParent = this;

                Wypozyczalnia.ChooseResourceForm crf = new Wypozyczalnia.ChooseResourceForm(Int32.Parse(Settings.employeeID), Wypozyczalnia.ChooseResourceForm.WorkMode.ManageResource, this);
                crf.Show();

                a.Close();
            }
            else if(e.KeyCode == Keys.F3)
            {
                Form a = new Form();
                a.MdiParent = this;

                Wypozyczalnia.UsersListForm usersForm = new Wypozyczalnia.UsersListForm(Wypozyczalnia.UsersListForm.Mode.ManageUser, a, Int32.Parse(Settings.employeeID));
                usersForm.Show();

                a.Close();
            }
            else if (e.KeyCode == Keys.F4)
            {
                // statistics
                Wypozyczalnia.StatisticsForm sf = new Wypozyczalnia.StatisticsForm();
                sf.MdiParent = this;
                sf.Show();
            }
            else if (e.KeyCode == Keys.F9)
            {
                WaitForm WF = new WaitForm();

                this.Invoke((MethodInvoker)delegate
                {
                    WF.Show(this);
                    WF.Update();
                });

                Wypozyczalnia.CurrentBorrowsForm borrowsForm = new Wypozyczalnia.CurrentBorrowsForm(Int32.Parse(Settings.employeeID), this);

                WF.Dispose();

                borrowsForm.Show();
            }
            else if (e.KeyCode == Keys.F11)
            {
                Form a = new Form();
                a.MdiParent = this;
                Wypozyczalnia.BorrowForm borr = new Wypozyczalnia.BorrowForm(Int32.Parse(Settings.employeeID), a);
                borr.Show();
                a.Close();
            }
            else if (e.KeyCode == Keys.F12)
            {
                // quick
                Wypozyczalnia.QuickBorrowForm qbf = new Wypozyczalnia.QuickBorrowForm(Int32.Parse(Settings.employeeID));
                qbf.MdiParent = this;
                qbf.Show();
            }
            
        }

        private void userRB_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.MdiParent = this;

            Wypozyczalnia.UsersListForm usersForm = new Wypozyczalnia.UsersListForm(Wypozyczalnia.UsersListForm.Mode.ManageUser, a, Int32.Parse(Settings.employeeID));
            usersForm.Show();

            a.Close();
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            WaitForm WF = new WaitForm();

            this.Invoke((MethodInvoker)delegate
            {
                WF.Show(this);
                WF.Update();
            });

            Wypozyczalnia.CurrentBorrowsForm borrowsForm = new Wypozyczalnia.CurrentBorrowsForm(Int32.Parse(Settings.employeeID), this);

            WF.Dispose();

            borrowsForm.Show();
        }

        private void resourcesRB_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.MdiParent = this;

            Wypozyczalnia.ChooseResourceForm crf = new Wypozyczalnia.ChooseResourceForm(Int32.Parse(Settings.employeeID), Wypozyczalnia.ChooseResourceForm.WorkMode.ManageResource, this);
            crf.Show();

            a.Close();
        }

        private void borrowRB_Click(object sender, EventArgs e)
        {
            Form a = new Form();
            a.MdiParent = this;
            Wypozyczalnia.BorrowForm borr = new Wypozyczalnia.BorrowForm(Int32.Parse(Settings.employeeID), a);
            borr.Show();
            a.Close();
        }

        private void ordersButton_Click(object sender, EventArgs e)
        {
            UpdateOrdersButtonsText();

            Form a = new Form();
            a.MdiParent = this;
            Wypozyczalnia.CurrentOrdersForm of = new Wypozyczalnia.CurrentOrdersForm(Int32.Parse(Settings.employeeID), a);
            of.Show();
            a.Close();
        }

        private void wypStatsRB_Click(object sender, EventArgs e)
        {
            Wypozyczalnia.StatisticsForm sf = new Wypozyczalnia.StatisticsForm();
            sf.MdiParent = this;
            sf.Show();
        }

        private void quickRB_Click(object sender, EventArgs e)
        {
            Wypozyczalnia.QuickBorrowForm qbf = new Wypozyczalnia.QuickBorrowForm(Int32.Parse(Settings.employeeID));
            qbf.MdiParent = this;
            qbf.Show();
        }

        private void exitOrbMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutOrbMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.MdiParent = this.ParentForm;
            about.ShowDialog();
            SetWindowTitle();
        }

        private void guideOrbMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Dokumentacja", "Co-Liber - Podręcznik użytkownika.pdf"));
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void rbNormyAdd_Click(object sender, EventArgs e)
        {
            Normy.Norma fNorma = new Normy.Norma(-1);
            fNorma.MdiParent = this;
            fNorma.Show();
            rbNormyAdd.Checked = false;
        }
        private void rbNormyMod_Click(object sender, EventArgs e)
        {
            Normy.Normy fNormy = new Normy.Normy();
            fNormy.MdiParent = this;
            fNormy.Show();
            rbNormyMod.Checked = false;
        }
        private void rbNormyDel_Click(object sender, EventArgs e)
        {
            Normy.Normy fNormy = new Normy.Normy(true);
            fNormy.MdiParent = this;
            fNormy.Show();
            rbNormyDel.Checked = false;
        }

    }
}
