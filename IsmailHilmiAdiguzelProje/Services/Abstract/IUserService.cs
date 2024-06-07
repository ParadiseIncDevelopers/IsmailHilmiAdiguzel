using Microsoft.AspNetCore.Mvc;

namespace IsmailHilmiAdiguzelProje.Services.Abstract
{
    public interface IUserService
    {
        Task<IActionResult> ConnectUser(string Email, string Password);
        Task<IActionResult> AddUser(string name, string surname, string email, string phoneNumber, string password);
        Task<IActionResult> EditUser();
        Task<IActionResult> DeleteUser();
    }
}
