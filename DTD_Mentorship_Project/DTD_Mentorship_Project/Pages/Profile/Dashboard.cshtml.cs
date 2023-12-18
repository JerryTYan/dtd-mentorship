using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using DTD_Mentorship_Project; // Namespace where your models are defined
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DTD_Mentorship_Project.Pages.Profile
{
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;
        private readonly DBContext _dbContext;
        private readonly GeocodingService _geocodingService;

        // Define properties here
        public string Name { get; set; }
        public string School { get; set; }
        public string District { get; set; }
        public int Progress { get; set; }
        public List<Mentee> CurrentMentees { get; set; }
        public string AboutMe { get; set; }

        public DashboardModel(DBContext bdContext, GeocodingService geocodingService, ILogger<Eligibility> logger)
        {
            _dbContext = bdContext;
            _geocodingService = geocodingService;
            _logger = _logger;
        }

        public void OnGet()
        {
            // Replace 'YourUserId' with the actual user ID or some identifier to fetch the correct user
            var user = _dbContext.Users
    .Include(u => u.Addresses)  // Include related addresses if needed
    .FirstOrDefault(u => u.SelectedUserTypeId == "Mentor");

            var Mentee = _dbContext.MentorMentees
    .Include(mm => mm.Mentor)  // Include related ids if needed
    .Include(mm => mm.Mentee);
            if (user != null)
                _logger.LogInformation("User Found Successful.User");
            {
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
