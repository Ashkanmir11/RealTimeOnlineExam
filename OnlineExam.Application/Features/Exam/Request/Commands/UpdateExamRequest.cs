using MediatR;
using OnlineExam.Application.DTOs.Exam;

namespace OnlineExam.Application.Features.Exam.Request.Commands
{
    public class UpdateExamRequest : IRequest
    {
        public int Id { get; set; }
        public required UpdateExamDTO UpdateExamDTO { get; set; }
    }
}
