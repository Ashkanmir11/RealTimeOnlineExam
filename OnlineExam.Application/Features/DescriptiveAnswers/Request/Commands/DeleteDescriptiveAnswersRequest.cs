using MediatR;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands
{
    public class DeleteDescriptiveAnswersRequest : IRequest
    {
        public int Id { get; set; }
    }
}
