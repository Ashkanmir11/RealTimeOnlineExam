namespace OnlineExam.Application.Contracts.AIServices
{
    public interface IAiServices
    {
        Task<decimal> GetScoreAsync(string studentText, string correctText, decimal score);
    }
}
