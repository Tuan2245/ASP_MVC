using B9361_ASP_MVC.Areas.Admin.Repository;
using B9361_ASP_MVC.Models;
using B9361_ASP_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace B9361_ASP_MVC.Controllers
{
	public class CheckoutController : Controller
	{
		private readonly DataContext _dataContext;
        private readonly IEmailSender _emailSender;

        public CheckoutController(DataContext context, IEmailSender emailSender)
		{
			_dataContext = context;
			_emailSender = emailSender;
		}
		
		public async Task<IActionResult> Checkout() 
		{
			var userEmail = User.FindFirstValue(ClaimTypes.Email);
			if(userEmail == null)
			{
				return RedirectToAction("Login","Account");
			}
			else
			{
				var ordercode = Guid.NewGuid().ToString();
				var orderItem = new OrderModel();
				orderItem.OrderCode = ordercode;
				orderItem.UserName = userEmail;
				orderItem.Status = 1;
				orderItem.CreatedDate = DateTime.Now;
				_dataContext.Add(orderItem);
				_dataContext.SaveChanges();
				List<CartItemModel> cartitems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
				foreach (var item in cartitems)
				{
					var orderdetails = new OrderDetails();
					orderdetails.UserName = userEmail;
					orderdetails.OrderCode = ordercode;
					orderdetails.ProductId = item.ProductId;
					orderdetails.Price = item.Price;
					orderdetails.Quantity = item.Quantity;
					_dataContext.Add(orderdetails);
					_dataContext.SaveChanges();
				}
				HttpContext.Session.Remove("Cart");
				var receiver = "khongcandau9963@gmail.com";
				var subject = "Đặt hàng thành công";
				var message = "Đặt hàng thành công";
				await _emailSender.SendEmailAsync(receiver, subject, message);
				TempData["success"] = "Đặt hàng thành công";
				return RedirectToAction("Index", "Cart");
			}
			return View();
		}
	}
}
