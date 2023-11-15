using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DTD_Mentorship_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignupController : ControllerBase
    {
        private readonly IValidator<personModel> _personValidator;

        public SignupController(IValidator<personModel> personValidator)
        {
            _personValidator = personValidator;
        }

        [HttpPost]
        public IActionResult SignUp(personModel person)
        {
            // Validate the incoming PersonModel using FluentValidation
            var validationResult = _personValidator.Validate(person);

            if (!validationResult.IsValid)
            {
                // Return validation errors to the client
                var errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }

                return BadRequest(errors);
            }

            // Form data is valid, process the form submission
            // Access form fields using person.Name, person.Age, person.City, person.State, person.ZipCode
            // Perform your logic here, such as saving the data to a database

            // Return a success response if the form submission was successful
            return Ok("Form submitted successfully!"); // You can customize the success message if needed
        }
    }
}

