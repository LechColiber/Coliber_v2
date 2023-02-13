using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

public class IniFile
{
    [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileStringW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    private static extern int WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFilename);

    public string path;
    public string Path;

    public IniFile(string ConfigFileName, string Name = "", bool lx = true)
    {
        path = FilePath(ConfigFileName, Name);
        Path = path;
    }

    public IniFile(string ConfigFileName, string Name = "")
    {
       path = FilePath(ConfigFileName, Name);
       Path = path;
    }

    public IniFile(string INIPath)
    {
        path = INIPath;
        Path = path;
    }

    public string ReadIni(string Section, string Key)
    {
        string Temp = "";
        string Value = "";

        try
        {
            StreamReader Reader = new StreamReader(path, Encoding.Default);
            
            while (Reader.EndOfStream == false)
            {
                Temp = Reader.ReadLine().Trim();

                if (Temp.Length > 0 && Temp[0] == ';')
                    continue;

                while (Temp.Length > 0 && Temp[0] == '[' && Temp[Temp.Length - 1] == ']')
                {
                    if (Temp.ToLower().Substring(1, Temp.Length - 2) == Section.ToLower().Trim())
                    {
                        if (Reader.EndOfStream == false)
                            Temp = Reader.ReadLine().Trim();
                        else
                            break;

                        while (Temp.Length > 0 && Temp[0] != '[' && Temp[Temp.Length - 1] != ']')
                        {
                            if (Temp.Length >= Key.Length && Temp.ToLower().Substring(0, Key.Length) == Key.ToLower().Trim())
                            {
                                if (Temp.Length > Key.Length + 1)
                                {
                                    Reader.Close();
                                    return Temp.Substring(Key.Length + 1);
                                }
                            }

                            if (Reader.EndOfStream == false)
                                Temp = Reader.ReadLine();
                            else
                                break;
                        }
                        continue;
                    }

                    if (Reader.EndOfStream == false)
                        Temp = Reader.ReadLine();
                    else
                        break;
                }
            }

            Reader.Close();

            return Value;
        }
        catch (Exception Ex)
        {
            if (Ex is FileNotFoundException)
                MessageBox.Show("Brak pliku konfiguracyjnego.");
            else if (Ex is IOException)
                MessageBox.Show("Błąd odczytu z pliku.");
            else if (Ex is DirectoryNotFoundException)
                MessageBox.Show("Nie znaleziono folderu z plikiem konfiguracyjnym");
            else
                MessageBox.Show(Ex.Message);

            return "";
        }
    }

    public void WriteIni(string Section, string Key, string Value)
    {
        WritePrivateProfileString(Section, Key, Value, path);
    }

    public void WriteIni(string Section, string[] Keys, string[] Values)
    {
        int i = 0;

        while (i < Keys.Length && i < Values.Length)
        {
            WritePrivateProfileString(Section, Keys[i], Values[i], path);
            i++;
        }
    }

    public string FilePath(string ConfigFileName, string Name = "")
    {
        string path = "";
        RegistryKey Reg;

        try
        {
            Reg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            Reg = Reg.OpenSubKey("SOFTWARE\\Exell\\" + Name);
            path = Reg.GetValue("Path").ToString();
            Reg.Close();

            if (File.Exists(path + "\\" + ConfigFileName) || File.Exists(path + ConfigFileName))
            {
                if (path[path.Length - 1].ToString() == "\\")
                    return path + ConfigFileName;
                else
                    return path + "\\" + ConfigFileName;
            }
        }
        catch (Exception Ex)
        {
            //MessageBox.Show(Ex.Message);
        }

        if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + @"\Exell\" + Name + @"\" + ConfigFileName))
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + @"\Exell\" + Name + @"\" + ConfigFileName;
        }
        else if (File.Exists(ConfigFileName))
            return Environment.CurrentDirectory + "\\" + ConfigFileName;
        else
        {
            MessageBox.Show("Wskaż lokalizację pliku \"" + ConfigFileName + "\".");
            OpenFileDialog OFP = new OpenFileDialog();
            OFP.Filter = "*.ini|*.ini";
            OFP.ShowDialog();

            if (OFP.FileName == "")
            {
                /*if (MessageBox.Show("Proszę podać ścieżkę do pliku " + this.ConfigFileName + ". Prawdopodobnie znajduje się on w folderze z Co-Librem.", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    FilePath();
                else
                {
                    if (MessageBox.Show("Zamknąć?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Application.Exit();
                }*/
            }
            else
            {
                return OFP.FileName;
            }

            return "";
        }
    }
}