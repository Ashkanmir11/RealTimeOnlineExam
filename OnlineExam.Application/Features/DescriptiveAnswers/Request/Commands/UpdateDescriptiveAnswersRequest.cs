
using MediatR;
using OnlineExam.Application.DTOs.DescriptiveAnswers;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands
{
    public class UpdateDescriptiveAnswersRequest : IRequest
    {
        public int Id { get; set; }
        public required UpdateDescriptiveAnswersDTO UpdateDescriptiveAnswersDTO { get; set; }
    }
}
