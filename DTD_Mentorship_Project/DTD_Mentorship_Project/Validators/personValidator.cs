using FluentValidation;

namespace DTD_Mentorship_Project.Validators
{
    public class personValidator : AbstractValidator<personModel>
    {
        public personValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Matches("^[a-zA-Z]*$").WithMessage("Invalid name format.");
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.ZipCode).NotEmpty();
        }
    }
}
