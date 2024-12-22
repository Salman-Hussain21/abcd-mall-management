using System.ComponentModel.DataAnnotations;

namespace Ecom_Store.Models
{
    public class ShopsModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string ShopName { get; set; }
        [Required]
        public string ShopLogo { get; set; }
    }
}
