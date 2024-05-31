using Google.Protobuf.WellKnownTypes;
using IsmailHilmiAdiguzelProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {

        }

        public void OnGet()
        {

        }

        private readonly string _connectionString = "Server=hangelyazilim.mysql.database.azure.com;Port=3306;Database=hangel;Uid=yusufsalimozbek;Pwd=hangelyazilim!997;";

        public async Task<IActionResult> OnGetCounterClickLink(string clickWebsite, string clickName)
        {
            if (clickName == null)
            {
                return RedirectToPage("/Login");
            }
            else
            {
                // Create a MySqlConnection object
                using (var connection = new MySqlConnection(_connectionString))
                {
                    // Get the current datetime in UTC
                    DateTime clickDateUtc = DateTime.UtcNow;

                    // Convert UTC datetime to local time (Turkey time)
                    DateTime clickDateLocal = clickDateUtc.ToLocalTime();

                    // SQL command to insert a new record into user_click_counters table
                    string insertSql = "INSERT INTO hangel.users_clicks_counters (click_website, click_date, click_name) VALUES (@clickWebsite, @clickDate, @clickName)";

                    // Create a MySqlCommand object
                    using (var command = new MySqlCommand(insertSql, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@clickWebsite", clickWebsite);
                        command.Parameters.AddWithValue("@clickDate", clickDateLocal); // Use local time
                        command.Parameters.AddWithValue("@clickName", clickName);

                        try
                        {
                            // Open the connection
                            await connection.OpenAsync();

                            // Execute the command asynchronously
                            await command.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions
                            // For simplicity, you can just return a generic error message
                            return StatusCode(500, ex.Message);
                        }
                    }
                } 
          
            }

            // Return an empty result
            return new EmptyResult();
            
        }

        /**
         [JsonPropertyName("description")]
            public string? Description { get; set; }

            [JsonPropertyName("require_approval")]
            public int RequireApproval { get; set; }

            [JsonPropertyName("require_terms_and_conditions")]
            public int RequireTermsAndConditions { get; set; }

            [JsonPropertyName("terms_and_conditions")]
            public string? TermsAndConditions { get; set; }

            [JsonPropertyName("preview_url")]
            public string? PreviewUrl { get; set; }

            [JsonPropertyName("currency")]
            public string? Currency { get; set; }

            [JsonPropertyName("default_payout")]
            public string? DefaultPayout { get; set; }

            [JsonPropertyName("protocol")]
            public string? Protocol { get; set; }

            [JsonPropertyName("status")]
            public string? Status { get; set; }

            [JsonPropertyName("expiration_date")]
            public DateTime ExpirationDate { get; set; }

            [JsonPropertyName("payout_type")]
            public string? PayoutType { get; set; }

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
            public string? EmailInstructionsFrom { get; set; }

            [JsonPropertyName("email_instructions_subject")]
            public string? EmailInstructionsSubject { get; set; }

            [JsonPropertyName("enforce_secure_tracking_link")]
            public int EnforceSecureTrackingLink { get; set; }

            [JsonPropertyName("has_goals_enabled")]
            public int HasGoalsEnabled { get; set; }

            [JsonPropertyName("default_goal_name")]
            public string? DefaultGoalName { get; set; }

            [JsonPropertyName("modified")]
            public long Modified { get; set; }

            [JsonPropertyName("use_target_rules")]
            public int UseTargetRules { get; set; }

            [JsonPropertyName("use_payout_groups")]
            public int UsePayoutGroups { get; set; }

            [JsonPropertyName("link_platform")]
            public string? LinkPlatform { get; set; }

            [JsonPropertyName("is_expired")]
            public int IsExpired { get; set; }

            [JsonPropertyName("dne_download_url")]
            public string? DneDownloadUrl { get; set; }

            [JsonPropertyName("dne_unsubscribe_url")]
            public string? DneUnsubscribeUrl { get; set; }

            [JsonPropertyName("dne_third_party_list")]
            public bool DneThirdPartyList { get; set; }

            [JsonPropertyName("approval_status")]
            public string? ApprovalStatus { get; set; }
         
         */
    }
}
