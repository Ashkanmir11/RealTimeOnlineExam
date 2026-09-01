using MediatR;

namespace OnlineExam.Application.Features.ExamAttampt.Request.Commands
{
    public class CreateExamAttamptRequest : IRequest
    {
        public required string UserId { get; set; }
        public required int ExamId { get; set; }
        public int ExamMinute { get; set; }
    }
}
