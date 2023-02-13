using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using WebColiber.App_GlobalResources;

namespace WebColiber
{
    public partial class SearchBox : System.Web.UI.UserControl
    {
        /*public string Phrase1 { get { return txtPhrase1.Text; } set { txtPhrase1.Text = value; } }
        public string Phrase2 { get { return txtPhrase2.Text; } set { txtPhrase2.Text = value; } }
        public string Phrase3 { get { return txtPhrase3.Text; } set { txtPhrase3.Text = value; } }*/

        /*public string Type1 { get { return dropType1.SelectedValue; } set { dropType1.SelectedIndex = dropType1.Items.IndexOf(dropType1.Items.FindByValue(value)); } }
        public string Type2 { get { return dropType2.SelectedValue; } set { dropType2.SelectedIndex = dropType2.Items.IndexOf(dropType2.Items.FindByValue(value)); } }
        public string Type3 { get { return dropType3.SelectedValue; } set { dropType2.SelectedIndex = dropType2.Items.IndexOf(dropType2.Items.FindByValue(value)); } }*/

        /*public string Type1 { get { return Type1HiddenField.Value; } set { dropType1.SelectedIndex = dropType1.Items.IndexOf(dropType1.Items.FindByValue(value)); } }
        public string Type2 { get { return Type2HiddenField.Value; } set { dropType2.SelectedIndex = dropType2.Items.IndexOf(dropType2.Items.FindByValue(value)); } }
        public string Type3 { get { return Type3HiddenField.Value; } set { dropType2.SelectedIndex = dropType2.Items.IndexOf(dropType2.Items.FindByValue(value)); } }
        public string Type4 { get { return Type4HiddenField.Value; } set { dropType2.SelectedIndex = dropType2.Items.IndexOf(dropType2.Items.FindByValue(value)); } }
        public string Type5 { get { return Type5HiddenField.Value; } set { dropType2.SelectedIndex = dropType2.Items.IndexOf(dropType2.Items.FindByValue(value)); } }*/

        public string Path { get { return dropPath.SelectedValue; } set { dropPath.SelectedIndex = dropPath.Items.IndexOf(dropPath.Items.FindByValue(value)); } }

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Settings.Books)
            {
                if (dropPath.Items.FindByText(Language.books) != null)
                    dropPath.Items.Remove(dropPath.Items.FindByText(Language.books));
            }
            if (!Settings.Magazines)
            {
                if (dropPath.Items.FindByText(Language.magazines) == null)
                    dropPath.Items.Remove(dropPath.Items.FindByText(Language.magazines));
            }
            if (!Settings.Articles)
            {
                if (dropPath.Items.FindByText(Language.articles) == null)
                    dropPath.Items.Remove(dropPath.Items.FindByText(Language.articles));     
            }
            if (!Settings.Normy)
            {
                if (dropPath.Items.FindByText("Normy") == null)
                    dropPath.Items.Remove(dropPath.Items.FindByText("Normy"));
            }

            LangDDL.Items.AddRange(Search.GetLanguagesList().ToArray());
            CountryDDL.Items.AddRange(Search.GetCountriesList().ToArray());
            FreqDDL.Items.AddRange(Search.GetFreqList().ToArray());
        }    
    }
}