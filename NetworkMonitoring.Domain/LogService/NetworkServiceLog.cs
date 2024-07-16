using NetworkMonitoring.Domain.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.LogService
{
    public class NetworkServiceLog
    {
        [Key]
        public Guid NetworkServiceLogID { get; set; }
        public DateTime DownTime { get; set; }
        public DateTime? UpTime { get; set; }

        public long NetworkServiceID { get; set; }
        public virtual NetworkService NetworkService { get; set; }
    }
}
