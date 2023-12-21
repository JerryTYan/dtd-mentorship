using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace DTD_Mentorship_Project.Pages.Profile
{
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger; // Corrected logger type
        private readonly DBContext _dbContext;
        // Define properties here
        public string Name { get; set; }
        public string School { get; set; }
        public string District { get; set; }
        public int Progress { get; set; }
        public List<Mentee> CurrentMentees { get; set; }
        public string AboutMe { get; set; }

        public DashboardModel(DBContext bdContext, ILogger<DashboardModel> logger)
        {
            _dbContext = bdContext;
            _logger = logger;
        }

        public void OnGet()
        {
            // Replace 'YourUserId' with the actual user ID or some identifier to fetch the correct user
            var user = _dbContext.Users
                .Include(u => u.Addresses)  // Include related addresses if needed
                .FirstOrDefault(u => u.SelectedUserTypeId == "Mentor");

            if (user != null)
            {
                _logger.LogInformation("User Found Successfully");
                // Populate properties from the database
                Name = $"{user.FirstName} {user.LastName}";
                School = user.Company;  // Assuming the company represents the school
                District = user.City;   // Assuming the city represents the district
            }

            // Fetch other dashboard data (e.g., current mentees) in a similar manner
            CurrentMentees = new List<Mentee>
    {
        new Mentee { Name = "Mentee 1", Description = "Description for Mentee 1", Title = "Title 1", Area = "Area 1", Image = "path/to/image1.jpg" },
        new Mentee { Name = "Mentee 2", Description = "Description for Mentee 2", Title = "Title 2", Area = "Area 2", Image = "path/to/image2.jpg" },
        // Add more mentees here
    };

            AboutMe = "Hello, I'm John Doe, the only person who can trip over a wireless network! ..."; // (Your existing AboutMe data)
        }

    }
}
