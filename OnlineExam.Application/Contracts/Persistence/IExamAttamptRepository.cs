using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IExamAttamptRepository : IGenericRepository<ExamAttampt>
    {
        Task<bool> ExamEndedAsync(int examId, string userId);
        Task<bool> ExamStartedAsync(int examId, string userId);
        Task EndExamAsync(int examId, string userId);
        Task<double> GetRemainingSeconds(int examId, string studentId);
    }
}
