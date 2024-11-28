using B9361_ASP_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace B9361_ASP_MVC.Repository
{
	public class SeedData
	{
		public static void SeedingData(DataContext _context) 
		{
			_context.Database.Migrate();
			if(!_context.Products.Any()) 
			{
				AppUserModel user = new AppUserModel { Id = "1", RoleId = "1", UserName = "admin", NormalizedUserName = "ADMIN", Email = "admin@gmail.com", NormalizedEmail = "ADMIN@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEBHlYbbg6E8Xy/GykicaJfskOQ5i/d66kIa0WCaK4w/4voVKrIFmxIziFRBmffOfzA==", SecurityStamp = "QRAGOZ7KZFMCV2G3YEBKMRNHTTK32PVQ", ConcurrencyStamp = "89061eb5-33a7-4509-9ab4-c0fa02a053c4", PhoneNumber = "123456789", EmailConfirmed = false, PhoneNumberConfirmed = false, AccessFailedCount = 0, TwoFactorEnabled = false, LockoutEnabled = true };
				IdentityRole role = new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "1"};

				BrandModel pcmini = new BrandModel { Name = "Pc mini", Slug = "pc-mini", Description = "pcmini", Status = 1 };
				BrandModel pc = new BrandModel { Name = "Pc", Slug = "pc", Description = "pc", Status = 1 };

				CategoryModel gaming = new CategoryModel { Name = "Gaming", Slug = "Gaming", Description = "Gaming", Status = 1 };
				CategoryModel workstation = new CategoryModel { Name = "Workstation", Slug = "workstation", Description = "workstation", Status = 1 };

				_context.Products.AddRange(
					new ProductModel { Name = "PC FASTER GAMING 10400F - RTX 3050 6GB", Slug = "PC FASTER GAMING 10400F - RTX 3050 6GB", Description = "PC FASTER GAMING 10400F - RTX 3050 6GB", Image = "dsc06272_1671f22220f4482684fb1c3.png", Category = gaming, Brand = pc, Price = 1000 },
					new ProductModel { Name = "PC WORKSTATION - GAMING PROFESSIONAL RTX 4070 Ti SUPER 16GB OC - I7 14700K ", Slug = "PC WORKSTATION - GAMING PROFESSIONAL RTX 4070 Ti SUPER 16GB OC - I7 14700K ", Description = "PC WORKSTATION - GAMING PROFESSIONAL RTX 4070 Ti SUPER 16GB OC - I7 14700K ", Image = "dsc07615_87316a40ad644990bec276d.png", Category = workstation, Brand = pc, Price = 2000 }
				);
				_context.SaveChanges();
			}
		}
	}
}
