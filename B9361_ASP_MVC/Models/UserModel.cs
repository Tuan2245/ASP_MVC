using System.ComponentModel.DataAnnotations;

namespace B9361_ASP_MVC.Models
{
	public class UserModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Chưa nhập user name")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Chưa nhập email"),EmailAddress]
		public string Email { get; set; }
		[Required(ErrorMessage = "Chưa nhập password"),DataType(DataType.Password)]
		public string Password { get; set; }

	}
}
