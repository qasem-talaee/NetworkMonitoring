using Microsoft.EntityFrameworkCore;
using NetworkMonitoring.Application.Infrastracture.Service;
using NetworkMonitoring.Application.Resources;
using NetworkMonitoring.Database.DBC;
using NetworkMonitoring.Domain.Log;
using NetworkMonitoring.Domain.LogService;
using NetworkMonitoring.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Application.Repository.Service
{
    public class ServiceRepository : IService
    {
        private NetworkMonitoringDbContext _db;
        public ServiceRepository(NetworkMonitoringDbContext db)
        {
            _db = db;
        }

        #region Equipment
        public async Task<string> CreateEquipmentIP(EquipmentIP model)
        {
            string res = "";
            try
            {
                _db.Srv_EquipmentIP.Add(model);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public EquipmentIP GetEquipmentIP(long TypeID)
        {
            return _db.Srv_EquipmentIP.Include(x => x.EquipmentType).Include(x => x.EquipmentLocation).FirstOrDefault(x => x.EquipmentTypeID == TypeID);
        }
        public IEnumerable<EquipmentIP> GetAllEquipmentIP()
        {
            return _db.Srv_EquipmentIP.Include(x => x.EquipmentType).Include(x => x.EquipmentLocation).ToList();
        }
        public async Task<string> UpdateEquipmentIP(EquipmentIP model)
        {
            string res = "";
            try
            {
                var eq = _db.Srv_EquipmentIP.FirstOrDefault(x => x.EquipmentIPID == model.EquipmentIPID);
                eq.EquipmentIPName = model.EquipmentIPName;
                eq.IPAddress = model.IPAddress;
                eq.EquipmentLocationID = model.EquipmentLocationID;
                eq.EquipmentTypeID = model.EquipmentTypeID;
                _db.Srv_EquipmentIP.Update(eq);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public async Task<string> DeleteEquipmentIP(long TypeID)
        {
            string res = "";
            try
            {
                EquipmentIP equipment = _db.Srv_EquipmentIP.FirstOrDefault(x => x.EquipmentIPID == TypeID);
                _db.Srv_EquipmentIP.Remove(equipment);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }

        public EquipmentIP GetPing(string ip)
        {
            EquipmentIP eq = _db.Srv_EquipmentIP.FirstOrDefault(x => x.IPAddress == ip);
            EquipmentLog eqLog = _db.Log_EquipmentILog.Where(x => x.EquipmentIPID == eq.EquipmentIPID && x.UpTime == null).FirstOrDefault();

            var reply = new Ping().Send(eq.IPAddress, 2000);
            if (reply != null)
            {
                if(reply.Status.ToString() != "Success")
                {
                    if(eqLog == null)
                    {
                        EquipmentLog eqLogAdd = new EquipmentLog()
                        {
                            EquipmentLogID = new Guid(),
                            DownTime = DateTime.Now,
                            UpTime = null,
                            EquipmentIPID = eq.EquipmentIPID,
                        };
                        _db.Log_EquipmentILog.Add(eqLogAdd);
                        _db.SaveChanges();
                    }
                    eq.Status = false;
                    eq.Ping = "No Ping";
                }
                else
                {
                    if (eqLog != null)
                    {
                        eqLog.UpTime = DateTime.Now;
                        _db.Log_EquipmentILog.Update(eqLog);
                        _db.SaveChanges();
                    }
                    eq.Status = true;
                    eq.Ping = reply.RoundtripTime.ToString() + " ms";
                }
            }
            return eq;
        }

        #endregion


        #region Network Service
        public async Task<string> CreateNetworkService(NetworkService model)
        {
            string res = "";
            try
            {
                _db.Srv_NetworkService.Add(model);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public NetworkService GetNetworkService(long id)
        {
            return _db.Srv_NetworkService.FirstOrDefault(x => x.NetworkServiceID == id);
        }
        public IEnumerable<NetworkService> GetAllNetworkService()
        {
            return _db.Srv_NetworkService.ToList();
        }
        public async Task<string> UpdateNetworkService(NetworkService model)
        {
            string res = "";
            try
            {
                var eq = _db.Srv_NetworkService.FirstOrDefault(x => x.NetworkServiceID == model.NetworkServiceID);
                if(model.IsEnable != eq.IsEnable)
                {
                    if (!model.IsEnable)
                    {
                        NetworkServiceLog LogAdd = new NetworkServiceLog()
                        {
                            NetworkServiceLogID = new Guid(),
                            DownTime = DateTime.Now,
                            UpTime = null,
                            NetworkServiceID = eq.NetworkServiceID,
                        };
                        _db.Log_NetworkService.Add(LogAdd);
                        _db.SaveChanges();
                    }
                    else
                    {
                        NetworkServiceLog eqLog = _db.Log_NetworkService.Where(x => x.NetworkServiceID == eq.NetworkServiceID && x.UpTime == null).FirstOrDefault();
                        eqLog.UpTime = DateTime.Now;
                        _db.Log_NetworkService.Update(eqLog);
                        _db.SaveChanges();
                    }
                }
                eq.NetworkName = model.NetworkName;
                eq.IsEnable = model.IsEnable;
                _db.Srv_NetworkService.Update(eq);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public async Task<string> DeleteNetworkService(long id)
        {
            string res = "";
            try
            {
                NetworkService equipment = _db.Srv_NetworkService.FirstOrDefault(x => x.NetworkServiceID == id);
                _db.Srv_NetworkService.Remove(equipment);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        #endregion
    }
}
