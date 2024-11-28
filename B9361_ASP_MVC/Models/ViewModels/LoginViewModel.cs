using System.ComponentModel.DataAnnotations;

namespace B9361_ASP_MVC.Models.ViewModels
{
    public class LoginViewModel
    {
		public int Id { get; set; }
		[Required(ErrorMessage = "Chưa nhập user name")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Chưa nhập password"), DataType(DataType.Password)]
		public string Password { get; set; }

		public string ReturnUrl { get; set; }
	}
}
