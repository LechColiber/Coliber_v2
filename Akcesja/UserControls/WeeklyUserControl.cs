using System;

namespace Akcesja
{
    public partial class WeeklyUserControl : BaseFreqUserControl// UserControl
    {
        public WeeklyUserControl(string Title, int Year, string AkcesjaCode, string CzasopCode, int RadioMode, int VolumesMode, string Sygnatura, string id_cza_syg)
            : base(Title, Year, AkcesjaCode, CzasopCode, RadioMode, "Week", VolumesMode, 53, Sygnatura, id_cza_syg)
        {
            InitializeComponent();

            Render();

            GetData();
            setControlsText();
        }

        private void LoadData(object sender, EventArgs e)
        {
            base.LoadData(sender, e);
        }

        public void Render()
        {
            OrderWeek53Label.Visible = true;
            Week53Label.Visible = true;
            base.MaxKol = 53;
        }
    }
}
