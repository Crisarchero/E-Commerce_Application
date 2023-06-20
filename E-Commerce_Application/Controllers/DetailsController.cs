using E_Commerce_Application.Data;
using E_Commerce_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Application.Controllers
{
	[ApiController]
	[Route("Menu/ProductDetail")]
	public class DetailsController : Controller
	{
		private readonly ProductService _productService;
		private readonly ReviewService _reviewService;
		private readonly CategoryService _categoryService;


		public DetailsController(ProductService productService, ReviewService reviewService, CategoryService cateogryService)
		{
			_productService = productService;
			_reviewService = reviewService;
			_categoryService = cateogryService;
		}

		[HttpGet("{id:length(24)}")]
		public async Task<ActionResult<Product>> Get(string id)
		{
			var product = await _productService.GetAsync(id);
			var reviews = await _reviewService.GetAsync(id);
			var categories = await _categoryService.GetAsync();
			
			if (product is null)
			{
			
				return NotFound();
			}
			ViewBag.Product = product;
			ViewBag.Reviews = reviews;
			ViewBag.Categories = categories;

			return View("Index");
		}
	}
}
