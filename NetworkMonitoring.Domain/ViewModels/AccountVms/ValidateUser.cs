using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.ViewModels.AccountVms
{
    public class ValidateUser
    {
        public string SystemUserUserName { get; set; } = string.Empty;
        public string SystemUserPassword { get; set; } = string.Empty;
    }
}
