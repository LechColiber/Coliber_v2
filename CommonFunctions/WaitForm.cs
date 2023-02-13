using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

public partial class WaitForm : Form
{
    public WaitForm()
    {           
        InitializeComponent();
        //this.CenterToParent();
        this.CenterToScreen();

        setControlsText();
    }

    private void setControlsText()
    {
        var mapping = new Dictionary<Object, string>();
        mapping.Add(label1, "please_wait");

        CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name);
    }
}
