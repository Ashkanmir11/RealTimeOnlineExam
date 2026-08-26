using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.Question.Request.Queries
{
    public class GetQuestionWithAnswerRequest : IRequest<PaginateResponse<GetQuestionWithAnswerDTO>>
    {
        public int ExamId { get; set; }
        public required string StudentId { get; set; }
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
