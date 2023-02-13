using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Akcesja.UserControls
{
    public partial class SeparateNumbersGridUC : UserControl
    {
        public string ID_volumes {get { return id_volumes; }}
        public DataGridView NumbersDGV { get { return numbersDGV; } }
        
        private string id_volumes;
        private bool controlIsPressed;
        private bool leftButtonIsPressed;
        private int rowIndex;
   
        public SeparateNumbersGridUC()
        {
            InitializeComponent();            

            controlIsPressed = false;
            rowIndex = -1;
            setControlsText();
        }
        public SeparateNumbersGridUC(string id_volumes, int year, string volumin, string kod_akcesja) : this()
        {
            SetUC(id_volumes, year, volumin, kod_akcesja);
            setControlsText();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(numerDGVC, "numbers");

            CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name);
        }

        public void SetUC(string id_volumes, int year, string volumin, string kod_akcesja)
        {
            this.id_volumes = id_volumes;

            numerDGVC.HeaderText = volumin + "/" + year;

            GetData(id_volumes, year, kod_akcesja);
        }

        private void GetData(string id_volumes, int year, string kod_akcesja)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Akcesja_ListaNumerowWoluminu @id_volumes, @rok, @kod_akcesja; ";
            Command.Parameters.AddWithValue("@id_volumes", id_volumes);
            Command.Parameters.AddWithValue("@rok", year);
            Command.Parameters.AddWithValue("@kod_akcesja", kod_akcesja);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                numbersDGV.Rows.Add(Dt.Rows[i]["id_czasop_n"], Dt.Rows[i]["numer"], id_volumes, Dt.Rows[i]["number_to_sort"]);
            }
        }

        private void numbersDGV_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewSelectedRowCollection)))
                e.Effect = DragDropEffects.Move;
            else 
                e.Effect = DragDropEffects.None;
        }

        private void numbersDGV_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewSelectedRowCollection)))
            {
                foreach (DataGridViewRow row in (DataGridViewSelectedRowCollection)e.Data.GetData(typeof(DataGridViewSelectedRowCollection)))
                {
                    if (row.DataGridView.Equals(numbersDGV))
                        continue;                    

                    row.DataGridView.Rows.Remove(row);
                    numbersDGV.Rows.Add(row);
                }                
            }
        }

        private void numbersDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            numbersDGV.Sort(numberToSortDGVC, ListSortDirection.Ascending);
        } 

        private void numbersDGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                leftButtonIsPressed = true;

            rowIndex = e.RowIndex;
        }

        private void numbersDGV_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                leftButtonIsPressed = false;
        }

        private void numbersDGV_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
             e.Handled = true;
             e.SortResult = Compare((string)e.CellValue1, (string)e.CellValue2);
        }

        private int Compare(string o1, string o2)
        {
            o1 = o1.Substring(0, o1.IndexOf('/') > 0 ? o1.IndexOf('/') : o1.Length);
            o2 = o2.Substring(0, o2.IndexOf('/') > 0 ? o2.IndexOf('/') : o2.Length);

            int o1Int = 0;
            int o2Int = 0;

            Int32.TryParse(o1, out o1Int);
            Int32.TryParse(o2, out o2Int);

            return o1Int.CompareTo(o2Int);
        }

        private void numbersDGV_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (numbersDGV.SelectedRows.Count > 0 && leftButtonIsPressed)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (rowIndex >= 0)
                        numbersDGV.Rows[rowIndex].Selected = true;//!numbersDGV.Rows[rowIndex].Selected;

                    rowIndex = -1;

                    numbersDGV.DoDragDrop(numbersDGV.SelectedRows, DragDropEffects.Move);
                }
            }
        }       
    }
}
