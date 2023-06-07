using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Commerce_Application.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [ForeignKey("Category")]
        public string CategoryID { get; set; } = null!;     
        
     
        public Category Category { get; set; }


        [BsonElement("Name")]
		[JsonPropertyName("Name")]
		public string? Name { get; set; } = null!;


        public string? Description { get; set; } = null!;
        
   
        public decimal Price { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal DiscountAmount => Price * DiscountPercentage;
        public decimal DiscountedPrice => Price - DiscountAmount;

        public bool isDiscounted => DiscountedPrice != Price;







    }
}
