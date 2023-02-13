using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace Wypozyczalnia
{
    public class User : GeneralBase
    {
        private int _userId;
        private string _userName;
        private string _department;
        private bool _isMale;
        private string _barcode;
        private int? _userType;
        private int? _userGroup;
        private string _cardId;
        private string _domainName;
        private DateTime? _birthDate;
        private int _maxBorrows;
        private int _maxBorrowTime;
        private string _comments;
        private bool _isLocked;
        private bool _isDeleted;

        private AddressCollection _addresses;
        private TeleaddressCollection _teleaddresses;
        private PermissionCollection _permissions;

        //public SqlConnection sqlConnection;

        public int UserID { get { return _userId; } set { _userId = value; _currentMode = CreatingMode.None; } }
        public string UserName { get { return _userName; } set { _userName = value; SetChanged(); } }
        public string Department { get { return _department; } set { _department = value; SetChanged(); } }
        public bool IsMale { get { return _isMale; } set { _isMale = value; SetChanged(); } }
        public string Barcode { get { return _barcode; } set { _barcode = value; SetChanged(); } }
        public int? UserType { get { return _userType; } set { _userType = value; SetChanged(); } }
        public int? UserGroup { get { return _userGroup; } set { _userGroup = value; SetChanged(); } }
        public string CardId { get { return _cardId; } set { _cardId = value; SetChanged(); } }
        public string DomainName { get { return _domainName; } set { _domainName = value; SetChanged(); } }
        public DateTime? BirthDate { get { return _birthDate; } set { _birthDate = value; SetChanged(); } }
        public int MaxBorrows { get { return _maxBorrows; } set { _maxBorrows = value; SetChanged(); } }
        public int MaxBorrowTime { get { return _maxBorrowTime; } set { _maxBorrowTime = value; SetChanged(); } }
        public string Comments { get { return _comments; } set { _comments = value; SetChanged(); } }
        public bool IsLocked { get { return _isLocked; } set { _isLocked = value; SetChanged(); } }
        public bool IsDeleted { get { return _isDeleted; } set { _isDeleted = value; } }    

        public AddressCollection Addresses { get { return _addresses; } }
        public TeleaddressCollection Teleaddresses { get { return _teleaddresses; } }
        public PermissionCollection Permissions { get { return _permissions; } }

        public User() : base()
        {
            _userId = -1;
            _userName = "";
            _department = "";
            _isMale = false;
            _barcode = "";
            _userType = -1;
            _userGroup = -1;
            _cardId = "";
            _domainName = "";
            _birthDate = null;
            _maxBorrows = 0;
            _maxBorrowTime = 0;
            _comments = "";
            _isLocked = true;
            _isDeleted = false;
            _currentMode = CreatingMode.New;

            _addresses = new AddressCollection();
            _teleaddresses = new TeleaddressCollection();
            _permissions = new PermissionCollection();
        }

        public User(int Id) : this()
        {
            _userId = Id;
            _currentMode = CreatingMode.None;
        }

        public override void prepareSaveCommand(ref SqlCommand SaveCommand, object owner)
        {
            SqlParameter userIDSqlParameter = new SqlParameter();
            userIDSqlParameter.ParameterName = "@uzytk_id" + this.HashCode;
            userIDSqlParameter.Direction = ParameterDirection.InputOutput;
            userIDSqlParameter.SqlValue = _userId;
            
            SaveCommand.Parameters.Add(userIDSqlParameter);

            if (_currentMode == CreatingMode.New)
                SaveCommand.CommandText += string.Format("EXEC w2_uzytkownik_dodaj @p_typuzytk_id{0}, @p_grupa_id{0}, @p_kod_kresk{0}, @p_nazwa{0}, @p_data_urodz{0}, @p_plec{0}, @p_uwagi{0}, @p_limit_czasu{0}, @p_limit_ilosci{0}, @p_zablokowany{0}, @p_nr_legitym{0}, @p_domena_nazwa{0}, @p_dzial{0}, @uzytk_id{0} OUTPUT; ", this.HashCode);
            else if (_currentMode == CreatingMode.Edit)
                SaveCommand.CommandText += string.Format("EXEC w2_uzytkownik_edytuj @p_typuzytk_id{0}, @p_grupa_id{0}, @p_kod_kresk{0}, @p_nazwa{0}, @p_data_urodz{0}, @p_plec{0}, @p_uwagi{0}, @p_limit_czasu{0}, @p_limit_ilosci{0}, @p_zablokowany{0}, @p_nr_legitym{0}, @p_domena_nazwa{0}, @p_dzial{0}, @uzytk_id{0}; ", this.HashCode);

            // typ użytkownika
            if (_userType.HasValue)
                SaveCommand.Parameters.AddWithValue("@p_typuzytk_id" + this.HashCode, _userType);
            else
                SaveCommand.Parameters.AddWithValue("@p_typuzytk_id" + this.HashCode, DBNull.Value);

            // grupa użytkownika
            if (_userGroup.HasValue)
                SaveCommand.Parameters.AddWithValue("@p_grupa_id" + this.HashCode, _userGroup);
            else
                SaveCommand.Parameters.AddWithValue("@p_grupa_id" + this.HashCode, DBNull.Value);

            // kod kreskowy
            if (!string.IsNullOrWhiteSpace(_barcode))
                SaveCommand.Parameters.AddWithValue("@p_kod_kresk" + this.HashCode, _barcode);
            else
                SaveCommand.Parameters.AddWithValue("@p_kod_kresk" + this.HashCode, DBNull.Value);

            // nazwa
            if (!string.IsNullOrEmpty(_userName))
                SaveCommand.Parameters.AddWithValue("@p_nazwa" + this.HashCode, _userName);
            else
                SaveCommand.Parameters.AddWithValue("@p_nazwa" + this.HashCode, DBNull.Value);

            // data urodzenia
            if (_birthDate != null)
                SaveCommand.Parameters.AddWithValue("@p_data_urodz" + this.HashCode, _birthDate.Value.ToString("yyyyMMdd"));
            else
                SaveCommand.Parameters.AddWithValue("@p_data_urodz" + this.HashCode, DBNull.Value);

            // płeć            
            SaveCommand.Parameters.AddWithValue("@p_plec" + this.HashCode, _isMale);

            // uwagi
            if (!string.IsNullOrEmpty(_comments))
                SaveCommand.Parameters.AddWithValue("@p_uwagi" + this.HashCode, _comments);
            else
                SaveCommand.Parameters.AddWithValue("@p_uwagi" + this.HashCode, DBNull.Value);

            // limit czasu
            SaveCommand.Parameters.AddWithValue("@p_limit_czasu" + this.HashCode, _maxBorrowTime);

            // limit ilości      
            SaveCommand.Parameters.AddWithValue("@p_limit_ilosci" + this.HashCode, _maxBorrows);

            // zablokowany
            SaveCommand.Parameters.AddWithValue("@p_zablokowany" + this.HashCode, _isLocked);

            // numer legitymacji
            if (!string.IsNullOrWhiteSpace(_cardId))
                SaveCommand.Parameters.AddWithValue("@p_nr_legitym" + this.HashCode, _cardId);
            else
                SaveCommand.Parameters.AddWithValue("@p_nr_legitym" + this.HashCode, DBNull.Value);

            // domena_nazwa
            if (!string.IsNullOrWhiteSpace(_domainName))
                SaveCommand.Parameters.AddWithValue("@p_domena_nazwa" + this.HashCode, _domainName);
            else
                SaveCommand.Parameters.AddWithValue("@p_domena_nazwa" + this.HashCode, DBNull.Value);

            // dział
            if (!string.IsNullOrEmpty(_department))
                SaveCommand.Parameters.AddWithValue("@p_dzial" + this.HashCode, _department);
            else
                SaveCommand.Parameters.AddWithValue("@p_dzial" + this.HashCode, DBNull.Value);

            // delete addresses
            foreach (var addressId in _addresses.ValuesToDelete)
            {
                SaveCommand.CommandText += "EXEC w2_uzytkownik_adres_usun @address_delete" + addressId + ";" + Environment.NewLine;
                SaveCommand.Parameters.AddWithValue("@address_delete" + addressId, addressId);
            }

            // add/edit addresses
            foreach (var address in _addresses)
            {
                address.Value.prepareSaveCommand(ref SaveCommand, this);
            }

            // delete teleaddresses
            foreach (var teleaddressId in _teleaddresses.ValuesToDelete)
            {
                SaveCommand.CommandText += "EXEC w2_uzytkownik_teleadres_usun @teleaddress_delete" + teleaddressId + ";" + Environment.NewLine;
                SaveCommand.Parameters.AddWithValue("@teleaddress_delete" + teleaddressId, teleaddressId);
            }

            // add/edit teleaddresses
            foreach (var teleaddress in _teleaddresses)
            {
                teleaddress.Value.prepareSaveCommand(ref SaveCommand, this);
            }

            // delete permissions
            foreach (var permissionId in _permissions.ValuesToDelete)
            {
                SaveCommand.CommandText += string.Format("EXEC w2_uzytkownik_uprawnienie_usun @permissionId_delete{0};", permissionId.ToString().Replace('-', '_')) + Environment.NewLine;
                SaveCommand.Parameters.AddWithValue("@permissionId_delete" + permissionId.ToString().Replace('-', '_'), permissionId);
            }

            // add/edit permissions
            foreach (var permission in _permissions)
            {
                permission.Value.prepareSaveCommand(ref SaveCommand, this);
            }
        }        
    }
}