using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetworkMonitoring.Application.Infrastracture.Service;
using NetworkMonitoring.Domain.Account;
using NetworkMonitoring.Domain.Service;
using System.Net.NetworkInformation;

namespace NetworkMonitoring.UI.Controllers
{
    [Route("[controller]")]
    public class ServiceController : Controller
    {
        private readonly IService _iService;
        public ServiceController(IService iService)
        {
            _iService = iService;
        }

        #region Equipment
        [Authorize(Roles = "EIA")]
        [HttpPost("EquipmentIP")]
        public async Task<string> CreateEquipmentIP([FromBody] EquipmentIP model)
        {
            return await _iService.CreateEquipmentIP(model);
        }

        [Authorize(Roles = "EIG")]
        [HttpGet("EquipmentIP/{TypeID}")]
        public EquipmentIP GetEquipmentIP(long TypeID)
        {
            return _iService.GetEquipmentIP(TypeID);
        }

        [HttpGet("EquipmentIPAll")]
        public IEnumerable<EquipmentIP> GetAllEquipmentIP()
        {
            return _iService.GetAllEquipmentIP();
        }

        [Authorize(Roles = "EIU")]
        [HttpPut("EquipmentIP")]
        public async Task<string> UpdateEquipmentIP([FromBody] EquipmentIP model)
        {
            return await _iService.UpdateEquipmentIP(model);
        }

        [Authorize(Roles = "EID")]
        [HttpDelete("EquipmentIP/{TypeID}")]
        public async Task<string> DeleteEquipmentIP(long TypeID)
        {
            return await _iService.DeleteEquipmentIP(TypeID);
        }

        [HttpGet("EquipmentGetPing/{ip}")]
        public EquipmentIP GetPing(string ip)
        {
            return _iService.GetPing(ip);
        }
        #endregion

        #region Network Service
        [Authorize(Roles = "EIA")]
        [HttpPost("NetworkService")]
        public async Task<string> CreateNetworkService([FromBody] NetworkService model)
        {
            return await _iService.CreateNetworkService(model);
        }

        [Authorize(Roles = "EIG")]
        [HttpGet("NetworkService/{id}")]
        public NetworkService GetNetworkService(long id)
        {
            return _iService.GetNetworkService(id);
        }

        [Authorize(Roles = "EIG")]
        [HttpGet("NetworkServiceAll")]
        public IEnumerable<NetworkService> GetAllNetworkService()
        {
            return _iService.GetAllNetworkService();
        }

        [Authorize(Roles = "EIU")]
        [HttpPut("NetworkService")]
        public async Task<string> UpdateNetworkService([FromBody] NetworkService model)
        {
            return await _iService.UpdateNetworkService(model);
        }

        [Authorize(Roles = "EID")]
        [HttpDelete("NetworkService/{id}")]
        public async Task<string> DeleteNetworkService(long id)
        {
            return await _iService.DeleteNetworkService(id);
        }

        #endregion

    }
}
