using IsmailHilmiAdiguzelProje.Interfaces;
using IsmailHilmiAdiguzelProje.Models;
using IsmailHilmiAdiguzelProje.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace IsmailHilmiAdiguzelProje.Pages
{
    public class IndexModel(IUserService userService, IUserClickCounterService userClickCounter) : PageModel
    {
        private readonly IUserClickCounterService _userClickCounter = userClickCounter;
        private readonly IUserService _userService = userService;

        public static string? NameAndSurname { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostLoginUserAsync(string Email, string Password)
        {
            if (Email == null)
            {
                TempData["PrintMessage"] = "ERROR_EMAIL_NULL";
                return new RedirectToPageResult("/Index");
            }
            if (Password == null) 
            {
                TempData["PrintMessage"] = "ERROR_PASSWORD_NULL";
                return new RedirectToPageResult("/Index");
            }
            else
            {
                JsonResult result = (JsonResult) await _userService.ConnectUser(Email, Password);

                if (result.Value == null)
                {
                    TempData["PrintMessage"] = "ERROR_USER_NOT_FOUND";
                    return new RedirectToPageResult("/Index");
                }
                else
                {
                    User? user = JsonObjectSerializer<User>.DeserializeObject(result.Value);
                    TempData["NameAndSurname"] = $"{ user.name } { user.surname }";
                    return new RedirectToPageResult("/Index");
                }
            }
        }

        public async Task<IActionResult> OnPostRegisterClassicUser(string classicName, string classicSurname, string classicEmail, string classicProvince, string classicDistrict, string classicNeighborhood, string classicAddress, string classicGender, string classicPassword, string classicPassword2)
        {
            User user = new()
            {
                email = classicEmail,
                name = classicName,
                surname = classicSurname,
                gender = Convert.ToInt32(classicGender),
                neighbourhood = classicNeighborhood,
                province = classicProvince,
                district = classicDistrict,
                address = classicAddress,
                password = classicPassword,
                user_type = 0
            };

            object result = await _userService.AddUser(user, classicPassword2);
            TempData["PrintMessage"] = result.ToString();
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnPostRegisterOrganisationUser(string organisationName, string organisationFullName, string organisationWebsite, string organisationPhoneNumber, string organisationProvince, string organisationCity, string organisationNeighbourhood, string organiastionBarcode, string organiastionWorkDomain, string organiastionTaxNumber, string organisationBank, string organisationIban, string organisationMainWorkDomain, string organisationCategory, string organisationUnDomain, string organisationType, string organisationPassword, string organisationPassword2, string organisationUserName, string organisationUserSurname, string organisationUserPhoneNumber, string organisationUserEmail, string organisationUserDomain) 
        {
            return new JsonResult("");
        }

        public async Task<IActionResult> OnPostRegisterBrandUser() 
        {
            return new JsonResult("");
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

        public UserClickCounter? DeserializeObject(object value)
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
