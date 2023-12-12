using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// using System.Security.Claims; // Uncomment when backend is ready

namespace DTD_Mentorship_Project.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Uncomment the following lines when backend is ready
            // HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Clear any session or cookie data here

            return RedirectToPage("/Account/Login");
        }
    }
}
