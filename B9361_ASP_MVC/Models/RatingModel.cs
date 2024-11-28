using System.ComponentModel.DataAnnotations;

namespace B9361_ASP_MVC.Models
{
	public class RatingModel
	{
		[Key]
		public int Id { get; set; }
		public int ProductId { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập đánh giá")]
		public string Comment { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập tên")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập email")]
		public string Email { get; set; }

		public string Star { get; set; }

		public ProductModel Product { get; set; }
	}
}
