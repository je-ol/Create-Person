using Moq;
using Xunit;
using Create_Person.Core.PersonContext.DTOs;
using Create_Person.Core.PersonContext.Commands;
using Create_Person.Business.PersonContext.CommandHandlers;
using Create_Person.Core.Services;
using Microsoft.Extensions.Logging;

namespace Create_Person.Test.Business.PersonContext
{
    public class CreatePersonCommandHandlerTest
    {
        private readonly Mock<IPersonService> _mockPersonService;
        private readonly Mock<ILogger<CreatePersonCommandHandler>> _mockLogger;

        public CreatePersonCommandHandlerTest()
        {
            _mockPersonService = new();
            _mockLogger = new();
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
            var handler = new CreatePersonCommandHandler(_mockPersonService.Object, _mockLogger.Object);

            // Act
            var resultId = await handler.Handle(command, CancellationToken.None);
            
            // Assert
            Assert.IsType<Guid>(resultId.Value.Id);
            Assert.NotEqual(Guid.Empty, resultId.Value.Id);
        }
    }
}