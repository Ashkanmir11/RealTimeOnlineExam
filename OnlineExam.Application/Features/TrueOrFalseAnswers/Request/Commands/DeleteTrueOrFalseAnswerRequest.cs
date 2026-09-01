using MediatR;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands
{
    public class DeleteTrueOrFalseAnswerRequest : IRequest
    {
        public int Id { get; set; }
    }
}
