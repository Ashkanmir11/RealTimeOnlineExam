using MediatR;
using OnlineExam.Application.DTOs.Question;

namespace OnlineExam.Application.Features.Question.Request.Commands
{
    public class CreateQuestionRequest : IRequest
    {
        public required CreateQuestionDTO CreateQuestionDTO { get; set; }
    }
}
