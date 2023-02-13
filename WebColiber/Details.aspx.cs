using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;
using WebColiber.App_GlobalResources;

namespace WebColiber
{
    public partial class Details : System.Web.UI.Page
    {
        protected string type;
        protected int id;
        private static string title;

        protected static object getField(string columnName, string query, SqlConnection connection)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            object tmp;
                            do
                            {
                                if ((tmp = reader.GetValue(columnName)) != null)
                                    return tmp;
                            }
                            while(reader.Read());
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        protected static object getField(string query, SqlConnection connection)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    return cmd.ExecuteScalar();
                }
            }
            catch
            {
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            type = Request.QueryString["type"];
            if (!Int32.TryParse(Request.QueryString["id"], out id) || type.Length == 0) return;

            if (type.ToLower() != "book" && type.ToLower() != "books") AddToBasketButton.Visible = false;

            lblContent.Text = GenerateContent(type, id.ToString());

            this.Page.Title = title;

            #region a
            /*lblContent.Text = "<table class=\"table table-striped table-bordered table-hover table-condensed\">";
            switch (type.ToLower().Trim())
            {
                #region Książki
                case "book": 
                    //AddLine("Typ", "Książka");

                    using (SqlConnection conn = new SqlConnection(Settings.ColiberConnectionString))
                    {
                        conn.Open();
                        string query = "SELECT k.*, w1.nazwa_w AS nazwa_w1, w1.miasto_w AS miasto_w1, w2.miasto_w AS miasto_w2, w2.nazwa_w AS nazwa_w2 FROM ksiazki k" +
                                       " LEFT OUTER JOIN wydawca_k w1 ON k.id_wyd1 = w1.id_wydawcy" +
                                       " LEFT OUTER JOIN wydawca_k w2 ON k.id_wyd2 = w2.id_wydawcy" +
                                       " WHERE kod = @kod; ";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            SqlParameter par = new SqlParameter();
                            par.ParameterName = "@kod";
                            par.SqlDbType = System.Data.SqlDbType.Decimal;
                            par.Value = id;

                            cmd.Parameters.Add(par);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if(reader.HasRows)
                                {
                                    reader.Read();

                                    using (SqlConnection conn2 = new SqlConnection(Settings.ColiberConnectionString))
                                    {
                                        conn2.Open();
                                        SqlConnection WypozyczalniaDatabaseConnection = new SqlConnection(Settings.WypozyczalniaConnectionString);

                                        //SYGNATURA
                                        string Query = "SELECT ISNULL(sygnat.syg,'') As syg, ISNULL(LTRIM(RTRIM(sygnat.numer_inw)),'') As numer_inw, CASE WHEN wypozyczony = 1 THEN '(wypożyczona)' ELSE '' END AS stan, CASE WHEN wypozyczony = 1 THEN '(wypożyczony)' ELSE '' END AS stan_num_inw FROM sygnat " +                                                        
                                                        "INNER JOIN zasoby ON zasoby.id_zasob = sygnat.id_zasob " +
                                                        "INNER JOIN " + WypozyczalniaDatabaseConnection.Database +"..w2_zasoby ON " + WypozyczalniaDatabaseConnection.Database +"..w2_zasoby.obcy_id = zasoby.id_zasob " +                                                        
                                                        "WHERE sygnat.kod = @id ORDER BY syg_expand; ";

                                        using (SqlCommand cmdSyg = new SqlCommand(Query, conn2))
                                        {
                                            cmdSyg.Parameters.AddWithValue("@id", id);

                                            using (SqlDataReader readerSyg = cmdSyg.ExecuteReader())
                                            {
                                                while (readerSyg.Read())
                                                {
                                                    if (Settings.ShowNumerInwentarzowy)
                                                        AddLine("Numer inwentarzowy", readerSyg.GetValue("numer_inw") + " <font color=\"red\">" + readerSyg.GetValue("stan_num_inw") + "</font>");
                                                    
                                                    AddLine("Sygnatura", readerSyg.GetValue("syg") + " <font color=\"red\">" + readerSyg.GetValue("stan") + "</font> <br /> <br />");
                                                }
                                            }
                                        }

                                        //TYTUŁY
                                        AddLine("Tytuł", reader.GetValue("tytul_gl"));
                                        this.Page.Title = reader.GetValue("tytul_gl").ToString();

                                        AddLine("Tytuł dod.", getField("SELECT t_dodatk FROM t_dodatk  WHERE kod=" + id + " ORDER BY t_dodatk; ", conn2));
                                        AddLine("Tytuł równ.", getField("SELECT t_rownol FROM t_rownol  WHERE kod=" + id + " ORDER BY t_rownol; ", conn2));

                                        {
                                            string authors = "";

                                            //object tmp;

                                            string autor1 = (reader.GetValue("imie1").ToString() + " " + reader.GetValue("autor1").ToString()).Trim();
                                            string autor2 = (reader.GetValue("imie2").ToString() + " " + reader.GetValue("autor2").ToString()).Trim();
                                            string autor3 = (reader.GetValue("imie3").ToString() + " " + reader.GetValue("autor3").ToString()).Trim();

                                            authors = autor1;

                                            if (authors.Length > 0 && autor2.Length > 0)
                                                authors += ", " + autor2;

                                            if (authors.Length > 0 && autor3.Length > 0)
                                                authors += ", " + autor3;

                                            AddLine("Autor", authors);
                                        }

                                        {
                                            string coAuthors = "";

                                            string wautor1 = (reader.GetValue("wimie1").ToString() + " " + reader.GetValue("wautor1").ToString()).Trim();
                                            string wautor2 = (reader.GetValue("wimie2").ToString() + " " + reader.GetValue("wautor2").ToString()).Trim();
                                            string wautor3 = (reader.GetValue("wimie3").ToString() + " " + reader.GetValue("wautor3").ToString()).Trim();
                                            string wautor4 = (reader.GetValue("wimie4").ToString() + " " + reader.GetValue("wautor4").ToString()).Trim();

                                            coAuthors = wautor1;

                                            if (coAuthors.Length > 0 && wautor2.Length > 0)
                                                coAuthors += ", " + wautor2;

                                            if (coAuthors.Length > 0 && wautor3.Length > 0)
                                                coAuthors += ", " + wautor3;

                                            if (coAuthors.Length > 0 && wautor4.Length > 0)
                                                coAuthors += ", " + wautor4;

                                            AddLine("Współautor", coAuthors);
                                        }

                                        string miasto_w1 = reader.GetValue("miasto_w1").ToString().Trim();
                                        string miasto_w2 = reader.GetValue("miasto_w2").ToString().Trim();

                                        if (miasto_w1 == miasto_w2)
                                            miasto_w2 = "";

                                        if (miasto_w1.Length > 0 && miasto_w2.Length > 0)
                                            miasto_w1 += ", ";

                                        if (miasto_w1.Length > 0 || miasto_w2.Length > 0)
                                            AddLine("Miejsce wydania", miasto_w1 + miasto_w2);

                                        AddLine("Wydawca", reader.GetValue("nazwa_w1"));
                                        AddLine("Wydawca", reader.GetValue("nazwa_w2"));

                                        string wydanie = reader.GetValue("rok_wyd").ToString();
                                        //AddLine("Wydanie", reader.GetValue("rok_wyd") + "; " + reader.GetValue("wydanie"));
                                        /*if (wydanie.Trim() != "0")
                                            AddLine("Wydanie", wydanie + "; " + reader.GetValue("wydanie"));
                                        else*/
                                        /*string data_wydania = reader.GetValue("rok_wyd").ToString();

                                        if(data_wydania != "0")
                                            AddLine("Data wydania", data_wydania);

                                        string jezyk1 = reader.GetValue("jezyk1").ToString().Trim();
                                        string jezyk2 = reader.GetValue("jezyk2").ToString().Trim();
                                        string jezyk3 = reader.GetValue("jezyk3").ToString().Trim();
                                        string jezyk4 = reader.GetValue("jezyk4").ToString().Trim();
                                        string jezyk5 = reader.GetValue("jezyk5").ToString().Trim();
                                        
                                        string jezyki = string.Join(", ", new string[] { jezyk1, jezyk2, jezyk3, jezyk4, jezyk5 }.Where(x => x.Length > 0));

                                        if(jezyki.Length > 0)
                                            jezyki = "Język tekstu: " + jezyki + ";<br />";

                                        string il_tomow = reader.GetValue("il_tomow").ToString().Trim();

                                        if (il_tomow.Length > 0)
                                            il_tomow = "Ilość tomów: " + il_tomow + "; <br />";

                                        string strony = reader.GetValue("strony").ToString().Trim();

                                        if (strony.Length > 0)
                                            strony = "Strony: " + strony + ";<br />";

                                        string streszczenia = string.Join(", ", new string[] {Boolean.Parse(reader.GetValue("s_ang").ToString()) ? "angielskie" : "", Boolean.Parse(reader.GetValue("s_fran").ToString()) ? "francuskie" : "", Boolean.Parse(reader.GetValue("s_niem").ToString()) ? "niemieckie" : "", Boolean.Parse(reader.GetValue("s_pol").ToString()) ? "polskie" : "", Boolean.Parse(reader.GetValue("s_ros").ToString()) ? "rosyjske" : ""}.Where(x => x.Length > 0));

                                        if (streszczenia.Length > 0)
                                            streszczenia = "Streszczenia: " + streszczenia + ";<br />";

                                        //AddLine("Opis fiz.", reader.GetValue("il_tomow") + " " + reader.GetValue("strony") + " " + jezyk1 + " " + jezyk2 + " " + jezyk3 + " " + jezyk4 + " " + jezyk5);
                                        AddLine("Opis fiz.", il_tomow + strony + jezyki + streszczenia);
                                        AddLine("ISBN", reader.GetValue("isbn"));

                                        AddLine("Seria", getField("SELECT tyt_serii FROM ksi_ser LEFT OUTER JOIN serie ON ksi_ser.kody = serie.kody WHERE kod=" + id + " ORDER BY tyt_serii; ", conn2));
                                    }
                                }
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand("SELECT kody, LTRIM(RTRIM(klucze)) AS klucze FROM ksi_klu WHERE kod = @kod;", conn))
                        {
                            SqlParameter par = new SqlParameter();
                            par.ParameterName = "@kod";
                            par.SqlDbType = System.Data.SqlDbType.Decimal;
                            par.Value = id;

                            cmd.Parameters.Add(par);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if(reader.HasRows)
                                {
                                    string klucze = "";
                                    do
                                    {
                                        object klucz = reader.GetValue("klucze");
                                        if (klucz != null && klucz.ToString().Length > 0)
                                            klucze += (klucze.Length > 0 ? ", " : "") + "<a href='Search.aspx?key=" + klucz + "&path=books'>" + klucz + "</a>";
                                    }
                                    while (reader.Read());

                                    if (klucze.Length > 0) AddLine("Klucze", klucze);
                                }
                            }
                        }

                        //Pobieranie adresów URL
                        using (SqlCommand cmd = new SqlCommand("SELECT LTRIM(RTRIM(nazwa)) AS nazwa, LTRIM(RTRIM(URL)) AS URL, uwagi FROM documents WHERE rodzaj_zasobu = 1 AND URL IS NOT NULL AND kod = @kod ORDER BY nazwa;", conn))
                        {
                            SqlParameter par = new SqlParameter();
                            par.ParameterName = "@kod";
                            par.SqlDbType = System.Data.SqlDbType.Decimal;
                            par.Value = id;

                            cmd.Parameters.Add(par);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    List<string> adresy = new List<string>();

                                    string Comments = "";
                                    while (reader.Read())
                                    {
                                        if (reader.GetValue("uwagi") != null && reader.GetValue("uwagi").ToString().Length > 0)
                                            Comments = " [" + reader.GetValue("uwagi") + "] ";

                                        adresy.Add("<a href=" + reader.GetValue("URL").ToString() + " target=\"_blank\">" + reader.GetValue("nazwa") + "</a>" + Comments + " <br />");

                                        Comments = "";
                                    }

                                    if (adresy.Count > 0) AddLine("<br />Źródła on-line", "<br />" + String.Join("<br />", adresy));
                                }
                            }
                        }

                        //Pobieranie informacji o plikach
                        using (SqlCommand cmd = new SqlCommand("SELECT id, LTRIM(RTRIM(nazwa)) AS nazwa, uwagi FROM documents WHERE rodzaj_zasobu = 1 AND plik IS NOT NULL AND kod = @kod ORDER BY nazwa;", conn))
                        {
                            SqlParameter par = new SqlParameter();
                            par.ParameterName = "@kod";
                            par.SqlDbType = System.Data.SqlDbType.Decimal;
                            par.Value = id;

                            cmd.Parameters.Add(par);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    List<string> adresy = new List<string>();

                                    string Comments = "";

                                    while (reader.Read())
                                    {
                                        if (reader.GetValue("uwagi") != null && reader.GetValue("uwagi").ToString().Length > 0)
                                            Comments = " [" + reader.GetValue("uwagi") + "] ";

                                        adresy.Add("<a href='download.aspx?s=" + reader.GetValue("id").ToString() + "'>" + reader.GetValue("nazwa") + "</a> " + Comments + " <br />");

                                        Comments = "";
                                    }

                                    if (adresy.Count > 0) AddLine("<br />Pliki do pobrania", "<br />" + String.Join("<br />", adresy));
                                }
                            }
                        }                        
                    }
                    break;
                #endregion

                #region Czasopisma
                case "magazine":
                    //AddLine("Typ", "Czasopismo");

                    using (SqlConnection conn = new SqlConnection(Settings.ColiberConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT c.*, w.* FROM czasop c LEFT OUTER JOIN wydawca_c w ON c.id_wydawcy = w.id_wydawcy WHERE kod=@kod; ", conn))
                        {
                            SqlParameter par = new SqlParameter();
                            par.ParameterName = "@kod";
                            par.SqlDbType = System.Data.SqlDbType.Decimal;
                            par.Value = id;
                            cmd.Parameters.Add(par);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reader.Read();

                                    AddLine("Tytuł", reader.GetValue("tytul"));
                                    this.Page.Title = reader.GetValue("tytul").ToString();

                                    if (!Settings.ShortDetails)
                                    {
                                        AddLine("Podtytuł", reader.GetValue("podtytul"));
                                        AddLine("Tytuł dod.", reader.GetValue("t_dodatk"));
                                        AddLine("Tytuł równ.", reader.GetValue("t_rownol"));
                                        AddLine("Redaktor", reader.GetValue("redaktor"));
                                        AddLine("Wydawca", reader.GetValue("nazwa_w") + " " + reader.GetValue("miasto_w"));
                                        AddLine("Instytucja sprawcza", reader.GetValue("nazwa_inst") + " " + reader.GetValue("siedziba"));
                                    }

                                    using (SqlConnection conn2 = new SqlConnection(Settings.ColiberConnectionString))
                                    {
                                        conn2.Open();

                                        using (SqlCommand cmd2 = new SqlCommand("SELECT RTRIM(LTRIM(ISNULL(syg,''))) As syg FROM cza_syg WHERE kod=@kod ORDER BY syg_expand; ", conn2))
                                        {
                                            cmd2.Parameters.AddWithValue("@kod", id);

                                            using (SqlDataReader reader2 = cmd2.ExecuteReader())
                                            {
                                                //if (reader2.HasRows)
                                                if (reader2.Read())
                                                {
                                                    using (SqlConnection conn3 = new SqlConnection(Settings.ColiberConnectionString))
                                                    {
                                                        conn3.Open();
                                                        do
                                                        {
                                                            //AddLine("Sygnatura", reader2.GetValue("syg"));
                                                            AddLine("Sygnatura", reader2.GetValue(0));
                                                            /*string query = " SELECT kod, id_volumes, numer_inw, czesci, rok1, " + 
                                                                           " CASE WHEN rok2 > 1900 THEN RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) + '/' + CAST(rok2 As varchar) ELSE RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) END As wolumin, " + 
                                                                           " LTRIM(RTRIM(volumin)) AS volumin FROM volumes " +
                                                                           " WHERE kod= " + id + " AND czesci != '' ORDER BY rok1, volumin; ";*/
                                                            /*string query = "  SELECT kod, id_volumes, numer_inw, czesci, rok1, " +
                                                                            " CASE WHEN volumin = '' " +
                                                                            "	THEN  CAST(rok1 As varchar) " +
                                                                            " ELSE " +
                                                                            "	RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) " +
                                                                            " END AS wolumin, volumin " +
                                                                            " FROM volumes  " +
                                                                            " WHERE kod= @kod AND czesci != '' ORDER BY rok1, volumin;";

                                                            using (SqlCommand cmdVolumes = new SqlCommand(query, conn3))
                                                            /*using (SqlCommand cmdVolumes = new SqlCommand("SELECT kod, id_volumes, numer_inw, CASE WHEN rok2 > 1900 THEN RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) + '/' + CAST(rok2 As varchar) ELSE RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) END As wolumin, volumin FROM volumes" +
                                                                                                          " WHERE kod= " + id + " AND RTRIM(LTRIM(syg)) like '" + reader2.GetValue("syg") + "'", conn3))*/
                                                            /*{
                                                                cmdVolumes.Parameters.AddWithValue("@kod", id);

                                                                using (SqlDataReader readerVolumes = cmdVolumes.ExecuteReader())
                                                                {
                                                                    if (readerVolumes.HasRows)
                                                                    {
                                                                        List<string> vols = new List<string>();

                                                                        do
                                                                        {
                                                                            if ((readerVolumes.GetValue("numer_inw") != null && readerVolumes.GetValue("numer_inw").ToString().Trim().Length > 0) || (readerVolumes.GetValue("wolumin") != null && readerVolumes.GetValue("wolumin").ToString().Trim().Length > 0))
                                                                                //vols.Add("<li>" + readerVolumes.GetValue("numer_inw") + " " + readerVolumes.GetValue("volumin") + ((Session["CanOrder"] as string).Trim().ToLower()  == "true" ? " <a href='AddToBasket.aspx?ordersMag={" + id + "}'>Zamów</a></li>" : ""));                                                                        
                                                                                vols.Add("<li>" + "Wolumin " + "<a href='ShowMagazines.aspx?kod=" + readerVolumes.GetValue("kod") + "&volumin=" + readerVolumes.GetValue("volumin").ToString().Trim() + "&rok=" + readerVolumes.GetValue("rok1") + "'>" + readerVolumes.GetValue("wolumin") + ";</a>" + " numery: " + readerVolumes.GetValue("czesci") + "</li>");
                                                                        }
                                                                        while (readerVolumes.Read());
                                                                        //
                                                                        //SCHOWANE WOLUMINY
                                                                        if (vols.Count > 0)
                                                                            //AddLine("Woluminy", "<ul>" + string.Join(string.Empty, vols.ToArray()) + "</ul>");
                                                                            AddLine("Zasoby", "<ul>" + string.Join(string.Empty, vols.ToArray()) + "</ul>");
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        while (reader2.Read());
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    if (!Settings.ShortDetails)
                                        AddLine("ISSN", reader.GetValue("issn"));
                                    //AddLine("Opis fiz.", reader.GetValue("format"));
                                    /*string wydanie = reader.GetValue("kraj_w").ToString();
                                    if (wydanie.Trim() != "0")
                                        AddLine("Wydanie", wydanie);*/

                                    /*string[] freqs = {"", "Dziennik", "Tygodnik", "Dwutygodnik", "Miesięcznik", "Dwumiesięcznik", "Kwartalnik", "Półrocznik", "Rocznik", "Nieregularne"};
                                    decimal freq = (decimal)reader.GetValue("id_czest");
                                    AddLine("Częstotliwość", freqs[Convert.ToInt32((decimal)reader.GetValue("id_czest"))]);
                                }
                            }
                        }

                        if (!Settings.ShortDetails)
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT kody, LTRIM(RTRIM(klucze)) AS klucze FROM cza_klu WHERE kod = @kod; ", conn))
                            {
                                SqlParameter par = new SqlParameter();
                                par.ParameterName = "@kod";
                                par.SqlDbType = System.Data.SqlDbType.Decimal;
                                par.Value = id;

                                cmd.Parameters.Add(par);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        string klucze = "";
                                        do
                                        {
                                            object klucz = reader.GetValue("klucze");
                                            if (klucz != null && klucz.ToString().Length > 0)
                                                klucze += (klucze.Length > 0 ? ", " : "") + "<a href='Search.aspx?key=" + klucz + "&path=magazines'>" + klucz + "</a>";
                                        }
                                        while (reader.Read());

                                        if (klucze.Length > 0) AddLine("Klucze", klucze);
                                    }
                                }
                            }
                        }

                        if (!Settings.ShortDetails)
                        {
                            //Pobieranie adresów URL
                            using (SqlCommand cmd = new SqlCommand("SELECT LTRIM(RTRIM(nazwa)) AS nazwa, LTRIM(RTRIM(URL)) AS URL, uwagi FROM documents WHERE rodzaj_zasobu = 2 AND URL IS NOT NULL AND kod = @kod ORDER BY nazwa;", conn))
                            {
                                SqlParameter par = new SqlParameter();
                                par.ParameterName = "@kod";
                                par.SqlDbType = System.Data.SqlDbType.Decimal;
                                par.Value = id;

                                cmd.Parameters.Add(par);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        List<string> adresy = new List<string>();

                                        string Comments = "";

                                        while (reader.Read())
                                        {
                                            if (reader.GetValue("uwagi") != null && reader.GetValue("uwagi").ToString().Length > 0)
                                                Comments = " [" + reader.GetValue("uwagi") + "] ";

                                            adresy.Add("<a href=" + reader.GetValue("URL").ToString() + " target=\"_blank\">" + reader.GetValue("nazwa") + "</a> " + Comments + " <br />");

                                            Comments = "";
                                        }
                                        if (adresy.Count > 0) AddLine("<br />Źródła on-line", "<br />" + String.Join("<br />", adresy));
                                        //if (adresy.Count > 0) AddLine("Źródła on-line", String.Join("<br />", adresy));
                                    }
                                }
                            }
                        }

                        if (!Settings.ShortDetails)
                        {
                            //Pobieranie informacji o plikach
                            using (SqlCommand cmd = new SqlCommand("SELECT id, LTRIM(RTRIM(nazwa)) AS nazwa, uwagi FROM documents WHERE rodzaj_zasobu = 2 AND plik IS NOT NULL AND kod = @kod ORDER BY nazwa;", conn))
                            {
                                SqlParameter par = new SqlParameter();
                                par.ParameterName = "@kod";
                                par.SqlDbType = System.Data.SqlDbType.Decimal;
                                par.Value = id;

                                cmd.Parameters.Add(par);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        List<string> adresy = new List<string>();

                                        string Comments = "";

                                        while (reader.Read())
                                        {
                                            if (reader.GetValue("uwagi") != null && reader.GetValue("uwagi").ToString().Length > 0)
                                                Comments = " [" + reader.GetValue("uwagi") + "] ";

                                            adresy.Add("<a href='download.aspx?s=" + reader.GetValue("id").ToString() + "'>" + reader.GetValue("nazwa") + "</a> " + Comments + " <br />");

                                            Comments = "";
                                        }
                                        if (adresy.Count > 0) AddLine("<br />Pliki do pobrania", "<br />" + String.Join("<br />", adresy));
                                        //if (adresy.Count > 0) AddLine("Pliki do pobrania", String.Join("<br />", adresy));
                                    }
                                }
                            }
                        }
                    }
                    break;
                #endregion

                #region Artykuły
                case "article":
                    //AddLine("Typ", "Artykuł");

                    using (SqlConnection conn = new SqlConnection(Settings.ColiberConnectionString))
                    {
                        conn.Open();
                        string CommandString = " SELECT ISNULL(LTRIM(RTRIM(tytul)),'') As tytul, ISNULL(LTRIM(RTRIM(syg)),'') As syg, ISNULL(LTRIM(RTRIM(strony)),'') As strony,ISNULL(opis,'') As opis, " +
                                               " ISNULL(tytul_a,'') As tytul_a,ISNULL(mapy,'') As mapy,ISNULL(wykresy,'') As wykresy,ISNULL(tabele,'') As tabele,ISNULL(jezyk,'') As jezyk, " +
                                               " LTRIM(RTRIM(miejsce_wyd)) AS miejsce_wyd, CASE WHEN LTRIM(RTRIM(data_wyd)) != '0' THEN CAST(data_wyd AS varchar) ELSE '' END AS data_wyd, " +
                                               " CASE WHEN LTRIM(RTRIM(rok1)) != 0 THEN CAST(rok1 AS varchar) ELSE '' END AS rok1, " + 
                                               " CASE WHEN rodzaj_zas = 'c' THEN 2 ELSE 1 END AS typ, " +
                                               //" CASE WHEN numer1 != '' AND numer1 != 0 THEN LTRIM(RTRIM(numer1)) ELSE '' END AS numer1," +
                                               //" CASE WHEN (numer1 != '' AND numer1 != 0) AND (numer2 != '' AND numer2 != 0) THEN '/' ELSE '' END AS slash," +
                                               //" CASE WHEN numer2 != '' AND numer2 != 0 THEN LTRIM(RTRIM(numer2)) ELSE '' END AS numer2" +
                                               " CASE WHEN numer1 != '' AND LTRIM(RTRIM(numer1)) != '0' THEN LTRIM(RTRIM(numer1)) ELSE '' END AS numer1," +
                                               " CASE WHEN (numer1 != '' AND LTRIM(RTRIM(numer1)) != '0') AND (numer2 != '' AND LTRIM(RTRIM(numer2)) != '0') THEN '/' ELSE '' END AS slash," +
                                               " CASE WHEN numer2 != '' AND LTRIM(RTRIM(numer2)) != '0' THEN LTRIM(RTRIM(numer2)) ELSE '' END AS numer2" +
                                               " FROM artykuly WHERE kod = @id; ";
                        
                        using (SqlCommand cmd = new SqlCommand(CommandString, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    AddLine("Tytuł artykułu", reader.GetValue("tytul_a"));
                                    this.Page.Title = reader.GetValue("tytul_a").ToString();

                                    using (SqlConnection conn2 = new SqlConnection(Settings.ColiberConnectionString))
                                    {
                                        conn2.Open();
                                        using (SqlCommand cmd2 = new SqlCommand("SELECT ISNULL(LTRIM(RTRIM(list_aut_a.imie)),'') As imie, ISNULL(LTRIM(RTRIM(list_aut_a.nazwisko)),'') As nazwisko FROM art_aut " +
                                                                                " JOIN list_aut_a ON list_aut_a.id_aut = art_aut.id_aut" +
                                                                                " WHERE art_aut.kod = @kod ORDER BY nazwisko, imie;", conn2))
                                        {
                                            cmd2.Parameters.AddWithValue("kod", id);

                                            using (SqlDataReader readerAut = cmd2.ExecuteReader())
                                            {
                                                if (readerAut.HasRows)
                                                {
                                                    string authors = "";
                                                    while (readerAut.Read())
                                                    {
                                                        string author = readerAut.GetString(0).Trim() + " " + readerAut.GetString(1).Trim();
                                                        if (author.Trim().Length > 0)
                                                            authors += (authors.Length > 0 ? ", " : "") + "<a href='Search.aspx?author=" + author + "&path=articles'>" + author + "</a>";
                                                    }

                                                    AddLine("Autor", authors);
                                                }
                                            }
                                        }
                                    }

                                    AddLine("Tytuł źródła publikacji", reader.GetValue("tytul"));

                                   // AddLine("Wolumin", reader.GetValue("volumin"));

                                    //miejsce i data wydania – w przypadku publikacji pochodzących z książek / numer i rok - w przypadku publikacji pochodzących z czasopism
                                    //typ == 1 dla książek
                                    //typ == 2 dla czasopism

                                    if (reader.GetValue("typ").ToString() == "1")
                                    {
                                        string Miejsce = reader.GetValue("miejsce_wyd").ToString();
                                        AddLine("Miejsce i data wydania", Miejsce + (Miejsce.Length > 0 ? "; " : "") + reader.GetValue("data_wyd"));
                                    }
                                    else if (reader.GetValue("typ").ToString() == "2")
                                    {
                                        AddLine("Numer i rok", reader.GetValue("numer1").ToString() + reader.GetValue("slash").ToString() + reader.GetValue("numer2").ToString() + ((reader.GetValue("numer1").ToString() + reader.GetValue("slash").ToString() + reader.GetValue("numer2").ToString()).Length > 0 ? "; " : "") + reader.GetValue("rok1").ToString());
                                       // AddLine("Numer1", reader.GetValue("numer1").ToString().Length.ToString());
                                       // AddLine("Numer2", reader.GetValue("numer2").ToString().Length.ToString());
                                    }

                                    string pages = reader.GetValue("strony").ToString().Trim();

                                    if (pages.Length > 0)
                                    {
                                        bool tables, maps, plots;
                                        string contains = "";
                                        tables = reader.GetBoolean(reader.GetOrdinal("tabele"));
                                        maps = reader.GetBoolean(reader.GetOrdinal("mapy"));
                                        plots = reader.GetBoolean(reader.GetOrdinal("wykresy"));

                                        if (tables || maps || plots)
                                        {
                                            contains += ", zawiera: ";
                                            if (tables) contains += "tabele";
                                            if (maps) contains += (tables ? ", " : "") + "mapy";
                                            if (plots) contains += (tables || maps ? ", " : "") + "wykresy";
                                        }

                                        AddLine("Strony", pages + contains);
                                        //AddLine("Sygnatura", reader.GetValue("syg"));
                                       
                                        /*using (SqlConnection conn2 = new SqlConnection(Settings.ColiberConnectionString))
                                        {
                                            conn2.Open();
                                            //using (SqlCommand cmd2 = new SqlCommand("SELECT ISNULL(dokumenty.adres_sciezka,'') As adres_sciezka FROM artykuly LEFT OUTER JOIN dokumenty ON artykuly.kod = dokumenty.kod WHERE artykuly.kod = " + id + " AND dokumenty.CzyAdres = 1", conn2))
                                            using (SqlCommand cmd2 = new SqlCommand("SELECT nazwa, URL FROM documents WHERE rodzaj_zasobu = 3 AND URL IS NOT NULL AND kod = " + id + ";", conn2))
                                            {
                                                using (SqlDataReader reader2 = cmd2.ExecuteReader())
                                                {
                                                    if (reader2.HasRows)
                                                    {
                                                        string sources = "";
                                                        while (reader2.Read())
                                                        {
                                                            string source = reader2.GetString(0).Trim();
                                                            if (source.Trim().Length > 0)
                                                                sources += (sources.Length > 0 ? ", " : "") + "<a href='" + source + "'>" + source + "</a>";
                                                        }

                                                        AddLine("Źródła online", sources);
                                                    }
                                                }
                                            }
                                        }*/

                                        /*AddLine("Streszczenie", reader.GetValue("opis"));
                                    }
                                }
                            }
                        }
                        using (SqlCommand cmd = new SqlCommand("SELECT kody, LTRIM(RTRIM(klucze)) AS klucze FROM art_klu WHERE kod = @kod;", conn))
                        {
                            SqlParameter par = new SqlParameter();
                            par.ParameterName = "@kod";
                            par.SqlDbType = System.Data.SqlDbType.Decimal;
                            par.Value = id;

                            cmd.Parameters.Add(par);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    string klucze = "";
                                    do
                                    {
                                        object klucz = reader.GetValue("klucze");
                                        if (klucz != null && klucz.ToString().Length > 0)
                                            klucze += (klucze.Length > 0 ? ", " : "") + "<a href='Search.aspx?key=" + klucz + "&path=articles'>" + klucz + "</a>";
                                    }
                                    while (reader.Read());

                                    if (klucze.Length > 0) AddLine("Klucze", klucze);
                                }
                            }
                        }

                        //Pobieranie adresów URL
                        using (SqlCommand cmd = new SqlCommand("SELECT LTRIM(RTRIM(nazwa)) AS nazwa, LTRIM(RTRIM(URL)) AS URL, uwagi FROM documents WHERE rodzaj_zasobu = 3 AND URL IS NOT NULL AND kod = @kod ORDER BY nazwa;", conn))
                        {
                            SqlParameter par = new SqlParameter();
                            par.ParameterName = "@kod";
                            par.SqlDbType = System.Data.SqlDbType.Decimal;
                            par.Value = id;

                            cmd.Parameters.Add(par);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    List<string> adresy = new List<string>();

                                    string Comments = "";

                                    while (reader.Read())
                                    {
                                        if (reader.GetValue("uwagi") != null && reader.GetValue("uwagi").ToString().Length > 0)
                                            Comments = " [" + reader.GetValue("uwagi") + "] ";

                                        adresy.Add("<a href=" + reader.GetValue("URL").ToString() + " target=\"_blank\">" + reader.GetValue("nazwa") + "</a> " + Comments + " <br />");

                                        Comments = "";
                                    }

                                    if (adresy.Count > 0) AddLine("<br />Źródla on-line", "<br />" + String.Join("<br />", adresy));
                                }
                            }
                        }

                        //Pobieranie informacji o plikach
                        using (SqlCommand cmd = new SqlCommand("SELECT id, LTRIM(RTRIM(nazwa)) AS nazwa, uwagi FROM documents WHERE rodzaj_zasobu = 3 AND plik IS NOT NULL AND kod = @kod ORDER BY nazwa;", conn))
                        {
                            SqlParameter par = new SqlParameter();
                            par.ParameterName = "@kod";
                            par.SqlDbType = System.Data.SqlDbType.Decimal;
                            par.Value = id;

                            cmd.Parameters.Add(par);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    List<string> adresy = new List<string>();

                                    string Comments = "";

                                    while (reader.Read())
                                    {
                                        if (reader.GetValue("uwagi") != null && reader.GetValue("uwagi").ToString().Length > 0)
                                            Comments = " [" + reader.GetValue("uwagi") + "] ";

                                        adresy.Add("<a href='download.aspx?s=" + reader.GetValue("id").ToString() + "'>" + reader.GetValue("nazwa") + "</a> " + Comments + " <br />");

                                        Comments = "";
                                    }

                                    if (adresy.Count > 0) AddLine("<br />Pliki do pobrania", "<br />" + String.Join("<br />", adresy));
                                    //if (adresy.Count > 0) AddLine("Pliki do pobrania", String.Join("<br />", adresy));
                                }
                            }
                        }
                    }

                    break;
                #endregion
            }

            lblContent.Text += "</table>";*/
#endregion

            if ((Session["CanOrder"] as string).Trim() == "false")
                AddToBasketButton.Visible = false;
        }

        [WebMethod]
        public static string GenerateContent(string type, string id, bool toPrint = false)
        {
            string pageContent = "<table class=\"table table-striped table-bordered table-hover table-condensed\">";
            switch (type.ToLower().Trim())
            {
                #region Książki
                case "book":
                case "books":
                    //AddLine("Typ", "Książka");

                    //SYGNATURA
                    SqlCommand SygCommand = new SqlCommand();
                    SygCommand.CommandText = "SELECT ISNULL(sygnat.syg,'') As syg, ISNULL(LTRIM(RTRIM(sygnat.numer_inw)),'') As numer_inw, CASE WHEN wypozycz = 1 THEN '(wypożyczona)' ELSE '' END AS stan, CASE WHEN wypozycz = 1 THEN '(wypożyczony)' ELSE '' END AS stan_num_inw FROM sygnat " +
                                                "INNER JOIN zasoby ON zasoby.id_zasob = sygnat.id_zasob " +
                                                "WHERE sygnat.kod = @id ORDER BY sort_order, syg_expand; ";

                    SygCommand.Parameters.AddWithValue("@id", id);

                    DataTable SygDt = CommonFunctions.ReadData(SygCommand, ref Settings.ColiberConnection);

                    for (int i = 0; i < SygDt.Rows.Count; i++)
                    {
                        if (Settings.ShowNumerInwentarzowy)
                            AddLine(Language.inventory, SygDt.Rows[i]["numer_inw"] + " <font color=\"red\">" + SygDt.Rows[i]["stan_num_inw"] + "</font>", ref pageContent);

                        AddLine(Language.signature, SygDt.Rows[i]["syg"] + " <font color=\"red\">" + SygDt.Rows[i]["stan"] + "</font> <br /> <br />", ref pageContent);
                    }
                    
                    SqlCommand BookCommand = new SqlCommand();
                    BookCommand.CommandText = " SELECT LTRIM(RTRIM(k.tytul_gl)) AS tytul_gl, wydawca1.miasto_w AS wyd1_miasto, wydawca1.nazwa_w AS wyd1_nazwa, wydawca2.miasto_w AS wyd2_miasto, wydawca2.nazwa_w AS wyd2_nazwa, rok_wyd, il_tomow, strony, s_ang, s_fran, s_niem, s_pol, s_ros, isbn, seria.tyt_serii, LTRIM(RTRIM(k.wydanie)) AS wydanie, " +
                                                " (SELECT TOP 1 LTRIM(RTRIM(t_dodatk)) AS t_dodatk FROM t_dodatk WHERE t_dodatk.kod = k.kod) AS t_dodatk, " +
                                                " (SELECT TOP 1 LTRIM(RTRIM(t_rownol)) AS t_rownol FROM t_rownol WHERE t_rownol.kod = k.kod) AS t_rownol, " + 
                                                " ((SELECT stuff((select ', ' + LTRIM(RTRIM(imie)) + ' ' + LTRIM(RTRIM(nazwisko)) FROM list_aut_k INNER JOIN ksiazki_autor_new ON ksiazki_autor_new.id_autor = list_aut_k.id_aut WHERE ksiazki_autor_new.id_ksiazka = k.kod ORDER BY rating for xml path('')),1,2,''))) as autor, " +
                                                //" ((SELECT stuff((select ', ' + LTRIM(RTRIM(imie)) + ' ' + LTRIM(RTRIM(nazwisko)) FROM list_aut_k INNER JOIN ksiazki_wautor_new ON ksiazki_wautor_new.id_wautor = list_aut_k.id_aut WHERE ksiazki_wautor_new.id_ksiazka = k.kod ORDER BY rating for xml path('')),1,2,''))) as wautor, " +
                                                " ((SELECT stuff((select ', ' + LTRIM(RTRIM(imie)) + ' ' + LTRIM(RTRIM(nazwisko)) + ISNULL(' - ' + (SELECT TOP 1 nazwa FROM odpowiedzialnosci_new INNER JOIN wautor_odpowiedzialnosc_new ON wautor_odpowiedzialnosc_new.id_odpowiedzialnosc = odpowiedzialnosci_new.id WHERE wautor_odpowiedzialnosc_new.id_ksiazki_wautor = ksiazki_wautor_new.id ), '') FROM list_aut_k INNER JOIN ksiazki_wautor_new ON ksiazki_wautor_new.id_wautor = list_aut_k.id_aut WHERE ksiazki_wautor_new.id_ksiazka = k.kod ORDER BY rating for xml path('')),1,2,''))) as wautor, " +
                                                " ((SELECT stuff((select ', ' + LTRIM(RTRIM(jezyk)) FROM jezyki INNER JOIN ksiazki_jezyki_new ON ksiazki_jezyki_new.id_jezyk = jezyki.id WHERE ksiazki_jezyki_new.id_ksiazki = k.kod ORDER BY jezyk for xml path('')),1,2,''))) as jezyki " +
                                                " FROM dbo.ksiazki_new k " +
                                                " OUTER APPLY (SELECT LTRIM(RTRIM(nazwa_w)) AS nazwa_w, LTRIM(RTRIM(miasto_w)) AS miasto_w FROM wydawca_k WHERE wydawca_k.id_wydawcy = k.id_wyd1) AS wydawca1 " +
                                                " OUTER APPLY (SELECT LTRIM(RTRIM(nazwa_w)) AS nazwa_w, LTRIM(RTRIM(miasto_w)) AS miasto_w FROM wydawca_k WHERE wydawca_k.id_wydawcy = k.id_wyd2) AS wydawca2 " +
                                                " OUTER APPLY (SELECT LTRIM(RTRIM(tyt_serii)) AS tyt_serii FROM ksi_ser LEFT OUTER JOIN serie ON ksi_ser.kody = serie.kody WHERE kod = k.kod) AS seria " + 
                                                " WHERE kod = @kod; ";

                    BookCommand.Parameters.AddWithValue("@kod", id);

                    DataTable BookDt = CommonFunctions.ReadData(BookCommand, ref Settings.ColiberConnection);

                    if (BookDt.Rows.Count > 0)
                    {
                        //TYTUŁY
                        AddLine(Language.title, BookDt.Rows[0]["tytul_gl"], ref pageContent);
                        title = BookDt.Rows[0]["tytul_gl"].ToString();

                        AddLine(Language.additionalTitle, BookDt.Rows[0]["t_dodatk"], ref pageContent);
                        AddLine(Language.paralellTitle, BookDt.Rows[0]["t_rownol"], ref pageContent);

                        // autorzy
                        string autor = BookDt.Rows[0]["autor"].ToString();

                        if(autor.Length > 0)
                            AddLine(Language.author, autor, ref pageContent);

                        // współautorzy
                        string wautor = BookDt.Rows[0]["wautor"].ToString();

                        if(wautor.Length > 0)
                            AddLine(Language.coAuthor, wautor, ref pageContent);

                        // wydanie
                        if (BookDt.Rows[0]["wydanie"].ToString().Trim().Length > 0)
                            AddLine(Language.edition, BookDt.Rows[0]["wydanie"], ref pageContent);

                        // wydawca
                        string miasto_w1 = BookDt.Rows[0]["wyd1_miasto"].ToString();
                        string miasto_w2 = BookDt.Rows[0]["wyd2_miasto"].ToString();

                        if (miasto_w1 == miasto_w2)
                            miasto_w2 = "";

                        if (miasto_w1.Length > 0 && miasto_w2.Length > 0)
                            miasto_w1 += ", ";

                        if (miasto_w1.Length > 0 || miasto_w2.Length > 0)
                            AddLine(Language.publicationPlace, miasto_w1 + miasto_w2, ref pageContent);

                        AddLine(Language.publisher, BookDt.Rows[0]["wyd1_nazwa"], ref pageContent);
                        AddLine(Language.publisher, BookDt.Rows[0]["wyd2_nazwa"], ref pageContent);

                        // rok_wydania
                        string data_wydania = BookDt.Rows[0]["rok_wyd"].ToString();

                        if (data_wydania != "0" && data_wydania.Length > 0)
                            AddLine(Language.yearOfPublishing, data_wydania, ref pageContent);

                        // języki
                        string jezyki = BookDt.Rows[0]["jezyki"].ToString();

                        if (jezyki.Length > 0)
                            jezyki = Language.languageOfText + ": " + jezyki + ";<br />";

                        string il_tomow = BookDt.Rows[0]["il_tomow"].ToString().Trim();

                        // ilość tomów
                        if (il_tomow.Length > 0)
                            il_tomow = Language.numberOfVolumes + ": " + il_tomow + "; <br />";

                        // strony
                        string strony = BookDt.Rows[0]["strony"].ToString().Trim();

                        if (strony.Length > 0)
                            strony = Language.pages + ": " + strony + ";<br />";

                        // streszczenia
                        string streszczenia = string.Join(", ", new string[] { Boolean.Parse(BookDt.Rows[0]["s_ang"].ToString()) ? "angielskie" : "", Boolean.Parse(BookDt.Rows[0]["s_fran"].ToString()) ? "francuskie" : "", Boolean.Parse(BookDt.Rows[0]["s_niem"].ToString()) ? "niemieckie" : "", Boolean.Parse(BookDt.Rows[0]["s_pol"].ToString()) ? "polskie" : "", Boolean.Parse(BookDt.Rows[0]["s_ros"].ToString()) ? "rosyjske" : "" }.Where(x => x.Length > 0));

                        if (streszczenia.Length > 0)
                            streszczenia = Language.summaries + ": " + streszczenia + ";<br />";

                        // opis fizyczny
                        AddLine(Language.physicalDescription, il_tomow + strony + jezyki + streszczenia, ref pageContent);

                        // ISBN
                        AddLine("ISBN", BookDt.Rows[0]["isbn"], ref pageContent);

                       //  seria
                        AddLine(Language.serie, BookDt.Rows[0]["tyt_serii"], ref pageContent);
                    }


                    // klucze
                    SqlCommand KeyCommand = new SqlCommand();
                    KeyCommand.CommandText = "SELECT klucze_k.kody, LTRIM(RTRIM(klucze_k.klucze)) AS klucze FROM ksi_klu INNER JOIN klucze_k ON klucze_k.kody = ksi_klu.kody WHERE kod = @kod ORDER BY klucze_k.klucze; ";
                    KeyCommand.Parameters.AddWithValue("@kod", id);
                           
                    DataTable KeyDt = CommonFunctions.ReadData(KeyCommand, ref Settings.ColiberConnection);

                    string kluczeK = "";

                    for (int i = 0; i < KeyDt.Rows.Count; i++)
                    {
                        string klucz = KeyDt.Rows[i]["klucze"].ToString();

                        if (klucz != null && klucz.ToString().Length > 0)
                        {
                            if(toPrint)
                                kluczeK += (kluczeK.Length > 0 ? ", " : "")  + klucz;  
                            else
                                kluczeK += (kluczeK.Length > 0 ? ", " : "") + "<a href='Search.aspx?key=" + klucz + "&path=books'>" + klucz + "</a>";  
                        }                                                   
                    }

                    if (kluczeK.Length > 0)
                        AddLine(Language.tags, kluczeK, ref pageContent);                                                                                             

                    // Pobieranie adresów URL
                    SqlCommand URLCommand = new SqlCommand();
                    URLCommand.CommandText = "SELECT LTRIM(RTRIM(nazwa)) AS nazwa, LTRIM(RTRIM(URL)) AS URL, LTRIM(RTRIM(uwagi)) AS uwagi FROM documents WHERE rodzaj_zasobu = 1 AND URL IS NOT NULL AND kod = @kod ORDER BY nazwa; ";
                    URLCommand.Parameters.AddWithValue("@kod", id);

                    List<string> adresyK = new List<string>();

                    DataTable URLDt = CommonFunctions.ReadData(URLCommand, ref Settings.ColiberConnection);
                        
                    string CommentsK = "";

                    for(int i = 0; i < URLDt.Rows.Count; i++)
                    {
                        CommentsK = URLDt.Rows[i]["uwagi"].ToString();

                        if (URLDt.Rows[i]["uwagi"].ToString().Length > 0)
                            CommentsK = " [" + URLDt.Rows[i]["uwagi"] + "] ";

                        adresyK.Add("<a href=" + URLDt.Rows[i]["URL"].ToString() + " target=\"_blank\">" + URLDt.Rows[i]["nazwa"] + "</a>" + CommentsK + " <br />");

                        CommentsK = "";
                    }

                    if (adresyK.Count > 0)
                        AddLine("<br />" + Language.sources + "on-line", "<br />" + String.Join("<br />", adresyK), ref pageContent);

                    // Pobieranie informacji o plikach
                    SqlCommand FileCommand = new SqlCommand();
                    FileCommand.CommandText = "SELECT id, LTRIM(RTRIM(nazwa)) AS nazwa, uwagi FROM documents WHERE rodzaj_zasobu = 1 AND plik IS NOT NULL AND kod = @kod ORDER BY nazwa; ";
                    FileCommand.Parameters.AddWithValue("@kod", id);

                    adresyK.Clear();

                    DataTable FileDt = CommonFunctions.ReadData(FileCommand, ref Settings.ColiberConnection);

                    CommentsK = "";

                    for (int i = 0; i < FileDt.Rows.Count; i++)
                    {
                        CommentsK = FileDt.Rows[i]["uwagi"].ToString();

                        if (FileDt.Rows[i]["uwagi"].ToString().Length > 0)
                            CommentsK = " [" + FileDt.Rows[i]["uwagi"] + "] ";

                        if (toPrint)
                            adresyK.Add(FileDt.Rows[i]["nazwa"] + CommentsK + " <br />");
                        else
                            adresyK.Add("<a href='download.aspx?s=" + FileDt.Rows[i]["id"].ToString() + "'>" + FileDt.Rows[i]["nazwa"] + "</a>" + CommentsK + " <br />");

                        CommentsK = "";
                    }

                    if (adresyK.Count > 0)
                        AddLine("<br />" + Language.filesToDL, "<br />" + String.Join("<br />", adresyK), ref pageContent);                                 
                    
                    break;
                #endregion

                #region Czasopisma
                case "magazine":
                case "magazines":
                    //AddLine("Typ", "Czasopismo");

                    SqlCommand MagazineCommand = new SqlCommand();
                    MagazineCommand.CommandText = " SELECT LTRIM(RTRIM(tytul)) AS tytul, LTRIM(RTRIM(podtytul)) AS podtytul, LTRIM(RTRIM(t_rownol)) AS t_rownol, LTRIM(RTRIM(t_dodatk)) AS t_dodatk, " +
                                                  " LTRIM(RTRIM(redaktor)) AS redaktor, LTRIM(RTRIM(nazwa_inst)) AS nazwa_inst, LTRIM(RTRIM(siedziba)) AS siedziba, LTRIM(RTRIM(issn)) AS issn, id_czest, " + 
                                                  " wydawca.nazwa_w, wydawca.miasto_w " +
                                                  " FROM dbo.czasop " +
                                                  " OUTER APPLY (SELECT LTRIM(RTRIM(nazwa_w)) AS nazwa_w, LTRIM(RTRIM(miasto_w)) AS miasto_w FROM dbo.wydawca_c WHERE dbo.wydawca_c.id_wydawcy = dbo.czasop.id_wydawcy) AS wydawca " +
                                                  " WHERE kod = @kod; ";

                    MagazineCommand.Parameters.AddWithValue("@kod", id);

                    DataTable MagazineDt = CommonFunctions.ReadData(MagazineCommand, ref Settings.ColiberConnection);

                    if(MagazineDt.Rows.Count > 0)
                    {
                        // tytuły
                        AddLine(Language.title, MagazineDt.Rows[0]["tytul"], ref pageContent);
                        title = MagazineDt.Rows[0]["tytul"].ToString();

                        if (!Settings.ShortDetails)
                        {
                            if(MagazineDt.Rows[0]["podtytul"].ToString().Length > 0)
                                AddLine(Language.subtitle, MagazineDt.Rows[0]["podtytul"], ref pageContent);

                            if (MagazineDt.Rows[0]["t_dodatk"].ToString().Length > 0)
                                AddLine(Language.additionalTitle, MagazineDt.Rows[0]["t_dodatk"], ref pageContent);

                            if (MagazineDt.Rows[0]["t_rownol"].ToString().Length > 0)
                                AddLine(Language.paralellTitle, MagazineDt.Rows[0]["t_rownol"], ref pageContent);

                            // redaktor
                            if (MagazineDt.Rows[0]["redaktor"].ToString().Length > 0)
                                AddLine(Language.editor, MagazineDt.Rows[0]["redaktor"], ref pageContent);

                            // wydawca
                            if (MagazineDt.Rows[0]["nazwa_w"].ToString().Length > 0 || MagazineDt.Rows[0]["miasto_w"].ToString().Length > 0)
                                AddLine(Language.publisher, MagazineDt.Rows[0]["nazwa_w"] + " " +MagazineDt.Rows[0]["miasto_w"], ref pageContent);

                            if (MagazineDt.Rows[0]["nazwa_inst"].ToString().Length > 0 || MagazineDt.Rows[0]["siedziba"].ToString().Length > 0)
                            // instytucja sprawcza
                                AddLine(Language.institution, MagazineDt.Rows[0]["nazwa_inst"] + " " + MagazineDt.Rows[0]["siedziba"], ref pageContent);
                        }

                        // sygnatura
                        SqlCommand MagazineSygCommand = new SqlCommand();
                        MagazineSygCommand.CommandText = "SELECT RTRIM(LTRIM(ISNULL(syg,''))) AS syg, id_cza_syg FROM cza_syg WHERE kod = @kod ORDER BY syg_expand; ";
                        MagazineSygCommand.Parameters.AddWithValue("@kod", id);

                        DataTable MagazineSygDt = CommonFunctions.ReadData(MagazineSygCommand, ref Settings.ColiberConnection);

                        SqlCommand VolumesCommand = new SqlCommand();
                        VolumesCommand.CommandText = "SELECT id_volumes, LTRIM(RTRIM(czesci)) AS czesci, rok1, " +
                                                     " CASE WHEN LTRIM(RTRIM(volumin)) = '' " +
                                                     "	THEN CAST(rok1 As varchar) " +
                                                     " ELSE " +
                                                     "	RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) " +
                                                     " END AS wolumin, LTRIM(RTRIM(volumin)) AS volumin " +
                                                     " FROM volumes  " +
                                                     //" WHERE kod = @kod AND syg = @syg ORDER BY rok1, dbo.Expand(volumin, 6, 60); ";
                                                     " WHERE czesci != '' AND kod = @kod AND id_cza_syg = @id_cza_syg ORDER BY rok1, dbo.Expand(volumin, 6, 60); ";

                        VolumesCommand.Parameters.AddWithValue("@kod", id);
                        VolumesCommand.Parameters.AddWithValue("@id_cza_syg", "");

                        DataTable VolumesDt;

                        List<string> vols = new List<string>();

                        for (int i = 0; i < MagazineSygDt.Rows.Count; i++)
                        {
                            AddLine(Language.signature, MagazineSygDt.Rows[i]["syg"], ref pageContent);

                            //VolumesCommand.Parameters["@syg"].Value = MagazineSygDt.Rows[i]["syg"];
                            VolumesCommand.Parameters["@id_cza_syg"].Value = MagazineSygDt.Rows[i]["id_cza_syg"];

                            VolumesDt = CommonFunctions.ReadData(VolumesCommand, ref Settings.ColiberConnection);

                            for (int j = 0; j < VolumesDt.Rows.Count; j++)
                            {
                                //if (!string.IsNullOrEmpty(VolumesDt.Rows[j]["wolumin"].ToString().Trim()))                                    
                                    //vols.Add("<li>" + "Wolumin " + "<a href='ShowMagazines.aspx?kod=" + id + "&volumin=" + VolumesDt.Rows[j]["volumin"].ToString().Trim() + "&rok=" + VolumesDt.Rows[j]["rok1"] + "'>" + VolumesDt.Rows[j]["wolumin"] + ";</a>" + " numery: " + VolumesDt.Rows[j]["czesci"] + "</li>");
                                //vols.Add("<li>" + "Wolumin " + "<a href='ShowMagazines.aspx?kod=" + id + "&volumin=" + VolumesDt.Rows[j]["id_volumes"].ToString().Trim() + "'>" + VolumesDt.Rows[j]["wolumin"] + ";</a>" + " numery: " + VolumesDt.Rows[j]["czesci"] + "</li>");
                                
                                vols.Add("<li>" + Language.volumin + " <a target='_blank' href='ShowMagazines.aspx?kod=" + id + "&volumin=" + VolumesDt.Rows[j]["id_volumes"].ToString().Trim() + "'>" + VolumesDt.Rows[j]["wolumin"] + ";</a>" + " " + Language.numbers + ": " + VolumesDt.Rows[j]["czesci"] + "</li>");
                                //Temp += "<td><a onclick=\"window.open('Details.aspx?id=" + Dt.Rows[i]["kod"].ToString() + "&type=" + Dt.Rows[i]["type"].ToString() + "','','width=1000,height=800,scrollbars=yes');return false;\" href=\"Details.aspx?id=" + Dt.Rows[i]["kod"].ToString() + "&type=" + Dt.Rows[i]["type"].ToString() + "\" >" + Dt.Rows[i]["tytul"].ToString() + "</a></td>";
                            }
                            
                            if (vols.Count > 0)                                
                                AddLine(Language.resources, "<ul>" + string.Join(string.Empty, vols.ToArray()) + "</ul>", ref pageContent);

                            vols.Clear();
                        }


                       /* string query = "  SELECT kod, id_volumes, numer_inw, czesci, rok1, " +
                                            " CASE WHEN volumin = '' " +
                                            "	THEN  CAST(rok1 As varchar) " +
                                            " ELSE " +
                                            "	RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) " +
                                            " END AS wolumin, volumin " +
                                            " FROM volumes  " +
                                            " WHERE kod = @kod AND czesci != '' AND syg = @syg ORDER BY rok1, volumin; ";
                                                using (SqlCommand cmdVolumes = new SqlCommand(query, conn3))
                                                /*using (SqlCommand cmdVolumes = new SqlCommand("SELECT kod, id_volumes, numer_inw, CASE WHEN rok2 > 1900 THEN RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) + '/' + CAST(rok2 As varchar) ELSE RTRIM(LTRIM(volumin)) + '/' + CAST(rok1 As varchar) END As wolumin, volumin FROM volumes" +
                                                                                              " WHERE kod= " + id + " AND RTRIM(LTRIM(syg)) like '" + reader2.GetValue("syg") + "'", conn3))*/
                                                /*{
                                                    cmdVolumes.Parameters.AddWithValue("@kod", id);

                                                    using (SqlDataReader readerVolumes = cmdVolumes.ExecuteReader())
                                                    {
                                                        if (readerVolumes.HasRows)
                                                        {
                                                            List<string> vols = new List<string>();

                                                            do
                                                            {
                                                                if ((readerVolumes.GetValue("numer_inw") != null && readerVolumes.GetValue("numer_inw").ToString().Trim().Length > 0) || (readerVolumes.GetValue("wolumin") != null && readerVolumes.GetValue("wolumin").ToString().Trim().Length > 0))
                                                                    //vols.Add("<li>" + readerVolumes.GetValue("numer_inw") + " " + readerVolumes.GetValue("volumin") + ((Session["CanOrder"] as string).Trim().ToLower()  == "true" ? " <a href='AddToBasket.aspx?ordersMag={" + id + "}'>Zamów</a></li>" : ""));                                                                        
                                                                    vols.Add("<li>" + "Wolumin " + "<a href='ShowMagazines.aspx?kod=" + readerVolumes.GetValue("kod") + "&volumin=" + readerVolumes.GetValue("volumin").ToString().Trim() + "&rok=" + readerVolumes.GetValue("rok1") + "'>" + readerVolumes.GetValue("wolumin") + ";</a>" + " numery: " + readerVolumes.GetValue("czesci") + "</li>");
                                                            }
                                                            while (readerVolumes.Read());
                                                            //
                                                            //SCHOWANE WOLUMINY
                                                            if (vols.Count > 0)
                                                                //AddLine("Woluminy", "<ul>" + string.Join(string.Empty, vols.ToArray()) + "</ul>");
                                                                AddLine("Zasoby", "<ul>" + string.Join(string.Empty, vols.ToArray()) + "</ul>", ref pageContent);
                                                        }
                                                    }
                                                }*/
                                           
                                   
                            
                        

                        if (!Settings.ShortDetails)
                            AddLine("ISSN", MagazineDt.Rows[0]["issn"], ref pageContent);
                        //AddLine("Opis fiz.", reader.GetValue("format"));
                        /*string wydanie = reader.GetValue("kraj_w").ToString();
                        if (wydanie.Trim() != "0")
                            AddLine("Wydanie", wydanie);*/

                        string[] freqs = { "", Language.daily, Language.weekly, Language.biweekly, Language.monthly, Language.bimonthly, Language.quarterly, Language.halfYearly, Language.yearly, Language.irregular };
                        int freq = 0;
                        Int32.TryParse(MagazineDt.Rows[0]["id_czest"].ToString(), out freq);

                        AddLine(Language.frequency, freqs[freq], ref pageContent);
                    }
                        

                        if (!Settings.ShortDetails)
                        {
                            // klucze
                            SqlCommand MagazineKeyCommand = new SqlCommand();
                            MagazineKeyCommand.CommandText = "SELECT klucze_c.kody, LTRIM(RTRIM(klucze_c.klucze)) AS klucze FROM cza_klu INNER JOIN klucze_c ON klucze_c.kody = cza_klu.kody WHERE kod = @kod ORDER BY klucze_c.klucze; ";
                            MagazineKeyCommand.Parameters.AddWithValue("@kod", id);

                            DataTable MagazineKeyDt = CommonFunctions.ReadData(MagazineKeyCommand, ref Settings.ColiberConnection);

                            string kluczeM = "";

                            for (int i = 0; i < MagazineKeyDt.Rows.Count; i++)
                            {
                                string klucz = MagazineKeyDt.Rows[i]["klucze"].ToString();

                                if (klucz != null && klucz.ToString().Length > 0)
                                {
                                    if (toPrint)
                                        kluczeM += (kluczeM.Length > 0 ? ", " : "") + klucz;
                                    else
                                        kluczeM += (kluczeM.Length > 0 ? ", " : "") + "<a href='Search.aspx?key=" + klucz + "&path=magazines'>" + klucz + "</a>";
                                }                                    
                            }

                            if (kluczeM.Length > 0)
                                AddLine(Language.tags, kluczeM, ref pageContent); 
                        }

                        if (!Settings.ShortDetails)
                        {
                            // Pobieranie adresów URL
                            SqlCommand MagazineURLCommand = new SqlCommand();
                            MagazineURLCommand.CommandText = "SELECT LTRIM(RTRIM(nazwa)) AS nazwa, LTRIM(RTRIM(URL)) AS URL, LTRIM(RTRIM(uwagi)) AS uwagi FROM documents WHERE rodzaj_zasobu = 2 AND URL IS NOT NULL AND kod = @kod ORDER BY nazwa; ";
                            MagazineURLCommand.Parameters.AddWithValue("@kod", id);

                            List<string> adresyM = new List<string>();

                            DataTable MagazineURLDt = CommonFunctions.ReadData(MagazineURLCommand, ref Settings.ColiberConnection);

                            string CommentsM = "";

                            for (int i = 0; i < MagazineURLDt.Rows.Count; i++)
                            {
                                CommentsM = MagazineURLDt.Rows[i]["uwagi"].ToString();

                                if (MagazineURLDt.Rows[i]["uwagi"].ToString().Length > 0)
                                    CommentsM = " [" + MagazineURLDt.Rows[i]["uwagi"] + "] ";

                                adresyM.Add("<a href=" + MagazineURLDt.Rows[i]["URL"].ToString() + " target=\"_blank\">" + MagazineURLDt.Rows[i]["nazwa"] + "</a>" + CommentsM + " <br />");

                                CommentsM = "";
                            }

                            if (adresyM.Count > 0)
                                AddLine("<br />" + Language.sources + " on-line", "<br />" + String.Join("<br />", adresyM), ref pageContent);
                        }

                        if (!Settings.ShortDetails)
                        {
                            // Pobieranie informacji o plikach
                            SqlCommand MagazineFileCommand = new SqlCommand();
                            MagazineFileCommand.CommandText = "SELECT id, LTRIM(RTRIM(nazwa)) AS nazwa, uwagi FROM documents WHERE rodzaj_zasobu = 2 AND plik IS NOT NULL AND kod = @kod ORDER BY nazwa; ";
                            MagazineFileCommand.Parameters.AddWithValue("@kod", id);

                            DataTable MagazineFileDt = CommonFunctions.ReadData(MagazineFileCommand, ref Settings.ColiberConnection);

                            string CommentsM = "";
                            List<string> adresyM = new List<string>();

                            for (int i = 0; i < MagazineFileDt.Rows.Count; i++)
                            {
                                CommentsM = MagazineFileDt.Rows[i]["uwagi"].ToString();

                                if (MagazineFileDt.Rows[i]["uwagi"].ToString().Length > 0)
                                    CommentsM = " [" + MagazineFileDt.Rows[i]["uwagi"] + "] ";

                                if (toPrint)
                                    adresyM.Add(MagazineFileDt.Rows[i]["nazwa"] + CommentsM + " <br />");
                                else
                                    adresyM.Add("<a href='download.aspx?s=" + MagazineFileDt.Rows[i]["id"].ToString() + "'>" + MagazineFileDt.Rows[i]["nazwa"] + "</a>" + CommentsM + " <br />");

                                CommentsM = "";
                            }

                            if (adresyM.Count > 0)
                                AddLine("<br />" + Language.filesToDL, "<br />" + String.Join("<br />", adresyM), ref pageContent);
                        }
                    
                    break;
                #endregion

                #region Artykuły
                case "article":
                case "articles":
                    //AddLine("Typ", "Artykuł");

                    SqlCommand ArticleCommand = new SqlCommand();

                    ArticleCommand.CommandText =   " SELECT ISNULL(LTRIM(RTRIM(tytul)),'') As tytul, ISNULL(LTRIM(RTRIM(syg)),'') As syg, ISNULL(LTRIM(RTRIM(strony)),'') As strony, ISNULL(opis,'') As opis, " +
                                                   " ISNULL(tytul_a,'') As tytul_a, mapy, wykresy, tabele, ISNULL(jezyk,'') As jezyk, s_pol, s_ang, s_niem, s_fran, s_ros, " +
                                                   " LTRIM(RTRIM(miejsce_wyd)) AS miejsce_wyd, CASE WHEN LTRIM(RTRIM(data_wyd)) != '0' AND data_wyd IS NOT NULL THEN CAST(data_wyd AS varchar) ELSE '' END AS data_wyd, " +
                                                   " CASE WHEN LTRIM(RTRIM(rok1)) != 0 THEN CAST(rok1 AS varchar) ELSE '' END AS rok1, " +
                                                   " CASE WHEN rodzaj_zas = 'c' THEN 2 ELSE 1 END AS typ, " +
                                                   " CASE WHEN numer1 != '' AND LTRIM(RTRIM(numer1)) != '0' THEN LTRIM(RTRIM(numer1)) ELSE '' END AS numer1, " +
                                                   " CASE WHEN (numer1 != '' AND LTRIM(RTRIM(numer1)) != '0') AND (numer2 != '' AND LTRIM(RTRIM(numer2)) != '0') THEN '/' ELSE '' END AS slash, " +
                                                   " CASE WHEN numer2 != '' AND LTRIM(RTRIM(numer2)) != '0' THEN LTRIM(RTRIM(numer2)) ELSE '' END AS numer2, " +
                                                   " ((SELECT stuff((select ', ' + LTRIM(RTRIM(imie)) + ' ' + LTRIM(RTRIM(nazwisko)) FROM list_aut_a INNER JOIN art_aut ON art_aut.id_aut = list_aut_a.id_aut WHERE art_aut.kod = artykuly.kod ORDER BY nazwisko, imie for xml path('')),1,2,''))) as autor " +
                                                   " FROM artykuly WHERE kod = @id; ";

                    ArticleCommand.Parameters.AddWithValue("@id", id);


                    DataTable ArticleDt = CommonFunctions.ReadData(ArticleCommand, ref Settings.ColiberConnection);

                    if (ArticleDt.Rows.Count > 0)
                    {
                        // tytuł artykułu
                        AddLine(Language.articleTitle, ArticleDt.Rows[0]["tytul_a"], ref pageContent);
                        title = ArticleDt.Rows[0]["tytul_a"].ToString();
                                                           
                        // autor
                        string author = ArticleDt.Rows[0]["autor"].ToString();

                        /*if (author.Trim().Length > 0)
                            authors += (authors.Length > 0 ? ", " : "") + "<a href='Search.aspx?author=" + author + "&path=articles'>" + author + "</a>";*/

                        if(author.Length > 0)
                            AddLine(Language.author, author, ref pageContent);                                                  

                        // tytuł źródła publikacji
                        AddLine(Language.sourceTitle, ArticleDt.Rows[0]["tytul"], ref pageContent);

                        //miejsce i data wydania – w przypadku publikacji pochodzących z książek / numer i rok - w przypadku publikacji pochodzących z czasopism
                        //typ == 1 dla książek
                        //typ == 2 dla czasopism
                        
                        if (ArticleDt.Rows[0]["typ"].ToString() == "1")
                        {
                            string Miejsce = ArticleDt.Rows[0]["miejsce_wyd"].ToString();
                            AddLine(Language.publicationPlaceDate, Miejsce + (Miejsce.Length > 0 ? "; " : "") + ArticleDt.Rows[0]["data_wyd"], ref pageContent);
                        }
                        else if (ArticleDt.Rows[0]["typ"].ToString() == "2")
                        {
                            AddLine(Language.numberYear, ArticleDt.Rows[0]["numer1"].ToString() + ArticleDt.Rows[0]["slash"].ToString() + ArticleDt.Rows[0]["numer2"].ToString() + ((ArticleDt.Rows[0]["numer1"].ToString() + ArticleDt.Rows[0]["slash"].ToString() + ArticleDt.Rows[0]["numer2"].ToString()).Length > 0 ? "; " : "") + ArticleDt.Rows[0]["rok1"].ToString(), ref pageContent);
                        }

                        // języki
                        string jezyki = ArticleDt.Rows[0]["jezyk"].ToString();

                        if (jezyki.Trim().Length > 0)
                            AddLine(Language.languageOfText, jezyki + ";<br />", ref pageContent);

                        // strony
                        string pages = ArticleDt.Rows[0]["strony"].ToString();

                        bool tables, maps, plots;
                        string contains = "";
                        Boolean.TryParse(ArticleDt.Rows[0]["tabele"].ToString(), out tables);
                        Boolean.TryParse(ArticleDt.Rows[0]["mapy"].ToString(), out maps);
                        Boolean.TryParse(ArticleDt.Rows[0]["wykresy"].ToString(), out plots);

                        if (tables || maps || plots)
                        {
                            if(pages.Length > 0)
                                contains = ", " + Language.contains + ": ";
                            else
                                contains = Language.contains + ": ";

                            if (tables) contains += "tabele";
                            if (maps) contains += (tables ? ", " : "") + "mapy";
                            if (plots) contains += (tables || maps ? ", " : "") + "wykresy";
                        }

                        if(pages.Length > 0 || contains.Length > 0)
                            AddLine(Language.pages, pages + contains, ref pageContent);

                        // streszczenie
                        if(ArticleDt.Rows[0]["opis"].ToString().Length > 0)
                            AddLine(Language.summary, ArticleDt.Rows[0]["opis"], ref pageContent);

                        // streszczenia
                        string streszczenia = string.Join(", ", new string[] { Boolean.Parse(ArticleDt.Rows[0]["s_ang"].ToString()) ? "angielskie" : "", Boolean.Parse(ArticleDt.Rows[0]["s_fran"].ToString()) ? "francuskie" : "", Boolean.Parse(ArticleDt.Rows[0]["s_niem"].ToString()) ? "niemieckie" : "", Boolean.Parse(ArticleDt.Rows[0]["s_pol"].ToString()) ? "polskie" : "", Boolean.Parse(ArticleDt.Rows[0]["s_ros"].ToString()) ? "rosyjske" : "" }.Where(x => x.Length > 0));

                        if (streszczenia.Length > 0)
                            AddLine(Language.summaries, streszczenia + ";<br />", ref pageContent);
                    }

                    // klucze
                    SqlCommand ArticleKeyCommand = new SqlCommand();
                    ArticleKeyCommand.CommandText = "SELECT klucze_a.kody, LTRIM(RTRIM(klucze_a.klucze)) AS klucze FROM art_klu INNER JOIN klucze_a ON klucze_a.kody = art_klu.kody WHERE kod = @kod ORDER BY klucze_a.klucze; ";
                    ArticleKeyCommand.Parameters.AddWithValue("@kod", id);

                    DataTable ArticleKeyDt = CommonFunctions.ReadData(ArticleKeyCommand, ref Settings.ColiberConnection);

                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "myscript", "alert('" + Settings.UserID + "')", true);

                    string ArticleKey = "";

                    for (int i = 0; i < ArticleKeyDt.Rows.Count; i++)
                    {
                        string klucz = ArticleKeyDt.Rows[i]["klucze"].ToString();

                        if (klucz.ToString().Length > 0)
                            ArticleKey += (ArticleKey.Length > 0 ? ", " : "") + "<a href='Search.aspx?key=" + klucz + "&path=articles'>" + klucz + "</a>";
                    }

                    if (ArticleKey.Length > 0)
                        AddLine(Language.keys, ArticleKey, ref pageContent);

                    // Pobieranie adresów URL
                    SqlCommand ArticleURLCommand = new SqlCommand();
                    ArticleURLCommand.CommandText = "SELECT LTRIM(RTRIM(nazwa)) AS nazwa, LTRIM(RTRIM(URL)) AS URL, LTRIM(RTRIM(uwagi)) AS uwagi FROM documents WHERE rodzaj_zasobu = 3 AND URL IS NOT NULL AND kod = @kod ORDER BY nazwa; ";
                    ArticleURLCommand.Parameters.AddWithValue("@kod", id);

                    List<string> adresyA = new List<string>();

                    DataTable ArticleURLDt = CommonFunctions.ReadData(ArticleURLCommand, ref Settings.ColiberConnection);

                    string CommentsA = "";

                    for (int i = 0; i < ArticleURLDt.Rows.Count; i++)
                    {
                        CommentsA = ArticleURLDt.Rows[i]["uwagi"].ToString();

                        if (ArticleURLDt.Rows[i]["uwagi"].ToString().Length > 0)
                            CommentsA = " [" + ArticleURLDt.Rows[i]["uwagi"] + "] ";

                        adresyA.Add("<a href=" + ArticleURLDt.Rows[i]["URL"].ToString() + " target=\"_blank\">" + ArticleURLDt.Rows[i]["nazwa"] + "</a>" + CommentsA + " <br />");

                        CommentsA = "";
                    }

                    if (adresyA.Count > 0)
                        AddLine("<br />" + Language.sources + " on-line", "<br />" + String.Join("<br />", adresyA), ref pageContent);


                    // Pobieranie informacji o plikach
                    SqlCommand ArticleFileCommand = new SqlCommand();
                    ArticleFileCommand.CommandText = "SELECT id, LTRIM(RTRIM(nazwa)) AS nazwa, LTRIM(RTRIM(uwagi)) AS uwagi FROM documents WHERE rodzaj_zasobu = 3 AND plik IS NOT NULL AND kod = @kod ORDER BY nazwa; ";
                    ArticleFileCommand.Parameters.AddWithValue("@kod", id);

                    adresyA.Clear();

                    DataTable ArticleFileDt = CommonFunctions.ReadData(ArticleFileCommand, ref Settings.ColiberConnection);

                    CommentsA = "";

                    for (int i = 0; i < ArticleFileDt.Rows.Count; i++)
                    {
                        CommentsA = ArticleFileDt.Rows[i]["uwagi"].ToString();

                        if (ArticleFileDt.Rows[i]["uwagi"].ToString().Length > 0)
                            CommentsA = " [" + ArticleFileDt.Rows[i]["uwagi"] + "] ";

                        adresyA.Add("<a href='download.aspx?s=" + ArticleFileDt.Rows[i]["id"].ToString() + "'>" + ArticleFileDt.Rows[i]["nazwa"] + "</a>" + CommentsA + " <br />");

                        CommentsA = "";
                    }

                    if (adresyA.Count > 0)
                        AddLine("<br />" + Language.filesToDL, "<br />" + String.Join("<br />", adresyA), ref pageContent);
                    
                    break;
                #endregion

                #region Normy
                case "normy":
                    //AddLine("Typ", "Normy", ref pageContent);
                    SqlCommand NormyCommand = new SqlCommand();

                    NormyCommand.CommandText = " SELECT ISNULL(LTRIM(RTRIM(tytul)),'') As tytul,  " +
                                                   " Nr_normy, " +
                                                   " data_ust, " +
                                                   " data_pub, " +
                                                   " Wydawcy, " +
                                                   " data_uniew, " +
                                                   " klucze, " +
                                                   " Format, " +
                                                   " StatusN, " +
                                                   " Isbn, " +
                                                   " Wycofana, " +
                                                   " Uwagi " +
                                                   " FROM Normy WHERE id_norma = @id; ";

                    NormyCommand.Parameters.AddWithValue("@id", id);


                    DataTable NormyDt = CommonFunctions.ReadData(NormyCommand, ref Settings.ColiberConnection);

                    if (NormyDt.Rows.Count > 0)
                    {
                        // numer
                        AddLine("Numer", NormyDt.Rows[0]["nr_normy"], ref pageContent);
                        // tytuł 
                        AddLine("Tytuł", NormyDt.Rows[0]["tytul"], ref pageContent);
                        AddLine("Data publikacji", CommonFunctions.DTOC(NormyDt.Rows[0]["data_pub"]), ref pageContent);
                        AddLine("Status", NormyDt.Rows[0]["StatusN"], ref pageContent);
                        AddLine("Wydawcy", NormyDt.Rows[0]["Wydawcy"], ref pageContent);
                        AddLine("Data wycofania", CommonFunctions.DTOC(NormyDt.Rows[0]["wycofana"]), ref pageContent);
                        AddLine("Data unieważnienia", CommonFunctions.DTOC(NormyDt.Rows[0]["data_uniew"]), ref pageContent);
                        AddLine("Format", NormyDt.Rows[0]["format"], ref pageContent);
                        AddLine("ISBN", NormyDt.Rows[0]["isbn"], ref pageContent);
                        AddLine("Słowa kluczowe", NormyDt.Rows[0]["klucze"], ref pageContent);
                        AddLine("Uwagi", NormyDt.Rows[0]["uwagi"], ref pageContent, true);
                    }
                    break;

                #endregion
            }

            pageContent += "</table>";

            return pageContent;
        }       

        protected static void AddLine(object key, object value, ref string pageContent, bool lChk = false)
        {
            if (value != null && value.ToString().Trim().Length > 0)
            {
                bool lMult = false;
                if (lChk)
                {
                    string cText = value.ToString();
                    foreach (char c in cText)
                    {
                        if (c == (char)10 || c == (char)13)
                        {
                            lMult = true;
                            break;
                        }
                    }
                }
                //int iLines = value.ToString().TakeWhile(c => c == (char)10 || c == (char)13).Count();
                if  (lMult)
                    //pageContent += "<tr><td valign='top' width='150px'><b>" + key + ":</b></td><td><pre>" + value + "</pre></td></tr>";
                    pageContent += "<tr><td valign='top' width='150px'><b>" + key + ":</b></td><td style='white-space:pre-wrap;word-wrap:break-word'>" + value + "</td></tr>";
                else
                    pageContent += "<tr><td valign='top' width='150px'><b>" + key + ":</b></td><td>" + value + "</td></tr>";
            }
        }

        protected void AddToBasketButton_Click(object sender, EventArgs e)
        {
            if ((Session["CanOrder"] as string).Trim().ToLower() == "true")
                Response.Redirect("AddToBasket.aspx?orders={" + id + "}");

            //Search.GenerateDOC(type, id.ToString());
        }
    }
}