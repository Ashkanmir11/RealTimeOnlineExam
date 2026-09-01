using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands
{
    public class CreateTrueOrFalseAnswerRequest : IRequest
    {
        public required CreateTrueOrFalseAnswerDTO CreateTrueOrFalseQuestionAnswerDTO { get; set; }
    }
}
