using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public abstract class Permission : GeneralBase
    {
        Guid _permissionId;
        Right _right;
        DateTime _startDate;
        DateTime _endDate;
        bool _isLocked;

        public Guid PermissionId { get { return _permissionId; } }
        public Right Right { get { return _right; } }
        public DateTime StartDate { get { return _startDate; } set { _startDate = value; SetChanged(); } }
        public DateTime EndDate { get { return _endDate; } set { _endDate = value; SetChanged(); } }
        public bool IsLocked { get { return _isLocked; } set { _isLocked = value; SetChanged(); } }

        public Permission()
        {
            _permissionId = Guid.Empty;
            _right = new Wypozyczalnia.Right();
            _startDate = DateTime.Now;
            _endDate = DateTime.Now;
            _isLocked = true;

            _currentMode = CreatingMode.New;
        }

        public Permission(Right Right, DateTime StartDate, DateTime EndDate, bool Locked)
        {
            _right = Right;
            _startDate = StartDate;
            _endDate = EndDate;
            _isLocked = Locked;

            _currentMode = CreatingMode.New;
        }

        public Permission(Guid PermissionId, Right Right, DateTime StartDate, DateTime EndDate, bool Locked)
        {
            _permissionId = PermissionId;
            _right = Right;
            _startDate = StartDate;
            _endDate = EndDate;
            _isLocked = Locked;

            _currentMode = CreatingMode.None;
        }
    }
}
