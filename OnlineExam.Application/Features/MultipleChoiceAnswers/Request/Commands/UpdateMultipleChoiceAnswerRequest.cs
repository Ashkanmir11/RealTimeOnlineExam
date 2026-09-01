using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands
{
    public class UpdateMultipleChoiceAnswerRequest : IRequest
    {
        public int Id { get; set; }
        public required UpdateMultipleChoiceAnswerDTO UpdateMultipleChoiceQuestionAnswerDTO { get; set; }
    }
}
