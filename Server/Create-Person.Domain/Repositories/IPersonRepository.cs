using Create_Person.Domain.Entities;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Create_Person.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Result<Guid>> AddAsync(Person person);
        Task<Maybe<Person>> GetByIdAsync(Guid id);
    }
}