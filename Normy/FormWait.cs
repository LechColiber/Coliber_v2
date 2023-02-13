using System.Windows.Forms;

namespace Normy
{
    public partial class FormWait : Form
    {
        public FormWait(string cMsg="Proszę czekać...")
        {
            InitializeComponent();
            SetMessage(cMsg);
        }
        public void SetMessage(string cMsg)
        {
            lMsg.Text = cMsg;
        }
    }
}
