using CSharpFunctionalExtensions;
using Create_Person.Domain.Entities;
using Create_Person.Domain.Errors;

namespace Create_Person.Core.Services
{
    public interface IPersonService
    {
        Task <Result<Person, Error>> GetByIdAsync(Guid id);
        Task <Result<Guid>> CreatePersonAsync(Person person);
    }
}
