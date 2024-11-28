﻿using B9361_ASP_MVC.Models;
using B9361_ASP_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B9361_ASP_MVC.Controllers
{
    public class CategoryController : Controller
    {
		private readonly DataContext _dataContext;
        public CategoryController(DataContext context)
        {
            _dataContext = context;
        }
		public async Task<IActionResult> Index(string Slug = "")
        {
            CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();

            if (category == null) return RedirectToAction("Index");

            var productsByCategory = _dataContext.Products.Where(p => p.CategoryId == category.Id);

			ViewBag.Slug = Slug;

			return View(await productsByCategory.OrderByDescending(p => p.Id).ToListAsync());
        }
    }
}
