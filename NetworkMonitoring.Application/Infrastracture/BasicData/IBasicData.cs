using NetworkMonitoring.Domain.Account;
using NetworkMonitoring.Domain.BasicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Application.Infrastracture.BasicData
{
    public interface IBasicData
    {
        #region Type
        Task<string> CreateEquipmentType(EquipmentType model);
        EquipmentType GetEquipmentType(long TypeID);
        IEnumerable<EquipmentType> GetAllEquipmentTypes();
        Task<string> UpdateEquipmentType(EquipmentType model);
        Task<string> DeleteEquipmentType(long TypeID);
        #endregion

        #region Location
        Task<string> CreateEquipmentlocation(EquipmentLocation model);
        EquipmentLocation GetEquipmentlocation(long locationID);
        IEnumerable<EquipmentLocation> GetAllEquipmentlocations();
        Task<string> UpdateEquipmentlocation(EquipmentLocation model);
        Task<string> DeleteEquipmentlocation(EquipmentLocation model);
        #endregion
    }
}
