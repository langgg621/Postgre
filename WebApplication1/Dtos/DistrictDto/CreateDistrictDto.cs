using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos.DistrictDto
{
	public class CreateDistrictDto
	{
		private string _Name;
		[Required(AllowEmptyStrings = false, ErrorMessage = "Tên quận huyện không được bỏ trống")]
		[MaxLength(255, ErrorMessage = "Tên quận huyện không được vượt quá 255 ký tự")]
		public string Name
		{
			get => _Name;
			set => _Name = value?.Trim();
		}

		[Required]
		public int ProvinceId { get; set; }
	}
}
