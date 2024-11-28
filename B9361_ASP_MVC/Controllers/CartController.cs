using B9361_ASP_MVC.Models;
using B9361_ASP_MVC.Models.ViewModels;
using B9361_ASP_MVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace B9361_ASP_MVC.Controllers
{
    public class CartController : Controller
    {
		private readonly DataContext _dataContext;
		public CartController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}	

		public IActionResult Index()
		{
			List<CartItemModel> cartitems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			CartItemViewModel cartVM = new()
			{
				CartItems = cartitems,
                GrandTotal = cartitems.Sum(x => x.Quantity * x.Price)
			};
			return View(cartVM);
		}

		public IActionResult Checkout() 
		{
			return View("~/Views/Checkout/Index.cshtml"); 
		}
		public async Task<IActionResult> Add(int Id)
		{
			ProductModel product = await _dataContext.Products.FindAsync(Id);

			List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

			CartItemModel cartItems = cart.Where(c => c.ProductId == Id).FirstOrDefault();

			if (cartItems == null)
			{
				cart.Add(new CartItemModel(product));
			}
			else
			{
				cartItems.Quantity += 1;
			}

			HttpContext.Session.SetJson("Cart", cart);

			TempData["success"] = "Add item to cart successfully";

			return Redirect(Request.Headers["Referer"].ToString());
		}

		public async Task<IActionResult> Decrease(int Id)
		{
			List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");

			CartItemModel cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();

			if (cartItem.Quantity > 1) 
			{
				--cartItem.Quantity;
			}
            else
            {
                cart.RemoveAll(c => c.ProductId == Id);
            }

			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}

            TempData["success"] = "Decrease item to cart successfully";

            return RedirectToAction("Index");
		}

		public async Task<IActionResult> Increase(int Id)
		{
			List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");

			CartItemModel cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();

			if (cartItem.Quantity >= 1)
			{
				++cartItem.Quantity;
			}
			else
			{
				cart.RemoveAll(c => c.ProductId == Id);
			}

			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}

            TempData["success"] = "Increase item to cart successfully";

            return RedirectToAction("Index");
		}

		public async Task<IActionResult> Remove(int Id)
		{
			List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");

			CartItemModel cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();

			cart.RemoveAll(p  => p.ProductId == Id);

			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}

            TempData["success"] = "Remove item to cart successfully";

            return RedirectToAction("Index");
		}

		public async Task<IActionResult> Clear(int Id)
		{
			HttpContext.Session.Remove("Cart");

            TempData["success"] = "Clear cart successfully";

            return RedirectToAction("Index");
		}
	}
}
