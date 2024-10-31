using MediatR;
using CSharpFunctionalExtensions;
using Create_Person.Core.PersonContext.Queries;
using Create_Person.Core.Services;
using Create_Person.Core.Exceptions;
using Create_Person.Core.PersonContext.DTOs;
using Create_Person.Domain.Errors;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Create_Person.Business.PersonContext.QueryHandlers
{
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, Result<PersonDetailsDto, Error>>
    {
        private readonly IPersonService _personService;
        private readonly ILogger<GetPersonQueryHandler> _logger;

        public GetPersonQueryHandler(IPersonService personService, ILogger<GetPersonQueryHandler> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        public async Task<Result<PersonDetailsDto, Error>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var personResult = await _personService.GetByIdAsync(request.Id);
            if (!personResult.IsSuccess)
            {
                _logger.LogError("There was a problem retrieving the person from the cache associated with this id: {id}", request.Id);
                throw new CustomException(personResult.Error);
            }
            else
            {
                _logger.LogInformation("Person was succefully retrieved from the cache");
                return personResult.Map(person => new PersonDetailsDto
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName
                });
            }

        }
    }
}