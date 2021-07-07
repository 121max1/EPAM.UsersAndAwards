using System;
using System.Web.Security;
using EPAM.UsersAndAwards.BLL.Interfaces;
using EPAM.UsersAndAwards.Common.Dependencies;
using EPAM.UsersAndAwards.Common.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace EPAM.UserAwards.WebPages.Models
{
    public class UsersAndAwardsRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var userAuthService = DependenciesResolver.Kernel.GetService<IUserAuthService>();
            UserAuth userAuth = userAuthService.GetByLogin(username);
            return userAuth.Roles.Replace(" ","").Split('|');
            
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userAuthService = DependenciesResolver.Kernel.GetService<IUserAuthService>();
            UserAuth userAuth = userAuthService.GetByLogin(username);
            var roles = userAuth.Roles.Replace(" ", "").Split('|');
            foreach(var role in roles)
            {
                if (role == roleName){
                    return true;
                }
            }
            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}