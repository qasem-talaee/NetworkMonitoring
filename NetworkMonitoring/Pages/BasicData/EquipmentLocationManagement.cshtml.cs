using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetworkMonitoring.UI.Pages.BasicData
{
	[Authorize(Roles = "ELA")]
	public class EquipmentLocationManagementModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
