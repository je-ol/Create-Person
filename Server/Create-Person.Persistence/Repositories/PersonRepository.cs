using CSharpFunctionalExtensions;
using Create_Person.Domain.Entities;
using Create_Person.Domain.Repositories;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Create_Person.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMemoryCache _cache;
        private const string PersonCacheKey = "Persons";

        public PersonRepository(IMemoryCache cache)
        {
            _cache = cache;
            InitializeCache();
        }
        public Task<Result<Guid>> AddAsync(Person person) =>
            Task.FromResult(
                Result.Success(person.Id))
                .Tap(() => 
                    {
                        var persons = _cache.Get<Dictionary<Guid, Person>>(PersonCacheKey) ?? new Dictionary<Guid, Person>();
                        persons.Add(person.Id, person);
                        _cache.Set(PersonCacheKey, persons);
                    });


        public Task<Maybe<Person>> GetByIdAsync(Guid id) =>
            Task.FromResult(
                Maybe<Dictionary<Guid, Person>> 
                    .From(_cache.Get<Dictionary<Guid,Person>>(PersonCacheKey))
                    .Bind(persons => 
                        persons.TryGetValue(id, out var person) ? Maybe<Person>.From(person) : Maybe<Person>.None)
            );

        private void InitializeCache()
        {
            _cache.GetOrCreate(PersonCacheKey, _ => new Dictionary<Guid, Person>());
        }
    }
}