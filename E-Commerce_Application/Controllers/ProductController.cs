using E_Commerce_Application.Data;
using E_Commerce_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Application.Controllers
{
	[ApiController]
	[Route("Menu/Products")]
	public class ProductController : Controller
    {
		private readonly ProductService _productService;
		private readonly ReviewService _reviewService;
		private readonly CategoryService _categoryService;


		public ProductController(ProductService productService,ReviewService reviewService, CategoryService cateogryService)
		{
			//Including all the services so it's easier to work with multiple at once.
			_productService = productService;
			_reviewService = reviewService;
			_categoryService = cateogryService;
		}


		//A method to get all the products.

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var productList = await _productService.GetAsync();
			var categoryList = await _categoryService.GetAsync();
			ViewBag.Products = productList;
			ViewBag.Category = categoryList;
			return View("Index");
		}

		//A method to get products based on their categories.
		[HttpGet("{id:length(24)}")]
		public async Task<ActionResult> GetByCat(string id)
		{
			
			var productList = await _productService.GetByCatAsync(id);
			var categoryList = await _categoryService.GetAsync();
			if(productList.Count == 0)
			{
				ViewBag.Prodcuts = null;
			}
			else
			{
				ViewBag.Products = productList;
			}
			
			ViewBag.Categories = categoryList;

			return View("Index");
		}


		//A method to return a single product with its reviews.

		

		//Adding a new product.
		public async Task<IActionResult> Post(Product newProduct)
		{
			await _productService.CreateAsync(newProduct);

			return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
		}

		//Updating a product.
		public async Task<IActionResult> Update(string id, Product updatedProduct)
		{
			var product = await _productService.GetAsync(id);

			if (product is null)
			{
				return NotFound();
			}

			updatedProduct.Id = product.Id;

			await _productService.UpdateAsync(id, updatedProduct);

			return NoContent();
		}

		//Deleting a product

		public async Task<IActionResult> Delete(string id)
		{
			var product = await _productService.GetAsync(id);

			if (product is null)
			{
				return NotFound();
			}

			await _productService.RemoveAsync(id);

			return NoContent();
		}
		
	}
}
