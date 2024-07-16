using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetworkMonitoring.UI.Pages.Service
{
    [Authorize(Roles = "EIA")]
    public class EquipmentIPManagementModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
