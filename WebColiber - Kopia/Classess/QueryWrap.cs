using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace WebColiber
{
    public static class QueryWrap
    {
        #region Books
        
        //  string[] = wartość, typ, operator
        /*public static SqlCommand getBooksQuery(List<string[]> Values, List<string[]> ANDValues, int StartIndex, int Count)
        {            
            SqlCommand Command = new SqlCommand();

            Command.CommandText = "DECLARE @ResultOrder TABLE  " + Environment.NewLine +
                                  "(     OrderID int identity(1,1) not null primary key clustered," + Environment.NewLine +
                                  "      ResultID int," + Environment.NewLine +
                                  "      tytul varchar(1024)    " + Environment.NewLine +
                                  ");" + Environment.NewLine;

            Command.CommandText += "; with tab1 AS ( " + Environment.NewLine;
            Command.CommandText += " SELECT DISTINCT ksiazki_new.kod, " + Environment.NewLine +
                                   " LTRIM(RTRIM(tytul_gl)) AS tytul " + Environment.NewLine;
            Command.CommandText += " FROM ksiazki_new " +
                                   " INNER JOIN sygnat ON sygnat.kod = ksiazki_new.kod " + Environment.NewLine +
                                   " WHERE LEN(ISNULL(tytul_gl,'')) > 0 " + Environment.NewLine;

            string[] temp;
            string Phrase;
            string Type;
            string Operator;

            if (Values.Count > 0)
                Command.CommandText += " AND (";

            for (int i = 0; i < Values.Count; i++)
            {
                temp = Values[i];

                Phrase = temp[0].Trim();
                Phrase = string.Join(" AND", Phrase.Split(' ').Select(x => "\"" + x + "*\""));
                Type = temp[1].Trim().ToLower();
                Operator = temp[2].Trim();

                switch (Type)
                {
                    //case "authorslastname": Command.CommandText += "(EXISTS (SELECT 1 FROM list_aut_k INNER JOIN ksiazki_autor_new ON ksiazki_autor_new.id_autor = list_aut_k.id_aut AND ksiazki_autor_new.id_ksiazka = ksiazki_new.kod WHERE LTRIM(RTRIM(UPPER(nazwisko))) + ' ' + LTRIM(RTRIM(UPPER(imie))) like '%' + @fraza" + i + " + '%' OR LTRIM(RTRIM(UPPER(imie))) + ' ' + LTRIM(RTRIM(UPPER(nazwisko))) like '%' +  @fraza" + i + " + '%') OR EXISTS (SELECT 1 FROM list_aut_k INNER JOIN ksiazki_wautor_new ON ksiazki_wautor_new.id_wautor = list_aut_k.id_aut AND ksiazki_wautor_new.id_ksiazka = ksiazki_new.kod WHERE LTRIM(RTRIM(UPPER(nazwisko))) + LTRIM(RTRIM(UPPER(imie))) like '%' + @fraza" + i + " + '%' OR LTRIM(RTRIM(UPPER(imie))) + LTRIM(RTRIM(UPPER(nazwisko))) like '%' + @fraza" + i + " + '%')) " + Environment.NewLine;
                    case "authorslastname": Command.CommandText += "EXISTS (SELECT 1 FROM list_aut_k INNER JOIN ksiazki_autor_new ON ksiazki_autor_new.id_autor = list_aut_k.id_aut AND ksiazki_autor_new.id_ksiazka = ksiazki_new.kod WHERE CONTAINS(imie_nazwisko, @fraza" + i + ")) OR EXISTS (SELECT 1 FROM list_aut_k INNER JOIN ksiazki_wautor_new ON ksiazki_wautor_new.id_wautor = list_aut_k.id_aut AND ksiazki_wautor_new.id_ksiazka = ksiazki_new.kod WHERE CONTAINS(imie_nazwisko, @fraza" + i + ")) " + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase.ToUpper());
                        break;
                    //case "title": Command.CommandText += "LTRIM(RTRIM(UPPER(tytul_gl))) LIKE '%' + @fraza" + i + " + '%'" + Environment.NewLine;
                    case "title": Command.CommandText += "CONTAINS (tytul_gl, @fraza" + i + ")" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "key": Command.CommandText += "EXISTS (SELECT 1 FROM ksi_klu INNER JOIN klucze_k ON ksi_klu.kody = klucze_k.kody AND ksi_klu.kod = ksiazki_new.kod WHERE LTRIM(RTRIM(UPPER(klucze_k.klucze))) like '%' + @fraza" + i + " + '%') " + Environment.NewLine;//"klu" + KeyCount + ".kody IN (SELECT kody FROM klucze_k WHERE klucze like '%' + @fraza" + i + " + '%')"; // "LTRIM(RTRIM(UPPER(klu" + KeyCount + ".klucze))) LIKE '%' + @" + i + " + '%'";
                    case "key": Command.CommandText += "EXISTS (SELECT 1 FROM ksi_klu INNER JOIN klucze_k ON ksi_klu.kody = klucze_k.kody AND ksi_klu.kod = ksiazki_new.kod WHERE CONTAINS (klucze_k.klucze, @fraza" + i + ")) " + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        //Command.Parameters.Add("@fraza" + i, System.Data.SqlDbType.NVarChar).Value = Phrase = string.Join(" AND", Phrase.Split(' ').Select(x => "\"" + x + "*\""));
                        break;
                    //case "syg": Command.CommandText += "LTRIM(RTRIM(UPPER(syg))) LIKE '%' + @fraza" + i + " +'%'" + Environment.NewLine;
                    case "syg": Command.CommandText += "CONTAINS (syg, @fraza" + i + ")" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "publisher": Command.CommandText += "EXISTS (SELECT 1 FROM wydawca_k WHERE (nazwa_w like '%' + @fraza" + i + " + '%' OR sk_nazwa_w like '%' + @fraza" + i + " + '%') AND (id_wyd1 = id_wydawcy OR id_wyd2 = id_wydawcy))" + Environment.NewLine;
                    case "publisher": Command.CommandText += "EXISTS (SELECT 1 FROM wydawca_k WHERE CONTAINS((nazwa_w, sk_nazwa_w), @fraza" + i + ") AND (id_wyd1 = id_wydawcy OR id_wyd2 = id_wydawcy))" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "ukd": Command.CommandText += "LTRIM(RTRIM(UPPER(ukd))) LIKE '%' + @fraza" + i + " + '%'" + Environment.NewLine;
                    case "ukd": Command.CommandText += "CONTAINS(ukd, @fraza" + i + ")" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "serie": Command.CommandText += "EXISTS (SELECT 1 FROM ksi_ser INNER JOIN serie ON serie.kody = ksi_ser.kody WHERE LTRIM(RTRIM(UPPER(tyt_serii))) LIKE '%' + @fraza" + i + " + '%' AND ksiazki_new.kod = ksi_ser.kod)" + Environment.NewLine;
                    case "serie": Command.CommandText += "EXISTS (SELECT 1 FROM ksi_ser INNER JOIN serie ON serie.kody = ksi_ser.kody WHERE CONTAINS(tyt_serii, @fraza" + i + ") AND ksiazki_new.kod = ksi_ser.kod)" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase.ToUpper());
                        break;
                    //case "instyt": Command.CommandText += "EXISTS (SELECT 1 FROM instyt WHERE LTRIM(RTRIM(UPPER(nazwa_inst))) LIKE '%' + @fraza" + i + " + '%' AND instyt.kod = ksiazki_new.kod)" + Environment.NewLine;
                    case "instyt": Command.CommandText += "EXISTS (SELECT 1 FROM instyt WHERE CONTAINS(nazwa_inst, @fraza" + i + ") AND instyt.kod = ksiazki_new.kod)" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase.ToUpper());
                        break;
                }                

                if (i+1 < Values.Count)
                    Command.CommandText += Operator.ToLower() == "and" ? " AND " : " OR ";
            }

            if (Values.Count > 0)
                Command.CommandText += ") " + Environment.NewLine;


            // conditions with AND only
            if (ANDValues.Count > 0)
                Command.CommandText += " AND ";

            for (int i = 0; i < ANDValues.Count; i++)
            {
                temp = ANDValues[i];

                Phrase = temp[0].Trim();
                Type = temp[1].Trim().ToLower();
                Operator = temp[2].Trim();

                switch (Type)
                {
                    case "lang": Command.CommandText += "EXISTS (SELECT 1 FROM ksiazki_jezyki_new INNER JOIN jezyki ON jezyki.id = ksiazki_jezyki_new.id_jezyk AND ksiazki_jezyki_new.id_ksiazki = ksiazki_new.kod WHERE id_jezyk = @fraza_" + i + ")" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza_" + i, Phrase.ToUpper());
                        break;
                    case "sources": Command.CommandText += "EXISTS (SELECT 1 FROM documents WHERE kod = ksiazki_new.kod AND rodzaj_zasobu = 1)" + Environment.NewLine;
                        break;
                }

                if (i + 1 < ANDValues.Count)
                    Command.CommandText += Operator.ToLower() == "and" ? " AND " : " OR ";
            }

            Command.CommandText += ") " + Environment.NewLine;

            Command.CommandText += " INSERT INTO @ResultOrder" + Environment.NewLine +
                                   " SELECT tab1.kod, tab1.tytul" + Environment.NewLine +
                                   " FROM tab1" + Environment.NewLine +
                                   " ORDER BY tab1.tytul;" + Environment.NewLine +

                                   " SELECT OrderID, tytul, ResultID AS kod, 'Book' AS type, (SELECT COUNT(*) FROM sygnat WHERE sygnat.kod = ResultID AND wypozycz = 0) AS ilosc, (SELECT COUNT(*) FROM @ResultOrder) AS rows_count" + Environment.NewLine +
                                   " FROM @ResultOrder result" + Environment.NewLine +
                                   " WHERE OrderID >= @start AND OrderID < @end" + Environment.NewLine;

            Command.Parameters.AddWithValue("@start", StartIndex);
            Command.Parameters.AddWithValue("@end", StartIndex + Count);

            return Command;
        }*/

        #endregion

        #region Magazines

        /*public static SqlCommand getMagazinesQuery(List<string[]> Values, List<string[]> ANDValues, int StartIndex, int Count)
        {

            SqlCommand Command = new SqlCommand();

            Command.CommandText = "DECLARE @ResultOrder TABLE  " + Environment.NewLine +
                                  "(     OrderID int identity(1,1) not null primary key clustered," + Environment.NewLine +
                                  "      ResultID int," + Environment.NewLine +
                                  "      tytul varchar(1024)    " + Environment.NewLine +
                                  ");" + Environment.NewLine;

            Command.CommandText += ";with tab1 AS ( " +
                                    "SELECT DISTINCT czasop.kod, LTRIM(RTRIM(czasop.tytul)) As tytul " + Environment.NewLine +
                                   " FROM czasop " + Environment.NewLine +
                                   " INNER JOIN cza_syg ON cza_syg.kod = czasop.kod " + Environment.NewLine +
                                   " LEFT JOIN akcesja ON czasop.kod = akcesja.nr_czasop " + Environment.NewLine +
                                   " WHERE LEN(czasop.tytul) > 0 " +  Environment.NewLine;

            string[] temp;
            string Phrase;
            string Type;
            string Operator;
            string LewyNawias;
            string PrawyNawias;

            if (Values.Count > 0)
                Command.CommandText += " AND (";

            for (int i = 0; i < Values.Count; i++)
            {
                temp = Values[i];

                Phrase = temp[0].Trim();                
                Phrase = string.Join(" AND", Phrase.Split(' ').Where(x => x.Trim().Length > 1).Select(x => "\"" + x + "*\""));

                if (Phrase.Trim().Length == 0)
                    Phrase = "\"" + temp[0].Trim() + "*\"";

                Type = temp[1].Trim().ToLower();
                Operator = temp[2].Trim();
                LewyNawias = temp[3].Trim();
                PrawyNawias = temp[4].Trim();

                switch (Type)
                {
                    //case "title": Command.CommandText += "LTRIM(RTRIM(UPPER(czasop.tytul))) LIKE '%' + @fraza" + i + " + '%'" + Environment.NewLine;
                    case "title": Command.CommandText += "CONTAINS(czasop.tytul, @fraza" + i + ")" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "key": Command.CommandText += "EXISTS (SELECT 1 FROM cza_klu INNER JOIN klucze_c ON cza_klu.kody = klucze_c.kody AND cza_klu.kod = czasop.kod WHERE LTRIM(RTRIM(UPPER(klucze_c.klucze))) like '%' + @fraza" + i + " + '%') " + Environment.NewLine;//"klu" + KeyCount + ".kody IN (SELECT kody FROM klucze_k WHERE klucze like '%' + @fraza" + i + " + '%')"; // "LTRIM(RTRIM(UPPER(klu" + KeyCount + ".klucze))) LIKE '%' + @" + i + " + '%'";
                    case "key": Command.CommandText += "EXISTS (SELECT 1 FROM cza_klu INNER JOIN klucze_c ON cza_klu.kody = klucze_c.kody AND cza_klu.kod = czasop.kod WHERE CONTAINS(klucze_c.klucze, @fraza" + i + ")) " + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "syg": Command.CommandText += "LTRIM(RTRIM(UPPER(cza_syg.syg))) LIKE '%' + @fraza" + i + " +'%'" + Environment.NewLine;
                    case "syg": Command.CommandText += "CONTAINS(cza_syg.syg,  @fraza" + i + ")" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "publisher": Command.CommandText += "EXISTS (SELECT 1 FROM wydawca_c WHERE (nazwa_w like '%' + @fraza" + i + " + '%' OR sk_nazwa_w like '%' + @fraza" + i + " + '%') AND czasop.id_wydawcy = wydawca_c.id_wydawcy)" + Environment.NewLine;
                    case "publisher": Command.CommandText += "EXISTS (SELECT 1 FROM wydawca_c WHERE CONTAINS((nazwa_w, sk_nazwa_w), @fraza" + i + ") AND czasop.id_wydawcy = wydawca_c.id_wydawcy)" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "distributor": Command.CommandText += "LTRIM(RTRIM(UPPER(ukd))) LIKE '%' + @fraza" + i + " + '%'" + Environment.NewLine;
                    case "distributor": Command.CommandText += "EXISTS (SELECT 1 FROM kolport WHERE CONTAINS((nazwa_k, sk_nazwa_k), @fraza" + i + ") AND kolport.id_kolport = czasop.id_kolport)" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "extras_title": Command.CommandText += "EXISTS (SELECT 1 FROM dodatki WHERE czasop.kod = dodatki.kod AND LTRIM(RTRIM(UPPER(tytul_dod))) LIKE '%' + @fraza" + i + " +'%')" + Environment.NewLine;
                    case "extras_title": Command.CommandText += "EXISTS (SELECT 1 FROM dodatki WHERE czasop.kod = dodatki.kod AND CONTAINS(tytul_dod, @fraza" + i + "))" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "extras_author": Command.CommandText += "EXISTS (SELECT 1 FROM dodatki WHERE czasop.kod = dodatki.kod AND (LTRIM(RTRIM(UPPER(autor1))) LIKE '%' + @fraza" + i + " +'%' OR LTRIM(RTRIM(UPPER(autor2))) LIKE '%' + @fraza" + i + " +'%' OR LTRIM(RTRIM(UPPER(autor3))) LIKE '%' + @fraza" + i + " +'%'))" + Environment.NewLine;
                    case "extras_author": Command.CommandText += "EXISTS (SELECT 1 FROM dodatki WHERE czasop.kod = dodatki.kod AND (CONTAINS(autor1, @fraza" + i + ") OR CONTAINS(autor2,  @fraza" + i + ") OR CONTAINS(autor3, @fraza" + i + ")))" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                }

                if (i + 1 < Values.Count)
                    Command.CommandText += Operator.ToLower() == "and" ? " AND " : " OR ";
            }

            if (Values.Count > 0)
                Command.CommandText += ") " + Environment.NewLine;

            // conditions with AND only
            if (ANDValues.Count > 0)
                Command.CommandText += " AND ";

            for (int i = 0; i < ANDValues.Count; i++)
            {
                temp = ANDValues[i];

                Phrase = temp[0].Trim();
                Type = temp[1].Trim().ToLower();
                Operator = temp[2].Trim();
                LewyNawias = temp[3].Trim();
                PrawyNawias = temp[4].Trim();

                switch (Type)
                {
                    case "lang": Command.CommandText += "(SELECT jezyk FROM jezyki WHERE id = @fraza_" + i + ") IN (jezyk1, jezyk2, jezyk3)" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza_" + i, Phrase.ToUpper());
                        break;
                    case "country": Command.CommandText += "czasop.kraj_w = (SELECT panstwo FROM panstwa WHERE id = @fraza_" + i + ") " + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza_" + i, Phrase.ToUpper());
                        break;
                    case "freq": Command.CommandText += "czasop.id_czest = @fraza_" + i + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza_" + i, Phrase.ToUpper());
                        break;
                    case "sources": Command.CommandText += "EXISTS (SELECT 1 FROM documents WHERE kod = czasop.kod AND rodzaj_zasobu = 2)" + Environment.NewLine;
                        break;
                }

                if (i + 1 < ANDValues.Count)
                    Command.CommandText += Operator.ToLower() == "and" ? " AND " : " OR ";
            }

            Command.CommandText += ") " + Environment.NewLine;

            Command.CommandText += " INSERT INTO @ResultOrder" + Environment.NewLine +
                                   " SELECT tab1.kod, tab1.tytul" + Environment.NewLine +
                                   " FROM tab1" + Environment.NewLine +
                                   " ORDER BY tab1.tytul;" + Environment.NewLine +

                                   " SELECT OrderID, tytul, ResultID AS kod, 'Magazine' AS type, 0 AS ilosc, (SELECT COUNT(*) FROM @ResultOrder) AS rows_count" + Environment.NewLine +
                                   " FROM @ResultOrder result" + Environment.NewLine +
                                   " WHERE OrderID >= @start AND OrderID < @end" + Environment.NewLine;

            Command.Parameters.AddWithValue("@start", StartIndex);
            Command.Parameters.AddWithValue("@end", StartIndex + Count);
           
            Command.CommandText +=  " ORDER BY tytul; ";

            return Command;
        }*/
        
        #endregion

       /* #region Articles

        public static SqlCommand getArticlesQuery(List<string[]> Values, List<string[]> ANDValues, int StartIndex, int Count)
        {
            SqlCommand Command = new SqlCommand();

            Command.CommandText = "DECLARE @ResultOrder TABLE  " + Environment.NewLine +
                                  "(     OrderID int identity(1,1) not null primary key clustered," + Environment.NewLine +
                                  "      ResultID int," + Environment.NewLine +
                                  "      tytul varchar(1024)    " + Environment.NewLine +
                                  ");" + Environment.NewLine;


            Command.CommandText += ";with tab1 AS (SELECT DISTINCT artykuly.kod, LTRIM(RTRIM(artykuly.tytul_a)) AS tytul " + Environment.NewLine +
                                " FROM artykuly " + Environment.NewLine +
                                " WHERE LEN(tytul_a) > 0 " + Environment.NewLine;

            string[] temp;
            string Phrase;
            string Type;
            string Operator;

            if (Values.Count > 0)
                Command.CommandText += " AND (";

            for (int i = 0; i < Values.Count; i++)
            {
                temp = Values[i];

                Phrase = temp[0].Trim();
                Phrase = string.Join(" AND", Phrase.Split(' ').Select(x => "\"" + x + "*\""));
                Type = temp[1].Trim().ToLower();
                Operator = temp[2].Trim();

                switch (Type)
                {
                    //case "authorlastname": Command.CommandText += "(LTRIM(RTRIM(UPPER(imie))) + ' ' + LTRIM(RTRIM(UPPER(nazwisko))) LIKE '%' + @fraza" + i + " + '%' OR LTRIM(RTRIM(UPPER(nazwisko))) + ' ' + LTRIM(RTRIM(UPPER(imie))) LIKE '%' + @fraza" + i + " + '%')";
                    case "authorslastname": Command.CommandText += "EXISTS (SELECT 1 FROM list_aut_a INNER JOIN art_aut ON art_aut.id_aut = list_aut_a.id_aut AND art_aut.kod = artykuly.kod WHERE CONTAINS(imie_nazwisko, @fraza" + i + "))" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "title": Command.CommandText += "LTRIM(RTRIM(UPPER(tytul_a))) LIKE '%' + @fraza" + i + " + '%'";
                    case "title": Command.CommandText += "CONTAINS(tytul_a, @fraza" + i + ")";
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "key": Command.CommandText += "EXISTS (SELECT 1 FROM art_klu INNER JOIN klucze_a ON art_klu.kody = klucze_a.kody AND art_klu.kod = artykuly.kod WHERE LTRIM(RTRIM(UPPER(klucze_a.klucze))) LIKE '%' + @fraza" + i + " + '%') " + Environment.NewLine;
                    case "key": Command.CommandText += "EXISTS (SELECT 1 FROM art_klu INNER JOIN klucze_a ON art_klu.kody = klucze_a.kody AND art_klu.kod = artykuly.kod WHERE CONTAINS(klucze_a.klucze, @fraza" + i + "))" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                    //case "magazine_title": Command.CommandText += "UPPER(rodzaj_zas) = 'C' AND EXISTS (SELECT 1 FROM czasop WHERE czasop.kod = artykuly.kod AND LTRIM(RTIRM(UPPER(czasop.tytul))) LIKE '%' + @fraza" + i + " + '%') " + Environment.NewLine;
                    case "magazine_title": Command.CommandText += "UPPER(rodzaj_zas) = 'C' AND EXISTS (SELECT 1 FROM czasop WHERE czasop.kod = artykuly.kod_zas AND CONTAINS(czasop.tytul, @fraza" + i + "))" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza" + i, Phrase);
                        break;
                }                

                if (i + 1 < Values.Count)
                    Command.CommandText += Operator.ToLower() == "and" ? " AND " : " OR ";
            }

            if (Values.Count > 0)
                Command.CommandText += ") " + Environment.NewLine;


            // conditions with AND only
            if (ANDValues.Count > 0)
                Command.CommandText += " AND ";

            for (int i = 0; i < ANDValues.Count; i++)
            {
                temp = ANDValues[i];

                Phrase = temp[0].Trim();
                Type = temp[1].Trim().ToLower();
                Operator = temp[2].Trim();

                switch (Type)
                {
                    case "lang": Command.CommandText += "artykuly.jezyk = (SELECT jezyk FROM jezyki WHERE id = @fraza_" + i + ")" + Environment.NewLine;
                        Command.Parameters.AddWithValue("@fraza_" + i, Phrase.ToUpper());
                        break;
                    case "sources": Command.CommandText += "EXISTS (SELECT 1 FROM documents WHERE kod = artykuly.kod AND rodzaj_zasobu = 3)" + Environment.NewLine;
                        break;
                }

                if (i + 1 < ANDValues.Count)
                    Command.CommandText += Operator.ToLower() == "and" ? " AND " : " OR ";
            }

            Command.CommandText += ") " + Environment.NewLine;

            Command.CommandText += " INSERT INTO @ResultOrder" + Environment.NewLine +
                                   " SELECT tab1.kod, tab1.tytul" + Environment.NewLine +
                                   " FROM tab1" + Environment.NewLine +
                                   " ORDER BY tab1.tytul;" + Environment.NewLine +

                                   " SELECT OrderID, tytul, ResultID AS kod, 'Article' AS type, 0 AS ilosc, (SELECT COUNT(*) FROM @ResultOrder) AS rows_count" + Environment.NewLine +
                                   " FROM @ResultOrder result" + Environment.NewLine +
                                   " WHERE OrderID >= @start AND OrderID < @end" + Environment.NewLine;

            Command.Parameters.AddWithValue("@start", StartIndex);
            Command.Parameters.AddWithValue("@end", StartIndex + Count);            

            Command.CommandText += " ORDER BY tytul; ";

            return Command;
        }

        #endregion*/
    }
}