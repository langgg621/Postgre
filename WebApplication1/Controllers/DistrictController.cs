using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.DistrictDto;
using WebApplication1.Services.Interface;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DistrictController : ControllerBase
	{
		private readonly IDistrictService _DistrictService;
		public DistrictController(IDistrictService DistrictService)
		{
			_DistrictService = DistrictService;
		}
		[HttpPost("create")]
		public IActionResult CreateStudent([FromForm] CreateDistrictDto input)
		{
			try
			{
				_DistrictService.CreateDistrict(input);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
		[HttpPut("update")]
		public IActionResult Update(int id, [FromForm] UpdateDistrictDto input)
		{
			try
			{
				_DistrictService.UpdateDistrict(input);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpDelete("deleted/{id}")]
		public IActionResult Delete(int id)
		{
			try
			{
				_DistrictService.DeleteDistrict(id);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
		[HttpGet]
		[Route("Get-all")]
		public IActionResult GetAll()
		{
			try
			{
				var result = _DistrictService.GetAllDistrict();
				return Ok(result);
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpGet]
		[Route("get-by-id")]
		public IActionResult GetById(int id)
		{
			try
			{
				var result = _DistrictService.GetDistrictById(id);
				return Ok(result);
			}
			catch
			{
				return BadRequest();
			}
		}
		[HttpGet]
		[Route("get-ward-by-districct")]
		public IActionResult GetWardbyDistrict(int id)
		{
			try
			{
				var result = _DistrictService.GetWardByDistrict(id);
				return Ok(result);
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
