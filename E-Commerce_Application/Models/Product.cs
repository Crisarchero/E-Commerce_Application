using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Application.Models
{
    public class Product
    {
        
        public int Id { get; set; }
       
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "A category must be selected.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The product must have a name.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please give the product a description.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The product must have a price.")]
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount => Price * DiscountPercentage;
        public decimal DiscountedPrice => Price - DiscountAmount;

        public bool isDiscounted => DiscountedPrice != Price;







    }
}
