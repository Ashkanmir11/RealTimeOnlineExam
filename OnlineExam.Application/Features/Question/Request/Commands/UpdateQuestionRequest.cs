using MediatR;
using OnlineExam.Application.DTOs.Question;

namespace OnlineExam.Application.Features.Question.Request.Commands
{
    public class UpdateQuestionRequest : IRequest
    {
        public int Id { get; set; }
        public required UpdateQuestionDTO UpdateQuestionDTO { get; set; }
    }
}
