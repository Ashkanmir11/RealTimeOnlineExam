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
        Task<PaginateResponse<GetQuestionDTO>> GetByExamId(int ExamId,bool RandomQuestions, string? StudentId,PaginateRequestDTO paginateRequestDTO);
    }
}
