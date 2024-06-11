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
        public int? user_type { get; set; }
        [JsonPropertyName("province")]
        public string? province { get; set; }
        [JsonPropertyName("district")]
        public string? district { get; set; }
        [JsonPropertyName("neighbourhood")]
        public string? neighbourhood { get; set; }
        [JsonPropertyName("address")]
        public string? address { get; set; }
        [JsonPropertyName("gender")]
        public int? gender { get; set; }

    }
}
