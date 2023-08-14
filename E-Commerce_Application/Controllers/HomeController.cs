using E_Commerce_Application.Models;
using E_Commerce_Application.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace E_Commerce_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

		private readonly CategoryService _categoryService;

		public HomeController(CategoryService categoryService, ILogger<HomeController> logger)
        {

			_categoryService = categoryService;
		    _logger = logger;
        }
	
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Cart()
		{
			return View();
		}
		public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
		public async Task<IActionResult> Login()
		{
			var categoryList = await _categoryService.GetAsync();
			ViewBag.Categories = categoryList;
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}