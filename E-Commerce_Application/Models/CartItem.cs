using Humanizer;

namespace E_Commerce_Application.Models
{
	public class CartItem
	{
		public Product Product { get; set; }
		public string Name { get; set; }
		public string SizeName { get; set; }
		public int Size { get; set; }
	
		public CartItem(Product product, string name, int size, string sizeName)
		{
			Product = product;
			Name = name;
			Size = size;
			SizeName = sizeName;
		}
	}
}
