using MediatR;
using OnlineExam.Application.DTOs.ExamLog;

namespace OnlineExam.Application.Features.ExamLog.Request.Queries
{
    public class GetExamLogForTeacherRequest : IRequest<List<GetExamLogDTO>>
    {
        public required int ExamId { get; set; }
        public required string StudentId { get; set; }
    }
}
