using MediatR;

namespace OnlineExam.Application.Features.Question.Request.Commands
{
    public class DeleteQuestionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
