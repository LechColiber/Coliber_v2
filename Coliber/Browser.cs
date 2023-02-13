using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coliber
{
    public partial class Browser : Form
    {
        string cUrl;
        public Browser(string cUrlParam)
        {
            InitializeComponent();
            cUrl = cUrlParam;
            //oBrowser.ScriptErrorsSuppressed = true;
            //SuppressScriptErrorsOnly(oBrowser);
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            oBrowser.Navigate(cUrl);
        }

        private void cbOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        /*
        // Hides script errors without hiding other dialog boxes.
        private void SuppressScriptErrorsOnly(WebBrowser browser)
        {
            // Ensure that ScriptErrorsSuppressed is set to false.
            browser.ScriptErrorsSuppressed = false;

            // Handle DocumentCompleted to gain access to the Document object.
            browser.DocumentCompleted +=
                new WebBrowserDocumentCompletedEventHandler(
                    browser_DocumentCompleted);
        }

        private void browser_DocumentCompleted(object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Document.Window.Error +=
                new HtmlElementErrorEventHandler(Window_Error);
        }

        private void Window_Error(object sender,
            HtmlElementErrorEventArgs e)
        {
            // Ignore the error and suppress the error dialog box. 
            e.Handled = true;
        }
        */

    }
}
