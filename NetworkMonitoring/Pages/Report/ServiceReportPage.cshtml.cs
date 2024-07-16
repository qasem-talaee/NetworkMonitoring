using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetworkMonitoring.UI.Pages.Report
{
    [Authorize(Roles = "ETA")]
    public class ServiceReportPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
