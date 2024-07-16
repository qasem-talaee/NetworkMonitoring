using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetworkMonitoring.Application.Infrastracture.BasicData;
using NetworkMonitoring.Domain.BasicData;

namespace NetworkMonitoring.UI.Controllers
{
	[Route("[controller]")]
	public class BasicDataController : Controller
	{
		private readonly IBasicData _iBasicData;
		public BasicDataController(IBasicData iBasicData)
		{
			_iBasicData = iBasicData;
		}

		#region Type
		[Authorize(Roles = "ETA")]
		[HttpPost("EquipmentType")]
		public async Task<string> CreateEquipmentType([FromBody] EquipmentType model)
		{
			return await _iBasicData.CreateEquipmentType(model);
		}

		[Authorize(Roles = "ETG")]
		[HttpGet("EquipmentType/{TypeID}")]
		public EquipmentType GetEquipmentType(long TypeID)
		{
			return _iBasicData.GetEquipmentType(TypeID);
		}

		[HttpGet("EquipmentTypeAll")]
		public IEnumerable<EquipmentType> GetAllEquipmentTypes()
		{
			return _iBasicData.GetAllEquipmentTypes();
		}

		[Authorize(Roles = "ETU")]
		[HttpPut("EquipmentType")]
		public async Task<string> UpdateEquipmentType([FromBody] EquipmentType model)
		{
			return await _iBasicData.UpdateEquipmentType(model);
		}

		[Authorize(Roles = "ETD")]
		[HttpDelete("EquipmentType/{TypeID}")]
		public async Task<string> DeleteEquipmentType(long TypeID)
		{
			return await _iBasicData.DeleteEquipmentType(TypeID);
		}
		#endregion

		#region Location
		[Authorize(Roles = "ELA")]
		[HttpPost("EquipmentLocation")]
		public async Task<string> CreateEquipmentlocation([FromForm] EquipmentLocation model)
		{
			return await _iBasicData.CreateEquipmentlocation(model);
		}

		[Authorize(Roles = "ELG")]
		[HttpGet("EquipmentLocation/{locationID}")]
		public EquipmentLocation GetEquipmentlocation(long locationID)
		{
			return _iBasicData.GetEquipmentlocation(locationID);
		}

		[Authorize(Roles = "ELG")]
		[HttpGet("EquipmentLocationAll")]
		public IEnumerable<EquipmentLocation> GetAllEquipmentlocations()
		{
			return _iBasicData.GetAllEquipmentlocations();
		}

		[Authorize(Roles = "ELU")]
		[HttpPut("EquipmentLocation")]
		public async Task<string> UpdateEquipmentlocation([FromForm] EquipmentLocation model)
		{
			return await _iBasicData.UpdateEquipmentlocation(model);
		}

		[Authorize(Roles = "ELD")]
		[HttpDelete("EquipmentLocation")]
		public async Task<string> DeleteEquipmentlocation([FromForm] EquipmentLocation model)
		{
			return await _iBasicData.DeleteEquipmentlocation(model);
		}
		#endregion
	}
}
