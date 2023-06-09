using E_Commerce_Application.Data;
using E_Commerce_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Application.Controllers
{
	[ApiController]
	[Route("Menu/[controller]")]
	public class ProductController : Controller
    {
		private readonly ProductService _productService;
		private readonly ReviewService _reviewService;


		public ProductController(ProductService productService,ReviewService reviewService)
		{
			_productService = productService;
			_reviewService = reviewService;
		}


		//A method to get all the products.

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var productList = await _productService.GetAsync();
			ViewBag.Products = productList;
			return View("Index");
		}

		//A method to get products based on their categories.
		[HttpGet("{id:length(24)}")]
		public async Task<ActionResult> GetByCat(string id)
		{
			var productList = await _productService.GetByCatAsync(id);
			ViewBag.Products = productList;
			return View("Index");
		}


		//A method to return a single product with its reviews.

		[HttpGet("Details/{id:length(24)}")]
		public async Task<ActionResult<Product>> Get(string id)
		{
			var product = await _productService.GetAsync(id);
			var reviews = await _reviewService.GetAsync(id); 
			if (product is null)
			{
				return NotFound();
			}
			ViewBag.Product = product;
			ViewBag.Reviews = reviews;
			return View();
		}

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
