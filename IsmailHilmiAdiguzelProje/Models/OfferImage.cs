using IsmailHilmiAdiguzelProje.Interfaces;
using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Models
{
    [Serializable]
    public class OfferImage
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("offer_id")]
        public string? Offer_id { get; set; }

        [JsonPropertyName("display")]
        public string? Display { get; set; }

        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        [JsonPropertyName("size")]
        public string? Size { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("width")]
        public string? Width { get; set; }

        [JsonPropertyName("height")]
        public string? Height { get; set; }

        [JsonPropertyName("code")]
        public object Code { get; set; }

        [JsonPropertyName("flash_vars")]
        public object Flash_vars { get; set; }

        [JsonPropertyName("interface")]
        public string? Interface { get; set; }

        [JsonPropertyName("account_id")]
        public object Account_id { get; set; }

        [JsonPropertyName("is_private")]
        public string? Is_private { get; set; }

        [JsonPropertyName("created")]
        public string? Created { get; set; }

        [JsonPropertyName("modified")]
        public string? Modified { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("thumbnail")]
        public string? Thumbnail { get; set; }
    }

    [Serializable]
    public class ImageData
    {
        [JsonPropertyName("data")]
        public Dictionary<string, Dictionary<string, OfferImage>>? OfferImage { get; set; }
    }

    [Serializable]
    public class ImageDataResponse : IJsonDataObjectGetter<ImageData>
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("httpStatus")]
        public int HttpStatus { get; set; }

        [JsonPropertyName("data")]
        public ImageData? Data { get; set; }

        [JsonPropertyName("errors")]
        public List<object>? Errors { get; set; }

        [JsonPropertyName("errorMessage")]
        public object? ErrorMessage { get; set; }
    }

    [Serializable]
    public class ImageDataObject : IJsonResponseGetter<ImageDataResponse>
    {
        [JsonPropertyName("request")]
        public Dictionary<string, object>? Request { get; set; }

        [JsonPropertyName("response")]
        public ImageDataResponse? Response { get; set; }
    }
}
