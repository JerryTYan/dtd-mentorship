using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DTD_Mentorship_Project.Models;
using Newtonsoft.Json; // Add this using statement for JSON deserialization
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
        private readonly DBContext _dbContext;
        private readonly ILogger _logger;

        [BindProperty]
        public NewUser? FormData { get; set; }

        public RegistrationModel(DBContext bdContext, ILogger<RegistrationModel> logger)
        {
            _dbContext = bdContext;
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
                    string userAddress = TempData["UserStreetAddress"] as string;

                    _logger.LogInformation("Email: {Email}, Password: {Password}, Confirm: {Confirm}", email, password, confirm);
                    // Save both eligibility and registration data to the database
                    SaveDataToDatabase(eligibilityData, email, password, userAddress);

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

        private void SaveDataToDatabase(User eligibilityData, string email, string password, string streetAddress)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(FormData.Password);

            // Save eligibilityData and registration data to the database using  DbContext (_bdContext)
            _dbContext.Users.Add(new User
            {
                //Save registration data to DB
                IdentityId = eligibilityData.IdentityId,
                FirstName = eligibilityData.FirstName,
                LastName = eligibilityData.LastName,
                City = eligibilityData.City,
                State = eligibilityData.State,
                Zip = eligibilityData.Zip,
                Dob = eligibilityData.Dob,
                FieldOfWork = eligibilityData.FieldOfWork,
                Degree = eligibilityData.Degree,
                Company = eligibilityData.Company,
                Availability = eligibilityData.Availability,
                Email = email,
                Password = hashedPassword,
                Address = new Address
                {
                    StreetAddress = streetAddress,
                    City = eligibilityData.City,
                    State = eligibilityData.State,
                    ZipCode = eligibilityData.Zip
                },
                //NEED TO ADD DROP DOWN TO SPECIFY THE WORK AREA OF FOCUS
                //ex. CYBER SECURITY, SOFTWARE ENGINEERING, OTHER, ETC. 
                //GIVE NUMERICAL VALUE TO SELECTIOn
                //HAVE THE FIELD OF WORK AREA BE THEIR SPECIFIC TITLE
            }) ;
         

            
            _dbContext.SaveChanges();
        }

    }
}

