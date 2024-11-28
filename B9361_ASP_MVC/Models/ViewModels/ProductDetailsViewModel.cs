﻿using System.ComponentModel.DataAnnotations;

namespace B9361_ASP_MVC.Models.ViewModels
{
	public class ProductDetailsViewModel
	{
		public ProductModel ProductDetails { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập bình luận")]
		public string Comment { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập tên")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập email")]
		public string Email { get; set; }

	}
}
