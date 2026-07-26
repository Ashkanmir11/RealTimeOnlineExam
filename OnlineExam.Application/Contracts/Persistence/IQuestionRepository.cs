using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Response;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task DeleteQuestionDetailAsync(int questionId);
        Task<PaginateResponse<TResult>> GetByExamIdAsync<TResult>(int examId,bool randomQuestions, string? studentId,PaginateRequestDTO paginateRequestDTO);
        Task<Question> GetByQuestionDetailIdAsync(bool trueOrFalse, bool multipleChoice, bool descriptive, int id);
        Task RemoveNoRelationQuestionDetail();
    }
}
