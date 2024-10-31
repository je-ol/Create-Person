namespace Create_Person.Core.PersonContext.DTOs
{
    public class PersonDetailsDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}