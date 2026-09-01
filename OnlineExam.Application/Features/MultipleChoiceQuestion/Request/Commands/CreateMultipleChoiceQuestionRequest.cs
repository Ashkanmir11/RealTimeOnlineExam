using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Commands
{
    public class CreateMultipleChoiceQuestionRequest : IRequest<int>
    {
        public required CreateMultipleChoiceQuestionDTO CreateMultipleChoiceQuestionDTO { get; set; }
    }
}
