using EPAM.UsersAndAwards.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.BLL.Interfaces
{
    public interface IUserService
    {
        void Add(User entity);

        void Delete(User entity);

        void Update(User entity);

        IEnumerable<User> GetAll();

        User GetByID(Guid id);

    }
}
