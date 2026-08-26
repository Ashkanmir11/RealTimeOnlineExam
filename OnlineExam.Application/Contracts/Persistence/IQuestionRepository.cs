using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Response;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Enums;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task DeleteQuestionDetailAsync(int questionId);
        Task<PaginateResponse<TResult>> GetByExamIdAsync<TResult>(int examId, bool randomQuestions, string? studentId, PaginateRequestDTO paginateRequestDTO);
        Task<Question> GetByQuestionDetailIdAsync(QuestionType questionType, int id);
        Task RemoveNoRelationQuestionDetail();
    }
}
