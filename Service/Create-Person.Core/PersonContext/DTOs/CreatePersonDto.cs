namespace Create_Person.Core.PersonContext.DTOs
{
    public class CreatePersonDto
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
    }
}