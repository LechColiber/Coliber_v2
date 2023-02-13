using System.Data.SqlClient;

namespace Wypozyczalnia
{
    public class UserAddress : Address
    {
        private int _userId;

        /// <summary>
        /// Creates new UserAddress instance.
        /// </summary>
        public UserAddress() : base()
        {
            _userId = -1;
        }

        /// <summary>
        /// Creates UserAddress instance in none mode.
        /// </summary>
        /// <param name="AddressId"></param>
        /// <param name="AddressType"></param>
        /// <param name="Place"></param>
        /// <param name="Street"></param>
        /// <param name="HouseNo"></param>
        /// <param name="LocalNo"></param>
        /// <param name="Zip"></param>
        /// <param name="PostOffice"></param>
        /// <param name="IsActive"></param>
        /// <param name="Comments"></param>
        /// <param name="UserId"></param>
        public UserAddress(int AddressId, int AddressType, string Place, string Street, string HouseNo, string LocalNo, string Zip, string PostOffice, bool IsActive, string Comments, int UserId) : base(AddressId, AddressType, Place, Street, HouseNo, LocalNo, Zip, PostOffice, IsActive, Comments)
        {
            _userId = UserId;
        }

        // new
        public UserAddress(int AddressType, string Place, string Street, string HouseNo, string LocalNo, string Zip, string PostOffice, bool IsActive, string Comments, int UserId)
            : base(AddressType, Place, Street, HouseNo, LocalNo, Zip, PostOffice, IsActive, Comments)
        {
            _userId = UserId;
        }

        public override void prepareSaveCommand(ref SqlCommand command, object owner)
        {
            int ownerKey = this.HashCode;

            if (owner is User)
                ownerKey = ((User)owner).HashCode;
            
            // address add
            if (_currentMode == CreatingMode.New)
            {
                command.CommandText += string.Format("EXEC w2_uzytkownik_adres_dodaj @uzytk_id{1}, @p_typadr_id{0}, @p_miejscowosc{0}, @p_ulica{0}, @p_nr_domu{0}, @p_nr_lokalu{0}, @p_kod_poczt{0}, @p_poczta{0}, @p_stan{0}, @pracown_id_wpr, @p_uwagi{0}; ", this.HashCode, ownerKey);
                
                if(!command.Parameters.Contains("@uzytk_id"))
                    command.Parameters.AddWithValue("@uzytk_id", _userId);
            }
            // address edit
            else if (_currentMode == CreatingMode.Edit)
            {
                command.CommandText += string.Format("EXEC w2_uzytkownik_adres_edytuj @p_typadr_id{0}, @p_miejscowosc{0}, @p_ulica{0}, @p_nr_domu{0}, @p_nr_lokalu{0}, @p_kod_poczt{0}, @p_poczta{0}, @p_stan{0}, @p_uwagi{0}, @p_adres_id{0}; ", this.HashCode);
                command.Parameters.AddWithValue("@p_adres_id" + this.HashCode, AddressId);
            }
            
            command.Parameters.AddWithValue("@p_typadr_id" + this.HashCode, AddressType);
            command.Parameters.AddWithValue("@p_miejscowosc" + this.HashCode, Place);
            command.Parameters.AddWithValue("@p_ulica" + this.HashCode, Street);
            command.Parameters.AddWithValue("@p_nr_domu" + this.HashCode, HouseNo);
            command.Parameters.AddWithValue("@p_nr_lokalu" + this.HashCode, LocalNo);
            command.Parameters.AddWithValue("@p_kod_poczt" + this.HashCode, Zip);
            command.Parameters.AddWithValue("@p_poczta" + this.HashCode, PostOffice);
            command.Parameters.AddWithValue("@p_stan" + this.HashCode, IsActive);
            command.Parameters.AddWithValue("@p_uwagi" + this.HashCode, Comments);
        }
    }
}
