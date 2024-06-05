using Microsoft.AspNetCore.Mvc;

namespace IsmailHilmiAdiguzelProje.Services.Abstract
{
    public interface IUserService
    {
        Task<IActionResult> ConnectUser(string Email, string Password);
        Task<IActionResult> AddUser();
        Task<IActionResult> EditUser();
        Task<IActionResult> DeleteUser();
    }
}
