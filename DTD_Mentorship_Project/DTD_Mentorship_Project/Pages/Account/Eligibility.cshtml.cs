using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project; // Namespace where your models are defined
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DTD_Mentorship_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;

namespace DTD_Mentorship_Project.Pages
{
    public class Eligibility : PageModel
    {
        private readonly DBContext _bdContext;
        private readonly ILogger<Eligibility> _logger;

        [BindProperty]
        public User Users { get; set; }

        public Eligibility(DBContext bdContext, ILogger<Eligibility> logger)
        {
            _bdContext = bdContext;
            _logger = logger;
        }

        [BindProperty]
        [Required(ErrorMessage = "Identify yourself. The SelectedUserTypeId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid user type.")]
        public int SelectedUserTypeId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Street Address where you reside is required.")]
        public virtual ICollection<Address> Address { get; set; } = new List<Address>();

        [BindProperty]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Zip is required.")]
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
                Address = Address,
                City = City,
                State = State,
                Zip = Zip,
                DOB = DOB.ToString("yyyy-MM-dd"),
                FieldofWork = FieldofWork,
                Degree = Degree,
                Company = Company,
                Availability = Availability,
                Password = "YourPassword"  // Replace with a real password
            };

            _bdContext.Users.Add(eligibilityData);
            await _bdContext.SaveChangesAsync();

            _logger.LogInformation("Form Submission Successful.User added to Database");

            return Page();

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