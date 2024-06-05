using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Models
{
    [Serializable]
    public class UserClickCounter
    {
        [Key]
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("click_website")]
        public string? click_website { get; set; }

        [JsonPropertyName("click_date")]
        public DateTime click_date { get; set; }

        [JsonPropertyName("click_name")]
        public string? click_name { get; set; }
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
