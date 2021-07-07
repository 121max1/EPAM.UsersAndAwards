using EPAM.UsersAndAwards.BLL.Interfaces;
using EPAM.UsersAndAwards.Common.Entities;
using EPAM.UsersAndAwards.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.UsersAndAwards.BLL
{
    public class AwardService : IAwardService
    {
        private readonly IAwardDAO _awardDAO;
        private readonly IUserAwardDAO _userAwardDAO;
        private readonly IUserDAO _userDAO;

        public AwardService(IAwardDAO awardDAO, IUserAwardDAO userAwardDAO, IUserDAO userDAO)
        {
            _awardDAO = awardDAO;
            _userAwardDAO = userAwardDAO;
            _userDAO = userDAO;
        }
        public void Add(Award entity)
        {
            _awardDAO.Add(entity);

        }


        public void Delete(Award award)
        {
            _awardDAO.Delete(award);
            _userAwardDAO.DeleteByAward(award.ID);
        }

        public IEnumerable<Award> GetAll()
        {
            foreach (var award in _awardDAO.GetAll())
            {
                yield return GetByID(award.ID);
            }
        }

        public Award GetByID(Guid id)
        {
            var award = _awardDAO.GetByID(id);
            var usersId = _userAwardDAO.GetAll().Where(p => p.IdAward == id).Select(p => p.IdUser);
            foreach (var user in _userDAO.GetAll())
            {
                foreach (var userId in usersId)
                {
                    if (userId == user.ID)
                        award.Users.Add(user);
                }
            }
            return award;



        }

        public void Update(Award entity)
        {
            _awardDAO.Update(entity);
        }
    }
}
