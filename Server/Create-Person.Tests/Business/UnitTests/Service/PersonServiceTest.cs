using Xunit;
using Moq;
using Create_Person.Business.Services;
using Create_Person.Domain.Repositories;
using Create_Person.Domain.Entities;
using CSharpFunctionalExtensions;

namespace Create_Person.Test.Service
{
    public class PersonServiceTest
    {
        public readonly Mock<IPersonRepository> _mockPersonRepository;

        public PersonServiceTest()
        {
            _mockPersonRepository = new();
        }
        
        [Fact]
        public async Task CreatePersonAsync_CreatesPerson_ReturnsId()
        {
            // Arrange
            var stubPerson = new Person(
                "Jane",
                "Doe"
            );

            _mockPersonRepository
                .Setup(repository => repository.AddAsync(stubPerson))
                .ReturnsAsync(Result.Success(stubPerson.Id));

            // Act
            var result = await _mockPersonRepository.Object.AddAsync(stubPerson);
            
            // Assert
            Assert.Equal(result.Value, stubPerson.Id);
            Assert.True(result.IsSuccess);
        }
        [Fact]
        public async Task GetByIdAsync_ReturnsPersonDetails()
        {
            // Arrange
            var stubPerson = new Person(
                "Jane",
                "Doe"
            );

            _mockPersonRepository
                .Setup(repository => repository.GetByIdAsync(stubPerson.Id))
                .ReturnsAsync(stubPerson);

            // Act
            var result = await _mockPersonRepository.Object.GetByIdAsync(stubPerson.Id);
                

            // Assert
            Assert.Equal(result.Value, stubPerson);
        }
    }
}