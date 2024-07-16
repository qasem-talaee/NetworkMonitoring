using Microsoft.EntityFrameworkCore;
using NetworkMonitoring.Domain.Account;
using NetworkMonitoring.Domain.BasicData;
using NetworkMonitoring.Domain.Log;
using NetworkMonitoring.Domain.LogService;
using NetworkMonitoring.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Database.DBC
{
    public class NetworkMonitoringDbContext : DbContext
    {
        public NetworkMonitoringDbContext(DbContextOptions options) : base(options) { }

        #region Account
        public DbSet<SystemUser> Sys_SystemUser { get; set; }
        public DbSet<SystemUserGroup> Sys_SystemUserGroup { get; set; }
        public DbSet<SystemObject> Sys_SystemObject { get; set; }
        public DbSet<SystemUserAccessRole> Sys_SystemUserAccessRole { get; set; }
        #endregion

        #region BasicData
        public DbSet<EquipmentType> Bs_EquipmentType { get; set; }
        public DbSet<EquipmentLocation> Bs_EquipmentLocation { get; set; }
        #endregion

        #region Service
        public DbSet<EquipmentIP> Srv_EquipmentIP { get; set; }
        public DbSet<NetworkService> Srv_NetworkService { get; set; }
        #endregion

        #region Log Service
        public DbSet<EquipmentLog> Log_EquipmentILog { get; set; }
        public DbSet<NetworkServiceLog> Log_NetworkService { get; set; }
        #endregion
    }
}