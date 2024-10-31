using MediatR;
using Create_Person.Core.PersonContext.DTOs;
using CSharpFunctionalExtensions;

namespace Create_Person.Core.PersonContext.Commands
{
    public class CreatePersonCommand : IRequest<Result<CreatePersonResponseDto>>
    {
        public CreatePersonDto PersonDto { get; }

        public CreatePersonCommand(CreatePersonDto personDto)
        {
            PersonDto = personDto;
        }
    }
}
