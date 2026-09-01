using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.Question.Request.Queries
{
    public class GetQuestionRequest : IRequest<PaginateResponse<GetQuestionTeacherDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
