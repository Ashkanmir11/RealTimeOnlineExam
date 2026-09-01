using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Queries
{
    public class GetTrueOrFalseAnswerRequest : IRequest<PaginateResponse<GetTrueOrFalseAnswerDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
