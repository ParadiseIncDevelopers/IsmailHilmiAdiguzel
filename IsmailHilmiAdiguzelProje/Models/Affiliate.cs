using IsmailHilmiAdiguzelProje.Interfaces;
using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Models
{

    [Serializable]
    public class BalanceDataResponse : IJsonDataObjectGetter<string>
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("httpStatus")]
        public int HttpStatus { get; set; }

        [JsonPropertyName("data")]
        public string? Data { get; set; }

        [JsonPropertyName("errors")]
        public List<object>? Errors { get; set; }

        [JsonPropertyName("errorMessage")]
        public object? ErrorMessage { get; set; }
    }

    [Serializable]
    public class BalanceDataObject : IJsonResponseGetter<BalanceDataResponse>
    {
        [JsonPropertyName("request")]
        public Dictionary<string, object>? Request { get; set; }

        [JsonPropertyName("response")]
        public BalanceDataResponse? Response { get; set; }
    }
}
