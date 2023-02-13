using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class UserPermission : Permission
    {
        int _userId;
        public UserPermission() : base()
        {
            _userId = -1;
        }

        public UserPermission(Right Right, DateTime StartDate, DateTime EndDate, bool IsLocked, int UserId) : base(Right, StartDate, EndDate, IsLocked)
        {
            _userId = UserId;
        }

        public UserPermission(Guid PermissionId, Right Right, DateTime StartDate, DateTime EndDate, bool IsLocked, int UserId) : base(PermissionId, Right, StartDate, EndDate, IsLocked)
        {
            _userId = UserId;
        }
        public override void prepareSaveCommand(ref SqlCommand command, object owner)
        {
            int onwnerKey = this.HashCode;

            if (owner is User)
                onwnerKey = ((User)owner).HashCode;
            
            // permission add
            if (_currentMode == CreatingMode.New)
            {
                command.CommandText += string.Format("EXEC w2_uzytkownik_uprawnienie_dodaj @uzytk_id{1}, @prawa_id{0}, @data_od{0}, @data_do{0}, @zablokowane{0};", this.HashCode, onwnerKey);

                if (!command.Parameters.Contains("@uzytk_id" + onwnerKey))
                    command.Parameters.AddWithValue("@uzytk_id" + onwnerKey, _userId);

                command.Parameters.AddWithValue("@prawa_id" + this.HashCode, Right.RightId);
            }
            // permission edit
            else if (_currentMode == CreatingMode.Edit)
            {
                command.CommandText += string.Format("EXEC w2_uzytkownik_uprawnienie_edytuj @data_od{0}, @data_do{0}, @zablokowane{0}, @uprawnienie_id{0};", this.HashCode);
                command.Parameters.AddWithValue("@uprawnienie_id" + this.HashCode, PermissionId);
            }

            command.Parameters.AddWithValue("@data_od" + this.HashCode, StartDate.ToString("yyyyMMdd"));
            command.Parameters.AddWithValue("@data_do" + this.HashCode, EndDate.ToString("yyyyMMdd"));
            command.Parameters.AddWithValue("@zablokowane" + this.HashCode, IsLocked);
        }
    }
}
