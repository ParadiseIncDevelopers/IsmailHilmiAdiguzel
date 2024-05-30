using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester
{
    using System;
    using System.Text.Json.Serialization;

    public class OfferModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("require_approval")]
        public int RequireApproval { get; set; }

        [JsonPropertyName("require_terms_and_conditions")]
        public int RequireTermsAndConditions { get; set; }

        [JsonPropertyName("terms_and_conditions")]
        public string TermsAndConditions { get; set; }

        [JsonPropertyName("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("default_payout")]
        public string DefaultPayout { get; set; }

        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("expiration_date")]
        public DateTime ExpirationDate { get; set; }

        [JsonPropertyName("payout_type")]
        public string PayoutType { get; set; }

        [JsonPropertyName("percent_payout")]
        public decimal PercentPayout { get; set; }

        [JsonPropertyName("allow_multiple_conversions")]
        public int AllowMultipleConversions { get; set; }

        [JsonPropertyName("allow_website_links")]
        public int AllowWebsiteLinks { get; set; }

        [JsonPropertyName("allow_direct_links")]
        public int AllowDirectLinks { get; set; }

        [JsonPropertyName("show_custom_variables")]
        public int ShowCustomVariables { get; set; }

        [JsonPropertyName("session_hours")]
        public int SessionHours { get; set; }

        [JsonPropertyName("show_mail_list")]
        public int ShowMailList { get; set; }

        [JsonPropertyName("dne_list_id")]
        public int DneListId { get; set; }

        [JsonPropertyName("email_instructions")]
        public int EmailInstructions { get; set; }

        [JsonPropertyName("email_instructions_from")]
        public string EmailInstructionsFrom { get; set; }

        [JsonPropertyName("email_instructions_subject")]
        public string EmailInstructionsSubject { get; set; }

        [JsonPropertyName("enforce_secure_tracking_link")]
        public int EnforceSecureTrackingLink { get; set; }

        [JsonPropertyName("has_goals_enabled")]
        public int HasGoalsEnabled { get; set; }

        [JsonPropertyName("default_goal_name")]
        public string DefaultGoalName { get; set; }

        [JsonPropertyName("modified")]
        public long Modified { get; set; }

        [JsonPropertyName("use_target_rules")]
        public int UseTargetRules { get; set; }

        [JsonPropertyName("use_payout_groups")]
        public int UsePayoutGroups { get; set; }

        [JsonPropertyName("link_platform")]
        public string LinkPlatform { get; set; }

        [JsonPropertyName("is_expired")]
        public int IsExpired { get; set; }

        [JsonPropertyName("dne_download_url")]
        public string DneDownloadUrl { get; set; }

        [JsonPropertyName("dne_unsubscribe_url")]
        public string DneUnsubscribeUrl { get; set; }

        [JsonPropertyName("dne_third_party_list")]
        public bool DneThirdPartyList { get; set; }

        [JsonPropertyName("approval_status")]
        public string ApprovalStatus { get; set; }
    }

}
