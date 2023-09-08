using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos.WardDto
{
	public class CreateWardDto
	{
		private string _Name;
		[Required(AllowEmptyStrings = false, ErrorMessage = "Tên xã phường không được bỏ trống")]
		[MaxLength(255, ErrorMessage = "Tên xã phường không được vượt quá 255 ký tự")]
		public string Name
		{
			get => _Name;
			set => _Name = value?.Trim();
		}
		[Required]
		public int DistrictId { get; set; }
	}
}
