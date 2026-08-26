using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.Question.Request.Queries
{
    public class GetQuestionTeacherRequest : IRequest<PaginateResponse<GetQuestionTeacherDTO>>
    {
        public int ExamId { get; set; }
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
