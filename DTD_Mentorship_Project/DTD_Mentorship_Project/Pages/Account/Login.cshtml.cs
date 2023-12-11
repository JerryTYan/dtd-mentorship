using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DTD_Mentorship_Project.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger _logger;

        [BindProperty]
        public LoginFormData FormData { get; set; }

        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
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