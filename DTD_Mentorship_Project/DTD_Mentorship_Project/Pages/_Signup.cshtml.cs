using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project; // Namespace where your models are defined
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DTD_Mentorship_Project.Pages
{
    public class _Signup : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Identify yourself. The SelectedUserTypeId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid user type.")]
        public int SelectedUserTypeId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Street Address where you reside is required.")]
        public string Address { get; set; } = "";

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
        public string Availability { get; set; } = "";

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

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                Error = "Data Validtation Failed ! Correct Field/s as Required !";
                return; // Return the page with validation errors
            }
            Success = "Huuray! Your Form was Submitted Correctly :-)";

            Address = "";
            City = "";
            State = "";
            Zip = "";
            FieldofWork = "";
            Degree = "";
            Company = "";
            Availability = "";

            ModelState.Clear();
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