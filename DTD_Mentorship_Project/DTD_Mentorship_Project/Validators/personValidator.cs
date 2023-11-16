using FluentValidation;

namespace DTD_Mentorship_Project.Validators
{
    public class personValidator : AbstractValidator<personModel>
    {
        public personValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Matches("^[a-zA-Z]*$").WithMessage("Invalid name format.");
            RuleFor(x => x.BirthYear).NotEmpty().Must(IsValidBirthYear).WithMessage("Invalid birth year.");
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.ZipCode).NotEmpty();
        }

        private bool IsValidBirthYear(int birthYear)
        {
            // Calculate the minimum allowed birth year based on the current date
            int currentYear = DateTime.Now.Year;
            int minimumBirthYear = currentYear - 18;

            return birthYear <= minimumBirthYear;
        }
    }
}
