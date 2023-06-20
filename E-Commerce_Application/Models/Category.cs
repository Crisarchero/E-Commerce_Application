using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Commerce_Application.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
		[JsonPropertyName("Name")]
		public string Name { get; set; } = null!;

        public Size[] Sizes { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = null!;

    }

}
