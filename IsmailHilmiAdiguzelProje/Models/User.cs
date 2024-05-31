using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace IsmailHilmiAdiguzelProje.Models
{
    public class UserClickCounter
    {
        public int Id { get; set; }

        public string? ClickWebsite { get; set; }

        public DateTime ClickDate { get; set; }

        public string? ClickName { get; set; }
    }
}
