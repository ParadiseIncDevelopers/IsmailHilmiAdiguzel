using IsmailHilmiAdiguzelProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsmailHilmiAdiguzelProje.Services.Abstract
{
    public interface IUserService
    {
        Task<IActionResult> ConnectUser(string Email, string Password);
        Task<IActionResult> AddUser(User user, string password2);
        Task<IActionResult> EditUser();
        Task<IActionResult> DeleteUser();
    }
}
