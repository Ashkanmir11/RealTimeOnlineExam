using MediatR;

namespace OnlineExam.Application.Features.ExamAttampt.Request.Queries
{
    public class ExamAttamptEndedRequest : IRequest<bool>
    {
        public int ExamId { get; set; }
        public required string UserId { get; set; }
    }
}
