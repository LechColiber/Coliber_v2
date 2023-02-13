using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using System.Data.Odbc;
using System.Threading;

namespace Ksiazki
{
    public partial class EditMARCForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        List<EditMARCUC> EditMARCUCList;
        List<string> TagsList;
        List<KeyValuePair<string, List<string>>> TagsCodesList;

        public EditMARCForm(Object Array, bool IsEdit, string FormName)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();
            
            AddRowButton.Visible = IsEdit;
            this.Text = FormName;
            Rectangle Rect = Screen.PrimaryScreen.Bounds;

            this.Size = new Size(Rect.Width / 2, Rect.Height / 4 * 3);
            this.groupBox1.Text = FormName;

            TagsList = ReadTagsFromXML();
            EditMARCUCList = new List<EditMARCUC>();

            //dodawania kontrolek do List
            foreach (List<SubfieldClass> Datafield in (IList)Array)
            {
                foreach(SubfieldClass Subfield in Datafield)
                {
                    if (TagsList.Contains(Subfield.Tag))
                    {
                        for (int i = 0; i < TagsCodesList.Count; i++)
                        {
                            if (TagsCodesList[i].Key == Subfield.Tag && TagsCodesList[i].Value.Contains(Subfield.Code))
                            {
                                EditMARCUC NewRowEditMARCUC;

                                if (Subfield.Code.Trim() == "")
                                    NewRowEditMARCUC = new EditMARCUC(TagsList, Subfield.Tag, Subfield.Ind1, Subfield.Ind2, "" + Subfield.Value, IsEdit);
                                else
                                    NewRowEditMARCUC = new EditMARCUC(TagsList, Subfield.Tag, Subfield.Ind1, Subfield.Ind2, Subfield.Code + "\\ " + Subfield.Value, IsEdit);

                                NewRowEditMARCUC.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
                                NewRowEditMARCUC.Size = new Size(this.Size.Width - 40, NewRowEditMARCUC.Size.Height);
                                EditMARCUCList.Add(NewRowEditMARCUC);
                            }
                        }
                    }
                }
            }
            
            //
            for (int i = 0; i < EditMARCUCList.Count; i++)
            {
                if (i < EditMARCUCList.Count - 1 && EditMARCUCList[i].GetTagComboBoxText() == EditMARCUCList[i + 1].GetTagComboBoxText())
                {
                    EditMARCUCList[i].SetValueTextBoxText(EditMARCUCList[i].GetValueTextBoxText(), EditMARCUCList[i+1].GetValueTextBoxText());
                    EditMARCUCList.RemoveAt(i + 1);
                    i--;
                }
            }

            //sortowanie po tagu
            for (int i = 0; i < EditMARCUCList.Count; i++)
            {
                EditMARCUC temp;

                for (int j = 0; j < EditMARCUCList.Count-1; j++)
                {
                    try
                    {
                        if (j < EditMARCUCList.Count - 1 && Int32.Parse(EditMARCUCList[j].GetTagComboBoxText()) > Int32.Parse(EditMARCUCList[j + 1].GetTagComboBoxText()))
                        {
                            temp = EditMARCUCList[j + 1];
                            EditMARCUCList[j + 1] = EditMARCUCList[j];
                            EditMARCUCList[j] = temp;
                        }
                    }
                    catch (Exception Ex)
                    {

                    }
                }
            }

            //lokowanie kontrolek na panelu
            /*for(int i = 0; i < EditMARCUCList.Count; i++)
            {
                EditMARCUCList[i].Location = new Point(TagLabel.Location.X-3, TagLabel.Location.Y + TagLabel.Size.Height + i * EditMARCUCList[i].Size.Height);
                //MessageBox.Show(EditMARCUCList[i].ToString());
                panel1.Controls.Add(EditMARCUCList[i]);
            }*/

            for (int i = 0; i < EditMARCUCList.Count; i++)
            {
                MARCDetailsTextBox.Text += EditMARCUCList[i].ToString() + "\r\n";                
            }

            //MARCDetailsTextBox.Text += "\r\n";
            MARCDetailsTextBox.Select(MARCDetailsTextBox.Text.Length, 0);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "view_marc");
            mapping.Add(groupBox1, "view_marc");
            mapping.Add(Ind2Label, "ws2");
            mapping.Add(TagLabel, "field");
            mapping.Add(Ind1Label, "ws1");
            mapping.Add(ValueLabel, "value");
            mapping.Add(CancelButton, "exit");
            mapping.Add(ImportButton, "import");
            mapping.Add(AddRowButton, "add_row");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        //dodawanie wiersza
        private void AddRowButton_Click(object sender, EventArgs e)
        {
            EditMARCUC NewRowEditMARCUC = new EditMARCUC(TagsList, "", "", "", "", true);

            if (EditMARCUCList.Count > 0)
            {
                NewRowEditMARCUC.Location = new Point(EditMARCUCList[EditMARCUCList.Count - 1].Location.X, EditMARCUCList[EditMARCUCList.Count - 1].Location.Y + 31);
                NewRowEditMARCUC.Size = EditMARCUCList[EditMARCUCList.Count - 1].Size;
            }
            else
            {
                NewRowEditMARCUC.Location = new Point(TagLabel.Location.X - 3, TagLabel.Location.Y + TagLabel.Size.Height + NewRowEditMARCUC.Size.Height);
                NewRowEditMARCUC.Size = new Size(this.Size.Width - 40, NewRowEditMARCUC.Size.Height);
            }

            NewRowEditMARCUC.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
           
            EditMARCUCList.Add(NewRowEditMARCUC);
            panel1.Controls.Add(EditMARCUCList[EditMARCUCList.Count-1]);
        }

        private List<string> ReadTagsFromXML()
        {
            XmlDocument XMLDocConfig = new XmlDocument();
            XMLDocConfig.Load("tags.xml");

            List<string> CodesList;
            List<string> TagsList = new List<string>();
            
            TagsCodesList = new List<KeyValuePair<string, List<string>>>();

            foreach (XmlNode Tag in XMLDocConfig.ChildNodes[0].ChildNodes)
            {
                CodesList = new List<string>();

                foreach (XmlAttribute Attribute in Tag.Attributes)
                {
                    if (Attribute.Name.ToString() == "name")
                    {
                        TagsList.Add(Attribute.Value);
                    }
                }

                foreach (XmlNode Code in Tag.ChildNodes)
                {
                    CodesList.Add(Code.InnerText);
                }

                TagsCodesList.Add(new KeyValuePair<string, List<string>>(TagsList.Last(), CodesList));
            }
            
            return TagsList;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            try
            {
                IniFile Ini = new IniFile("coliber.ini", "coliber");
                string ConnectionString = Ini.ReadIni("sqlserver", "ConnectionString");
                OdbcConnection ConnectionToDbOdbc = new OdbcConnection(ConnectionString);
                //ConnectionToDbOdbc.Open();

                for (int i = 0; i < EditMARCUCList.Count; i++)
                {
                    string t = EditMARCUCList[i].GetValueTextBoxText();

                    if (EditMARCUCList[i].GetTagComboBoxText() == "260")
                    {
                        t = t.Substring(t.IndexOf("b\\") + 2);//, t.IndexOf("c\\")).Trim();
                        t = t.Replace(t.Substring(t.IndexOf("c\\")-2), "");
                        MessageBox.Show(t);
                    }
                    //MessageBox.Show();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                
            }
        }

        private void MARCDetailsTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
            if (e.Control && e.KeyCode == Keys.A)
                MARCDetailsTextBox.SelectAll();
        }
    }
}
