using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebColiber.App_GlobalResources;
using System.Diagnostics;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.Threading;
using System.Globalization;

namespace WebColiber
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {        
        public static string Name;
        
        public static string Name1;

        protected void Page_Init(object sender, EventArgs e)
        {
            /*if (Settings.OrderMethod == 1)
            {
                NavigationMenu.Items.RemoveAt(3);
            }

            if (!Settings.CanOrder)
            {          
                if (NavigationMenu.Items.Count > 3)    
                    NavigationMenu.Items.RemoveAt(3);

                NavigationMenu.Items.RemoveAt(2);
                NavigationMenu.Items.RemoveAt(1);
            }*/
            Name1 = "";
            //this.Name = Session["CurrentName"] as string;
            Name = Session["CurrentName"] as string;

            /*if (this.Name == null)
                this.Name = "";*/
            if (Name == null)
                Name = "";

            if ((Session["CurrentLogin"] as string) == null)
                Session["CurrentLogin"] = "";

            //if (this.Name.Trim().ToLower() != Page.User.Identity.Name.Trim().ToLower())
            if ((Session["CurrentLogin"] as string).Trim().ToLower() != Page.User.Identity.Name.Trim().ToLower())
            {
                string[] temp = (Page.User.Identity.Name).Split('\\');

                if (Settings.IsDomain)
                {
                    try
                    {
                        PrincipalContext PContext = new PrincipalContext(ContextType.Domain);
                        UserPrincipal UserP = new UserPrincipal(PContext);

                        if (temp.Length > 1)
                            UserP = UserPrincipal.FindByIdentity(PContext, temp[1]);
                        
                        //this.Name = UserP.Name;                        
                        Name = UserP.Name;
                    }
                    catch (Exception Ex)
                    {

                    }
                }
                else
                {
                    //this.Name = Page.User.Identity.Name;
                    Name = Page.User.Identity.Name;
                }

                //Session["CurrentName"] = this.Name;
                Session["CurrentName"] = Name;
                Session["CurrentLogin"] = Page.User.Identity.Name;
            }

            //if (Page.User.Identity.Name != null && Page.User.Identity.Name != "" && Page.User.Identity.Name.Length > 0)
            if (!string.IsNullOrEmpty(Page.User.Identity.Name))
                Settings.GetSettinsgFromDb(Page.User.Identity.Name);
                //Settings.GetSettinsgFromDb("damian");
            else
                Settings.GetSettingsFromDb();            

            //this.Name = Page.User.Identity.Name;

            //this.Name = HttpContext.Current.Session["Name"] as string;// +" " + HttpContext.Current.Session["UserID"] as string + " " + Page.User.Identity.Name;//+ Name1;// +Page.User.Identity.Name;

            //this.Name += Name1;

            string cUser;
            cUser = Page.User.Identity.Name;
            if (cUser==null || cUser=="")
            {
                string pageUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                SiteMaster.Name = pageUser + " - niezalogowany!";
            }
            else
            {

            
            if ((HttpContext.Current.Session["Deleted"] as string).Trim().ToLower() == "true" && Int32.Parse((HttpContext.Current.Session["UserID"] as string)) != -1)
                SiteMaster.Name = SiteMaster.Name + " (" + Language.userDeleted + ")";
            else if ((HttpContext.Current.Session["Banned"] as string).Trim().ToLower() == "true" && Int32.Parse((HttpContext.Current.Session["UserID"] as string)) != -1)
                SiteMaster.Name = SiteMaster.Name + " (" + Language.banned + ")";
            
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string cLang;
            ddLang.Visible = Settings.changeLang;
            if (!ddLang.Visible) return;
            cLang = ddLang.SelectedValue;
            if (IsPostBack)
            {
                if ((string)HttpContext.Current.Session["Lang"] != cLang)
                {
                    HttpContext.Current.Session["Lang"] = cLang;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(ddLang.SelectedValue);
                    Response.Redirect(Request.RawUrl);
                }
            }
            else ddLang.SelectedValue = Thread.CurrentThread.CurrentCulture.Name;
        }
    }
}
