using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace DTD_Mentorship_Project.Pages
{
   
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;
        private readonly DBContext _dbContext;

        // Define properties here
        public User LoggedInUser { get; set; }
        public DashboardModel(Models.DBContext db, ILogger<DashboardModel> logger)
        {
            _logger = logger;
            _dbContext = db;
        }

        public IActionResult OnGet(string UserEmail = "")
        {




            var email = UserEmail;

            if (UserEmail != "")
            {
                HttpContext.Session.SetString("UserEmail", UserEmail);
            }
            else
            {
                email = HttpContext.Session.GetString("UserEmail") ?? "";
            }
            return new OkResult();

            //LoggedInUser = _dbContext.User.Include(u => u.MentorMenteeMentee).SingleOrDefault(u => u.Email == email);
        }
    }
}
