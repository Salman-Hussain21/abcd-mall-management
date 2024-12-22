using System.ComponentModel.DataAnnotations;

namespace Ecom_Store.Models
{
    public class Contactmodel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

    }
}
