using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Models
{
    [Serializable]
    public class Offer
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("preview_url")]
        public string? Url { get; set; }
    }

    [Serializable]
    public class MainData
    {
        [JsonPropertyName("data")]
        public Dictionary<string, Dictionary<string, Offer>>? Data { get; set; }
    }

    [Serializable]
    public class MainDataResponse
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("httpStatus")]
        public int HttpStatus { get; set; }

        [JsonPropertyName("data")]
        public MainData? Data { get; set; }

        [JsonPropertyName("errors")]
        public List<object>? Errors { get; set; }

        [JsonPropertyName("errorMessage")]
        public object? ErrorMessage { get; set; }
    }

    [Serializable]
    public class MainDataObject
    {
        [JsonPropertyName("request")]
        public Dictionary<string, object>? Request { get; set; }

        [JsonPropertyName("response")]
        public MainDataResponse? Response { get; set; }
    }
}
