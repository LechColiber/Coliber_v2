using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Resources;

using System.Data.SqlClient;

using System.Diagnostics;
using System.Web.UI;
using System.Data;

namespace WebColiber
{
    public static class Settings
    {
        public static bool Dbg;

        public static bool Articles;
        public static bool Magazines;
        public static bool Books;
        public static bool News;
        public static bool Normy;

        public static bool CanOrder;

        public static bool SearchByKeyInArticlesVisible;
        public static bool SearchByKeyInBooksVisible;
        public static bool SearchByKeyInMagazinesVisible;
        public static bool SearchByInstitutionInBooksVisible;
        public static bool SearchBySerieInBooksVisible;
        public static bool SearchByPublisherInBooksVisible;
        public static bool SearchByPublisherInMagazinesVisible;
        public static bool SearchByUKDInBooksVisible;
        public static bool SearchByEntryInArticlesDateVisible;
        public static bool SearchByEntryInBooksDateVisible;
        public static bool SearchByPublishYearInBooksVisible;
        public static bool SearchByDistributorInMagazinesVisible;
        public static bool SearchByExtrasTitleInMagazinesVisible;
        public static bool SearchByExtrasAuthorInMagazinesVisible;
        public static bool SearchByDescFragmentInArticlesVisible;

        public static bool IsDomain;
        public static bool ShortDetails;
        public static bool ShowNumerInwentarzowy;        

        public static string ColiberConnectionString;
        public static string WypozyczalniaConnectionString;

        public static string Recipient;
        public static string SmtpServer;
        public static string User;
        public static string Password;

        public static string Localization;
        public static bool changeLang;

        public static int OrderMethod;
        public static string PracownikWypozyczajacyID;

        public static bool IsDemo;
        public static SqlConnection ColiberConnection;
        public static SqlConnection WypozyczalniaConnection;

        public static System.Diagnostics.Stopwatch CacheStopWatch;
        public static DataTable CountryDataTable;
        public static DataTable LanguagesDataTable;

        public static void SetSettings()
        {
            Dbg = ConfigurationManager.AppSettings["Dbg"].ToLower().Trim() == "True".ToLower();

            Articles = ConfigurationManager.AppSettings["Articles"].ToLower().Trim() == "True".ToLower();
            Magazines = ConfigurationManager.AppSettings["Magazines"].ToLower().Trim() == "True".ToLower();
            Books = ConfigurationManager.AppSettings["Books"].ToLower().Trim() == "True".ToLower();
            News = ConfigurationManager.AppSettings["News"].ToLower().Trim() == "True".ToLower();
            Normy = ConfigurationManager.AppSettings["Normy"].ToLower().Trim() == "True".ToLower();

            SearchByKeyInArticlesVisible = ConfigurationManager.AppSettings["SearchByKeyInArticlesVisible"].ToLower().Trim() == "True".ToLower();
            SearchByKeyInBooksVisible = ConfigurationManager.AppSettings["SearchByKeyInBooksVisible"].ToLower().Trim() == "True".ToLower();
            SearchByKeyInMagazinesVisible = ConfigurationManager.AppSettings["SearchByKeyInMagazinesVisible"].ToLower().Trim() == "True".ToLower();

            SearchByInstitutionInBooksVisible = ConfigurationManager.AppSettings["SearchByInstitutionInBooksVisible"].ToLower().Trim() == "True".ToLower();

            SearchBySerieInBooksVisible = ConfigurationManager.AppSettings["SearchBySerieInBooksVisible"].ToLower().Trim() == "True".ToLower();

            SearchByPublisherInBooksVisible = ConfigurationManager.AppSettings["SearchByPublisherInBooksVisible"].ToLower().Trim() == "True".ToLower();
            SearchByPublisherInMagazinesVisible = ConfigurationManager.AppSettings["SearchByPublisherInMagazinesVisible"].ToLower().Trim() == "True".ToLower();

            SearchByUKDInBooksVisible = ConfigurationManager.AppSettings["SearchByUKDInBooksVisible"].ToLower().Trim() == "True".ToLower();

            SearchByEntryInArticlesDateVisible = ConfigurationManager.AppSettings["SearchByEntryInArticlesDateVisible"].ToLower().Trim() == "True".ToLower();
            SearchByEntryInBooksDateVisible = ConfigurationManager.AppSettings["SearchByEntryInBooksDateVisible"].ToLower().Trim() == "True".ToLower();

            SearchByPublishYearInBooksVisible = ConfigurationManager.AppSettings["SearchByPublishYearInBooksVisible"].ToLower().Trim() == "True".ToLower();

            SearchByDistributorInMagazinesVisible = ConfigurationManager.AppSettings["SearchByDistributorInMagazinesVisible"].ToLower().Trim() == "True".ToLower();
            SearchByExtrasTitleInMagazinesVisible = ConfigurationManager.AppSettings["SearchByExtrasTitleInMagazinesVisible"].ToLower().Trim() == "True".ToLower();
            SearchByExtrasAuthorInMagazinesVisible = ConfigurationManager.AppSettings["SearchByExtrasAuthorInMagazinesVisible"].ToLower().Trim() == "True".ToLower();

            SearchByDescFragmentInArticlesVisible = ConfigurationManager.AppSettings["SearchByDescFragmentInArticlesVisible"].ToLower().Trim() == "True".ToLower();

            IsDomain = ConfigurationManager.AppSettings["IsDomain"].ToLower().Trim() == "True".ToLower();
            ShortDetails = ConfigurationManager.AppSettings["IsShortDetails"].ToLower().Trim() == "True".ToLower();
            ShowNumerInwentarzowy = ConfigurationManager.AppSettings["ShowNumerInwentarzowy"].ToLower().Trim() == "True".ToLower();

            PracownikWypozyczajacyID = ConfigurationManager.AppSettings["PracownikWypozyczajacyID"].ToLower().Trim();
            CanOrder = ConfigurationManager.AppSettings["canOrder"].ToLower().Trim() == "True".ToLower();

            ColiberConnectionString = ConfigurationManager.ConnectionStrings["Coliber"].ConnectionString;
            WypozyczalniaConnectionString = ConfigurationManager.ConnectionStrings["Wypozyczalnia"].ConnectionString;

            Recipient = ConfigurationManager.AppSettings["Recipient"];
            SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            User = ConfigurationManager.AppSettings["User"];
            Password = ConfigurationManager.AppSettings["Password"];

            Localization = ConfigurationManager.AppSettings["Localization"];
            changeLang = ConfigurationManager.AppSettings["changeLang"].ToLower().Trim() == "true";

            Int32.TryParse(ConfigurationManager.AppSettings["OrderMethod"].ToString(), out OrderMethod);

            WypozyczalniaConnection = new SqlConnection(WypozyczalniaConnectionString);
            ColiberConnection = new SqlConnection(ColiberConnectionString);

            IsDemo = false;
        }

