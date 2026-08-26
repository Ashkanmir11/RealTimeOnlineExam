namespace OnlineExam.Application.Exceptions
{
    public class ConflictException : ApplicationException
    {
        public ConflictException(string massage) : base(massage)
        {
        }
    }
}
