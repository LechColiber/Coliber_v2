using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dBASE.Data.dBASEClient;

namespace DBFReader
{
    public partial class Form1 : Form
    {
        private Dictionary<string, DataTable> dict;

        public dBASEConnection myConn = null;
        string ConnnectionString = "";
        string CommandText = "";
        private List<string> ordinaList;

        public Form1()
        {
            InitializeComponent();

            dict = new Dictionary<string, DataTable>();
            ordinaList = new List<string>();
            setordinaList();
        }

        private void setordinaList()
        {
            // listy autorów
            ordinaList.Add("list_aut_a");
            ordinaList.Add("list_aut_k");
            ordinaList.Add("list_aut_wsp");

            // listy klucz
            ordinaList.Add("klucze_a");
            ordinaList.Add("klucze_c");
            ordinaList.Add("klucze_k");
            ordinaList.Add("klucze_wsp");

            // jezyki
            ordinaList.Add("jezyki");

            // panstwa
            ordinaList.Add("panstwa");

            // czasopisma
            ordinaList.Add("wydawca_c");
            ordinaList.Add("kolport");
            ordinaList.Add("czasop");            
            ordinaList.Add("cza_klu");
            ordinaList.Add("cza_syg");
            ordinaList.Add("volumes");
            ordinaList.Add("seryjne");
            ordinaList.Add("dodatki");
            ordinaList.Add("zmi_ins");

            // akcesja
            ordinaList.Add("akcesja");
            ordinaList.Add("czasop_n");
            ordinaList.Add("departam");
            ordinaList.Add("dla_kogo");

            // artykuly itd
            ordinaList.Add("artykuly");
            ordinaList.Add("art_aut");
            ordinaList.Add("art_klu");
            
            
            // ksiazki
            ordinaList.Add("serie");

            ordinaList.Add("wydawca_k");
            ordinaList.Add("wydawca_wsp");

            ordinaList.Add("ksiazki_new");
            ordinaList.Add("instyt");
            ordinaList.Add("konfer");

            ordinaList.Add("podserie");
                       
            ordinaList.Add("ksi_klu"); 
            ordinaList.Add("ksi_ser");

            ordinaList.Add("ksiazki_autor_new");
            ordinaList.Add("ksiazki_jezyki_new");

            ordinaList.Add("odpowiedzialnosci_new");
            ordinaList.Add("ksiazki_wautor_new");            
            ordinaList.Add("wautor_odpowiedzialnosc_new");

            ordinaList.Add("sygnat");
            ordinaList.Add("tomy");

            ordinaList.Add("t_dodatk");
            ordinaList.Add("t_rownol");
                                   

            // ubytki
            ordinaList.Add("ubytki_c");
            ordinaList.Add("ubytki_k");
            

            ordinaList.Add("pracow");
            
            ordinaList.Add("zasoby");

            ordinaList.Add("wypozycz");
            
        }

        /*public void readMemo()
        {   
            string file = @"D:\Exell\Coliber 2.6 Baza TK\2013-09-20\BAZY\BAZY";
            //file = @"D:\Exell\TK\BAZY\ksiazki";
            file = @"D:\Exell\Dentons\BAZY";
            //file = @"D:\Exell\Dentons\BAZY\WSP";
            //file = @"D:\Exell\Coliber 2.6 Baza TK\COLIBER_bazy_05_2011\BAZY";

            FileInfo[] files = DirSearch(file, "*.fpt");

            if (files == null)
                return;

            int i = 1;

            foreach (var fileInfo in files)
            {
                if (!fileInfo.Name.ToLower().Contains("artykuly"))
                    continue;

                Stream fileStream = new FileStream(fileInfo.FullName, FileMode.Open);
                MemoCollection col = new MemoCollection(fileStream);
                
                foreach (var memo in col)
                {
                    if(memo.MemoDataType == MemoDataType.Text)
                        MessageBox.Show(Encoding.GetEncoding(1250).GetString(memo.Memo));
                }
            }
        }*/

        public void ReadDBFUsingOleDB()
        {
            dict.Clear();
            listDGV.Rows.Clear();

            /*string file = @"D:\Exell\Coliber 2.6 Baza TK\2013-09-20\BAZY\BAZY";
            file = @"D:\Exell\TK\BAZY";*/
            string file = folderBrowserDialog1.SelectedPath;
            //file = @"D:\Exell\Dentons\2014_08_14_BAZY";           //file = @"D:\Exell\Dentons\BAZY\WSP";
            //file = @"D:\Exell\Coliber 2.6 Baza TK\COLIBER_bazy_05_2011\BAZY";

            FileInfo[] files = DirSearch(file, "*.dbf");

            if (files == null)
                return;

            int i = 1;

            foreach (var fileInfo in files)
            {
                //if (!fileInfo.Name.ToLower().Contains("wypozycz"))
                //    continue;
                
                string mytable = Path.GetFileNameWithoutExtension(fileInfo.Name);

                string DataSource = Path.GetFullPath(fileInfo.FullName).Replace(Path.GetFileName(fileInfo.Name), "");

                ConnnectionString = "Data Source=" + DataSource;
                CommandText = "SELECT * FROM " + mytable;

                myConn = new dBASEConnection(ConnnectionString);
                
                DbCommand dbcmd = myConn.CreateCommand();                
                dbcmd.CommandText = this.CommandText;

                dBASEDataAdapter myAdapter = new dBASEDataAdapter();                
                myAdapter.SelectCommand = dbcmd;

                DataTable mySet = new DataTable();

                myAdapter.Fill(mySet);
                myAdapter.Dispose();                

                string key = "";

                if (fileInfo.FullName.ToLower().Contains("klucze"))
                {
                    key = "klucze" + combineName(fileInfo);
                }
                else if (fileInfo.FullName.ToLower().Contains("list_aut"))
                {
                    key = "list_aut" + combineName(fileInfo);
                }
                else if (fileInfo.FullName.ToLower().Contains("ubytki"))
                {
                    key = "ubytki" + combineName(fileInfo);
                }
                else if (fileInfo.FullName.ToLower().Contains("wydawca"))
                {
                    key = "wydawca" + combineName(fileInfo);
                }
                else
                    key = Path.GetFileNameWithoutExtension(fileInfo.Name);

                if (doDistinct(mytable))
                {
                    DataView view = new DataView(mySet);                    
                    mySet = view.ToTable(true, mySet.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray());
                }

                dict.Add(key, mySet);
                listDGV.Rows.Add(key, true, key);

                importedCountLabel.Text = string.Format("{0} z {1}", i, files.Count());
                    
                i++;
                Application.DoEvents();
            }

            MessageBox.Show("Zakończono czytanie danych z DBF.");
        }

