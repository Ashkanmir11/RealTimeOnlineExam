namespace OnlineExam.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string massage) : base(massage)
        {
        }
    }
}
