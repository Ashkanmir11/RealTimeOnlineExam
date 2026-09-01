using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands
{
    public class UpdateTrueOrFalseAnswerRequest : IRequest
    {
        public int Id { get; set; }
        public required UpdateTrueOrFalseAnswerDTO UpdateTrueOrFalseQuestionAnswerDTO { get; set; }
    }
}
