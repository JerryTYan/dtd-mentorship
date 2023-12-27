using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using DTD_Mentorship_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DTD_Mentorship_Project.Pages.Profile
{
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;
        private readonly DBContext _dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;


        public string FullName { get; set; } // Combine First and Last Name
        public string School { get; set; }
        public string District { get; set; }
        public int Progress { get; set; }

        public List<Mentee> CurrentMentees { get; set; }
        public string Image { get; set; } // Add this property for the image path


        [BindProperty]
        public IFormFile AvatarFile { get; set; }
   
        public string AboutMe { get; set; }

        public bool IsEditMode { get; set; }
        [BindProperty]
        public string EditedAboutMe { get; set; }

        public DashboardModel(DBContext dbContext, ILogger<DashboardModel> logger, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                // Retrieve the most currently authenticated user
                var userId = await _dbContext.Users.MaxAsync(u => (int?)u.UserId);

                // Query the database for the user with the sp
                var user = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.UserId == userId);

                if (user != null)
                {
                    _logger.LogInformation("User Found Successfully");
                    FullName = $"{user.FirstName} {user.LastName}";
                    School = user.Company;
                    District = user.City;
                    Image = user.Image;
                    AboutMe = user.AboutMe;
                }

                
                // Fetch other dashboard data (e.g., current mentees) in a similar manner
                // Ensure CurrentMentees is initialized
                CurrentMentees = new List<Mentee>();

                // Fetch other dashboard data (e.g., current mentees) in a similar manner
                CurrentMentees.Add(new Mentee { Name = "Mentee 1", Description = "Description for Mentee 1", Title = "Title 1", Area = "Area 1", Image = "path/to/image1.jpg" });
                CurrentMentees.Add(new Mentee { Name = "Mentee 2", Description = "Description for Mentee 2", Title = "Title 2", Area = "Area 2", Image = "path/to/image2.jpg" });
                // Add more mentees here
                IsEditMode = false;
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving dashboard data: {ex.Message}");
                return RedirectToPage("/Error");
            }
        }

        public void OnPostToggleEditMode()
        {
                IsEditMode = !IsEditMode; // Toggle edit mode
        }
        public async Task<IActionResult> OnPostUpdateAboutMe()
        {

            try
            {
                // Retrieve the most currently authenticated user
                var userId = await _dbContext.Users.MaxAsync(u => (int?)u.UserId);

                // Query the database for the user with the specified ID
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);

                if (user != null)
                {
                    // Update the "About Me" content in the database
                    user.AboutMe = EditedAboutMe;
                    await _dbContext.SaveChangesAsync();
                }

                // Set IsEditMode to false after updating AboutMe

                AboutMe = EditedAboutMe;
                IsEditMode = false;

                return RedirectToPage();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating 'About Me': {ex.Message}");
                return RedirectToPage("/Error");
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (AvatarFile != null && AvatarFile.Length > 0)
            {
                try
                {
                    var user = await _dbContext.Users
                        .OrderByDescending(u => u.UserId)
                        .FirstOrDefaultAsync();

                    if (user != null)
                    {
                        // Save the uploaded file to wwwroot/images directory
                        var uploadPath = Path.Combine(_hostEnvironment.WebRootPath, "images");
                        var fileName = $"{user.UserId}_avatar_{DateTime.Now:yyyyMMddHHmmssfff}{Path.GetExtension(AvatarFile.FileName)}";
                        var filePath = Path.Combine(uploadPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await AvatarFile.CopyToAsync(stream);
                        }

                        // Update the user's avatar path in the database
                        user.Image = $"/images/{fileName}";
                        await _dbContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error uploading avatar: {ex.Message}");
                }
            }
            return RedirectToPage("/Profile/Dashboard");
        }

    }
}

