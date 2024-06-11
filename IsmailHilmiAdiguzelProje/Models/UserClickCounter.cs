using System.ComponentModel.DataAnnotations;
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
}
