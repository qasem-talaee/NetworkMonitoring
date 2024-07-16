using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetworkMonitoring.UI.Pages.Account
{
    [Authorize]
    public class ManageUserPasswordModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
