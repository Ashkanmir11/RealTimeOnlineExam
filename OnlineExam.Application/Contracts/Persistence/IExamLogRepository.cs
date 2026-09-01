using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IExamLogRepository : IGenericRepository<ExamLog>
    {
        Task<List<GetExamLogDTO>> GetForTeacher(string studentId, int examId);
    }
}
