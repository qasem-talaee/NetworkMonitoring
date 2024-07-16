using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.ViewModels.AccountVms
{
    public class SystemAccessRolesVm
    {
        public List<int> SystemObjects { get; set; } = new List<int> { 0 };
        public int SystemUserGroupID { get; set; }
    }
}
