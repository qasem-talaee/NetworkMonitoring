using Microsoft.EntityFrameworkCore;
using NetworkMonitoring.Application.Infrastracture.Report;
using NetworkMonitoring.Database.DBC;
using NetworkMonitoring.Domain.Log;
using NetworkMonitoring.Domain.ViewModels.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Application.Repository.Report
{
    public class ReportRepository : IReport
    {
        private NetworkMonitoringDbContext _db;
        public ReportRepository(NetworkMonitoringDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ReportEqResultViewModel> GetEquipmentReport(ReportEqFilterViewModel eqFilter)
        {
            List< ReportEqResultViewModel> res = new List< ReportEqResultViewModel>();
			eqFilter.FromDate = eqFilter.FromDate.AddDays(1);
			eqFilter.ToDate = eqFilter.ToDate.AddDays(1);
			DateTime FromTime = new DateTime(eqFilter.FromDate.Year, eqFilter.FromDate.Month, eqFilter.FromDate.Day, 0, 0, 0);
            DateTime ToTime = new DateTime(eqFilter.ToDate.Year, eqFilter.ToDate.Month, eqFilter.ToDate.Day, 23, 59, 59);
            TimeSpan Total = new TimeSpan();

            if (eqFilter.Type == null && eqFilter.Location == null && eqFilter.IPAddress != null)
            {
                var device = _db.Srv_EquipmentIP.Include(x => x.EquipmentType).Include(x => x.EquipmentLocation).FirstOrDefault(x => x.IPAddress == eqFilter.IPAddress);
				var Times = _db.Log_EquipmentILog.Where(
					x => x.EquipmentIPID == device.EquipmentIPID &&
					x.UpTime != null &&
					x.DownTime >= FromTime &&
					x.UpTime <= ToTime
				).ToList();
                foreach (var item in Times)
                {
                    TimeSpan diffrence = (item.UpTime ?? DateTime.Now) - item.DownTime;
                    Total += diffrence;
                    string ResultDiffrence = diffrence.Hours.ToString() + ":" + diffrence.Minutes.ToString() + ":" + diffrence.Seconds.ToString();
					string TotalDiffrence = Total.Days.ToString() + " Days " + Total.Hours.ToString() + " Hours " + Total.Minutes.ToString() + " Minutes " + Total.Seconds.ToString() + " Seconds";
					ReportEqResultViewModel report = new ReportEqResultViewModel()
                    {
                        Name = device.EquipmentIPName,
                        IPAddress = device.IPAddress,
                        Location = device.EquipmentLocation.EquipmentLocationName,
                        Type = device.EquipmentType.EquipmentTypeName,
                        DownTime = item.DownTime,
                        UpTime = item.UpTime ?? DateTime.Now,
                        Diffrence = ResultDiffrence,
                        Total = TotalDiffrence,
					};
                    res.Add(report);
                }
            }
            if (eqFilter.Type == null && eqFilter.Location != null && eqFilter.IPAddress == null)
            {
                var devices = _db.Srv_EquipmentIP.Include(x => x.EquipmentType).Include(x => x.EquipmentLocation).Where(x => x.EquipmentLocationID == eqFilter.Location).ToList();
				foreach (var device in devices)
                {
					var Times = _db.Log_EquipmentILog.Where(
					x => x.EquipmentIPID == device.EquipmentIPID &&
					x.UpTime != null &&
					x.DownTime >= FromTime &&
					x.UpTime <= ToTime
					).ToList();
					foreach (var item in Times)
					{
						TimeSpan diffrence = (item.UpTime ?? DateTime.Now) - item.DownTime;
						Total += diffrence;
						string ResultDiffrence = diffrence.Hours.ToString() + ":" + diffrence.Minutes.ToString() + ":" + diffrence.Seconds.ToString();
						string TotalDiffrence = Total.Days.ToString() + " Days " + Total.Hours.ToString() + " Hours " + Total.Minutes.ToString() + " Minutes " + Total.Seconds.ToString() + " Seconds";
						ReportEqResultViewModel report = new ReportEqResultViewModel()
						{
							Name = device.EquipmentIPName,
							IPAddress = device.IPAddress,
							Location = device.EquipmentLocation.EquipmentLocationName,
							Type = device.EquipmentType.EquipmentTypeName,
							DownTime = item.DownTime,
							UpTime = item.UpTime ?? DateTime.Now,
							Diffrence = ResultDiffrence,
							Total = TotalDiffrence,
						};
						res.Add(report);
					}
				}
            }
            if (eqFilter.Type != null && eqFilter.Location == null && eqFilter.IPAddress == null)
            {
				var devices = _db.Srv_EquipmentIP.Include(x => x.EquipmentType).Include(x => x.EquipmentLocation).Where(x => x.EquipmentTypeID == eqFilter.Type).ToList();
				foreach (var device in devices)
				{
					var Times = _db.Log_EquipmentILog.Where(
					x => x.EquipmentIPID == device.EquipmentIPID &&
					x.UpTime != null &&
					x.DownTime >= FromTime &&
					x.UpTime <= ToTime
					).ToList();
					foreach (var item in Times)
					{
						TimeSpan diffrence = (item.UpTime ?? DateTime.Now) - item.DownTime;
						Total += diffrence;
						string ResultDiffrence = diffrence.Hours.ToString() + ":" + diffrence.Minutes.ToString() + ":" + diffrence.Seconds.ToString();
						string TotalDiffrence = Total.Days.ToString() + " Days " + Total.Hours.ToString() + " Hours " + Total.Minutes.ToString() + " Minutes " + Total.Seconds.ToString() + " Seconds";
						ReportEqResultViewModel report = new ReportEqResultViewModel()
						{
							Name = device.EquipmentIPName,
							IPAddress = device.IPAddress,
							Location = device.EquipmentLocation.EquipmentLocationName,
							Type = device.EquipmentType.EquipmentTypeName,
							DownTime = item.DownTime,
							UpTime = item.UpTime ?? DateTime.Now,
							Diffrence = ResultDiffrence,
							Total = TotalDiffrence,
						};
						res.Add(report);
					}
				}
			}
			if (eqFilter.Type == null && eqFilter.Location == null && eqFilter.IPAddress == null)
			{
				var devices = _db.Srv_EquipmentIP.Include(x => x.EquipmentType).Include(x => x.EquipmentLocation).ToList();
				foreach (var device in devices)
                {
                    var Times = _db.Log_EquipmentILog.Where(
                    x => x.EquipmentIPID == device.EquipmentIPID &&
                    x.UpTime != null &&
					x.DownTime >= FromTime &&
					x.UpTime <= ToTime
					).ToList();
                    foreach (var item in Times)
					{
						TimeSpan diffrence = (item.UpTime ?? DateTime.Now) - item.DownTime;
						Total += diffrence;
						string ResultDiffrence = diffrence.Hours.ToString() + ":" + diffrence.Minutes.ToString() + ":" + diffrence.Seconds.ToString();
                        string TotalDiffrence = Total.Days.ToString() + " Days " + Total.Hours.ToString() + " Hours " + Total.Minutes.ToString() + " Minutes " + Total.Seconds.ToString() + " Seconds";
                        ReportEqResultViewModel report = new ReportEqResultViewModel()
						{
							Name = device.EquipmentIPName,
							IPAddress = device.IPAddress,
							Location = device.EquipmentLocation.EquipmentLocationName,
							Type = device.EquipmentType.EquipmentTypeName,
							DownTime = item.DownTime,
							UpTime = item.UpTime ?? DateTime.Now,
							Diffrence = ResultDiffrence,
							Total = TotalDiffrence,
						};
						res.Add(report);
					}
				}
			}

			return res;
        }


		public IEnumerable<ReportSrvResultViewModel> GetServiceReport(ReportSrvFilterViewModel SrvFilter)
		{
			List<ReportSrvResultViewModel> res = new List<ReportSrvResultViewModel>();
			SrvFilter.FromDate = SrvFilter.FromDate.AddDays(1);
			SrvFilter.ToDate = SrvFilter.ToDate.AddDays(1);
			DateTime FromTime = new DateTime(SrvFilter.FromDate.Year, SrvFilter.FromDate.Month, SrvFilter.FromDate.Day, 0, 0, 0);
			DateTime ToTime = new DateTime(SrvFilter.ToDate.Year, SrvFilter.ToDate.Month, SrvFilter.ToDate.Day, 23, 59, 59);
			TimeSpan Total = new TimeSpan();

			if (SrvFilter.ServiceID == null)
			{
				var services = _db.Srv_NetworkService.ToList();
				foreach (var service in services)
				{
					var Times = _db.Log_NetworkService.Where(
					x => x.NetworkServiceID == service.NetworkServiceID &&
					x.UpTime != null &&
					x.DownTime >= FromTime &&
					x.UpTime <= ToTime
					).ToList();
					foreach (var item in Times)
					{
						TimeSpan diffrence = (item.UpTime ?? DateTime.Now) - item.DownTime;
						Total += diffrence;
						string ResultDiffrence = diffrence.Hours.ToString() + ":" + diffrence.Minutes.ToString() + ":" + diffrence.Seconds.ToString();
						string TotalDiffrence = Total.Days.ToString() + " Days " + Total.Hours.ToString() + " Hours " + Total.Minutes.ToString() + " Minutes " + Total.Seconds.ToString() + " Seconds";
						ReportSrvResultViewModel report = new ReportSrvResultViewModel()
						{
							ServiceName = service.NetworkName,
							DownTime = item.DownTime,
							UpTime = item.UpTime ?? DateTime.Now,
							Diffrence = ResultDiffrence,
							Total = TotalDiffrence,
						};
						res.Add(report);
					}
				}
			}
			else
			{
				var service = _db.Srv_NetworkService.FirstOrDefault(x => x.NetworkServiceID == SrvFilter.ServiceID);
				var Times = _db.Log_NetworkService.Where(
					x => x.NetworkServiceID == service.NetworkServiceID &&
					x.UpTime != null &&
					x.DownTime >= FromTime &&
					x.UpTime <= ToTime
					).ToList();
				foreach (var item in Times)
				{
					TimeSpan diffrence = (item.UpTime ?? DateTime.Now) - item.DownTime;
					Total += diffrence;
					string ResultDiffrence = diffrence.Hours.ToString() + ":" + diffrence.Minutes.ToString() + ":" + diffrence.Seconds.ToString();
					string TotalDiffrence = Total.Days.ToString() + " Days " + Total.Hours.ToString() + " Hours " + Total.Minutes.ToString() + " Minutes " + Total.Seconds.ToString() + " Seconds";
					ReportSrvResultViewModel report = new ReportSrvResultViewModel()
					{
						ServiceName = service.NetworkName,
						DownTime = item.DownTime,
						UpTime = item.UpTime ?? DateTime.Now,
						Diffrence = ResultDiffrence,
						Total = TotalDiffrence,
					};
					res.Add(report);
				}
			}
			return res;
		}

	}
}
