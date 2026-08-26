using MediatR;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Commands
{
    public class DeleteTrueOrFalseQuestionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
