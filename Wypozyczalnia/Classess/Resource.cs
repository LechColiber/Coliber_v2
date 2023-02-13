using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class Resource : GeneralBase
    {
        private int _resourceId;
        private string _title;
        private string _noInv;        
        private string _barcode;
        private bool _isBorrowed;
        private int _groupId;
        private string _groupName;
        private int _timeLimit;
        private string _comments;
        private PermissionCollection _permissions;

        public int ResourceId { get { return _resourceId; } }
        public string Title { get { return _title; } }
        public string NoInv { get { return _noInv; } }        
        public string Barcode { get { return _barcode; } }
        public bool IsBorrowed { get { return _isBorrowed; } }
        public int GroupId { get { return _groupId; } }
        public string GroupName { get { return _groupName; } }
        public int TimeLimit { get { return _timeLimit; } set { _timeLimit = value; } }
        public string Comments { get { return _comments; } }
        public PermissionCollection Permissions { get { return _permissions; } }

        public Resource() : base()
        {
            _permissions = new PermissionCollection();

            _resourceId = -1;
            _title = "";
            _noInv = "";
            _barcode = "";
            _isBorrowed = true;
            _groupId = -1;
            _groupName = "";
            _timeLimit = 0;
            _comments = "";

            _currentMode = CreatingMode.New;
        }

        public Resource(int Id, string Title, string NoInv, string Barcode, bool IsBorrowed, int GroupId, string GroupName, int TimeLimit, string Comments) : this()
        {
            _resourceId = Id;
            _title = Title;
            _noInv = NoInv;            
            _barcode = Barcode;
            _isBorrowed = IsBorrowed;
            _groupId = GroupId;
            _groupName = GroupName;
            _timeLimit = TimeLimit;
            _comments = Comments;

            _currentMode = CreatingMode.Edit;
        }

        public override void prepareSaveCommand(ref System.Data.SqlClient.SqlCommand command, object owner)
        {
            SqlParameter resourceIDSqlParameter = new SqlParameter();
            resourceIDSqlParameter.ParameterName = "@zasob_id" + this.HashCode;            
            resourceIDSqlParameter.Direction = ParameterDirection.InputOutput;
            resourceIDSqlParameter.SqlValue = _resourceId;

            command.Parameters.Add(resourceIDSqlParameter);

            if(_currentMode == CreatingMode.Edit)
            {
                command.CommandText += string.Format("EXEC w2_zasob_edytuj @zasob_id{0}, @limit_czasu{0};", this.HashCode) + Environment.NewLine;                
                command.Parameters.AddWithValue(string.Format("@limit_czasu{0}", this.HashCode), _timeLimit);
            }

            // delete permissions
            foreach (var permissionId in _permissions.ValuesToDelete)
            {
                command.CommandText += string.Format("EXEC w2_zasob_uprawnienie_usun @resource_permissionId_delete{0};", permissionId.ToString().Replace('-', '_')) + Environment.NewLine;
                command.Parameters.AddWithValue(string.Format("@resource_permissionId_delete{0}", permissionId.ToString().Replace('-', '_')), permissionId);
            }

            // add/edit permissions
            foreach (var permission in _permissions)
            {
                permission.Value.prepareSaveCommand(ref command, this);
            }
        }
    }
}
