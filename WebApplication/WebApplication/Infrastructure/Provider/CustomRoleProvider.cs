using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Interface.Services;
namespace WebApplication.Infrastructure.Provider
{
    public class CustomRoleProvider : RoleProvider
    {
        private readonly IUserService UserService;

        public override string ApplicationName { get; set; }
        public CustomRoleProvider()
        {
            UserService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
        }
        public CustomRoleProvider( IUserService userService)
        {
            UserService = userService;
        }
        public override string[] GetRolesForUser(string userName)
        {
            List<string> roles = new List<string>();
            roles.Add( UserService.GetUserRole(userName));
            return roles.ToArray();
        }
        public override bool IsUserInRole(string userName, string userRole)
        {
            return UserService.CheckUserRoles(userName, userRole);
        }

        #region UnusedMethods
        public override bool DeleteRole(string userRole, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string userRole)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] userNames, string[] userRoles)
        {
            throw new NotImplementedException();
        }
        public override string[] GetUsersInRole(string userRole)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string userRole, string userNameToMatch)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string userRole)
        {
            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override void AddUsersToRoles(string[] usernames, string[] userRoles)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
