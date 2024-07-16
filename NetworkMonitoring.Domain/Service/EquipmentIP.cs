using NetworkMonitoring.Domain.BasicData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.Service
{
    public class EquipmentIP
    {
        [Key]
        public long EquipmentIPID { get; set; }
        public string EquipmentIPName { get; set; } = string.Empty;
        public string IPAddress { get; set;} = string.Empty;
        [DefaultValue(true)]
        public bool Status { get; set; }
        

        public long EquipmentLocationID { get; set; }
        public virtual EquipmentLocation EquipmentLocation {  get; set; } 

        public long EquipmentTypeID { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }

        [NotMapped]
        public string Ping { get; set; } = string.Empty;
    }
}
