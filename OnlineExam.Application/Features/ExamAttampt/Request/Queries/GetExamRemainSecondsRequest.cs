using MediatR;

namespace OnlineExam.Application.Features.ExamAttampt.Request.Queries
{
    public class GetExamRemainSecondsRequest : IRequest<double>
    {
        public int ExamId { get; set; }
        public required string? currentUser { get; set; }
    }
}
