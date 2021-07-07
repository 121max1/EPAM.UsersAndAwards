using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.UsersAndAwards.BLL.Interfaces;
using EPAM.UsersAndAwards.Common.Entities;
using EPAM.UsersAndAwards.DAL.Interfaces;

namespace EPAM.UsersAndAwards.BLL
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUserAuthDAO _userAuthDAO;

        public UserAuthService(IUserAuthDAO userAuthDAO)
        {
            _userAuthDAO = userAuthDAO;
        }

        public void Add(UserAuth userAuth)
        {
            _userAuthDAO.Add(userAuth);
        }

        public bool CanLogin(UserAuth userAuth)
        {

            UserAuth userAuthLocal = null; 

            try
            {
                userAuthLocal = _userAuthDAO.GetByLogin(userAuth.Login);
            }
            catch
            {
                return false;
            }
            if (userAuthLocal.Password == userAuth.Password)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public UserAuth GetByLogin(string login)
        {
            return _userAuthDAO.GetByLogin(login);
        }
    }
}
