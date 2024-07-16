using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetworkMonitoring.UI.Pages.Account
{
    [Authorize(Roles = "UGA")]
    public class ManageSystemUserGroupModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
