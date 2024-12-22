using System.ComponentModel.DataAnnotations;

namespace Ecom_Store.Models
{
    public class CinemaModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string CinemaName { get; set; }
        [Required]
        public string CinemaDesc { get; set; }
        [Required]
        public string CinemaLogo { get; set; }


        [Required]
        public int CinemaSeats { get; set; }
        // Navigation property to Movies
        public virtual ICollection<MoviesModel> Movies { get; set; }

    }
}
