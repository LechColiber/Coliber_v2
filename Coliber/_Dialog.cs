using System;
using System.Windows.Forms;
using System.Data;

namespace Coliber
{
    public class _Dialog : Form
    {
        protected DataRow Master;
        protected TabPage pagMain = null;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // _Dialog
            // 
            this.ClientSize = new System.Drawing.Size(560, 331);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "_Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        protected void FillControls()
        {
            //txNr_normy.Text = App.NVL(Master["nr_normy"]);

            foreach (Control C in pagMain.Controls)
            {
                string cName, cVal;
                DateTime tData, tEmpty;
                tEmpty = new DateTime(1901, 1, 1);
                cName = C.Name.Substring(2);
                if (C.GetType() == typeof(TextBox) || C.GetType() == typeof(MaskedTextBox))
                {
                    cVal = App.NVL(Master[cName]);
                    C.Text = cVal;
                }
                if (C.GetType() == typeof(NullableDTP))
                {
                    NullableDTP dpC = (NullableDTP)C;
                    tData = App.DBDateT(Master[cName]);
                    if (tData == tEmpty)
                    {
                        tData = DateTime.MinValue;
                    }
                    dpC.Value = tData;
                }
            }
        }

        protected void SaveControls()
        {
            //txNr_normy.Text = App.NVL(Master["nr_normy"]);
            foreach (Control C in pagMain.Controls)
            {
                string cName, cVal;
                //int iVal;
                cName = C.Name.Substring(2);
                if (C.GetType() == typeof(TextBox) || C.GetType() == typeof(MaskedTextBox))
                {

                    cVal = App.NVL(Master[cName]);
                    if (cVal != C.Text) Master[cName] = C.Text;

                    /*
                    //MessageBox.Show(cName + "\n" + Master[cName].DataType.ToString());
                    if (Master[cName].DataType.ToString() == "System.String")
                    {
                        cVal = App.NVL(Master[cName]);
                        if (cVal != C.Text) Master[cName] = C.Text;
                    }
                    if (Master[cName].DataType.ToString() == "System.Int32")
                    {
                        iVal = App.DBInt(Master[cName]);
                        if (iVal != Int32.Parse(C.Text)) Master[cName] = Int32.Parse(C.Text);
                    }
                    */

                }
                else if (C.GetType() == typeof(NullableDTP))
                {
                    //MessageBox.Show(cName + "\n" + Master[cName].DataType.ToString());
                    NullableDTP dpC = (NullableDTP)C;
                    if (dpC.Value == null )
                    {
                        if (Master[cName] != DBNull.Value)
                            Master[cName] = DBNull.Value;
                    }
                    else if (dpC.Value.ToString() != Master[cName].ToString())
                    {
                        Master[cName] = dpC.Value;
                    }
                }
            }
        }

        protected TabPage getMainPage()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType().Name == "TabPage" && c.Name == "pagMain")
                {
                    return (TabPage)c;
                }
            }
            return null;
        }

        protected bool Edited()
        {
            //txNr_normy.Text = App.NVL(Master["nr_normy"]);
            foreach (Control C in pagMain.Controls)
            {
                string cName, cVal;
                //int iVal;
                cName = C.Name.Substring(2);
                if (C.GetType() == typeof(TextBox) || C.GetType() == typeof(MaskedTextBox))
                {
                    cVal = App.NVL(Master[cName]);
                    if (cVal != C.Text) return true;
                }
                else if (C.GetType() == typeof(NullableDTP))
                {
                    NullableDTP dpC = (NullableDTP)C;
                    if (dpC.Value == null)
                    {
                        if (Master[cName] != DBNull.Value)
                            return true;
                    }
                    else if (dpC.Value.ToString() != Master[cName].ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected virtual bool ValidateDialog()
        {
            return true;
        }

        protected void OK()
        {
            if (!ValidateDialog()) return;
            if (Edited()) SaveControls();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected void Cancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
