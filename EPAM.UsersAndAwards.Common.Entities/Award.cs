using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.Common.Entities
{
    public class Award
    {
        public Award(Guid id, string tittle)
        {
            ID = id;
            Tittle = tittle;
            Users = new List<User>();
        }
        public Guid ID { get; private set; }

        public string Tittle { get; private set; }

        public ICollection<User> Users { get; private set; }

    }
}
