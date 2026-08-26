namespace OnlineExam.Persistence.Exceptions
{
    public class DbConflictException : ApplicationException
    {
        public DbConflictException(string massage) : base(massage)
        {
        }
    }
}
