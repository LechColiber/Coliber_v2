using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebColiber
{
    public partial class BasketResult : System.Web.UI.UserControl
    {
        public string Text { get { return lblTitle.Text; } set { lblTitle.Text = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}