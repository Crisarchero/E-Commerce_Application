using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using E_Commerce_Application.Models;
using Microsoft.Identity.Client;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Http;
using E_Commerce_Application.Data;

namespace E_Commerce_Application.Controllers
{
	
	public class CartController : Controller
	{
		private readonly ProductService _productService;

		public CartController(ProductService productService)
		{
			
			_productService = productService;
			
		}
		public void getCartItems()
		{
			List<Object> CartList = new List<Object>();

			if (HttpContext.Session.GetInt32("counter") == null)
			{
				HttpContext.Session.SetInt32("counter", 0);

			}
			
			foreach (var key in HttpContext.Session.Keys) {
				
				if (key.Contains("CartItem")){

					var CartItemJson = HttpContext.Session.GetString(key);
					var CartItem = JsonConvert.DeserializeObject(CartItemJson);
					if(CartItem == null) {
						continue;					
					}
					CartList.Add(CartItem);
				}
	
			}
			ViewBag.CartItems = CartList;
		}

		public void setCartItems(Product product, string size, int quantity)
		{
			var counterObject = HttpContext.Session.GetInt32("counter");
			int counter;
			if(counterObject == null) { 
				HttpContext.Session.SetInt32("counter", 0);
				counter = 0;
			}
			else
			{
				counter = (int)counterObject;
			}
			CartItem cartItem = new CartItem(product, size, quantity);
			var cartItemJson = JsonConvert.SerializeObject(cartItem);
			HttpContext.Session.SetString("CartItem" + counter, cartItemJson);
			HttpContext.Session.SetInt32("counter", counter + 1);
		}
		
		
		public async Task<IActionResult> Add()
		{
			var id = Request.Form["id"];			
			var size = Request.Form["size"];
			var quantityString = Request.Form["quantity"];
			if(quantityString == "")
			{
				quantityString = "0";
			}
			
			int quantity = Int32.Parse(quantityString);
			
			
			Product product = await _productService.GetAsync(id);
			if(quantity <= 0)
			{
				quantity = 1;
			}
			if (product == null || size == "")
			{
				return View("Error");
			}
			else
			{
				setCartItems(product, size, quantity);
				return View();
			}
		}

		public IActionResult Index()
		{
			getCartItems();
			return View();
		}
		

	}
}
