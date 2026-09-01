using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Commands
{
    public class UpdateTrueOrFalseQuestionRequest : IRequest
    {
        public required UpdateTrueOfFalseQuestionDTO UpdateTrueOfFalseQuestionDTO { get; set; }
    }
}
