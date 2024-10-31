
namespace Create_Person.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Person(string firstname, string lastname)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
        }

    }
}