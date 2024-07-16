using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.ViewModels.Report
{
	public class ReportSrvFilterViewModel
	{
		public long? ServiceID { get; set; } = null;
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
	}
}
