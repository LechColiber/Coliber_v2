using System.Collections.Generic;
using ProcessCloser;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Translate_Manager;
using System.IO;

public static class CommonFunctions
{
    [System.Runtime.InteropServices.DllImport("user32", SetLastError = false)]
    private static extern bool SetForegroundWindow(Int32 hwnd);

    public static bool WriteData(SqlCommand Command, ref SqlConnection Connection)
    {
        SqlTransaction Transaction = null;

        try
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            Transaction = Connection.BeginTransaction("Trans");

            Command.Connection = Connection;
            Command.Transaction = Transaction;

            Command.ExecuteNonQuery();

            Transaction.Commit();

            return true;
        }
        catch (SqlException Ex)
        {
            SQLLog(Command.CommandText);
            try
            {
                if (Transaction != null)
                    Transaction.Rollback();
            }
            catch (Exception Ex2)
            {
                MessageBox.Show(Ex2.Message, "Błąd SQL1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            foreach (SqlError a in Ex.Errors)
            {
                if (a.Number == 18456 || a.State.ToString() == "28000")
                {
                    MessageBox.Show("Nieprawidłowy użytkownik lub hasło bazy danych.", "Nieprawidłowe poświadczenia",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (a.State.ToString() == "08001")
                {
                    MessageBox.Show("Brak dostępu do serwera bazy danych.", "Brak dostępu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    MessageBox.Show(Ex.Message, "Błąd SQL2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }           
        }
        catch (Exception Ex)
        {
            try
            {
                if (Transaction != null)
                    Transaction.Rollback();
            }
            catch (Exception Ex2)
            {
                MessageBox.Show(Ex2.Message, "Błąd SQL3", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            MessageBox.Show(Ex.Message, "Błąd SQL4", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return false;
        }
        finally
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        return false;
    }

    public static bool WriteData(ref SqlCommand Command, ref SqlConnection Connection)
    {
        SqlTransaction Transaction = null;

        try
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            Transaction = Connection.BeginTransaction("Trans");

            Command.Connection = Connection;
            Command.Transaction = Transaction;

            Command.ExecuteNonQuery();

            Transaction.Commit();

            return true;
        }
        catch (SqlException Ex)
        {
            SQLLog(Command.CommandText);
            try
            {
                if (Transaction != null)
                    Transaction.Rollback();
            }
            catch (Exception Ex2)
            {
                MessageBox.Show(Ex2.Message, "Błąd SQL5", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            foreach (SqlError a in Ex.Errors)
            {
                if (a.Number == 18456 || a.State.ToString() == "28000")
                {
                    MessageBox.Show("Nieprawidłowy użytkownik lub hasło bazy danych.", "Nieprawidłowe poświadczenia",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (a.State.ToString() == "08001")
                {
                    MessageBox.Show("Brak dostępu do serwera bazy danych.", "Brak dostępu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    MessageBox.Show(Ex.Message, "Błąd SQL6", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }            
        }
        catch (Exception Ex)
        {
            try
            {
                if (Transaction != null)
                    Transaction.Rollback();
            }
            catch (Exception Ex2)
            {
                MessageBox.Show(Ex2.Message, "Błąd SQL7", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            MessageBox.Show(Ex.Message, "Błąd SQL8", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return false;
        }
        finally
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        return false;
    }

    public static DataTable ReadData(SqlCommand Command, ref SqlConnection Connection)
    {
        DataTable Dt = new DataTable();
        SqlDataReader Reader = null;

        try
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            Command.Connection = Connection;

            Reader = Command.ExecuteReader();

            Dt.Load(Reader);

            Reader.Close();

            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }
        catch (SqlException Ex)
        {
            SQLLog(Command.CommandText);
            foreach (SqlError a in Ex.Errors)
            {
                if (a.Number == 18456 || a.State.ToString() == "28000")
                {
                    MessageBox.Show("Nieprawidłowy użytkownik lub hasło bazy danych.", "Nieprawidłowe poświadczenia",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                else if (a.State.ToString() == "08001")
                {
                    MessageBox.Show("Brak dostępu do serwera bazy danych.", "Brak dostępu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return false;
                }
                else
                    MessageBox.Show(Ex.Message, "Błąd SQL9", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            if (Reader != null && Reader.IsClosed != true)
                Reader.Close();

            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        return Dt;
    }

    public static void CheckIsOpen(string MUTEX_GUID, string HeadProgramName)
    {
        //string MUTEX_GUID = "czasopisma_coliber";

        Mutex oneMutex = null;

        try
        {
            oneMutex = Mutex.OpenExisting(MUTEX_GUID);
        }
        catch (WaitHandleCannotBeOpenedException Ex)
        {
            // Mutex nie istnieje, obsługa wyjątku                
        }

        if (oneMutex == null)
        {
            oneMutex = new Mutex(true, MUTEX_GUID);
        }
        else
        {
            Process currentProcess = Process.GetCurrentProcess();

            String processName = currentProcess.ProcessName;
            Int32 currentProcessId = currentProcess.Id;

            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process p in processes)
            {
                // Bring the existing instance to the front

                if (p.Id != currentProcessId)
                {
                    IntPtr windowHandle = p.MainWindowHandle;
                    SetForegroundWindow(windowHandle.ToInt32());
                }
            }

            oneMutex.Close();
            //return;
            //Thread.CurrentThread.Abort();
            Environment.Exit(0);
        }

        ProcessMonitor.Init("coliber");
    }

    public static Dictionary<string, string> GetAndLoadTranslations(Dictionary<Object, string> mapDictionary, string culture)
    {
        try
        {            
            TranslateReader reader = new TranslateReader(culture);

            foreach (var item in mapDictionary)
            {
                string value = "";
                
                if (reader.Dictionary.TryGetValue(item.Value, out value))
                {                    
                    if(item.Key.GetType().GetProperty("Text") != null)
                        item.Key.GetType().GetProperty("Text").SetValue(item.Key, value, null);
                    else if (item.Key.GetType().GetProperty("HeaderText") != null)
                        item.Key.GetType().GetProperty("HeaderText").SetValue(item.Key, value, null);
                }
            }

            return reader.Dictionary;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        return new Dictionary<string, string>();
    }

    public static string getStringFromDictionary(this Dictionary<string, string> dictionary, string key, string stringIfNotFound)
    {
        return dictionary.ContainsKey(key) ? dictionary[key] : stringIfNotFound;
    }

    public static void LoadConfig(Control.ControlCollection ctrlCollection, ref SqlConnection sqlConnection, int modul)
    {
        SqlCommand Command = new SqlCommand();

        Command.CommandText = "EXEC getConfig @modul;";
        Command.Parameters.AddWithValue("@modul", modul);

        DataTable Dt = CommonFunctions.ReadData(Command, ref sqlConnection);

        for (int i = 0; i < Dt.Rows.Count; i++)
        {
            //Control[] a = this.Controls.Find(Dt.Rows[i]["nazwa_kontrolki"].ToString(), true);
            Control[] a = ctrlCollection.Find(Dt.Rows[i]["nazwa_kontrolki"].ToString(), true);
            string wartosc = "1";
            wartosc = "0";

            if (a.Length > 0)
            {
                wartosc = Dt.Rows[i]["wartosc"].ToString();

                switch (Dt.Rows[i]["wlasciwosc"].ToString().Trim().ToLower())
                {
                    case "visible":
                        a[0].Visible = wartosc != "0";
                        break;
                    case "checked":
                        if (a[0] is CheckBox)
                            ((CheckBox) a[0]).Checked = wartosc != "0";
                        else if (a[0] is RadioButton)
                            ((RadioButton) a[0]).Checked = wartosc != "0";

                        break;
                    case "charactercasing":
                        if (a[0] is TextBox)
                        {
                            CharacterCasing ch = CharacterCasing.Normal;

                            CharacterCasing.TryParse(wartosc, true, out ch);
                            ((TextBox) a[0]).CharacterCasing = ch;
                        }
                        break;
                }
            }
        }

    }
    public static void SQLLog(String sInfo, Boolean lNew = false)
    {
        string cPath = Application.LocalUserAppDataPath;
        string cLog = cPath + @"\Coliber.LOG";
        //MessageBox.Show(cLog);
        if (lNew & File.Exists(cLog)) File.Delete(cLog);
        File.AppendAllText(cLog, "\r\n --- " + DateTime.Now.ToString() + " --- \r\n" + sInfo);

    }
}
