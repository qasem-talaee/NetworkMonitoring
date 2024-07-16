using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetworkMonitoring.Application.Infrastracture.Report;
using NetworkMonitoring.Application.Infrastracture.Service;
using NetworkMonitoring.Domain.Account;
using NetworkMonitoring.Domain.Service;
using NetworkMonitoring.Domain.ViewModels.Report;
using System.Net.NetworkInformation;

namespace NetworkMonitoring.UI.Controllers
{
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private readonly IReport _iReport;
        public ReportController(IReport iReport)
        {
            _iReport = iReport;
        }

        [Authorize(Roles = "EIA")]
        [HttpPost("ReportEquipment")]
        public IEnumerable<ReportEqResultViewModel> GetEquipmentReport([FromBody] ReportEqFilterViewModel model)
        {
            return _iReport.GetEquipmentReport(model);
        }

		[Authorize(Roles = "EIA")]
		[HttpPost("ReportService")]
		public IEnumerable<ReportSrvResultViewModel> GetServiceReport([FromBody] ReportSrvFilterViewModel model)
		{
			return _iReport.GetServiceReport(model);
		}
	}
}
