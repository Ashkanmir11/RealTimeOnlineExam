namespace OnlineExam.Application.Exceptions
{
    public class AccessForbiddenException : ApplicationException
    {
        public AccessForbiddenException(string massage) : base(massage)
        {
        }
    }
}
