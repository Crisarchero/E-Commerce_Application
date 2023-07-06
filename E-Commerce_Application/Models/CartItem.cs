using Humanizer;

namespace E_Commerce_Application.Models
{
	public class CartItem
	{
		public Product Product { get; set; }
		public string Name { get; set; }
		public int Size { get; set; }
		public int Quantity { get; set; }
		public CartItem(Product product, string name, int size, int quantity)
		{
			Product = product;
			Name = name;
			Size = size;
			Quantity = quantity;
		}
	}
}
