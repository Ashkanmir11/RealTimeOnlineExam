using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Queries
{
    public class GetTrueOrFalseQuestionRequest : IRequest<PaginateResponse<GetTrueOrFalseQuestionDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
