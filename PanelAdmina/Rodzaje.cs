using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace WindowsFormsApplication1
{
    public partial class Rodzaje : Form
    {
        Connection NewConnection;

        public int rodzaj = 1;
        DataTable Dt;
        List<string> List;

        public Rodzaje(Connection NewConnection)
        {
            InitializeComponent();

            this.NewConnection = NewConnection;

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void Type_Load(object sender, EventArgs e)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT id_rodzaj, LTRIM(RTRIM(nazwa)) AS [nazwa] FROM dbo.rodzaje";

                OdbcDataReader Reader = Command.ExecuteReader();
                Dt = new DataTable();
                Dt.Load(Reader);
                Reader.Close();

                List = new List<string>();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    List.Add(Dt.Rows[i][1].ToString());
                }
                List.Sort();
                listBox1.DataSource = List;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anulować?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Dt.Rows[i][1].ToString() == listBox1.SelectedValue.ToString())
                    rodzaj = Int32.Parse(Dt.Rows[i][0].ToString());
            }
        }

        private void Rodzaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
