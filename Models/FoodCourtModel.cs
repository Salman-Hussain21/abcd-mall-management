using System.ComponentModel.DataAnnotations;

namespace Ecom_Store.Models
{
    public class FoodCourtModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string FoodCourtName { get; set; }
        [Required]
        public string FoodCourtLogo { get; set; }
    }
}
