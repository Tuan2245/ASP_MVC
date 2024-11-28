using B9361_ASP_MVC.Models;
using B9361_ASP_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace B9361_ASP_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , DataContext context)
        {
            _logger = logger;
            _dataContext = context;
        }
		public async Task<IActionResult> Index(int pg = 1)
		{
			var products = _dataContext.Products.Include("Category").Include("Brand").ToList();
            var sliders = _dataContext.Sliders.Where(x => x.Status == 1).ToList();

			const int pageSize = 9;

			if (pg < 1)
			{
				pg = 1;
			}
			int recsCount = products.Count();
			var pager = new Paginate(recsCount, pg, pageSize);

			int recSkip = (pg - 1) * pageSize;

			var data = products.Skip(recSkip).Take(pager.PageSize).ToList();

			ViewBag.Pager = pager;
            ViewBag.Sliders = sliders;

			return View(data);
		}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statuscode)
        {
            if (statuscode == 404)
            {
                return View("NotFound");
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
