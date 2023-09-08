using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos.ProvinceDto
{
	public class CreateProvince
	{
		private string _Name;
		[Required(AllowEmptyStrings = false, ErrorMessage = "Tên tỉnh thành không được bỏ trống")]
		[MaxLength(255, ErrorMessage = "Tên tỉnh thành không được vượt quá 255 ký tự")]
		public string Name
		{
			get => _Name;
			set => _Name = value?.Trim();
		}
	}
}
