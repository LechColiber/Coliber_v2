using System;

namespace Akcesja
{
    public partial class BiWeeklyUserControl : BaseFreqUserControl
    {
        public BiWeeklyUserControl(string Title, int Year, string AkcesjaCode, string CzasopCode, int RadioMode, int VolumesMode, string Sygnatura, string id_cza_syg)
            : base(Title, Year, AkcesjaCode, CzasopCode, RadioMode, "Week", VolumesMode, 27, Sygnatura, id_cza_syg)
        {
            InitializeComponent();

            GetData();
            setControlsText();
        }

        private void LoadData(object sender, EventArgs e)
        {
            base.LoadData(sender, e);
        }
    }
}
