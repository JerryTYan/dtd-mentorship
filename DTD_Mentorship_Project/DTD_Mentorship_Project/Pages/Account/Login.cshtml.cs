using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DTD_Mentorship_Project.Models;
using System.Globalization;

namespace DTD_Mentorship_Project.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger _logger;
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

                var user = _dbContext.Users.SingleOrDefault(user => user.Email == email && user.Password == password);
                var identity = _dbContext.Identities.SingleOrDefault(identity => identity.Id == user.IdentityId);

                var identity_name = identity.IdentityName;   

                //var user = _dbContext.Users.ToList();



                if (user != null)
                {
                    _logger.LogInformation("User found: {User}", user.LastName);
                    _logger.LogInformation("Id found: {IdName}", identity_name);


                }
                else
                {
                    _logger.LogInformation("No user found for email: {Email}", email);
                }

                // TODO: Add authentication logic here

                _logger.LogInformation("Email: {Email}, Password: {Password}", email, password);

                return RedirectToPage("/Profile/Dashboard");
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