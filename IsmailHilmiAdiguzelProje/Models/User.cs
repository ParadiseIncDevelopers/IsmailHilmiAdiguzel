using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Models
{
    [Serializable]
    public class User 
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; } = Guid.NewGuid();
        [JsonPropertyName("name")]
        public string? name { get; set; }
        [JsonPropertyName("surname")]
        public string? surname { get; set; }
        [JsonPropertyName("email")]
        public string? email { get; set; }
        [JsonPropertyName("password")]
        public string? password { get; set; }
        [JsonPropertyName("user_type")]
        public int? user_type { get; set; }
        [JsonPropertyName("user_province")]
        public string? user_province { get; set; }
        [JsonPropertyName("user_city")]
        public string? user_city { get; set; }
        [JsonPropertyName("user_district")]
        public string? user_district { get; set; }
        [JsonPropertyName("user_neighbourhood")]
        public string? user_neighbourhood { get; set; }
        [JsonPropertyName("user_address")]
        public string? user_address { get; set; }
        [JsonPropertyName("gender")]
        public int? gender { get; set; }

    }
}
