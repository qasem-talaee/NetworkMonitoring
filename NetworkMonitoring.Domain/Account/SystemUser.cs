using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.Account
{
    public class SystemUser
    {
        [Key]
        public int SystemUserID { get; set; }
        public string SystemUserName { get; set; } = string.Empty;
        public string SystemUserPassword { get; set; } = string.Empty;

        public int SystemUserGroupID { get; set; }
        public virtual SystemUserGroup SystemUserGroup { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
