using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetworkMonitoring.UI.Pages.Account
{
    [Authorize(Roles = "UA")]
    public class ManageSystemUserModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
