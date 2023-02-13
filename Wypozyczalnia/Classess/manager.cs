using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class Manager : GeneralBase
    {
        public SqlConnection Connection;
        private GroupCollection _userGroups;
        private GroupCollection _resourcesGroups;
        public UserCollection Users { get; set; }
        public ResourceCollection Resources { get; set; }
        public GroupCollection UserGroups
        {
            get
            {
                if (_userGroups.Count == 0)
                    _userGroups = GetUserGroupsFromDb();

                return _userGroups;
            }
            set { _userGroups = value; }
        }

        public GroupCollection ResourceGroups
        {
            get
            {
                if (_resourcesGroups.Count == 0)
                    _resourcesGroups = GetResourceGroupsFromDb();

                return _resourcesGroups;
            }
            set { _resourcesGroups = value; }
        }
        public Configuration WypozyczalniaConfiguration { get; set; }        

        public int EmployeeId { get; set; }
        public Manager(int EmployeeId, string ConnectionString) : base()
        {            
            this.EmployeeId = EmployeeId;
            SetConnection(ConnectionString);

            Users = new UserCollection();
            UserGroups = new GroupCollection();
            ResourceGroups = new GroupCollection();
            WypozyczalniaConfiguration = new Configuration();
            Resources = new ResourceCollection();         

            LoadWypozyczalniaConfiguration();
        }

        #region private void SetConnection(string ConnectionString)
        private void SetConnection(string ConnectionString)
        {
            Connection = new SqlConnection(ConnectionString);
        }
        #endregion

        public bool Save()
        {
            if (!CheckBeforeSave())
                return false;

            SqlCommand SaveCommand = new SqlCommand();

            if (!SaveCommand.Parameters.Contains("@pracown_id_wpr"))
                SaveCommand.Parameters.AddWithValue("@pracown_id_wpr", EmployeeId);

            // delete users
            foreach (var userId in Users.ValuesToDelete)
            {
                int userBorrowsCount = this.GetUserBorrowsCount(userId);

                if (userBorrowsCount > 0)
                {
                    //MessageBox.Show(, "Operacja przerwana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new Exception(string.Format("Użytkownik nie został usunięty.\nUżytkownik posiada {0} zasobów na swoim koncie.\nProszę dokonać zwrotów wszystkich zasobów użytkownika.", userBorrowsCount));   
                }

                SaveCommand.CommandText += string.Format("EXEC w2_uzytkownik_wyrejestruj @userId_delete{0}; ", userId);
                SaveCommand.Parameters.AddWithValue("@userId_delete" + userId, userId);
            }

            // add/edit users
            foreach (User user in Users.Values.Where(x => x.CurrentMode == CreatingMode.New || x.CurrentMode == CreatingMode.Edit))
                user.prepareSaveCommand(ref SaveCommand, null);

            // delete user groups
            foreach (var groupId in _userGroups.ValuesToDelete)
            {
                SaveCommand.CommandText += string.Format("EXEC w2_grupa_uzytkownikow_usun @grupaId_delete{0}; ", groupId);
                SaveCommand.Parameters.AddWithValue("@grupaId_delete" + groupId, groupId);
            }

            // add/edit user groups
            foreach (UserGroup group in _userGroups.Values.Where(x => x.CurrentMode == CreatingMode.New || x.CurrentMode == CreatingMode.Edit))
                group.prepareSaveCommand(ref SaveCommand, null);

            // delete resource groups
            // not implemented 
            /*foreach (var groupId in UserGroups.ValuesToDelete)
            {
                SaveCommand.CommandText += string.Format("EXEC w2_grupa_uzytkownikow_usun @grupaId_delete{0}; ", groupId);
                SaveCommand.Parameters.AddWithValue("@grupaId_delete" + groupId, groupId);
            }*/

            // add/edit resource groups
            foreach (ResourceGroup group in _resourcesGroups.Values.Where(x => x.CurrentMode == CreatingMode.New || x.CurrentMode == CreatingMode.Edit))
                group.prepareSaveCommand(ref SaveCommand, null);

            WypozyczalniaConfiguration.prepareSaveCommand(ref SaveCommand, null);

            // edit resources
            foreach (Resource resource in Resources.Values.Where(x => x.CurrentMode == CreatingMode.Edit))
                resource.prepareSaveCommand(ref SaveCommand, null);

            // check CommandText is empty
            if (string.IsNullOrWhiteSpace(SaveCommand.CommandText))
                return true;

            if(CommonFunctions.WriteData(ref SaveCommand, ref Connection))
            {
                foreach (User user in Users.Values)
                {
                    if (SaveCommand.Parameters.Contains("@uzytk_id" + user.HashCode))
                    {
                        user.UserID = (int)SaveCommand.Parameters["@uzytk_id" + user.HashCode].Value;
                    }
                }

                foreach (UserGroup group in _userGroups.Values)
                {
                    if (SaveCommand.Parameters.Contains("@grupaId" + group.HashCode))
                        group.GroupId = (int)SaveCommand.Parameters["@grupaId" + group.HashCode].Value;
                }

                foreach (ResourceGroup group in _resourcesGroups.Values)
                {
                    if (SaveCommand.Parameters.Contains("@grupaId" + group.HashCode))
                        group.GroupId = (int)SaveCommand.Parameters["@grupaId" + group.HashCode].Value;
                }

                return true;
            }

            return false;
        }

        #region public override void prepareSaveCommand(ref SqlCommand command, object owner)
        public override void prepareSaveCommand(ref SqlCommand command, object owner)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region private bool CheckBeforeSave()
        private bool CheckBeforeSave()
        {
            if (EmployeeId == -1)
                throw new Exception("Invalid employee id");

            if (Connection == null)
                throw new Exception("sqlConnection property has not been initialized");

            return true;
        }
        #endregion

        public DataTable GetUserNameWithDomainName(string userDomainName)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_uzytkownik_z_nazwa_domenowa @userDomainName; ";
            Command.Parameters.AddWithValue("@userDomainName", userDomainName.Trim());

            return CommonFunctions.ReadData(Command, ref this.Connection);
        }

        public DataTable GetCurrentOrders(int sort)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zamowienia_lista @sort; ";
            Command.Parameters.AddWithValue("@sort", sort);

            return CommonFunctions.ReadData(Command, ref this.Connection);
        }

        public int GetCurrentOrdersCount()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zamowienia_ilosc; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref this.Connection);

            if (Dt == null || Dt.Rows.Count == 0) return -1;
            else return (int)Dt.Rows[0]["ilosc"];
        }

        public bool GetUserHaveResourceBorrowed(int userId, int resourceId)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_uzytkownik_posiada_wypozyczony_zasob @userId, @resourceId; ";
            Command.Parameters.AddWithValue("@userId", userId);
            Command.Parameters.AddWithValue("@resourceId", resourceId);

            DataTable Dt = CommonFunctions.ReadData(Command, ref this.Connection);

            return GeneralBase.ConvertToBool(Dt.Rows[0]["rezultat"].ToString());
        }

        public bool ChangeOrderState(int orderId, bool isReady)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zamowienie_zmien_stan @orderId, @isReady; ";
            Command.Parameters.AddWithValue("@orderId", orderId);
            Command.Parameters.AddWithValue("@isReady", isReady);

            return CommonFunctions.WriteData(Command, ref this.Connection);
        }

        public DataTable GetResourceHistoryById(int id)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zasob_historia @zasob_id; ";
            Command.Parameters.AddWithValue("@zasob_id", id);

            return CommonFunctions.ReadData(Command, ref this.Connection);
        }

        public DataTable GetResourceOrderHistoryById(int id)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zasob_zamowienia @zasob_id; ";
            Command.Parameters.AddWithValue("@zasob_id", id);

            return CommonFunctions.ReadData(Command, ref this.Connection);
        }

        public int GetResourceIdByBarcode(string barcode)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zasob_przez_kod_kreskowy @barcode; ";
            Command.Parameters.AddWithValue("@barcode", barcode.Trim());

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);

            if (Dt.Rows.Count > 0)
                return (int)Dt.Rows[0]["zasob_id"];

            return -1;
        }

        public int GetResourceIdBySignature(string signature)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zasob_przez_sygnatura @signature; ";
            Command.Parameters.AddWithValue("@signature", signature.Trim());

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);

            if (Dt.Rows.Count > 0)
                return (int)Dt.Rows[0]["zasob_id"];

            return -1;
        }

        public int GetResourceIdByNoInv(string noInv)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zasob_przez_numer_inwentarzowy @noInv; ";
            Command.Parameters.AddWithValue("@noInv", noInv.Trim());

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);

            if (Dt.Rows.Count > 0)
                return (int)Dt.Rows[0]["zasob_id"];

            return -1;
        }

        public int GetUserIdByBarcode(string barcode)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_uzytkownik_przez_kod_kreskowy @barcode; ";
            Command.Parameters.AddWithValue("@barcode", barcode.Trim());

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);

            if (Dt.Rows.Count > 0)
                return (int)Dt.Rows[0]["uzytk_id"];

            return -1;
        }

        public DataTable GetUserOrdersByUserId(int id)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_uzytkownik_zamowienia @uzytk_id; ";
            Command.Parameters.AddWithValue("@uzytk_id", id);

            return CommonFunctions.ReadData(Command, ref this.Connection);
        }

        public void CancelOrder(int orderId)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zamowienie_rezygnuj @zamowienie_id, @pracown_id; ";
            Command.Parameters.AddWithValue("@zamowienie_id", orderId);
            Command.Parameters.AddWithValue("@pracown_id", EmployeeId);

            CommonFunctions.WriteData(Command, ref this.Connection);
        }

        public int RealizeOrder(int orderId)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zamowienie_realizacja @zamowienie_id, @pracown_id, @wypoz_id OUTPUT; ";
            Command.Parameters.AddWithValue("@zamowienie_id", orderId);
            Command.Parameters.AddWithValue("@pracown_id", EmployeeId);

            SqlParameter borrowIdParameter = new SqlParameter();
            borrowIdParameter.ParameterName = "@wypoz_id";
            borrowIdParameter.SqlDbType = SqlDbType.Int;
            borrowIdParameter.Direction = ParameterDirection.Output;
            Command.Parameters.Add(borrowIdParameter);

            CommonFunctions.WriteData(Command, ref this.Connection);

            return (int)Command.Parameters["@wypoz_id"].Value;
        }

        public int DoBorrow(int resourceId, int userId, int timeLimit, string comments, DateTime borrowDate)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_wypozyczenie @zasob_id, @uzytk_id, @pracown_id, @limit_czasu, @uwagi, @data_wyp, @wypoz_id OUTPUT; ";
            Command.Parameters.AddWithValue("@zasob_id", resourceId);
            Command.Parameters.AddWithValue("@uzytk_id", userId);
            Command.Parameters.AddWithValue("@pracown_id", EmployeeId);
            Command.Parameters.AddWithValue("@limit_czasu", timeLimit);
            Command.Parameters.AddWithValue("@uwagi", comments);
            Command.Parameters.AddWithValue("@data_wyp", borrowDate.ToString("yyyyMMdd"));

            SqlParameter borrowIdParameter = new SqlParameter();
            borrowIdParameter.ParameterName = "@wypoz_id";
            borrowIdParameter.SqlDbType = SqlDbType.Int;
            borrowIdParameter.Direction = ParameterDirection.Output;

            Command.Parameters.Add(borrowIdParameter);

            CommonFunctions.WriteData(Command, ref this.Connection);

            return (int)Command.Parameters["@wypoz_id"].Value;
        }

        public bool ReturnBorrow(int borrowId, DateTime date)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zwrot @wypoz_id, @pracown_id, @data_zwrotu, @rezultat OUTPUT; ";
            Command.Parameters.AddWithValue("@wypoz_id", borrowId);
            Command.Parameters.AddWithValue("@pracown_id", EmployeeId);
            Command.Parameters.AddWithValue("@data_zwrotu", date.ToString("yyyyMMdd"));

            SqlParameter rezultat = new SqlParameter();
            rezultat.ParameterName = "@rezultat";
            rezultat.SqlDbType = SqlDbType.TinyInt;
            rezultat.Direction = ParameterDirection.Output;

            Command.Parameters.Add(rezultat);

            return CommonFunctions.WriteData(ref Command, ref this.Connection) && Command.Parameters["@rezultat"].SqlValue.ToString() == "1";
        }

        public bool DoOrder(int resourceId, int userId, string comments)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zamowienie @zasob_id, @uzytk_id, @pracown_id, @uwagi, @rezultat OUTPUT; ";

            Command.Parameters.AddWithValue("@zasob_id", resourceId);
            Command.Parameters.AddWithValue("@uzytk_id", userId);
            Command.Parameters.AddWithValue("@pracown_id", EmployeeId);
            Command.Parameters.AddWithValue("@uwagi", comments);

            SqlParameter rezultat = new SqlParameter();
            rezultat.ParameterName = "@rezultat";
            rezultat.SqlDbType = SqlDbType.TinyInt;
            rezultat.Direction = ParameterDirection.Output;

            Command.Parameters.Add(rezultat);

            return CommonFunctions.WriteData(Command, ref this.Connection) && Command.Parameters["@rezultat"].SqlValue.ToString() == "1";
        }

        public DataTable GetBorrowDetailsByResourceId(int id)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_wypozyczenie_szczegoly_przez_zasob_id @zasob_id; ";
            Command.Parameters.AddWithValue("@zasob_id", id);

            return CommonFunctions.ReadData(Command, ref this.Connection);
        }

        #region public GroupCollection GetUserGroupsFromDb()
        public GroupCollection GetUserGroupsFromDb()
        {            
            GroupCollection userGroups = new GroupCollection();

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_grupa_uzytkownikow_szczegoly; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);
            SqlCommand rightsCommand = new SqlCommand();
            rightsCommand.CommandText = "EXEC w2_grupa_uzytkownikow_prawa_szczegoly @grupa_id; ";

            for(int i = 0; i < Dt.Rows.Count; i++)
            {
                bool isActive = ConvertToBool(Dt.Rows[i]["aktywna"].ToString());

                short tempTimeLimit;
                short? tempTimeLimitNullable = null;
                short tempMaxBorrows;
                short? tempMaxBorrowsNullable = null;

                if(short.TryParse(Dt.Rows[i]["limit_czasu"].ToString(), out tempTimeLimit))
                    tempTimeLimitNullable = tempTimeLimit;

                if (short.TryParse(Dt.Rows[i]["limit_ilosci"].ToString(), out tempMaxBorrows))
                    tempMaxBorrowsNullable = tempMaxBorrows;

                UserGroup tempGroup = new UserGroup((int)Dt.Rows[i]["grupa_id"], Dt.Rows[i]["nazwa"].ToString(), Dt.Rows[i]["uwagi"].ToString(), isActive, tempTimeLimitNullable, tempMaxBorrowsNullable);
                
                rightsCommand.Parameters.Clear();
                rightsCommand.Parameters.AddWithValue("@grupa_id", tempGroup.GroupId);

                DataTable rightDt = CommonFunctions.ReadData(rightsCommand, ref this.Connection);

                for (int j = 0; j < rightDt.Rows.Count; j++)
                {
                    tempGroup.Rights.Add(new Right((int)rightDt.Rows[j]["prawa_id"], rightDt.Rows[j]["nazwa"].ToString(), false));
                }

                userGroups.Add(tempGroup);
            }
            
            return userGroups;
        }
        #endregion

        #region public UserGroup GetUserGroupById(int id)
        public UserGroup GetUserGroupById(int id)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_grupa_uzytkownikow_szczegoly @grupaId; ";
            Command.Parameters.AddWithValue("@grupaId", id);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);
            SqlCommand rightsCommand = new SqlCommand();
            rightsCommand.CommandText = "EXEC w2_grupa_uzytkownikow_prawa_szczegoly @grupa_id; ";

            UserGroup tempGroup = null;

            if (Dt.Rows.Count > 0)
            {
                bool isActive = ConvertToBool(Dt.Rows[0]["aktywna"].ToString());

                short tempTimeLimit;
                short? tempTimeLimitNullable = null;
                short tempMaxBorrows;
                short? tempMaxBorrowsNullable = null;

                if (short.TryParse(Dt.Rows[0]["limit_czasu"].ToString(), out tempTimeLimit))
                    tempTimeLimitNullable = tempTimeLimit;

                if (short.TryParse(Dt.Rows[0]["limit_ilosci"].ToString(), out tempMaxBorrows))
                    tempMaxBorrowsNullable = tempMaxBorrows;

                tempGroup = new UserGroup((int)Dt.Rows[0]["grupa_id"], Dt.Rows[0]["nazwa"].ToString(), Dt.Rows[0]["uwagi"].ToString(), isActive, tempTimeLimitNullable, tempMaxBorrowsNullable);

                rightsCommand.Parameters.Clear();
                rightsCommand.Parameters.AddWithValue("@grupa_id", tempGroup.GroupId);

                DataTable rightDt = CommonFunctions.ReadData(rightsCommand, ref this.Connection);

                for (int j = 0; j < rightDt.Rows.Count; j++)
                {
                    tempGroup.Rights.Add(new Right((int)rightDt.Rows[j]["prawa_id"], rightDt.Rows[j]["nazwa"].ToString(), false));
                }                
            }

            return tempGroup;
        }
        #endregion

        #region public GroupCollection GetResourceGroupsFromDb()
        public GroupCollection GetResourceGroupsFromDb()
        {
            GroupCollection resourceGroups = new GroupCollection();

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_grupa_zasobow_szczegoly; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);
            SqlCommand rightsCommand = new SqlCommand();
            rightsCommand.CommandText = "EXEC w2_grupa_zasobow_prawa_szczegoly @grupa_id; ";

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                bool isActive = ConvertToBool(Dt.Rows[i]["aktywna"].ToString());

                short tempTimeLimit;
                short? tempTimeLimitNullable = null;

                if (short.TryParse(Dt.Rows[i]["limit_czasu"].ToString(), out tempTimeLimit))
                    tempTimeLimitNullable = tempTimeLimit;

                ResourceGroup tempGroup = new ResourceGroup((int)Dt.Rows[i]["grupa_id"], Dt.Rows[i]["nazwa"].ToString(), Dt.Rows[i]["uwagi"].ToString(), isActive, tempTimeLimitNullable);

                rightsCommand.Parameters.Clear();
                rightsCommand.Parameters.AddWithValue("@grupa_id", tempGroup.GroupId);

                DataTable rightDt = CommonFunctions.ReadData(rightsCommand, ref this.Connection);

                for (int j = 0; j < rightDt.Rows.Count; j++)
                {
                    tempGroup.Rights.Add(new Right((int)rightDt.Rows[j]["prawa_id"], rightDt.Rows[j]["nazwa"].ToString(), false));
                }

                resourceGroups.Add(tempGroup);
            }

            return resourceGroups;
        }
        #endregion

        #region public ResourceGroup GetResourceGroupById(int id)
        public ResourceGroup GetResourceGroupById(int id)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_grupa_zasobow_szczegoly @grupaId; ";
            Command.Parameters.AddWithValue("@grupaId", id);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);
            SqlCommand rightsCommand = new SqlCommand();
            rightsCommand.CommandText = "EXEC w2_grupa_zasobow_prawa_szczegoly @grupa_id; ";

            ResourceGroup tempGroup = null;

            if (Dt.Rows.Count > 0)
            {
                bool isActive = ConvertToBool(Dt.Rows[0]["aktywna"].ToString());

                short tempTimeLimit;
                short? tempTimeLimitNullable = null;

                if (short.TryParse(Dt.Rows[0]["limit_czasu"].ToString(), out tempTimeLimit))
                    tempTimeLimitNullable = tempTimeLimit;

                tempGroup = new ResourceGroup((int)Dt.Rows[0]["grupa_id"], Dt.Rows[0]["nazwa"].ToString(), Dt.Rows[0]["uwagi"].ToString(), isActive, tempTimeLimitNullable);

                rightsCommand.Parameters.Clear();
                rightsCommand.Parameters.AddWithValue("@grupa_id", tempGroup.GroupId);

                DataTable rightDt = CommonFunctions.ReadData(rightsCommand, ref this.Connection);

                for (int j = 0; j < rightDt.Rows.Count; j++)
                {
                    tempGroup.Rights.Add(new Right((int)rightDt.Rows[j]["prawa_id"], rightDt.Rows[j]["nazwa"].ToString(), false));
                }
            }

            return tempGroup;
        }
        #endregion

        #region public User GetUserByKey(int key)
        public User GetUserByKey(int key)
        {
            if (Users.ContainsKey(key))
                return Users[key];

            return null;
        }
        #endregion

        #region public User GetUserById(int id, bool getFromDbWithoutCache = false)
        public User GetUserById(int id, bool getFromDbWithoutCache = false)
        {
            if (!getFromDbWithoutCache)
            {
                foreach (User tempUser in this.Users.Values)
                {
                    if (tempUser.UserID == id)
                    {
                        return tempUser;
                    }
                }
            }

            User user = new User(id);
            LoadUserData(user);
            LoadUserAddresses(user);
            LoadUserTeleaddresses(user);
            LoadUserPermissions(user);

            if (!getFromDbWithoutCache)
                Users.Add(user);

            return user;
        }
        #endregion

        #region public Resource GetResourceById(int id, bool getFromDbWithoutCache = false)
        public Resource GetResourceById(int id, bool getFromDbWithoutCache = false)
        {
            if (!getFromDbWithoutCache)
            {
                foreach (Resource tempResource in this.Resources.Values)
                {
                    if (tempResource.ResourceId == id)
                    {
                        return tempResource;
                    }
                }
            }

            Resource resource = LoadResourceData(id);

            if (!getFromDbWithoutCache)
                Resources.Add(resource);

            return resource;
        }
        #endregion

        #region private Resource LoadResourceData(int id)
        private Resource LoadResourceData(int id)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_zasob_szczegoly @zasob_id; ";
            Command.Parameters.AddWithValue("@zasob_id", id);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);

            if (Dt.Rows.Count > 0)
            {
                // timeLimit
                int timeLimit;
                int.TryParse(Dt.Rows[0]["limit_czas"].ToString().Trim(), out timeLimit);

                Resource resource = new Resource(id, Dt.Rows[0]["opis"].ToString(), Dt.Rows[0]["numer_inw"].ToString(), Dt.Rows[0]["kod_kresk"].ToString(), ConvertToBool(Dt.Rows[0]["wypozyczony"].ToString()), (int)Dt.Rows[0]["grupa_id"], Dt.Rows[0]["grupa"].ToString(), timeLimit, Dt.Rows[0]["uwagi"].ToString());

                Command = new SqlCommand();
                Command.CommandText = "EXEC w2_zasob_uprawnienia @zasob_id; ";
                Command.Parameters.AddWithValue("@zasob_id", id);

                Dt = CommonFunctions.ReadData(Command, ref Connection);

                Guid permissionId;
                int rightsId;
                DateTime start, end;
                bool isLocked;

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    Guid.TryParse(Dt.Rows[i]["upraw_id"].ToString().Trim(), out permissionId);
                    int.TryParse(Dt.Rows[i]["prawa_id"].ToString().Trim(), out rightsId);
                    DateTime.TryParseExact(Dt.Rows[i]["data_od"].ToString().Trim(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out start);
                    DateTime.TryParseExact(Dt.Rows[i]["data_do"].ToString().Trim(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out end);

                    isLocked = ConvertToBool(Dt.Rows[i]["zablokowane"].ToString().Trim());

                    ResourcePermission resourcePermission = new ResourcePermission(permissionId, new Right(rightsId, Dt.Rows[i]["nazwa"].ToString(), false), start, end, isLocked, resource.ResourceId);
                    resource.Permissions.Add(resourcePermission);
                }

                return resource;
            }

            return new Resource();
        }
        #endregion

        #region private void LoadUserData(User user)
        private void LoadUserData(User user)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_uzytkownik_szczegoly @uzytk_id; ";
            Command.Parameters.AddWithValue("@uzytk_id", user.UserID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);

            if (Dt.Rows.Count > 0)
            {
                // nazwa / nazwisko
                user.UserName = Dt.Rows[0]["nazwa"].ToString().Trim();

                // dział
                user.Department = Dt.Rows[0]["dzial"].ToString().Trim();

                // płeć
                user.IsMale = ConvertToBool(Dt.Rows[0]["plec"].ToString());// (Dt.Rows[0]["plec"].ToString().Trim() == "1" || (bool.TryParse(Dt.Rows[0]["plec"].ToString().Trim(), out _isMale) && _isMale));

                // kod kreskowy
                user.Barcode = Dt.Rows[0]["kod_kresk"].ToString().Trim();

                // typ użytkownika
                int tempUserType;
                if (int.TryParse(Dt.Rows[0]["typuzytk_id"].ToString().Trim(), out tempUserType))
                    user.UserType = tempUserType;
                else
                    user.UserType = null;

                // grupa użytkownika
                int tempUserGroup;
                if (int.TryParse(Dt.Rows[0]["grupa_id"].ToString().Trim(), out tempUserGroup))
                    user.UserGroup = tempUserGroup;
                else
                    user.UserGroup = null;

                // nr legitymacji
                user.CardId = Dt.Rows[0]["nr_legitym"].ToString().Trim();

                // nazwa domenowa
                user.DomainName = Dt.Rows[0]["domena_nazwa"].ToString().Trim();

                // data urodzenia 
                DateTime birthDate;

                if (!DateTime.TryParse(Dt.Rows[0]["data_urodz"].ToString().Trim(), out birthDate))
                    user.BirthDate = null;
                else
                    user.BirthDate = birthDate;

                // limit ilości
                int maxBorrows;
                int.TryParse(Dt.Rows[0]["limit_ilosci"].ToString().Trim(), out maxBorrows);
                user.MaxBorrows = maxBorrows;

                // limit czasu          
                int maxBorrowTime;
                int.TryParse(Dt.Rows[0]["limit_czasu"].ToString().Trim(), out maxBorrowTime);
                user.MaxBorrowTime = maxBorrowTime;

                // uwagi
                user.Comments = Dt.Rows[0]["uwagi"].ToString().Trim();

                // zablokowany
                user.IsLocked = ConvertToBool(Dt.Rows[0]["zablokowany"].ToString());

                // deleted
                user.IsDeleted = ConvertToBool(Dt.Rows[0]["usuniety"].ToString());
            }
        }
        #endregion

        #region private void LoadUserAddresses(User user)
        private void LoadUserAddresses(User user)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_uzytkownik_adresy @user_id; ";
            Command.Parameters.AddWithValue("@user_id", user.UserID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);

            user.Addresses.Clear();

            int addressId;
            int addressType;
            bool isActive;

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                int.TryParse(Dt.Rows[i]["adres_id"].ToString().Trim(), out addressId);
                int.TryParse(Dt.Rows[i]["typadr_id"].ToString().Trim(), out addressType);

                isActive = Dt.Rows[i]["stan"].ToString().Trim() == "1" || (bool.TryParse(Dt.Rows[0]["stan"].ToString().Trim(), out isActive) && isActive);

                UserAddress address = new UserAddress(addressId, addressType, Dt.Rows[i]["miejscowosc"].ToString(), Dt.Rows[i]["ulica"].ToString(), Dt.Rows[i]["nr_domu"].ToString(), Dt.Rows[i]["nr_lokalu"].ToString(), Dt.Rows[i]["kod_poczt"].ToString(), Dt.Rows[i]["poczta"].ToString(), isActive, Dt.Rows[i]["uwagi"].ToString(), user.UserID);
                user.Addresses.Add(address);
            }
        }
        #endregion

        #region private void LoadUserTeleaddresses(User user)
        private void LoadUserTeleaddresses(User user)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_uzytkownik_teleadresy @user_id; ";
            Command.Parameters.AddWithValue("@user_id", user.UserID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);

            user.Teleaddresses.Clear();

            int teleaddressId;
            int teleaddressType;
            bool isActive;

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                int.TryParse(Dt.Rows[i]["teleadr_id"].ToString().Trim(), out teleaddressId);
                int.TryParse(Dt.Rows[i]["typteleadr_id"].ToString().Trim(), out teleaddressType);

                isActive = Dt.Rows[i]["stan"].ToString().Trim() == "1" || (bool.TryParse(Dt.Rows[0]["stan"].ToString().Trim(), out isActive) && isActive);

                UserTeleaddress teleaddress = new UserTeleaddress(teleaddressId, teleaddressType, Dt.Rows[i]["wartosc"].ToString(), isActive, Dt.Rows[i]["uwagi"].ToString(), user.UserID);
                user.Teleaddresses.Add(teleaddress);
            }
        }
        #endregion

        #region private void LoadUserPermissions(User user)
        private void LoadUserPermissions(User user)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_uzytkownik_uprawnienia @user_id; ";
            Command.Parameters.AddWithValue("@user_id", user.UserID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);

            user.Permissions.Clear();

            Guid permissionId;
            int rightsId;
            DateTime start, end;
            bool isLocked;

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Guid.TryParse(Dt.Rows[i]["upraw_id"].ToString().Trim(), out permissionId);
                int.TryParse(Dt.Rows[i]["prawa_id"].ToString().Trim(), out rightsId);
                DateTime.TryParseExact(Dt.Rows[i]["data_od"].ToString().Trim(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out start);
                DateTime.TryParseExact(Dt.Rows[i]["data_do"].ToString().Trim(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out end);

                //isLocked = Dt.Rows[i]["zablokowane"].ToString().Trim() == "1" || (bool.TryParse(Dt.Rows[0]["zablokowane"].ToString().Trim(), out isLocked) && isLocked);

                isLocked = ConvertToBool(Dt.Rows[i]["zablokowane"].ToString().Trim());

                UserPermission userPermission = new UserPermission(permissionId, new Right(rightsId, Dt.Rows[i]["nazwa"].ToString(), false), start, end, isLocked, user.UserID);
                user.Permissions.Add(userPermission);
            }
        }
        #endregion

        #region public int GetUserBorrowsCount(int id)
        public int GetUserBorrowsCount(int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "EXEC w2_uzytkownik_zasoby_niezwrocone_liczba @uzytk_id; ";
            command.Parameters.AddWithValue("@uzytk_id", id);

            DataTable dt = CommonFunctions.ReadData(command, ref Connection);

            if(dt.Rows.Count > 0)
                return Int32.Parse(dt.Rows[0]["liczba"].ToString());

            return -1;
        }
        #endregion

        #region private void LoadWypozyczalniaConfiguration()
        private void LoadWypozyczalniaConfiguration()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_wartosc_konfiguracja_lista; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);

            for(int i = 0; i < Dt.Rows.Count; i++)
            {
                // sort
                if (Dt.Rows[i]["nazwa"].ToString() == "sortowanie1")
                    this.WypozyczalniaConfiguration.Sort1 = (Configuration.SortFields)((decimal)Dt.Rows[i]["wart_N"]);
                else if (Dt.Rows[i]["nazwa"].ToString() == "sortowanie2")
                    this.WypozyczalniaConfiguration.Sort2 = (Configuration.SortFields)((decimal)Dt.Rows[i]["wart_N"]);
                else if (Dt.Rows[i]["nazwa"].ToString() == "sortowanie3")
                    this.WypozyczalniaConfiguration.Sort3 = (Configuration.SortFields)((decimal)Dt.Rows[i]["wart_N"]);
                else if (Dt.Rows[i]["nazwa"].ToString() == "sortowanie4")
                    this.WypozyczalniaConfiguration.Sort4 = (Configuration.SortFields)((decimal)Dt.Rows[i]["wart_N"]);

                // reverse
                else if (Dt.Rows[i]["nazwa"].ToString() == "drukowanie_rewersu")
                    this.WypozyczalniaConfiguration.Reverse = (Configuration.ReverseMode)((decimal)Dt.Rows[i]["wart_N"]);
                // manual search field
                else if (Dt.Rows[i]["nazwa"].ToString() == "pole_wyszukiwania")
                    this.WypozyczalniaConfiguration.ManualSearchField = (Configuration.SearchFieldMode)((decimal)Dt.Rows[i]["wart_N"]);
                // auto
                else if (Dt.Rows[i]["nazwa"].ToString() == "pole_autowyszukiwania")
                    this.WypozyczalniaConfiguration.AutoSearchField = (Configuration.SearchFieldMode)((decimal)Dt.Rows[i]["wart_N"]);
                // compare
                else if (Dt.Rows[i]["nazwa"].ToString() == "sposob_porownania")
                    this.WypozyczalniaConfiguration.Compare = (Configuration.CompareMode)((decimal)Dt.Rows[i]["wart_N"]);
                // is require user is not locked
                else if (Dt.Rows[i]["nazwa"].ToString() == "wymagany_odblokowany_uzytkownik")
                    this.WypozyczalniaConfiguration.RequiredNotLockedUserForBorrow = (Configuration.RequiredNotLockedUserForBorrowMode)((decimal)Dt.Rows[i]["wart_N"]);
                // show barcode
                else if (Dt.Rows[i]["nazwa"].ToString() == "pokaz_kod_kreskowy")
                    this.WypozyczalniaConfiguration.ShowBarcodeColumn = ConvertToBool(Dt.Rows[i]["wart_L"].ToString());

                // Name
                else if (Dt.Rows[i]["nazwa"].ToString() == "biblioteka_nazwa")
                    this.WypozyczalniaConfiguration.InformationAboutUser.Name = Dt.Rows[i]["wart_C"].ToString();
                // Street
                else if (Dt.Rows[i]["nazwa"].ToString() == "biblioteka_ulica")
                    this.WypozyczalniaConfiguration.InformationAboutUser.Street = Dt.Rows[i]["wart_C"].ToString();
                // City
                else if (Dt.Rows[i]["nazwa"].ToString() == "biblioteka_miasto")
                    this.WypozyczalniaConfiguration.InformationAboutUser.City = Dt.Rows[i]["wart_C"].ToString();
                // ZipCode
                else if (Dt.Rows[i]["nazwa"].ToString() == "biblioteka_kod")
                    this.WypozyczalniaConfiguration.InformationAboutUser.ZipCode = Dt.Rows[i]["wart_C"].ToString();
                // PhoneNumber
                else if (Dt.Rows[i]["nazwa"].ToString() == "biblioteka_numer_telefonu")
                    this.WypozyczalniaConfiguration.InformationAboutUser.PhoneNumber = Dt.Rows[i]["wart_C"].ToString();
            }
        }
        #endregion

        #region Dictionary<int, string> GetUserGroupsDictionary()
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns dictionary with ids and names of groups.</returns>
        public Dictionary<int, string> GetUserGroupsDictionary()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_lista_grup 0; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);
            Dictionary<int, string> Items = new Dictionary<int, string>();

            Items.Add(-1, "- BRAK -");

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Items.Add(Int32.Parse(Dt.Rows[i]["grupa_id"].ToString()), Dt.Rows[i]["nazwa"].ToString());
            }

            return Items;
        }
        #endregion

        #region Dictionary<int, string> GetResourceGroupsDictionary()
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns dictionary with ids and names of groups.</returns>
        public Dictionary<int, string> GetResourceGroupsDictionary()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_grupa_zasobow_lista; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);
            Dictionary<int, string> Items = new Dictionary<int, string>();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Items.Add(Int32.Parse(Dt.Rows[i]["grupa_id"].ToString()), Dt.Rows[i]["nazwa"].ToString());
            }

            return Items;
        }
        #endregion

        #region Dictionary<int, string> GetUserTypesDictionary()
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns dictionary with ids and names of user types.</returns>
        public Dictionary<int, string> GetUserTypesDictionary()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_lista_typow_uzytkownikow; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);
            Dictionary<int, string> Items = new Dictionary<int, string>();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Items.Add(Int32.Parse(Dt.Rows[i]["typuzytk_id"].ToString()), Dt.Rows[i]["nazwa"].ToString());
            }

            return Items;
        }
        #endregion

        #region Dictionary<int, string> GetAddressesTypesDictionary()
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns dictionary with ids and names of address types.</returns>
        public Dictionary<int, string> GetAddressesTypesDictionary()
        {
            Dictionary<int, string> addressTypes = new Dictionary<int, string>();

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_lista_typow_adresu; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Connection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                addressTypes.Add(Int32.Parse(Dt.Rows[i]["typadr_id"].ToString()), Dt.Rows[i]["nazwa"].ToString());
            }

            return addressTypes;
        }
        #endregion

        #region Dictionary<int, string> GetTeleaddressTypesDictionary()
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns dictionary with ids and names of teleaddress types.</returns>
        public Dictionary<int, string> GetTeleaddressTypesDictionary()
        {
            Dictionary<int, string> teleaddressTypes = new Dictionary<int, string>();

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_lista_typow_teleadresu; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref this.Connection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                teleaddressTypes.Add(Int32.Parse(Dt.Rows[i]["typteleadr_id"].ToString()), Dt.Rows[i]["nazwa"].ToString());
            }

            return teleaddressTypes;
        }
        #endregion
    }
}