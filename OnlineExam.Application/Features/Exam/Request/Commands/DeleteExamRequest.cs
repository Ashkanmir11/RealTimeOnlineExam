using MediatR;

namespace OnlineExam.Application.Features.Exam.Request.Commands
{
    public class DeleteExamRequest : IRequest
    {
        public int Id { get; set; }
    }
}
