using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Commands
{
    public class UpdateMultipleChoiceQuestionRequest : IRequest
    {
        public required UpdateMultipleChoiceQuestionDTO UpdateMultipleChoiceQuestionDTO { get; set; }
    }
}
