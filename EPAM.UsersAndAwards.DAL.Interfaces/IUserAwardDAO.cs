using EPAM.UsersAndAwards.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.DAL.Interfaces
{
    public interface IUserAwardDAO
    {
        void Add(Guid userID, Guid awardID);
        void DeleteByAward(Guid awardID);

        void DeleteByUser(Guid userID);

        IEnumerable<UserAward> GetAll();
    }
}
