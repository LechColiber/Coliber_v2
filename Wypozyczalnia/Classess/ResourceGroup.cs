using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Wypozyczalnia
{
    public class ResourceGroup : Group
    {
        public ResourceGroup() : base()
        {

        }

        public ResourceGroup(string name, string comments, bool isActive, short? timeLimit) : base(name, comments, isActive, timeLimit)
        {
           
        }

        public ResourceGroup(int groupId, string name, string comments, bool isActive, short? timeLimit) : base(groupId, name, comments, isActive, timeLimit)
        {

        }

        public override void prepareSaveCommand(ref SqlCommand command, object owner)
        {
            // add resource group
            if (_currentMode == CreatingMode.New)
            {
                SqlParameter groupIdParameter = new SqlParameter();
                groupIdParameter.ParameterName = "@grupaId" + this.HashCode;
                groupIdParameter.SqlValue = -1;
                groupIdParameter.Direction = System.Data.ParameterDirection.InputOutput;

                command.Parameters.Add(groupIdParameter);

                command.CommandText += string.Format("EXEC w2_grupa_zasobow_dodaj @nazwa{0}, @uwagi{0}, @aktywna{0}, @limit_czasu{0}, @grupaId{0} OUTPUT; ", this.HashCode);
            }
            // edit resource group
            else if (_currentMode == CreatingMode.Edit)
            {
                command.CommandText += string.Format("EXEC w2_grupa_zasobow_edytuj @nazwa{0}, @uwagi{0}, @aktywna{0}, @limit_czasu{0}, @grupaId{0}; ", this.HashCode);
                command.Parameters.AddWithValue("@grupaId" + this.HashCode, this.GroupId);
            }

            command.Parameters.AddWithValue("@nazwa" + this.HashCode, this.Name);
            command.Parameters.AddWithValue("@uwagi" + this.HashCode, !string.IsNullOrWhiteSpace(this.Comments) ? this.Comments as object : DBNull.Value);
            command.Parameters.AddWithValue("@aktywna" + this.HashCode, this.IsActive);
            command.Parameters.AddWithValue("@limit_czasu" + this.HashCode, this.TimeLimit);

            // delete rights
            foreach (var rightId in Rights.ValuesToDelete)
            {
                command.CommandText += string.Format("EXEC w2_grupa_zasobow_prawa_usun @grupaId{0}, @prawaId{1}_{0}; ", this.HashCode, rightId);
                command.Parameters.AddWithValue(string.Format("@prawaId{1}_{0}", this.HashCode, rightId), rightId);
            }

            // add rights
            foreach (var right in Rights.Values.Where(x => x.CurrentMode == CreatingMode.New || x.CurrentMode == CreatingMode.Edit))
            {
                command.CommandText += string.Format("EXEC w2_grupa_zasobow_prawa_dodaj @grupaId{0}, @prawaId{1}; ", this.HashCode, right.HashCode);
                command.Parameters.AddWithValue("@prawaId" + right.HashCode, right.RightId);
            }
        }
    }
}
