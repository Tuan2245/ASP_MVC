using B9361_ASP_MVC.Repository.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B9361_ASP_MVC.Models
{
    public class ProductModel
    {
		[Key]
        public int Id { get; set; }

		[Required (ErrorMessage = "Yêu cầu nhập tên sản phẩm")]
		public string Name { get; set; }
		public string Slug { get; set; }
		[Required (ErrorMessage = "Yêu cầu nhập mô tả")]
		public string Description { get; set; }
		[Required (ErrorMessage = "Yêu cầu nhập giá")]
		public float Price { get; set; }
		public string Image { get; set; }
		[Required, Range(1, int.MaxValue, ErrorMessage = "Chọn 1 thương hiệu")]
		public int BrandId { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Chọn 1 danh mục")]
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public BrandModel Brand { get; set; }
		public RatingModel Rating { get; set; }
		[NotMapped]
		[FileExtension]
		public IFormFile? ImageUpload { get; set; }

    }
}
