namespace Create_Person.Domain.Errors
{
    public readonly struct Error
    {   
        public ErrorType Type { get; }
        public IReadOnlyList<string> Messages { get; }
        public DateTime Date { get; }

        private Error(ErrorType errorType, IEnumerable<string> messages) : this(errorType, messages.ToArray())
        {
        }
        private Error(ErrorType errorType, params string[] messages)
        {
            Type = errorType;
            Messages = messages;
            Date = DateTime.Now;
        }

        public static Error NotFound(string error)
        {
            return new Error(ErrorType.NotFound, error);
        }

        public static Error NotFound(IEnumerable<string> errors)
        {
            return new Error(ErrorType.NotFound, errors);
        }

        public static Error BadRequest(string error)
        {
            return new Error(ErrorType.BadRequest, error);
        }

        public static Error BadRequest(IEnumerable<string> errors)
        {
            return new Error(ErrorType.BadRequest, errors);
        }

        public ErrorResponse ToErrorResponse()
        {
            return new ErrorResponse
            {
                Type = Type.ToString(),
                Date = Date,
                Messages = Messages
            };
        }


        
    }
}