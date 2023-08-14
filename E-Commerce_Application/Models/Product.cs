using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.Identity.Client;
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

        [BsonElement("Name")]
		[JsonPropertyName("Name")]
		public string Name { get; set; } = null!;


        public string Description { get; set; } = null!;

        public string ImgName { get; set; } = null!;
        
   
        public decimal SmallPrice { get; set; }
        public decimal MediumPrice { get; set; }
        public decimal LargePrice { get; set; }
		public decimal ExtraLargePrice { get; set; }


		public decimal DiscountPercentage { get; set; }



        public Product(string name,string description, string categoryId, decimal sPrice, decimal mPrice, decimal lPrice, decimal exLPrice, decimal discountPercentage, string Img)
        {
            Name = name;
            Description = description;
            CategoryID = categoryId;
            SmallPrice = sPrice;
            MediumPrice = mPrice;
            LargePrice = lPrice;
            ExtraLargePrice = exLPrice;
            DiscountPercentage = discountPercentage;
            ImgName = Img;

        }
  

    







	}
}
