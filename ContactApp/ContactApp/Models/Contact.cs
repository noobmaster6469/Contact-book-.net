using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{7,15}$", ErrorMessage = "Phone must be numbers only, 7-15 digits.")]
        public string Phone { get; set; }
    }
}
