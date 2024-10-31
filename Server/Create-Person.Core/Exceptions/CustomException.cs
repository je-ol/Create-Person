using Create_Person.Domain.Errors;

namespace Create_Person.Core.Exceptions
{
    public class CustomException : Exception
    {
        public Error Error { get; }
        public CustomException(string message) : base(message)
        {

        }
        public CustomException(string message, Error error) : base(message)
        {
            Error = error;
        }
        public CustomException(Error error) : base(error.Messages.FirstOrDefault())
        {
            Error = error;
        }
    }
}
