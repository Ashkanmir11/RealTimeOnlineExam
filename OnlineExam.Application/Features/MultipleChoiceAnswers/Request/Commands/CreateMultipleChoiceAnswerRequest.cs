using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands
{
    public class CreateMultipleChoiceAnswerRequest : IRequest
    {
        public required CreateMultipleChoiceAnswerDTO CreateMultipleChoiceQuestionAnswerDTO { get; set; }
    }
}
