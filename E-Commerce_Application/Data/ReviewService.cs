using E_Commerce_Application.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace E_Commerce_Application.Data
{
	public class ReviewService
	{
	
		private readonly IMongoCollection<Review> _reviewCollection;

		public ReviewService(
			IOptions<BakeryShopSettings> bakeryShopSettings)
		{
			var mongoClient = new MongoClient(bakeryShopSettings.Value.ConnectionString);

			var mongoDatabase = mongoClient.GetDatabase(
				bakeryShopSettings.Value.DatabaseName);

			_reviewCollection = mongoDatabase.GetCollection<Review>(
				bakeryShopSettings.Value.ReviewCollectionName);
		}

	
		public async Task<List<Review>> GetAsync() =>
		await _reviewCollection.Find(_ => true).ToListAsync();

		public async Task<Review?> GetAsync(string id) =>
			await _reviewCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();

		public async Task CreateAsync(Review newReview) =>
			await _reviewCollection.InsertOneAsync(newReview);

		public async Task UpdateAsync(string id, Review updatedReview) =>
			await _reviewCollection.ReplaceOneAsync(x => x.Id == id, updatedReview);

		public async Task RemoveAsync(string id) =>
			await _reviewCollection.DeleteOneAsync(x => x.Id == id);
	}
}
