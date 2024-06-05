using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Models
{
    public class UserClickCounter
    {
        public int Id { get; set; }

        public string? ClickWebsite { get; set; }

        public DateTime ClickDate { get; set; }

        public string? ClickName { get; set; }
    }

    [Serializable]
    public class User 
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("name")]
        public string? name { get; set; }
        [JsonPropertyName("surname")]
        public string? surname { get; set; }
        [JsonPropertyName("email")]
        public string? email { get; set; }
        [JsonPropertyName("password")]
        public string? password { get; set; }
        [JsonPropertyName("user_type")]
        public string? user_type { get; set; }
    }
}
