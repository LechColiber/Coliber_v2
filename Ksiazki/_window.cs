using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

    public class _Window : Form
    {
        DataTable dtNapisy = null;
        //
        public void WriteCaptions()
        {
            if (dtNapisy == null)
            {
                dtNapisy = new DataTable();
                dtNapisy.Columns.Add(new DataColumn("Object", typeof(string)));
                dtNapisy.Columns.Add(new DataColumn("Pol", typeof(string)));
                dtNapisy.Columns.Add(new DataColumn("FName", typeof(string)));
                dtNapisy.Columns.Add(new DataColumn("Type", typeof(string)));
            }
            GetControls((Control)this, "");
            dtNapisy.TableName = "dtNapisyN";
            dtNapisy.WriteXml(@"C:\Program\Exell\NET\Lang\1" + this.Name + ".XML");
            MessageBox.Show("1850");
        }

        //
        public void GetControls(Control ctrl, string FName)
        {
            //dtNapisy.Rows.Add(ctrl.Name, ctrl.Text, FName+"$", ctrl.GetType().ToString());
            if (ctrl.GetType().ToString() == "System.Windows.Forms.TextBox") return;
            else if (ctrl.GetType().ToString() == "System.Windows.Forms.DataGridView")
            {
                foreach (DataGridViewColumn col in ((DataGridView)ctrl).Columns) dtNapisy.Rows.Add(col.Name, col.HeaderText, FName, "column");
            }
            else if (ctrl != null && ctrl.HasChildren && ctrl.Controls.Count > 0)
            {
                dtNapisy.Rows.Add(ctrl.Name, ctrl.Text, FName + "$", ctrl.GetType().ToString());
                foreach (Control ctrl1 in ctrl.Controls) GetControls(ctrl1, FName + (FName == "" ? "" : ".") + ctrl1.Parent.Name);
            }
            else
            {
                if (ctrl.Text == "") return;
                else dtNapisy.Rows.Add(ctrl.Name, ctrl.Text, FName, ctrl.GetType().ToString());
            }
        }

    }
