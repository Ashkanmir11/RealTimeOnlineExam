using MediatR;
using OnlineExam.Application.DTOs.DescriptiveQuestion;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Request.Commands
{
    public class UpdateDescriptiveQuestionRequest : IRequest
    {
        public required UpdateDescriptiveQuestionDTO UpdateDescriptiveQuestionDTO { get; set; }
    }
}
