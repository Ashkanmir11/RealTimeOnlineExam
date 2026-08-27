using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Response;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<bool> IsUserTeacherAsync(string userId, int examId);
        Task<PaginateResponse<GetExamDetailDTO>> GetByClassIdAsync(int classId, PaginateRequestDTO paginateRequestDTO);
        Task<bool> CanModifyExamAsync(int examId);
        Task <bool> IsExamFullyEnded(int examId);
    }
}
