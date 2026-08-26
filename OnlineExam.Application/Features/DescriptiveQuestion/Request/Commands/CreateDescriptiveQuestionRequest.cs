using MediatR;
using OnlineExam.Application.DTOs.DescriptiveQuestion;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Request.Commands
{
    public class CreateDescriptiveQuestionRequest : IRequest<int>
    {
        public required CreateDescriptiveQuestionDTO CreateDescriptiveQuestionDTO { get; set; }
    }
}
