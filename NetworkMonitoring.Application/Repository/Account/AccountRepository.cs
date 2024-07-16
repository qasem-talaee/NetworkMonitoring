using Microsoft.EntityFrameworkCore;
using NetworkMonitoring.Application.Helper;
using NetworkMonitoring.Application.Infrastracture.Account;
using NetworkMonitoring.Application.Resources;
using NetworkMonitoring.Database.DBC;
using NetworkMonitoring.Domain.Account;
using NetworkMonitoring.Domain.ViewModels.AccountVms;
using NetworkMonitoring.Domain.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Application.Repository.Account
{
    public class AccountRepository : IAccount
    {
        private NetworkMonitoringDbContext _db;
        public AccountRepository(NetworkMonitoringDbContext db)
        {
            _db = db;
        }

        #region SystemUser
        public async Task<string> CreateUser(SystemUser model)
        {
            string res = "";
            try
            {
                var usr = _db.Sys_SystemUser.FirstOrDefault(x => x.SystemUserName.ToLower() == model.SystemUserName.ToLower());
                if (usr == null)
                {
                    model.SystemUserPassword = model.SystemUserPassword.GetHashPss();
                    model.SystemUserName = model.SystemUserName.ToLower();
                    _db.Sys_SystemUser.Add(model);
                    await _db.SaveChangesAsync();
                    res = SystemMessages.OperationSuccess;
                }
                else
                {
                    res = SystemMessages.DuplicateUser;
                }
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public SystemUser GetUser(int userID)
        {
            var usr = _db.Sys_SystemUser.Include(x => x.SystemUserGroup).FirstOrDefault(x => x.SystemUserID == userID);
            usr.SystemUserPassword = "";
            return usr;
        }
        public IEnumerable<SystemUser> GetAllUsers()
        {
            var users = _db.Sys_SystemUser.Include(x => x.SystemUserGroup).ToList();
            users.ForEach(x => x.SystemUserPassword = "");
            return users;
        }
        public async Task<string> UpdateUser(SystemUser model)
        {
            string res = "";
            try
            {
                var usr = _db.Sys_SystemUser.FirstOrDefault(x => x.SystemUserID == model.SystemUserID);
                if (usr != null)
                {
                    if (model.SystemUserPassword == "")
                    {
                        usr.SystemUserName = model.SystemUserName;
                        usr.SystemUserGroupID = model.SystemUserGroupID;
                    }
                    else
                    {
                        usr.SystemUserName = model.SystemUserName;
                        usr.SystemUserGroupID = model.SystemUserGroupID;
                        usr.SystemUserPassword = model.SystemUserPassword.GetHashPss();
                    }
                    usr.SystemUserName = model.SystemUserName.ToLower();
                    _db.Sys_SystemUser.Update(usr);
                    await _db.SaveChangesAsync();
                    res = SystemMessages.OperationSuccess;
                }
                else
                {
                    res = SystemMessages.DuplicateUser;
                }
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public async Task<string> DeleteUser(int userID)
        {
            string res = "";
            try
            {
                var usr = _db.Sys_SystemUser.FirstOrDefault(x => x.SystemUserID == userID);
                if (usr != null)
                {
                    if (usr.SystemUserName != "admin")
                    {
                        usr.IsDeleted = !usr.IsDeleted;
                        _db.Sys_SystemUser.Update(usr);
                        await _db.SaveChangesAsync();
                        res = SystemMessages.OperationSuccess;
                    }
                    else
                    {
                        res = SystemMessages.OperationFaild;
                    }
                }
                else
                {
                    res = SystemMessages.DuplicateUser;
                }
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        #endregion

        #region UserGroup
        public async Task<string> CreateUserGroup(SystemUserGroup model)
        {
            string res;
            try
            {
                _db.Sys_SystemUserGroup.Add(model);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public IEnumerable<SystemUserGroup> GetAllUserGroup()
        {
            return _db.Sys_SystemUserGroup.ToList();
        }
        public async Task<string> UpdateUserGroup(SystemUserGroup model)
        {
            string res;
            try
            {
                _db.Sys_SystemUserGroup.Update(model);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public async Task<string> DeleteUserGroup(SystemUserGroup model)
        {
            string res;
            try
            {
                _db.Sys_SystemUserGroup.Remove(model);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        #endregion

        #region Access Role
        public async Task<string> ChangeUserGroupAccessRoles(SystemAccessRolesVm systemAccessRolesVm)
        {
            string res;
            try
            {
                _db.Sys_SystemUserAccessRole.RemoveRange(_db.Sys_SystemUserAccessRole.Where(x => x.SystemUserGroupID == systemAccessRolesVm.SystemUserGroupID));
                foreach (var item in systemAccessRolesVm.SystemObjects)
                {
                    _db.Sys_SystemUserAccessRole.Add(new SystemUserAccessRole
                    {
                        SystemUserGroupID = systemAccessRolesVm.SystemUserGroupID,
                        SystemObjectID = item
                    });
                }
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public IEnumerable<JsTreeViewModel> GetAllSystemObjects()
        {
            var tr = _db.Sys_SystemObject.ToList();

            List<JsTreeViewModel> list = new List<JsTreeViewModel>();

            foreach (var item in tr)
            {
                JsTreeViewModel node = new()
                {
                    id = item.SystemObjectID.ToString(),
                    state = item.ParentID == -1 ? new State() { opened = true } : new State() { opened = false },
                    parent = item.ParentID == -1 ? "#" : item.ParentID.ToString(),
                    text = item.SystemObjectTitle,
                    type = (item.ParentID.ToString() == "-1") ? "parent" : "child",
                };
                list.Add(node);
            }

            return list;
        }
        public IEnumerable<SystemUserAccessRole> GetAllUserRoles(int SystemUserGroupID)
        {
            return _db.Sys_SystemUserAccessRole.Where(x => x.SystemUserGroupID == SystemUserGroupID).Include(x => x.SystemObject);
        }
        public SystemAccessRolesVm GetUserGroupAccessRoles(int UserGroupID)
        {
            var accR = _db.Sys_SystemUserAccessRole.Where(x => x.SystemUserGroupID == UserGroupID).ToList();
            var lst = new SystemAccessRolesVm();
            accR.ForEach(x => lst.SystemObjects.Add(x.SystemObjectID));
            lst.SystemUserGroupID = UserGroupID;

            return lst;
        }
        #endregion

        #region Verify
        public SystemUser ValidateUser(ValidateUser model)
        {
            var ResUser = new SystemUser() { SystemUserName = "error" };

            var usr = _db.Sys_SystemUser.FirstOrDefault(x => x.SystemUserName == model.SystemUserUserName && x.SystemUserPassword == model.SystemUserPassword.GetHashPss());

            if (usr != null)
            {
                if (!usr.IsDeleted)
                {
                    ResUser = usr;
                }
                else
                {
                    ResUser.SystemUserName = SystemMessages.UserDisabled;
                }
            }
            else
            {
                ResUser.SystemUserName = SystemMessages.WrongUserPass;
            }

            return ResUser;
        }
        #endregion

        #region Manage Password
        public async Task<string> ChangeUserPassword(PassManageVM passManageVM)
        {
            string res = "";
            var user = _db.Sys_SystemUser.Find(passManageVM.SystemUserID);

            if (user.SystemUserPassword == passManageVM.OldPassword.GetHashPss())
            {
                if (passManageVM.NewPassword == passManageVM.RNewPassword)
                {
                    user.SystemUserPassword = passManageVM.NewPassword.GetHashPss();
                    await _db.SaveChangesAsync();
                    res = SystemMessages.OperationSuccess;
                }
                else
                {
                    res = SystemMessages.NewAndRNewNotSimilar;
                }
            }
            else
            {
                res = SystemMessages.WrongOldPass;
            }
            return res;
        }
        #endregion
    }
}
