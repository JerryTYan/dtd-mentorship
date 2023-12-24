using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DTD_Mentorship_Project.Models;
using Microsoft.Extensions.Logging; // Add this import
using System.Globalization;
using BCrypt.Net;

namespace DTD_Mentorship_Project.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger; // Corrected the ILogger type
        private readonly DBContext _dbContext;


        [BindProperty]
        public LoginFormData FormData { get; set; }

        public LoginModel(Models.DBContext db, ILogger<LoginModel> logger)
        {
            _logger = logger;
            _dbContext = db;

        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid && FormData != null)
            {
                var email = FormData.Email;
                var password = FormData.Password;

                var user = _dbContext.Users.SingleOrDefault(u => u.Email == email);

                if (user != null)
                {

                    if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        // Authentication successful

                        // TODO: Implement authentication logic (e.g., set a cookie, create a session)
                        // For demonstration purposes, you can store the UserId in TempData
                        TempData["UserId"] = user.UserId;

                        _logger.LogInformation("Email: {Email}, Password: {Password}", email, password);

                        return RedirectToPage("/Profile/Dashboard");
                    }
                    else
                    {
                        // Authentication failed
                        ModelState.AddModelError(string.Empty, "Invalid email or password");
                        _logger.LogInformation("No user found for email: {Email}", email);
                    }
                }

            }
            return Page();
        }
    }

    public class LoginFormData
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}