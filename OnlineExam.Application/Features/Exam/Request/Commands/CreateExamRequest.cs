using MediatR;
using OnlineExam.Application.DTOs.Exam;

namespace OnlineExam.Application.Features.Exam.Request.Commands
{
    public class CreateExamRequest : IRequest
    {
        public required CreateExamDTO CreateExamDTO { get; set; }
    }
}
