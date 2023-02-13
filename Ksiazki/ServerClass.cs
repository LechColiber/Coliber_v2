using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ksiazki
{
    class ServerClass
    {
        public int ID;
        public string Host;
        public int Port;
        public string Database;
        public string Name;
        public string User;
        public string Password;
        public string Comments;

        public ServerClass(int ID, string Host, int Port, string Database, string Name, string User, string Password, string Comments)
        {
            this.ID = ID;
            this.Host = Host;
            this.Port = Port;
            this.Database = Database;
            this.Name = Name;
            this.User = User;
            this.Password = Password;
            this.Comments = Comments;
        }
    }
}
