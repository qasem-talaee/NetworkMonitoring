using NetworkMonitoring.Application.Infrastracture.BasicData;
using NetworkMonitoring.Application.Resources;
using NetworkMonitoring.Database.DBC;
using NetworkMonitoring.Domain.BasicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitoring.Application.Repository.BasicData
{
    public class BasicDataRepository : IBasicData
    {
        private NetworkMonitoringDbContext _db;
        public BasicDataRepository(NetworkMonitoringDbContext db)
        {
            _db = db;
        }

        #region Type
        public async Task<string> CreateEquipmentType(EquipmentType model)
        {
            string res = "";
            try
            {
                _db.Bs_EquipmentType.Add(model);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public EquipmentType GetEquipmentType(long TypeID)
        {
            return _db.Bs_EquipmentType.FirstOrDefault(x => x.EquipmentTypeID == TypeID);
        }
        public IEnumerable<EquipmentType> GetAllEquipmentTypes()
        {
            return _db.Bs_EquipmentType.ToList();
        }
        public async Task<string> UpdateEquipmentType(EquipmentType model)
        {
            string res = "";
            try
            {
                var usr = _db.Bs_EquipmentType.FirstOrDefault(x => x.EquipmentTypeID == model.EquipmentTypeID);
                if (usr != null)
                {
                    if (model.EquipmentTypeImage == "")
                    {
                        usr.EquipmentTypeName = model.EquipmentTypeName;
                    }
                    else
                    {
                        usr.EquipmentTypeName = model.EquipmentTypeName;
                        usr.EquipmentTypeImage = model.EquipmentTypeImage;
                    }
                    _db.Bs_EquipmentType.Update(usr);
                    await _db.SaveChangesAsync();
                    res = SystemMessages.OperationSuccess;
                }
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public async Task<string> DeleteEquipmentType(long TypeID)
        {
            string res = "";
            try
            {
                _db.Bs_EquipmentType.Remove(_db.Bs_EquipmentType.FirstOrDefault(x => x.EquipmentTypeID == TypeID));
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

        #region Location
        public async Task<string> CreateEquipmentlocation(EquipmentLocation model)
        {
            string res = "";
            try
            {
                _db.Bs_EquipmentLocation.Add(model);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public EquipmentLocation GetEquipmentlocation(long locationID)
        {
            return _db.Bs_EquipmentLocation.FirstOrDefault(x => x.EquipmentLocationID == locationID);
        }
        public IEnumerable<EquipmentLocation> GetAllEquipmentlocations()
        {
            return _db.Bs_EquipmentLocation.ToList();
        }
        public async Task<string> UpdateEquipmentlocation(EquipmentLocation model)
        {
            string res = "";
            try
            {
                _db.Bs_EquipmentLocation.Update(model);
                await _db.SaveChangesAsync();
                res = SystemMessages.OperationSuccess;
            }
            catch (Exception)
            {
                res = SystemMessages.OperationFaild;
            }
            return res;
        }
        public async Task<string> DeleteEquipmentlocation(EquipmentLocation model)
        {
            string res = "";
            try
            {
                _db.Bs_EquipmentLocation.Remove(model);
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
