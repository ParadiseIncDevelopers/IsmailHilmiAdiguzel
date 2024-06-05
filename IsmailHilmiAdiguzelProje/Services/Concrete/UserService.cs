using IsmailHilmiAdiguzelProje.Models;
using IsmailHilmiAdiguzelProje.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsmailHilmiAdiguzelProje.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly MySQLDataContext _dataContext;

        public UserService(MySQLDataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public Task<IActionResult> AddUser()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> ConnectUser(string Email, string Password)
        {
            User? user = await _dataContext.users_table.AsQueryable().Where(x => x.email == Email && x.password == Password).FirstAsync();

            if (user != null) 
            {
                return new JsonResult(user);
            }
            else 
            {
                return new ForbidResult();
            }
        }

        public Task<IActionResult> DeleteUser()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> EditUser()
        {
            throw new NotImplementedException();
        }
    }
}
