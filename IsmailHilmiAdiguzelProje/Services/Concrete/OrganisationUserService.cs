using IsmailHilmiAdiguzelProje.Models;
using IsmailHilmiAdiguzelProje.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IsmailHilmiAdiguzelProje.Services.Concrete
{
    public class OrganisationUserService(MySQLDataContext dataContext) : IOrganisationUserService
    {
        private readonly MySQLDataContext _dataContext = dataContext;

        public async Task<IActionResult> AddOrganisation(OrganisationUser organisation)
        {
            await _dataContext.organisations.AddAsync(organisation);
            return new JsonResult(organisation);
        }

        public Task<IActionResult> ConnectToOrganisation(string userEmail, string userPassword)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteOrganisation(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> EditOrganisation(Guid id, OrganisationUser organisation)
        {
            throw new NotImplementedException();
        }
    }
}
