using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Commands
{
    public class CreateTrueOrFalseQuestionRequest : IRequest<int>
    {
        public required CreateTrueOrFalseQuestionDTO CreateTrueOrFalseQuestionDTO { get; set; }
    }
}
