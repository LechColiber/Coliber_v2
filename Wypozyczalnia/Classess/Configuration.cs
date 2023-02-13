using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class Configuration : GeneralBase
    {
        private ReverseMode _reverse;
        private SearchFieldMode _autoSearchField;
        private SearchFieldMode _manualSearchField;
        private CompareMode _compare;
        private SortFields _sort1, _sort2, _sort3, _sort4;
        private RequiredNotLockedUserForBorrowMode _requiredNotLockedUserForBorrow;
        private bool _showBarcodeColumn;
        private AboutUser _informationAboutUser;
        public ReverseMode Reverse { get { return _reverse; } set { _reverse = value; _currentMode = CreatingMode.Edit; } }
        public enum ReverseMode { Auto = 0, Semiauto = 1, Manual = 2};
        public SearchFieldMode AutoSearchField { get { return _autoSearchField; } set { _autoSearchField = value; _currentMode = CreatingMode.Edit; } }
        public SearchFieldMode ManualSearchField { get { return _manualSearchField; } set { _manualSearchField = value; _currentMode = CreatingMode.Edit; } }
        public enum SearchFieldMode { Title = 0, Signature = 1, InvertoryNo = 2, Barcode = 3 };
        public CompareMode Compare { get { return _compare; } set { _compare = value; _currentMode = CreatingMode.Edit; } }
        public enum CompareMode { Equals = 0, StartsWith = 1, Contains = 2 };
        public SortFields Sort1 { get { return _sort1; } set { _sort1 = value; _currentMode = CreatingMode.Edit; } }
        public SortFields Sort2 { get { return _sort2; } set { _sort2 = value; _currentMode = CreatingMode.Edit; } }
        public SortFields Sort3 { get { return _sort3; } set { _sort3 = value; _currentMode = CreatingMode.Edit; } }
        public SortFields Sort4 { get { return _sort4; } set { _sort4 = value; _currentMode = CreatingMode.Edit; } }        
        public enum SortFields { None = 0, Signature = 1, InvertoryNo = 2, Title = 3, Author = 4 };
        public RequiredNotLockedUserForBorrowMode RequiredNotLockedUserForBorrow { get { return _requiredNotLockedUserForBorrow; } set { _requiredNotLockedUserForBorrow = value; _currentMode = CreatingMode.Edit; } }
        public enum RequiredNotLockedUserForBorrowMode { No = 0, Yes = 1 };
        public bool ShowBarcodeColumn { get { return _showBarcodeColumn; } set { _showBarcodeColumn = value; _currentMode = CreatingMode.Edit; } }
        public AboutUser InformationAboutUser { get { return _informationAboutUser; } set { _informationAboutUser = value; _currentMode = CreatingMode.Edit; } }

        public Configuration()
        {
            // reverse
            Reverse = ReverseMode.Auto;

            // manual search field
            ManualSearchField = SearchFieldMode.Title;

            // auto search field
            AutoSearchField = SearchFieldMode.Title;

            // compare
            Compare = CompareMode.Equals;

            // sort
            Sort1 = SortFields.None;
            Sort2 = SortFields.None;
            Sort3 = SortFields.None;
            Sort4 = SortFields.None;

            // is require user is not locked
            RequiredNotLockedUserForBorrow = RequiredNotLockedUserForBorrowMode.No;

            ShowBarcodeColumn = true;

            _informationAboutUser = new AboutUser();
        }

        public override void prepareSaveCommand(ref System.Data.SqlClient.SqlCommand command, object owner)
        {
            if (_informationAboutUser.CurrentMode == CreatingMode.Edit || _informationAboutUser.CurrentMode == CreatingMode.New)
                _currentMode = CreatingMode.Edit;

            if (_currentMode != CreatingMode.Edit)
                return;

            // reverse
            command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_n_edycja 'drukowanie_rewersu', @wartosc_rewers{0}; ", this.HashCode);
            command.Parameters.AddWithValue("@wartosc_rewers" + this.HashCode, (int)Reverse);

            // manual search field
            command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_n_edycja 'pole_wyszukiwania', @wartosc_wyszukiwanie{0}; ", this.HashCode);
            command.Parameters.AddWithValue("@wartosc_wyszukiwanie" + this.HashCode, (int)ManualSearchField);

            // auto search
            command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_n_edycja 'pole_autowyszukiwania', @wartosc_autowyszukiwanie{0}; ", this.HashCode);
            command.Parameters.AddWithValue("@wartosc_autowyszukiwanie" + this.HashCode, (int)AutoSearchField);

            // compare
            command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_n_edycja 'sposob_porownania', @wartosc_porownanie{0}; ", this.HashCode);
            command.Parameters.AddWithValue("@wartosc_porownanie" + this.HashCode, (int)Compare);

            // sort
            if (Sort1 != SortFields.None)
            {
                command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_n_edycja 'sortowanie1', @sort1_{0}; ", this.HashCode);
                command.Parameters.AddWithValue("@sort1_" + this.HashCode, (int)Sort1);
            }
            else
                command.CommandText += "EXEC w2_wartosc_konfiguracyjna_usun 'sortowanie1'; ";

            if (Sort2 != SortFields.None)
            {
                command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_n_edycja 'sortowanie2', @sort2_{0}; ", this.HashCode);
                command.Parameters.AddWithValue("@sort2_" + this.HashCode, (int)Sort2);
            }
            else
                command.CommandText += "EXEC w2_wartosc_konfiguracyjna_usun 'sortowanie2'; ";

            if (Sort3 != SortFields.None)
            {
                command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_n_edycja 'sortowanie3', @sort3_{0}; ", this.HashCode);
                command.Parameters.AddWithValue("@sort3_" + this.HashCode, (int)Sort3);
            }
            else
                command.CommandText += "EXEC w2_wartosc_konfiguracyjna_usun 'sortowanie3'; ";

            if (Sort4 != SortFields.None)
            {
                command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_n_edycja 'sortowanie4', @sort4_{0}; ", this.HashCode);
                command.Parameters.AddWithValue("@sort4_" + this.HashCode, (int)Sort4);
            }
            else
                command.CommandText += "EXEC w2_wartosc_konfiguracyjna_usun 'sortowanie4'; ";

            // is require user is not locked
            command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_n_edycja 'wymagany_odblokowany_uzytkownik', @wymagany_odblokowany_uzytkownik{0}; ", this.HashCode);
            command.Parameters.AddWithValue("@wymagany_odblokowany_uzytkownik" + this.HashCode, (int)RequiredNotLockedUserForBorrow);

            // ShowBarcodeColumn
            command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_l_edycja 'pokaz_kod_kreskowy', @pokaz_kod_kreskowy{0}; ", this.HashCode);
            command.Parameters.AddWithValue("@pokaz_kod_kreskowy" + this.HashCode, ShowBarcodeColumn);

            // AboutUser
            _informationAboutUser.prepareSaveCommand(ref command, null);
        }
    }
}
