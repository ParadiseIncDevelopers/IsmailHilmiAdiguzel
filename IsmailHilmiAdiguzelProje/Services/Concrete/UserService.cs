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
            IQueryable<User>? user = _dataContext.users_table.AsQueryable()
                .Where(x => x.email == Email && x.password == Password);

            if (user.Count() != 0) 
            {
                return new JsonResult(await user.FirstAsync());
            }
            else 
            {
                return new JsonResult(null);
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
