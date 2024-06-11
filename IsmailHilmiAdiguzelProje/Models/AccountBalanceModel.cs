using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace IsmailHilmiAdiguzelProje.Models
{
    public class AccountBalanceResponse
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("httpStatus")]
        public int HttpStatus { get; set; }

        [JsonPropertyName("data")]
        public string? Data { get; set; }

        [JsonPropertyName("errors")]
        public List<string>? Errors { get; set; }

        [JsonPropertyName("errorMessage")]
        public string? ErrorMessage { get; set; }
    }

    public class AccountBalance
    {
        [JsonPropertyName("request")]
        public Dictionary<string, object>? Request { get; set; }

        [JsonPropertyName("response")]
        public AccountBalanceResponse? Response { get; set; }
    }

}
