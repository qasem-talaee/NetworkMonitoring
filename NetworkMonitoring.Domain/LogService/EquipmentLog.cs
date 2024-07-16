using NetworkMonitoring.Domain.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.Log
{
    public class EquipmentLog
    {
        [Key]
        public Guid EquipmentLogID { get; set; }
        public DateTime DownTime { get; set; }
        public DateTime? UpTime { get; set; }

        public long EquipmentIPID { get; set; }
        public virtual EquipmentIP EquipmentIP { get; set; }
    }
}
