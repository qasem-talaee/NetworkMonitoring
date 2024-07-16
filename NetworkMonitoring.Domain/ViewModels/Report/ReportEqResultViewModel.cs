using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.ViewModels.Report
{
    public class ReportEqResultViewModel
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public DateTime DownTime { get; set; }
        public DateTime UpTime { get; set; }
        public string Diffrence {  get; set; }
        public string Total {  get; set; }
    }
}
