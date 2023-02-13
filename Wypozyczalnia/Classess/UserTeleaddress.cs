using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class UserTeleaddress : Teleaddress
    {
        private int _userId;

        public UserTeleaddress() :base()
        {
            _userId = -1;
        }

        // none
        public UserTeleaddress(int TeleaddressId, int TeleaddressType, string Value, bool IsActive, string Comments, int UserId) : base(TeleaddressId, TeleaddressType, Value, IsActive, Comments)
        {
            _userId = UserId;
        }

        // new
        public UserTeleaddress(int TeleaddressType, string Value, bool IsActive, string Comments, int UserId) : base(TeleaddressType, Value, IsActive, Comments)
        {
            _userId = UserId;
        }

        public override void prepareSaveCommand(ref SqlCommand command, object owner)
        {
            int onwnerKey = this.HashCode;;

            if(owner is User)
                onwnerKey = ((User)owner).HashCode;

            // teleaddress add
            if (_currentMode == CreatingMode.New)
            {
                command.CommandText += string.Format("EXEC w2_uzytkownik_teleadres_dodaj @uzytk_id{1}, @typteleadr_id{0}, @wartosc{0}, @stan{0}, @pracown_id_wpr, @uwagi{0}; ", this.HashCode, onwnerKey);

                if (!command.Parameters.Contains("@uzytk_id" + onwnerKey))
                    command.Parameters.AddWithValue("@uzytk_id" + onwnerKey, _userId);
            }
            // teleaddress edit
            else if (_currentMode == CreatingMode.Edit)
            {
                command.CommandText += string.Format("EXEC w2_uzytkownik_teleadres_edytuj @teleadr_id{0}, @typteleadr_id{0}, @wartosc{0}, @stan{0}, @uwagi{0}; ", this.HashCode);
                command.Parameters.AddWithValue("@teleadr_id" + this.HashCode, TeleaddressId);
            }

            command.Parameters.AddWithValue("@typteleadr_id" + this.HashCode, TeleaddressType);
            command.Parameters.AddWithValue("@wartosc" + this.HashCode, Value);
            command.Parameters.AddWithValue("@stan" + this.HashCode, IsActive);
            command.Parameters.AddWithValue("@uwagi" + this.HashCode, Comments);
        }
    }
}
