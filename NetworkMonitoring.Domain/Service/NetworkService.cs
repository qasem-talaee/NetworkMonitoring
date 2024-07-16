using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Domain.Service
{
	public class NetworkService
	{
		[Key]
		public long NetworkServiceID { get; set; }
		public string NetworkName { get; set; } = string.Empty;

		[DefaultValue(true)]
		public bool IsEnable { get; set; }

    }
}
