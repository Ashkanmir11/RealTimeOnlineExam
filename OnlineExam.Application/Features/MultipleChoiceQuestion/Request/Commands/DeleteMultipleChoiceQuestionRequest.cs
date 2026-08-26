using MediatR;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Commands
{
    public class DeleteMultipleChoiceQuestionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
