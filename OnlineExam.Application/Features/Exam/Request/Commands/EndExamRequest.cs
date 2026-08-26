using MediatR;

namespace OnlineExam.Application.Features.Exam.Request.Commands
{
    public class EndExamRequest : IRequest
    {
        public int ExamId { get; set; }
    }
}
