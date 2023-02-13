using System.Data.SqlClient;

namespace Wypozyczalnia
{
    public abstract class Address : GeneralBase
    {
        // private class fields
        private int _addressId;
        private int _addressType;
        private string _place;
        private string _street;
        private string _houseNo;
        private string _localNo;
        private string _zip;
        private string _postOffice;
        private bool _isActive;
        private string _comments;        

        public enum UserType
        {
            Employee,
            User
        };

        // public accessors
        public int AddressId
        {
            get { return _addressId; }            
        }

        public int AddressType
        {
            get { return _addressType; }
            set
            {
                _addressType = value;
                SetChanged();
            }
        }

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                SetChanged();
            }
        }

        public string HouseNo
        {
            get { return _houseNo; }
            set
            {
                _houseNo = value;
                SetChanged();
            }
        }

        public string LocalNo
        {
            get { return _localNo; }
            set
            {
                _localNo = value;
                SetChanged();
            }
        }

        public string Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                SetChanged();
            }
        }

        public string Place
        {
            get { return _place; }
            set
            {
                _place = value;
                SetChanged();
            }
        }

        public string PostOffice
        {
            get { return _postOffice; }
            set
            {
                _postOffice = value;
                SetChanged();
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                SetChanged();
            }
        }

        public string Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                SetChanged();
            }
        }

        protected Address()
        {
            _addressId = -1;            
            _addressType = -1;
            _street = "";
            _houseNo = "";
            _localNo = "";
            _zip = "";
            _place = "";
            _postOffice = "";
            _isActive = false;
            _comments = "";
            _currentMode = CreatingMode.New;            
        }

        protected Address(int AddressId, int AddressType, string Place, string Street, string HouseNo, string LocalNo, string Zip, string PostOffice, bool IsActive, string Comments) : this()
        {
            _addressId = AddressId;
            _addressType = AddressType;
            _street = Street;
            _houseNo = HouseNo;
            _localNo = LocalNo;
            _zip = Zip;
            _place = Place;
            _postOffice = PostOffice;
            _isActive = IsActive;
            _comments = Comments;
            _currentMode = CreatingMode.None;            
        }

        protected Address(int AddressType, string Place, string Street, string HouseNo, string LocalNo, string Zip, string PostOffice, bool IsActive, string Comments) : this()
        {            
            _addressType = AddressType;
            _street = Street;
            _houseNo = HouseNo;
            _localNo = LocalNo;
            _zip = Zip;
            _place = Place;
            _postOffice = PostOffice;
            _isActive = IsActive;
            _comments = Comments;
            _currentMode = CreatingMode.New;                      
        }
    }
}
