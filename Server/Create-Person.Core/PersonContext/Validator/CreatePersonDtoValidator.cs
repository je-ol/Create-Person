using Create_Person.Core.PersonContext.DTOs;
using FluentValidation;

namespace Create_Person.Core.PersonContext.Validator
{
    public class CreatePersonDtoValidator : AbstractValidator<CreatePersonDto>
    {
        public CreatePersonDtoValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("Please enter your first name.")
                .Length(1, 30)
                .Must(name => !name.Any(char.IsDigit)).WithMessage("First name must not contain numbers.");
            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Please enter your last name.")
                .Length(1, 30)
                .Must(name => !name.Any(char.IsDigit)).WithMessage("Last name must not contain numbers.");
        }
    }
}