using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.Common.Entities
{
    public class User
    {

        public User(Guid id, string name, DateTime dateOfBirth, int age)
        {
            ID = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Age = age;
            Awards = new List<Award>();
        }
        public Guid ID { get; private set; }

        public string Name { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public int Age { get; private set; }

        public ICollection<Award> Awards { get; private set; }
    }
}
