using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Models
{
    [Serializable]
    public class UserAddress
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("province")]
        public string? province { get; set; }
        [JsonPropertyName("city")]
        public string? city { get; set; }
        [JsonPropertyName("district")]
        public string? district { get; set; }
        [JsonPropertyName("neighbourhood")]
        public string? neighbourhood { get; set; }
    }
}
