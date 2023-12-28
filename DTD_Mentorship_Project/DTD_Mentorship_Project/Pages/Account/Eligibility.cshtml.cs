using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using DTD_Mentorship_Project.Models;
using Newtonsoft.Json; // Add this using statement for JSON serialization
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DTD_Mentorship_Project.Pages
{
    public class Eligibility : PageModel
    {
        private readonly DBContext _bdContext;
        private readonly ILogger<Eligibility> _logger;

        public Eligibility(DBContext bdContext, ILogger<Eligibility> logger)
        {
            _bdContext = bdContext;
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
        [RegularExpression(@"^\d{1,5}\s\w+", ErrorMessage = "Invalid Street Address Format.")]
        public string StreetAddress { get; set; } = "";


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

        public void OnGet()
        {
            // Initialization logic for GET request
        }


        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Error = "Please correct field(s) as required!";
                return Page(); // Return the page with validation errors
            }
            TempData["EligibilityConfirmed"] = true;


            TempData["EligibilityData"] = JsonConvert.SerializeObject(new User
            {
                IdentityId = SelectedUserTypeId,
                FirstName = FirstName,
                LastName = LastName,
                City = City,
                State = State,
                Zip = Zip,
                Dob = DOB,
                FieldOfWork = FieldofWork,
                Degree = Degree,
                Company = Company,
                Availability = Availability,
            });

            TempData["UserStreetAddress"] = StreetAddress;

            return RedirectToPage("/Account/Registration");
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