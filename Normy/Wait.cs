using System.Windows.Forms;

namespace Normy
{
    public partial class Wait : Form
    {
        public Wait(string cMsg="Proszę czekać...")
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
