using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Dtos;
using WebApplication1.Dtos.WardDto;
using WebApplication1.Enities;

namespace WebApplication1.Services.Interface
{
	public interface IWardService
	{
		List<Ward> GetAllWard();
		Ward GetWardById(int id);
		void CreateWard(CreateWardDto Ward);
		void UpdateWard(UpdateWardDto Ward);
		void DeleteWard(int id);
		
	}
}
