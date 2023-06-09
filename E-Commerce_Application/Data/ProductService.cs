using MongoDB.Driver;
using E_Commerce_Application.Models;
using Microsoft.Extensions.Options;

namespace E_Commerce_Application.Data
{
	public class ProductService
	{

		private readonly IMongoCollection<Product> _productCollection;
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IMongoCollection<Review> _reviewCollection;

		public ProductService(
			IOptions<BakeryShopSettings> bakeryShopSettings)
		{
			var mongoClient = new MongoClient(bakeryShopSettings.Value.ConnectionString);

			var mongoDatabase = mongoClient.GetDatabase(
				bakeryShopSettings.Value.DatabaseName);

			_productCollection = mongoDatabase.GetCollection<Product>(
				bakeryShopSettings.Value.ProductCollectionName);

		}

		public async Task<List<Product>> GetAsync() =>
			await _productCollection.Find(_ => true).ToListAsync();

		public async Task<Product?> GetAsync(string id) =>
			await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
		public async Task<List<Product>> GetByCatAsync(string id) =>
			await _productCollection.Find(x => x.CategoryID == id).ToListAsync();

		public async Task CreateAsync(Product newProduct) =>
			await _productCollection.InsertOneAsync(newProduct);

		public async Task UpdateAsync(string id, Product updatedProduct) =>
			await _productCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

		public async Task RemoveAsync(string id) =>
			await _productCollection.DeleteOneAsync(x => x.Id == id);

	}	
}
