using MediatR;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Request.Commands
{
    public class DeleteDescriptiveQuestionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
