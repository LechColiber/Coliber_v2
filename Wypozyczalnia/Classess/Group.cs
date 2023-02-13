using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public abstract class Group : GeneralBase
    {
        protected int _groupId;
        protected string _name;
        protected string _comments;
        protected bool _isActive;
        protected short? _timeLimit;
        protected RightCollection _rights;        

        public int GroupId { get { return _groupId; } set { _groupId = value; _currentMode = CreatingMode.None; } }
        public string Name { get { return _name; } set { _name = value; SetChanged(); } }
        public string Comments { get { return _comments; } set { _comments = value; SetChanged(); } }
        public bool IsActive { get { return _isActive; } set { _isActive = value; SetChanged(); } }
        public short? TimeLimit { get { return _timeLimit; } set { _timeLimit = value; SetChanged(); } }
        public RightCollection Rights { get { return _rights; } }

        protected Group()
        {
            _groupId = -1;
            _name = "";
            _comments = "";
            _isActive = false;
            _timeLimit = 0;
            _rights = new RightCollection();

            _currentMode = CreatingMode.New;
        }

        protected Group(string Name, string Comments, bool IsActive, short? TimeLimit) : this()
        {
            this._name = Name;
            this._comments = Comments;
            this._isActive = IsActive;
            this._timeLimit = TimeLimit;            
        }

        protected Group(int GroupId, string Name, string Comments, bool IsActive, short? TimeLimit) : this(Name, Comments, IsActive, TimeLimit)
        {
            this._groupId = GroupId;

            _currentMode = CreatingMode.None;
        }
    }
}
