using MediatR;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands
{
    public class DeleteMultipleChoiceAnswerRequest : IRequest
    {
        public int Id { get; set; }
    }
}
