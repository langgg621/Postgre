using WebApplication1.AppDb;
using WebApplication1.Dtos.DistrictDto;
using WebApplication1.Enities;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services.Implement
{
	public class DistrictService : IDistrictService
	{
		private readonly MyDb _myDb;

		public DistrictService(MyDb myDb)
		{
			_myDb = myDb;
		}
		public List<District> GetAllDistrict()
		{
			var Districts = _myDb.Districts.ToList();
			return Districts;
		}
		public District GetDistrictById(int id)
		{
			var district = _myDb.Districts.FirstOrDefault(x => x.Id == id);

			return district ?? throw new Exception("Khong tim thay Tinh Thanh");
		}
		public bool ProvinceExists(int provinceId)
		{
			return _myDb.Provinces.Any(p => p.Id == provinceId);
		}
		public void CreateDistrict(CreateDistrictDto District)
		{
			if (!_myDb.Provinces.Any(p => p.Id == District.ProvinceId))
			{
				// Xử lý trường hợp tỉnh/thành không tồn tại
				throw new Exception("Tỉnh/thành không tồn tại trong CSDL.");
			}
			if (_myDb.Districts.Any(o => o.Name == District.Name))
			{
				throw new Exception("Trung ten");
			}
			var newDistrict = new District
			{
				Name = District.Name,
				ProvinceId = District.ProvinceId
			};

			_myDb.Districts.Add(newDistrict);
			_myDb.SaveChanges();
		}
		public void UpdateDistrict(UpdateDistrictDto input)
		{
			var District = _myDb.Districts.FirstOrDefault(o => o.Id == input.Id);
			if (District == null)
			{
				throw new Exception("Khong tim thay Tinh thanh");
			}
			if (_myDb.Districts.Any(b => b.Name == input.Name))
			{
				throw new Exception("Trung ten");
			}
			District.Name = input.Name;
			_myDb.SaveChanges();
		}
		public void DeleteDistrict(int id)
		{
			var District = _myDb.Districts.FirstOrDefault(o => o.Id == id);
			if (District == null)
			{
				throw new Exception("Khong tim thay Tinh Thanh");
			}
			_myDb.Districts.Remove(District);
			_myDb.SaveChanges();

		}
		public List<Ward> GetWardByDistrict(int districtId)
		{
			var districtIds = _myDb.Wards
				.Where(p=> p.DistrictId ==districtId).Select(p => p.Id).ToList();
			var wards = from W in _myDb.Wards
						join D in _myDb.Districts
						on W.DistrictId equals D.Id
						where D.Id == districtId
						select new
						{
							W
						};
			var result = wards.Select(o => o.W).ToList();
			return result;
		}
		
	}
}
