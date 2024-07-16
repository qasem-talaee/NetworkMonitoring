using NetworkMonitoring.Domain.Account;
using NetworkMonitoring.Domain.ViewModels.AccountVms;
using NetworkMonitoring.Domain.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Application.Infrastracture.Account
{
    public interface IAccount
    {
        #region SystemUser
        Task<string> CreateUser(SystemUser model);
        SystemUser GetUser(int userID);
        IEnumerable<SystemUser> GetAllUsers();
        Task<string> UpdateUser(SystemUser model);
        Task<string> DeleteUser(int userID);
        #endregion

        #region UserGroup
        Task<string> CreateUserGroup(SystemUserGroup model);
        IEnumerable<SystemUserGroup> GetAllUserGroup();
        Task<string> UpdateUserGroup(SystemUserGroup model);
        Task<string> DeleteUserGroup(SystemUserGroup model);
        #endregion

        #region Access Role
        SystemAccessRolesVm GetUserGroupAccessRoles(int UserGroupID);
        Task<string> ChangeUserGroupAccessRoles(SystemAccessRolesVm systemAccessRolesVm);
        IEnumerable<SystemUserAccessRole> GetAllUserRoles(int SystemUserGroupID);
        IEnumerable<JsTreeViewModel> GetAllSystemObjects();
        #endregion

        #region Verify
        SystemUser ValidateUser(ValidateUser model);
        #endregion

        #region Manage Password
        Task<string> ChangeUserPassword(PassManageVM passManageVM);
        #endregion
    }
}
