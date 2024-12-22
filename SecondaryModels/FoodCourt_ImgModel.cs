using System.ComponentModel.DataAnnotations;

namespace Ecom_Store.SecondaryModels
{
    public class FoodCourt_ImgModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string FoodCourtName { get; set; }
        [Required]
        public IFormFile FoodCourtLogo { get; set; }
    }
}
