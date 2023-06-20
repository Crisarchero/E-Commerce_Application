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

        public string CategoryName { get; set; } = null!;
        
     

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


  

        /*
         * I wanted these calculations to be done, but not stored in the database.  Tis excessive.
         * 
         * public decimal SmallDiscountAmount => SmallPrice * DiscountPercentage;
        public decimal MediumDiscountAmount=> MediumPrice * DiscountPercentage;
        public decimal LargeDiscountAmount => LargePrice * DiscountPercentage;
       
        
        public decimal SmallDiscountedPrice => SmallPrice - SmallDiscountAmount;
		public decimal MediumDiscountedPrice => MediumPrice - MediumDiscountAmount;
		public decimal LargeDiscountedPrice => LargePrice - LargeDiscountAmount;


		public bool SmallIsDiscounted => SmallDiscountedPrice != SmallPrice;
		public bool MediumIsDiscounted => MediumDiscountedPrice != MediumPrice;
		public bool LargeIsDiscounted => LargeDiscountedPrice != LargePrice;
        
         
         */








	}
}
