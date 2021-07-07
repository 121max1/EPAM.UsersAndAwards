using EPAM.UsersAndAwards.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.BLL.Interfaces
{
    public interface IUserAuthService
    {
        void Add(UserAuth userAuth);

        bool CanLogin(UserAuth userAuth);

        UserAuth GetByLogin(string login);


    }
}
