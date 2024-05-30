using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IsmailHilmiAdiguzelProje.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostSubmitForm(string email, string password) 
        {
            string concat = email + ":" + password;
            return new JsonResult(concat);
        }
    }
}
