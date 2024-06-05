using IsmailHilmiAdiguzelProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace IsmailHilmiAdiguzelProje.Services.Abstract
{
    public interface IUserClickCounterService
    {
        Task<IActionResult> CountClick(UserClickCounter counter); 
    }
}
