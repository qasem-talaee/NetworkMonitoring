using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.BasicData
{
    public class EquipmentLocation
    {
        [Key]
        public long EquipmentLocationID { get; set; }
        public string EquipmentLocationName { get; set; } = string.Empty;
    }
}
