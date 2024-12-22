using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_Store.Models
{
    public class BookedSeats
    {
        [Key]
        public int BookedSeatId { get; set; }
        [Required]

        public int MovieID { get; set; }

        [ForeignKey("MovieID")]
        
        public virtual MoviesModel Movies { get; set; }
        [Required]

        public int CinemaId { get; set; }

        [ForeignKey("CinemaId")]
        
        public virtual CinemaModel Cinema { get; set; }
        [Required]

        public int SeatId { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string UserEmail { get; set; }
    }
}
