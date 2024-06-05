using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
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

    public class User 
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? user_type { get; set; }
    }
}
