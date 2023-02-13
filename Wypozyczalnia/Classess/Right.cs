using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class Right : GeneralBase
    {
        private int _rightId;
        private string _name;
        private bool _isActive;
        
        public int RightId { get { return _rightId; } }
        public string Name { get { return _name; } set { _name = value; SetChanged(); } }
        public bool IsActive { get { return _isActive; } set { _isActive = value; SetChanged(); } }

        public Right()
        {
            _rightId = -1;
            _name = "";
            _isActive = false;
            _currentMode = CreatingMode.New;
        }

        public Right(string Name, bool IsActive)
        {
            _rightId = -1;
            _name = Name;
            _isActive = IsActive;
            _currentMode = CreatingMode.New;
        }
        public Right(int RightId, string Name, bool IsActive)
        {
            _rightId = RightId;
            _name = Name;
            _isActive = IsActive;
            _currentMode = CreatingMode.None;
        }

        public override void prepareSaveCommand(ref SqlCommand command, object owner)
        {
            // right add
            if (_currentMode == CreatingMode.New)
                command.CommandText = string.Format("EXEC w2_prawa_dodaj @nazwa{0}, @stan_domyslny{0}", this.HashCode);
            // right edit
            else if (_currentMode == CreatingMode.Edit)
            {
                command.CommandText = string.Format("EXEC w2_prawa_edytuj @nazwa{0}, @stan_domyslny{0}, @prawa_id{0}", this.HashCode);
                command.Parameters.AddWithValue("@prawa_id" + this.HashCode, _rightId);
            }

            command.Parameters.AddWithValue("@nazwa" + this.HashCode, _name);
            command.Parameters.AddWithValue("@stan_domyslny" + this.HashCode, _isActive);
        }
    }
}
