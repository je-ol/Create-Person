using MediatR;
using FluentValidation;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Create_Person.API.Controllers.Base;
using Create_Person.Core.PersonContext.Commands;
using Create_Person.Core.PersonContext.DTOs;
using Create_Person.Core.PersonContext.Queries;
using Create_Person.Core.PersonContext.Validator;
using Create_Person.Core.Exceptions;
using Create_Person.Domain.Errors;
using Microsoft.Extensions.Logging;


namespace Create_Person.API.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : ApiController
    {
        private readonly IValidator<GetPersonQuery> _getPersonValidator;
        private readonly IValidator<CreatePersonDto> _createPersonValidator;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IMediator mediator, IValidator<GetPersonQuery> getPersonValidator, IValidator<CreatePersonDto> createPersonValidator, ILogger<PersonController> logger) : base(mediator)
        {
            _getPersonValidator = getPersonValidator;
            _createPersonValidator = createPersonValidator;
            _logger = logger;
        }

        [HttpGet("search/{id}")]
        [ProducesResponseType(typeof(PersonDetailsDto), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        
        public async Task<IActionResult> SearchPerson(Guid id)
        {   
            var query = new GetPersonQuery(id);
            var validationResult = ValidateRequest(query, _getPersonValidator);
            if (validationResult != null) // meaning is DOES contain an error
            {
                _logger.LogError("The ID failed validation");
                return validationResult;
            }

            try 
            {
                _logger.LogInformation("Searching for person with id: {id}...", id);
                var result = await Mediator.Send(query);
                return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
            }

            catch (CustomException ex)
            {
                _logger.LogError("There was an CustomException error with the search request: {Message}", ex);
                var errorResponse = ex.Error.ToErrorResponse();
                return NotFound(errorResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("General error: Something went wrong in processing this search request: {Message}", ex);
                return StatusCode(500, new { message = "There was an error, try again later" });
            }
            
        }

        [HttpPost("new")]
        [ProducesResponseType(typeof(CreatePersonResponseDto), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDto dto)
        {   
            var validationResult = ValidateRequest(dto, _createPersonValidator);
            if (validationResult != null)
            {
                _logger.LogError("The ID failed validation");
                return validationResult;
            }

            try
            {   
                var command = new CreatePersonCommand(dto);
                _logger.LogInformation("Creating person: {@dto}...", dto);
                var result = await Mediator.Send(command);
                return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
            }
            catch (CustomException ex)
            {
                _logger.LogError("There was an error in creating this person: {Message}", ex);
                var errorResponse = ex.Error.ToErrorResponse();
                return BadRequest(errorResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong in processing this request: {Message}", ex);
                return StatusCode(500, new { message = "There was an error, try again later" });
            }
        }
    }
}