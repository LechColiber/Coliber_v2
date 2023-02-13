using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public abstract class Teleaddress : GeneralBase
    {
        // private class fields
        private int _teleaddressId;
        private int _teleaddressType;
        private string _value;
        private bool _isActive;
        private string _comments;

        // public accessors
        public int TeleaddressId
        {
            get { return _teleaddressId; }
        }

        public int TeleaddressType
        {
            get { return _teleaddressType; }
            set
            {
                _teleaddressType = value;
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

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                SetChanged();
            }
        }

        /// <summary>
        /// Creates empty new instance.
        /// </summary>
        protected Teleaddress()
        {
            _teleaddressId = -1;
            _teleaddressType = -1;
            _value = "";
            _isActive = false;
            _comments = "";
            _currentMode = CreatingMode.New;
        }

        /// <summary>
        /// Creates instance in "none" mode (for adding existing teleaddresses).
        /// </summary>
        /// <param name="TeleaddressId"></param>
        /// <param name="TeleaddressType"></param>
        /// <param name="Value"></param>
        /// <param name="IsActive"></param>
        /// <param name="Comments"></param>
        protected Teleaddress(int TeleaddressId, int TeleaddressType, string Value, bool IsActive, string Comments) :this()
        {
            _teleaddressId = TeleaddressId;
            _teleaddressType = TeleaddressType;
            _value = Value;
            _isActive = IsActive;
            _comments = Comments;
            _currentMode = CreatingMode.None;
        }

        /// <summary>
        /// Creates instance in "new" mode.
        /// </summary>
        /// <param name="TeleaddressType"></param>
        /// <param name="Value"></param>
        /// <param name="IsActive"></param>
        /// <param name="Comments"></param>
        protected Teleaddress(int TeleaddressType, string Value, bool IsActive, string Comments) :this()
        {
            _teleaddressType = TeleaddressType;
            _value = Value;
            _isActive = IsActive;
            _comments = Comments;            
        }
    }
}
