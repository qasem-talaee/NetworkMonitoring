using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using NetworkMonitoring.Application.Infrastracture.Account;
using NetworkMonitoring.Domain.Account;
using NetworkMonitoring.Domain.ViewModels.AccountVms;
using NetworkMonitoring.Domain.ViewModels.Components;



namespace NetworkMonitoring.UI.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccount _iAccount;
        public AccountController(IAccount iAccount)
        {
            _iAccount = iAccount;
        }

        #region System User
        [Authorize(Roles = "UA")]
        [HttpPost("SystemUser")]
        public Task<string> CreateUser([FromBody] SystemUser model)
        {
            return _iAccount.CreateUser(model);
        }

        [Authorize(Roles = "UG")]
        [HttpGet("SystemUser/{systemUserID}")]
        public SystemUser GetUser(int systemUserID)
        {
            return _iAccount.GetUser(systemUserID);
        }

        [Authorize(Roles = "UG")]
        [HttpGet("SystemUser")]
        public IEnumerable<SystemUser> GetAllUser()
        {
            return _iAccount.GetAllUsers();
        }

        [Authorize(Roles = "UU")]
        [HttpPut("SystemUser")]
        public Task<string> UpdateUser([FromBody] SystemUser model)
        {
            return _iAccount.UpdateUser(model);
        }

        [Authorize(Roles = "UD")]
        [HttpDelete("SystemUser/{systemUserID}")]
        public Task<string> DeleteUser(int systemUserID)
        {
            return _iAccount.DeleteUser(systemUserID);
        }


        #endregion

        #region UserGroup
        [Authorize(Roles = "UGA")]
        [HttpPost("UserGroup")]
        public Task<string> CreateUserGroup([FromForm] SystemUserGroup model)
        {
            return _iAccount.CreateUserGroup(model);
        }
        [Authorize(Roles = "UGG")]
        [HttpGet("UserGroup")]
        public IEnumerable<SystemUserGroup> GetAllUserGroup()
        {
            return _iAccount.GetAllUserGroup();
        }
        [Authorize(Roles = "UGU")]
        [HttpPut("UserGroup")]
        public Task<string> UpdateUserGroup([FromForm] SystemUserGroup model)
        {
            return _iAccount.UpdateUserGroup(model);
        }
        [Authorize(Roles = "UGD")]
        [HttpDelete("UserGroup")]
        public Task<string> DeleteUserGroup([FromForm] SystemUserGroup model)
        {
            return _iAccount.DeleteUserGroup(model);
        }
        #endregion

        #region AccessRole
        [Authorize(Roles = "UGA")]
        [HttpGet("GetSystemObjects")]
        public IEnumerable<JsTreeViewModel> GetAllSystemObjects()
        {
            return _iAccount.GetAllSystemObjects();
        }
        [Authorize(Roles = "UGA")]
        [HttpGet("GetUserGroupAccess/{UserGroupID}")]
        public SystemAccessRolesVm GetUserGroupAccessRoles(int UserGroupID)
        {
            return _iAccount.GetUserGroupAccessRoles(UserGroupID);
        }

        [Authorize(Roles = "UGA")]
        [HttpPost("ChangeUserGroupAccessRoles")]
        public Task<string> ChangeUserGroupAccessRoles([FromBody] SystemAccessRolesVm systemAccessRolesVm)//Use For UserManager
        {
            return _iAccount.ChangeUserGroupAccessRoles(systemAccessRolesVm);
        }

        #endregion

        #region Login LogOut
        [HttpPost("Login")]
        public async Task<string> Login([FromBody] ValidateUser vm)
        {
            string res = @"What ? \_(o.O)_/";
            try
            {

                if (!User.Identity.IsAuthenticated)
                {
                    if (ModelState.IsValid)
                    {
                        var user = _iAccount.ValidateUser(vm);
                        if (!user.SystemUserName.Contains("error"))
                        {
                            #region register user Data in session
                            var claims = new List<Claim>
                            {
                                new Claim("SystemUserID", user.SystemUserID.ToString()),
                                new Claim("UserName", user.SystemUserName),
                                new Claim("SystemUserGroupID", user.SystemUserGroupID.ToString()),
                            };

                            foreach (var roles in _iAccount.GetAllUserRoles(user.SystemUserGroupID))
                            {
                                claims.Add(new Claim(ClaimTypes.Role, roles.SystemObject.SystemObjectRole));
                            }

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            var authProperties = new AuthenticationProperties
                            {
                                AllowRefresh = true,
                                //IsPersistent= true,
                                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(40),

                            };

                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                            #endregion
                        }
                        res = user.SystemUserName.Contains("error") ? "ورود امکان پذیر نیست+error|" : "OK";
                    }
                    else
                    {
                        res = "ورود امکان پذیر نیست+error|";
                    }
                }

            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return res;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage("/index");
        }

        [Authorize]
        [HttpPost("ChangeMyPassword")]
        public async Task<string> ChangeUserPasswor([FromBody] PassManageVM passManageVM)
        {
            passManageVM.SystemUserID = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "SystemUserID").Value);
            return await _iAccount.ChangeUserPassword(passManageVM);
        }
        #endregion
    }
}
