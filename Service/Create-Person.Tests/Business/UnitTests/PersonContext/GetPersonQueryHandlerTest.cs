using Moq;
using Xunit;
using Create_Person.Business.PersonContext.QueryHandlers;
using Create_Person.Domain.Entities;
using CSharpFunctionalExtensions;

namespace Create_Person.Tests.Business.PersonContext
{
    public class GetPersonQueryHandlerTest
    {
        public GetPersonQueryHandlerTest()
        {

        }
        public void ShouldReturnAPerson()
        {
            var stubPerson = new Person(
                "Jane",
                "Doe"
            );
            
        }
    }
}