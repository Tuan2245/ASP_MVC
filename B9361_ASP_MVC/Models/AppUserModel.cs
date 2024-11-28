using Microsoft.AspNetCore.Identity;

namespace B9361_ASP_MVC.Models
{
	public class AppUserModel : IdentityUser
	{
        public string RoleId { get; set; }
    }
}
