using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.ProvinceDto;
using WebApplication1.Services.Interface;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProvinceController:ControllerBase
	{
		private readonly IProvinceService _provinceService;
		public ProvinceController(IProvinceService provinceService)
		{
			_provinceService = provinceService;
		}
		[HttpPost("create")]
		public IActionResult CreateStudent([FromForm] CreateProvince input)
		{
			try
			{
				_provinceService.CreateProvince(input);
				return Ok();
			}
			catch
			{ 
				return BadRequest();
			}
		}
		[HttpPut("update")]
		public IActionResult Update(int id, [FromForm] UpdateProvinceDto input)
		{
			try
			{
				_provinceService.UpdateProvince(input);
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
				_provinceService.DeleteProvince(id);
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
				var result = _provinceService.GetAllProvice();
				return Ok(result);
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpGet]
		[Route("get-district-by-province")]
		public IActionResult GetById(int id)
		{
			try
			{
				var result = _provinceService.GetDistrictByProvince(id);
				return Ok(result);
			}
			catch
			{
				return BadRequest();
			}
		}

	}
}
