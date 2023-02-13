using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class UserGroup : Group
    {
        protected short? _countLimit;

        public short? CountLimit { get { return _countLimit; } set { _countLimit = value; SetChanged(); } }

        public UserGroup() : base()
        {
            _countLimit = 0;
        }

        public UserGroup(string name, string comments, bool isActive, short? timeLimit, short? countLimit) : base(name, comments, isActive, timeLimit)
        {
            this._countLimit = countLimit;            
        }

        public UserGroup(int groupId, string name, string comments, bool isActive, short? timeLimit, short? countLimit) : base(groupId, name, comments, isActive, timeLimit)
        {
            this._countLimit = countLimit;            
        }

        public override void prepareSaveCommand(ref SqlCommand command, object owner)
        {
            // add user group
            if (_currentMode == CreatingMode.New)
            {
                SqlParameter groupIdParameter = new SqlParameter();
                groupIdParameter.ParameterName = "@grupaId" + this.HashCode;
                groupIdParameter.SqlValue = -1;
                groupIdParameter.Direction = System.Data.ParameterDirection.InputOutput;

                command.Parameters.Add(groupIdParameter);

                command.CommandText += string.Format("EXEC w2_grupa_uzytkownikow_dodaj @nazwa{0}, @uwagi{0}, @aktywna{0}, @limit_czasu{0}, @limit_ilosci{0}, @grupaId{0} OUTPUT; ", this.HashCode);
            }
            // edit user group
            else if (_currentMode == CreatingMode.Edit)
            {
                command.CommandText += string.Format("EXEC w2_grupa_uzytkownikow_edytuj @nazwa{0}, @uwagi{0}, @aktywna{0}, @limit_czasu{0}, @limit_ilosci{0}, @grupaId{0}; ", this.HashCode);
                command.Parameters.AddWithValue("@grupaId" + this.HashCode, this.GroupId);
            }

            command.Parameters.AddWithValue("@nazwa" + this.HashCode, this.Name);
            command.Parameters.AddWithValue("@uwagi" + this.HashCode, !string.IsNullOrWhiteSpace(this.Comments) ? this.Comments as object : DBNull.Value);
            command.Parameters.AddWithValue("@aktywna" + this.HashCode, this.IsActive);
            command.Parameters.AddWithValue("@limit_czasu" + this.HashCode, this.TimeLimit);
            command.Parameters.AddWithValue("@limit_ilosci" + this.HashCode, this.CountLimit);
            
            // delete rights
            foreach(var rightId in Rights.ValuesToDelete)
            {
                command.CommandText += string.Format("EXEC w2_grupa_uzytkownikow_prawa_usun @grupaId{0}, @prawaId{0}_{1}; ", this.HashCode, rightId);
                command.Parameters.AddWithValue(string.Format("@prawaId{0}_{1}", this.HashCode, rightId), rightId);
            }

            // add rights
            foreach (var right in Rights.Values.Where(x => x.CurrentMode == CreatingMode.New || x.CurrentMode == CreatingMode.Edit))
            {
                command.CommandText += string.Format("EXEC w2_grupa_uzytkownikow_prawa_dodaj @grupaId{0}, @prawaId{1}; ", this.HashCode, right.HashCode);
                command.Parameters.AddWithValue("@prawaId" + right.HashCode, right.RightId);
            }
        }
    }
}
