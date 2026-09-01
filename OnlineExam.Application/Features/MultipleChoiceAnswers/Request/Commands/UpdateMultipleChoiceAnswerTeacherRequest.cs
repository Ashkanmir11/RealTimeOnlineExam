using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands
{
    public class UpdateMultipleChoiceAnswerTeacherRequest : IRequest
    {
        public required UpdateMultipleChoiceAnswerTeacherDTO UpdateMultipleChoiceAnswerTeacherDTO { get; set; }
        public int Id { get; set; }
    }
}
