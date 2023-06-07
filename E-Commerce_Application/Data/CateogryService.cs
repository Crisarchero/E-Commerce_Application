using MongoDB.Driver;
using E_Commerce_Application.Models;
using Microsoft.Extensions.Options;

namespace E_Commerce_Application.Data
{
	public class CategoryService
	{
		

		private readonly IMongoCollection<Category> _categoryCollection;


		public CategoryService(
			IOptions<BakeryShopSettings> bakeryShopSettings)
		{
			var mongoClient = new MongoClient(bakeryShopSettings.Value.ConnectionString);

			var mongoDatabase = mongoClient.GetDatabase(
				bakeryShopSettings.Value.DatabaseName);
			
		
			_categoryCollection = mongoDatabase.GetCollection<Category>(
				bakeryShopSettings.Value.CategoryCollectionName);

		}


		//Category
		public async Task<List<Category>>GetAsync() =>
		await _categoryCollection.Find(_ => true).ToListAsync();

		public async Task<Category?> GetAsync(string id) =>
			await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

		public async Task CreateAsync(Category newCategory) =>
			await _categoryCollection.InsertOneAsync(newCategory);

		public async Task UpdateAsync(string id, Category updatedCategory) =>
			await _categoryCollection.ReplaceOneAsync(x => x.Id == id, updatedCategory);

		public async Task RemoveAsync(string id) =>
			await _categoryCollection.DeleteOneAsync(x => x.Id == id);



	}
}
