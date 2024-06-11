using IsmailHilmiAdiguzelProje.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Models
{
    public class CallbackLinkData
    {
        [JsonPropertyName("affiliate_id")]
        public string? AffiliateId { get; set; }

        [JsonPropertyName("offer_id")]
        public int? OfferId { get; set; }

        [JsonPropertyName("click_url")]
        public string? ClickUrl { get; set; }
    }

    public class CallbackLinkResponse : IJsonDataObjectGetter<CallbackLinkData>
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("httpStatus")]
        public int HttpStatus { get; set; }

        [JsonPropertyName("data")]
        public CallbackLinkData? Data { get; set; }

        [JsonPropertyName("errors")]
        public List<object>? Errors { get; set; }

        [JsonPropertyName("errorMessage")]
        public object? ErrorMessage { get; set; }
    }

    public class CallbackLink : IJsonResponseGetter<CallbackLinkResponse>
    {
        [JsonPropertyName("request")]
        public Dictionary<string, object>? Request { get; set; }

        [JsonPropertyName("response")]
        public CallbackLinkResponse? Response { get; set; }
    }

}
