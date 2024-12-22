using System.ComponentModel.DataAnnotations;

namespace Ecom_Store.SecondaryModels
{
    public class Shop_ImgModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string ShopName { get; set; }
        [Required]
        public IFormFile ShopLogo { get; set; }
    }
}
