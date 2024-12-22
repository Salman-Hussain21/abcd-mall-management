using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecom_Store.Models
{
    public class MoviesModel
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Please fill")]
        public string Movies_Name { get; set; }
        [Required(ErrorMessage = "Please fill")]
        public string Movies_Desc { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; } // Using TimeSpan for time only
        [Required]
        public TimeSpan EndTime { get; set; } // Using TimeSpan for time only
        [Required]
        public DateTime ScreeningDate { get; set; }

        [Required(ErrorMessage = "Please fill")]

        public int Cinema_ID { get; set; }
        [ForeignKey("Cinema_ID")]

        public virtual CinemaModel CinemaName { get; set; }
        [Required]
        public string MoviePicture { get; set; }
    }
}