        private DataTable listOdpow(DataTable dt)
        {            
            List<string> lista = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if(!string.IsNullOrWhiteSpace(dt.Rows[i]["ODPOW1"].ToString().Trim()))
                    lista.Add(dt.Rows[i]["ODPOW1"].ToString().Trim());
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["ODPOW2"].ToString().Trim()))
                    lista.Add(dt.Rows[i]["ODPOW2"].ToString().Trim());
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["ODPOW3"].ToString().Trim()))
                    lista.Add(dt.Rows[i]["ODPOW3"].ToString().Trim());
                if (dt.Columns.Contains("ODPOW4") && !string.IsNullOrWhiteSpace(dt.Rows[i]["ODPOW4"].ToString().Trim()))
                    lista.Add(dt.Rows[i]["ODPOW4"].ToString().Trim());
            }

            lista = lista.Distinct().ToList();

            DataTable dt2 = new DataTable(); //view.ToTable(true, dt.Columns.Cast<DataColumn>().Where(x => x.ColumnName.Contains("odpow")).ToArray());
            dt2.Columns.Add("odpow");

            foreach (string t in lista)
                dt2.Rows.Add(t);

            return dt2;        
        }

        private DataTable listOdpowAuthor(DataTable dt)
        {
            DataTable dt2 = new DataTable(); //view.ToTable(true, dt.Columns.Cast<DataColumn>().Where(x => x.ColumnName.Contains("odpow")).ToArray());
            dt2.Columns.Add("kod"); 
            dt2.Columns.Add("imie");
            dt2.Columns.Add("nazwisko");
            dt2.Columns.Add("odpow");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["ODPOW1"].ToString().Trim()))
                    dt2.Rows.Add(dt.Rows[i]["KOD"].ToString().Trim(), dt.Rows[i]["WIMIE1"].ToString().Trim(), dt.Rows[i]["WAUTOR1"].ToString().Trim(), dt.Rows[i]["ODPOW1"].ToString().Trim());
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["ODPOW2"].ToString().Trim()))
                    dt2.Rows.Add(dt.Rows[i]["KOD"].ToString().Trim(), dt.Rows[i]["WIMIE2"].ToString().Trim(), dt.Rows[i]["WAUTOR2"].ToString().Trim(), dt.Rows[i]["ODPOW2"].ToString().Trim());
                if (!string.IsNullOrWhiteSpace(dt.Rows[i]["ODPOW3"].ToString().Trim()))
                    dt2.Rows.Add(dt.Rows[i]["KOD"].ToString().Trim(), dt.Rows[i]["WIMIE3"].ToString().Trim(), dt.Rows[i]["WAUTOR3"].ToString().Trim(), dt.Rows[i]["ODPOW3"].ToString().Trim());
                if (dt.Columns.Contains("ODPOW4") && !string.IsNullOrWhiteSpace(dt.Rows[i]["ODPOW4"].ToString().Trim()))
                    dt2.Rows.Add(dt.Rows[i]["KOD"].ToString().Trim(), dt.Rows[i]["WIMIE4"].ToString().Trim(), dt.Rows[i]["WAUTOR4"].ToString().Trim(), dt.Rows[i]["ODPOW4"].ToString().Trim());
            }

            return dt2;
        }

        private bool doDistinct(string tableName)
        {
            string[] list = {"list_aut"};
            
            return list.Contains(tableName.ToLower().Trim());
        }

        private bool turnOnIdentityInsert(string tableName)
        {
            string[] list = { "tomy", "ksiazki_autor_new", "pracow", "wypozycz", "ksiazki_jezyki_new", "wautor_odpowiedzialnosc_new", "ksiazki_wautor_new", "art_aut", "odpowiedzialnosci_new", "ksiazki_autor_export", "panstwa", "t_dodatk", "t_rownol", "sygnat", "ksi_ser", "list_aut_a", "list_aut_k", "list_aut_wsp", "cza_syg", "volumes", "czasop_n", "art_klu", "cza_klu", "ksi_klu", "dla_kogo", "dodatki", "instyt", "konfer", "ubytki_c", "ubytki_k", "podserie" };

            //return !list.Contains(tableName.ToLower().Trim());
            return !(list.Any(x => x == tableName.ToLower().Trim()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //readMemo();
            ReadDBFUsingOleDB();

            //return;
            /*dict.Clear();
            listDGV.Rows.Clear();
            //string file = @"D:\Exell\Coliber 2.6 Baza TK\2013-09-20\BAZY\BAZY\ksiazki\sygnat.dbf";            

            string file = @"D:\Exell\Coliber 2.6 Baza TK\2013-09-20\BAZY\BAZY";
            //file = @"D:\Exell\TK\BAZY\ksiazki";
            //file = @"D:\Exell\Dentons\BAZY";

            FileInfo[] files = DirSearch(file, "*.dbf");

            if (files == null)
                return;

            foreach (var fileInfo in files)
            {                
                DBaseReader.DBaseReader dbfr = new DBaseReader.DBaseReader();
                dbfr.OpenDBaseDBF(fileInfo.FullName);
                //dbfr.OpenDBaseDBF(@"D:\Exell\Coliber 2.6 Baza TK\2013-09-20\BAZY\BAZY");                

                /*MessageBox.Show(dbfr.NumberOfRecords().ToString());
                MessageBox.Show(dbfr.NumberOfValidRecords().ToString());*/

                /*DataTable Dt = new DataTable();

                for (int i = 0; i < dbfr.FieldSortedList.Count; i++)
                {
                    Dt.Columns.Add(dbfr.FieldSortedList[i]);
                }

                foreach (List<string> val in dbfr.RecordsArray)
                {
                    Dt.Rows.Add(val.ToArray());
                }                

                string key = "";

                if (fileInfo.FullName.ToLower().Contains("klucze"))
                {
                    key = "klucze" + combineName(fileInfo);
                }
                else if (fileInfo.FullName.ToLower().Contains("list_aut"))
                {
                    key = "list_aut" + combineName(fileInfo);
                }
                else if (fileInfo.FullName.ToLower().Contains("ubytki"))
                {
                    key = "ubytki" + combineName(fileInfo);
                }
                else if (fileInfo.FullName.ToLower().Contains("wydawca"))
                {
                    key = "wydawca" + combineName(fileInfo);
                }
                else
                    key = Path.GetFileNameWithoutExtension(fileInfo.Name);

                dict.Add(key, Dt);
                listDGV.Rows.Add(key, true, key);

                Application.DoEvents();
            }

            MessageBox.Show("Zakończono czytanie danych z DBF.");*/
            //dataGridView1.DataSource = Dt;
        }

        private string combineName(FileInfo fileInfo)
        {
            string key = "";

            if (fileInfo.FullName.ToLower().Contains("artykuly"))
                key += "_a";
            else if (fileInfo.FullName.ToLower().Contains("czasop"))
                key += "_c";
            else if (fileInfo.FullName.ToLower().Contains("ksiazki"))
                key += "_k";
            else if (fileInfo.FullName.ToLower().Contains("wsp"))
                key += "_wsp";
            else if (fileInfo.FullName.ToLower().Contains("orzecz"))
                key += "_orzecz";

            return key;
        }

        static FileInfo[] DirSearch(string sDir, string extension)
        {
            FileInfo[] fileList = null;

            try
            {
                fileList = new DirectoryInfo(sDir).GetFiles(extension, SearchOption.AllDirectories).OrderBy(x => x.Name).ToArray();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return fileList;
        }

        private void listDGV_SelectionChanged_1(object sender, EventArgs e)
        {
            if (listDGV.SelectedRows.Count > 0 && dict.ContainsKey(listDGV.SelectedRows[0].Cells[keyDGVC.Name].Value.ToString()))
            {
                DataTable dt = dict[listDGV.SelectedRows[0].Cells[keyDGVC.Name].Value.ToString()];
                dataGridView1.DataSource = dt;
                rowsCountLabel.Text = dt.Rows.Count.ToString();
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listDGV.Rows.Count; i++)
            {
                if (!(bool)listDGV.Rows[i].Cells[checkDGVC.Name].Value)
                    continue;

                if (dict.ContainsKey(listDGV.Rows[i].Cells[keyDGVC.Name].Value.ToString()))
                {
                    string TableName = listDGV.Rows[i].Cells[tableDGVC.Name].Value.ToString().ToLower().Trim();

                    if (TableName.ToLower().Trim() == "ksiazki")
                        TableName = "ksiazki_new";

                    SaveToMSSQLFile(TableName, "", dict[listDGV.Rows[i].Cells[keyDGVC.Name].Value.ToString()]);

                    if (TableName == "ksiazki_new")
                    {
                        SaveToMSSQLFile("ksiazki_autor_new", "", dict[listDGV.Rows[i].Cells[keyDGVC.Name].Value.ToString()]); // OK

                        
                        SaveToMSSQLFile("odpowiedzialnosci_new", "", listOdpow(dict[listDGV.Rows[i].Cells[keyDGVC.Name].Value.ToString()])); // OK
                        
                        SaveToMSSQLFile("ksiazki_wautor_new", "", dict[listDGV.Rows[i].Cells[keyDGVC.Name].Value.ToString()]); // OK
                        SaveToMSSQLFile("wautor_odpowiedzialnosc_new", "", listOdpowAuthor(dict[listDGV.Rows[i].Cells[keyDGVC.Name].Value.ToString()])); // OK
                                                
                        SaveToMSSQLFile("ksiazki_jezyki_new", "", dict[listDGV.Rows[i].Cells[keyDGVC.Name].Value.ToString()]); // OK
                        SaveToMSSQLFile("tomy", "", dict[listDGV.Rows[i].Cells[keyDGVC.Name].Value.ToString()]); // OK
                    }
                    else if (TableName == "artykuly")
                    {
                        SaveToMSSQLFile("art_aut", "", dict[listDGV.Rows[i].Cells[keyDGVC.Name].Value.ToString()]); // OK
                    }
                }
            }

            MessageBox.Show("Wyeksportowano!");
        }

        private string getInsertStatements(string tableName)
        {
            string insertStatement = "INSERT INTO dbo.";
            tableName = tableName.Trim().ToLower();

            if (tableName == "jezyki")
            {
                insertStatement += tableName + " (jezyk, j_kod_cyfr, j_an_nazwa, j_pl_nazwa)";
            }
            else if (tableName.Contains("klucze"))
            {
                insertStatement += tableName + " (kody, klucze, id_rodzaj)";
            }
            else if (tableName == "kolport")
            {
                insertStatement += tableName + " (id_kolport, nazwa_k, sk_nazwa_k, id_panst_k, kod_k, miasto_k, adres_k, telefon_k, telefon2_k, fax_k)";
            }
            else if (tableName.Contains("list_aut"))
            {
                insertStatement += tableName + " (nazwisko, imie, id_rodzaj)";
            }
            else if (tableName.Contains("wydawca"))
            {
                insertStatement += tableName + " (id_wydawcy, nazwa_w, sk_nazwa_w, id_panst_w, miasto_w, kontakt_w, adres_w, id_rodzaj)";
            }
            else if (tableName == "czasop")
            {
                insertStatement += tableName + " (kod, seryjne, tytul, podtytul, zawartosc, nazwa_inst, siedziba, issn, id_wydawcy, id_kolport, jezyk1, jezyk2, jezyk3, id_czest, uwagi, data_biez, redaktor, rodzajnik, sp_nab, wysokosc, dlugosc, rocznik_p, rocznik_o, miejsce_w, format, ilosc, t_rownol, t_dodatk, kraj_w, z_kodu, na_kod, rozd_inst, id_rodzaj)";
            }
            else if (tableName == "cza_syg")
            {
                insertStatement += tableName + " (kod, syg, seryjne, sort_order, syg_expand)";
            }
            else if (tableName == "volumes")
            {
                insertStatement += tableName + " (kod, syg, rok1, rok2, volumin, czesci, uwagi_v, nr_akcesji, rocz_pren, wart_vol, numer_inw, nab, dodatki, data_biez, k_kreskowy, id_cza_syg)";
            }
            else if (tableName == "akcesja")
            {
                insertStatement += tableName + " (kod, tytul, nazwa_inst, siedziba, id_kolport, id_czest, data_biez, uwagi, nr_czasop, id_akces, id_rodzaj)";
            }
            else if (tableName == "czasop_n")
            {
                insertStatement += tableName + " (kod, rok1, rok2, volumin, numer_z, numer_z2, num_abs, num_abs2, spos_nab, ilosc, data_wpl, data_rekl1, data_rekl2, data_rekl3, uwagi_n, data_biez, kol, tytul_num, id_volumes)";
            }
            else if (tableName == "art_klu" || tableName == "cza_klu" || tableName == "ksi_klu")
            {
                insertStatement += tableName + " (kod, kody)";
            }
            else if (tableName == "artykuly")
            {
                insertStatement += tableName + " (kod, syg, tytul, rok1, rok2, volumin, tom, numer1, numer2, tytul_a, jezyk, strony, nr_odcinka, tabele, mapy, wykresy, s_pol, s_ang, s_niem, s_fran, s_ros, uwagi, opis, caly, data_biez, data_uk, rodzaj_zas, id_rodzaj)";
            }
            else if (tableName == "departam")
            {
                insertStatement += tableName + " (kod_depart, departam)";
            }
            else if (tableName == "dla_kogo")
            {
                insertStatement += tableName + " (kod, rok_dep, kod_depart, ilosc_egz)";
            }
            else if (tableName == "dodatki")
            {
                insertStatement += tableName + " (kod, syg, rok1, rok2, volumin, autor1, autor2, autor3, tytul_dod, rodz_dod, data_biez)";
            }
            else if (tableName == "instyt")
            {
                insertStatement += tableName + " (kod, nazwa_inst, siedziba)";
            }
            else if (tableName == "konfer")
            {
                //insertStatement += tableName + " (kod, nazwa_imp, numer_imp, kraj_imp, miasto_imp, org_imp, data_imp, rodzaj_imp)";
                insertStatement += tableName + " (kod, nazwa_imp, numer_imp, kraj_imp, miasto_imp, org_imp, rodzaj_imp)";
            }
            else if (tableName == "ubytki_c")
            {
                insertStatement += tableName + " (nr_ksiegi, data_ubyt, kod, syg, rok1, rok2, volumin, czesci, numer_inw, tytul, rocz_pren, przyczyna, nr_dow, uwagi_u, id_rodzaj)";
            }
            else if (tableName == "ubytki_k")
            {
                insertStatement += tableName + " (nr_ksiegi, data_ubyt, kod, syg, numer_inw, autor1, tytul_gl, rok_wyd, cena, przyczyna, nr_dow, uwagi_u, ilosc, id_rodzaj)";
            }
            else if (tableName == "serie")
            {
                insertStatement += tableName + " (kody, tyt_serii, issn, inst_serii, sied_serii, id_rodzaj)";
            }
            else if (tableName == "podserie")
            {
                insertStatement += tableName + " (kod, tyt_pserii, pissn, nazwa_pcz, numer_pcz)";
            }
            else if (tableName == "panstwa")
            {
                insertStatement += tableName + " (panstwo, kod2, p_kod_cyfr, p_sk_nazwa, p_an_nazwa, p_pl_nazwa)";
            }
            else if (tableName == "ksi_ser")
            {
                insertStatement += tableName + " (kod, kody, nazwa_cz, numer_cz)";
            }
            else if (tableName == "sygnat")
            {
                insertStatement += tableName + " (kod, syg, numer_inw, k_kreskowy, id_zasob, numer_akc, rodz_ksieg, spos_nab, ilosc_all, ilosc_poz, cena, wartosc, waluta, data_zap, wypozycz, siglum_syg, uwagi_s, sort_order, syg_expand, numer_inw_expand)";
            }
            else if (tableName == "t_dodatk")
            {
                insertStatement += tableName + " (kod, t_dodatk)";
            }
            else if (tableName == "t_rownol")
            {
                insertStatement += tableName + " (kod, t_rownol)";
            }
            else if (tableName == "ksiazki_new")
            {
                insertStatement += tableName + " (kod, tytul_gl, id_wyd1, id_wyd2, wydanie, rok_wyd, lata_wyd, strony, isbn, isbn2, il_tomow, wysokosc, dlugosc, zawartosc, s_pol, s_ang, s_niem, s_fran, s_ros, ukd, uwagi, rodzajnik, id_rodzaj)";
            }
            else if (tableName == "ksiazki_autor_new")
            {
                insertStatement += tableName + " (id_ksiazka, id_autor, rating)";
            }
            else if (tableName == "ksiazki_wautor_new")
            {
                insertStatement += tableName + " (id_ksiazka, id_wautor, rating)";
            }
            else if (tableName == "art_aut")
            {
                insertStatement += tableName + " (kod, id_aut)";
            }
            else if (tableName == "odpowiedzialnosci_new")
            {
                insertStatement += tableName + " (nazwa)";
            }
            else if (tableName == "ksiazki_jezyki_new")
            {
                insertStatement += tableName + " (id_ksiazki, id_jezyk)";
            }
            else if (tableName == "wautor_odpowiedzialnosc_new")
            {
                insertStatement += tableName + " (id_ksiazki_wautor, id_odpowiedzialnosc)";
            }
            else if (tableName == "zasoby")
            {
                insertStatement += tableName + " (id_zasob, k_kreskowy, kod, syg, tytul, autor, rodzaj_zas, rok1, rok2, volumin, numer_z, numer_z2, numer_inw, stan, zewn_akt)";
            }
            else if (tableName == "wypozycz" && containsResourceIdCheckBox.Checked)
            {
                insertStatement += tableName + " (id_uzyt, id_zasob, rodzaj_poz, kod, syg, data_wyp, data_przew, data_upom, data_zwr, kto_wzial)";
            }
            else if (tableName == "wypozycz" && !containsResourceIdCheckBox.Checked)
            {
                insertStatement += tableName + " (id_uzyt, rodzaj_poz, kod, syg, numer_inw, rok1, rok2, volumin, numer_z, numer_z2, data_zap, data_wykr, data_przew, data_upom, rok_wyd, tytul)";
            }
            else if (tableName == "pracow")
            {
                insertStatement += tableName + " (id_uzyt, data_wpisu, data_wyk, nazwisko, imie, dzial, tel_sluz, poczta, miasto, adres, tel_dom, nr_legitym, odwiedziny, data_w_rok, ilosc_w_k, ilosc_w_c, ilosc_z_k, ilosc_z_c)";
            }
            else if(tableName == "tomy")
            {
                insertStatement += tableName + " (kod_tomy, kod)";
            }
            //
 
            return insertStatement;
        }

        private string getInsertRow(string tableName, DataRow row, bool last)
        {
            tableName = tableName.Trim().ToLower();
            string insertStatement = "(";

            if (!last)
            {
                if (tableName== "jezyki")
                {
                    insertStatement += "'" + row["JEZYK"].ToString().Replace("'", "''") + "', " + row["J_KOD_CYFR"].ToString().Replace("'", "''") + ", '" + row["J_AN_NAZWA"].ToString().Replace("'", "''") + "', '" + row["J_PL_NAZWA"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName.Contains("klucze"))
                {
                    insertStatement += "" + row["KODY"].ToString().Replace("'", "''") + ", '" + row["KLUCZE"].ToString().Replace("'", "''") + "', 1";
                }
                else if (tableName == "kolport")
                {
                    insertStatement += row["ID_KOLPORT"].ToString().Replace("'", "''") + ", '" + row["NAZWA_K"].ToString().Replace("'", "''") + "', '" + row["SK_NAZWA_K"].ToString().Replace("'", "''") + "', '" + row["ID_PANST_K"].ToString().Replace("'", "''") + "', '" + row["KOD_K"].ToString().Replace("'", "''") + "', '" + row["MIASTO_K"].ToString().Replace("'", "''") + "', '" + row["ADRES_K"].ToString().Replace("'", "''") + "', '" + row["TELEFON_K"].ToString().Replace("'", "''") + "', '" + row["TELEFON2_K"].ToString().Replace("'", "''") + "', '" + row["FAX_K"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName.Contains("list_aut"))
                {
                    insertStatement += "'" + row["NAZWISKO"].ToString().Replace("'", "''") + "', '" + row["IMIE"].ToString().Replace("'", "''") + "', 1";
                }
                else if (tableName.Contains("wydawca"))
                {
                    insertStatement += row["ID_WYDAWCY"].ToString().Replace("'", "''") + ", '" + row["NAZWA_W"].ToString().Replace("'", "''") + "', '" + row["SK_NAZWA_W"].ToString().Replace("'", "''") + "', '" + row["ID_PANST_W"].ToString().Replace("'", "''") + "', '" + row["MIASTO_W"].ToString().Replace("'", "''") + "', '" + row["KONTAKT_W"].ToString().Replace("'", "''") + "', '" + row["ADRES_W"].ToString().Replace("'", "''") + "', 1";
                }
                else if (tableName == "czasop")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", " + (row["SERYJNE"].ToString().ToLower() == "f" ? "0" : "1") + ", '" + 
                        row["TYTUL"].ToString().Replace("'", "''") + "', '" + row["PODTYTUL"].ToString().Replace("'", "''") + "', " + 
                        row["ZAWARTOSC"].ToString().Replace("'", "''") + ", '" + row["NAZWA_INST"].ToString().Replace("'", "''") + "', '" + 
                        row["SIEDZIBA"].ToString().Replace("'", "''") + "', '" + row["ISSN"].ToString().Replace("'", "''") + "', " + 
                        row["ID_WYDAWCY"].ToString().Replace("'", "''") + ", " + row["ID_KOLPORT"].ToString().Replace("'", "''") + ", '" + 
                        row["JEZYK1"].ToString().Replace("'", "''") + "', '" + row["JEZYK2"].ToString().Replace("'", "''") + "', '" + 
                        row["JEZYK3"].ToString().Replace("'", "''") + "', " + row["ID_CZEST"].ToString().Replace("'", "''") + ", '" +
                        row["UWAGI"].ToString().Replace("'", "''") + "', '" + ((DateTime) row["DATA_BIEZ"]).ToString("yyyyMMdd") + "', '" +
                        row["REDAKTOR"].ToString().Replace("'", "''") + "', " + (row["RODZAJNIK"].ToString().Replace("'", "''").Length > 0 ? row["RODZAJNIK"].ToString().Replace("'", "''") : "0") + ", " +
                        row["SP_NAB"].ToString().Replace("'", "''") + ", " + row["WYSOKOSC"].ToString().Replace("'", "''") + ", " + 
                        row["DLUGOSC"].ToString().Replace("'", "''") + ", " + row["ROCZNIK_P"].ToString().Replace("'", "''") + ", " +
                        row["ROCZNIK_O"].ToString().Replace("'", "''") + ", '" + row["MIEJSCE_W"].ToString().Replace("'", "''") + "', " + row["FORMAT"].ToString().Replace("'", "''") + ", " + row["ILOSC"].ToString().Replace("'", "''") + ", '" + row["T_ROWNOL"].ToString().Replace("'", "''") + "', '" + row["T_DODATK"].ToString().Replace("'", "''") + "', '" + row["KRAJ_W"].ToString().Replace("'", "''") + "', " + row["Z_KODU"].ToString().Replace("'", "''") + ", " + row["NA_KOD"].ToString().Replace("'", "''") + ", '" + row["ROZD_INST"].ToString().Replace("'", "''") + "', 1";
                }
                else if (tableName == "cza_syg")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["SYG"].ToString().Replace("'", "''") + "', " + (row["SERYJNE"].ToString().ToLower() == "f" ? "0" : "1") + ", 0, (SELECT dbo.Expand('" + row["SYG"].ToString().Replace("'", "''") + "', 6, 60))";
                }
                else if (tableName == "volumes")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["SYG"].ToString().Replace("'", "''") + "', " + row["ROK1"].ToString().Replace("'", "''") + ", " + row["ROK2"].ToString().Replace("'", "''") + ", '" + row["VOLUMIN"].ToString().Replace("'", "''") + "', '" + row["CZESCI"].ToString().Replace("'", "''") + "', '" + row["UWAGI_V"].ToString().Replace("'", "''") + "', '" + row["NR_AKCESJI"].ToString().Replace("'", "''") + "', " + row["ROCZ_PREN"].ToString().Replace("'", "''") + ", " + row["WART_VOL"].ToString().Replace("'", "''") + ", '" + row["NUMER_INW"].ToString().Replace("'", "''") + "', " + row["NAB"].ToString().Replace("'", "''") + ", " + (row["DODATKI"].ToString().ToLower() == "f" ? "0" : "1") + ", '" + row["DATA_BIEZ"].ToString().Replace("'", "''") + "', 0, ISNULL((SELECT cza_syg.id_cza_syg FROM dbo.cza_syg WHERE " + row["KOD"].ToString().Replace("'", "''") + " = kod AND LTRIM(RTRIM(cza_syg.syg)) = LTRIM(RTRIM('" + row["SYG"].ToString().Replace("'", "''") + "'))), -1)";
                }
                else if (tableName == "akcesja")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["TYTUL"].ToString().Replace("'", "''") + "', '" + row["NAZWA_INST"].ToString().Replace("'", "''") + "', '" + row["SIEDZIBA"].ToString().Replace("'", "''") + "', " + row["ID_KOLPORT"].ToString().Replace("'", "''") + ", " + row["ID_CZEST"].ToString().Replace("'", "''") + ", '" + row["DATA_BIEZ"].ToString().Replace("'", "''") + "', '" + row["UWAGI"].ToString().Replace("'", "''") + "', " + row["NR_CZASOP"].ToString().Replace("'", "''") + ", " + row["ID_AKCES"].ToString().Replace("'", "''") + ", 1";
                }
                else if (tableName == "czasop_n")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", " + row["ROK1"].ToString().Replace("'", "''") + ", '" + row["ROK2"].ToString().Replace("'", "''") + "', '" + row["VOLUMIN"].ToString().Replace("'", "''") + "', " + row["NUMER_Z"].ToString().Replace("'", "''") + ", " + row["NUMER_Z2"].ToString().Replace("'", "''") + ", " + row["NUM_ABS"].ToString().Replace("'", "''") + ", " + row["NUM_ABS2"].ToString().Replace("'", "''") + ", " + row["SPOS_NAB"].ToString().Replace("'", "''") + ", " + row["ILOSC"].ToString().Replace("'", "''") + ", '" +//row["NUM_ABS"].ToString().Replace("'", "''") + ", " + row["NUM_ABS2"].ToString().Replace("'", "''") + ", '" +


                                       row["DATA_WPL"].ToString().Replace("'", "''") + "', '" + row["DATA_REKL1"].ToString().Replace("'", "''") + "', '" + row["DATA_REKL2"].ToString().Replace("'", "''") + "', '" + row["DATA_REKL3"].ToString().Replace("'", "''") + "', '" + row["UWAGI_N"].ToString().Replace("'", "''") + "', '" + row["DATA_BIEZ"].ToString().Replace("'", "''") + "', " + row["KOL"].ToString().Replace("'", "''") + ", '" + row["TYTUL_NUM"].ToString().Replace("'", "''") + "', " + "ISNULL((SELECT volumes.id_volumes FROM volumes " + " INNER JOIN akcesja ON akcesja.kod = " + row["KOD"].ToString().Replace("'", "''") + " WHERE volumes.kod = akcesja.nr_czasop AND LTRIM(RTRIM(volumes.volumin)) = LTRIM(RTRIM('" + row["VOLUMIN"].ToString().Replace("'", "''") + "')) AND volumes.rok1 = " + row["ROK1"].ToString().Replace("'", "''") + "), -1)";
                }
                else if (tableName == "art_klu" || tableName == "cza_klu" || tableName == "ksi_klu")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", " + row["KODY"].ToString().Replace("'", "''");
                }
                else if (tableName == "artykuly")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["SYG"].ToString().Replace("'", "''") + "', '" + row["TYTUL"].ToString().Replace("'", "''") + "', " + row["ROK1"].ToString().Replace("'", "''") + ", " + row["ROK2"].ToString().Replace("'", "''") + ", '" + row["VOLUMIN"].ToString().Replace("'", "''") + "', '" + row["TOM"].ToString().Replace("'", "''") + "', '" + row["NUMER1"].ToString().Replace("'", "''") + "', '" + row["NUMER2"].ToString().Replace("'", "''") + "', '" + row["TYTUL_A"].ToString().Replace("'", "''") + "', '" + row["JEZYK"].ToString().Replace("'", "''") + "', '" + row["STRONY"].ToString().Replace("'", "''") + "', '" + row["NR_ODCINKA"].ToString().Replace("'", "''") + "', " + (row["TABELE"].ToString().ToLower() == "f" ? "0" : "1") + ", " + (row["MAPY"].ToString().ToLower() == "f" ? "0" : "1") + ", " + (row["WYKRESY"].ToString().ToLower() == "f" ? "0" : "1") + ", " + (row["S_POL"].ToString().ToLower() == "f" ? "0" : "1") + ", " + (row["S_ANG"].ToString().ToLower() == "f" ? "0" : "1") + ", " + (row["S_NIEM"].ToString().ToLower() == "f" ? "0" : "1") + ", " + (row["S_FRAN"].ToString().ToLower() == "f" ? "0" : "1") + ", " + (row["S_ROS"].ToString().ToLower() == "f" ? "0" : "1") + ", '" + row["UWAGI"].ToString().Replace("'", "''") + "', '" + row["OPIS"].ToString().Replace("'", "''") + "', '" + row["CALY"].ToString().Replace("'", "''") + "', '" + row["DATA_BIEZ"].ToString().Replace("'", "''") + "', '" + row["DATA_UK"].ToString().Replace("'", "''") + "'," + (row["SYG"].ToString().ToLower().Contains("cz") ? "'C'" : "'C'") + ", 1";
                }
                else if (tableName == "departam")
                {
                    insertStatement += row["KOD_DEPART"].ToString().Replace("'", "''") + ", '" + row["DEPARTAM"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName == "dla_kogo")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", " + row["ROK_DEP"].ToString().Replace("'", "''") + ", " + row["KOD_DEPART"].ToString().Replace("'", "''") + ", " + row["ILOSC_EGZ"].ToString().Replace("'", "''");
                }
                else if (tableName == "dodatki")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["SYG"].ToString().Replace("'", "''") + "', " + row["ROK1"].ToString().Replace("'", "''") + ", " + row["ROK2"].ToString().Replace("'", "''") + ", '" + row["VOLUMIN"].ToString().Replace("'", "''") + "', '" + row["AUTOR1"].ToString().Replace("'", "''") + "', '" + row["AUTOR2"].ToString().Replace("'", "''") + "', '" + row["AUTOR3"].ToString().Replace("'", "''") + "', '" + row["TYTUL_DOD"].ToString().Replace("'", "''") + "', '" + row["RODZ_DOD"].ToString().Replace("'", "''") + "', '" + row["DATA_BIEZ"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName == "instyt")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["NAZWA_INST"].ToString().Replace("'", "''") + "', '" + row["SIEDZIBA"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName == "konfer")
                {
                    //insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["NAZWA_IMP"].ToString().Replace("'", "''") + "', '" + row["NUMER_IMP"].ToString().Replace("'", "''") + "', '" + row["KRAJ_IMP"].ToString().Replace("'", "''") + "', '" + row["MIASTO_IMP"].ToString().Replace("'", "''") + "', '" + row["ORG_IMP"].ToString().Replace("'", "''") + "', '" + row["DATA_IMP"].ToString().Replace("'", "''") + "', " + row["RODZAJ_IMP"].ToString().Replace("'", "''");
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["NAZWA_IMP"].ToString().Replace("'", "''") + "', '" + row["NUMER_IMP"].ToString().Replace("'", "''") + "', '" + row["KRAJ_IMP"].ToString().Replace("'", "''") + "', '" + row["MIASTO_IMP"].ToString().Replace("'", "''") + "', '" + row["ORG_IMP"].ToString().Replace("'", "''") + "', " + row["RODZAJ_IMP"].ToString().Replace("'", "''");
                }
                else if (tableName == "ubytki_c")
                {
                    insertStatement += "'" + row["nr_ksiegi"].ToString().Replace("'", "''") + "', '" + row["data_ubyt"].ToString().Replace("'", "''") + "', " + row["kod"].ToString().Replace("'", "''") + ", '" + row["syg"].ToString().Replace("'", "''") + "', " + row["rok1"].ToString().Replace("'", "''") + ", " + row["rok2"].ToString().Replace("'", "''") + ", '" + row["volumin"].ToString().Replace("'", "''") + "', '" + row["czesci"].ToString().Replace("'", "''") + "', '" + row["numer_inw"].ToString().Replace("'", "''") + "', '" + row["tytul"].ToString().Replace("'", "''") + "', " + row["rocz_pren"].ToString().Replace("'", "''").Replace(",", ".") + ", " + row["przyczyna"].ToString().Replace("'", "''") + ", '" + row["nr_dow"].ToString().Replace("'", "''") + "', '" + row["uwagi_u"].ToString().Replace("'", "''") + "', 1";
                }
                else if (tableName == "ubytki_k")
                {
                    insertStatement += "'" + row["nr_ksiegi"].ToString().Replace("'", "''") + "', '" + row["data_ubyt"].ToString().Replace("'", "''") + "', " + row["kod"].ToString().Replace("'", "''") + ", '" + row["syg"].ToString().Replace("'", "''") + "', '" + row["NUMER_INW"].ToString().Replace("'", "''") + "', '" + row["AUTOR1"].ToString().Replace("'", "''") + "', '" + row["TYTUL_GL"].ToString().Replace("'", "''") + "', " + row["ROK_WYD"].ToString().Replace("'", "''") + ", " + row["CENA"].ToString().Replace("'", "''").Replace(",", ".") + ", " + row["PRZYCZYNA"].ToString().Replace("'", "''") + ", '" + row["NR_DOW"].ToString().Replace("'", "''") + "', '" + row["UWAGI_U"].ToString().Replace("'", "''") + "', " + row["ILOSC"].ToString().Replace("'", "''") + ", 1";
                }
                else if (tableName == "serie")
                {
                    insertStatement += row["KODY"].ToString().Replace("'", "''") + ", '" + row["TYT_SERII"].ToString().Replace("'", "''") + "', '" + row["ISSN"].ToString().Replace("'", "''") + "', '" + row["INST_SERII"].ToString().Replace("'", "''") + "', '" + row["SIED_SERII"].ToString().Replace("'", "''") + "', 1";
                }
                else if (tableName == "podserie")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["TYT_PSERII"].ToString().Replace("'", "''") + "', '" + row["PISSN"].ToString().Replace("'", "''") + "', '" + row["NAZWA_PCZ"].ToString().Replace("'", "''") + "', '" + row["NUMER_PCZ"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName == "panstwa")
                {
                    insertStatement += "'" + row["PANSTWO"].ToString().Replace("'", "''") + "', '" + row["KOD2"].ToString().Replace("'", "''") + "', " + row["P_KOD_CYFR"].ToString().Replace("'", "''") + ", '" + row["P_SK_NAZWA"].ToString().Replace("'", "''") + "', '" + row["P_AN_NAZWA"].ToString().Replace("'", "''") + "', '" + row["P_PL_NAZWA"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName == "ksi_ser")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", " + row["KODY"].ToString().Replace("'", "''") + ", '" + row["NAZWA_CZ"].ToString().Replace("'", "''") + "', '" + row["NUMER_CZ"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName == "sygnat")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["SYG"].ToString().Replace("'", "''") + "', '" + row["NUMER_INW"].ToString().Replace("'", "''") + "', " + (row.Table.Columns.Contains("K_KRESKOWY") ? row["K_KRESKOWY"].ToString().Replace("'", "''") : "0") + ", " + 
                        (row.Table.Columns.Contains("ID_ZASOB") ? row["ID_ZASOB"].ToString().Replace("'", "''") : "NULL") + ", '" + row["NUMER_AKC"].ToString().Replace("'", "''") + "', " + row["RODZ_KSIEG"].ToString().Replace("'", "''") + ", " + row["SPOS_NAB"].ToString().Replace("'", "''") + ", " + row["ILOSC_ALL"].ToString().Replace("'", "''") + ", " + row["ILOSC_POZ"].ToString().Replace("'", "''") + ", " + row["CENA"].ToString().Replace("'", "''").Replace(",", ".") + ", " + row["WARTOSC"].ToString().Replace("'", "''").Replace(",", ".") + ", '" + 
                        (row.Table.Columns.Contains("WALUTA") ? row["WALUTA"].ToString().Replace("'", "''") : "") + "', '" + row["DATA_ZAP"].ToString().Replace("'", "''") + "', " + (row["WYPOZYCZ"].ToString().ToLower() == "f" ? "0" : "1") + ", " + row["SIGLUM_SYG"].ToString().Replace("'", "''") + ", '" + row["UWAGI_S"].ToString().Replace("'", "''") + "', 0, " + "(SELECT dbo.Expand('" + row["SYG"].ToString().Replace("'", "''") + "', 6, 60)), " + "(SELECT dbo.Expand('" + row["NUMER_INW"].ToString().Replace("'", "''") + "', 6, 60))";
                }
                else if (tableName == "t_dodatk")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["T_DODATK"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName == "t_rownol")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["T_ROWNOL"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName == "tomy")
                {
                    insertStatement = "";

                    foreach(string temp in row["TOMY"].ToString().Replace("'", "''").Split(',').ToArray().Where(x => !string.IsNullOrWhiteSpace(x) && row["KOD"].ToString().Trim() != x.Trim()))
                        insertStatement += (!string.IsNullOrWhiteSpace(insertStatement) ? ", " : "") + "(" + temp.ToString().Replace("'", "''") + ", " + row["KOD"].ToString().Replace("'", "''") + ")";
                }
                else if (tableName == "ksiazki_new")
                {
                    insertStatement += row["KOD"].ToString().Replace("'", "''") + ", '" + row["TYTUL_GL"].ToString().Replace("'", "''") + "', " + (row["ID_WYD1"].ToString().Replace("'", "''") == "0" ? "NULL" : row["ID_WYD1"].ToString().Replace("'", "''")) + ", " + (row["ID_WYD2"].ToString().Replace("'", "''") == "0" ? "NULL" : row["ID_WYD2"].ToString().Replace("'", "''")) + ", '" + row["WYDANIE"].ToString().Replace("'", "''") + "', " + row["ROK_WYD"].ToString().Replace("'", "''") + ", '" + row["LATA_WYD"].ToString().Replace("'", "''") + "', '" + row["STRONY"].ToString().Replace("'", "''") + "', '" + row["ISBN"].ToString().Replace("'", "''") + "', '" + row["ISBN2"].ToString().Replace("'", "''") + "', '" + row["IL_TOMOW"].ToString().Replace("'", "''").Replace(",", ".") + "', " + row["WYSOKOSC"].ToString().Replace("'", "''").Replace(",", ".") + ", " + row["DLUGOSC"].ToString().Replace("'", "''") + ", " + row["ZAWARTOSC"].ToString().Replace("'", "''") + ", " + (row["S_POL"].ToString().ToLower() == "f" ? "0" : "1") + ", " + (row["S_ANG"].ToString().ToLower() == "f" ? "0" : "1") + ", " + (row["S_NIEM"].ToString().ToLower() == "f" ? "0" : "1") + ", " + (row["S_FRAN"].ToString().ToLower() == "f" ? "0" : "1") + ", " + (row["S_ROS"].ToString().ToLower() == "f" ? "0" : "1") + ", '" + row["UKD"].ToString().Replace("'", "''") + "', '" + row["UWAGI"].ToString().Replace("'", "''") + "', 0, 1";
                }
                else if (tableName == "ksiazki_autor_new")
                {
                    insertStatement = "";
                    //insertStatement += tableName + " (id_ksiazka, id_autor, rating)";
                    if (row["AUTOR1"].ToString().Replace("'", "''").Length > 0 || row["IMIE1"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += "(" + row["KOD"].ToString().Replace("'", "''") + ", (SELECT ISNULL((select TOP 1 id_aut from list_aut_k WHERE LTRIM(RTRIM(nazwisko)) = '" + row["AUTOR1"].ToString().Replace("'", "''") + "' AND LTRIM(RTRIM(imie)) = '" + row["IMIE1"].ToString().Replace("'", "''") + "'), -1)), 1)" + Environment.NewLine;

                    if (row["AUTOR2"].ToString().Replace("'", "''").Length > 0 || row["IMIE2"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += (insertStatement.Length > 0 ? ",(" : "") + row["KOD"].ToString().Replace("'", "''") + ", (SELECT ISNULL((select TOP 1 id_aut from list_aut_k WHERE LTRIM(RTRIM(nazwisko)) = '" + row["AUTOR2"].ToString().Replace("'", "''") + "' AND LTRIM(RTRIM(imie)) = '" + row["IMIE2"].ToString().Replace("'", "''") + "'), -1)), 2)" + Environment.NewLine;

                    if (row["AUTOR3"].ToString().Replace("'", "''").Length > 0 || row["IMIE3"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += (insertStatement.Length > 0 ? ",(" : "") + row["KOD"].ToString().Replace("'", "''") + ", (SELECT ISNULL((select TOP 1 id_aut from list_aut_k WHERE LTRIM(RTRIM(nazwisko)) = '" + row["AUTOR3"].ToString().Replace("'", "''") + "' AND LTRIM(RTRIM(imie)) = '" + row["IMIE3"].ToString().Replace("'", "''") + "'), -1)), 3)";
                }
                else if (tableName == "ksiazki_wautor_new")
                {
                    insertStatement = "";
                    //insertStatement += tableName + " (id_ksiazka, id_autor, rating)";
                    
                    if (row["WAUTOR1"].ToString().Replace("'", "''").Length > 0 || row["WIMIE1"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += "(" + row["KOD"].ToString().Replace("'", "''") + ", (SELECT ISNULL((select TOP 1 id_aut from list_aut_k WHERE LTRIM(RTRIM(nazwisko)) = '" + row["WAUTOR1"].ToString().Replace("'", "''") + "' AND LTRIM(RTRIM(imie)) = '" + row["WIMIE1"].ToString().Replace("'", "''") + "'), -1)), 1)" + Environment.NewLine;

                    if (row["WAUTOR2"].ToString().Replace("'", "''").Length > 0 || row["WIMIE2"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += (insertStatement.Length > 0 ? ",(" : "") + row["KOD"].ToString().Replace("'", "''") + ", (SELECT ISNULL((select TOP 1 id_aut from list_aut_k WHERE LTRIM(RTRIM(nazwisko)) = '" + row["WAUTOR2"].ToString().Replace("'", "''") + "' AND LTRIM(RTRIM(imie)) = '" + row["WIMIE2"].ToString().Replace("'", "''") + "'), -1)), 2)" + Environment.NewLine;

                    if (row["WAUTOR3"].ToString().Replace("'", "''").Length > 0 || row["WIMIE3"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += (insertStatement.Length > 0 ? ",(" : "") + row["KOD"].ToString().Replace("'", "''") + ", (SELECT ISNULL((select TOP 1 id_aut from list_aut_k WHERE LTRIM(RTRIM(nazwisko)) = '" + row["WAUTOR3"].ToString().Replace("'", "''") + "' AND LTRIM(RTRIM(imie)) = '" + row["WIMIE3"].ToString().Replace("'", "''") + "'), -1)), 3)" + Environment.NewLine;

                    if ((row.Table.Columns.Contains("WAUTOR4") && row["WAUTOR4"].ToString().Replace("'", "''").Length > 0) || (row.Table.Columns.Contains("WIMIE4") && row["WIMIE4"].ToString().Replace("'", "''").Length > 0))
                        insertStatement += (insertStatement.Length > 0 ? ",(" : "") + row["KOD"].ToString().Replace("'", "''") + ", (SELECT ISNULL((select TOP 1 id_aut from list_aut_k WHERE LTRIM(RTRIM(nazwisko)) = '" + row["WAUTOR4"].ToString().Replace("'", "''") + "' AND LTRIM(RTRIM(imie)) = '" + row["WIMIE4"].ToString().Replace("'", "''") + "'), -1)), 4)";
                }
                else if (tableName == "art_aut")
                {
                    insertStatement = "";

                    if (row["AUTOR1"].ToString().Replace("'", "''").Length > 0 || row["IMIE1"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += "(" + row["KOD"].ToString().Replace("'", "''") + ", (SELECT ISNULL((select TOP 1 id_aut from list_aut_a WHERE LTRIM(RTRIM(nazwisko)) = '" + row["AUTOR1"].ToString().Replace("'", "''") + "' AND LTRIM(RTRIM(imie)) = '" + row["IMIE1"].ToString().Replace("'", "''") + "'), -1)))" + Environment.NewLine;                    
                                           
                    if (row["AUTOR2"].ToString().Replace("'", "''").Length > 0 || row["IMIE2"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += (insertStatement.Length > 0 ? "," : "") + "(" + row["KOD"].ToString().Replace("'", "''") + ", (SELECT ISNULL((select TOP 1 id_aut from list_aut_a WHERE LTRIM(RTRIM(nazwisko)) = '" + row["AUTOR2"].ToString().Replace("'", "''") + "' AND LTRIM(RTRIM(imie)) = '" + row["IMIE2"].ToString().Replace("'", "''") + "'), -1)))" + Environment.NewLine;

                    if (row["AUTOR3"].ToString().Replace("'", "''").Length > 0 || row["IMIE3"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += (insertStatement.Length > 0 ? "," : "") + "(" + row["KOD"].ToString().Replace("'", "''") + ", (SELECT ISNULL((select TOP 1 id_aut from list_aut_a WHERE LTRIM(RTRIM(nazwisko)) = '" + row["AUTOR3"].ToString().Replace("'", "''") + "' AND LTRIM(RTRIM(imie)) = '" + row["IMIE3"].ToString().Replace("'", "''") + "'), -1)))";
                }
                else if (tableName == "odpowiedzialnosci_new")
                {
                    insertStatement += "'" + row["ODPOW"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName == "ksiazki_jezyki_new")
                {
                    insertStatement = "";

                    if (row["JEZYK1"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += "(" + row["KOD"].ToString().Replace("'", "''") + ", (SELECT TOP 1 id FROM jezyki WHERE jezyk = '" + row["JEZYK1"].ToString().Replace("'", "''") + "'))";

                    if (row["JEZYK2"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += (insertStatement.Length > 0 ? ",(" : "") + row["KOD"].ToString().Replace("'", "''") + ", (SELECT TOP 1 id FROM jezyki WHERE jezyk = '" + row["JEZYK2"].ToString().Replace("'", "''") + "'))";

                    if (row["JEZYK3"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += (insertStatement.Length > 0 ? ",(" : "") + row["KOD"].ToString().Replace("'", "''") + ", (SELECT TOP 1 id FROM jezyki WHERE jezyk = '" + row["JEZYK3"].ToString().Replace("'", "''") + "'))";

                    if (row["JEZYK4"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += (insertStatement.Length > 0 ? ",(" : "") + row["KOD"].ToString().Replace("'", "''") + ", (SELECT TOP 1 id FROM jezyki WHERE jezyk = '" + row["JEZYK4"].ToString().Replace("'", "''") + "'))";

                    if (row["JEZYK5"].ToString().Replace("'", "''").Length > 0)
                        insertStatement += (insertStatement.Length > 0 ? ",(" : "") + row["KOD"].ToString().Replace("'", "''") + ", (SELECT TOP 1 id FROM jezyki WHERE jezyk = '" + row["JEZYK5"].ToString().Replace("'", "''") + "'))";
                }
                else if (tableName == "wautor_odpowiedzialnosc_new")
                {
                    insertStatement += "(select TOP 1 id FROM ksiazki_wautor_new where id_wautor = (SELECT TOP 1 id_aut FROM list_aut_k WHERE imie = '" + row["imie"].ToString().Replace("'", "''") + "' AND nazwisko = '" + row["nazwisko"].ToString().Replace("'", "''") + "') AND id_ksiazka = " + row["kod"].ToString().Replace("'", "''") + "), " +
                        " (SELECT TOP 1 id FROM odpowiedzialnosci_new WHERE nazwa = '" + row["odpow"].ToString().Replace("'", "''").Trim() + "')";
                }
                else if (tableName == "zasoby")
                {
                    insertStatement += row["ID_ZASOB"].ToString().Replace("'", "''") + ", " + row["K_KRESKOWY"].ToString().Replace("'", "''") + ", " + row["KOD"].ToString().Replace("'", "''") + ", '" +
                        row["SYG"].ToString().Replace("'", "''") + "', '" + row["TYTUL"].ToString().Replace("'", "''") + "', '" + row["AUTOR"].ToString().Replace("'", "''") + "', " +
                        row["RODZAJ_ZAS"].ToString().Replace("'", "''") + ", " + row["ROK1"].ToString().Replace("'", "''") + ", " + row["ROK2"].ToString().Replace("'", "''") + ", '" +
                        row["VOLUMIN"].ToString().Replace("'", "''") + "', " + row["NUMER_Z"].ToString().Replace("'", "''").Replace(",", ".") + ", " + row["NUMER_Z2"].ToString().Replace("'", "''").Replace(",", ".") + ", '" +
                    row["NUMER_INW"].ToString().Replace("'", "''") + "', " + (row["STAN"].ToString().ToLower() == "f" ? "0" : "1") + ", 0";
                }
                else if (tableName == "wypozycz" && containsResourceIdCheckBox.Checked)
                {
                    insertStatement += row["ID_UZYT"].ToString().Replace("'", "''") + ", " + (row.Table.Columns.Contains("ID_ZASOB") ? row["ID_ZASOB"].ToString().Replace("'", "''") : "NULL") + ", " + row["RODZAJ_POZ"].ToString().Replace("'", "''") + ", " + row["KOD"].ToString().Replace("'", "''") + ", '" +
                        row["SYG"].ToString().Replace("'", "''") + "', " +
                        (row["DATA_WYP"].ToString().Replace("'", "''") == "1900-01-01 00:00:00" ? "NULL" : "'" + row["DATA_WYP"].ToString().Replace("'", "''") + "'") + ", " +

                        (row["DATA_PRZEW"].ToString().Replace("'", "''") == "1900-01-01 00:00:00" ? "NULL" : "'" + row["DATA_PRZEW"].ToString().Replace("'", "''") + "'") + ", " +
                        (row["DATA_UPOM"].ToString().Replace("'", "''") == "1900-01-01 00:00:00" ? "NULL" : "'" + row["DATA_UPOM"].ToString().Replace("'", "''") + "'") + ", " +
                        (row["DATA_ZWR"].ToString().Replace("'", "''") == "1900-01-01 00:00:00" ? "NULL" : "'" + row["DATA_ZWR"].ToString().Replace("'", "''") + "'") + ", '" 
                        + row["KTO_WZIAL"].ToString().Replace("'", "''") + "'";
                }
                else if (tableName == "wypozycz" && !containsResourceIdCheckBox.Checked)
                {
                    insertStatement += string.Format(row["ID_UZYT"].ToString().Replace("'", "''") + ", " + 
                        row["RODZAJ_POZ"].ToString().Replace("'", "''") + ", " + 
                        row["KOD"].ToString().Replace("'", "''") + ", '" +
                        row["SYG"].ToString().Replace("'", "''") + "', '" +
                        row["NUMER_INW"].ToString().Replace("'", "''") + "', " +
                        row["ROK1"].ToString().Replace("'", "''") + ", " +
                        row["ROK2"].ToString().Replace("'", "''") + ", '" +
                        row["VOLUMIN"].ToString().Replace("'", "''") + "', " +
                        row["NUMER_Z"].ToString().Replace("'", "''") + ", " +
                        row["NUMER_Z2"].ToString().Replace("'", "''") + ", " +


                        (row["DATA_ZAP"].ToString().Replace("'", "''") == "1900-01-01 00:00:00" ? "NULL" : "'" + row["DATA_ZAP"].ToString().Replace("'", "''") + "'") + ", " +

                        (row["DATA_WYKR"].ToString().Replace("'", "''") == "1900-01-01 00:00:00" ? "NULL" : "'" + row["DATA_WYKR"].ToString().Replace("'", "''") + "'") + ", " +
                        (row["DATA_PRZEW"].ToString().Replace("'", "''") == "1900-01-01 00:00:00" ? "NULL" : "'" + row["DATA_PRZEW"].ToString().Replace("'", "''") + "'") + ", " +
                        (row["DATA_UPOM"].ToString().Replace("'", "''") == "1900-01-01 00:00:00" ? "NULL" : "'" + row["DATA_UPOM"].ToString().Replace("'", "''") + "'") + ", " +     
                        row["ROK_WYD"].ToString().Replace("'", "''") + ", '{0}'", row["TYTUL"].ToString().Replace("'", "''"));
                }
                else if (tableName == "pracow" || tableName == "persons")
                {
                    insertStatement += row["ID_UZYT"].ToString().Replace("'", "''") + ", " + 
                        (row["DATA_WPISU"].ToString().Replace("'", "''") == "1900-01-01 00:00:00" ? "NULL" : "'" + row["DATA_WPISU"].ToString().Replace("'", "''") + "'") + ", " +
                        (row["DATA_WYK"].ToString().Replace("'", "''") == "1900-01-01 00:00:00" ? "NULL" : "'" + row["DATA_WYK"].ToString().Replace("'", "''") + "'") + ", '" +
                        row["NAZWISKO"].ToString().Replace("'", "''") + "', '" +
                        row["IMIE"].ToString().Replace("'", "''") + "', '" + row["DZIAL"].ToString().Replace("'", "''") + "', '" + row["TEL_SLUZ"].ToString().Replace("'", "''") + "', '" +
                        row["POCZTA"].ToString().Replace("'", "''") + "', '" + row["MIASTO"].ToString().Replace("'", "''") + "', '" + row["ADRES"].ToString().Replace("'", "''") + "', '" +
                        row["TEL_DOM"].ToString().Replace("'", "''") + "', '" + row["NR_LEGITYM"].ToString().Replace("'", "''").Replace(",", ".") + "', '" + row["ODWIEDZINY"].ToString().Replace("'", "''").Replace(",", ".") + "', " +
                    (row["DATA_W_ROK"].ToString().Replace("'", "''") == "1900-01-01 00:00:00" ? "NULL" : "'" + row["DATA_W_ROK"].ToString().Replace("'", "''") + "'") + ", " +


                        row["ILOSC_W_K"].ToString().Replace("'", "''") + ", " + row["ILOSC_W_C"].ToString().Replace("'", "''") + ", " + row["ILOSC_Z_K"].ToString().Replace("'", "''") + ", " +
                    row["ILOSC_Z_C"].ToString().Replace("'", "''");
                }

                //, ilosc_w_c, ilosc_z_k, ilosc_z_c

                if (tableName != "ksiazki_autor_new" && tableName != "ksiazki_wautor_new" && tableName != "art_aut" && tableName != "ksiazki_jezyki_new" && tableName != "tomy")
                    insertStatement += ")";
            }


            if (last && tableName == "czasop_n")
            {
                insertStatement = "UPDATE czasop_n SET volumin = SUBSTRING(volumin, 0, 10)  WHERE id_volumes = -1; " + Environment.NewLine + ";with select_volumes_from_czasop_n AS " + Environment.NewLine + "( " + Environment.NewLine + "SELECT czasop.kod AS kod_czasop, LTRIM(RTRIM(syg)) AS syg, rok1, 0 AS rok2,/* SUBSTRING(volumin + ' -autom.', 0, 16) AS*/ volumin, GETDATE() AS data_biez, 0 AS k_kreskowy, " + Environment.NewLine + "ISNULL((SELECT cza_syg.id_cza_syg FROM dbo.cza_syg WHERE czasop.kod = kod AND LTRIM(RTRIM(cza_syg.syg)) = LTRIM(RTRIM(syg))), -1) AS id_cza_syg, " + Environment.NewLine + "akcesja.kod AS akcesja_kod " + Environment.NewLine + "FROM dbo.czasop_n " + Environment.NewLine + "INNER JOIN akcesja ON akcesja.kod = czasop_n.kod " + Environment.NewLine + "INNER JOIN czasop ON czasop.kod = akcesja.nr_czasop " + Environment.NewLine + "INNER JOIN cza_syg ON cza_syg.kod = czasop.kod " + Environment.NewLine + "where id_volumes = -1 " + Environment.NewLine + ") " + Environment.NewLine + "INSERT INTO volumes (kod, syg, rok1, rok2, volumin, data_biez, k_kreskowy, id_cza_syg) " + Environment.NewLine + "SELECT DISTINCT kod_czasop, syg, rok1, rok2, volumin, data_biez, k_kreskowy, id_cza_syg " + Environment.NewLine + "FROM select_volumes_from_czasop_n; " + Environment.NewLine + ";with tab_czasop AS ( " + Environment.NewLine + "SELECT id_czasop_n, akcesja.kod AS akcesja_kod, volumes.kod AS volumes_kod, czasop_n.volumin AS czasop_n_volumin, volumes.volumin AS volumes_volumin, czasop_n.id_volumes AS czasop_n_id_volumes, volumes.id_volumes AS volumes_id_volumes " + Environment.NewLine + "FROM czasop_n " + Environment.NewLine + "INNER JOIN akcesja ON akcesja.kod = czasop_n.kod " + Environment.NewLine + "INNER JOIN volumes ON volumes.kod = akcesja.nr_czasop AND LTRIM(RTRIM(volumes.volumin)) = LTRIM(RTRIM(czasop_n.volumin)) AND volumes.rok1 = czasop_n.rok1  " + Environment.NewLine + "where czasop_n.id_volumes = -1 " + Environment.NewLine + ") " + Environment.NewLine + "UPDATE czasop_n SET id_volumes = tab_czasop.volumes_id_volumes " + Environment.NewLine + "FROM tab_czasop " + Environment.NewLine + "WHERE czasop_n.id_czasop_n = tab_czasop.id_czasop_n; " + Environment.NewLine;
            }
            else if (last && tableName == "ksiazki_autor_new")
            {
                insertStatement = "DELETE FROM ksiazki_autor_new WHERE id_autor = -1;";
            }
            else if (last && tableName == "ksiazki_wautor_new")
            {
                insertStatement = "DELETE FROM ksiazki_wautor_new WHERE id_wautor = -1;";
            }
            else if (last && tableName == "art_aut")
            {
                insertStatement = "DELETE FROM art_aut WHERE id_aut = -1;";
            }
            else if (last)
                insertStatement = "";
            

            return insertStatement;
        }

        /*private string exportAuthors(string tableName, DataTable Dt)
        {
            StringBuilder insertStatement = new StringBuilder();

            int dzielnik = 200;

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (i % dzielnik == 0)
                    insertStatement.Append(";with tab1 AS (");

                if (Dt.Rows[i]["IMIE1"].ToString().Replace("'", "''").Length > 0 || Dt.Rows[i]["AUTOR1"].ToString().Replace("'", "''").Length > 0)
                    insertStatement.Append("SELECT '" + Dt.Rows[i]["IMIE1"].ToString().Replace("'", "''") + "' AS imie, '" + Dt.Rows[i]["AUTOR1"].ToString().Replace("'", "''") + "' AS nazwisko" + Environment.NewLine + "UNION" + Environment.NewLine);

                if (Dt.Rows[i]["IMIE2"].ToString().Replace("'", "''").Length > 0 || Dt.Rows[i]["AUTOR2"].ToString().Replace("'", "''").Length > 0)
                    insertStatement.Append("SELECT '" + Dt.Rows[i]["IMIE2"].ToString().Replace("'", "''") + "' AS imie, '" + Dt.Rows[i]["AUTOR2"].ToString().Replace("'", "''") + "' AS nazwisko" + Environment.NewLine + "UNION" + Environment.NewLine);

                if (Dt.Rows[i]["IMIE3"].ToString().Replace("'", "''").Length > 0 || Dt.Rows[i]["AUTOR3"].ToString().Replace("'", "''").Length > 0)
                    insertStatement.Append("SELECT '" + Dt.Rows[i]["IMIE3"].ToString().Replace("'", "''") + "' AS imie, '" + Dt.Rows[i]["AUTOR3"].ToString().Replace("'", "''") + "' AS nazwisko" + Environment.NewLine + "UNION" + Environment.NewLine);

                if (Dt.Rows[i]["WIMIE1"].ToString().Replace("'", "''").Length > 0 || Dt.Rows[i]["WAUTOR1"].ToString().Replace("'", "''").Length > 0)
                    insertStatement.Append("SELECT '" + Dt.Rows[i]["WIMIE1"].ToString().Replace("'", "''") + "' AS imie, '" + Dt.Rows[i]["WAUTOR1"].ToString().Replace("'", "''") + "' AS nazwisko" + Environment.NewLine + "UNION" + Environment.NewLine);

                if (Dt.Rows[i]["WIMIE2"].ToString().Replace("'", "''").Length > 0 || Dt.Rows[i]["WAUTOR2"].ToString().Replace("'", "''").Length > 0)
                    insertStatement.Append("SELECT '" + Dt.Rows[i]["WIMIE2"].ToString().Replace("'", "''") + "' AS imie, '" + Dt.Rows[i]["WAUTOR2"].ToString().Replace("'", "''") + "' AS nazwisko" + Environment.NewLine + "UNION" + Environment.NewLine);

                if (Dt.Rows[i]["WIMIE3"].ToString().Replace("'", "''").Length > 0 || Dt.Rows[i]["WAUTOR3"].ToString().Replace("'", "''").Length > 0)
                    insertStatement.Append("SELECT '" + Dt.Rows[i]["WIMIE3"].ToString().Replace("'", "''") + "' AS imie, '" + Dt.Rows[i]["WAUTOR3"].ToString().Replace("'", "''") + "' AS nazwisko" + Environment.NewLine + "UNION" + Environment.NewLine);

                if (Dt.Rows[i]["WIMIE4"].ToString().Replace("'", "''").Length > 0 || Dt.Rows[i]["WAUTOR4"].ToString().Replace("'", "''").Length > 0)
                    insertStatement.Append("SELECT '" + Dt.Rows[i]["WIMIE4"].ToString().Replace("'", "''") + "' AS imie, '" + Dt.Rows[i]["WAUTOR4"].ToString().Replace("'", "''") + "' AS nazwisko" + Environment.NewLine + "UNION" + Environment.NewLine);

                if ((i + 1) % dzielnik == 0 || i == Dt.Rows.Count)
                { 
                    insertStatement.AppendLine("SELECT '' AS imie, '' AS nazwisko )" + Environment.NewLine + /*" INSERT INTO " + tableName + " (imie, nazwisko)" + Environment.NewLine + " SELECT imie, nazwisko FROM tab1 WHERE imie != '' AND nazwisko != '' AND NOT EXISTS (SELECT imie, nazwisko FROM list_aut_k WHERE list_aut_k.imie = tab1.imie AND list_aut_k.nazwisko = tab1.nazwisko);");

                   /* insertStatement.AppendLine("GO");
                }

            }

            

            richTextBox1.Text = insertStatement.ToString();
            return insertStatement.ToString();
        }*/

        private string getOrdinal(string tableName)
        {
            return string.Format("{0:000}", ordinaList.FindIndex(x => x == tableName));
        }

        private void SaveToMSSQLFile(string TableName, string FileName, DataTable Dt)
        {
            const int dzielnik = 300;

            int count = Dt.Rows.Count;

            if (count == 0)
                return;

            try
            {
                StreamWriter ToMSSQLStreamWriter = new StreamWriter(new FileStream(Environment.CurrentDirectory + "\\" + getOrdinal(TableName.ToLower().Trim()) + TableName + ".sql", FileMode.Create, FileAccess.Write), Encoding.Default);

                StringBuilder MSSQLFormat = new StringBuilder();
                MSSQLFormat.AppendLine("use coliber_wzorzec;");
                MSSQLFormat.AppendLine("GO");

                if (turnOnIdentityInsert(TableName))
                    MSSQLFormat.Append("SET IDENTITY_INSERT dbo." + TableName + " ON;" + Environment.NewLine);

                MSSQLFormat.Append("EXEC sp_msforeachtable \"ALTER TABLE ? NOCHECK CONSTRAINT all\";" + Environment.NewLine);
                MSSQLFormat.Append("EXEC sp_msforeachtable \"ALTER TABLE ? DISABLE TRIGGER all\";" + Environment.NewLine);
                MSSQLFormat.Append("GO" + Environment.NewLine);

                //rows to table
                for (int i = 0; i < count; i++)
                {
                    if (i % dzielnik == 0)
                        MSSQLFormat.Append(getInsertStatements(TableName) + " VALUES " + Environment.NewLine);

                    string temp = getInsertRow(TableName, Dt.Rows[i], false).Trim();

                    /*if (string.IsNullOrWhiteSpace(temp) && i < Dt.Rows.Count - 1 && (i + 1) % dzielnik != 0)
                        continue;*/

                    MSSQLFormat.Append(temp);
                    //MSSQLFormat.Append(getInsertRow(TableName, Dt.Rows[i], false));

                    if (((i + 1)%dzielnik == 0) || i == count - 1)
                    {
                        //MessageBox.Show(MSSQLFormat[MSSQLFormat.Length - 1].ToString());

                        if (string.IsNullOrWhiteSpace(MSSQLFormat.ToString().Substring(MSSQLFormat.ToString().LastIndexOf(',')+1)))
                            MSSQLFormat[MSSQLFormat.ToString().LastIndexOf(',')] = ' ';

                        MSSQLFormat.AppendLine("; " + Environment.NewLine + "GO");

                        ToMSSQLStreamWriter.WriteLine(MSSQLFormat.ToString());
                        MSSQLFormat.Clear();
                    }
                    else if (!string.IsNullOrWhiteSpace(temp))
                        MSSQLFormat.AppendLine(",");

                    /*if (!string.IsNullOrWhiteSpace(temp))
                        MSSQLFormat.Append(Environment.NewLine);   */                 
                }

                MSSQLFormat.Append(getInsertRow(TableName, null, true));
                //-- end rows to table

                if (turnOnIdentityInsert(TableName))
                    MSSQLFormat.Append("SET IDENTITY_INSERT dbo." + TableName + " OFF;" + Environment.NewLine);

                MSSQLFormat.Append("EXEC sp_msforeachtable \"ALTER TABLE ? WITH NOCHECK CHECK CONSTRAINT all\";" + Environment.NewLine);
                MSSQLFormat.Append("EXEC sp_msforeachtable \"ALTER TABLE ? ENABLE TRIGGER all\";" + Environment.NewLine);                
                
                //richTextBox1.Text = MSSQLFormat.ToString();

                ToMSSQLStreamWriter.WriteLine(MSSQLFormat.ToString());
                
                ToMSSQLStreamWriter.Close();
                
                //MessageBox.Show("Wyeksportowano!");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathTextBox.Text = folderBrowserDialog1.SelectedPath;
                button1.Enabled = true;
                exportButton.Enabled = true;
            }
        }
    }
}
