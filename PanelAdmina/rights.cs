using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Rights : Form
    {
        Connection NewConnection;

        string Table = "dbo.prawa";
        string UserTable = "dbo.login";
        string UserID = "";

        List<string> UserList;
        string[] UserRightsList;
        List<string> OtherRightsList;
        string[,] AllRights;

        public string RightsList;

        public Rights(string RightsList, Connection NewConnection, string UserID)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;

            this.NewConnection = NewConnection;
            this.UserID = UserID;
            this.RightsList = RightsList;
        }

        private void Rights_Load(object sender, EventArgs e)
        {
            try
            {
                OdbcCommand OtherRightsCommand = new OdbcCommand();
                OtherRightsCommand.CommandText = "SELECT id AS [ID], RTRIM(LTRIM(prawo)) AS [Prawo] FROM " + this.Table + " ORDER BY prawo";
                OtherRightsCommand.Connection = NewConnection.AppConnection;
                OdbcDataReader Reader = OtherRightsCommand.ExecuteReader();
                DataTable Dt = new DataTable();
                Dt.Load(Reader);
                Reader.Close();

                UserRightsList = RightsList.Split(',');
                UserList = new List<string>();


                AllRights = new String[Dt.Rows.Count, 2];

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    AllRights[i, 0] = Dt.Rows[i]["Prawo"].ToString();
                    AllRights[i, 1] = Dt.Rows[i]["ID"].ToString();
                }

                for (int i = 0; i < UserRightsList.Length; i++)
                {
                    for (int j = 0; j < Dt.Rows.Count; j++)
                    {
                        string temp = Dt.Rows[j]["ID"].ToString().Trim();

                        if (UserRightsList[i].Trim() == temp)
                        {
                            UserList.Add(Dt.Rows[j]["Prawo"].ToString());
                            break;
                        }
                    }
                }

                OtherRightsList = new List<string>();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    OtherRightsList.Add(Dt.Rows[i]["Prawo"].ToString());
                }

                for (int i = 0; i < OtherRightsList.Count; i++)
                {
                    for (int j = 0; j < UserList.Count; j++)
                    {
                        if (OtherRightsList[i].Trim() == UserList[j].Trim())
                        {
                            OtherRightsList.RemoveAt(i);
                            i--;
                            break;
                        }
                    }
                }

                listBox1.DataSource = OtherRightsList;
                listBox1.Update();

                UserList.Sort();
                listBox2.DataSource = UserList;
                listBox2.Update();
            }
            catch (OdbcException Ex)
            {
                MessageBox.Show(Ex.Message);

                this.Dispose();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                this.Dispose();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                UserList.Add(listBox1.SelectedItem.ToString());
                OtherRightsList.Remove(listBox1.SelectedItem.ToString());

                listBox1.DataSource = null;
                listBox1.DataSource = OtherRightsList;

                UserList.Sort();
                listBox2.DataSource = null;
                listBox2.DataSource = UserList;
            }
            catch
            {

            }

            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;

            listBox2.ClearSelected();
            //listBox1.ClearSelected();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anulować?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                this.Dispose();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            RightsList = "";
                

            for (int i = 0; i < UserList.Count; i++)
            {
                for (int j = 0; j < AllRights.Length/2; j++)
                {
                    if (UserList[i] == AllRights[j, 0])
                        RightsList += AllRights[j, 1] + ",";
                }
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                UserList.Remove(listBox2.SelectedItem.ToString());
                OtherRightsList.Add(listBox2.SelectedItem.ToString());

                OtherRightsList.Sort();
                listBox1.DataSource = null;
                listBox1.DataSource = OtherRightsList;

                listBox2.DataSource = null;
                listBox2.DataSource = UserList;
            }
            catch
            {

            }

            if (listBox2.Items.Count > 0)
                listBox2.SelectedIndex = 0;

            listBox1.ClearSelected();
            //listBox2.ClearSelected();
        }

        private void AddAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                try
                {
                    UserList.Add(listBox1.Items[i].ToString());
                    OtherRightsList.Remove(listBox1.Items[i].ToString());
                }
                catch
                {

                }
            }

            UserList.Sort();
            listBox1.DataSource = null;
            listBox1.DataSource = OtherRightsList;

            listBox2.DataSource = null;
            listBox2.DataSource = UserList;
        }

        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                try
                {
                    UserList.Remove(listBox2.Items[i].ToString());
                    OtherRightsList.Add(listBox2.Items[i].ToString());
                }
                catch
                {

                }
            }

            OtherRightsList.Sort();
            listBox1.DataSource = null;
            listBox1.DataSource = OtherRightsList;

            listBox2.DataSource = null;
            listBox2.DataSource = UserList;
        }

        private void AddOneButton_Click(object sender, EventArgs e)
        {
            List<string> SelectedList = new List<string>();

            foreach (string Item in listBox1.SelectedItems)
                SelectedList.Add(Item.ToString());

            foreach (string Item in SelectedList)
            {
                try
                {
                    UserList.Add(Item);
                    OtherRightsList.Remove(Item);
                }
                catch
                {

                }

                UserList.Sort();
                listBox1.DataSource = null;
                listBox1.DataSource = OtherRightsList;

                listBox2.DataSource = null;
                listBox2.DataSource = UserList;

                if (listBox1.Items.Count > 0)
                    listBox1.SelectedIndex = 0;

                listBox2.ClearSelected();
                //listBox1.ClearSelected();
            }
        }

        private void DeleteOneBbutton_Click(object sender, EventArgs e)
        {
            List<string> SelectedList = new List<string>();

            foreach (string Item in listBox2.SelectedItems)
                SelectedList.Add(Item.ToString());

            foreach (string Item in SelectedList)
            {
                try
                {
                    UserList.Remove(Item);
                    OtherRightsList.Add(Item);
                }
                catch
                {

                }

                OtherRightsList.Sort();
                listBox1.DataSource = null;
                listBox1.DataSource = OtherRightsList;

                listBox2.DataSource = null;
                listBox2.DataSource = UserList;

                if (listBox2.Items.Count > 0)
                    listBox2.SelectedIndex = 0;

                listBox1.ClearSelected();
                //listBox2.ClearSelected();
            }
        }

        private void Rights_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }
    }
}
