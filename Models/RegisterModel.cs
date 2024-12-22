using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecom_Store.Models
{
    public class RegisterModel
    {

        [Key]
        public int id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        
        public int UserPassword { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Role { get; set; }
    }
}
