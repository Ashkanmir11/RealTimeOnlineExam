using MediatR;
using OnlineExam.Application.DTOs.DescriptiveAnswers;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands
{
    public class UpdateDescriptiveAnswersTeacherRequest : IRequest
    {
        public required UpdateDescriptiveAnswersTeacherDTO updateDescriptiveAnswersTeacherDTO { get; set; }
        public int Id { get; set; }
    }

}
