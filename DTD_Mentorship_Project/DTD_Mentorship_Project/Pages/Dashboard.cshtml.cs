using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging; 

namespace DTD_Mentorship_Project.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;

        // Define properties here
        public string Name { get; set; }
        public string School { get; set; }
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
            School = "University of California Los Angeles";
            District = "District 1";
            CurrentMentees = new List<Mentee>
            {
                new Mentee { Name = "Mentee 1", Description = "Description for Mentee 1", Title = "Title 1", Area = "Area 1", Image = "path/to/image1.jpg" },
                new Mentee { Name = "Mentee 2", Description = "Description for Mentee 2", Title = "Title 2", Area = "Area 2", Image = "path/to/image2.jpg" },
                // Add more mentees here
            };
            AboutMe = "Hello, I'm John Doe, the only person who can trip over a wireless network! I'm a professional snack engineer, a part-time unicorn whisperer, and a full-time internet explorer. In my spare time, I enjoy practicing reverse psychology on my pet rock and attempting to break my high score in imaginary sword fighting. My friends say I have a PhD in procrastination and a master's degree in losing my keys. But don't worry, I'm also a certified ninja in finding the best memes and a connoisseur of accidentally cooking things 'al dente.' Remember, if life gives you lemons, I'm probably the one who misplaced them!";
        }
    }
}
