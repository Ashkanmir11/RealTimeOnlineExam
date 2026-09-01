using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Request.Queries
{
    public class GetDescriptiveQuestionRequest : IRequest<PaginateResponse<GetDescriptiveQuestionDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
