using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project; // Namespace where your models are defined
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using DTD_Mentorship_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Geocoding;
using Geocoding.Google;
using DTD_Mentorship_Project.Pages.Profile;

namespace DTD_Mentorship_Project.Pages
{
    public class Eligibility : PageModel
    {
        //Connect Geo Services
        private readonly GeocodingService _geocodingService;
        //Initialize DB context
        private readonly DBContext _bdContext;
        private readonly ILogger<Eligibility> _logger;


        public Eligibility(DBContext bdContext, GeocodingService geocodingService, ILogger<Eligibility> logger)
        {
            _bdContext = bdContext;
            _geocodingService = geocodingService;
            _logger = logger;
        }

        [BindProperty]
        public User Users { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Identify yourself. The SelectedUserTypeId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid user type.")]
        public int SelectedUserTypeId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; } = "";


        [BindProperty]
        [Required(ErrorMessage = "Street Address where you reside is required.")]
        [StreetAddressValidation(ErrorMessage = "Invalid street address format.")]
        public virtual ICollection<DTD_Mentorship_Project.Models.Address> Addresses { get; set; } = new List<DTD_Mentorship_Project.Models.Address>();

        [BindProperty]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Zip is required.")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid ZIP code format.")]
        public string Zip { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [DOBNotLessThan18(ErrorMessage = "Date of Birth must be at least 18 years ago.")]
        public DateTime DOB { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Field of Work is required.")]
        public string FieldofWork { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Degree is required.")]
        public string Degree { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Company is required.")]
        public string Company { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Availability is required.")]
        public DateTime? Availability { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must agree to the Terms and Conditions.")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the Terms and Conditions.")]
        public bool TermsofServiceCheckbox { get; set; }

        public string Success = "";
        public string Error = "";

        /* Fetch City, State, Zip Data from Google Api 
        [HttpGet]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SuggestCitiesAndZips(string input)
        {
            try
            {
                var suggestions = await _geocodingService.SuggestCitiesAndZips(input);
            return new JsonResult(suggestions);
        }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error calling Google Geocoding API.");
                    return StatusCode(500, "Error calling Google Geocoding API.");
    }
}*/

        public void OnGet()
        {
            // Initialization logic for GET request
        }


        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Form submission failed due to validstion errors.");
                Error = "Please correct field(s) as required!";
				return Page(); // Return the page with validation errors
			}
            TempData["EligibilityConfirmed"] = true;

            Success = "Your Form was Submitted Correctly!";

            var eligibilityData = new User
            {
                SelectedUserTypeId = SelectedUserTypeId.ToString(),
                FirstName = FirstName,
                LastName = LastName,
                Addresses = Addresses,
                City = City,
                State = State,
                Zip = Zip,
                DOB = DOB.ToString("yyyy-MM-dd"),
                FieldofWork = FieldofWork,
                Degree = Degree,
                Company = Company,
                Availability = Availability,
            };

            _bdContext.Users.Add(eligibilityData);
            await _bdContext.SaveChangesAsync();

            _logger.LogInformation("Form Submission Successful.User added to Database");

            return RedirectToPage("/Account/Registration");
        }

        /* Validate Stree Address */
        public class StreetAddressValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is ICollection<Geocoding.Address> addresses)
                {
                    if (value is string streetAddress)
                    {
                        if (!IsValidStreetAddress(streetAddress))
                        {
                            return new ValidationResult(ErrorMessage);
                        }
                    }
                }

                return ValidationResult.Success;
            }

            private bool IsValidStreetAddress(string streetAddress)
            {
                // Regex pattern for at least 1-5 digits followed by a space and a string
                var pattern = @"^\d{1,5}\s\w+";
                return Regex.IsMatch(streetAddress, pattern);
            }
        }


        // Custom validation attribute for DOB
        public class DOBNotLessThan18Attribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime dateOfBirth)
                {
                    // Adjust the current date based on the user's timezone if needed
                    var currentDate = DateTime.UtcNow;
                    var minDate = currentDate.AddYears(-18);

                    if (dateOfBirth >= minDate)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }

                return ValidationResult.Success;
            }
        }
    }
}