using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;
using Create_Person.Domain.Entities;
using Create_Person.Persistence.Repositories;

namespace Create_Person.Tests.Repositories
{
    public class PersonRepositoryTests
    {
        private readonly IMemoryCache _stubCache;
        private readonly ICacheEntry _stubCacheEntry;
        private readonly string _personCacheKey = "Persons";

        public PersonRepositoryTests()
        {
            _stubCache = new MemoryCache(new MemoryCacheOptions());
            _stubCacheEntry = new Mock<ICacheEntry>().Object;
        }
        [Fact]
        public void Constructor_InitializeCache()
        {
            _stubCache.TryGetValue(_personCacheKey, out object? value);
            var repository = new PersonRepository(_stubCache);
        }

        [Fact]
        public async Task AddAsync_AddPersonToCache()
        {
            // Arrange
            var mockPerson = new Person(
                "John",
                "Smith"
            );
            var repository = new PersonRepository(_stubCache);

            // Act
            var guidResult = await repository.AddAsync(mockPerson);

            // Assert
            _stubCache.TryGetValue(_personCacheKey, out Dictionary<Guid, Person>? cachedPersons);

            cachedPersons!.TryGetValue(mockPerson.Id, out var cachedPerson);

            Assert.Equal(mockPerson, cachedPerson);
            
        }
    }
}
