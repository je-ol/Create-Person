using Moq;
using Xunit;
using Create_Person.Core.PersonContext.DTOs;
using Create_Person.Core.PersonContext.Commands;
using Create_Person.Business.PersonContext.CommandHandlers;
using Create_Person.Core.Services;

namespace Create_Person.Test.Business.PersonContext
{
    public class CreatePersonCommandHandlerTest
    {
        private readonly Mock<IPersonService> _mockPersonService;

        public CreatePersonCommandHandlerTest()
        {
            _mockPersonService = new();
        }
        //[Fact]
        public async Task ShouldCreatePersonAndReturnID()
        {
            // Arrange
            var stubPerson = new CreatePersonDto
            {
                FirstName = "Jane",
                LastName = "Doe"
            };
            var command = new CreatePersonCommand(stubPerson);
            var handler = new CreatePersonCommandHandler(_mockPersonService.Object);

            // Act
            var resultId = await handler.Handle(command, CancellationToken.None);
            
            // Assert
            Assert.IsType<Guid>(resultId.Value);
            Assert.NotEqual(Guid.Empty, resultId.Value);
        }
    }
}