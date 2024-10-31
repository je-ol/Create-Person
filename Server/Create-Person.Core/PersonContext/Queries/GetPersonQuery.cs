using MediatR;
using Create_Person.Core.PersonContext.DTOs;
using Create_Person.Domain.Errors;
using CSharpFunctionalExtensions;

namespace Create_Person.Core.PersonContext.Queries
{
    public class GetPersonQuery : IRequest<Result<PersonDetailsDto, Error>>
    {
        public Guid Id { get; init; }

        public GetPersonQuery(Guid id)
        {
            Id = id;
        }
    }
}