using Humanizer;

namespace E_Commerce_Application.Models
{
	public class CartItem
	{
		public Product Product { get; set; }
		public string Size { get; set; }
		public int Quantity { get; set; }
		public CartItem(Product product, string size, int quantity)
		{
			Product = product;
			Size = size;
			Quantity = quantity;
		}
	}
}
