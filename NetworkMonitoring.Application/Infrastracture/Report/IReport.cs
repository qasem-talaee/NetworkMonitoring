using NetworkMonitoring.Domain.ViewModels.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Application.Infrastracture.Report
{
    public interface IReport
    {
        IEnumerable<ReportEqResultViewModel> GetEquipmentReport(ReportEqFilterViewModel eqFilter);
		IEnumerable<ReportSrvResultViewModel> GetServiceReport(ReportSrvFilterViewModel eqFilter);
	}
}
