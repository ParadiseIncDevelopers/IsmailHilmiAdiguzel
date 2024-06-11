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

        public async Task<IActionResult> AddUser(User user, string password2)
        {
            IQueryable<User>? users = _dataContext.users_table.AsQueryable();
            int userCount = users.Count();
            IQueryable<User> userEmailFilter = users.Where(x => x.email == user.email);

            if (userCount == 0)
            {
                await _dataContext.users_table.AddAsync(user);
                return new JsonResult(user);
            }
            else 
            {
                if (userEmailFilter.Any())
                {
                    return new JsonResult("ERROR_EMAIL_EXIST");
                }
                else 
                {
                    if (user.password == password2)
                    {
                        await _dataContext.users_table.AddAsync(user);
                        return new JsonResult("SUCCESS_USER_CREATED");
                    }
                    else 
                    {
                        return new JsonResult("ERROR_PASSWORD_NOT_EQUAL");
                    }
                }
            }
        }

        public async Task<IActionResult> ConnectUser(string Email, string Password)
        {
            IQueryable<User>? user = _dataContext.users_table.AsQueryable()
                .Where(x => x.email == Email && x.password == Password);

            if (user.Any()) 
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
