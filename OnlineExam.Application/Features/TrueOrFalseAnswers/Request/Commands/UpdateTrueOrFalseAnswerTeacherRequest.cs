using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands
{
    public class UpdateTrueOrFalseAnswerTeacherRequest : IRequest
    {
        public required UpdateTrueOrFalseAnswerTeacherDTO? UpdateTrueOrFalseAnswerTeacherDTO { get; set; }
        public int Id { get; set; }
    }
}
