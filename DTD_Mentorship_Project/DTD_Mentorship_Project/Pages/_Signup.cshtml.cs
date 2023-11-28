using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FluentValidation;
using DTD_Mentorship_Project; // Namespace where your models are defined
using System.Diagnostics;
using System.Text.Json;


namespace DTD_Mentorship_Project.Pages
{
    public class _Signup : PageModel
    {

        private readonly IValidator<personModel> _personValidator;

        public _Signup(IValidator<personModel> personValidator)
        {
            _personValidator = personValidator;
            Person = new personModel(); //initialize the Person property
            var json = JsonSerializer.Serialize(Person);
            Debug.WriteLine(json);
        }

        [BindProperty]
        public personModel Person { get; set; } // BindProperty for form data

        public void OnGet()
        {
            // Initialization logic for GET request
            // Load city data when the page loads
            LoadCities();
        }

        // Define the LoadCities method to load city data
        private void LoadCities()
        {
            // Implement logic to load city data here
            // For example, you can fetch city data from a database or an API and populate the dropdown list
        }

        public IActionResult OnPost()
        {
            // Validate the PersonModel using FluentValidation
            var validationResult = _personValidator.Validate(Person);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                LoadCities(); // Load cities again to repopulate the dropdowns
                return Page(); // Return the page with validation errors
            }

            // Form data is valid, process the form submission
            // Access form fields using Person.Name, Person.Age, Person.City, Person.State, Person.ZipCode
            // Perform your logic here, such as saving the data to a database

            // Redirect to a success page or perform other actions
            return RedirectToPage("Action", "SignupController"); // Replace "SuccessPage" with the actual success page route
        }
    }
}

