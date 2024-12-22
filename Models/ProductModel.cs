using System.ComponentModel.DataAnnotations;

namespace Ecom_Store.Models
{
    public class ProductModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int ProductPrice { get; set;}
        [Required]
        public int ProductQuantity { get; set;}
        [Required]
        public string ProductImage { get; set;}
       
        


    }
}
