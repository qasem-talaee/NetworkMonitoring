using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetworkMonitoring.UI.Pages.BasicData
{
	[Authorize(Roles = "ETA")]
	public class EquipmentTypeManagementModel : PageModel
    {
		public void OnGet()
        {
        }
    }
}
