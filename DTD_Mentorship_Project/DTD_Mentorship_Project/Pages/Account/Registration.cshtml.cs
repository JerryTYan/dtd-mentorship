using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DTD_Mentorship_Project.Models;
using Newtonsoft.Json; // Add this using statement for JSON deserialization

namespace DTD_Mentorship_Project.Pages
{
    public class NewUser
	{
        [BindProperty]
        [Required]
		public string Email { get; set; }

		[BindProperty]
		[Required]
		public string Password { get; set; }

		[BindProperty]
        [Required]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
		public string Confirm { get; set; }
    }

    public class RegistrationModel : PageModel
	{

        //Initialize DB context
        private readonly DBContext _bdContext;
        private readonly ILogger _logger;

        [BindProperty]
        public NewUser? FormData { get; set; }

        public RegistrationModel(DBContext bdContext, ILogger<RegistrationModel> logger)
        {
            _bdContext = bdContext;
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


                var eligibilityDataJson = TempData["EligibilityData"] as string;
                
                if (!string.IsNullOrEmpty(eligibilityDataJson))
                {
                    var eligibilityData = JsonConvert.DeserializeObject<User>(eligibilityDataJson);

                    if (IsEmailAlreadyRegistered(email))
                    {
                        ModelState.AddModelError("FormData.Email", "This email is already registered.");
                        return Page();
                    }

                    _logger.LogInformation("Email: {Email}, Password: {Password}, Confirm: {Confirm}", email, password, confirm);
                    // Save both eligibility and registration data to the database
                    SaveDataToDatabase(eligibilityData, email, password);

                    return RedirectToPage("/Account/Login");
                }
                else
				{
                    // Handle TempData missing eligibility data
                    _logger.LogError("Eligibility Data missing in TempData");
                    return RedirectToPage("/Error");
                }
			}


			if (!ModelState.IsValid)
			{
				TempData["Email"] = FormData.Email;
				TempData["Password"] = FormData.Password;
				TempData["Confirm"] = FormData.Confirm;

			}

			return Page();

		}

        private bool IsEmailAlreadyRegistered(string email)
        {
            // Check if the email is already present in the database
            return _bdContext.Users.Any(u => u.Email == email);
        }

        private void SaveDataToDatabase(User eligibilityData, string email, string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(FormData.Password);
            // Save eligibilityData and registration data to the database using  DbContext (_bdContext)
            _bdContext.Users.Add(new User
             {
                 //Save registration data to DB
                 SelectedUserTypeId = eligibilityData.SelectedUserTypeId.ToString(),
                 FirstName = eligibilityData.FirstName,
                 LastName = eligibilityData.LastName,
                 Addresses = eligibilityData.Addresses,
                 City = eligibilityData.City,
                 State = eligibilityData.State,
                 Zip = eligibilityData.Zip,
                 DOB = eligibilityData.DOB,
                 FieldofWork = eligibilityData.FieldofWork,
                 Degree = eligibilityData.Degree,
                 Company = eligibilityData.Company,
                 Availability = eligibilityData.Availability,
                 Email =email, 
                 Password = hashedPassword,
             });
            _bdContext.SaveChanges();
        }

    }
}

