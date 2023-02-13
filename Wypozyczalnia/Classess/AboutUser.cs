using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class AboutUser : GeneralBase
    {
        private string _name;
        private string _street;
        private string _city;
        private string _zipCode;
        private string _phoneNumber;
        public string Name { get { return _name; } set { _name = value; _currentMode = CreatingMode.Edit; } }
        public string Street { get { return _street; } set { _street = value; _currentMode = CreatingMode.Edit; } }
        public string City { get { return _city; } set { _city = value; _currentMode = CreatingMode.Edit; } }
        public string ZipCode { get { return _zipCode; } set { _zipCode = value; _currentMode = CreatingMode.Edit; } }
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; _currentMode = CreatingMode.Edit; } }

        public AboutUser()
        {
            this.Name = "";
            this.Street = "";
            this.City = "";
            this.ZipCode = "";
            this.PhoneNumber = "";
        }
        public AboutUser(string Name, string Street, string City, string ZipCode, string PhoneNumber)
        {
            this.Name = Name;
            this.Street = Street;
            this.City = City;
            this.ZipCode = ZipCode;
            this.PhoneNumber = PhoneNumber;
        }

        public override void prepareSaveCommand(ref System.Data.SqlClient.SqlCommand command, object onwer)
        {
            // Name
            command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_c_edycja 'biblioteka_nazwa', @biblioteka_nazwa{0}; ", this.HashCode);
            command.Parameters.AddWithValue("@biblioteka_nazwa" + this.HashCode, _name);

            // Street
            command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_c_edycja 'biblioteka_ulica', @biblioteka_ulica{0}; ", this.HashCode);
            command.Parameters.AddWithValue("@biblioteka_ulica" + this.HashCode, _street);

            // City
            command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_c_edycja 'biblioteka_miasto', @biblioteka_miasto{0}; ", this.HashCode);
            command.Parameters.AddWithValue("@biblioteka_miasto" + this.HashCode, _city);

            // ZipCode
            command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_c_edycja 'biblioteka_kod', @biblioteka_kod{0}; ", this.HashCode);
            command.Parameters.AddWithValue("@biblioteka_kod" + this.HashCode, _zipCode);

            // PhoneNumber
            command.CommandText += string.Format("EXEC w2_wartosc_konfiguracyjna_c_edycja 'biblioteka_numer_telefonu', @biblioteka_numer_telefonu{0}; ", this.HashCode);
            command.Parameters.AddWithValue("@biblioteka_numer_telefonu" + this.HashCode, _phoneNumber);            
        }
    }
}
