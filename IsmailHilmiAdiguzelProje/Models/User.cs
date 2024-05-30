using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace IsmailHilmiAdiguzelProje.Models
{

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
