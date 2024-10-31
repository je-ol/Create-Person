using MediatR;
using CSharpFunctionalExtensions;
using Create_Person.Core.PersonContext.Commands;
using Create_Person.Core.PersonContext.DTOs;
using Create_Person.Core.Services;
using Create_Person.Domain.Repositories;
using Create_Person.Domain.Entities;
using Microsoft.Extensions.Logging;


namespace Create_Person.Business.PersonContext.CommandHandlers
{
public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Result<CreatePersonResponseDto>>
    {
        private readonly IPersonService _personService;
        private readonly ILogger<CreatePersonCommandHandler> _logger;
    
        public CreatePersonCommandHandler(IPersonService personService, ILogger<CreatePersonCommandHandler> logger)
        {
            _personService = personService;
            _logger = logger;
        }
        public async Task<Result<CreatePersonResponseDto>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            return await Result.Success(request)
                .Map(request => new Person(request.PersonDto.FirstName, request.PersonDto.LastName))
                .Bind(async person => await _personService.CreatePersonAsync(person))
                    .Tap(() => _logger.LogInformation("Person has been successfully saved to the cache"))
                    .TapError(() => _logger.LogError("Something went wrong saving this person to the cache"))
                .Map(personId => new CreatePersonResponseDto
                {
                    Id = personId 
                });
        }
    }
}