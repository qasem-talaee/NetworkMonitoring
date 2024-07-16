using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.ViewModels.Report
{
    public class ReportEqFilterViewModel
    {
        public string? IPAddress { get; set; } = null;
        public long? Type { get; set; } = null;
        public long? Location { get; set; } = null;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
