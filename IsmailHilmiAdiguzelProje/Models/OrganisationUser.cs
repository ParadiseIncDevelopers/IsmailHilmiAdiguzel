using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Models
{
    [Serializable]
    public class OrganisationUser
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; } = Guid.NewGuid();

        [JsonPropertyName("organisation_name")]
        public string? organisation_name { get; set; }
        [JsonPropertyName("organisation_full_name")]
        public string? organisation_full_name { get; set; }
        [JsonPropertyName("organisation_website")]
        public string? organisation_website { get; set; }
        [JsonPropertyName("organisation_phone_number")]
        public string? organisation_phone_number { get; set; }
        [JsonPropertyName("organisation_province")]
        public string? organisation_province { get; set; }
        [JsonPropertyName("organisation_name")]
        public string? organisation_city { get; set; }
        [JsonPropertyName("organisation_name")]
        public string? organisation_neighbourhood { get; set; }
        [JsonPropertyName("organisation_name")]
        public string? organiastion_barcode { get; set; }
        [JsonPropertyName("organisation_name")]
        public string? organiastion_work_domain { get; set; }
        [JsonPropertyName("organisation_name")]
        public string? organiastion_tax_number { get; set; }
        [JsonPropertyName("organisation_name")]
        public int? organisation_bank { get; set; }
        [JsonPropertyName("organisation_name")]
        public string? organisation_iban { get; set; }
        [JsonPropertyName("organisation_name")]
        public string? organisation_main_work_domain { get; set; }
        [JsonPropertyName("organisation_name")]
        public int? organisation_category { get; set; }
        [JsonPropertyName("organisation_name")]
        public int? organisation_un_domain { get; set; }
        [JsonPropertyName("organisation_type")]
        public int? organisation_type { get; set; }
        [JsonPropertyName("organisation_password")]
        public string? organisation_password { get; set; }
        [JsonPropertyName("organisation_user_name")]
        public string? organisation_user_name { get; set; }
        [JsonPropertyName("organisation_user_surname")]
        public string? organisation_user_surname { get; set; }
        [JsonPropertyName("organisationUser_phone_number")]
        public string? organisationUser_phone_number { get; set; }
        [JsonPropertyName("organisation_user_email")]
        public string? organisation_user_email { get; set; }
        [JsonPropertyName("organisation_user_domain")]
        public string? organisation_user_domain { get; set; }
    }
}
