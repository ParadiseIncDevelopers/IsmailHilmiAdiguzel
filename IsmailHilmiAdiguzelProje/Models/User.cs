using System.ComponentModel.DataAnnotations;

namespace IsmailHilmiAdiguzelProje.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Surname { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"^\+[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must have at least 8 characters, one uppercase letter, one lowercase letter, one number, and one special character")]
        public string? Password { get; set; }
    }

    public class UserClickCounter
    {
        [Key]
        public int UserClickCounterId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? ClickWebsite { get; set; }

        [Required]
        public DateTime ClickDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string? ClickName { get; set; }
    }

}
