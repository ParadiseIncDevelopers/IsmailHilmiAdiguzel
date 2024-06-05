using IsmailHilmiAdiguzelProje.Models;
using IsmailHilmiAdiguzelProje.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IsmailHilmiAdiguzelProje.Services.Concrete
{
    public class UserClickCounterService : IUserClickCounterService
    {
        private readonly MySQLDataContext _dataContext;

        public UserClickCounterService(MySQLDataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> CountClick(UserClickCounter counter)
        {
            await _dataContext.users_clicks_counters.AddAsync(counter);
            return new JsonResult(counter);
        }
    }
}
