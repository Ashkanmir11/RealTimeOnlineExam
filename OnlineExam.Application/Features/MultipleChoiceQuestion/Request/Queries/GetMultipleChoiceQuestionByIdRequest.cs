using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Queries
{
    public class GetMultipleChoiceQuestionByIdRequest : IRequest<GetMultipleChoiceQuestionDTO>
    {
        public int Id { get; set; }
    }
}
