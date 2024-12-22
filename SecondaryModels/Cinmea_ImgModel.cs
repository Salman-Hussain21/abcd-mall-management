using System.ComponentModel.DataAnnotations;

namespace Ecom_Store.SecondaryModels
{
    public class Cinmea_ImgModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string CinemaName { get; set; }
        [Required]
        public string CinemaDesc { get; set; }
        [Required]
        public IFormFile CinemaLogo { get; set; }
        [Required]
        public int CinemaSeats { get; set; }

    }
}
