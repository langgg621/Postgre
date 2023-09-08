using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Dtos.ProvinceDto;
using WebApplication1.Enities;

namespace WebApplication1.Services.Interface
{
	public interface IProvinceService
	{
		List<Province> GetAllProvice();
		Province GetProvinceById(int id);
		void CreateProvince(CreateProvince input);	
		void UpdateProvince(UpdateProvinceDto input);
		void DeleteProvince(int id);
		List<District> GetDistrictByProvince(int provinceId);


	}
}
