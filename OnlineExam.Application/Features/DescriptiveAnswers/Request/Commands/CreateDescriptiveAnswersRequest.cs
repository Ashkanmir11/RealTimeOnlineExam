using MediatR;
using OnlineExam.Application.DTOs.DescriptiveAnswers;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands
{
    public class CreateDescriptiveAnswersRequest : IRequest
    {
        public required CreateDescriptiveAnswersDTO CreateDescriptiveAnswersDTO { get; set; }
    }
}
