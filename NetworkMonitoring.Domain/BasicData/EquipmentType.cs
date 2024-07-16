using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.BasicData
{
    public class EquipmentType
    {
        [Key]
        public long EquipmentTypeID { get; set; }
        public string EquipmentTypeName { get; set; } = string.Empty;
        public string EquipmentTypeImage {  get; set; } = string.Empty;
    }
}
