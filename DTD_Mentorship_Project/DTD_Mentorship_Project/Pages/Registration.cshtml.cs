using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DTD_Mentorship_Project.Pages
{
	public class NewUser
	{
		[Required]
		public string? Email { get; set; }
		
		[Required]
		public string? Password { get; set; }

		[Compare("Password", ErrorMessage = "Password doesn't match.")]
		public string? Confirm { get; set; }
	}
	public class RegistrationModel : PageModel
	{
		private readonly ILogger _logger;


		[BindProperty]
		public NewUser? FormData { get; set; }

		public RegistrationModel(ILogger<RegistrationModel> logger)
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
				var confirm = FormData.Confirm;

				_logger.LogInformation("Email: {Email}, Password: {Password}, Confirm: {Confirm}", email, password, confirm);
				return RedirectToPage("/Submission");

			}


			return RedirectToPage();
		}
	}
}

