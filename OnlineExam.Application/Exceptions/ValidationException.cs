namespace OnlineExam.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; }

        public ValidationException(string message) : base(message)
        {
            Errors = new List<string> { message };
        }

        public ValidationException(List<string> errors) : base("One or more errors occurred.")
        {
            Errors = errors;
        }
    }
}
