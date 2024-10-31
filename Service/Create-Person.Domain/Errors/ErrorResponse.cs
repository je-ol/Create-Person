namespace Create_Person.Domain.Errors
{
    public class ErrorResponse
    {
        public string Type { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public IReadOnlyList<string> Messages { get; set; } = new List<string>();
    }
}