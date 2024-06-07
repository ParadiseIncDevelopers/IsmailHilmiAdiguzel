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
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public IActionResult OnGet()
        {
            return Page();
        }

        public LoginModel(IUserService userService) 
        {
            _userService = userService;
        }
    }
}
