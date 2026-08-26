using MediatR;

namespace OnlineExam.Application.Features.ExamAttampt.Request.Queries
{
    public class ExamAttamptStartedRequest : IRequest<bool>
    {
        public required string UserId { get; set; }
        public int ExamId { get; set; }
    }
}
