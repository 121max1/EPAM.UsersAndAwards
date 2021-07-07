using EPAM.UsersAndAwards.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.DAL.Interfaces
{
    public interface IUserAuthDAO
    {
        void Add(UserAuth userAuth);

        UserAuth GetByLogin(string login);

    }
}
