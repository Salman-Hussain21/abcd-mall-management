using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Ecom_Store.Models
{
    public class FeedbackForm
    {
        [Key]
        public int Id { get; set; }
        [AllowNull]
        public String UserName { get; set; } 
        [AllowNull]
        public String UserEmail { get; set; } 
        [AllowNull]
        public String UserMessage { get; set; }

    }
}
