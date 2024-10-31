using FluentValidation;
using Create_Person.Core.PersonContext.Queries;

namespace Create_Person.Core.PersonContext.Validator
{
    public class GetPersonQueryValidator : AbstractValidator<GetPersonQuery>
    {
        public GetPersonQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotEmpty().WithMessage("ID cannot be empty")
                .NotNull().WithMessage("A valid ID must be provided"); 
        }
    }
}