using MediatR;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace Create_Person.API.Controllers.Base
{
    [Route("[controller]")]
    public class ApiController : Controller
    {
        public IMediator Mediator { get; }
        public ApiController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IActionResult? ValidateRequest<T>(T request, IValidator<T> validator)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            return null; // it returns null when there is no error*
        }
    }
}