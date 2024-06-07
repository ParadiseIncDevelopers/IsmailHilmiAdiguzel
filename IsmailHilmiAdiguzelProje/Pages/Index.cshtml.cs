using Google.Protobuf.WellKnownTypes;
using IsmailHilmiAdiguzelProje.Interfaces;
using IsmailHilmiAdiguzelProje.Models;
using IsmailHilmiAdiguzelProje.Services.Abstract;
using IsmailHilmiAdiguzelProje.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IUserClickCounterService _userClickCounter;
        private readonly IUserService _userService;

        public static string? NameAndSurname { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Surname { get; set; }

        [Required]
        [RegularExpression(@"^\+[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Password { get; set; }

        public IndexModel(IUserService userService, IUserClickCounterService userClickCounter)
        {
            _userClickCounter = userClickCounter;
            _userService = userService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostLoginUserAsync()
        {
            if (Email == null)
            {
                ModelState.AddModelError("Email", "Please try again.");
            }
            if (Password == null) 
            {
                ModelState.AddModelError("Password", "Please try again.");
            }
            else
            {
                JsonResult result = (JsonResult) await _userService.ConnectUser(Email, Password);

                if (result.Value == null)
                {
                    ModelState.AddModelError("Email", "User not found please try again.");
                    return new PageResult();
                }
                else
                {
                    User? user = JsonObjectSerializer<User>.DeserializeObject(result.Value);
                    TempData["NameAndSurname"] = $"{ user.name } { user.surname }";
                    return new RedirectToPageResult("/Index");
                }
            }

            return new PageResult();
        }

        public async Task<IActionResult> OnPostRegisterUser()
        {
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    email = Email,
                    name = Name,
                    surname = Surname,
                    password = Password,
                    phoneNumber = PhoneNumber,
                    user_type = "USER"
                };

                await _userService.AddUser(Name, Surname, Email, PhoneNumber, Password);
                return new JsonResult("Welcome to Hangel.");
            }
            else 
            {
                ModelState.AddModelError("Email", "User not found please try again.");
                return new PageResult();
            }
        }

        public async Task<IActionResult> OnGetCounterClickLink(string clickWebsite, string clickName)
        {
            if (clickName == null)
            {
                return new JsonResult("LOGIN");
            }
            else
            {
                DateTime clickDateUtc = DateTime.UtcNow;
                DateTime clickDateLocal = clickDateUtc.ToLocalTime();

                UserClickCounter counter = new()
                {
                    click_date = clickDateLocal,
                    click_website = clickWebsite,
                    click_name = clickName
                };
                
                await _userClickCounter.CountClick(counter);

                return Redirect(clickWebsite);
            }
            
        }

        public UserClickCounter DeserializeObject(object value)
        {
            JsonSerializerOptions options = new() { WriteIndented = true };
            string serializedString = JsonSerializer.Serialize((UserClickCounter) value, options);
            UserClickCounter? user = JsonSerializer.Deserialize<UserClickCounter>(serializedString);
            return user;
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