        public static void RestartCacheStopWatch()
        {
            CacheStopWatch.Restart();
        }

        public static void GetSettingsFromDb()
        {           
            HttpContext.Current.Session["UserID"] = "-1";            
            HttpContext.Current.Session["Banned"] = "true";
            HttpContext.Current.Session["Name"] = "";
            HttpContext.Current.Session["CanOrder"] = "false";
        }

        public static void GetSettinsgFromDb(string TempName)
        {
            HttpContext.Current.Session["UserID"] = "-1";
            HttpContext.Current.Session["Banned"] = (OrderMethod != 1).ToString().ToLower();
            HttpContext.Current.Session["Name"] = "";
            HttpContext.Current.Session["CanOrder"] = "false";
            HttpContext.Current.Session["Deleted"] = (OrderMethod != 1).ToString().ToLower(); ;

            SqlConnection Connection = new SqlConnection(Settings.WypozyczalniaConnectionString);
            
            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;
            Command.CommandText = "SELECT nazwa, uzytk_id, CASE WHEN data_wyrejestr IS NOT NULL OR zablokowany = 1 THEN 'true' ELSE 'false' END AS zablokowany, CASE WHEN data_wyrejestr IS NOT NULL THEN 'true' ELSE 'false' END AS wyrejestrowany FROM w2_uzytkownicy WHERE LOWER(LTRIM(RTRIM(domena_nazwa))) = LOWER(LTRIM(RTRIM(@Name))); ";
            Command.Parameters.AddWithValue("@Name", TempName.ToLower());

            //SiteMaster.Name = TempName;
            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    HttpContext.Current.Session["Name"] = Reader.GetValue("nazwa").ToString();
                    
                    HttpContext.Current.Session["UserID"] = Reader.GetValue("uzytk_id").ToString();
                    HttpContext.Current.Session["Banned"] = Reader.GetValue("zablokowany").ToString().Trim().ToLower();
                    HttpContext.Current.Session["Deleted"] = Reader.GetValue("wyrejestrowany").ToString().Trim().ToLower();                    
                }

                Reader.Dispose();
                Connection.Close();
            }
            catch (Exception)
            {
                Connection.Close();
            }

            if (Int32.Parse((HttpContext.Current.Session["UserID"] as string)) == -1 && OrderMethod == 0)
                HttpContext.Current.Session["CanOrder"] = "false";
            else
                HttpContext.Current.Session["CanOrder"] = "true";

            if ((HttpContext.Current.Session["Banned"] as string).Trim() == "false")
                HttpContext.Current.Session["CanOrder"] = "true";
            else
                HttpContext.Current.Session["CanOrder"] = "false";

            if (!CanOrder)
                HttpContext.Current.Session["CanOrder"] = "false";
            if (Dbg)
            {
                HttpContext.Current.Session["CanOrder"] = "true";
                HttpContext.Current.Session["UserID"] = "676";
            }
        }
    }
}