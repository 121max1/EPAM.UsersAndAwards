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
    public class UserService : IUserService
    {
        private readonly IUserDAO _userDAO;
        private readonly IAwardDAO _awardDAO;
        private readonly IUserAwardDAO _userAwardDAO;
        public UserService(IUserDAO userDAO, IAwardDAO awardDAO, IUserAwardDAO userAwardDAO)
        {
            _userDAO = userDAO;
            _awardDAO = awardDAO;
            _userAwardDAO = userAwardDAO;
        }
        public void Add(User entity)
        {
            _userDAO.Add(entity);
        }

        public void Delete(User entity)
        {
            _userDAO.Delete(entity);
            _userAwardDAO.DeleteByUser(entity.ID);
        }

        public IEnumerable<User> GetAll()
        {
            foreach (var user in _userDAO.GetAll())
            {
                yield return GetByID(user.ID);
            }
        }


        public User GetByID(Guid id)
        {
            var user = _userDAO.GetByID(id);
            var awardsId = _userAwardDAO.GetAll().Where(p => p.IdUser == id).Select(p => p.IdAward);
            foreach (var award in _awardDAO.GetAll())
            {
                foreach (var awardId in awardsId)
                {
                    if (awardId == award.ID)
                        user.Awards.Add(award);
                }
            }
            return user;
        }

        public void Update(User entity)
        {
            _userDAO.Update(entity);
        }
    }
}
