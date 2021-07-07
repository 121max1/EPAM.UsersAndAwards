using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.Common.Entities
{
    public class UserAward
    {
        public UserAward(Guid userID, Guid awardID)
        {
            IdUser = userID;
            IdAward = awardID;
        }

        public Guid IdUser { get; set; }

        public Guid IdAward { get; set; }


    }
}
