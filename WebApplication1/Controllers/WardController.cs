using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.WardDto;
using WebApplication1.Services.Interface;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WardController : ControllerBase
	{
		private readonly IWardService _WardService;
		public WardController(IWardService WardService)
		{
			_WardService = WardService;
		}
		[HttpPost("create")]
		public IActionResult CreateStudent([FromForm] CreateWardDto input)
		{
			try
			{
				_WardService.CreateWard(input);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
		[HttpPut("update")]
		public IActionResult Update(int id, [FromForm] UpdateWardDto input)
		{
			try
			{
				_WardService.UpdateWard(input);
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
				_WardService.DeleteWard(id);
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
				var result = _WardService.GetAllWard();
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
				var result = _WardService.GetWardById(id);
				return Ok(result);
			}
			catch
			{
				return BadRequest();
			}
		}
		
	}
}
