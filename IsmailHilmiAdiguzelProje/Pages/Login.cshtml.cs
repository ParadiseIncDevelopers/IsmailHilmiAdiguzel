using IsmailHilmiAdiguzelProje.Interfaces;
using IsmailHilmiAdiguzelProje.Models;
using IsmailHilmiAdiguzelProje.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace IsmailHilmiAdiguzelProje.Pages
{
    [BindProperties]
    public class LoginModel : PageModel, IJsonObjectSerializer<User>
    {
        private readonly IUserService _userService;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public LoginModel(IUserService userService) 
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnPostLoginUserAsync()
        {
            if (ModelState.IsValid) 
            {
                JsonResult result = (JsonResult) await _userService.ConnectUser(Email, Password);
                User user = DeserializeObject(result.Value);
                TempData["NameAndSurname"] = $"{user.name} {user.surname}";
                return new RedirectToPageResult("/Index");
            }
            else 
            {
                return new ForbidResult();
            }
        }

        public User DeserializeObject(object value)
        {
            JsonSerializerOptions options = new() { WriteIndented = true };
            string serializedString = JsonSerializer.Serialize((User)value, options);
            User? user = JsonSerializer.Deserialize<User>(serializedString);
            return user;
        }
    }
}
