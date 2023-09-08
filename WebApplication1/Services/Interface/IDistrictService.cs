using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Dtos;
using WebApplication1.Dtos.DistrictDto;
using WebApplication1.Enities;

namespace WebApplication1.Services.Interface
{
	public interface IDistrictService
	{
		List<District> GetAllDistrict();
		District GetDistrictById(int id);
		void CreateDistrict(CreateDistrictDto input);
		void UpdateDistrict(UpdateDistrictDto input);
		void DeleteDistrict(int id);
		List<Ward> GetWardByDistrict(int districtId);



	}
}
