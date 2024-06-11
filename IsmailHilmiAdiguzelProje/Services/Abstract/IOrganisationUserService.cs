using IsmailHilmiAdiguzelProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsmailHilmiAdiguzelProje.Services.Abstract
{
    public interface IOrganisationUserService
    {
        Task<IActionResult> AddOrganisation(OrganisationUser organisation);
        Task<IActionResult> EditOrganisation(Guid id, OrganisationUser organisation);
        Task<IActionResult> DeleteOrganisation(Guid id);
        Task<IActionResult> ConnectToOrganisation(string userEmail, string userPassword);
    }
}
