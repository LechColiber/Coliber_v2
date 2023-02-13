using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using System.Globalization;
using System.Security.Principal;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Web.UI;
using System.Resources;

namespace WebColiber
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {

            Settings.SetSettings();

            //App_GlobalResources.Language.Culture = new CultureInfo(Settings.Localization);

            Settings.CacheStopWatch = new System.Diagnostics.Stopwatch();
            Settings.CacheStopWatch.Start();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            Settings.GetSettingsFromDb();
            //HttpContext.Current.Session["Lang"] = Thread.CurrentThread.CurrentCulture.Name;
            HttpContext.Current.Session["Lang"] = Settings.Localization;
            HttpContext.Current.Session["Start"] = DateTime.Now.ToString();

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (context != null && context.Session != null)
            {
                string culture = (string)HttpContext.Current.Session["Lang"];
                if (culture != null && culture != "")
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
                    Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                }
            }
        }

        public void WindowsAuthentication_OnAuthenticate(object sender, WindowsAuthenticationEventArgs args)
        {
           /* if (!args.Identity.IsAnonymous)
            {
                try
                {
                    string[] temp = (args.Identity.Name).Split('\\');

                    DirectoryEntry DE;

                    if (temp.Length > 0)
                    {
                        DE = new DirectoryEntry("LDAP://" + temp[0]);

                    }
                    else
                        DE = new DirectoryEntry("LDAP://");
                    
                    /*PrincipalContext PContext = new PrincipalContext(ContextType.Domain);

                    UserPrincipal UserP = UserPrincipal.FindByIdentity(PContext, temp[1]);*/
                    
               /* }
                catch (Exception Ex)
                {
                    //SiteMaster.Name1 = Ex.Message;
                }
            }*/
        }

    }
}
