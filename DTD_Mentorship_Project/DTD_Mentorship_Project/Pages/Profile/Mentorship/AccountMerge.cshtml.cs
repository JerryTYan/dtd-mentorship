using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DTD_Mentorship_Project.Pages
{
    public class AccountmergeModel : PageModel
    {
        public void OnGet()
        {
            var email = HttpContext.Session.GetString("UserEmail") ?? "";
        }
    }
}