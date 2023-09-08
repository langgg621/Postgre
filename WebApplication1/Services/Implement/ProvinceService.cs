using WebApplication1.AppDb;
using WebApplication1.Dtos.ProvinceDto;
using WebApplication1.Enities;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services.Implement
{
	public class ProvinceService : IProvinceService
	{
		private readonly MyDb _myDb;

		public ProvinceService(MyDb myDb)
		{
			_myDb = myDb;
		}
		public List<Province> GetAllProvice()
		{
			var provinces = _myDb.Provinces.ToList();
			return provinces;
		}
		public Province GetProvinceById(int id)
		{
			var province = _myDb.Provinces.FirstOrDefault(x => x.Id == id);

			if (province == null)
			{
				throw new Exception("Khong tim thay Tinh Thanh");

			}
			return province;
		}

		public void CreateProvince(CreateProvince province)
		{
			if (_myDb.Provinces.Any(o => o.Name == province.Name))
			{
				throw new Exception("Trung ten");
			}
			_myDb.Provinces.Add(new Province
			{
				Name = province.Name
			});
			_myDb.SaveChanges();
		}
		public void UpdateProvince(UpdateProvinceDto input)
		{
			var province = _myDb.Provinces.FirstOrDefault(o => o.Id == input.Id);
			if (province == null)
			{
				throw new Exception("Khong tim thay Tinh thanh");
			}
			if (_myDb.Provinces.Any(b => b.Name == input.Name))
			{
				throw new Exception("Trung ten");
			}
			province.Name = input.Name;
			_myDb.SaveChanges();
		}
		public void DeleteProvince(int id)
		{
			var province = _myDb.Provinces.FirstOrDefault(o => o.Id == id);
			if (province == null)
			{
				throw new Exception("Khong tim thay Tinh Thanh");
			}
			_myDb.Provinces.Remove(province);
			_myDb.SaveChanges();
		}
		public List<District> GetDistrictByProvince(int provinceId)
		{
			var provinecs = _myDb.Districts
				.Where(p => p.ProvinceId == provinceId).Select(p => p.Id).ToList();
			var Dis = from P in _myDb.Provinces
					  join D in _myDb.Districts
					  on P.Id equals D.ProvinceId
					  where D.ProvinceId == provinceId
					  select new
					  {
						  D
					  };
			var result = Dis.Select(o => o.D).ToList();
			return result;
		}
	}
}
