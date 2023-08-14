using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Commerce_Application.Models
{
    public class Review
    {

		public Review(string productId, string userName, double rating, string text)
		{
			ProductID = productId;
			UserName = userName;
			Rating = rating;
			CommentText = text;
		}

		[BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("UserName")]
		[JsonPropertyName("UserName")]
		public string UserName { get; set; } = null!;

        [ForeignKey("Product")]
        public string ProductID { get; set; }
        public Product Product { get; set; }

        public double Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CommentText { get; set; }

      
  
    }
}
