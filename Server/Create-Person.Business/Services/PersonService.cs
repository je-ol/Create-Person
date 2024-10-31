using Create_Person.Core.Services;
using Create_Person.Core.Exceptions;
using Create_Person.Domain.Repositories;
using Create_Person.Domain.Entities;
using Create_Person.Domain.Errors;
using CSharpFunctionalExtensions;

namespace Create_Person.Business.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        
        public Task<Result<Person, Error>> GetByIdAsync(Guid Id) 
        {
            return Result.SuccessIf(Id != Guid.Empty, Id, Error.BadRequest("Invalid ID"))
                .Bind(async validId => 
                {
                    return await _personRepository.GetByIdAsync(validId)
                        .ToResult(Error.NotFound("Person not found"));;
                });       
        }

        public async Task <Result<Guid>> CreatePersonAsync(Person person)
        {
            return await Result.SuccessIf(person != null, person, "Person cannot be null") 
                .Bind(async validPerson => 
                    {
                        return await _personRepository.AddAsync(validPerson!); 
                    }
                );
        }  
    }
  
}