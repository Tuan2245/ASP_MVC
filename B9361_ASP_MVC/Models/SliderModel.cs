using B9361_ASP_MVC.Repository.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B9361_ASP_MVC.Models
{
    public class SliderModel
    {
		public int Id { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập tên")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập mô tả")]
		public string Description { get; set; }
		public string Image {  get; set; }
		public int? Status { get; set; }
		[NotMapped]
		[FileExtension]
		public IFormFile? ImageUpload { get; set; }
	}
}
