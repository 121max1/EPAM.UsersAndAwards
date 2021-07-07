using EPAM.UsersAndAwards.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.BLL.Interfaces
{
    public interface IAwardService
    {
        void Add(Award entity);

        void Delete(Award id);

        void Update(Award entity);

        IEnumerable<Award> GetAll();

        Award GetByID(Guid id);
    }
}
