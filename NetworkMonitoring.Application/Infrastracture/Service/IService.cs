using NetworkMonitoring.Domain.BasicData;
using NetworkMonitoring.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Application.Infrastracture.Service
{
    public interface IService
    {
        #region Equipment
        Task<string> CreateEquipmentIP(EquipmentIP model);
        EquipmentIP GetEquipmentIP(long TypeID);
        IEnumerable<EquipmentIP> GetAllEquipmentIP();
        Task<string> UpdateEquipmentIP(EquipmentIP model);
        Task<string> DeleteEquipmentIP(long TypeID);

        EquipmentIP GetPing(string ip);
        #endregion


        #region Network Service
        Task<string> CreateNetworkService(NetworkService model);
        NetworkService GetNetworkService(long id);
        IEnumerable<NetworkService> GetAllNetworkService();
        Task<string> UpdateNetworkService(NetworkService model);
        Task<string> DeleteNetworkService(long id);
        #endregion
    }
}
