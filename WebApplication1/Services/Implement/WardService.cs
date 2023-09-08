using WebApplication1.AppDb;
using WebApplication1.Dtos;
using WebApplication1.Dtos.WardDto;
using WebApplication1.Enities;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services.Implement
{
	public class WardService : IWardService
	{
		private readonly MyDb _myDb;

		public WardService(MyDb myDb)
		{
			_myDb = myDb;
		}
		public List<Ward> GetAllWard()
		{
			var Wards = _myDb.Wards.ToList();
			return Wards;
		}
		public Ward GetWardById(int id)
		{
			var Ward = _myDb.Wards.FirstOrDefault(x => x.Id == id);

			return Ward ?? throw new Exception("Khong tim thay Tinh Thanh");
		}

		public void CreateWard(CreateWardDto Ward)
		{
			if (_myDb.Wards.Any(o => o.Name == Ward.Name))
			{
				throw new Exception("Trung ten");
			}
			_myDb.Wards.Add(new Ward
			{
				Name = Ward.Name,
				DistrictId = Ward.DistrictId,
			});
			_myDb.SaveChanges();
		}
		public void UpdateWard(UpdateWardDto input)
		{
			var Ward = _myDb.Wards.FirstOrDefault(o => o.Id == input.Id);
			if (Ward == null)
			{
				throw new Exception("Khong tim thay Tinh thanh");
			}
			if (_myDb.Wards.Any(b => b.Name == input.Name))
			{
				throw new Exception("Trung ten");
			}
			Ward.Name = input.Name;
			_myDb.SaveChanges();
		}
		public void DeleteWard(int id)
		{
			var Ward = _myDb.Wards.FirstOrDefault(o => o.Id == id);
			if (Ward == null)
			{
				throw new Exception("Khong tim thay Tinh Thanh");
			}
			_myDb.Wards.Remove(Ward);
			_myDb.SaveChanges();

		}
		
	}
}
