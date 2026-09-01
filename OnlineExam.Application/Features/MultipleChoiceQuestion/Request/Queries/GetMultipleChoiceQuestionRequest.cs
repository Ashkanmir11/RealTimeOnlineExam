using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Queries
{
    public class GetMultipleChoiceQuestionRequest : IRequest<PaginateResponse<GetMultipleChoiceQuestionDTO>>
    {
        public required PaginateRequestDTO paginateRequestDTO { get; set; }
    }
}
