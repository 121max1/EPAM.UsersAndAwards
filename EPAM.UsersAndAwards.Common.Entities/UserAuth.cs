using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.Common.Entities
{
    public class UserAuth
    {
        public UserAuth(string login, string password, string roles)
        {
            Login = login;

            Password = password;

            Roles = roles;
            
        }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public string Roles { get; private set; }

    }
}
