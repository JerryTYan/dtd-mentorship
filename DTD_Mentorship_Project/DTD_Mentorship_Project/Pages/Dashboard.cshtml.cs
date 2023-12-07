//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using DTD_Mentorship_Project.Models;
//using Microsoft.EntityFrameworkCore;

//namespace DTD_Mentorship_Project.Pages
//{

//    public class DashboardModel : PageModel
//    {
//        private readonly ILogger<DashboardModel> _logger;
//         private readonly DBContext _dbContext;

//        // Define properties here
//        public User ? LoggedInUser { get; set; }

//        public DashboardModel(Models.DBContext db, ILogger<DashboardModel> logger)
//        {
//            _logger = logger;
//            _dbContext = db;
//        }

//        public IActionResult OnGet(string UserEmail = "")
//        {

//            var email = UserEmail;

//            LoggedInUser = _dbContext.Find<Models.User>(email);


//            if (UserEmail != "")
//            {
//                HttpContext.Session.SetString("UserEmail", UserEmail);
//            }
//            else
//            {
//                email = HttpContext.Session.GetString("UserEmail") ?? "";
//            }
//            return new OkResult();

//            //LoggedInUser = _dbContext.User.Include(u => u.MentorMenteeMentee).SingleOrDefault(u => u.Email == email);
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project.Models;

namespace DTD_Mentorship_Project.Pages
{

    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;

        // Define properties here
        public string Name { get; set; }
        public string District { get; set; }
        public List<Mentee> CurrentMentees { get; set; }
        public string AboutMe { get; set; }

        public DashboardModel(ILogger<DashboardModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Initialize properties here
            Name = "John Doe";
            District = "District 1";
            CurrentMentees = new List<Mentee>
       {
           new Mentee { Name = "Mentee 1" },
           new Mentee { Name = "Mentee 2" },
           // Add more mentees here
       };
            AboutMe = "About me...";
        }
    }
}