using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebColiber.App_GlobalResources;

namespace WebColiber
{
    public partial class Result : System.Web.UI.UserControl
    {
        public bool Checked { get { return chkOrder.Checked; } set { chkOrder.Checked = value; } }
        public Entry Entry
        {
            get { return _entry; }
            set
            {
                _entry = value;

                if (Entry.Type == WebColiber.Entry.EntryType.Book || Entry.Type == WebColiber.Entry.EntryType.Magazine || Entry.Type == WebColiber.Entry.EntryType.Article)
                    lblTitle.Text = "<a href=\"Details.aspx?id=" + _entry.Id + "&type=" + Entry.Type.ToString() + "\">" + _entry.Title + "</a>";
                else
                    lblTitle.Text = _entry.Title;

                lblIndex.Text = _entry.Index.ToString();

                lblAvailableCopies.Text = _entry.NumberOfCopies.ToString() + " " + Language.cpy;

                if (_entry.NumberOfCopies == 0)
                    lblAvailableCopies.ForeColor = System.Drawing.Color.Red;
                else
                    lblAvailableCopies.ForeColor = System.Drawing.Color.Green;

                if (Entry.Type == WebColiber.Entry.EntryType.None || Entry.Type == WebColiber.Entry.EntryType.MagazineNumber)
                    lblAvailableCopies.Visible = false;
            }
        }

        private Entry _entry;

        protected void Page_Load(object sender, EventArgs e)
        {
            chkOrder.Visible = ((Entry.Type == WebColiber.Entry.EntryType.Book) || (Entry.Type == WebColiber.Entry.EntryType.MagazineNumber)) && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string);
            //chkOrder.Visible = ((Entry.Type == WebColiber.Entry.EntryType.Book)) && Boolean.Parse(HttpContext.Current.Session["CanOrder"] as string);
            if (Entry.Type == WebColiber.Entry.EntryType.None)
                lblIndex.Visible = false;
            else
                lblIndex.Visible = true;
        }
    }
}